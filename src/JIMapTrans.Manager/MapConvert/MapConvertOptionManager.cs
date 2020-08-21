using JIMapTrans.GdalManager.Models.Options;
using System.Collections.Generic;
using System.Linq;

namespace JIMapTrans.MapConvert
{
    public class MapConvertOptionManager
    {
        public static int CheckedOptionItem(string name)
        {
            int index = -1;

            var result = MapConvertDataSource.UnchekedOptionItemList.SingleOrDefault(x => x.OptionName == name);

            if (result == null)
            {
                return index;
            }

            MapConvertDataSource.CheckedOptionItemList.Add(result);
            MapConvertDataSource.UnchekedOptionItemList.Remove(result);

            index = MapConvertDataSource.CheckedOptionItemList.IndexOf(result);

            return index;
        }

        public static void UncheckedOptionItem(string name)
        {
            var result = MapConvertDataSource.CheckedOptionItemList.SingleOrDefault(x => x.OptionName == name);

            if (result == null)
            {
                return;
            }

            MapConvertDataSource.UnchekedOptionItemList.Add(result);
            MapConvertDataSource.CheckedOptionItemList.Remove(result);
        }

        public static List<string> GetConfigOptionsString()
        {
            List<string> options = new List<string>();
            foreach (var item in MapConvertDataSource.CheckedOptionItemList)
            {
                options.Add("-co");
                options.Add(item.ToString());
            }

            return options;
        }

        public static List<string> GetOutputDataTypeOptionString(string dataTypeString)
        {
            List<string> options = new List<string>();

            if (dataTypeString.Length > 0)
            {
                options.Add("-ot");
                options.Add(dataTypeString);
            }

            return options;
        }

        public static string GetDescriptionString(CreationOptionListOption item)
        {
            string descriptionString = "";

            if (item == null)
            {
                return descriptionString;
            }

            descriptionString += string.Format("[옵션명] {0}", item.name);
            descriptionString += System.Environment.NewLine;
            descriptionString += string.Format("[타입] {0}", item.type);
            descriptionString += System.Environment.NewLine;
            descriptionString += string.Format("[기본값] {0}", item.@default);
            descriptionString += System.Environment.NewLine;

            if (item.Value != null && item.Value.Length > 0)
            {
                List<string> values = new List<string>();
                foreach (var val in item.Value)
                {
                    values.Add(val.Value);
                }

                descriptionString += string.Format("[입력인자] {0}", string.Join(", ", values.ToArray()));
                descriptionString += System.Environment.NewLine;
            }

            descriptionString += string.Format("[설명] {0}", item.description);

            return descriptionString;
        }
    }
}
