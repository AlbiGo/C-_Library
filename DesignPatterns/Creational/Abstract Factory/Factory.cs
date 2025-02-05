using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Abstract_Factory
{
    public abstract class Factory
    {
        public abstract Animal CreateAnimal();
    }

    public class CarnivoreFactory : Factory
    {
        public override Animal CreateAnimal()
        {
            return new Wolf();
        }
    }

    public class HerbivorevoreFactory : Factory
    {
        public override Animal CreateAnimal()
        {
            return new Bison();
        }
    }

    public class Wolf : Animal
    {

    }

    public class Bison : Animal
    {

    }

    public class AnimalWorld
    {
        private HerbivorevoreFactory factory;
        private CarnivoreFactory _carnivoreFactory;

        public AnimalWorld(HerbivorevoreFactory herbivorevoreFactory, 
            CarnivoreFactory carnivoreFactory)
        {
            factory = herbivorevoreFactory;
            _carnivoreFactory = carnivoreFactory;
        }

        public void RunFoodChain()
        {
            var bison = factory.CreateAnimal();
            var wolf = _carnivoreFactory.CreateAnimal();

            Console.WriteLine(wolf.GetType().Name + " eats " + bison.GetType().Name);
        }
    }


    public abstract class Animal
    {
        public string? Name { get; set; }
        public AnimalType? Type { get; set; }
    }

    public enum AnimalType
    {
        None,
        Herbivore,
        Carnivore
    }

}
