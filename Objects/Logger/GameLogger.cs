using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondDealer.Objects
{
    public class GameLogger
    {
        public static bool IsEnableConsole = true;
        public static bool IsEnablePetri = true;
        public static Action<Type> OnLogger;
        public static ObservableCollection<ConsoleLog> ConsoleLogs= new ObservableCollection<ConsoleLog>();
        public static ObservableCollection<PetriLog> PetriLogs = new ObservableCollection<PetriLog>();


       
        private static int _CrystalMine=0;
        public static int CrystalMine 
        {
            get {return ++_CrystalMine; }
        }

        private static int _Factory = 0;
        public static int Factory
        {
            get {return ++_Factory; }
        }

        public static Dictionary<string,int> Operations = new Dictionary<string, int>
        {
            ["CrystalMine1"] =0,
            ["CrystalMine2"] = 0,
            ["CrystalMine3"] = 0,
            ["Factory1"] = 0,
            ["Factory2"] = 0,
            ["Factory3"] = 0,
            ["Factory4"] = 0,
            ["Factory5"] = 0,
            ["Customer"] = 0,
        };

        private static Func<string, string> Brakts = (s) => $"M [ {s} ]";

        public static string GetOperations()=> Brakts(String.Join(" , ",Operations.Keys));

        public static void WriteOperations(string key , int value) {
            Operations[key] = value;
           Log<Objects.PetriLog>(Brakts(String.Join(" , ", Operations.Values)));
        }

        public static void WriteOperations()
        {
            Log<Objects.PetriLog>(Brakts(String.Join(" , ", Operations.Values)));
        }

        public static void Log<T>(string message=null) where T: new()
        {
            if (!IsEnableConsole && !IsEnablePetri)
                return;

            if (typeof(T)==typeof(ConsoleLog))
            {
                if (!IsEnableConsole)
                    return;
                ConsoleLogs.Insert(0, new Objects.ConsoleLog() { Message = message });
                OnLogger?.Invoke(typeof(T));
            }
            else if (typeof(T) == typeof(PetriLog))
            {
                if (!IsEnablePetri)
                    return;
                PetriLogs.Insert(0, new Objects.PetriLog() { Message = message });
                OnLogger?.Invoke(typeof(T));
            }
        }

    }
}
