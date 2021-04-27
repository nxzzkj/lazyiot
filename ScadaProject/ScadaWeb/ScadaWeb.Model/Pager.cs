using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    public class Pager
    {
        public static dynamic Paging(IEnumerable<dynamic> list, long total)
        {
            return new { code = 0, msg = "", count = total, data = list };
        }
        public static dynamic ExcelPaging(IEnumerable<dynamic> list, IEnumerable<dynamic> backcolorlist, IEnumerable<dynamic> fontcolorlist, IEnumerable<dynamic> fontsizeclist, IEnumerable<dynamic> fontweightlist, List<int> fontwidthlist, long total)
        {
            return new { code = 0, msg = "", count = total, data = list,backcolors= backcolorlist,fontcolors= fontcolorlist,fontsizes= fontsizeclist,fontweights=fontweightlist , fontwidths= fontwidthlist };
        }
        public static dynamic RealExcelPaging(IEnumerable<ExcelModel> Iolist, IEnumerable<dynamic> backcolorlist, IEnumerable<dynamic> fontcolorlist, IEnumerable<dynamic> fontsizeclist, IEnumerable<dynamic> fontweightlist, List<ExcelModel> datas, long total)
        {
            return new { code = 0, msg = "", count = total, data = datas , backcolors = backcolorlist, fontcolors = fontcolorlist, fontsizes = fontsizeclist, fontweights = fontweightlist, iopara = Iolist };
        }
        public static string Paging2(string list, long total)
        {

            return   "{ 'code' : 0, 'msg' : '', 'count' :"+ total + ", 'data':"+ list + " }";
        }
        public static dynamic ScadaTablePaging(IEnumerable<dynamic> list, dynamic current, long total)
        {
            return new { code = 0, msg = "", count = total, data = list, current= current };
        }
    
        public static object ScadaDataTablePaging(string table, long total, string id)
        {
            return new
            {
                code = 0,
                msg = "",
                count = total,
                data = table,
                elementId = id
            };
        }

     
     
    }
}
