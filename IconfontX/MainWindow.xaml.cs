using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IconfontX
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SVG_Text_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = SVG_Text.Text;
                if (text != "")
                {
                    string path = Regex.Split(text, "path d=\"", RegexOptions.IgnoreCase)[1].Split('\"')[0];
                    Geometry_Text.Text = string.Format("<Geometry o:Freeze=\"True\" x:Key=\"{0}\">{1}</Geometry>", TB_Name.Text, path);

                    // 生成图标
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Geometry));
                    Path_Icon.Data = (Geometry)converter.ConvertFrom(path);
                }
            }
            catch (Exception)
            {
                Geometry_Text.Text = "";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ = Task.Run(() =>
            {
                while (true)
                {
                    _ = Application.Current?.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (CKB_Spy.IsChecked == true && Clipboard.ContainsText())
                        {
                            string txt = Clipboard.GetText();
                            if (txt.Contains("path d=\""))
                            {
                                SVG_Text.Text = Clipboard.GetText();
                            }
                        }
                    }));
                    Thread.Sleep(500);
                }
            });
        }
    }
}