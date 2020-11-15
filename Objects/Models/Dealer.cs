using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Dealer
    {
        public  Item Item { get; set; }
        public  string Image { get; set; }
        public bool IsCurrentPostion { get; set; }
        public bool IsItem => Item is not null;
    }
}
