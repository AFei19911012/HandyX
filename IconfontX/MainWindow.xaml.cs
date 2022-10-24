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
                    // 需要注意存在多条路径的情况
                    string[] strs = Regex.Split(text, "path d=\"", RegexOptions.IgnoreCase);
                    int len = strs.Length;
                    string path = "";
                    for (int i = 1; i < strs.Length; i++)
                    {
                        path += Regex.Split(text, "path d=\"", RegexOptions.IgnoreCase)[i].Split('\"')[0];
                    }
                    Geometry_Text.Text = string.Format("<Geometry o:Freeze=\"True\" x:Key=\"{0}\">{1}</Geometry>", TB_Name.Text, path);

                    // 生成图标
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Geometry));
                    GeometryGroup geometry = new GeometryGroup();
                    geometry.Children.Add((Geometry)converter.ConvertFrom(path));
                    // 设置填充规则 很重要
                    geometry.FillRule = FillRule.Nonzero;
                    Path_Icon.Data = geometry;
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
                        try
                        {
                            if (CKB_Spy.IsChecked == true && Clipboard.ContainsText())
                            {
                                string txt = Clipboard.GetText();
                                if (txt.Contains("path d=\""))
                                {
                                    SVG_Text.Text = Clipboard.GetText();
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }));
                    Thread.Sleep(500);
                }
            });
        }
    }
}