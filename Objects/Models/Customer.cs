using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Customer:Dealer
    {
        Queue<Item> Items;
        public Customer()
        {
            Items = new Queue<Item>();
        }

        public new Item Item => null;
        public new string Image { get; set; }
        public new bool IsItem => Items.Count != 0;


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
