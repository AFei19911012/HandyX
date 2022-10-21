using GifX.GIFplayer;

namespace GifX
{
    /// <summary>
    /// Gif.xaml 的交互逻辑
    /// </summary>
    public partial class Gif
    {
        public GifImage gifImage;

        public Gif(string fileName)
        {
            InitializeComponent();

            gifImage = new GifImage(fileName);
            gifView.Children.Add(gifImage);
            Begin();
        }

        public void Begin()
        {
            gifImage.StartAnimate();
        }

        public void Stop()
        {
            gifImage.StopAnimate();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Stop();
        }
    }
}