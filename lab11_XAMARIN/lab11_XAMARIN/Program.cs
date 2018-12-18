using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11_XAMARIN
{
	class Country
	{
		public string country;
		public string sity;
	}
	class Continent
	{
		public string country;
		public string continent;
	}

	class Data
	{
		//массив с названиями месяцев
		string[] arr = { "", "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
		public const int maxDay = 31;
		public const int maxMonth = 12;
		static int count = 0;
		public int toDay = 0;
		int day;
		int month;
		int year;
		public static int type = 1;//используется для запрашивания даты 01/01/2018 или 1 января 2018 года
		public readonly int ID;//поле тоько для чтения

		static Data()
		{
			Console.WriteLine("Статический конструктор");
		}

		//свойства
		public int accs_day
		{
			get
			{
				return day;
			}
			set
			{
				day = value;
			}
		}
		public int accs_month
		{
			get
			{
				return month;
			}
			set
			{
				month = value;
			}
		}
		public int accs_year
		{
			get
			{
				return year;
			}
		}
		public int accs_ID
		{
			get
			{
				return ID;
			}
		}

		public Data() {//конструктор с параметрами по умолчанию
			count++;
			day = 5;
			month = 1;
			year = 2018;
			ID = this.GetHashCode();
		}

		public Data(int d, int m, int y)//конструктор с параметрами
		{
			count++;
			if (d <= maxDay)
			{
				day = d;
			}
			else
			{
				day = 00;
			}
			if (m <= maxMonth)
			{
				month = m;
			}
			else
			{
				month = 00;
			}
			year = y;
			this.ToDay ();
			ID = this.GetHashCode();
		}

		public void print()//вывод даты ф соответствии с заданным форматом
		{
			if(type == 1)
			{
				Console.WriteLine("{0}/{1}/{2}", day, month, year);
			}
			if (type == 2)
			{
				string mnt = arr[month];
				Console.WriteLine("{0} {1} {2} года", day, mnt, year);
			}
		}

		public void ToDay(){
			toDay += this.day + this.month * 30 + this.year * 12 * 30;
		}

		//переоределение
		public virtual Boolean Equals(Data a)//ключевое слово, применяемое к методам, свойствам и событиям, 
		//которые могут быть переопределены (override) в производных классах.
		{
			if (this.GetType() != a.GetType()) return false;
			if (this.day != a.day || this.month != a.month || this.year != a.year) return false;
			return true;
		}

		public override int GetHashCode()//модификатор для переопределения виртуальных методов (virtual), свойств и событий базового класса.
		{
			int hashcode = this.day.GetHashCode();
			hashcode = 31 * hashcode + this.month.GetHashCode();
			hashcode = 31 * hashcode + this.year.GetHashCode();
			return hashcode;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
         
			string[] month = new string[] {
				"January",
				"February",
				"march",
				"april",
				"may",
				"june",
				"july",
				"august",
				"september",
				"october",
				"november",
				"december"
			};

			int n = 5;
			var LengthEqualsN = from m in month
			                    where m.Length == n
			                    select m;
			Console.WriteLine("\nмесяцы, с длиной строки "+n+": ");
			foreach (string s in LengthEqualsN)
				Console.WriteLine(s);

			var sw = from m in month
					where m == "January"|| m == "February"|| m == "june"|| m == "july"|| m == "august"|| m == "december"
					 select m;
			Console.WriteLine("\nзимние и летние месяцы: ");
			foreach (string s in sw)
				Console.WriteLine(s);

			var sort = month.OrderBy (s => s);
			Console.WriteLine("\nсортировка по алфавиту: ");
			foreach (string s in sort)
				Console.WriteLine(s);

			var another = from m in month
					where m.Length > 4 && m.Contains("u")
					select m;
			Console.WriteLine("\nмесяцы содержащие u и длиной > 4: ");
			foreach (string s in another)
				Console.WriteLine(s);

			//ex2

			Data d1 = new Data (1, 6, 2008);
			Data d2 = new Data (4, 8, 2010);
			Data d3 = new Data (19, 10, 2015);
			Data d4 = new Data (31, 12, 2018);

			List<Data> dt = new List<Data> () { d1, d2, d3, d4 };

			//ex3

			var dat1 = from d in dt
					where d.accs_year == 2018
					select d;
			Console.WriteLine("\nдаты для 2018г: ");
			foreach (Data da in dat1)
				da.print ();

			var dat2 = from d in dt
					where d.accs_month == 10
					select d;
			Console.WriteLine("\nдаты для 10 месяца: ");
			foreach (Data da in dat2)
				da.print ();

			var dat3 = from d in dt
					where d.accs_day>3 && d.accs_day<30
					select d;
			Console.WriteLine("\nколичество даты для диапазона от 3 до 30: ");
			Console.WriteLine (dat3.Count());

			int[] yeararr = new int[dt.Count];
			for(int i = 0; i<dt.Count; i++){
				yeararr[i] = dt[i].accs_year;
				}
			yeararr.OrderBy (e => e);
			Console.WriteLine("\nмаксимальная дата: ");
			Console.WriteLine (yeararr.Last());

			var dat5 = from d in dt
					where d.accs_day==31
					select d;
			Console.WriteLine("\nпервая дата для заданного дня: ");
			foreach (Data da in dat5) {
				da.print ();
				break;
			}

			var dat6 = dt.OrderBy (x => x.toDay);
			Console.WriteLine("\nотсортированные даты: ");
			foreach (Data da in dat6) {
				da.print ();
			}
			Console.WriteLine("\n");

			//ex4
			List<Country> cont = new List<Country>() {
				new Country {country = "belarus", sity = "minsk"},
				new Country {country = "kanada", sity = "ottava"}
			};

			List<Continent> cnt = new List<Continent> () {
				new Continent { continent = "europe", country = "belarus" },
				new Continent { continent = "america", country = "kanada" }
			};

			var smt = from co in cont
				join ct in cnt on co.country equals ct.country
				select new {continent = ct.continent, country = ct.country, sity = co.sity};
			foreach (var elems in smt) {
				Console.WriteLine (elems.continent + " - " + elems.country + " - " + elems.sity);
			}

			Console.ReadKey();
		}
	}
}
