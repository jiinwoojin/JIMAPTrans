using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Assimp;
using DotSpatial.Projections;
using Model3DConversion.Models.Common;
using Model3DConversion.Models.Utils;
using Newtonsoft.Json.Linq;

namespace Model3DConversion.Models.Converters
{
    public class NModel3DConverter
    {
        public NModel3DConverter(ProjectionInfo source_projection_info, string texture_file_extension, int zoom_level, string output_format_id, string output_extension)
        {
            Context = new AssimpContext();

            Reprojector = new NReprojector(source_projection_info);
            TextureFileExtension = texture_file_extension;
            ZoomLevel = zoom_level;
            OutputExtension = output_extension;
            ExportFormatId = output_format_id;
        }

        public AssimpContext Context { get; private set; }

        public string ExportFormatId { get; private set; }

        public string OutputExtension { get; private set; }

        public NReprojector Reprojector { get; private set; }

        public string TextureFileExtension { get; private set; }

        public int ZoomLevel { get; private set; }

        public Vector3D CalculateGeodeticBottomCenter(Vector3D source_model_bottom_center_coordinate)
        {
            return Reprojector.ReprojectSourceToGeodetic(source_model_bottom_center_coordinate);
        }

        public Vector3D CalculateModelBottomCenter(Scene scene)
        {
            var model_center_x = scene.Meshes.SelectMany(m => m.Vertices).Select(v => v.X).Average();
            var model_center_y = scene.Meshes.SelectMany(m => m.Vertices).Select(v => v.Y).Average();
            var model_bottom_z = scene.Meshes.SelectMany(m => m.Vertices).Select(v => v.Z).Min();

            return new Vector3D(model_center_x, model_center_y, model_bottom_z);
        }

        public string CalculateOutputDirectoryPath(string input_file_path, string output_root_directory_path, NTileAddress tile_address)
        {
            var base_name = Path.GetFileNameWithoutExtension(input_file_path);

            return string.Format(@"{0}\{1}\{2}\{3}\{4}", output_root_directory_path, tile_address.ZoomLevel, tile_address.X, tile_address.Y, base_name);
        }

        public string CalculateTemporaryFilePath(string input_file_path, string output_root_directory_path, NTileAddress tile_address)
        {
            var base_name = Path.GetFileNameWithoutExtension(input_file_path);

            return string.Format(@"{0}\{1}\{2}\{3}\{4}.{5}", output_root_directory_path, tile_address.ZoomLevel, tile_address.X, tile_address.Y, base_name, OutputExtension);
        }

        public void ConvertDirectoryRecursively(
            string input_root_directory_path, string output_root_directory_path, string temporary_root_directory_path, string input_file_extension)
        {
            var total_count = RetrieveObjFileCount(input_root_directory_path, input_file_extension);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            long success_count = 0;
            long fail_count = 0;
            foreach (var input_file_path in Directory.GetFiles(input_root_directory_path, "*.*", SearchOption.AllDirectories)
                .Where(i => i.EndsWith(input_file_extension, StringComparison.OrdinalIgnoreCase)).ToList())
            {
                bool is_success = ConvertToObjFile(input_file_path, output_root_directory_path, temporary_root_directory_path);

                string elapsed_time_span = stopwatch.Elapsed.ToString(@"dd\.hh\:mm\:ss");

                if(is_success)
                {
                    ++success_count;
                    var progressed_count = success_count + fail_count;

                    var message = string.Format(@"변환성공({0}/{1}/{2}) : {3} : {4}", fail_count, progressed_count, total_count, elapsed_time_span, input_file_path);

                    Console.WriteLine(message);
                }
                else
                {
                    ++fail_count;
                    var progressed_count = success_count + fail_count;

                    var message = string.Format(@"!!변환실패({0}/{1}/{2}) : {3} : {4}", fail_count, progressed_count, total_count, elapsed_time_span, input_file_path);

                    Console.WriteLine(message);
                }
            }

            Console.WriteLine(@"tileset combining...");

            string output_levelled_output_directory_path = NFileSystemUtil.GetAbsolutePath(output_root_directory_path, ZoomLevel.ToString());
            DoCreateTotalTileSet(output_levelled_output_directory_path);
        }

