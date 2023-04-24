using System;
using System.Collections.Generic;
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
                    List<string> paths = new List<string>();
                    for (int i = 1; i < strs.Length; i++)
                    {
                        paths.Add(strs[i].Split('\"')[0]);
                        path += " " + strs[i].Split('\"')[0];
                    }
                    Geometry_Text.Text = string.Format("<Geometry o:Freeze=\"True\" x:Key=\"{0}\">{1}</Geometry>", TB_Name.Text, path);

                    // 提取 fill 属性
                    List<string> colors = new List<string>();
                    strs = Regex.Split(text, "fill=\"#", RegexOptions.IgnoreCase);
                    for (int i = 1; i < strs.Length; i++)
                    {
                        colors.Add("#FF" + strs[i].Substring(0, 6));
                    }

                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Geometry));
                    Geometry geometry = (Geometry)converter.ConvertFrom(path);
                    if (RaBtn_Geometry.IsChecked == true)
                    {
                        Path_Icon.Data = geometry;
                    }
                    else if (RaBtn_PathGeometry.IsChecked == true)
                    {
                        // 处理一些特殊情况
                        Path_Icon.Data = GeometryMethod.ConvertGeometry(geometry);
                    }
                    else if (RaBtn_CombinedGeometry.IsChecked == true)
                    {
                        // 处理一些特殊情况
                        Path_Icon.Data = GeometryMethod.ConvertGeometryFill(geometry);
                    }
                    else
                    {
                        // 处理彩色图像
                        DrawingImage_Text.Text = string.Format("<DrawingImage o:Freeze=\"True\" x:Key=\"{0}\">\n  <DrawingImage.Drawing>\n    <DrawingGroup>", TB_Name.Text);
                        // 给每条 Path 设置颜色
                        for (int i = 0; i < colors.Count; i++)
                        {
                            string str = string.Format("\n      <GeometryDrawing Brush=\"{0}\" Geometry=\"{1}\"/>", colors[i], paths[i]);
                            DrawingImage_Text.Text += str;
                        }
                        DrawingImage_Text.Text += "\n    </DrawingGroup>\n  </DrawingImage.Drawing>\n</DrawingImage>";

                        // DrawingImage
                        DrawingImage image = new DrawingImage();
                        DrawingGroup group = new DrawingGroup();
                        for (int i = 0; i < colors.Count; i++)
                        {
                            GeometryDrawing drawing = new GeometryDrawing
                            {
                                Brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colors[i])),
                                Geometry = (Geometry)converter.ConvertFrom(paths[i]),
                            };
                            group.Children.Add(drawing);
                        }
                        image.Drawing = group;
                        Image_DrawingImage.Source = image;
                    }
                }
            }
            catch (Exception)
            {
                Geometry_Text.Text = "";
                DrawingImage_Text.Text = "";
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
                                    // 清空剪切板
                                    Clipboard.Clear();
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

        private void TB_Name_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SVG_Text_TextChanged(null, null);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (RaBtn_DrawingImage == null)
            {
                return;
            }
            if (RaBtn_DrawingImage.IsChecked == true)
            {
                MyTabControl.SelectedIndex = 1;
            }
            else
            {
                MyTabControl.SelectedIndex = 0;
            }
            SVG_Text_TextChanged(null, null);
        }
    }
}