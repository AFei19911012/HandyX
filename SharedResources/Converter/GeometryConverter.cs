using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SharedResources.Converter
{
    ///
    /// ----------------------------------------------------------------
    /// Copyright @CoderMan/CoderMan1012 2022 All rights reserved
    /// Author      : CoderMan/CoderMan1012
    /// Created Time: 2022/10/27 0:47:12
    /// Description :
    /// ------------------------------------------------------
    /// Version      Modified Time              Modified By                               Modified Content
    /// V1.0.0.0     2022/10/27 0:47:12    CoderMan/CoderMan1012                 
    ///
    public class GeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PathGeometry geometry = new PathGeometry();
            geometry.AddGeometry((Geometry)value);
            // 设置填充规则 很重要
            geometry.FillRule = FillRule.Nonzero;
            return geometry;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}