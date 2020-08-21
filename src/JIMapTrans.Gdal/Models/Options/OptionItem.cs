using System.ComponentModel;

namespace JIMapTrans.GdalManager.Models.Options
{
    public class OptionItem
    {
        [DisplayName("이름")]
        public string OptionName { get; set; }

        [DisplayName("값")]
        public string OptionVaule { get; set; }

        public OptionItem()
        {

        }

        public OptionItem(string optionName, string optionValue)
        {
            OptionName = optionName;
            OptionVaule = optionValue;
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", OptionName, OptionVaule);
        }
    }
}
