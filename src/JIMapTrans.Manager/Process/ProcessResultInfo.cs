using System;

namespace JIMapTrans.Process
{
    public class ProcessResultInfo
    {
        public string ProcessTitle;
        public int InputFileCount;
        public int OutputFileCount;
        public int SuccessCount;
        public int FailCount;
        public DateTime StartTime;
        public DateTime EndTime;

        public ProcessResultInfo(string title)
        {
            ProcessTitle = title;
        }

        public void Clear()
        {
            InputFileCount = 0;
            OutputFileCount = 0;
            SuccessCount = 0;
            FailCount = 0;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }
    }
}
