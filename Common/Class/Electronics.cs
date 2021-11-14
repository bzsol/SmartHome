using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Electronics
    {
        public string EventName { get; set; }

        public DateTime EventTime { set; get; }

        public bool Continous { get; set; }


    }
}
