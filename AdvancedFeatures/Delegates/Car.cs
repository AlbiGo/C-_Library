using CarServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Delegates
{
    public class Car : IEntity
    {
        public string Name { get; set; }
        public static Car LoadCar()
        {
            return new Car(); 
        }

        public void Deliver()
        {
            Console.WriteLine($"{this.Name} all services done");
        }
    }
}
