using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Item
    {
        public ModelImages ModelImages { get; set; }
        public string Image => ModelImages.GetUrlImage();

        public int EqualPackage { get; init; } = -100;

    }
}
