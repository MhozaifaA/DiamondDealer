using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace DiamondDealer.Objects
{
    public class CrystalMine : Dealer
    {
        //kind: CrystalMine Model  ,  kind: CrystalMine Color
        public CrystalMine(string kind)
        {
            //Timer s =new Timer((o)=> { Console.WriteLine($"Im{DateTime.Now.Second}"); }, null,100,1); 

            //System.Timers.Timer timer = new System.Timers.Timer(2000);
            //timer.Elapsed  += (e, s) => {
            //    Item = new Item()
            //    {
            //        ModelImages = ModelImages.Ten,
            //    };
            //  //  OnItem.Invoke(5);
            //  //  Console.WriteLine(10);
            //};
            //timer.AutoReset = false;
            //timer.Start();
        }
        public new Item Item { get; set; }
        public new string Image { get; set; }

        public new bool IsItem => Item is not null;


        public Item ItemDealer
        {
            get => base.Item; 
            set => base.Item= value;
        }
        public  bool IsItemDealer => base.IsItem;

        public string ImageDealer
        {
            get => base.Image;
            set => base.Image = value;
        }

        public event Action OnItem;
        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
