using AdvancedFeatures.Delegates;
using AdvancedFeatures.Linq;

internal delegate int myDelegate(int a, int b);

public static class Ex
{
    public static bool EnumerableContains<S, T>(this IEnumerable<S> obj, Func<S, T> comparer, T valueToMatch)
    {
        return obj.Any(l => comparer(l).Equals(valueToMatch));
    }
}

public class CarServiceExtension
{
    private readonly Car _car;

    public CarServiceExtension(Car car)
    {
        _car = car;
    }

    public void TransmissionService()
    {
        Console.WriteLine(_car.Name + " transmission serviced");
    }
}

public class Calc
{
    private int Sum(int a, int b)
    {
        return a + b;
    }

    private int Multiply(int a, int b)
    {
        return a * b;
    }

    public void DoAllOps(int a, int b)
    {
        Console.WriteLine(Sum(a, b));
        Console.WriteLine(Multiply(a, b));
    }
}

public delegate void CalculatorDelegate(int a, int b);

internal class Program
{
    private static void Main()
    {
        #region Delegates

        //var delegateObject = new DelegateClass();
        //var d = new myDelegate(delegateObject.DoWork);
        //int result = d(5, 6);

        //Console.WriteLine(result);
        //var car = new Car()
        //{
        //    Name = "Evo",
        //};

        //var services = new CarServices<Car>(car);
        //var serviceGarage = new ServiceGarage(car);
        //ServiceGarage.CarServiceDelegate carServiceDelegate = services.EngineService;
        //carServiceDelegate += services.TireChange;
        //var carServiceExtension = new CarServiceExtension(car);
        //carServiceDelegate += carServiceExtension.TransmissionService;

        //serviceGarage.DoService(carServiceDelegate);

        var calc = new Calc();
        CalculatorDelegate calcDelegate = calc.DoAllOps;

        calcDelegate(3, 6);

        #endregion Delegates

        #region Events

        //var taskService = new TaskService();
        //var appService = new AppService();
        //var mailService = new EmailService();

        //taskService.TaskCreated += appService.OnTaskCreated;
        //taskService.TaskCreated += mailService.OnTaskCreated;
        //taskService.TaskCompleted += appService.OnTaskCompleted;
        //taskService.TaskCompleted += mailService.OnTaskCompleted;

        //taskService.PrepareTask(new AdvancedFeatures.Events.Task() { Title = "Write SQL Store Procedure" });
        //Console.WriteLine("-----------------------------------------------------------------------------------------------");
        //taskService.CompleteTask(new AdvancedFeatures.Events.Task() { Title = "Write SQL Store Procedure" });

        //var ratesService = new RatesService();
        //var economicsService = new EconomicsService();

        //ratesService.RatesUpdated += economicsService.OnRatesUpdated;

        //ratesService.UpdateRates(20, 3);

        //var obj = new List<Person> { new Person { ID = 1, Name = "Arunava" }, new Person { ID = 2, Name = "Bubu" } };
        //bool res = obj.EnumerableContains(data => data.Name, "Bubu");
        //Console.WriteLine(res); // Outputs "True"

        #endregion Events

        #region Expression Trees

        //Func<int, int, int> sum1 = (int number1, int number2) => number1 + number2;
        //var sum = (ExpressionTrees.CreateExpressionTreeFromLambdaExpression()).Compile();
        ////Console.WriteLine(sum(5, 7));

        //Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
        //Expression<Action<Student>> printStudentName = s => Console.WriteLine(s.StudentName);
        //Action<Student> printStudentNameAc = s => Console.WriteLine(s.StudentName);

        //isTeenAgerExpr = s => s.Age > 12 && s.Age < 25 && s.StudentName.Contains("Al");

        //var stList = new List<Student>()
        //{
        //    new()
        //    {
        //        Age = 23,
        //        StudentID = 1,
        //        StudentName = "Albus",
        //        Email = "Albus@gmail.com"

        // }, new() { Age = 13, StudentID = 2, StudentName = "Donus", Email = "Donus@gmail.com"

        // }, new() { Age = 45, StudentID = 4, StudentName = "Xhonus", Email = "Xhonus@gmail.com"

        //    }
        //}.AsQueryable();

        //var studentFilter = new StudentFilter()
        //{
        //    Age = 20,
        //    Email = "Xhonus@gmail.com"
        //};

        ////var filterEx = ExpressionTrees.CreateExpressionTreeFromFilter(studentFilter);

        //var studentList = stList.InlineFilter(studentFilter)
        //    .ToList();

        //studentList.ForEach(printStudentName.Compile());

        #endregion Expression Trees

        #region LINQ

        var myLst = new List<int>();
        myLst.Add(1);
        myLst.Add(-11);
        myLst.Add(-2);
        myLst.Add(4);

        var linqResult = myLst.WherePositive(p => p > 0)
            .ToList();

        linqResult.ForEach(p => Console.WriteLine(p));

        #endregion LINQ

        Console.ReadLine();
    }

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}