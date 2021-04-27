using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("ScadaTable")]
   public class ScadaTableModel:Entity
    {
        public ScadaTableModel()
        {
            RowNum = 100;
            ColNum = 26;
        }
        public string Title { set; get; }
        /// <summary>
        /// 非数据库字段
        /// </summary>
        [Computed]
        public string RoleUserID { set; get; }
        public string FilterRule { set; get; }
        public int ShowAlarms { set; get; }
        public int ShowRealSeries { set; get; }
        public int ShowHistory { set; get; }
        public int ShowHistorySeries { set; get; }
        public int ShowHistoryAlarms { set; get; }
        public string ColumnTitles { set; get; }
        public string ColimnWidths { set; get; }
        public int RowNum
        { set; get; }
        public int ColNum
        { set; get; }
     
  

    }
}
