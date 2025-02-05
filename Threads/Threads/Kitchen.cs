using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Threads
{
    public class Kitchen
    {
        public Kitchen() { }
        public virtual void MakePasta()
        {

            BoilWater();
            PrepareIngridients();
            MakeSauce();
            PourPastaIntoWater();
            PourSause();
            PrepareTable();
            FillPlates();
        }

        protected virtual void BoilWater()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());
            Thread.Sleep(10000);
        }

        protected virtual void PrepareIngridients()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            Thread.Sleep(10000);

        }

        protected virtual void MakeSauce()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            Thread.Sleep(10000);


        }

        protected virtual void PourPastaIntoWater()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            Thread.Sleep(10000);

        }

        protected virtual void PrepareTable()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            Thread.Sleep(10000);

        }

        protected virtual void PourSause()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            Thread.Sleep(10000);
        }

        protected virtual void FillPlates()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            Thread.Sleep(10000);

        }

        protected void CountTo20()
        {
            for (int i = 0; i < 20;)
            {
                i++;
                Console.WriteLine(i.ToString());
            }
        }
    }

    public class KitchenThread : Kitchen
    {
        public override void MakePasta()
        {

            Thread boilWaterThread = new Thread(BoilWater);
            Thread prepareIngridientsThread = new Thread(PrepareIngridients);
            Thread makeSauceThread = new Thread(MakeSauce);
            Thread prepareTableThread = new Thread(PrepareTable);
            Thread pourPastaIntoWaterThread = new Thread(PourPastaIntoWater);
            Thread pourSauseThread = new Thread(PourSause);
            Thread fillPlatesThread = new Thread(FillPlates);

            ////Executing the methods
            Console.WriteLine("Doing these three tasks at same time");
            boilWaterThread.Start();
            prepareIngridientsThread.Start();
            prepareTableThread.Start();
            prepareIngridientsThread.Join();
            Console.WriteLine("---------------------------------");

            makeSauceThread.Start();

            Console.WriteLine("Doing these tasks at same time");
            boilWaterThread.Join();
            pourPastaIntoWaterThread.Start();
            Console.WriteLine("---------------------------------");

            makeSauceThread.Join();

            pourSauseThread.Start();
            pourSauseThread.Join();
            Console.WriteLine("---------------------------------");
            fillPlatesThread.Start();
            fillPlatesThread.Join();
            Console.WriteLine("---------------------------------");
            Task.WaitAll();
        }
    }

    public class KitchenAsync : Kitchen
    {
        public KitchenAsync() { }
        public async Task MakePasta()
        {

            await BoilWater();
            await PrepareIngridients();
            //MakeSauce();
            //PourPastaIntoWater();
            //PourSause();
            //PrepareTable();
            //FillPlates();
        }


        protected async Task BoilWater()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());
            CountTo20();
        }

        protected async Task PrepareIngridients()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            CountTo20();

        }

        protected async void MakeSauce()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            CountTo20();


        }

        protected async void PourPastaIntoWater()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            CountTo20();

        }

        protected async void PrepareTable()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            CountTo20();

        }

        protected async void PourSause()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            CountTo20();
        }

        protected async void FillPlates()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            CountTo20();

        }
    }


}