        public bool ConvertRecursively1(
            string input_root_directory_path, string output_root_directory_path, string temporary_root_directory_path, string input_file_extension)
        {
            var total_count = RetrieveObjFileCount(input_root_directory_path, input_file_extension);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            long success_count = 0;
            long fail_count = 0;
            foreach (var input_file_path in Directory.GetFiles(input_root_directory_path, "*.*", SearchOption.AllDirectories)
                .Where(i => i.EndsWith(input_file_extension, StringComparison.OrdinalIgnoreCase)).ToList())
            {
                bool is_success = ConvertToObjFile(input_file_path, output_root_directory_path, temporary_root_directory_path);

                string elapsed_time_span = stopwatch.Elapsed.ToString(@"dd\.hh\:mm\:ss");

                if (is_success)
                {
                    ++success_count;
                    var progressed_count = success_count + fail_count;

                    var message = string.Format(@"변환성공({0}/{1}/{2}) : {3} : {4}", fail_count, progressed_count, total_count, elapsed_time_span, input_file_path);

                    Console.WriteLine(message);
                }
                else
                {
                    ++fail_count;
                    var progressed_count = success_count + fail_count;

                    var message = string.Format(@"!!변환실패({0}/{1}/{2}) : {3} : {4}", fail_count, progressed_count, total_count, elapsed_time_span, input_file_path);

                    Console.WriteLine(message);
                }
            }

            Console.WriteLine(@"tileset combining...");

            string output_levelled_output_directory_path = NFileSystemUtil.GetAbsolutePath(output_root_directory_path, ZoomLevel.ToString());
            DoCreateTotalTileSet(output_levelled_output_directory_path);

            return false;
        }

        public bool ConvertRecursively(string input_file_path, string output_root_directory_path, string temporary_root_directory_path)
        {

            bool is_success = ConvertToObjFile(input_file_path, output_root_directory_path, temporary_root_directory_path);

            return is_success;
        }

        private void DoCreateTotalTileSet(string output_root_directory_path)
        {
            var arguments = string.Format(@"combine -i {0}", output_root_directory_path);
            var proc = new Process
                       {
                           StartInfo =
                           {
                               CreateNoWindow = true,
                               RedirectStandardInput = false,
                               RedirectStandardOutput = false,
                               UseShellExecute = true,
                               RedirectStandardError = false,
                               FileName = "obj23dtiles",
                               Arguments = arguments
                           }
                       };
            proc.Start();

            proc.WaitForExit();
        }

        public bool ConvertToObjFile(string input_file_path, string output_root_directory_path, string temporary_root_directory_path)
        {
            var source_model = Context.ImportFile(input_file_path);

            var source_model_bottom_center_coordinate = CalculateModelBottomCenter(source_model);
            var geodetic_bottom_center_coordinate = CalculateGeodeticBottomCenter(source_model_bottom_center_coordinate);
            var tile_address = NTileCalculator.ToTileAddress(geodetic_bottom_center_coordinate.X, geodetic_bottom_center_coordinate.Y, ZoomLevel);
            var tile_geodetic_center_coordinate = NTileCalculator.CalculateTileGeodeticCenter(tile_address);
            var tile_source_center_coordinate = Reprojector.ReprojectGeodeticToSource(tile_geodetic_center_coordinate);
            DoTransformMeshVertexes(source_model, tile_source_center_coordinate);

            var temporary_obj_file_path = CalculateTemporaryFilePath(input_file_path, temporary_root_directory_path, tile_address);
            if (!DoPrepareDirectory(Path.GetDirectoryName(temporary_obj_file_path)))
            {
                return false;
            }

            if (!Context.ExportFile(source_model, temporary_obj_file_path, ExportFormatId))
            {
                return false;
            }

            if (!DoCopyTextureFile(input_file_path, temporary_obj_file_path))
            {
                return false;
            }

            if (!DoCreateObjFileInfoJson(temporary_obj_file_path, tile_geodetic_center_coordinate))
            {
                return false;
            }

            var output_directory_path = CalculateOutputDirectoryPath(input_file_path, output_root_directory_path, tile_address);
            if (!DoPrepareDirectory(output_directory_path))
            {
                return false;
            }

            if (!DoCallObj23dtiles(temporary_obj_file_path))
            {
                return false;
            }

            if (!DoCopyTemporaryTileSetToOutputDirectory(temporary_obj_file_path, output_directory_path))
            {
                return false;
            }

            return true;
        }

