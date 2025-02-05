using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Events
{
    public class EconomicsService
    {
        public void OnRatesUpdated(object source, EventArgs eventArgs)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Economics Recalculated");
        }
    }
}
