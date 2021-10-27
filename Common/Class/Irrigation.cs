using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class Irrigation
    {
        public TimeSpan IrrigationInterval { get; set; }

        public int IriggationStrenght { get; set; }

        public IList<DateTime> IrrigationTime { set; get; }
    }
}
