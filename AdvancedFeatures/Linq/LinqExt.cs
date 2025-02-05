using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Linq
{
    public static class LinqExt
    {
        public static IEnumerable<int> WherePositive(this IEnumerable<int> myLst, Func<int,bool> func)
        {
            foreach (int element in myLst)
                if (func(element))
                {
                    yield return element;
                    myLst.GetEnumerator().MoveNext();
                }
                    
        }
    }
}
