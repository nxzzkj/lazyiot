using System.ComponentModel.DataAnnotations;

namespace ScadaWeb.Common
{
    /// <summary>
    /// 显示位置枚举
    /// </summary>
    public enum PositionEnum
    {
        /// <summary>
        /// 表内
        /// </summary>
        [Display(Name = "表内")]
        FormInside = 0,
        /// <summary>
        /// 表外
        /// </summary>
        [Display(Name = "表外")]
        FormRightTop = 1
    }
}
