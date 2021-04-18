using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaWeb.Model
{
    public class TreeSelect
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool open { get; set; }
        public IEnumerable<TreeSelect> children { get; set; }
    }
    public class IOTreeSelect
    {
        public IOTreeSelect()
        {
            UpdateCycle = 120;
        }
        public string id { get; set; }
        public string name { get; set; }
        public bool open { get; set; }
        public string DeviceID { set; get; }
        public string CommunicateID { set; get; }
        public string ServerID { set; get; }
        public string value { get; set; }
        public int UpdateCycle { set; get; }
        public IEnumerable<IOTreeSelect> children { get; set; }
    }
    public class SelectOption
    {
        public string id { get; set; }
        public string name { get; set; }

        public string value { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public string value4 { get; set; }
        public string value5 { get; set; }
        public string value6 { get; set; }
        public string value7 { get; set; }
    }
    public class SerieOption
    {
        public string id { get; set; }
        public string name { get; set; }

        public string value { get; set; }

        public SerieConfigModel SerieConfig{set;get;}
    }
    public class GridColumn
    {
        public GridColumn()
        {
            width = "120";
        }
        public string field
        {
            set;
            get;
        }
        public string width
        { set; get; }
        public string title
        { set; get; }
    }
   

}
