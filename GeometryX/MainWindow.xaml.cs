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
    }
}