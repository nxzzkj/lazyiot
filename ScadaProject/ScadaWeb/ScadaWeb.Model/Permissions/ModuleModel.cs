using DapperExtensions;
using ScadaWeb.DapperExtensions;

namespace ScadaWeb.Model
{
    [Table("Module")]
    public class ModuleModel : Entity
    {
        /// <summary>
        /// 父级
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 字体类型 layui-icon|ok-icon|my-icon
        /// </summary>
        public string FontFamily { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string UrlAddress { get; set; }

        /// <summary>
        /// 菜单按钮复选框Html
        /// </summary>
        [Computed]
        public string ModuleButtonHtml { get; set; }

        public int IsSystem
        {
            set;get;
        }
        /// <summary>
        /// 菜单是否选中
        /// </summary>
        [Computed]
        public bool IsChecked { get; set; }
    }
}
