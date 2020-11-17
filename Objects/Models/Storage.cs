using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Storage:Dealer
    {
        public RollQueue<Item> Items;
        public Storage()
        {
            Items = new RollQueue<Item>(3);
        }

        public new Item Item => Items.FirstOrDefault();
        public new string Image { get; set; }
        public new bool IsItem => Items.Count!=0;


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
