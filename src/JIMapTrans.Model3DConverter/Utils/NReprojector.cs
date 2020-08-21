using System;
using System.Collections.Generic;
using Assimp;
using DotSpatial.Projections;
using JIMapTrans.Common.Defines;

namespace Model3DConversion.Models.Utils
{
    public class NReprojector
    {
        public NReprojector(ProjectionInfo source_projection_info)
        {
            SourceProjectionInfo = source_projection_info;
            GeodeticProjectionInfo = ProjectionInfo.FromEpsgCode(ModelConversionDefines.GeographyEpsg);
            GeocentricConverter = new GeocentricGeodetic(new Spheroid(Proj4Ellipsoid.WGS_1984));
        }

        public GeocentricGeodetic GeocentricConverter { get; private set; }

        public ProjectionInfo GeodeticProjectionInfo { get; private set; }

        public ProjectionInfo SourceProjectionInfo { get; private set; }

        public Vector3D ReprojectGeocentricToGeodetic(Vector3D geocentric)
        {
            var xys_as_array = new List<double>
                               {
                                   geocentric.X,
                                   geocentric.Y
                               }.ToArray();

            var zs_as_array = new double[]
                              {
                                  geocentric.Z
                              };

            GeocentricConverter.GeocentricToGeodetic(xys_as_array, zs_as_array, 0, 1);

            return new Vector3D(Convert.ToSingle(xys_as_array[0] * 180 / Math.PI), Convert.ToSingle(xys_as_array[1] * 180 / Math.PI), Convert.ToSingle(zs_as_array[0]));
        }

        public Vector3D ReprojectGeodeticToGeocentric(Vector3D geodetic)
        {
            var xys_as_array = new List<double>
                               {
                                   geodetic.X * Math.PI / 180,
                                   geodetic.Y * Math.PI / 180
                               }.ToArray();

            var zs_as_array = new double[]
                              {
                                  geodetic.Z
                              };

            GeocentricConverter.GeodeticToGeocentric(xys_as_array, zs_as_array, 0, 1);

            return new Vector3D(Convert.ToSingle(xys_as_array[0]), Convert.ToSingle(xys_as_array[1]), Convert.ToSingle(zs_as_array[0]));
        }

        public Vector2D ReprojectGeodeticToSource(Vector2D tile_geodetic_center_coordinate)
        {
            var xys_as_array = new List<double>
                               {
                                   tile_geodetic_center_coordinate.X,
                                   tile_geodetic_center_coordinate.Y
                               }.ToArray();

            Reproject.ReprojectPoints(xys_as_array, null, GeodeticProjectionInfo, SourceProjectionInfo, 0, 1);

            return new Vector2D(Convert.ToSingle(xys_as_array[0]), Convert.ToSingle(xys_as_array[1]));
        }

        public Vector3D ReprojectSourceToGeocentric(Vector3D source_coordinate)
        {
            var geodetic_coordinate = ReprojectSourceToGeodetic(source_coordinate);

            return ReprojectGeodeticToGeocentric(geodetic_coordinate);
        }

        public Vector3D ReprojectSourceToGeodetic(Vector3D source_coordinate)
        {
            var xys_as_array = new List<double>
                               {
                                   source_coordinate.X,
                                   source_coordinate.Y
                               }.ToArray();

            var zs_as_array = new double[]
                              {
                                  source_coordinate.Z
                              };

            Reproject.ReprojectPoints(xys_as_array, zs_as_array, SourceProjectionInfo, GeodeticProjectionInfo, 0, 1);

            return new Vector3D(Convert.ToSingle(xys_as_array[0]), Convert.ToSingle(xys_as_array[1]), source_coordinate.Z);
        }
    }
}