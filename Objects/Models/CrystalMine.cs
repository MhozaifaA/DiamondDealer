﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Timers;

namespace DiamondDealer.Objects
{
    public class CrystalMine : Dealer, INotifyPropertyChanged
    {

        private Timer timer;
        private Random random;

        //kind: CrystalMine Model  ,  kind: CrystalMine Color
        public CrystalMine(string kind)
        {
            timer = new Timer();
            random = new Random();
            timer.AutoReset = false;

            switch (kind)
            {
                case "Model":
                    timer.Interval = random.NextSecound(1, 5);
                    timer.Elapsed += (o, e) =>
                    {
                        Item = new Item()
                        {
                            ModelImages = random.RandomModel()
                        };
                        timer.Stop();
                        timer.Interval = random.NextSecound(1, 5);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item)));
                    };
                    break;

                case "Color":
                    timer.Interval = random.NextSecound(1, 3);
                    timer.Elapsed += (o, e) =>
                    {
                        Item = new Item()
                        {
                            ModelImages = random.RandomColor()
                        };
                        timer.Stop();
                        timer.Interval = random.NextSecound(1, 3);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item)));
                    };
                    break;

                default:
                    break;
            }

            timer.Start();
            //Timer s =new Timer((o)=> { Console.WriteLine($"Im{DateTime.Now.Second}"); }, null,100,1); 
        }

        public void Work() => timer.Enabled = true;
     

        public new Item Item { get; set; }
        public new string Image { get; set; }

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

        // public event Action OnItem;

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
