using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Liskov
{
    public class Animal
    {
        public virtual void Moves()
        {
            Console.WriteLine("Animal moves");
        }
    }

    public class Bird : Animal
    {
        public override void Moves()
        {
            Console.WriteLine("Bird Flies");
        }
    }

    public class Fish : Animal
    {
        public override void Moves()
        {
            Console.WriteLine("Fish swims");
        }
    }

    public class Habitat
    {
        public void MakeAnimalMove(Animal animal)
        {
            animal.Moves();
        }
    }

}
