using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public sealed class Board
    {
        public static void Initialize(ref Spot[,] Board, Action action)
        {
            var initDealer = Board[Board.GetLength(0) - 1, Board.GetLength(1) / 2];
            initDealer.SpotTypes = SpotTypes.Dealer;
            initDealer.Content = new Dealer()
            {
                Image = DealerImages.Top.GetUrlImage(),
                IsCurrentPostion = true,

            };

            var spot = Board[4, 0];
            spot.SpotTypes = SpotTypes.CrystalMine;
            var _CrystalMine= new CrystalMine("Model")
            {
                Image = "/image/crystalminemodel.png",
            };
            _CrystalMine.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = _CrystalMine;

            //color
            spot = Board[3, 0];
            spot.SpotTypes = SpotTypes.CrystalMine;
             _CrystalMine = new CrystalMine("Color")
            {
                Image = "/image/crystalminecolor.png",
            };
            _CrystalMine.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = _CrystalMine;

            spot = Board[2, 0];
            spot.SpotTypes = SpotTypes.CrystalMine;
            _CrystalMine = new CrystalMine("Model")
            {
                Image = "/image/crystalminemodel.png",
            };
            _CrystalMine.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = _CrystalMine;



            spot = Board[2, 4];
            spot.SpotTypes = SpotTypes.Factory;
            var factory = new Factory("Factory")
            {
                Image = "/image/factory.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;

            spot = Board[3, 4];
            spot.SpotTypes = SpotTypes.Factory;
            factory = new Factory("Factory")
            {
                Image = "/image/factory.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;


            spot = Board[4, 4];
            spot.SpotTypes = SpotTypes.Factory;
            factory = new Factory("Packaging")
            {
                Image = "/image/packaging.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;


            spot = Board[6, 0];
            spot.SpotTypes = SpotTypes.Storage;
            spot.Content = new Storage()
            {
                Image = "/image/storage.png",
            };


            spot = Board[0, 2];
            spot.SpotTypes = SpotTypes.Customer;
            spot.Content = new Customer()
            {
                Image = "/image/customer.png",
            };


            spot = Board[1, 0];
            spot.SpotTypes = SpotTypes.Police;
            spot.Content = new Police()
            {
                Image = "/image/police.png",
            };


            spot = Board[6, 4];
            spot.SpotTypes = SpotTypes.Calculator;
            spot.Content = new Calculator()
            {
                Image = "/image/calculator.png",
            };

        }
    }
}
