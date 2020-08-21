using System.IO;
using CommandLineParser.Arguments;

namespace JIMapTrans.DataUploader.Models.Infos
{
    public class NModel3DConverterArgumentList
    {
        [ValueArgument(typeof(string), "input_file_extension", Optional = false, Description = "Input file extension. (https://github.com/assimp/assimp/blob/master/Readme.md)")]
        public string InputFileExtension { get; set; }

        [ValueArgument(typeof(string), "input_proj4", Optional = false, Description = "Proj4 string of input models")]
        public string InputProj4String { get; set; }

        [DirectoryArgument('i', "input", Optional = false, DirectoryMustExist = true, Description = "Input root directory path")]
        public DirectoryInfo InputRootDirectoryPath { get; set; }

        [ValueArgument(typeof(string), "output_file_extension", Optional = false, Description = "Output format id. (https://github.com/assimp/assimp/blob/master/Readme.md)")]
        public string OutputFileExtension { get; set; }

        public string OutputFormatId { get; set; }

        [BoundedValueArgument(typeof(int), 'l', "output_level", Optional = false, Description = "Level of tile structure", MinValue = 0, MaxValue = 18)]
        public int OutputLevel { get; set; }

        [DirectoryArgument('o', "output", Optional = false, DirectoryMustExist = false, Description = "Output root directory path")]
        public DirectoryInfo OutputRootDirectoryPath { get; set; }

        [DirectoryArgument('t', "temporory", Optional = false, DirectoryMustExist = false, Description = "Temporary root directory path")]
        public DirectoryInfo TemporaryRootDirectoryPath { get; set; }

        public string TextureFileExtension { get; set; }

        public string FileName { get; set; }

        [DirectoryArgument('z', "zip_output", Optional = false, DirectoryMustExist = false, Description = "Zip root directory path")]
        public DirectoryInfo ZipRootDirectoryPath { get; set; }
    }
}