using JIMapTrans.GdalManager.Handlers;
using OSGeo.GDAL;
using System;
using System.Runtime.ExceptionServices;
using System.Security;

namespace JIMapTrans.MapConvert
{
    public class MapConverter
    {
        public static bool EcwToTiff(string inputFile, string outputFile, GDALTranslateOptions translateOptions,
            Gdal.GDALProgressFuncDelegate progressFuncDelegate)
        {
            bool result = false;
            Dataset dataset = null;

            try
            {
                Gdal.PushErrorHandler(new Gdal.GDALErrorHandlerDelegate(GdalHandlers.ErrorHandler));
                dataset = Gdal.Open(inputFile, Access.GA_ReadOnly);
                Gdal.PopErrorHandler();

                if (dataset != null)
                {
                    result = Translate(dataset, outputFile, translateOptions, progressFuncDelegate);
                }
            }
            catch(Exception ex)
            {
                //LoggerManager.WriteErrorLog(ex.Message);
            }
            finally
            {
                if (dataset != null)
                {
                    dataset.FlushCache();
                    dataset.Dispose();
                }
            }

            return result;
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public static bool Translate(Dataset dataset, string outputFile, GDALTranslateOptions translateOptions,
            Gdal.GDALProgressFuncDelegate progressFuncDelegate)
        {
            bool result = false;

            Dataset newDs = null;

            try
            {
                Gdal.PushErrorHandler(new Gdal.GDALErrorHandlerDelegate(GdalHandlers.ErrorHandler));
                newDs = Gdal.wrapper_GDALTranslate(outputFile, dataset, translateOptions, progressFuncDelegate, null);
                Gdal.PopErrorHandler();
            }
            catch (Exception ex)
            {
                //LoggerManager.WriteErrorLog(ex.Message);
            }
            finally
            {
                if (newDs != null)
                {
                    newDs.FlushCache();
                    newDs.Dispose();

                    result = true;
                }
            }

            return result;
        }

    }
}
