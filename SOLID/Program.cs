// See https://aka.ms/new-console-template for more information
using SOLID.Interface_Segregation;
using SOLID.Liskov;

Console.WriteLine("Hello, World!");

//Habitat habitat = new Habitat();
//habitat.MakeAnimalMove(new Animal());
//habitat.MakeAnimalMove(new Fish());
//habitat.MakeAnimalMove(new Bird());

IBaseClassA iBaseClassA = new BaseClass();
iBaseClassA.MethodA();
IBaseClassB iBaseClassB = new BaseClass();
iBaseClassB.MethodB();

