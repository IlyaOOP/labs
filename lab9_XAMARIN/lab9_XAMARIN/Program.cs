using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab9_XAMARIN
{
	public delegate void Action();
	class Director
	{
		public event Action Up;

		public void CommandUp(int i)
		{
			Console.WriteLine ("повысить");
			if (Up != null) {
				Up ();
			}
		}

		public event Action Shtraf;

		public void CommandShtraf()
		{
			Console.WriteLine ("штраф");
			if (Shtraf != null) {
				Shtraf ();
			}
		}
	}

	delegate void toup();

	class tokar
	{
		public int money = 0;
		public void Iup()
		{
			Console.WriteLine ("я повышен");
			money += 10;
			Console.WriteLine ("зарплата " + money);
		}
		public void Ishtraph()
		{
			Console.WriteLine ("я оштрафован");
			money -= 10;
			Console.WriteLine ("зарплата " + money);
		}
	}

	class student
	{
		public int money = 0;
		public void Iup()
		{
			Console.WriteLine ("я повышен");
			money += 5;
			Console.WriteLine ("зарплата " + money);
		}
		public void Ishtraph()
		{
			Console.WriteLine ("я оштрафован");
			money -= 5;
			Console.WriteLine ("зарплата " + money);
		}
	}

	class oString
	{
		public static string deldot(string s)
		{
			for (int i = 0; i < s.Length; i++) {
				if (s.ElementAt(i) == '.' || s.ElementAt(i) == ',' || s.ElementAt(i) == ':' || s.ElementAt(i) == ';' || s.ElementAt(i) == '-')
				{
					s = s.Remove(i, 1);
				}
			}
			return s;
		}

		public static string delsp(string s)
		{
			for (int i = 0; i < s.Length; i++) {
				if (s.ElementAt(i) == ' ' && s.ElementAt(i+1) == ' ')
				{
					s = s.Remove(i, 1);
				}
			}
			return s;
		}

		public static string addsy(string s, int n, string c)
		{
			s = s.Insert(n, c);
			return s;
		}

		public static string touppercaseALL(string s)
		{
			s = s.ToUpper();
			return s;
		}

		public static string touppercaseFIRST(string s)
		{
			if (s.Length > 0) { s = Char.ToUpper(s[0]) + s.Substring(1); }
			return s;
		}

		public static void noreturn(string s)
		{
			Console.WriteLine ("completed");
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Director dir = new Director ();

			tokar t1 = new tokar ();
			tokar t2 = new tokar ();
			tokar t3 = new tokar ();

			student s1 = new student ();
			student s2 = new student ();
			student s3 = new student ();

			dir.Shtraf += new Action (t1.Ishtraph);
			dir.Shtraf += new Action (s1.Ishtraph);
			dir.Shtraf += new Action (s2.Ishtraph);

			dir.Up += new Action (t2.Iup);
			dir.Up += new Action (t3.Iup);

			dir.CommandUp (2);
			dir.CommandShtraf();

			Func<string, string> func;
			string str = "asd zxc, qwe - fgh;";

			func = oString.deldot;
			Console.WriteLine(str = func(str));
			func = oString.delsp;
			Console.WriteLine(str = func(str));
			func = oString.touppercaseALL;
			Console.WriteLine(func(str));
			func = oString.touppercaseFIRST;
			Console.WriteLine(func(str));

			Func<string, int, string, string> fun = oString.addsy;
			Console.WriteLine(str = fun (str, 3, "f"));

			Action<string> act = oString.noreturn;
			act (str);

			Console.ReadKey ();
		}
	}
}
