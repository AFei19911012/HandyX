using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GeometryX.View
{
    /// <summary>
    /// IconButton.xaml 的交互逻辑
    /// </summary>
    public partial class IconButton : Button
    {
        public IconButton()
        {
            InitializeComponent();

            DataContext = this;
        }


        /// <summary>
        /// 路径数据
        /// </summary>
        public Geometry PathData
        {
            get => (Geometry)GetValue(PathDataProperty);
            set => SetValue(PathDataProperty, value);
        }
        public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register("PathData", typeof(Geometry), typeof(IconButton), new PropertyMetadata(new PathGeometry()));


        /// <summary>
        /// 圆角半径
        /// </summary>
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(int), typeof(IconButton), new PropertyMetadata(0));


        /// <summary>
        /// 鼠标停留前景颜色
        /// </summary>
        public Brush MouseOverForeground
        {
            get => (Brush)GetValue(MouseOverForegroundProperty);
            set => SetValue(MouseOverForegroundProperty, value);
        }
        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(IconButton), new PropertyMetadata(Brushes.DeepSkyBlue));
    }
}