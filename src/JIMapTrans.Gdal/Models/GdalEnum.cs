using System.ComponentModel;

namespace JIMapTrans.GdalManager.Models
{
    public class GdalEnum
    {
        public enum ResamplingType
        {
            //nearest,average,gauss,cubic,cubicspline,lanczos,average_mp,average_magphase,mode
            [Description("최근린 이웃")]
            NEAREST = 0,
            [Description("평균")]
            AVERAGE,
            [Description("가우스")]
            GAUSS,
            [Description("3차(cubic)")]
            CUBIC,
            [Description("3차 스플라인(cubic)")]
            CUBICSPLINE,
            [Description("란초시")]
            LANCZOS,
            [Description("최빈값")]
            MODE,
            [Description("없음")]
            NONE
        }

        public enum ResolutionType
        {
            [Description("평균")]
            average,
            [Description("고품질")]
            highest,
            [Description("저품질")]
            lowest
        }
    }
}
