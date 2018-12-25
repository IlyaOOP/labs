using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab16
{
    class Eratosfen
    {
        List<int> simple;

        public Eratosfen(int MaxNumber)
        {
            simple = new List<int>();
            for (int i = 1; i < MaxNumber; i++)
                simple.Add(i);
            DoEratosfen();
        }

        public Eratosfen()
        {
        }

        int Step(int Prime, int startFrom)
        {
            int i = startFrom + 1;
            int Removed = 0;
            while (i < simple.Count)
                if (simple[i] % Prime == 0)
                {
                    simple.RemoveAt(i);
                    Removed++;
                }
                else
                    i++;
            return Removed;
        }

        void DoEratosfen()
        {
            int i = 1;
            while (i < simple.Count)
            {
                Step(simple[i], i);
                i++;
            }
        }

        public int[] Simple
        {
            get
            {
                return simple.ToArray();
            }
        }

    }


    class Program
    {
        public static int Formula1(int x, int y)
        {
            return (int)(x * (8 - 3.5*8 / 3 + 0.5689));
        }

        public static int Formula2(int x)
        {
            return (int)(9 * (x - 5) + 4 / 3 + 5);
        }

        public static int Formula3(int x)
        {
            return (int)(-17 / 12 * (-x + 4) / x * 33);
        }

        public static int ResultFormula(int x, int y, int z)
        {
            return (x + y + z);
        }
        static void Main(string[] args)
        {
            Stopwatch stpw = new Stopwatch();
            stpw.Start();

            Eratosfen erf;
            Task eratosphenes = new Task(() => erf = new Eratosfen(100000));

            Console.WriteLine("1id: " + eratosphenes.Id + " status: " + eratosphenes.Status);
            eratosphenes.Start();
            Console.WriteLine("2id: " + eratosphenes.Id + " status: " + eratosphenes.Status);
            eratosphenes.Wait();
            Console.WriteLine("3id: " + eratosphenes.Id + " status: " + eratosphenes.Status);

            stpw.Stop();
            Console.WriteLine("время выполнения: " + stpw.Elapsed.Seconds + "секунд " + stpw.Elapsed.Milliseconds + "миллисекунд");

            //t2
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;


            Task eratosphenes2 = new Task(() =>
            {
                erf = new Eratosfen(100000);
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
            });
            eratosphenes2.Start();
            Console.WriteLine("input sumbol to cansel operation");
            Console.ReadKey();
            cancelTokenSource.Cancel();

            //t3
            Task<int> task1 = Task.Run(() => Formula1(5, 2));
            Task<int> task2 = Task.Run(() => Formula2(3));
            Task<int> task3 = Task.Run(() => Formula3(-6));
            Task<int> result = Task.Run(() => ResultFormula(task1.Result, task2.Result, task3.Result));

            Console.WriteLine("Task1: "+ task1.Result);
            Console.WriteLine("Task2: "+ task2.Result);
            Console.WriteLine("Task3: "+ task3.Result);
            Console.WriteLine("Result: "+ result.Result);

            //t4
            //Task continuation = Task.WhenAll(result).ContinueWith(t => Console.WriteLine("Continue"));
            Task continuation = Task.Run(() => Console.WriteLine("Continue"));

            var awaiter = result.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine("Awaiter result: "+ awaiter.GetResult()));

            //t5
            double[] array = new double[1000000];
            stpw.Start();
            Parallel.For(0, array.Length, i =>
            {
                array[i] = Math.Pow(2, i);
            });
            stpw.Stop();
            Console.WriteLine("Время выполнения: {0},{1}", stpw.Elapsed.Seconds, stpw.Elapsed.Milliseconds);

            stpw.Reset();

            stpw.Start();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Pow(2, i);
            }
            stpw.Stop();
            Console.WriteLine("Время выполнения: {0},{1}", stpw.Elapsed.Seconds, stpw.Elapsed.Milliseconds);
            stpw.Reset();

            Console.WriteLine("______________________");
            //t6
            stpw.Start();
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Math.Pow(2, i);
                }
            });
            stpw.Stop();
            Console.WriteLine("Время выполнения: {0},{1}", stpw.Elapsed.Seconds, stpw.Elapsed.Milliseconds);
            stpw.Reset();

            stpw.Start();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Pow(2, i);
            }
            stpw.Stop();
            Console.WriteLine("Время выполнения: {0},{1}", stpw.Elapsed.Seconds, stpw.Elapsed.Milliseconds);
            stpw.Reset();

            //t7
            BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            for (int producer = 0; producer < 10; producer++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(200);
                        blockcoll.Add(i * producer);
                    }
                });
            }
            Task consumer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("_");
                foreach (var item in blockcoll.GetConsumingEnumerable())
                {
                    Console.WriteLine(item);
                }
            });
            //consumer.Wait();
            //t8
            FactorialAsync();
            Console.ReadKey();
        }

        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Console.WriteLine("asd"));                            // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");  // выполняется синхронно
        }
       
    }
}
