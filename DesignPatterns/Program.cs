using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Creational.Builder;
using DesignPatterns.Creational.Singleton;

Console.WriteLine("---------------------------------------");

//TestSingleton("Test1");
//TestSingleton("Test2");

//Thread process1 = new Thread(() =>
//{
//    TestSingleton("FOO");
//});
//Thread process2 = new Thread(() =>
//{
//    TestSingleton("BAR");
//});

//process1.Start();
//process2.Start();

//process1.Join();
//process2.Join();
//static void TestSingleton(string value)
//{
//    Singleton singleton = Singleton.GetInstance(value);
//    Console.WriteLine(singleton.Value);
//}

//var shop = new Shop();
//var carBuilder = new CarBuilder();
//shop.Construct(carBuilder);
//var car = carBuilder.GetVehicle();
//car.PrintParts();

var taxServiceContext = new TaxCalculateContext(new CalculateTaxPERC());
taxServiceContext.Calculate();