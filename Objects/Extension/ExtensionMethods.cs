using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public static class ExtensionMethods
    {
        public static T[,] InitializeArray<T>(this T[,] array) where T : new()
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = new T();
            GameLogger.Log<Objects.ConsoleLog>($"Done {nameof(InitializeArray)}");
            return array;
        }


        public static void PoliceAction(this Spot[,] spots, SpotTypes type)
        {
            Collection<Spot> spotsoftype = new Collection<Spot>();
            foreach (var spot in spots)
                if (spot.SpotTypes == type)
                    spotsoftype.Add(spot);

            var OnAction = spotsoftype.OrderBy(x => Guid.NewGuid()).First();

            if (type == SpotTypes.Factory) //factory
            {
                var factory = OnAction.Cast<Factory>();
                if (factory.IsItem)
                    factory.Item = default;
            }
            else // storage
            {
                var storage = OnAction.Cast<Storage>();
                if (storage.IsItem)
                    storage.Items.Dequeue();
            }
        }

        public static string GetUrlImage(this DealerImages dealer)
        {
            return $"image/dealer_{dealer.ToString().ToLower()}.png";
        }

        public static string GetUrlImage(this ModelImages model)
        {
            return (int)model switch
            {
                -1 => $"image/{ModelImages.Package.ToString().ToLower()}.png",
                >= 0 and <= 10 => $"image/model_{(int)model}.png",
                >= 100 and <= 123 => $"image/model_{(int)model}.png",
                _ => string.Empty
            };
        }

        public static string GetUrlImage(this ModelImages model, ModelImages color)
        {
            if ((int)model >= 3 && (int)model <= 10)
                throw new AggregateException(message: $"{model} is not as model");

            if ((int)color >= 0 && (int)color <= 2)
                throw new AggregateException(message: $"{color} is not as Color");

            return $"image/model_{(int)model}_{(int)color}.png";
        }

        public static ModelImages GetModelImages(this List<Item> items)
        {
            if (items.Count == 2)
            {
                //100 -  107 ,  108  - 115  , 116 - 123
                var list = items.Select(x => (int)x.ModelImages).OrderBy(x => x);
                int first = list.First(); // color
                int seound = list.Last(); // model 
                //1 
                return (ModelImages)((100 + (first * 8)) + seound - 3);
            }
            else
            {
                return items.First().ModelImages;
            }
        }

        public static bool IsFromTwoKind(ModelImages first, ModelImages secound)
        {
            if ((((int)first >= 3 && (int)first <= 10) && ((int)secound >= 0 && (int)secound <= 2)) ||
                (((int)secound >= 3 && (int)secound <= 10) && ((int)first >= 0 && (int)first <= 2)))
                return true;
            return false;
        }




        public static string GetUrlDealer(string key, string defaultimage = default)
        {
            return key switch
            {
                ("w" or "ص") => DealerImages.Top.GetUrlImage(),
                ("s" or "س") => DealerImages.Down.GetUrlImage(),
                ("a" or "ش") => DealerImages.Left.GetUrlImage(),
                ("d" or "ي") => DealerImages.Right.GetUrlImage(),
                " " or _ => defaultimage,
            };
        }

        public static (int X, int Y) GetNextPosstion(ref this (int X, int Y) postion, string key, int rows, int columns)
        {
            GameLogger.Log<Objects.ConsoleLog>($"{nameof(GetNextPosstion)} postion: [{postion}]");

            return key switch
            {
                ("w" or "ص") when postion.X != 0 => (--postion.X, postion.Y),
                ("s" or "س") when postion.X != rows - 1 => (++postion.X, postion.Y),
                ("a" or "ش") when postion.Y != 0 => (postion.X, --postion.Y),
                ("d" or "ي") when postion.Y != columns - 1 => (postion.X, ++postion.Y),
                " " or _ => (postion.X, postion.Y)
            };
        }



        public static T Cast<T>(this Spot spot) =>
             (T)spot.Content;

        public static T Cast<T>(this object obj) =>
          (T)obj;

        public static dynamic CustomeCast(this Spot spot, SpotTypes type) =>
            type switch
            {
                SpotTypes.Dealer => (Dealer)spot.Content,
                SpotTypes.CrystalMine => (CrystalMine)spot.Content,
                SpotTypes.Factory => (Factory)spot.Content,
                _ => (Dealer)spot.Content
            };


        public static void EnableSpace(this Spot siteOld , string key)
        {
            if (key != " ")
                return;

            GameLogger.Log<Objects.ConsoleLog>($"{nameof(EnableSpace)} :SpotTypes [{siteOld.SpotTypes}]");


            if (siteOld.SpotTypes == SpotTypes.CrystalMine)
            {
                var _Crystal = siteOld.Cast<CrystalMine>();
                if (_Crystal.IsItem && !_Crystal.IsItemDealer)
                {
                    _Crystal.ItemDealer = _Crystal.Item;
                    _Crystal.Item = default;
                    _Crystal.Work();
                }
            }
            else if (siteOld.SpotTypes == SpotTypes.Factory)
            {
                var _Crystal = siteOld.Cast<Factory>();
                if (_Crystal.IsItemDealer && !_Crystal.IsItem)
                {
                    if (_Crystal.TryAddToItems(_Crystal.ItemDealer))
                    {
                        _Crystal.ItemDealer = default;
                    }
                }
                else if (!_Crystal.IsItemDealer && _Crystal.IsItem)
                {
                    _Crystal.ItemDealer = _Crystal.Item;
                    _Crystal.Item = default;
                }
            }
            else if (siteOld.SpotTypes == SpotTypes.Storage)
            {
                var _Crystal = siteOld.Cast<Storage>();
                if (_Crystal.IsItemDealer)
                {
                    _Crystal.Items.Add(_Crystal.ItemDealer);
                    _Crystal.ItemDealer = default;
                }
                else if (_Crystal.IsItem)
                {
                    _Crystal.ItemDealer = _Crystal.Items.Dequeue();
                }
            }
            else if (siteOld.SpotTypes == SpotTypes.Customer)
            {
                var _Customer = siteOld.Cast<Customer>();
                if (_Customer.IsItemDealer && _Customer.IsItem)
                {
                    if (_Customer.TryAddToItems(_Customer.ItemDealer))
                    {
                        _Customer.ItemDealer = default;
                    }
                }
            }

        }


        public static double NextSecound(this Random random, double minimum, double maximum)
        {
            return (random.NextDouble() * (maximum - minimum) + minimum) * 1000;
        }

        public static ModelImages RandomColor(this Random random)
        {
            return (ModelImages)random.Next(0, 3);
        }

        public static ModelImages RandomModel(this Random random)
        {
            return (ModelImages)random.Next(3, 11);
        }

        public static ModelImages RandomDiamond(this Random random)
        {
            return (ModelImages)random.Next(100, 124);
        }

        public static SpotTypes RandomSpot(this Random random)
        {
            return (SpotTypes)random.Next((int)SpotTypes.Factory, (int)SpotTypes.Storage + 1);
        }

        public static T FirstOrDefault<T>(this Queue<T> queue)
        {
            if (queue.TryPeek(out T item))
                return item;
            return default;
        }
    }
}
