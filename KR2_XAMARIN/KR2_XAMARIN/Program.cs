using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KR2_XAMARIN
{
	class SuperList<T> : List<T> where T : class
	{
		public static SuperList<T> operator +(SuperList<T> spl, T addsmth)
		{
			if (spl.Count <= 3) {
				spl.Add (addsmth);
			} else {
				throw new IndexOutOfRangeException();
			}
			return spl;
		}
	}

	class A
	{
		public int a;
		public string b;

		public A(int ia, string ib)
		{
			a = ia;
			b = ib;
		}
		public bool eq (A obj)
		{
			if (a == obj.a && b == obj.b) {
				return true;
			} else {
				return false;
			}

		}
	}
	//------------------------------------------------
	public delegate void Action();

	class Doctor
	{
		public void ILech()
		{
			Console.WriteLine ("доктор: лечу");

		}
	}

	class Bolnoy
	{
		public event Action lech;

		public void tempup()
		{
			Console.WriteLine ("больной: температура повысилась!");
			if (lech != null) {
				lech ();
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			try{
			A a1 = new A (1, "asd");
			A a2 = new A (2, "asd");
			A a3 = new A (3, "asd");
			A a4 = new A (4, "asd");
			A a5 = new A (5, "asd");

			SuperList<A> sp1 = new SuperList<A> ();
			sp1.Add (a1);
			sp1.Add (a2);
			sp1.Add (a3);
			sp1.Add (a4);
			
			SuperList<A> sp2 = new SuperList<A> ();//исключение
				//sp2 = sp1 + a5;

				A[] arrA;//_____________________вывод
				arrA = sp1.ToArray();
				foreach(A a in arrA)
				{
					Console.WriteLine(a);
				}
				Console.WriteLine("________________________________ex2_________________________________");
				//_____________________________________________________ex2________________________________
				var data = from s in sp1
						where s.eq(a4)
					select s;
				foreach(A a in sp1)
				{
					Console.WriteLine(a.eq(a4));
				}
				foreach(var dt in data)
				{
					Console.WriteLine(dt);
				}
				Console.WriteLine("________________________________ex3_________________________________");
				//______________________________________________________ex3__________________________________
				Doctor dok = new Doctor();
				Bolnoy bl = new Bolnoy();

				bl.lech += new Action(dok.ILech);//подпись доктора на больного
				bl.tempup();
			}
			catch(Exception ex){
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.Message);
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.TargetSite);
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.StackTrace);
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.HelpLink);
			}
			finally{
				Console.ReadKey ();
			}
		}
	}
}
