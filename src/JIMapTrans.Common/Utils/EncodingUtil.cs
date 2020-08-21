using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JIMapTrans.Common.Utils
{
    public class EncodingUtil
    {

        public static void WriteAllTextByUtf8(string path, string txt)
        {
            var enc = new UTF8Encoding(true);
            var bytes = Encoding.UTF8.GetBytes(txt);
            using (var f = File.Open(path, FileMode.Create))
            {
                f.Write(enc.GetPreamble(), 0, enc.GetPreamble().Length);
                f.Write(bytes, 0, bytes.Length);
            }
        }

        public static Encoding GetFileEncoding(string path)
        {
            Encoding encoding;
            using (var sr = new StreamReader(path, true))
            {
                encoding = sr.CurrentEncoding;                

                sr.Close();
            }

            return encoding;
        }

        public static void SetFileEncodingToUtf8Bom(string path)
        {
            var encoding = GetFileEncoding(path);

            if (encoding != Encoding.UTF8)
            {
                return;  
            }

            WriteAllTextByUtf8(path, File.ReadAllText(path, Encoding.Default));
        }

        public static string PtrToString(IntPtr msg)
        {
            try
            {
                if (msg == IntPtr.Zero)
                {
                    return "";
                }

                string msgString = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(msg);
                var size = Encoding.UTF8.GetBytes(msgString).Length + 1;

                byte[] recvBytes = new byte[size];
                System.Runtime.InteropServices.Marshal.Copy(msg, recvBytes, 0, size);

                return Encoding.GetEncoding("UTF-8").GetString(recvBytes);
            }
            catch
            {
                return "";
            }
        }
    }
}
