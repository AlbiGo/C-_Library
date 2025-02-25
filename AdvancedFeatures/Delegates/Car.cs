namespace AdvancedFeatures.Delegates
{
    public class Car
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