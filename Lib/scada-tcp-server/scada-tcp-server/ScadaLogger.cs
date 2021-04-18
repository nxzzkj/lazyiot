using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scada_tcp_server
{
    public interface ScadaLogger
    {
        ScadaLogManager CreateLogManager(Type type);
    }
}
