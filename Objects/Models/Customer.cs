using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class Customer:Dealer
    {
        public Queue<Item> Items;

        private readonly Timer timer;
        private Random random;


        public Customer()
        {
            random = new Random();
            Items = new Queue<Item>();

            timer = new Timer((o)=> {

                var diamond = random.RandomDiamond();
                Items.Enqueue(new Item()
                {
                    ModelImages = diamond,
                    EqualPackage = (int)diamond
                });
                timer.Change( (int)random.NextSecound(5, 20) , Timeout.Infinite);

                GameLogger.Log<Objects.ConsoleLog>($"{nameof(Customer)}  ,  ModelImages: {Item.ModelImages} , EqualPackage: {Item.EqualPackage}");


            }, null,(int)random.NextSecound(1, 3) , Timeout.Infinite);

        }

        public bool TryAddToItems(Item item)
        {

            if (Item is not null && item.ModelImages==ModelImages.Package &&  Item.EqualPackage == item.EqualPackage)
            {
                Items.Dequeue();

                GameLogger.Log<Objects.ConsoleLog>($"{nameof(TryAddToItems)} Dequeue");

                return true;
            }

            return false;
        }

        public new Item Item => Items.FirstOrDefault();
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
