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

            InitBrushName();

            InitTraditionalBrush();

            InitNBS();

            InitJapaneseBrush();
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


        private void InitBrushName()
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


        private void InitTraditionalBrush()
        {
            List<string> name_list = new List<string>()
            {
                // 红色
                "粉红(#ffb3a7)",
                "妃色(#ed5736)",
                "桃红(#f47983)",
                "海棠红(#db5a6b)",
                "海棠红(#db5a6b)",
                "石榴红(#f20c00)",
                "樱桃红(#c93756)",
                "银红(#f05654)",
                "大红(#ff2121)",
                "绛紫(#8c4356)",
                "绯红(#c83c23)",
                "胭脂(#9d2933)",
                "朱红(#ff4c00)",
                "丹(#ff4e20)",
                "彤(#f35336)",
                "茜色(#cb3a56)",
                "火红(#ff2d51)",
                "赫赤(#c91f37)",
                "嫣红(#ef7a82)",
                "炎(#ff3300)",
                "赤(#c3272b)",
                "绾(#a98175)",
                "枣红(#c32136)",
                "檀(#b36d61)",
                "殷红(#be002f)",
                "酡红(#dc3023)",
                "酡颜(#f9906f)",
                // 黄色
                "鹅黄(#fff143)",
                "鸭黄(#faff72)",
                "樱草色(#eaff56)",
                "杏黄(#ffa631)",
                "杏红(#ff8c31)",
                "橘黄(#ff8936)",
                "橙黄(#ffa400)",
                "橘红(#ff7500)",
                "姜黄(#ffc773)",
                "缃色(#f0c239)",
                "橙色(#fa8c35)",
                "茶色(#b35c44)",
                "驼色(#a88462)",
                "昏黄(#c89b40)",
                "栗色(#60281e)",
                "棕色(#b25d25)",
                "棕绿(#827100)",
                "棕黑(#7c4b00)",
                "棕红(#9b4400)",
                "棕黄(#ae7000)",
                "赭(#9c5333)",
                "赭色(#955539)",
                "琥珀(#ca6924)",
                "褐色(#6e511e)",
                "枯黄(#d3b17d)",
                "黄栌(#e29c45)",
                "秋色(#896c39)",
                "秋香色(#d9b611)",
                // 绿色
                "嫩绿(#bddd22)",
                "柳黄(#c9dd22)",
                "柳绿(#afdd22)",
                "竹青(#789262)",
                "葱黄(#a3d900)",
                "葱绿(#9ed900)",
                "葱青(#0eb83a)",
                "葱倩(#0eb840)",
                "青葱(#0aa344)",
                "油绿(#00bc12)",
                "绿沈(#0c8918)",
                "碧色(#1bd1a5)",
                "碧绿(#2add9c)",
                "青碧(#48c0a3)",
                "翡翠色(#3de1ad)",
                "草绿(#40de5a)",
                "青色(#00e09e)",
                "青翠(#00e079)",
                "青白(#c0ebd7)",
                "鸭卵青(#e0eee8)",
                "蟹壳青(#bbcdc5)",
                "鸦青(#424c50)",
                "绿色(#00e500)",
                "豆绿(#9ed048)",
                "豆青(#96ce54)",
                "石青(#7bcfa6)",
                "玉色(#2edfa3)",
                "缥(#7fecad)",
                "艾绿(#a4e2c6)",
                "松柏绿(#21a675)",
                "松花绿(#057748)",
                "松花色(#bce672)",
                // 蓝色
                "蓝(#44cef6)",
                "靛青(#177cb0)",
                "靛蓝(#065279)",
                "碧蓝(#3eede7)",
                "蔚蓝(#70f3ff)",
                "宝蓝(#4b5cc4)",
                "蓝灰色(#a1afc9)",
                "藏青(#2e4e7e)",
                "藏蓝(#3b2e7e)",
                "黛(#4a4266)",
                "黛绿(#426666)",
                "黛蓝(#425066)",
                "黛紫(#574266)",
                "紫色(#8d4bbb)",
                "紫酱(#815463)",
                "酱紫(#815476)",
                "紫檀(#4c221b)",
                "绀紫(#003371)",
                "紫棠(#56004f)",
                "青莲(#801dae)",
                "群青(#4c8dae)",
                "雪青(#b0a4e3)",
                "丁香色(#cca4e3)",
                "藕色(#edd1d8)",
                "藕荷色(#e4c6d0)",
                // 仓色
                "苍色(#75878a)",
                "苍翠(#519a73)",
                "苍黄(#a29b7c)",
                "苍青(#7397ab)",
                "苍黑(#395260)",
                "苍白(#d1d9e0)",
                // 水色
                "水色(#88ada6)",
                "水红(#f3d3e7)",
                "水绿(#d4f2e7)",
                "水蓝(#d2f0f4)",
                "淡青(#d3e0f3)",
                "湖蓝(#30dff3)",
                "湖绿(#25f8cb)",
                // 灰白色
                "精白(#ffffff)",
                "象牙白(#fffbf0)",
                "雪白(#f2fdff)",
                "月白(#d6ecf0)",
                "缟(#f2ecde)",
                "素(#e0f0e9)",
                "荼白(#f3f9f1)",
                "霜色(#e9f1f6)",
                "花白(#c2ccd0)",
                "鱼肚白(#fcefe8)",
                "莹白(#e3f9fd)",
                "灰色(#808080)",
                "牙色(#eedeb0)",
                "铅白(#f0f0f4)",
                // 黑色
                "玄色(#622a1d)",
                "玄青(#3d3b4f)",
                "乌色(#725e82)",
                "乌黑(#392f41)",
                "漆黑(#161823)",
                "墨色(#50616d)",
                "墨灰(#758a99)",
                "黑色(#000000)",
                "缁色(#493131)",
                "煤黑(#312520)",
                "黧(#5d513c)",
                "黎(#75664d)",
                "黝(#6b6882)",
                "黝黑(#665757)",
                "黯(#41555d)",
                // 金银
                "赤金(#f2be45)",
                "金色(#eacd76)",
                "银白(#e9e7ef)",
                "老银(#bacac6)",
                "乌金(#a78e44)",
                "铜绿(#549688)",
            };

            List<Brush> colors = new List<Brush>();
            List<string> names = new List<string>();
            for (int i = 0; i < name_list.Count; i++)
            {
                string str = name_list[i].Split('(')[1].Split(')')[0];
                string name = name_list[i].Split('(')[0];
                Brush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(str));
                colors.Add(brush);
                names.Add(name);
            }

            for (int i = 0; i < colors.Count; i++)
            {
                ColorInfo info = new ColorInfo();
                info.BrushName.Text = names[i];
                info.BrushShow.Background = colors[i];
                info.BrushStr.Text = colors[i].ToString();
                _ = MyBrushContainer2.Children.Add(info);
            }
        }


        private void InitNBS()
        {
            List<Brush> colors = new List<Brush>
            {
                // Red Pink
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7E93")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FD7B7C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F3545E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBCAD")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EE9086")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C76864")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCBBB")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CF9B8F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9DBC8")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C8A696")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C10020")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BF2233")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7B001C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4F0014")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AB343A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#681C23")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#320A18")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B17267")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C4743")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#482A2A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1F0E11")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8B6C62")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#523C36")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E1112")),

                // Yellowish Pink
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF845C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7A5C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F64A46")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB28B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EE9374")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC6C5C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC8A8")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D39B85")),

                // Reddish Orange, Reddish Brown
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CD9A7B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F13A13")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB961")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A91D11")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D35339")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9B2F1F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B85D43")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F180D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#490005")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AA6651")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#712F26")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#321011")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#966A57")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5E3830")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#371F1C")),

                // Orange Brown
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6800")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB841")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6F1A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C34D0A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA161")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E8793E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B15124")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#753313")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4D220E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A86540")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#673923")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#35170C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#946B54")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5A3D30")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#32221A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8B6D5C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#503D33")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#140F0B")),

                // Orange Yellow, Yellowish Brown
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8E00")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB02E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8E0D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D76E00")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB961")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F7943C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C37629")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCA86")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#95500C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#593315")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BB8B54")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7D512D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3F2512")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B48764")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#785840")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D2B1F")),

                // Yellow, Olive Brown
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB300")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCF40")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E59E1F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B57900")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD35F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D79D41")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B07D2B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDB8B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CEA262")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A47C45")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2B7")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CAA885")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#945D0B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#64400F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#302112")),
                
                // Greenish Yellow, Olive
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4C800")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDC33")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCA817")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9F8200")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDE5A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C4A43D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9B8127")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDF84")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C4A55F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#846A20")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5E490F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#362C12")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8B734B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#52442C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2B2517")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#887359")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4D4234")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#121910")),

                // Yellow Green, Olive Green
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#93AA00")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CED23A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F8F18")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#425E17")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DCD36A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8B8940")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0D698")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#90845B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0A4500")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#142300")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#434B1B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#232C16")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#48442D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#27261A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#379931")),

                // Yellowish Green
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8CCB5E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#478430")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00541F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#002800")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6DF90")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007BA7")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#657F4B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#304B26")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#132712")),

                // Green
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007D34")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#47A76A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006B3C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#004524")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98C793")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#719B6E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#386646")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#203A27")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#16251C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D8DEBA")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8D917A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#575E4E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#313830")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#141613")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5E6CB")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BAAF96")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7A7666")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#45433B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#181513")),

                // Bluish Green
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00836E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009B76")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006D5B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00382B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A0D6B4")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#669E85")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2F6556")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#013A33")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#001D18")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007BA7")),

                // Greenish Blue
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2A8D9C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00677E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007BA7")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A3C6C0")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#649A9E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#30626B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#003841")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#022027")),

                // Blue
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007CAD")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4285B4")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00538A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#002F55")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A6BDD7")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6C92AF")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#395778")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#002137")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C1CACA")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#919192")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A545C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C3337")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#161A1E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9DFCF")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BEADA1")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7D746D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#464544")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#151719")),
                
                // Purplish Blue
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#20155E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#62639B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#474389")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1A153F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BAACC7")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#837DA2")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#423C63")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1A162A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CBBAC5")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8A7F8E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#413D51")),

                // Violet
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#884BAE")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#755D9A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#53377A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#240935")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEBEF1")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#876C99")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#543964")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#22132B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D8B1BF")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#957B8D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#46394B")),

                // Purple
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#943391")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DD80CC")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#803E75")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#531A50")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#320B35")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E3A9BE")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BA7FA2")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4870")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#472A3F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#230D21")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E6BBC1")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AE848B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#72525C")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#452D35")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1D1018")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FADBC8")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C8A99E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#88706B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#564042")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1B1116")),

                // Reddish Purple
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7E0059")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A366B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#641349")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#470736")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BB6C8A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C4566")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4F273A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#270A1F")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AC7580")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7D4D5D")),

                // Purplish Pink, Purplish Red
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF97BB")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F6768E")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EB5284")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA8AF")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E28090")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C76574")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FDBDBA")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC9293")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D5265B")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B32851")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6F0035")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#470027")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A73853")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5B1E31")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#28071A")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B27070")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8C4852")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9D7")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C2A894")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#817066")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#49423D")),
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#131313")),
            };
            List<string> names = new List<string>
            {
                "Vivid Pink", "Strong Pink", "Deep Pink", "Light Pink", "Moderate Pink", "Dark Pink", "Pale Pink", "Grayish Pink", "Pinkish White",
                "Pinkish Gray", "Vivid Red", "Strong Red", "Deep Red", "Very Deep Red", "Moderate Red", "Dark Red", "Very Dark Red", "Light Grayish Red",
                "Grayish Red", "Dark Grayish Red", "Blackish Red", "Reddish Gray", "Dark Reddish Gray", "Reddish Black",

                "Vivid Yellowish Pink", "Strong Yellowish Pink", "Deep Yellowish Pink", "Light Yellowish Pink", "Moderate Yellowish Pink",
                "Dark Yellowish Pink", "Pale Yellowish Pink", "Grayish Yellowish Pink",

                "Brownish Pink", "Vivid Reddish Orange", "Strong Reddish Orange", "Deep Reddish Orange", "Moderate Reddish Orange",
                "Dark Reddish Orange", "Grayish Reddish Orange", "Strong Reddish Brown", "Deep Reddish Brown", "Light Reddish Brown",
                "Moderate Reddish Brown", "Dark Reddish Brown", "Light Grayish Reddish Brown", "Grayish Reddish Brown", "Dark Grayish Reddish Brown",

                "Vivid Orange", "Brilliant Orange", "Strong Orange", "Deep Orange", "Light Orange", "Moderate Orange",
                "Brownish Orange", "Strong Brown", "Deep Brown", "Light Brown", "Moderate Brown", "Dark Brown",
                "Light Grayish Brown", "Grayish Brown", "Dark Grayish Brown", "Light Brownish Gray", "Brownish Gray", "Brownish Black",

                "Vivid Orange Yellow", "Brilliant Orange Yellow", "Strong Orange Yellow", "Deep Orange Yellow", "Light Orange Yellow",
                "Moderate Orange Yellow", "Dark Orange Yellow", "Pale Orange Yellow", "Strong Yellowish Brown", "Deep Yellowish Brown", "Light Yellowish Brown",
                "Moderate Yellowish Brown", "Dark Yellowish Brown", "Light Grayish Yellowish Brown", "Grayish Yellowish Brown", "Dark Grayish Yellowish Brown",

                "Vivid Yellow", "Brilliant Yellow", "Strong Yellow", "Deep Yellow", "Light Yellow", "Moderate Yellow", "Dark Yellow", "Pale Yellow",
                "Grayish Yellow", "Dark Grayish Yellow", "Yellowish White", "Yellowish Gray", "Light Olive Brown", "Moderate Olive Brown", "Dark Olive Brown",

                "Vivid Greenish Yellow", "Brilliant Greenish Yellow", "Strong Greenish Yellow", "Deep Greenish Yellow", "Light Greenish Yellow",
                "Moderate Greenish Yellow", "Dark Greenish Yellow", "Pale Greenish Yellow", "Grayish Greenish Yellow", "Light Olive", "Moderate Olive",
                "Dark Olive", "Light Grayish Olive", "Grayish Olive", "Dark Grayish Olive", "Light Olive Gray", "Olive Gray", "Olive Black",

                "Vivid Yellowish Green", "Brilliant Yellow Green", "Strong Yellow Green", "Deep Yellow Green", "Light Yellow Green",
                "Moderate Yellow Green", "Pale Yellowish Green", "Grayish Yellowish Green", "Strong Olive Green", "Deep Olive Green",
                "Moderate Olive Green", "Dark Olive Green", "Grayish Olive Green", "Dark Grayish Olive Green", "Vivid Yellowish Green",

                "Brilliant Yellowish Green", "Strong Yellowish Green", "Deep Yellowish Green", "Very Deep Yellowish Green", "Very Light Yellowish Green",
                "Light Yellowish Green", "Moderate Yellowish Green", "Dark Yellowish Green", "Very Dark Yellowish Green",

                "Vivid Green", "Brilliant Green", "Strong Green", "Deep Green", "Very Light Green", "Light Green", "Moderate Green",
                "Dark Green", "Very Dark Green", "Very Pale Green", "Pale Green", "Grayish Green", "Dark Greenish Yellowish Green",
                "Blackish Green", "Greenish White", "Light Greenish Gray", "Greenish Gray", "Dark Greenish Gray", "Greenish Black",

                "Vivid Bluish Green", "Brilliant Bluish Green", "Strong Bluish Green", "Deep Bluish Green", "Very Light Bluish Green",
                "Light Bluish Green", "Moderate Bluish Green", "Dark Bluish Green", "Very Dark Bluish Green", "Vivid Greenish Blue",

                "Brilliant Greenish Blue", "Strong Greenish Blue", "Deep Greenish Blue", "Very Light Greenish Blue",
                "Light Greenish Blue", "Moderate Greenish Blue", "Dark Greenish Blue", "Very Dark Greenish Blue",

                "Vivid Blue", "Brilliant Blue", "Strong Blue", "Deep Blue", "Very Light Blue", "Light Blue", "Moderate Blue", "Dark Blue", "Very Pale Blue",
                "Pale Blue", "Grayish Blue", "Dark Grayish Blue", "Blackish Blue", "Bluish White", "Light Bluish Gray", "Bluish Gray", "Dark Bluish Gray", "Bluish Black",

                "Very Purplish Blue", "Brilliant Purplish Blue", "Strong Purplish Blue", "Deep Purplish Blue", "Very Light Purplish Blue",
                "Light Purplish Blue", "Moderate Purplish Blue", "Dark Purplish Blue", "Very Pale Purplish Blue", "Pale Purplish Blue", "Grayish Purplish Blue",

                "Vivid Violet", "Brilliant Violet", "Strong Violet", "Deep Violet", "Very Light Violet", "Light Violet", "Moderate Violet", "Dark Violet",
                "Very Pale Violet", "Pale Violet", "Grayish Violet",

                "Vivid Purple", "Brilliant Purple", "Strong Purple", "Deep Purple", "Very Deep Purple", "Very Light Purple", "Light Purple",
                "Moderate Purple", "Dark Purple", "Very Dark Purple", "Very Pale Purple", "Pale Purple", "Grayish Purple", "Dark Grayish Purple",
                "Blackish Purple", "Purplish White", "Light Purplish Gray", "Purplish Gray", "Dark Purplish Gray", "Purplish Black",

                "Vivid Reddish Purple", "Strong Reddish Purple", "Deep Reddish Purple", "Very Deep Reddish Purple", "Light Reddish Purple",
                "Moderate Reddish Purple", "Dark Reddish Purple", "Very Dark Reddish Purple", "Pale Reddish Purple", "Grayish Reddish Purple",

                "Brilliant Purplish Pink", "Strong Purplish Pink", "Deep Purplish Pink", "Light Purplish Pink", "Moderate Purplish Pink",
                "Dark Purplish Pink", "Pale Purplish Pink", "Grayish Purplish Pink", "Vivid Purplish Red", "Strong Purplish Red",
                "Deep Purplish Red", "Very Deep Purplish Red", "Moderate Purplish Red", "Dark Purplish Red", "Very Dark Purplish Red",
                "Light Grayish Purplish Red", "Grayish Purplish Red", "White", "Light Gray", "Medium Gray", "Dark Gray", "Black",
            };


            for (int i = 0; i < colors.Count; i++)
            {
                ColorInfo info = new ColorInfo();
                info.BrushName.Text = names[i];
                info.BrushShow.Background = colors[i];
                info.BrushStr.Text = colors[i].ToString();
                _ = MyBrushContainer3.Children.Add(info);
            }
        }


        private void InitJapaneseBrush()
        {

        }
    }
}