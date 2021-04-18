using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.DBUtility
{
   public  class GUIDTo16
    {
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        public static long GuidToLongID(Guid GUID)
        {
            byte[] buffer = GUID.ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
