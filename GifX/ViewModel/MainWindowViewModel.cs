using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GifX.GIFmaker;
using GifX.Helper;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;

namespace GifX.ViewModel
{
    ///
    /// ----------------------------------------------------------------
    /// Copyright @CoderMan/CoderMan1012 2022 All rights reserved
    /// Author      : CoderMan/CoderMan1012
    /// Created Time: 2022/10/19 23:44:17
    /// Description :
    /// ------------------------------------------------------
    /// Version      Modified Time              Modified By                               Modified Content
    /// V1.0.0.0     2022/10/19 23:44:17    CoderMan/CoderMan1012                 
    ///
    public class MainWindowViewModel : ViewModelBase
    {
        #region 绑定变量
        private string progressInfo;
        public string ProgressInfo
        {
            get => progressInfo;
            set => Set(ref progressInfo, value);
        }

        private string operationFlag;
        public string OperationFlag
        {
            get => operationFlag;
            set => Set(ref operationFlag, value);
        }

        private bool isFPS10;
        public bool IsFPS10
        {
            get => isFPS10;
            set
            {
                Set(ref isFPS10, value);
                if (IsFPS10)
                {
                    IsFPS33 = !value;
                }
            }
        }

        private bool isFPS33;
        public bool IsFPS33
        {
            get => isFPS33;
            set
            {
                _ = Set(ref isFPS33, value);
                if (IsFPS33)
                {
                    IsFPS10 = !value;
                }
            }
        }

        private bool isCaptureCursor;
        public bool IsCaptureCursor
        {
            get => isCaptureCursor;
            set => Set(ref isCaptureCursor, value);
        }

        private int gifWidth;
        public int GifWidth
        {
            get => gifWidth;
            set => Set(ref gifWidth, value);
        }

        private int gifHeight;
        public int GifHeight
        {
            get => gifHeight;
            set => Set(ref gifHeight, value);
        }

        private int gifMaxWidth;
        public int GifMaxWidth
        {
            get => gifMaxWidth;
            set => Set(ref gifMaxWidth, value);
        }

        private int gifMaxHeight;
        public int GifMaxHeight
        {
            get => gifMaxHeight;
            set => Set(ref gifMaxHeight, value);
        }

        private bool isGrayScale;
        public bool IsGrayScale
        {
            get => isGrayScale;
            set => Set(ref isGrayScale, value);
        }

        private double speedRatio;
        public double SpeedRatio
        {
            get => speedRatio;
            set => Set(ref speedRatio, value);
        }
        #endregion

