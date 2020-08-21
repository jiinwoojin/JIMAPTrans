using JIMapTrans.GdalManager.Handlers;
using OSGeo.GDAL;
using System;
using System.Collections.Generic;
using System.IO;

namespace JIMapTrans.Overview
{
    public class OverviewCreator
    {
        public static bool CreateOverviews(OverviewCreateInfo info, string inputFilePath, Gdal.GDALProgressFuncDelegate progressFuncDelegate)
        {
            bool result = false;
            Dataset dataset = null;

            try
            {
                Access access = OverviewOptionEnum.OverviewForamt.External == info.OverviewFormat ? Access.GA_ReadOnly : Access.GA_Update;

                Gdal.PushErrorHandler(GdalHandlers.ErrorHandler);
                dataset = Gdal.Open(inputFilePath, access);
                Gdal.PopErrorHandler();

                if (dataset == null)
                {
                    return result;
                }

                List<int> levels = info.LevelList;
                if (info.IsNeedCalcLevel)
                {
                    levels = CalculateOverViewLevels(dataset);
                }

                if (levels.Count < 1)
                {
                    return result;
                }

                if (OverviewOptionEnum.OverviewForamt.External == info.OverviewFormat)
                {
                    DeleteExternalOverviews(inputFilePath);
                }

                Gdal.PushErrorHandler(GdalHandlers.ErrorHandler);
                if (dataset.BuildOverviews(info.OverviewResamplingOption.ToString(), levels.ToArray(), progressFuncDelegate, null) == (int)CPLErr.CE_None)
                {
                    result = true;
                }
                Gdal.PopErrorHandler();
            }
            catch (Exception ex)
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

        public static void DeleteExternalOverviews(string inputFilePath)
        {
            var ovrFilePath = string.Format("{0}.ovr", inputFilePath);

            if (File.Exists(ovrFilePath))
            {
                File.Delete(ovrFilePath);
            }
        }

        public static List<int> CalculateOverViewLevels(Dataset newDs)
        {
            int iWidth = newDs.RasterXSize;
            int iHeight = newDs.RasterYSize;

            int minResolution = Math.Min(iWidth, iHeight);
            int minValue = 50;
            int iCurNum = minResolution;
            int nLevelCount = 1;

            List<int> levels = new List<int>();

            do
            {
                int levelValue = Convert.ToInt32(Math.Pow(2.0, nLevelCount++));
                levels.Add(levelValue);
                iCurNum /= 2;

            } while (iCurNum > minValue);

            return levels;
        }
    }
}
