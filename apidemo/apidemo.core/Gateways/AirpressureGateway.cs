using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidemo.core.Gateways
{
    public class AirpressureGateway : IAirpressureGateway
    {
        public double GetAirPressureBasesOnPosition(double x, double y)
        {
            return 1004.0;
        }
    }
}
