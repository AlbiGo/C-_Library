using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarServices;
using static AdvancedFeatures.Delegates.ServiceGarage;

namespace AdvancedFeatures.Delegates
{
    public class ServiceGarage
    {
        public delegate void CarServiceDelegate();
        private Car _car;

        public ServiceGarage(Car car)
        {
            _car = car;
        }

        public void DoService(CarServiceDelegate carServiceDelegate)
        {
            //Do service
            // carServiceDelegate(car);
            carServiceDelegate();

            //Deliver after service
            _car.Deliver();
        }
    }
}
