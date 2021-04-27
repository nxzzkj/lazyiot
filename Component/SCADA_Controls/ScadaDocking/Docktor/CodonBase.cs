using System;
using System.Collections.Generic;
using System.Text;

namespace Scada.Controls
{
 
    public abstract class CodonBase
    {
        string codonName;

        public string CodonName
        {
            get { return codonName; }
            set { codonName = value; }
        }

        public CodonBase(string name)
        {
            codonName = name;
        }
    }
}
