using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Events
{
    public class RatesService
    {
        //Rates updated
        public delegate void RatesUpdatedEventHandler(object source, EventArgs args);
        public event RatesUpdatedEventHandler RatesUpdated;
        public void UpdateRates(decimal rate, int entityID)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Rates Updated");
            OnRatesUpdated(entityID);
        }

        protected virtual void OnRatesUpdated(int entityID)
        {
            Console.WriteLine("Task completed;");
            if (RatesUpdated != null)
                RatesUpdated(this, null);
        }
    }
}
