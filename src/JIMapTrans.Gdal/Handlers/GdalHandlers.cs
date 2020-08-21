using JIMapTrans.Common.Utils;
using JIMapTrans.Logger;
using System;

namespace JIMapTrans.GdalManager.Handlers
{
    public class GdalHandlers
    {
        public static void ErrorHandler(int eclass, int code, IntPtr msg)
        {
            var errorString = EncodingUtil.PtrToString(msg);
            errorString += Environment.NewLine;
            LoggerManager.WriteErrorLog(errorString);
        }
    }
}
