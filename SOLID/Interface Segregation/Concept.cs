using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Interface_Segregation
{
    public class BaseClass : IBaseClassA, IBaseClassB
    {
        public void MethodA()
        {
            Console.WriteLine("Method A");
        }

        public void MethodB()
        {
            Console.WriteLine("Method B");
        }
    }

    public interface IBaseClassA
    {
        public void MethodA();

    }

    public interface IBaseClassB
    {
        public void MethodB();
    }
}
