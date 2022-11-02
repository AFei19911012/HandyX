using System;
using System.Collections.Generic;
using System.Windows;
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

                // 红紫色
                Brushes.Pink,
                Brushes.LightPink,
                Brushes.HotPink,
                Brushes.Orchid,
                Brushes.PaleVioletRed,
                Brushes.DeepPink,
                Brushes.MediumVioletRed,
                Brushes.Crimson,

                // 红褐色
                Brushes.LightCoral,
                Brushes.RosyBrown,
                Brushes.IndianRed,
                Brushes.Brown,
                Brushes.Firebrick,
                Brushes.Red,
                Brushes.DarkRed,
                Brushes.Maroon,

                // 橙色系
                Brushes.BlanchedAlmond,
                Brushes.Bisque,
                Brushes.Moccasin,
                Brushes.PeachPuff,
                Brushes.NavajoWhite,
                Brushes.Wheat,
                Brushes.PaleGoldenrod,
                Brushes.Khaki,
                Brushes.Gold,
                Brushes.BurlyWood,
                Brushes.Tan,
                Brushes.DarkKhaki,
                Brushes.SandyBrown,
                Brushes.Orange,
                Brushes.LightSalmon,
                Brushes.DarkSalmon,
                Brushes.Goldenrod,
                Brushes.Salmon,
                Brushes.DarkOrange,
                Brushes.Coral,
                Brushes.Peru,
                Brushes.Tomato,
                Brushes.DarkGoldenrod,
                Brushes.OrangeRed,
                Brushes.Chocolate,
                Brushes.Sienna,
                Brushes.SaddleBrown,

                // 黄色系
                Brushes.Yellow,
                Brushes.Olive,

                // 橄榄绿
                Brushes.GreenYellow,
                Brushes.Chartreuse,
                Brushes.LawnGreen,
                Brushes.YellowGreen,
                Brushes.OliveDrab,
                Brushes.DarkOliveGreen,

                // 艳绿色
                Brushes.PaleGreen,
                Brushes.LightGreen,
                Brushes.Lime,
                Brushes.DarkSeaGreen,
                Brushes.LimeGreen,
                Brushes.ForestGreen,
                Brushes.Green,
                Brushes.DarkGreen,

                // 土耳其绿
                Brushes.Aquamarine,
                Brushes.Honeydew,
                Brushes.MediumAquamarine,
                Brushes.MediumTurquoise,
                Brushes.MediumSpringGreen,
                Brushes.SpringGreen,
                Brushes.Turquoise,
                Brushes.LightSeaGreen,
                Brushes.SeaGreen,
                Brushes.MediumSeaGreen,

                // 青色
                Brushes.PaleTurquoise,
                Brushes.Cyan,
                Brushes.Aqua,
                Brushes.DarkCyan,
                Brushes.Teal,
                Brushes.DarkSlateGray,

                // 天蓝
                Brushes.PowderBlue,
                Brushes.LightBlue,
                Brushes.LightSteelBlue,
                Brushes.LightSkyBlue,
                Brushes.SkyBlue,
                Brushes.DeepSkyBlue,
                Brushes.DarkTurquoise,
                Brushes.CornflowerBlue,
                Brushes.CadetBlue,
                Brushes.DodgerBlue,
                Brushes.LightSlateGray,
                Brushes.SlateGray,
                Brushes.RoyalBlue,
                Brushes.SteelBlue,

                // 海蓝
                Brushes.Blue,
                Brushes.MediumBlue,
                Brushes.DarkBlue,
                Brushes.Navy,
                Brushes.MidnightBlue,

                // 紫罗兰
                Brushes.MediumOrchid,
                Brushes.MediumPurple,
                Brushes.MediumSlateBlue,
                Brushes.SlateBlue,
                Brushes.BlueViolet,
                Brushes.DarkViolet,
                Brushes.DarkOrchid,
                Brushes.DarkSlateBlue,
                Brushes.Indigo,

                // 玫瑰红
                Brushes.Thistle,
                Brushes.Plum,
                Brushes.Violet,
                Brushes.Magenta,
                Brushes.Fuchsia,
            };
            List<string> names = new List<string>
            {
                "White", "WhiteSmoke", "Gainsboro", "LightGray", "DarkGray", "Gray", "DimGray", "Black",

                "Snow", "GhostWhite", "MintCream", "Azure", "Ivory", "FloralWhite", "AliceBlue", "LavenderBlush", "SeaShell", 
                "Honeydew", "LightYellow", "LightCyan", "OldLace", "Cornsilk", "Linen", "LemonChiffon", "Lavender", "Beige", 
                "LightGoldenrodYellow", "MistyRose", "PapayaWhip", "AntiqueWhite",

                "Pink", "LightPink","HotPink","Orchid","PaleVioletRed","DeepPink","MediumVioletRed","Crimson",

                "LightCoral", "RosyBrown", "IndianRed", "Brown", "Firebrick", "Red", "DarkRed", "Maroon",

                "BlanchedAlmond", "Bisque", "Moccasin", "PeachPuff", "NavajoWhite", "Wheat", "PaleGoldenrod", "Khaki", "Gold",
                "BurlyWood", "Tan", "DarkKhaki", "SandyBrown", "Orange", "LightSalmon", "DarkSalmon", "Goldenrod", "Salmon",
                "DarkOrange", "Coral", "Peru", "Tomato", "DarkGoldenrod", "OrangeRed", "Chocolate", "Sienna", "SaddleBrown",

                "Yellow", "Olive",

                "GreenYellow", "Chartreuse", "LawnGreen", "YellowGreen", "OliveDrab", "DarkOliveGreen",

                "PaleGreen", "LightGreen", "Lime", "DarkSeaGreen", "LimeGreen", "ForestGreen", "Green", "DarkGreen",

                "Aquamarine", "Honeydew", "MediumAquamarine", "MediumTurquoise", "MediumSpringGreen",
                "SpringGreen", "Turquoise", "LightSeaGreen", "SeaGreen", "MediumSeaGreen",

                "PaleTurquoise", "Cyan", "Aqua", "DarkCyan", "Teal", "DarkSlateGray",

                "PowderBlue", "LightBlue", "LightSteelBlue", "LightSkyBlue", "SkyBlue", "DeepSkyBlue", "DarkTurquoise",
                "CornflowerBlue", "CadetBlue", "DodgerBlue", "LightSlateGray", "SlateGray", "RoyalBlue", "SteelBlue",

                "Blue", "MediumBlue", "DarkBlue", "Navy", "MidnightBlue",

                "MediumOrchid", "MediumPurple", "MediumSlateBlue", "SlateBlue", "BlueViolet",
                "DarkViolet", "DarkOrchid", "DarkSlateBlue", "Indigo",

                "Thistle", "Plum", "Violet", "Magenta", "Fuchsia",
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