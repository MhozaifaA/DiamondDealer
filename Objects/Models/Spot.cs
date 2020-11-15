using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Spot
    {
        public SpotTypes SpotTypes { get; set; }
        public object Content { get; set; } // Dealer ,Factory ,
        public bool IsContent => Content is not null;
    }
}
