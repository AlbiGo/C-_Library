using DataManagement.DbContext;
using DataManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AdvancedFeatures.CompiledQueries
{
    public class Filter
    {
        public string? FilterTerm { get; set; }
        public DateTime Created { get; set; }
    }

    public static class CompiledQueryEx
    {
        private static Func<DatabaseContext, Filter, IEnumerable<Entity1>> CreateCompiledFilterQuery()
        {
            Func<DatabaseContext, Filter, IEnumerable<Entity1>> filterCompiledQuery = EF.CompileQuery((DatabaseContext context, Filter filter) =>
                context.Entity1s.Where(p => p.Name.Contains(filter.FilterTerm) &&
                                            p.Created > filter.Created));

            return filterCompiledQuery;
        }

        public static void Filter(this IEnumerable<Entity1> entities, Filter filter)
        {
            var filterCompiledQuery = CreateCompiledFilterQuery();
            using (DatabaseContext context = new DatabaseContext())
            {
                entities = filterCompiledQuery.Invoke(context, filter);

                foreach (var entity in entities)
                {
                    Console.WriteLine("ID: {0}  Name : {1} Created: {2}",
                        entity.Id,
                        entity.Name,
                        entity.Created);
                }
            }
        }
    }
}