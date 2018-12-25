using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace lab15
{
    public static class checker
    {
        public static bool flag;
    }
    class Program
    {
        void tim()
        {
            Console.WriteLine("timer");
        }
        static void func()
        {
            Console.WriteLine("введите n ");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i<n)
            {
                Thread.Sleep(300);
                Console.WriteLine(i);
                i++;
            }
            checker.flag = true;
        }

        static string objlocker = "null";
        public static void even()
        {
            lock(objlocker){
                int i = 0;
                while (i < 20)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                    i++;
                    Thread.Sleep(200);
                }
            }
        }

        public static void odd()
        {
            int i = 0;
            while (i < 20)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
                i++;
                Thread.Sleep(150);
            }
        }

        public static void PrintTime(object state)
        {
            Console.WriteLine("Текущее время:  " + DateTime.Now.ToLongTimeString());
        }

        static void Main(string[] args)
        {
            //t1
            Process[] proc = Process.GetProcesses();
            foreach (Process pr in proc)
            {
                try
                {
                    Console.WriteLine("id: " + pr.Id + " name: " + pr.ProcessName + " priority: " + pr.BasePriority + " start time: " + pr.StartTime + " full processortime: " + pr.TotalProcessorTime);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            //t2
            Console.WriteLine("____________________________________________________________________________________________________");
            AppDomain ad = AppDomain.CurrentDomain;
            Console.WriteLine("name: " + ad.FriendlyName + " details: " + ad.SetupInformation + " assamblies: " + ad.GetAssemblies());
            foreach (var apd in ad.GetAssemblies())
            {
                Console.WriteLine(apd);
            }
            //создание нового домена
            AppDomain nad = AppDomain.CreateDomain("lab15new");
            Assembly assembly = Assembly.LoadFrom("lab15.exe");
            nad.Load(assembly.FullName);
            AppDomain.Unload(nad);
            Console.WriteLine("____________________________________________________________________________________________________");

            //t3
            Thread th1 = new Thread(func);
            th1.Start();
            Console.WriteLine("name: " + th1.Name + " status: " + th1.ThreadState + " priority: " + th1.Priority + " id: " + th1.ManagedThreadId);
            Thread.Sleep(300);
            th1.Suspend();
            Thread.Sleep(300);
            th1.Resume();

            //t4
            while(true)
            {
                if (checker.flag == true) { break; }
            }
            Thread th2 = new Thread(even);
            Thread th3 = new Thread(odd);
            th2.Start();
            Thread.Sleep(100);
            th3.Start();
            th3.Priority = ThreadPriority.Lowest;
            Thread.Sleep(4000);

            //t5
            TimerCallback tm = new TimerCallback(PrintTime);
            Timer timer = new Timer(tm, 0, 0, 2000);
            Console.ReadLine();
        }

        
    }
}
