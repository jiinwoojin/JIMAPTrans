using System.ComponentModel;

namespace JIMapTrans.Common.Infos
{
    public enum PathType
    {
        [Description("파일")]
        FilePathType = 0,
        [Description("폴더")]
        DirectoryPathType = 1
    }
}
