using System.ComponentModel;

namespace JIMapTrans.Common
{
    public enum PathType
    {
        [Description("파일")]
        FilePathType = 0,
        [Description("폴더")]
        DirectoryPathType = 1
    }
}
