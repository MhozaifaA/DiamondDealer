using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Spot
    {
        public SpotTypes SpotTypes { get; set; }
        public string UrlImage { get; set; }
        public bool IsCurrentPostion { get; set; }
    }
}
