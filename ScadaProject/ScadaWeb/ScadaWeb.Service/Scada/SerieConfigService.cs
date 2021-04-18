 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.IService;

namespace ScadaWeb.Service
{
  public  class SerieConfigService : BaseService<SerieConfigModel>, ISerieConfigService
    {
        public SerieConfigService()
        {

        }
     
        public dynamic GetAll()
        {
            return base.GetAll(null, null);
        }

        public dynamic GetListByFilter(SerieConfigModel filter, PageInfo pageInfo)
        {
            pageInfo.field = "SerieClassify";
            pageInfo.order = "  asc ";
            pageInfo.prefix = " ";
            string _where = "  SerieConfig where 1=1 ";
            if (!string.IsNullOrEmpty(filter.SerieTitle))
            {
                _where += string.Format(" and {0}SerieTitle like '%"+ filter.SerieTitle.Trim() + "%'", pageInfo.prefix);
            }
            if (!string.IsNullOrEmpty(filter.SerieClassify))
            {
                _where += string.Format(" and {0}SerieClassify like '%"+ filter.SerieClassify.Trim() + "%'", pageInfo.prefix);
            }
            
            _where = CreateTimeWhereStr(filter.StartEndDate, _where, pageInfo.prefix);
            pageInfo.returnFields = string.Format("{0}Id,{0}SerieName,{0}SerieTitle,{0}SerieWidth,{0}SerieType,{0}SerieColor,{0}SymbolSize,{0}SymbolType,{0}SymbolColor,{0}SymbolStep,{0}ShowSymbol,{0}ShowLegend,{0}SerieClassify,{0}SortCode,{0}EnCode,{0}CreateUserId,{0}CreateTime,{0}UpdateTime,{0}UpdateUserId", pageInfo.prefix);
            return GetPageUnite(filter, pageInfo, _where);
        }

       
     
    }
}
