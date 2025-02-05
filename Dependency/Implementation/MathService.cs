using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Implementation
{
    public class MathService : IMathService
    {
        public double Value { get; set; }
        private readonly IMathRepo _mathRepo;

        public MathService(IMathRepo mathRepo)
        {
            _mathRepo = mathRepo;
        }
        public void Add(Math math)
        {
            _mathRepo.Add(math);
        }
    }
}
