using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    [Flags]
    public enum SpotTypes
    {
        Spot,
        Dealer,
        CrystalMine,
        Factory,
        Storage,
        Customer,
        Police,
        Calculator
    }
}
