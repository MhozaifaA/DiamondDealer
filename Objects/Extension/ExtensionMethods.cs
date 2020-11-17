using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public static class ExtensionMethods
    {
        public static T[,] InitializeArray<T>(this T[,]  array) where T : new()
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i,j] = new T();
            return array;
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
                >=0 and <=10 => $"image/model_{(int)model}.png",
                >= 100 and <= 123 => $"image/model_{(int)model}.png",
                _ => string.Empty
            };
        }

        public static string GetUrlImage(this ModelImages model,  ModelImages color)
        {
            if ((int)model >= 3 && (int)model <= 10)
                throw new AggregateException(message: $"{model} is not as model");

            if ((int)color >= 0 && (int)color <=2)
                throw new AggregateException(message:$"{color} is not as Color");

            return $"image/model_{(int)model}_{(int)color}.png";
        }

        public static ModelImages GetModelImages(this List<Item> items)
        {
            if (items.Count==2)
            {
                //100 -  107 ,  108  - 115  , 116 - 123
                var list = items.Select(x => (int)x.ModelImages).OrderBy(x => x);
                int first = list.First(); // color
                int seound = list.Last(); // model 

                return (ModelImages)((100 + (first * 8)) + seound - 3);
            }else
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




        public static string GetUrlDealer(string key, string defaultimage=default)
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



        public static T Cast<T>(this Spot spot) =>
             (T)spot.Content;

        public static T Cast<T>(this object obj) =>
          (T)obj;

        public static dynamic CustomeCast(this Spot spot, SpotTypes type) =>
            type switch {
                SpotTypes.Dealer=> (Dealer)spot.Content,
                SpotTypes.CrystalMine => (CrystalMine)spot.Content,
                SpotTypes.Factory => (Factory)spot.Content,
                _ => (Dealer)spot.Content
            };


        public static double NextSecound(this Random random, double minimum, double maximum)
        {
            return (random.NextDouble() * (maximum - minimum) + minimum)*1000;
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

        public static T FirstOrDefault<T>(this Queue<T> queue )
        {
            if (queue.TryPeek(out T item))
                return item;
            return default;
        }
    }
}
