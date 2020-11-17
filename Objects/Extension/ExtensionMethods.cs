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
            return $"image/model_{(int)model}.png";
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
    }
}
