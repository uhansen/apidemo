using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidemo.core.Gateways
{
    public interface IAirpressureGateway
    {
        double GetAirPressureBasesOnPosition(double x, double y);
    }
}
