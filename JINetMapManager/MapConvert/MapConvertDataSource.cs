using JIMapTrans.Options;
using JIMapTrans.GdalConfig;
using System.Collections.Generic;
using System.ComponentModel;

namespace JIMapTrans.MapConvert
{
    public class MapConvertDataSource
    {
        public static List<OptionProfile> MapConvertProfileList;
        public static CreationOptionList GdalCreationOptionList;
        public static BindingList<OptionItem> CheckedOptionItemList;
        public static BindingList<OptionItem> UnchekedOptionItemList;

        public static void Initialize()
        {
            GdalCreationOptionList = GdalConfigManager.GetCreationOptionListFromXml();
            CheckedOptionItemList = new BindingList<OptionItem>();
            UnchekedOptionItemList = new BindingList<OptionItem>();
        }
    }
}
