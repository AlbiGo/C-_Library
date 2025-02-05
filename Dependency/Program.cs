// See https://aka.ms/new-console-template for more information
using Dependency.Concept;
using Dependency.Implementation;
using Math = Dependency.Implementation.Math;

Console.WriteLine("Hello, World!");
var controller = new EconomicsController();
controller.EconomicsCalc(new Math());

//var classC = new ClassC();
//classC.MethodA();
Console.WriteLine("---------------------------------------");
//classC.MethodA();
Console.ReadLine();


