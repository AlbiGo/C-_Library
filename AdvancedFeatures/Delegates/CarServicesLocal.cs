using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Delegates
{
    public class CarServicesLocal
    {
        private readonly Car _car;
        public CarServicesLocal(Car car)
        {
            _car = car;
        }

        public void OilChange() 
        {
            Console.WriteLine($"{_car.Name} oil changed");
        }

        public void TireChange()
        {
            Console.WriteLine($"{_car.Name} tires changed");
        }

        public void EngineService()
        {
            Console.WriteLine($"{_car.Name} engine serviced");
        }
    }
}
