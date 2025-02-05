using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFeatures.Expressions
{
    public static class ExpressionTrees
    {
        public static Expression<Func<int, int, int>> CreateExpressionTreeFromLambdaExpression()
        {
            Expression<Func<int, int, int>> sumExpressionTree = (int number1, int number2) => number1 + number2;
            return sumExpressionTree;
        }

        public static Expression<Func<Student, bool>> CreateExpressionTreeFromFilter(StudentFilter filter)
        {
            Expression<Func<Student,bool>> filterExp;

  
            filterExp = p => (filter.Age == null ? true : p.Age >= filter.Age) &&
                             (string.IsNullOrEmpty(filter.Email) ? true : p.Email.Contains(filter.Email)) &&
                             (string.IsNullOrEmpty(filter.FullName) ? true : p.StudentName.Contains(filter.FullName));

            return filterExp;
        }

        public static IEnumerable<Student> InlineFilter(this IQueryable<Student> query, StudentFilter filter)
        {
            var filterExp = CreateExpressionTreeFromFilter(filter);
            var filteredQuery = query.Where(filterExp.Compile());
            return filteredQuery;
        }
    }
}
