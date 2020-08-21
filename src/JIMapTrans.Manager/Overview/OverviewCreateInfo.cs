using JIMapTrans.Common.Infos;
using JIMapTrans.GdalManager.Models;
using System.Collections.Generic;

namespace JIMapTrans.Overview
{
    public class OverviewCreateInfo
    {
        public OverviewOptionEnum.OverviewForamt OverviewFormat;
        public PathInfo OverviewCreatePathInfo;
        //public string OverviewResamplingOption;
        public GdalEnum.ResamplingType OverviewResamplingOption;
        public List<int> LevelList;
        public string OverviewCreationOptionsString;
        public bool IsNeedCalcLevel;

        public OverviewCreateInfo()
        {
            OverviewCreationOptionsString = "";
            OverviewFormat = OverviewOptionEnum.OverviewForamt.External;
            OverviewCreatePathInfo = new PathInfo();
            //OverviewResamplingOption = "";
            OverviewResamplingOption = GdalEnum.ResamplingType.NONE;
            LevelList = new List<int>();
            IsNeedCalcLevel = false;
        }

        public void Clear()
        {
            OverviewCreationOptionsString = "";
            OverviewCreatePathInfo.Clear();
            //OverviewResamplingOption = "";
            OverviewResamplingOption = GdalEnum.ResamplingType.NONE;
            LevelList.Clear();
            IsNeedCalcLevel = false;
        }

    }
}
