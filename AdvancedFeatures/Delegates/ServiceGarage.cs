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