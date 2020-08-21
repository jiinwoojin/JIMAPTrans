using System;
using Assimp;

namespace Model3DConversion.Models.Utils
{
    public static class NTileCalculator
    {
        public static Vector2D CalculateTileGeodeticCenter(NTileAddress tile_address)
        {
            var center_lon = ToLongitude(tile_address.X + 0.5, tile_address.ZoomLevel);
            var center_lat = ToLatitude(tile_address.Y + 0.5, tile_address.ZoomLevel);

            return new Vector2D(Convert.ToSingle(center_lon), Convert.ToSingle(center_lat));
        }

        public static double ToLatitude(double tile_y, int zoom_level)
        {
            var n = Math.PI - 2 * Math.PI * tile_y / Math.Pow(2, zoom_level);

            return 180 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
        }

        public static double ToLongitude(double tile_x, int zoom_level)
        {
            return tile_x / Math.Pow(2, zoom_level) * 360 - 180;
        }

        public static NTileAddress ToTileAddress(double lon, double lat, int zoom_level)
        {
            var x = Convert.ToInt32(ToTileX(lon, zoom_level));
            var y = Convert.ToInt32(ToTileY(lat, zoom_level));

            return new NTileAddress
                   {
                       X = x,
                       Y = y,
                       ZoomLevel = zoom_level
                   };
        }

        public static double ToTileX(double lon, int zoom_level)
        {
            return Math.Floor((lon + 180) / 360 * Math.Pow(2, zoom_level));
        }

        public static double ToTileY(double lat, int zoom_level)
        {
            return Math.Floor((1 - Math.Log(Math.Tan(lat * Math.PI / 180) + 1 / Math.Cos(lat * Math.PI / 180)) / Math.PI) / 2 * Math.Pow(2, zoom_level));
        }
    }
}