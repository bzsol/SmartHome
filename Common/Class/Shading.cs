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
        public int Level { get; set; }
        public string Date { get; set; }
        public ShadePreference ShadePreference { get; set; }
        public int Photosensitivity { get; set; }
    }
}
