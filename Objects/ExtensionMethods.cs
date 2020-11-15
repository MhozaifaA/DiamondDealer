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
    }
}
