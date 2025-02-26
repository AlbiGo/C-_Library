namespace AdvancedFeatures.Linq
{
    /// <summary>
    /// Linq extension
    /// </summary>
    public static class LinqExt
    {
        public static IEnumerable<int> WherePositive(this IEnumerable<int> myLst, Func<int, bool> func)
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