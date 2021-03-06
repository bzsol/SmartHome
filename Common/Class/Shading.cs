using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Model.ExternalFactors;

namespace Common.Model
{
    public class Shading
    {
        public string Place { get; set; }
        public int Level { get; set; }
        public int State { get; set; }
        public DateTime Date { get; set; }
        public ShadePreference ShadePreference { get; set; }
        public int Photosensitivity { get; set; }
    }
}
