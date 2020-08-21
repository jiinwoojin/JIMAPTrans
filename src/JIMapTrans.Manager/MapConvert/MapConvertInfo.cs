using JIMapTrans.Common.Infos;
using OSGeo.GDAL;
using System.Collections.Generic;

namespace JIMapTrans.MapConvert
{
    public class MapConvertInfo
    {
        public PathInfo MapConvertPathInfo;
        public List<string> ConvertOptions;
        public GDALTranslateOptions GdalTranslateOptions;

        public MapConvertInfo()
        {
            MapConvertPathInfo = new PathInfo();
            ConvertOptions = new List<string>();
        }

        public void Clear()
        {
            if(ConvertOptions != null)
            {
                ConvertOptions.Clear();
            }
            if(MapConvertPathInfo != null)
            {
                MapConvertPathInfo.Clear();
            }
            if(GdalTranslateOptions != null)
            {
                GdalTranslateOptions.Dispose();
            }
        }

    }
}
