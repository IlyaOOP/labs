using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Растение
{
	interface IProperties
	{
		bool plant_living();
		double prevalence { get; set; }
		double condition { get; set; }
	}

	abstract class растение : IProperties//не сможем создать объект
	{
		public abstract bool plant_living();
		public string grown_in;
		public abstract double prevalence { get; set; }
		public abstract double condition { get; set; }
		public растение(string a)
		{
			grown_in = a;
		}
	}

	partial class куст : растение
	{
		public int length;
		public override double prevalence { get; set; }
		public override double condition { get; set; }
		public куст(int len, double preval, double cond, string grown) : base(grown)
		{
			length = len;
			prevalence = preval;
			condition = cond;
		}
		public override string ToString()
		{
			return (this.GetType() + " произрастает в: " + grown_in + "\nвысота: " + length + "\nраспространенность: " + prevalence);
		}
		public void print()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(this.GetType() + " произрастает в: " + grown_in);
			Console.ResetColor();
			Console.WriteLine("высота: " + length + "\nраспространенность: " + prevalence);
			Console.ResetColor();
		}
	}

	class бумага : растение, IProperties
	{
		public enum qality {Bad, Good};//----------------

		struct factory
		{
			public string name;
			public int age;

			public void DisplayInfo()
			{
				Console.WriteLine("Name: " + name + " Age: " + age);
			}
		}

		public void SetFactory(string a, int b)
		{
			бумага.factory f = new factory ();
			f.name = a;
			f.age = b;
			f.DisplayInfo ();
		}

		bool IProperties.plant_living()
		{
			if (this != null)
				return false;
			else
				return true;
		}
		public override bool plant_living()
		{
			throw new NotImplementedException(); // метод не реализован, но будет реализован в будущем
		}
		int height;
		int width;
		public override double prevalence { get; set; }
		public override double condition { get; set; }
		public бумага(int hg, int wid, double preval, double cond, string grown) : base(grown)
		{
			height = hg;
			width = wid;
			prevalence = preval;
			condition = cond;
		}
		public override string ToString()
		{
			return (this.GetType() + " произведено в: " + grown_in + "\nдлина: " + height + "\nширина: " + width + "\nраспространенность: " + prevalence + "качаство: " + (qality)1);
		}
		public void print()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(this.GetType() + " произрастает в: " + grown_in);
			Console.ResetColor();
			Console.WriteLine("длина: " + height + "\nширина: " + width + "\nраспространенность: " + prevalence);
			Console.WriteLine ("качаство: " + (qality)1);
			Console.ResetColor();
		}
	}

	class цветок : растение, IProperties
	{
		public string color;
		bool IProperties.plant_living()
		{
			if (this != null)
				return false;
			else
				return true;
		}
		public override bool plant_living()
		{
			throw new NotImplementedException(); // метод не реализован, но будет реализован в будущем
		}
		public int length;
		public override double prevalence { get; set; }
		public override double condition { get; set; }

		public цветок(int len, double preval, double cond, string grown, string col) : base(grown)
		{
			color = col;
			length = len;
			prevalence = preval;
			condition = cond;
		}
		public override string ToString()
		{
			return (this.GetType() + " произрастает в: " + grown_in + "\nвысота: " + length + "\nраспространенность: " + prevalence);
		}
		public virtual void print()//будет  переопределено в букет
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(this.GetType() + " произрастает в: " + grown_in);
			Console.ResetColor();
			Console.WriteLine("высота: " + length + "\nраспространенность: " + prevalence);
			Console.ResetColor();
		}
	}

	class роза : цветок
	{
		public string color;
		public роза(int len, double preval, double cond, string grown, string clr) : base(len, preval, cond, grown, clr)
		{
			color = clr;
			length = len;
			prevalence = preval;
			condition = cond;
		}
		public override string ToString()
		{
			return (this.GetType() + " произрастает в: " + grown_in + "\nвысота: " + length + "\nраспространенность: " + prevalence + "\nцвет: " + color);
		}

	}

	class гладиолус : цветок
	{
		public string color;
		public гладиолус(int len, double preval, double cond, string grown, string clr) : base(len, preval, cond, grown, clr)
		{
			color = clr;
			length = len;
			prevalence = preval;
			condition = cond;
		}
		public override string ToString()
		{
			return (this.GetType() + " произрастает в: " + grown_in + "\nвысота: " + length + "\nраспространенность: " + prevalence + "\nцвет: " + color);
		}
	}

	class кактус : цветок
	{
		public string color;
		public кактус(int len, double preval, double cond, string grown, string clr) : base(len, preval, cond, grown, clr)
		{
			if (clr.Length > 10) {
				Exception x = new Exception ();
				x.Data.Add("time ", DateTime.Now);
			}
			if (clr == "red") {
				throw new cactusException ("кактус не может быть красным");
			}
			color = clr;
			length = len;
			prevalence = preval;
			condition = cond;
		}
		public override string ToString()
		{
			return (this.GetType() + " произрастает в: " + grown_in + "\nвысота: " + length + "\nраспространенность: " + prevalence + "\nцвет: " + color);
		}
	}

	/*class букет : цветок
	{
		object[] contain;
		string objarr = "";
		public букет(int kolich, double preval, double cond, string grown, object[] obj) : base(kolich, preval, cond, grown)
		{
			contain = obj;
			length = kolich;
			prevalence = preval;
			condition = cond;

			foreach (object i in contain)
			{
				objarr += "-\n";
				objarr += Convert.ToString(i);
				objarr += ";\n";
			}
		}
		public override string ToString()
		{
			return (this.GetType() + " произрастает в: " + grown_in + "\nколичество: " + length + "\nраспространенность: " + prevalence + "\nсостав: \n" + objarr);
		}

		public override void print()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(this.GetType() + " произрастает в: " + grown_in);
			Console.ResetColor();
			Console.WriteLine("количесво: " + length + "\nраспространенность: " + prevalence + "\nсостав: \n" + objarr);
			Console.ResetColor();
		}
	}*/
	public class pereopr : Object
	{
		public override string ToString()
		{
			return "a";
		}

		public override int GetHashCode()
		{
			return 2;
		}

		public override bool Equals(object obj)
		{
			if (obj != null) return true;
			else return false;
		}
	}

	sealed class Printer//бесплодный класс
	{
		public string iAmPrinting(растение someobj)//полиморфный метод с параметром-ссылкой на объект
		{
			Type a = someobj.GetType();
			return a.ToString();
		}

	}

	//----------------------------------------------------------------------------

	class cactusException : Exception
	{
		public cactusException(string str) : base(str) { }
		public override string ToString()
		{
			Console.BackgroundColor = ConsoleColor.Red;
			return "Ошибка: " + Message;
		}
	}
	class except1 : Exception
	{
		public except1(string str) : base(str) { }
		public override string ToString()
		{
			return Message;
		}
	}

	class except2 : except1
	{
		public except2(string str) : base(str) { }
		public override string ToString()
		{
			return Message;
		}
	}

	class Program
	{
		static bool err=false;
		static int dividenull(int x, int y)
		{
			if (y == 0)
			{
				Exception a = new Exception();
				a.Data.Add("Время: ", DateTime.Now);
				err = true;
			};
			return x / y;
		}

		static void Main(string[] args)
		{
			try
			{
				куст kyst = new куст(100, 0.1, 1, "belarus");
				kyst.print();

				бумага paper = new бумага(100, 90, 1, 0, "belarus");
				paper.print();


				цветок flower = new цветок(15, 0.9, 0.7, "belarus", "gold");
				flower.print();

				кактус cactus = new кактус (10, 0.3, 0.4, "Egupt", "green");

				роза rose = new роза(40, 0.7, 0, "England", "white");
				rose.print();

				object[] objarr = { flower, rose };

				Console.Write("Rose is string ");
				Console.WriteLine(rose is string);
				Console.Write("Rose is цветок ");
				Console.WriteLine(rose is цветок);
				Console.Write("Rose as растение ");
				Console.WriteLine(rose as растение);
				Console.WriteLine("");
				IProperties obj;
				obj = rose;
				Console.WriteLine("object rose: " + obj.ToString());
				Console.WriteLine("");

				Printer pr = new Printer();
				List<растение> spisok = new List<растение>();
				spisok.Add(kyst);
				spisok.Add(paper);
				spisok.Add(flower);
				spisok.Add(rose);
				Console.WriteLine(pr.iAmPrinting(spisok[0]));
				Console.WriteLine(pr.iAmPrinting(spisok[1]));
				Console.WriteLine(pr.iAmPrinting(spisok[2]));
				Console.WriteLine(pr.iAmPrinting(spisok[3]));
				Console.BackgroundColor = ConsoleColor.Red;
				for (int i = 0; i < 20; i++) 
				{
					Console.Write (" ");
				}
				Console.WriteLine ();
				Console.ResetColor ();

				paper.SetFactory ("factory", 2);
				Console.WriteLine ();

				букет bouquet = new букет(rose, flower, cactus);
				bouquet.PrintBouqet ();
				Console.WriteLine ();

				Controller cntr = new Controller ();
				Console.WriteLine("price " + cntr.cost (bouquet) + " rub");
				cntr.sort (bouquet);
				Console.WriteLine ();

				cntr.findbycolor (bouquet, "green");


				кактус Ecactus = new кактус(10, 0.3, 0.4, "Egupt", "red");
				dividenull(89,0);

				Console.ReadKey ();
			}
			catch (cactusException ex){Console.WriteLine (ex); err = true;}
			catch (except2 ex) { Console.WriteLine(ex); err = true;}
			catch (except1 ex) { Console.WriteLine(ex); err = true;}
			catch (Exception ex)
			{
				err = true;
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.Message);
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.TargetSite);
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.StackTrace);
				Console.WriteLine("------------------------------------------");
				Console.WriteLine(ex.HelpLink);
			}
			finally {Debug.Assert(err != false,/*\\*/ "Программа завершена без ошибок"); Console.ReadKey ();}
		}
	}
}

