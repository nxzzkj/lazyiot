using DapperExtensions;
using ScadaWeb.DapperExtensions;

namespace ScadaWeb.Model
{
    [Table("TopButton")]
    public class TopButtonModel : Entity
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 绑定的图标文件
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 按钮样式
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 按钮颜色
        /// </summary>
        public string ButtonColor { get; set; }
    }
}
