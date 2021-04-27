
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace Scada.Controls
{
                   [Description("ColorExt控件设计模式行为")]
    public class ColorExtDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.LeftSizeable | SelectionRules.Moveable | SelectionRules.RightSizeable;
            }
        }

    }
                   [Description("ColorPickerExt控件设计模式行为")]
    public class ColorPickerExtDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.Moveable;
            }
        }

    }
}
