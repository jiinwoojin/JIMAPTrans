using log4net;
using System;
using System.IO;
using System.Windows.Forms;

namespace JIMapTrans.Logger
{

    public class LoggerManager
    {
        private static ILog _processLogger;
        public static string MainSeparatorString;
        public static string SubSeparatorString;

        public static void Initialize(RichTextBox richTextBox)
        {
            InitConfig();
            InitLogger(richTextBox);
            InitSeparatorString();
        }

        private static void InitSeparatorString()
        {
            MainSeparatorString = "====================================================================";
            SubSeparatorString = "--------------------------------------------------------------------";
        }

        private static void InitConfig()
        {
            GlobalContext.Properties["LogName"] = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Log.txt");
            string executingAssemblyFqPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            executingAssemblyFqPath = (Path.Combine(executingAssemblyFqPath, "log4net.xml"));
            if (File.Exists(executingAssemblyFqPath))
            {
                FileInfo fi = new FileInfo(executingAssemblyFqPath);
                log4net.Config.XmlConfigurator.Configure(fi);
            }
        }

        private static void InitLogger(RichTextBox richTextBox)
        {
            _processLogger = LogManager.GetLogger("logger");
            RichTextBoxAppender.SetRichTextBox(richTextBox, "RichTextBoxAppender");
        }

        public static void FlushLogger(int millSecondsTimeout)
        {
            LogManager.Flush(millSecondsTimeout);
        }

        public static void WriteVersionInfoLog()
        {
            string logString = "";
            logString += MainSeparatorString;
            logString += Environment.NewLine;
            logString += "[버전 정보]";
            logString += Environment.NewLine;
            logString += string.Format("JIMap-Trans : {0}", Application.ProductVersion);
            logString += Environment.NewLine;
            //logString += string.Format("GDAL : {0}", Gdal.VersionInfo("RELEASE_NAME"));
            //logString += Environment.NewLine;
            logString += MainSeparatorString;
            WriteInfoLog(logString);
        }

        //public static void WriteMapConvertInfoLog(MapConvertInfo mapConvertInfo)
        //{
        //    string logString = "";
        //    logString += MainSeparatorString;
        //    logString += Environment.NewLine;
        //    logString += "[변환 정보]";
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 경로 유형 : {0}", ControlsUtil.GetEnumDescription(mapConvertInfo.MapConvertPathInfo.SelectedPathType));
        //    logString += Environment.NewLine;

        //    if(mapConvertInfo.MapConvertPathInfo.SelectedPathType == PathType.DirectoryPathType)
        //    {
        //        logString += string.Format(" 선택 확장자 : {0}", mapConvertInfo.MapConvertPathInfo.InputExtensions);
        //        logString += Environment.NewLine;
        //        logString += string.Format(" 입력 파일 개수 : {0}", mapConvertInfo.MapConvertPathInfo.InputPathList.Count);
        //        logString += Environment.NewLine;
        //    }

        //    logString += string.Format(" 입력 경로 : {0}", mapConvertInfo.MapConvertPathInfo.InputPathString);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 출력 경로 : {0}", mapConvertInfo.MapConvertPathInfo.OutputPathString);
        //    logString += Environment.NewLine;

        //    string optionsString = string.Join(" ", mapConvertInfo.ConvertOptions.ToArray());

        //    if(optionsString.Length < 1)
        //    {
        //        logString += string.Format(" 입력 옵션 : {0}", "없음");
        //    }
        //    else
        //    {
        //        logString += string.Format(" 입력 옵션 : {0}", optionsString);
        //    }
            
        //    logString += Environment.NewLine;
        //    logString += MainSeparatorString;

        //    WriteInfoLog(logString);
        //}

        //public static void WriteOverviewCreateInfoLog(OverviewCreateInfo info)
        //{
        //    string logString = "";
        //    logString += MainSeparatorString;
        //    logString += Environment.NewLine;
        //    logString += "[오버뷰 생성 정보]";
        //    logString += Environment.NewLine;

        //    logString += string.Format(" 경로 유형 : {0}", ControlsUtil.GetEnumDescription(info.OverviewCreatePathInfo.SelectedPathType));
        //    logString += Environment.NewLine;

        //    if (info.OverviewCreatePathInfo.SelectedPathType == PathType.DirectoryPathType)
        //    {
        //        logString += string.Format(" 입력 파일 개수 : {0}", info.OverviewCreatePathInfo.InputPathList.Count);
        //        logString += Environment.NewLine;
        //    }

