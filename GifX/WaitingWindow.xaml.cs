using GifX.ViewModel;
using System.Windows.Controls;

namespace GifX
{
    /// <summary>
    /// WaitingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WaitingWindow : UserControl
    {
        public WaitingWindowViewModel VM { get; set; }

        public WaitingWindow(int curValue, int maxValue)
        {
            InitializeComponent();

            VM = new WaitingWindowViewModel
            {
                CurrentValue = curValue,
                MaxVaule = maxValue,
                CloseVisible = false,
            };

            DataContext = VM;
        }
    }
}