using JIMapTrans.Common;
using OSGeo.GDAL;
using System.Collections.Generic;

namespace JIMapTrans.Vrt
{
    public class VrtCreateInfo
    {
        public PathInfo VrtCreatePathInfo;
        public List<string> CreateOptions;
        public GDALBuildVRTOptions BuildVrtOptions;

        public VrtCreateInfo()
        {
            VrtCreatePathInfo = new PathInfo();
            CreateOptions = new List<string>();
        }

        public void Clear()
        {
            if (CreateOptions != null)
            {
                CreateOptions.Clear();
            }
            if (VrtCreatePathInfo != null)
            {
                VrtCreatePathInfo.Clear();
            }
            if (BuildVrtOptions != null)
            {
                BuildVrtOptions.Dispose();
            }
        }
    }
}
