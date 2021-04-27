using DapperExtensions;
using ScadaWeb.DapperExtensions;

namespace ScadaWeb.Model
{
    [Table("RoleAuthorize")]
    public class RoleAuthorizeModel
    {
        /// <summary>
        /// 角色主键
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 模块主键
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// 按钮主键
        /// </summary>
        public int ButtonId { get; set; }
    }
}
