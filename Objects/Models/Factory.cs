using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Factory:Dealer
    {
        public new List<Item> Item { get; set; }
        public new string Image { get; set; }


        public Item ItemDealer
        {
            get => base.Item;
            set => base.Item = value;
        }

        public string ImageDealer
        {
            get => base.Image;
            set => base.Image = value;
        }
    }
}
