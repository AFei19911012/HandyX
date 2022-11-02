using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace IconfontX
{
    ///
    /// ----------------------------------------------------------------
    /// Copyright @CoderMan/CoderMan1012 2022 All rights reserved
    /// Author      : CoderMan/CoderMan1012
    /// Created Time: 2022/11/1 23:41:08
    /// Description :
    /// ------------------------------------------------------
    /// Version      Modified Time              Modified By                               Modified Content
    /// V1.0.0.0     2022/11/1 23:41:08    CoderMan/CoderMan1012                 
    ///
    public class GeometryMethod
    {
        public static Geometry ConvertGeometry(Geometry geometry)
        {
            PathGeometry path = new PathGeometry();
            path.AddGeometry(geometry);
            // 设置填充规则 很重要
            path.FillRule = FillRule.Nonzero;
            return path;
        }


        public static Geometry ConvertGeometryFill(Geometry geometry)
        {
            string[] strs = geometry.ToString().Split('M');
            List<string> paths = new List<string>();
            for (int i = 1; i < strs.Length; i++)
            {
                paths.Add("M" + strs[i]);
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Geometry));
            if (paths.Count == 1)
            {
                return ConvertGeometry(geometry);
            }
            else if (paths.Count > 1)
            {
                // 仍然遇到一些无法填满的图标
                CombinedGeometry combined = new CombinedGeometry
                {
                    Geometry1 = (Geometry)converter.ConvertFrom(paths[0]),
                };
                for (int i = 1; i < paths.Count; i++)
                {
                    combined.Geometry1 = Geometry.Combine(combined.Geometry1, (Geometry)converter.ConvertFrom(paths[i]), GeometryCombineMode.Union, null);
                }
                return combined;
            }
            return null;
        }
    }
}