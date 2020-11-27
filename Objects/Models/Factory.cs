using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace DiamondDealer.Objects
{
    public class Factory:Dealer, INotifyPropertyChanged
    {
        private Timer timer;
        private Random random;
        private int CapacityIn;
        private readonly string Key;
        // kind  Factory , Packaging
        public Factory(string kind)
        {
            Key = $"{nameof(Factory)}{GameLogger.Factory}";

            timer = new Timer();
            random = new Random();
           // timer.AutoReset = false;

            switch (kind)
            {
                case "Factory":
                    CapacityIn = 2;
                    InItems = new List<Item>(CapacityIn);

                    timer.Interval = random.NextSecound(1, 5);
                    timer.Elapsed += (o, e) =>
                    {
                        Item = new Item()
                        {
                            ModelImages = InItems.GetModelImages()
                        };
                        timer.Stop();
                        timer.Interval = random.NextSecound(1, 5);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item)));
                        InItems.Clear();

                        GameLogger.Log<Objects.ConsoleLog>($"{nameof(Factory)} Type: {kind} , Interval:  {timer.Interval} , ModelImages: {Item.ModelImages}");


                    };

                    break;

                case "Packaging":
                    CapacityIn = 1;
                    InItems = new List<Item>(CapacityIn);

                    timer.Interval = random.NextSecound(1, 3);
                    timer.Elapsed += (o, e) =>
                    {
                        Item = new Item()
                        {
                            ModelImages = ModelImages.Package,
                            EqualPackage= (int)InItems.GetModelImages()
                        };
                        timer.Stop();
                        timer.Interval = random.NextSecound(1, 3);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item)));
                        InItems.Clear();

                        GameLogger.Log<Objects.ConsoleLog>($"{nameof(Factory)} Type: {kind} , Interval:  {timer.Interval} , ModelImages: {Item.ModelImages}");

                    };

                    break;

                default:
                    break;
            }
        }

        private void Work() {
            if (IsInItems)
            {
             timer.Enabled = true;
            }
        }
        public bool TryAddToItems(Item item)
        {
            if (!IsInItems)
            {
                if (CapacityIn==2) // factory
                {
                    var first = InItems.FirstOrDefault();
                    if ((item.ModelImages != ModelImages.Package && (int)item.ModelImages <100) && ((first is null) || (ExtensionMethods.IsFromTwoKind(first.ModelImages, item.ModelImages))))
                    {
                        InItems.Add(item);
                        Work();

                        GameLogger.Log<Objects.ConsoleLog>($"{nameof(TryAddToItems)} Type: {"factory"} , Add {item.ModelImages} and Work");


                        return true;
                    }
                }
                else
                {
                    if ((int)item.ModelImages >= 100)
                    {
                        InItems.Add(item);
                        Work();

                        GameLogger.Log<Objects.ConsoleLog>($"{nameof(TryAddToItems)} Type: {"pagcking"} , Add {item.ModelImages} and Work");

                        return true;
                    }
                }
            }
            return false;
        }


        private Item _Item;
        public new Item Item
        {
            get => _Item;
            set { _Item = value;
                GameLogger.WriteOperations(Key, ((int)(_Item?.ModelImages ?? 0)!=-1?((int)(_Item?.ModelImages ?? 0)) :((int)(_Item?.EqualPackage ?? 0)) ) );}
        }



        public new string Image { get; init; }
        public new bool IsItem => Item is not null;


        public List<Item> InItems;
        public  bool IsInItems => InItems.Count==CapacityIn;



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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
