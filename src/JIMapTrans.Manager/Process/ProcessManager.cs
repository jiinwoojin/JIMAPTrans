using JIMapTrans.Logger;
using System;

namespace JIMapTrans.Process
{
    public class ProcessManager
    {
        private static readonly Lazy<ProcessManager> Lazy =
            new Lazy<ProcessManager>(() => new ProcessManager());

        public static ProcessManager Instance => Lazy.Value;

        public void WriteProcessLog(ProcessResultInfo info)
        {
            if (info == null)
            {
                return ;
            }

            string logString = "";
            logString += LoggerManager.MainSeparatorString;
            logString += Environment.NewLine;
            logString += string.Format("[{0} 작업 결과]", info.ProcessTitle);
            logString += Environment.NewLine;
            logString += string.Format(" 입력 파일 개수 : {0}", info.InputFileCount);
            logString += Environment.NewLine;
            logString += string.Format(" 출력 파일 개수 : {0}", info.OutputFileCount);
            logString += Environment.NewLine;
            logString += string.Format(" 작업 성공 : {0}", info.SuccessCount, info.InputFileCount);
            logString += Environment.NewLine;
            logString += string.Format(" 작업 실패 : {0}", info.FailCount, info.InputFileCount);
            logString += Environment.NewLine;
            logString += string.Format(" 작업 시작 시간 : {0}", info.StartTime);
            logString += Environment.NewLine;
            logString += string.Format(" 작업 종료 시간 : {0}", info.EndTime);

            LoggerManager.WriteInfoLog(logString);

            //TimeSpan interval = resultInfo.EndTime - resultInfo.StartTime;

            //logString += Environment.NewLine;
            //logString += string.Format(" 작업 소요 시간 : {0}", interval.ToString(@"hh\:mm\:ss\.ff"));
        }
    }
}
