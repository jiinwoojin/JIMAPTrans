using JIMapTrans.Logger;
using OSGeo.GDAL;
using System;

namespace JIMapTrans.Vrt
{
    public class VrtCreator
    {
        public static bool Create(string outputPath, string[] inputPaths, GDALBuildVRTOptions options, Gdal.GDALProgressFuncDelegate progressFuncDelegate)
        {
            bool result = false;

            Dataset newDs = null;

            try {
                Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");

                //Gdal.PushErrorHandler(GdalConfig.GdalHandlers.ErrorHandler);
                newDs = Gdal.wrapper_GDALBuildVRT_names(outputPath, inputPaths, options, progressFuncDelegate, null);
                //Gdal.PopErrorHandler();
                

                Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");                
            }
            catch (Exception ex)
            {
                LoggerManager.WriteErrorLog(ex.Message);
            }
            finally
            {
                if (newDs != null)
                {
                    newDs.FlushCache();
                    newDs.Dispose();

                    result = true;
                }

                Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            }

            return result;
        }


    }
}
