using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace DiamondDealer.Objects
{
    public class CrystalMine : Dealer
    {
        public CrystalMine()
        {
            //Timer s =new Timer((o)=> { Console.WriteLine($"Im{DateTime.Now.Second}"); }, null,100,1); 

            //System.Timers.Timer timer = new System.Timers.Timer(1000);
            //timer.Elapsed  += (e, s) => {
            //    Console.WriteLine($"Im{DateTime.Now.Second}");
            //};
            //timer.Start();
        }
        public new Item Item { get; set; }
        public new string Image { get; set; }

      
        public Item ItemDealer
        {
            get => base.Item; 
            set => base.Item= value;
        }

        public string ImageDealer
        {
            get => base.Image;
            set => base.Image = value;
        }

    }
}
