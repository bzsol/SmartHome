using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class Electronics
    {
        public IList<String> Event { get; set; }

        public IList<DateTime> EventTime { set; get; }

        public bool Continous { get; set; }

        public enum ElectronicsType { TV, Radio };

        public ElectronicsType ElectronicType { get; set; }
    }
}
