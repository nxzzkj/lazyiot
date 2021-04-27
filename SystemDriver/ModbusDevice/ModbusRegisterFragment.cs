using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusDevice
{
    public class ModbusRegisterFragment
    {
        public int StartRegister = 0;
        //一次最小读取8个单元
        public int RegisterNum = 8;
    }
    public class ModbusStore
    {
        public string StoredCode = "";
        public List<ModbusRegisterFragment> Fragments = new List<ModbusRegisterFragment>();
        public List<int> Units = new List<int>();
        public void MakeFragment()
        {
            for (int i = 0; i < Units.Count; i++)
            {
                int temp = Units[i];
                int j = i;
                while ((j > 0) && (Units[j - 1] > temp))
                {
                    Units[j] = Units[j - 1];
                    --j;
                }
                Units[j] = temp;
            }
            Fragments = new List<ModbusRegisterFragment>();
            ModbusRegisterFragment fragment = null;
            bool iscreate = true;
            for (int i = 0; i < Units.Count; i++)
            {
                if (iscreate)
                {
                    fragment = new ModbusRegisterFragment();
                    fragment.StartRegister = Units[i];
                    Fragments.Add(fragment);
                    iscreate = false;
                }
                else
                {
                    int num = Units[i] - fragment.StartRegister + 9;
                    int num2 = Units[i - 1] - fragment.StartRegister + 9;
                    if (num >= 123)
                    {
                        if (num == 123)
                        {
                            fragment.RegisterNum = num;
                        }
                        else if (num2 <= 123)
                        {
                            fragment.RegisterNum = num2;
                            i--;

                        }
                        iscreate = true;
                    }
                    else
                    {
                        fragment.RegisterNum = num;
                        iscreate = false;
                    }

                }

            }
        }
    }

}
