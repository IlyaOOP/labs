using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smst
{
    //public class A
    //{
    //    public A()
    //    {
    //        Console.Write("aaaaa");
    //    }
    //}
    //public class B : A
    //{
    //    public B() : base()
    //    {
    //        Console.WriteLine("bbbbbbb");
    //    }
    //}
    class MyInt : IEnumerable, IEnumerator
    {
        int[] ints = { 12, 13, 1, 4 };
        int index = -1;

        // Реализуем интерфейс IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // Реализуем интерфейс IEnumerator
        public bool MoveNext()
        {
            if (index == ints.Length - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return ints[index];
            }
        }
    }

    /*interface IGood
    {
        void fine();
    }
    abstract class Something : IGood
    {
        public abstract void ItsOk();
        public abstract void fine();
    }
    class Case : IGood
    {
        public void fine()
        {
            public void 
        }
    public void ItsOk()
    {

    }
    }*/

    class Computer : IComparable<Computer>
    {
        static readonly int first= 0;
        static int second= 0;
        public int third;

        public Computer() {
            this.third = 0;
        }
        public Computer(int first, int second, int third)
        {
            first = first;
            second = second;
            this.third = third;
        }

        // Реализуем интерфейс IComparable<T>
        public int CompareTo(Computer obj)
        {
            if (this.third > obj.third)
                return 1;
            if (this.third < obj.third)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return String.Format(first + "" + second + "" + this.third);
        }

    }

    interface Interface1 { void f(); void g(); }
    class A { public void f() { System.Console.WriteLine("F"); } public void g() { System.Console.WriteLine("G"); } }
    class B : A, Interface1 { new public void g() { System.Console.WriteLine("new G"); } }

    class Program
    {
        public enum month { jan = 1, feb = 2, mar = 3, apr = 4, may = 5, jun = 6, jul = 7, aug = 8, sept = 9, oct = 10, nov = 11, dec = 12 }

        public static string str = "123. 345. 678.";
        static void Main(string[] args)
        {
            Interface1 obj = new B();
            obj.g();
            //B obj = new B();
            //.g(); 
            //foreach (int i in mi)
            //  Console.Write(i + "\t");

            //Console.ReadLine();

            //A a = new A();

            //B b = new B();
            //A
            /*foreach (string i in month) {
                Console.WriteLine(i);
            }*/

            //B 
            string[] str2 = str.Split(new char[] { '.' });
            foreach (string j in str2)
            {
                Console.WriteLine(j);
            }

            //C
            int[] ceil = { 1, 2, 3, 4, 5 };
            string endstr = "";
            foreach (int h in ceil)
            {
                endstr += h;
            }
            Console.WriteLine(endstr + " " + endstr.GetType());

            //2
            Computer comp1 = new Computer();
            Computer comp2 = new Computer();
            Console.WriteLine(comp1.CompareTo(comp2));

            //3
            //00000

        }
    }
}
