using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scada_udp_server
{
    public interface ScadaLogger
    {
        ScadaLogManager CreateLogManager(Type type);
    }
}
