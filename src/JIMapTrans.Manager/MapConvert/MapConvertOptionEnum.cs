using System.ComponentModel;

namespace JIMapTrans.MapConvert
{
    public class MapConvertOptionEnum
    {
        public enum ConvertProfile
        {
            [Description("압축하지 않음")]
            NONE = 0,

            [Description("약한 압축")]
            LOW_COMPRESS = 1,

            [Description("강한 압축")]
            HIGH_COMPRESS = 2,

            [Description("JPEG 압축")]
            JPEG_COMPRESS = 3
        }

        public enum BigTiffType
        {
            [Description("IF_NEEDED")]            
            IF_NEEDED = 0,

            [Description("YES")]
            YES = 1,

            [Description("NO")]
            NO = 2,

            [Description("IF_SAFER")]
            IF_SAFER = 3
        }

        public enum CompressType
        {
            [Description("NONE")]
            NONE = 0,

            [Description("LZW")]
            LZW = 1,

            [Description("PACKBITS")]
            PACKBITS = 2,

            [Description("JPEG")]
            JPEG = 3,

            [Description("DEFLATE")]
            DEFLATE = 4
        }

    }
}
