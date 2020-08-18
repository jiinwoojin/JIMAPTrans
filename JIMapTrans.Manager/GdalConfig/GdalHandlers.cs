using JIMapTrans.Common;
using JIMapTrans.Logger;
using System;

namespace JIMapTrans.GdalConfig
{
    public class GdalHandlers
    {
        public static void ErrorHandler(int eclass, int code, IntPtr msg)
        {
            var errorString = CommonUtil.PtrToString(msg);
            errorString += Environment.NewLine;
            LoggerManager.WriteErrorLog(errorString);
        }
    }
}
