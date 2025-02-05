using System.Diagnostics;
using Threads;
using Threads.Threads;

Console.WriteLine("---------------------------------------------------------------------------------");

var kithcen2 = new KitchenThread();
Stopwatch stopwatch2 = Stopwatch.StartNew();
kithcen2.MakePasta();
stopwatch2.Stop();
Console.WriteLine(stopwatch2.ElapsedMilliseconds.ToString());



