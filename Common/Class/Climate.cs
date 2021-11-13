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
        public bool isHeatingEnabled { get; set; }

        public Modes mode { get; set; }

        public int level { get; set; }
    }
}
