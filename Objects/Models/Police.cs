using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Police :Dealer
    {

        public new Item Item { get; set; }
        public new string Image { get; init; }

        public new bool IsItem => Item is not null;


        public Item ItemDealer
        {
            get => base.Item;
            set => base.Item = value;
        }
        public bool IsItemDealer => base.IsItem;

        public string ImageDealer
        {
            get => base.Image;
            set => base.Image = value;
        }


    }
}
