using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Factory:Dealer
    {
        // kind  Factory , Packaging
        public Factory(string kind)
        {

        }

        public new Item Item { get; set; }
        public new string Image { get; set; }
        public new bool IsItem => Item is not null;


        public List<Item> InItems { get; set; } = new List<Item>(2);



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
