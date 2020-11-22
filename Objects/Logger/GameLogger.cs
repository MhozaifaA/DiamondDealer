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

        public static void Log<T>(string message=null)
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