        // 变量
        public string TempFolder { get; set; }
        public Point GifPosition { get; set; }
        public int CurBmpNumber { get; set; }
        public DispatcherTimer Timer { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        // 初始化参数
        public MainWindowViewModel()
        {
            IsFPS10 = true;
            IsCaptureCursor = true;
            IsGrayScale = false;
            SpeedRatio = 1;
            GifWidth = 300;
            GifHeight = 300;
            GifMaxWidth = 800;
            GifMaxHeight = 600;
            OperationFlag = "Record";
            ProgressInfo = "";
            TempFolder = @"C:\Users\Administrator\AppData\Local\Temp\GifCaptureTemporaryFrames";
            CurBmpNumber = 1;
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(ScreenCpatured);
        }

        // 带参数的命令
        public RelayCommand<string> SelectCmd => new Lazy<RelayCommand<string>>(() => new RelayCommand<string>(SelectEvent)).Value;

        private void SelectEvent(string key)
        {
            // 开始录屏
            if (key == "Record")
            {
                OperationFlag = "Stop";
                // 开始计时
                TimeStart = DateTime.Now;
                // 计时器执行截图任务
                Timer.Interval = IsFPS10 ? new TimeSpan(0, 0, 0, 0, 100) : new TimeSpan(0, 0, 0, 0, 30);
                Timer.Start();
            }
            // 暂停
            else if (key == "Stop")
            {
                OperationFlag = "Record";
                // 停止计时器任务
                Timer.Stop();
                // 结束计时
                TimeEnd = DateTime.Now;
            }
            // 新建录屏
            else if (key == "CommandNew")
            {
                DelectDirFiles(TempFolder);
                CurBmpNumber = 1;
                ProgressInfo = "Frame " + 0;
            }
            // 保存为 Gif
            else if (key == "CommandSave")
            {
                // 保存
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "GIF file (*.gif)|*.gif",
                    Title = "Save as GIF",
                    FileName = "Gif",
                    RestoreDirectory = true,
                };
                string fileName;
                if (saveFileDialog.ShowDialog() == true)
                {
                    fileName = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
                TimeSpan span = TimeEnd.Subtract(TimeStart);
                double time = span.TotalMilliseconds;
                // 判断文件夹是否存在
                if (Directory.Exists(TempFolder))
                {
                    DirectoryInfo directory = new DirectoryInfo(TempFolder);
                    // 指定类型
                    FileInfo[] collections = directory.GetFiles("*.png");   // 这种方式获取的文件名有规则
                    int totalFrames = collections.Length;
                    int delay = (int)(time / SpeedRatio / totalFrames);

                    // 进度
                    WaitingWindow waiting = new WaitingWindow(1, totalFrames);
                    _ = HandyControl.Controls.Dialog.Show(waiting);
                    // 33ms delay (~30fps)
                    using (AnimatedGifCreator animatedGif = new AnimatedGifCreator(fileName, delay))
                    {
                        GifQuality quality = GifQuality.Bit8;
                        if (IsGrayScale)
                        {
                            quality = GifQuality.Grayscale;
                        }
                        for (int i = 0; i < totalFrames; i++)
                        {
                            waiting.VM.CurrentValue = i + 1;
                            string name = TempFolder + "\\" + (i + 1) + ".png";
                            using (System.Drawing.Image image = System.Drawing.Image.FromFile(name))
                            {
                                animatedGif.AddFrame(image, delay, quality);
                            }
                            if (i == totalFrames - 1)
                            {
                                waiting.VM.CloseVisible = true;
                            }
                            DispatcherHelper.DoEvents();
                        }
                    }
                }
            }
        }

        // 不带参数的命令
        // 打开临时文件夹
        public RelayCommand OpenFolderCmd => new Lazy<RelayCommand>(() => new RelayCommand(OpenFolderEvent)).Value;
        private void OpenFolderEvent()
        {
            System.Diagnostics.Process.Start(TempFolder);
        }

        // 启动时创建临时文件夹
        public RelayCommand CmdLoaded => new Lazy<RelayCommand>(() => new RelayCommand(LoadedEvent)).Value;
        private void LoadedEvent()
        {
            if (!Directory.Exists(TempFolder))
            {
                _ = Directory.CreateDirectory(TempFolder);
            }
            else
            {
                // 如果存在文件夹，删除该目录下的文件
                DelectDirFiles(TempFolder);
            }
        }

        // 关闭时删除临时文件夹
        public RelayCommand CmdClosed => new Lazy<RelayCommand>(() => new RelayCommand(ClosedEvent)).Value;
        private void ClosedEvent()
        {
            if (Directory.Exists(TempFolder))
            {
                // 删除文件
                DelectDirFiles(TempFolder);
                // 删除目录
                Directory.Delete(TempFolder);
            }
        }

        // 删除指定目录下的所有文件
        private void DelectDirFiles(string folder)
        {
            if (Directory.Exists(folder))
            {
                DirectoryInfo dir = new DirectoryInfo(folder);
                // 返回目录中所有文件和子目录
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo item in fileinfo)
                {
                    // 判断是否文件夹
                    if (item is DirectoryInfo)
                    {
                        DirectoryInfo subDir = new DirectoryInfo(item.FullName);
                        subDir.Delete(true);
                    }
                    else
                    {
                        // 删除指定文件
                        File.Delete(item.FullName);
                    }
                }
            }
        }

        // 截屏
        private void ScreenCpatured(object sender, EventArgs e)
        {
            if (OperationFlag == "Stop")
            {
                try
                {
                    ProgressInfo = "Frame " + CurBmpNumber;
                    System.Drawing.Size size = new System.Drawing.Size(GifWidth, GifHeight);
                    using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(size.Width, size.Height))
                    {
                        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                        int sourceX = (int)GifPosition.X;
                        int sourceY = (int)GifPosition.Y;
                        int destX = sourceX + GifWidth;
                        int destY = sourceY + GifHeight;
                        g.CopyFromScreen(sourceX, sourceY, 0, 0, size);
                        // 是否获取鼠标
                        if (IsCaptureCursor)
                        {
                            CURSORINFO pci;
                            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                            GetCursorInfo(out pci);
                            // 判断鼠标是否在范围内
                            int x = pci.ptScreenPos.x;
                            int y = pci.ptScreenPos.y;
                            if (x >= sourceX && x <= destX && y >= sourceY && y <= destY)
                            {
                                // 相对位置
                                x -= sourceX;
                                y -= sourceY;
                                System.Windows.Forms.Cursor cur = new System.Windows.Forms.Cursor(pci.hCursor);
                                cur.Draw(g, new System.Drawing.Rectangle(x - 10, y - 10, cur.Size.Width, cur.Size.Height));
                            }
                        }
                        string filePath = TempFolder + "\\" + CurBmpNumber + ".png";
                        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                        CurBmpNumber++;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        // 获取鼠标
        private struct POINT
        {
            public int x;
            public int y;
        }

        private struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetCursorPos(out POINT pt);
    }
}