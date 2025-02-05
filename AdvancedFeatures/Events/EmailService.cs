using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Events
{
    public class EmailService
    {
        public void OnTaskCreated(object source, EventArgs eventArgs)
        {
            Console.WriteLine("Email Servcie: Email sent 'Your task is created'.");
        }

        public void OnTaskCompleted(object source, EventArgs eventArgs)
        {
            Console.WriteLine("Email Servcie: Email sent 'Your task is completed'.");
        }
    }
}
