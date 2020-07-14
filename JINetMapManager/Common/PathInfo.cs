using System.Collections.Generic;

namespace JIMapTrans.Common
{
    public class PathInfo
    {
        public PathType SelectedPathType;
        public string InputPathString;
        public string OutputPathString;
        public string InputExtensions;

        public List<string> InputPathList = new List<string>();

        public void Clear()
        {
            InputPathString = "";
            OutputPathString = "";
            InputPathList.Clear();
            InputExtensions = "";
        }
    }
}