        public long RetrieveObjFileCount(string input_root_directory_path, string input_file_extension)
        {
            long result = 0;
            foreach (var input_file_path in Directory.GetFiles(input_root_directory_path, "*.*", SearchOption.AllDirectories)
                .Where(i => i.EndsWith(input_file_extension, StringComparison.OrdinalIgnoreCase)).ToList())
            {
                ++result;
            }

            return result;
        }

        private bool DoCallObj23dtiles(string obj_file_path)
        {
            var info_file_path = Path.ChangeExtension(obj_file_path, @".json");
            var arguments = string.Format(@"-i {0} -p {1} --tileset --materialsCommon ", obj_file_path, info_file_path);
            var proc = new Process
                       {
                           StartInfo =
                           {
                               CreateNoWindow = true,
                               RedirectStandardInput = false,
                               RedirectStandardOutput = false,
                               UseShellExecute = true,
                               RedirectStandardError = false,
                               FileName = "obj23dtiles",
                               Arguments = arguments
                           }
                       };
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();

            proc.WaitForExit();

            return true;
        }

        private bool DoCopyTemporaryTileSetToOutputDirectory(string temporary_obj_file_path, string output_directory_path)
        {
            var base_name = Path.GetFileNameWithoutExtension(temporary_obj_file_path);
            var batch_directory_name = string.Format(@"Batched{0}", base_name);
            var batch_directory_parent_path = Path.GetDirectoryName(temporary_obj_file_path);
            var batch_directory_path = NFileSystemUtil.GetAbsolutePath(batch_directory_parent_path, batch_directory_name);
            var temporary_tile_set_file_path = NFileSystemUtil.GetAbsolutePath(batch_directory_path, "tileset.json");
            var temporary_b3dm_file_path = NFileSystemUtil.GetAbsolutePath(batch_directory_path, string.Format("{0}.b3dm", base_name));

            var output_temporary_tile_set_file_path = NFileSystemUtil.GetDestinationFilePath(batch_directory_path, output_directory_path, temporary_tile_set_file_path);
            var output_temporary_b3dm_file_path = NFileSystemUtil.GetDestinationFilePath(batch_directory_path, output_directory_path, temporary_b3dm_file_path);

            File.Copy(temporary_tile_set_file_path, output_temporary_tile_set_file_path, true);
            File.Copy(temporary_b3dm_file_path, output_temporary_b3dm_file_path, true);

            return true;
        }

        private bool DoCopyTextureFile(string input_file_path, string output_file_path)
        {
            var input_texture_file_path = Path.ChangeExtension(input_file_path, TextureFileExtension);
            var output_texture_file_path = Path.ChangeExtension(output_file_path, TextureFileExtension);
            if (string.IsNullOrWhiteSpace(input_texture_file_path))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(output_texture_file_path))
            {
                return false;
            }

            File.Copy(input_texture_file_path, output_texture_file_path, true);

            return true;
        }

        private bool DoCreateObjFileInfoJson(string obj_file_path, Vector2D geodetic_coordinate)
        {
            dynamic info = new JObject();
            info.longitude = geodetic_coordinate.X * Math.PI / 180;
            info.latitude = geodetic_coordinate.Y * Math.PI / 180;
            info.transHeight = 0.5;
            info.region = true;
            info.box = true;
            info.sphere = true;

            var info_file_path = Path.ChangeExtension(obj_file_path, @".json");
            if (string.IsNullOrWhiteSpace(info_file_path))
            {
                return false;
            }

            File.WriteAllText(info_file_path, info.ToString());

            return true;
        }

        private bool DoPrepareDirectory(string output_directory_path)
        {
            if (string.IsNullOrWhiteSpace(output_directory_path))
            {
                return false;
            }

            if (!Directory.Exists(output_directory_path))
            {
                Directory.CreateDirectory(output_directory_path);
            }

            return true;
        }

        private void DoTransformMeshVertexes(Scene scene, Vector2D tile_source_center)
        {
            foreach (var mesh in scene.Meshes)
            {
                var new_mesh_vertexes = new List<Vector3D>();
                foreach (var mesh_vertex in mesh.Vertices)
                {
                    var translated_vertex = new Vector3D
                                            {
                                                X = mesh_vertex.X - tile_source_center.X,
                                                Y = mesh_vertex.Y - tile_source_center.Y,
                                                Z = mesh_vertex.Z
                                            };

                    new_mesh_vertexes.Add(translated_vertex);
                }

                mesh.Vertices.Clear();
                mesh.Vertices.AddRange(new_mesh_vertexes);
            }
        }
    }
}