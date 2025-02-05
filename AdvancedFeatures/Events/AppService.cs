using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Events
{
    public class AppService
    {
        public void OnTaskCreated(object source, EventArgs eventArgs)
        {
            Console.WriteLine("AppService: your task is created.");
        }

        public void OnTaskCompleted(object source, EventArgs eventArgs)
        {
            Console.WriteLine("App Servcie: Your task is completed.");
        }
    }
}
