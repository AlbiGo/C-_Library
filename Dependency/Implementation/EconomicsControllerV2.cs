using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Implementation
{
    public class EconomicsControllerV2
    {
        private MathService _mathService;
        public EconomicsControllerV2()
        {
            _mathService = new MathService(new MathRepo(new MathDBContext()));
        }

        public void EconomicsCalc(Math math)
        {
            _mathService.Add(math);
        }
    }
}
