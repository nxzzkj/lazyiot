using ScadaWeb.DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    [Table("SerieConfig")]
    public  class SerieConfigModel: Entity
    {
        public SerieConfigModel()
        {
            SerieWidth = "2";
            SerieColor = "#FF0000";
            SerieColor = "#FF0000";
            SymbolType = "circle";
            SymbolSize = "8";
            SymbolStep = "2";
            ShowSymbol ="1";
            ShowLegend = "1";
        }
        public string SerieName { get; set; }
        public string SerieClassify { get; set; }
        
        public string SerieTitle { get; set; }
        public string SerieWidth { get; set; }
        //"line","bar"
        public string SerieType { get; set; }
        public string SerieColor { get; set; }
        public string SymbolSize { get; set; }

        //'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
        public string SymbolType { get; set; }
        public string SymbolColor { get; set; }
        public string SymbolStep { get; set; }
        public string ShowSymbol { get; set; }
        public string ShowLegend { get; set; }
        
  
    }
}
