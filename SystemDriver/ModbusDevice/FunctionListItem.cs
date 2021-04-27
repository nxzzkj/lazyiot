using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDevice
{   
  
    public class FunctionListItem
    {
        public FunctionListItem()
        {

        }
        public FunctionListItem(string name, string code)
        {
            Name = name;
            Code = code;
        }
        public string Name
        {
            set;
            get;
        }
        public string Code
        {
            set;
            get;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
