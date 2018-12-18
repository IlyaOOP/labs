using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab12_XAMARIN
{
	interface A{};
	interface B{};

	class first : A, B
	{
		public int a;
		public string b;
		string c;

		public int A{ get; set;}

		public first(){
			a = 1;
			b = "2";
			c = "3";
		}

		public first(int ia, string ib, string ic)
		{
			a = ia;
			b = ib;
			c = ic;
		}

		public void func1(){
			Console.WriteLine ("method 1");
		}

		public void func2(int g){
			Console.WriteLine ("method 1. You input: "+g);
		}
	}

	static class Reflector
	{
		public static void outtofile(string clname)
		{
			Type type = Type.GetType (clname);

			using (StreamWriter srw = new StreamWriter(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab12_XAMARIN\lab12_XAMARIN\smfile.txt"))
			{
				Console.WriteLine(clname);
				var members = type.GetMembers ();
				foreach (MemberInfo mbs in members) {
					srw.WriteLine (mbs);
				}
				srw.WriteLine ("\n_____________________________________________________________");
				Console.WriteLine("содержимое выведено в текстовый файл");
			}
			Console.WriteLine ("\n_____________________________________________________________");
		}

		public static void getpublicmethods(string clname)
		{
			Type type = Type.GetType (clname);

			Console.WriteLine ("public методы для "+clname);

			var members = type.GetMethods ();
			foreach (MemberInfo mbinf in members) {
				Console.WriteLine (mbinf);
			}
			Console.WriteLine ("\n_____________________________________________________________");
		}

		public static void fieldsandproperties(string clname)
		{
			Type type = Type.GetType (clname);

			Console.WriteLine ("поля и свойства для "+clname);

			var ffields = type.GetFields (BindingFlags.NonPublic | BindingFlags.Instance|BindingFlags.Public);
			var pproperties = type.GetProperties (BindingFlags.NonPublic | BindingFlags.Instance);

			foreach (MemberInfo mbinf in ffields) {
				Console.WriteLine (mbinf);
			}
			foreach (MemberInfo mbinf in pproperties) {
				Console.WriteLine (mbinf);
			}
			Console.WriteLine ("\n_____________________________________________________________");
		}

		public static void interfaces(string clname)
		{
			Type type = Type.GetType (clname);

			Console.WriteLine ("интерфейсы реализованные классом");

			var iinterfaces = type.GetInterfaces ();

			foreach(MemberInfo mbi in iinterfaces){
				Console.WriteLine (mbi);
			}
			Console.WriteLine ("\n_____________________________________________________________");
		}

		public static void methodsbyparameter(string clname, string parametertype)
		{
			Type type = Type.GetType (clname);

			Console.WriteLine ("метод по заданному параметру");

			var methods = type.GetMethods ();

			foreach (MethodInfo mti in methods) {
				foreach (ParameterInfo pinf in mti.GetParameters()) {
					if (pinf.ParameterType  == Type.GetType (parametertype)) {
						Console.WriteLine (mti);
					}
					}
				/*if (mti.ReturnType == Type.GetType (parametertype)) {
					Console.WriteLine (mti);
				}*/
			}
			Console.WriteLine ("\n_____________________________________________________________");
		}

		public static void callmethod(string clname, string metname)
		{
			Type type = Type.GetType (clname);

			Console.WriteLine ("вызов метода");

			var method = type.GetMethod (metname);

			Queue<object> parametrs = new Queue<object>();

			using (StreamReader sr = new StreamReader(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab12_XAMARIN\lab12_XAMARIN\params.txt"))
			{
				string str;

				while ((str = sr.ReadLine () )!= null) {
					parametrs.Enqueue (Int32.Parse(str));
				}
			}

			method.Invoke (Activator.CreateInstance(type), parametrs.ToArray());
			Console.WriteLine ("\n_____________________________________________________________");
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Reflector.outtofile ("lab12_XAMARIN.first");//вывод содержимого класса в файл

			Reflector.getpublicmethods ("lab12_XAMARIN.first");

			Reflector.fieldsandproperties ("lab12_XAMARIN.first");

			Reflector.interfaces ("lab12_XAMARIN.first");

			Reflector.methodsbyparameter ("lab12_XAMARIN.first", "System.Int32");

			Reflector.callmethod ("lab12_XAMARIN.first", "func2");

			Console.WriteLine ("Hello World!");
			Console.ReadKey ();
		}
	}
}
