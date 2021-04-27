using DapperExtensions;
using ScadaWeb.DapperExtensions;

namespace ScadaWeb.Model
{
    [Table("Items")]
    public class ItemsModel : Entity
    {
        /// <summary>
        /// 父级
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
    }
}
