using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace JIMapTrans.Common.Utils
{
    public class ControlsUtil
    {
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
            if (value > 100)
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

        public static void LoadComboBoxColumnItems(DataGridViewComboBoxColumn comboboxControl, Type enumType)
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

        public static void LoadComboBoxItems(ComboBox comboboxControl, Type enumType)
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

        public static string GetPropertyDescription(Type type, string propertyName)
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

    }
}
