using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;



namespace JIMapTrans.Common
{
    public class CommonUtil
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

        public static List<string> GetPathListFromTextFile(string textFilePath)
        {
            List<string> pathList = new List<string>();

            if (!File.Exists(textFilePath))
            {
                return pathList;
            }

            string[] files = File.ReadAllLines(textFilePath, Encoding.Default);

            foreach (var path in files)
            {
                pathList.Add(path);
            }

            return pathList;
        }

        public static List<string> GetPathList(PathType pathType, string rootPath, string inputExtensions)
        {
            List<string> pathList = new List<string>();

            if (pathType == PathType.FilePathType)
            {
                pathList.Add(rootPath);
            }
            else
            {
                string[] extensions = inputExtensions.Split(' ');
                
                if (extensions.Length < 1)
                {
                    return pathList;
                }

                foreach (var ext in extensions)
                {
                    pathList.AddRange(CommonUtil.GetDirectoryPathList(pathType, rootPath, ext));
                }
            }

            return pathList;
        }

        public static List<string> GetDirectoryPathList(PathType pathType, string rootPath, string extension)
        {
            string[] inputFiles = Directory.GetFiles(rootPath, string.Format("*.{0}", extension), SearchOption.AllDirectories);
            
            return inputFiles.ToList();
        }

        public static void CreateDirectoryByFilePath(string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }


        public static void SetLabelText(Form windowForm, Label labelControl, string text)
        {
            if (windowForm.InvokeRequired)
            {
                windowForm.Invoke(new MethodInvoker(delegate ()
                {
                    labelControl.Text = text;
                }));
            }
        }

        public static void SetLabelText(Control control, Label labelControl, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate ()
                {
                    labelControl.Text = text;
                }));
            }
        }

        public static void SetProgressBarValue(ProgressBar progressBar, int value)
        {
            if(value > 100)
            {
                value = 100;
            }

            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new MethodInvoker(delegate ()
                {
                    progressBar.Value = value;

                }));
            }
        }

        public static void SetProgressBar(ProgressBar progressBar, int minimum, int maximum, int step, int value)
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Minimum = minimum;
            progressBar.Maximum = maximum;
            progressBar.Step = step;
            progressBar.Value = value;
        }

        public static string GetEnumDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)

                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
        
        public static  void LoadComboBoxColumnItems(DataGridViewComboBoxColumn comboboxControl, Type enumType)
        {
            comboboxControl.DataSource = Enum.GetValues(enumType)
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            comboboxControl.DisplayMember = "Description";
            comboboxControl.ValueMember = "value";
        }

        public static  void LoadComboBoxItems(ComboBox comboboxControl, Type enumType)
        {
            comboboxControl.DataSource = Enum.GetValues(enumType)
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })                
                .OrderBy(item => item.value)
                .ToList();
            comboboxControl.DisplayMember = "Description";
            comboboxControl.ValueMember = "value";
        }

        public static string GetDescription(Type type)
        {
            var descriptions = (DescriptionAttribute[])
                type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }

        public static  string GetPropertyDescription(Type type, string propertyName)
        {
            AttributeCollection attributes =
   TypeDescriptor.GetProperties(type)[propertyName].Attributes;

            DescriptionAttribute myAttribute =
               (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];

            return myAttribute.Description;

        }

        public static void UseDefaultExtAsFilterIndex(FileDialog dialog)
        {
            var ext = "*." + dialog.DefaultExt;
            var filter = dialog.Filter;
            var filters = filter.Split('|');
            for (int i = 1; i < filters.Length; i += 2)
            {                
                if (filters[i].Contains(ext))
                {
                    dialog.FilterIndex = 1 + (i - 1) / 2;
                    return;
                }
            }
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

        static public void SetTextboxPlaceHolder(TextBox control, string PlaceHolderText)
        {
            control.Text = PlaceHolderText;
            control.ForeColor = Color.Gray;
            
            control.TextChanged += delegate (object sender, EventArgs args)
            {
                if (string.IsNullOrWhiteSpace(control.Text) == true)
                {
                    control.ForeColor = Color.Gray;
                }
                else
                {
                    control.ForeColor = Color.Black;
                }
            };

            control.GotFocus += delegate (object sender, EventArgs args)
            {
                //if (cusmode == false)
                //{
                    control.Text = control.Text == PlaceHolderText ? string.Empty : control.Text;
                    //IF Focus TextBox forecolor Black
                control.ForeColor = Color.Black;
                //}
            };

            control.LostFocus += delegate (object sender, EventArgs args)
            {
                if (string.IsNullOrWhiteSpace(control.Text) == true)
                {
                    control.Text = PlaceHolderText;
                    //If not focus TextBox forecolor to gray
                    control.ForeColor = Color.Gray;
                }
            };
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                                        int size, string filePath);


        public static string GetIniFile(string section, string key, string filePath)
        {
            string value = "";

            StringBuilder builder = new StringBuilder(255);

            GetPrivateProfileString(section, key, "", builder, 255, filePath);

            value = builder.ToString();

            return value;
        }


    }
}
