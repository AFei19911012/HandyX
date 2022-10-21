using GifX.ViewModel;
using HandyControl.Data;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace GifX
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        // 用来传递参数
        public static MainWindowViewModel VM { get; set; } = new MainWindowViewModel();
        private double WindowWidth { get; set; } = 0;
        private double WindowHeight { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();

            // 数据验证
            SetVerifyFunc();

            DataContext = VM;
        }

        // 设置验证函数
        private void SetVerifyFunc()
        {
            // 获取屏幕分辨率
            // 方式一：全屏尺寸
            int width1 = (int)SystemParameters.PrimaryScreenWidth;
            int height1 = (int)SystemParameters.PrimaryScreenHeight;

            // 方式二：不含任务栏
            int width2 = (int)SystemParameters.WorkArea.Width;
            int height2 = (int)SystemParameters.WorkArea.Height;


            int maxGifWidth = width2 - (int)cmdBorder.Width;
            int maxGifHeight = height2 - (int)headBorder.Height;
            VM.GifMaxWidth = maxGifWidth;
            VM.GifMaxHeight = maxGifHeight;

            gifWidth.VerifyFunc = str => int.TryParse(str, out int v)
                ? v < 300 || v > maxGifWidth
                    ? OperationResult.Failed("[300, " + maxGifWidth + "]")
                    : OperationResult.Success()
                : OperationResult.Failed("Error");

            gifHeight.VerifyFunc = str => int.TryParse(str, out int v)
                ? v < 300 || v > maxGifHeight
                    ? OperationResult.Failed("[300, " + maxGifHeight + "]")
                    : OperationResult.Success()
                : OperationResult.Failed("Error");
        }

        // 拖动窗体
        private void Window_DragMove(object sender, MouseButtonEventArgs e)
        {
            // 右键报错
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        // 最小化窗体
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // 关闭窗体
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // 窗体大小变化
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gifBorder.Width = Width - cmdBorder.Width;
            gifBorder.Height = Height - headBorder.Height;
        }

        // 按钮事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is System.Windows.Controls.Button button))
            {
                return;
            }
            if (button.Content.ToString() == "OK")
            {
                if (WindowWidth == 0 || WindowHeight == 0)
                {
                    WindowWidth = gifWidth.Value + cmdBorder.Width;
                    WindowHeight = gifHeight.Value + headBorder.Height;
                }
                Width = WindowWidth;
                Height = WindowHeight;
            }
            else if (button.Content.ToString() == "Default")
            {
                WindowWidth = 0;
                WindowHeight = 0;
                Height = 300 + headBorder.Height;
                Width = 300 + cmdBorder.Width;
                VM.SpeedRatio = 1;
            }
        }

        // 按下录屏键的时候记录位置
        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            // 控件的绝对位置（相对屏幕的位置）
            VM.GifPosition = gifBorder.PointToScreen(new Point(0d, 0d));
        }

        // 位置变化时记录位置
        private void MainWindow_LocationChanged(object sender, System.EventArgs e)
        {
            if (gifBorder.ActualWidth == 0)
            {
                return;
            }
            VM.GifPosition = gifBorder.PointToScreen(new Point(0d, 0d));
        }

        // 显示 Gif
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Gif File(*.gif)|*.gif",
                Multiselect = true,
                RestoreDirectory = true,
                Title = "Select a gif"
            };
            string[] fileNames;
            if (openFileDialog.ShowDialog() == true)
            {
                fileNames = openFileDialog.FileNames;
            }
            else
            {
                return;
            }
            for (int i = 0; i < fileNames.Length; i++)
            {
                Gif gif = new Gif(fileNames[i]);
                double height = gif.gifImage.Source.Height;
                double width = gif.gifImage.Source.Width;
                gif.Width = width + 10;
                gif.Height = height + gif.NonClientAreaHeight + 10;
                gif.Margin = new Thickness(5);
                gif.Title = System.IO.Path.GetFileName(fileNames[i]);
                gif.Show();
            }
        }
    }
}