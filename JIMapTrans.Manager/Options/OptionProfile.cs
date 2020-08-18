using System.Collections.Generic;

namespace JIMapTrans.Options
{
    public class OptionProfile
    {
        public string ProfileName { get; set; }
        public List<OptionItem> Options { get; set; }

        public string OptionsString
        {
            get { return ToString(); }
        }

        public OptionProfile()
        {
            Options = new List<OptionItem>();
        }

        public OptionProfile(string profileName, List<OptionItem> options)
        {
            ProfileName = profileName;
            Options = options;
        }

        public override string ToString()
        {
            return string.Join(" ", Options);
            //return base.ToString();
        }
    }
}
