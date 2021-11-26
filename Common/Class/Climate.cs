using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Model.ExternalFactors;

namespace Common.Model
{
    public class Climate
    {
        public bool IsHeatingEnabled { get; set; }

        public bool IsCoolingEnabled { get; set; }

        public Modes Mode { get; set; }

        public int Level { get; set; }
    }
}
