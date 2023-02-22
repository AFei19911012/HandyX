using GeometryX.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

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

        /// <summary>
        /// 设置窗体尺寸
        /// </summary>
        private void SetWindowSize()
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                MyResizeIcon.Data = (Geometry)FindResource("IconWindowMax");
                MyButtonResize.ToolTip = "最大化";
            }
            else
            {
                WindowState = WindowState.Maximized;
                MyResizeIcon.Data = (Geometry)FindResource("IconWindowRestore");
                MyButtonResize.ToolTip = "向下还原";
            }
        }

        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonResize_Click(object sender, RoutedEventArgs e)
        {
            SetWindowSize();
        }

        private void Move_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();

                // 拖动后窗体变成默认的
                WindowState = WindowState.Normal;
                MyResizeIcon.Data = (Geometry)FindResource("IconWindowMax");
                MyButtonResize.ToolTip = "最大化";
            }
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left && e.ClickCount == 2)
            {
                SetWindowSize();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MaxWidth = SystemParameters.MaximumWindowTrackWidth;
            MaxHeight = SystemParameters.MaximumWindowTrackHeight;
        }
    }
}