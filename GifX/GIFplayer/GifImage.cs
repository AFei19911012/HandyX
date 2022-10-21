using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GifX.GIFplayer
{
    // 显示 Gif
    public class GifImage : System.Windows.Controls.Image
    {
        // gif 动画的 System.Drawing.Bitmap   
        private Bitmap gifBitmap;

        // 用于显示每一帧的 BitmapSource  
        private BitmapSource bitmapSource;

        public GifImage(string gifPath)
        {
            gifBitmap = new Bitmap(gifPath);   // 绝对路径
            bitmapSource = GetBitmapSource();
            Source = bitmapSource;
        }

        // 从 System.Drawing.Bitmap 中获得用于显示的那一帧图像的 BitmapSource  
        private BitmapSource GetBitmapSource()
        {
            IntPtr handle = IntPtr.Zero;
            try
            {
                handle = gifBitmap.GetHbitmap();
                bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    DeleteObject(handle);
                }
            }
            return bitmapSource;
        }

        // Start animation  
        public void StartAnimate()
        {
            ImageAnimator.Animate(gifBitmap, OnFrameChanged);
        }

        // Stop animation  
        public void StopAnimate()
        {
            ImageAnimator.StopAnimate(gifBitmap, OnFrameChanged);
        }

        // Event handler for the frame changed  
        private void OnFrameChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                ImageAnimator.UpdateFrames();  // 更新到下一帧  
                if (bitmapSource != null)
                {
                    bitmapSource.Freeze();
                }
                // Convert the bitmap to BitmapSource
                bitmapSource = GetBitmapSource();
                Source = bitmapSource;
                InvalidateVisual();
            }));
        }

        // Delete local bitmap resource  
        // Reference: http://msdn.microsoft.com/en-us/library/dd183539(VS.85).aspx  
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteObject(IntPtr hObject);
    }
}