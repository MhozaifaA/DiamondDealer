using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Item
    {
        public ModelImages ModelImages { get; set; }
        public string Image => $"/image/model_{(int)ModelImages}.png";
    }
}
