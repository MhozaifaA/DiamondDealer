using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public sealed class Board
    {
        public static void Initialize(Spot[,] Board, Action action)
        {

            #region -   Dealer   -

            var initDealer = Board[Board.GetLength(0) - 1, Board.GetLength(1) / 2];
            initDealer.SpotTypes = SpotTypes.Dealer;
            initDealer.Content = new Dealer()
            {
                Image = DealerImages.Top.GetUrlImage(),
                IsCurrentPostion = true,
            };

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Dealer} at row-1 col/2");

            #endregion


            #region -   CrystalMine   -



            var spot = Board[2, 0];
            spot.SpotTypes = SpotTypes.CrystalMine;
            var _CrystalMine = new CrystalMine("Model")
            {
                Image = "/image/crystalminemodel.png",
            };
            _CrystalMine.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = _CrystalMine;

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.CrystalMine} model at [2,0]");


            //color
            spot = Board[3, 0];
            spot.SpotTypes = SpotTypes.CrystalMine;
             _CrystalMine = new CrystalMine("Color")
            {
                Image = "/image/crystalminecolor.png",
            };
            _CrystalMine.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = _CrystalMine;


            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.CrystalMine} color at [3,0]");



            spot = Board[4, 0];
            spot.SpotTypes = SpotTypes.CrystalMine;
            _CrystalMine = new CrystalMine("Model")
            {
                Image = "/image/crystalminemodel.png",
            };
            _CrystalMine.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = _CrystalMine;


            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.CrystalMine} model at [4,0]");



            #endregion


            #region -   Factory   -
            

            spot = Board[1, 4];
            spot.SpotTypes = SpotTypes.Factory;
            var factory = new Factory("Factory")
            {
                Image = "/image/factory.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Factory} Factory at [1,4]");



            spot = Board[2, 4];
            spot.SpotTypes = SpotTypes.Factory;
            factory = new Factory("Factory")
            {
                Image = "/image/factory.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Factory} Factory at [2,4]");


            spot = Board[3, 4];
            spot.SpotTypes = SpotTypes.Factory;
            factory = new Factory("Factory")
            {
                Image = "/image/factory.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Factory} Factory at [3,4]");



            spot = Board[4, 4];
            spot.SpotTypes = SpotTypes.Factory;
            factory = new Factory("Packaging")
            {
                Image = "/image/packaging.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Factory} Packaging at [4,4]");


            spot = Board[5, 4];
            spot.SpotTypes = SpotTypes.Factory;
            factory = new Factory("Packaging")
            {
                Image = "/image/packaging.png",
            };
            factory.PropertyChanged += (o, e) => { action.Invoke(); };
            spot.Content = factory;


            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Factory} Packaging at [5,4]");


            #endregion



            spot = Board[6, 0];
            spot.SpotTypes = SpotTypes.Storage;
            spot.Content = new Storage()
            {
                Image = "/image/storage.png",
            };

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Storage} at [6,0]");


            spot = Board[0, 2];
            spot.SpotTypes = SpotTypes.Customer;
            spot.Content = new Customer()
            {
                Image = "/image/customer.png",
            };

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Customer} at [0,2]");



            spot = Board[1, 0];
            spot.SpotTypes = SpotTypes.Police;
            var _police= new Police()
            {
                Image = "/image/police.png",
            };
            _police.OnPolice += (type) =>
            {
                Console.WriteLine(type);
                Board.PoliceAction(type);
                action.Invoke();
            };
            spot.Content = _police;


            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Police} at [1,0]");


            spot = Board[6, 4];
            spot.SpotTypes = SpotTypes.Calculator;
            spot.Content = new Calculator()
            {
                Image = "/image/calculator.png",
            };

            GameLogger.Log<Objects.ConsoleLog>($"Init {SpotTypes.Calculator} at [6,4]");


            GameLogger.Log<Objects.ConsoleLog>($"Done {nameof(Initialize)}");

        }
    }
}
