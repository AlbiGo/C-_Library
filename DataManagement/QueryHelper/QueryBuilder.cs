using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Queries
{
    public static class QueryBuilder
    {
        public static string BuildQuery(string queryName, List<Param> queryParams = null, string path = null)
        {
            var query = path == null ? File.ReadAllText(@$"../../../QueryHelper/Queries/{queryName}.sql") : path + $"/{queryName}.sql";

            if (queryParams != null && queryParams.Any())
            {
                foreach (var p in queryParams)
                {
                    if (p != null)
                    {
                        switch (p.ParamType)
                        {
                            case ParamType.Int
                                :
                                {
                                    query = query.Replace(p.Name, p.Value);
                                    break;
                                }
                            case ParamType.String
                               :
                                {
                                    query = query.Replace(p.Name, $"{p.Value}");
                                    break;
                                }
                        }
                    }
                }
            }
            return query;
        }
    }

    public class Param
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ParamType ParamType { get; set; }
    }

    public enum ParamType
    {
        Int = 1,
        String = 2,
        Double = 3
    }

    public class Query
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
    }

    //String connectionString = dbContext.Database.GetConnectionString();
    //System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(connectionString);

    //var query = QueryBuilder.BuildQuery("Entity1_query", new List<Param>() { new Param() { Name = "@nameParam", ParamType = ParamType.String, Value = "te" } });

    //System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(query);
    //cmd.Connection = conn;

    //conn.Open();
    //cmd.ExecuteScalar();
    //SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
    //System.Data.DataSet ds = new System.Data.DataSet();

    //da.Fill(ds);

    //foreach (DataTable myTable in ds.Tables)
    //{
    //    foreach (DataRow myRow in myTable.Rows)
    //    {
    //        foreach (DataColumn myColumn in myTable.Columns)
    //        {
    //            Console.Write(myRow[myColumn] + "\t");
    //        }
    //        Console.WriteLine();
    //    }
    //    Console.WriteLine();
    //}
    //Console.ReadLine();
}