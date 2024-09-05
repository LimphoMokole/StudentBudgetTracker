using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectPRJ271
{
    public class DataSaver
    {
        private Thread _thread;
        private Budget _budget;

        public DataSaver(Budget budget)
        {
            _budget = budget;
            _thread = new Thread(SaveDataPeriodically);
        }

        public void Start()
        {
            _thread.Start();
        }

        private void SaveDataPeriodically()
        {
            while (true)
            {
              
                Console.WriteLine("Saving data...");
                Thread.Sleep(60000); 
            }
        }
    }
}
