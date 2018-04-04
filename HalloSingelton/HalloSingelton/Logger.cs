using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloSingleton
{
    public class Logger
    {
        private Logger() => instanceCounter++;

        private static int instanceCounter;
        private static Logger instance;
        private static Object _lockObject = new object();
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {   
                    //Multi threading save 
                    lock (_lockObject)
                    {
                        instance = new Logger();
                    }
                }
                return instance;
            }
        }

        public void Log(String message)
        {
            Console.WriteLine($"[{instanceCounter}] {DateTime.Now}: {message}");
        }
    }
}
