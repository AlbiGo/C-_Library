namespace Dependency.Concept
{
    public interface IClassA
    {
        void MethodA();

        void MethodA2();
    }

    public class ClassA : IClassA
    {
        private readonly IClassB _classB;
        private readonly IClassB2 _classB2;

        public ClassA(IClassB classB, IClassB2 classB2)
        {
            _classB = classB;
            _classB2 = classB2;
        }

        public void MethodA() => _classB.MethodB();

        public void MethodA2() => _classB2.MethodB2();
    }

    public interface IClassB
    {
        void MethodB();
    }

    public class ClassB : IClassB
    {
        public void MethodB() => Console.WriteLine("Method B");
    }

    public interface IClassB2
    {
        void MethodB2();
    }

    public class ClassB2 : IClassB2
    {
        public void MethodB2() => Console.WriteLine("Method B2");
    }

    public class ClassC
    {
        private readonly IClassA _classA;

        public ClassC(IClassA classA)
        {
            _classA = classA;
        }

        public void MethodA() => _classA.MethodA();

        public void Method2() => _classA.MethodA2();
    }

    public static class DependencyInjectionProvider
    {
        private static readonly Dictionary<Type, Func<object>> _services = new();

        public static void Register<TService, TImplementation>() where TImplementation : TService
        {
            _services[typeof(TService)] = () => Activator.CreateInstance(typeof(TImplementation));
        }

        public static void Register<T>() where T : class
        {
            _services[typeof(T)] = () => Activator.CreateInstance(typeof(T));
        }

        public static TService Resolve<TService>()
        {
            if (_services.ContainsKey(typeof(TService)))
            {
                return (TService)_services[typeof(TService)]();
            }
            throw new InvalidOperationException($"Service of type {typeof(TService)} is not registered.");
        }
    }
}