using System;
using System.ComponentModel;
namespace Scada.Controls
{
                   [Description("展开属性选型去除描述")]
    public class EmptyConverter : ExpandableObjectConverter
    {
                                                                                public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(string))
                return (object)String.Empty;
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