        //    logString += string.Format(" 입력 경로 : {0}", info.OverviewCreatePathInfo.InputPathString);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 오버뷰 포맷 : {0}", ControlsUtil.GetEnumDescription(info.OverviewFormat));
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 리샘플링 옵션 : {0}", ControlsUtil.GetEnumDescription(info.OverviewResamplingOption));
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 오버뷰 레벨 : {0}", info.IsNeedCalcLevel ? "자동계산" : string.Join(", ", info.LevelList));
        //    logString += Environment.NewLine;

        //    if (info.OverviewCreationOptionsString.Length < 1)
        //    {
        //        logString += string.Format(" 입력 옵션 : {0}", "없음");
        //    }
        //    else
        //    {
        //        logString += string.Format(" 입력 옵션 : {0}", info.OverviewCreationOptionsString);
        //    }

        //    logString += Environment.NewLine;
        //    logString += MainSeparatorString;

        //    WriteInfoLog(logString);
        //}

        //public static void WriteVrtCreateInfoLog(VrtCreateInfo info)
        //{
        //    string logString = "";
        //    logString += MainSeparatorString;
        //    logString += Environment.NewLine;
        //    logString += "[VRT 생성 정보]";

        //    logString += Environment.NewLine;
        //    logString += string.Format(" 경로 유형 : {0}", ControlsUtil.GetEnumDescription(info.VrtCreatePathInfo.SelectedPathType));
        //    logString += Environment.NewLine;

        //    if (info.VrtCreatePathInfo.SelectedPathType == PathType.DirectoryPathType)
        //    {
        //        logString += string.Format(" 선택 확장자 : {0}", info.VrtCreatePathInfo.InputExtensions);
        //        logString += Environment.NewLine;
        //        logString += string.Format(" 입력 파일 개수 : {0}", info.VrtCreatePathInfo.InputPathList.Count);
        //        logString += Environment.NewLine;
        //    }

        //    logString += string.Format(" 입력 경로 : {0}", info.VrtCreatePathInfo.InputPathString);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 출력 경로 : {0}", info.VrtCreatePathInfo.OutputPathString);
        //    logString += Environment.NewLine;

        //    string optionsString = string.Join(" ", info.CreateOptions.ToArray());

        //    if (optionsString.Length < 1)
        //    {
        //        logString += string.Format(" 입력 옵션 : {0}", "없음");
        //    }
        //    else
        //    {
        //        logString += string.Format(" 입력 옵션 : {0}", optionsString);
        //    }

        //    logString += Environment.NewLine;
        //    logString += MainSeparatorString;

        //    WriteInfoLog(logString);
        //}

        public static void WriteFileInfoLog(string inputFilePath, string outputFilePath)
        {
            string logString = "";
            if(inputFilePath.Length > 0)
            {
                logString += string.Format("   입력 파일 : {0}", inputFilePath);
            }
            if (outputFilePath.Length > 0)
            {
                logString += Environment.NewLine;
                logString += string.Format("   출력 파일 : {0}", outputFilePath);
            }

            WriteDebugLog(logString);
        }

        //public static void WriteProcessResultInfoLog(ProcessResultInfo resultInfo)
        //{
        //    if(resultInfo == null)
        //    {
        //        return;
        //    }

        //    string logString = "";
        //    logString += MainSeparatorString;
        //    logString += Environment.NewLine;
        //    logString += string.Format("[{0} 작업 결과]", resultInfo.ProcessTitle); 
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 입력 파일 개수 : {0}", resultInfo.InputFileCount);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 출력 파일 개수 : {0}", resultInfo.OutputFileCount);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 작업 성공 : {0}", resultInfo.SuccessCount, resultInfo.InputFileCount);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 작업 실패 : {0}", resultInfo.FailCount, resultInfo.InputFileCount);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 작업 시작 시간 : {0}", resultInfo.StartTime);
        //    logString += Environment.NewLine;
        //    logString += string.Format(" 작업 종료 시간 : {0}", resultInfo.EndTime);
            
        //    //TimeSpan interval = resultInfo.EndTime - resultInfo.StartTime;

        //    //logString += Environment.NewLine;
        //    //logString += string.Format(" 작업 소요 시간 : {0}", interval.ToString(@"hh\:mm\:ss\.ff"));

        //    _processLogger.Info(logString);
        //}

        public static void WriteDebugLog(string debugMessage)
        {
            _processLogger.Debug(debugMessage);
        }

        public static void WriteInfoLog(string infoMessage)
        {
            _processLogger.Info(infoMessage);
        }


        public static void WriteErrorLog(string errorMessage)
        {
            _processLogger.Error(errorMessage);
        }

        public static void WriteInfoLogDate(string infoMessage)
        {
            _processLogger.Info(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")  + ": " + infoMessage);
        }


        public static void WriteErrorLogDate(string errorMessage)
        {
            _processLogger.Error(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + errorMessage);
        }
    }
}
