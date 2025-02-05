using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection = Dependency.Implementation.DependencyInjection<Dependency.Implementation.Math>;

namespace Dependency.Implementation
{
    public class EconomicsController
    {
        private IMathService _mathService;
        public EconomicsController()
        {
            _mathService = (MathService)(DependencyInjection<IMathService>.GetService());
        }

        public void EconomicsCalc(Math math)
        {
            _mathService.Add(math);
        }
    }
}
