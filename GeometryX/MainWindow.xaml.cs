using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfControls.Controls;

namespace GeometryX
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            InitGeometry();

            InitBrush();
        }


        private void InitGeometry()
        {
            ResourceDictionary geometry = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/GeometryX;component/Resources/Geometry.xaml")
            };

            List<string> names = new List<string>();
            foreach (object item in geometry.Keys)
            {
                names.Add((string)item);
            }

            List<Geometry> paths = new List<Geometry>();
            foreach (object item in geometry.Values)
            {
                paths.Add((Geometry)item);
            }

            for (int i = 0; i < names.Count; i++)
            {
                IconButton button = new IconButton
                {
                    PathData = paths[i],
                    Content = names[i],
                    Height = 32,
                    FontSize = 18,
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Width = 220,
                    Foreground = (Brush)FindResource("AccentBrush"),
                    MouseOverForeground = (Brush)FindResource("PrimaryBrush"),
                };
                if (i % 5 == 0)
                {
                    button.CornerRadius = 10;
                    button.BorderThickness = new Thickness(2);
                }
                _ = MyGeometryContainer.Children.Add(button);
            }
        }


        private void InitBrush()
        {
            // 标准色
            List<Brush> colors = new List<Brush>
            {
                // 单色调
                Brushes.White,
                Brushes.WhiteSmoke,
                Brushes.Gainsboro,
                Brushes.LightGray,
                Brushes.DarkGray,
                Brushes.Gray,
                Brushes.DimGray,
                Brushes.Black,

                // 浅淡色
                Brushes.Snow,
                Brushes.GhostWhite,
                Brushes.MintCream,
                Brushes.Azure,
                Brushes.Ivory,
                Brushes.FloralWhite,
                Brushes.AliceBlue,
                Brushes.LavenderBlush,
                Brushes.SeaShell,
                Brushes.Honeydew,
                Brushes.LightYellow,
                Brushes.LightCyan,
                Brushes.OldLace,
                Brushes.Cornsilk,
                Brushes.Linen,
                Brushes.LemonChiffon,
                Brushes.Lavender,
                Brushes.Beige,
                Brushes.LightGoldenrodYellow,
                Brushes.MistyRose,
                Brushes.PapayaWhip,
                Brushes.AntiqueWhite,
            };
            List<string> names = new List<string>
            {
                "White", "WhiteSmoke", "Gainsboro", "LightGray", "DarkGray", "Gray", "DimGray", "Black",

                "Snow", "GhostWhite", "MintCream", "Azure", "Ivory", "FloralWhite", "AliceBlue", "LavenderBlush", "SeaShell", "Honeydew", "LightYellow",
                "LightCyan", "OldLace", "Cornsilk", "Linen", "LemonChiffon", "Lavender", "Beige", "LightGoldenrodYellow", "MistyRose", "PapayaWhip", "AntiqueWhite",
            };

            for (int i = 0; i < colors.Count; i++)
            {
                ColorInfo info = new ColorInfo();
                info.BrushName.Text = names[i];
                info.BrushShow.Background = colors[i];
                info.BrushStr.Text = colors[i].ToString();
                _ = MyBrushContainer1.Children.Add(info);
            }
        }
    }
}