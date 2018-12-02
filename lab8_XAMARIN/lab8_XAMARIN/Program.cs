using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab8_XAMARIN
{
	interface IInterface<T>
	{
		void add(T obj);
		void del(T obj);
		void display();
	}

	public class CollectionType<T> : List<T>, IInterface<T>
	{
		public void add(T obj)
		{
			this.Add(obj);
		}
		public void display()
		{
			Console.WriteLine("__________________________________________________________________________________________________________________");
			Console.Write ("{");
			foreach (T l in this)
			{
				Console.Write(l + ", ");
			}
			Console.WriteLine ("}");
			Console.WriteLine("__________________________________________________________________________________________________________________");
		}
		public void savetofile()
		{
			using (FileStream fstream = new FileStream(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab8_XAMARIN\collection.txt", FileMode.OpenOrCreate))
			{
				fstream.Seek(0, SeekOrigin.End);
				string text = "{";
				foreach (T l in this)
				{
					text += l + ",";
				}
				text += "}||type " + this[0].GetType() + "\r\n";
				// преобразуем строку в байты
				byte[] array = System.Text.Encoding.Default.GetBytes(text);
				// запись массива байтов в файл
				fstream.Write(array, 0, array.Length);
				Console.WriteLine("Текст записан в файл");
			}
		}
		public void readfromfile()
		{
			using (FileStream fstream = File.OpenRead(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab8_XAMARIN\collection.txt"))
			{
				// преобразуем строку в байты
				byte[] array = new byte[fstream.Length];
				// считываем данные
				fstream.Read(array, 0, array.Length);
				// декодируем байты в строку
				string textFromFile = System.Text.Encoding.Default.GetString(array);
				Console.WriteLine("Текст из файла: \n{0}", textFromFile);
			}
		}
		public void del(T obj)
		{
			if (this.Count > 0)
				this.Remove(obj);
			else throw new Exception("ERROR");
		}

		public int kolElems = 1;
		public string[] set;
		public int[] setInt;
		public bool isnum = false;


		public CollectionType()
		{
			
		}
		public CollectionType(string zero, int size)//конструктор пустого множества
		{
			set = new string[size];
		}

		public class Owner
		{
			public int Id;
			public string Name;
			public string organisation;
			public Owner(int Id, string Name, string organisation)
			{
				this.Id = Id;
				this.Name = Name;
				this.organisation = organisation;
			}
		}
		public Owner owner = new Owner(1, "Ilya", "BSTU");

		public class Date
		{
			int day;
			int month;
			int year;
			public Date(int day, int month, int year)
			{
				this.day = day;
				this.month = month;
				this.year = year;
			}
			public override string ToString()
			{
				return "{this.day}.{this.month}.{this.year}";
			}
		}
		public Date date = new Date(31, 10, 18);

		public void convert()
		{
			//конвертация множества в int
			setInt = new int[kolElems];
			bool result=false;
			for(int i =0; i<kolElems; i++)
			{
				result = int.TryParse(set[i], out setInt[i]);
				if (result == false) { break; }
			}
			if(result == true) { Console.WriteLine(" "); isnum = true; }
			else { Console.WriteLine("");}
		}

		public void printSet()
		{
			Console.WriteLine("________________________________________________");
			for(int i = 0; i<kolElems; i++)
			{
				Console.WriteLine(set[i]);
			}
			Console.WriteLine("________________________________________________");
		}

		public void destroyCollision()
		{
			for(int i = 0; i < this.kolElems; i++)
			{
				for(int j=0; j < this.kolElems; j++)
				{
					if (this.set[i] == this.set[j]&&i!=j)
					{
						bool flag = false;
						int kol = this.kolElems;
						for (int k = 0; k < kol-1; k++)
						{
							if (k == j)
							{
								flag = true;
							}
							if (flag == true)
							{
								this.set[k] = this.set[k + 1];
							}
						}
						Array.Resize(ref this.set, kol);
						this.kolElems--;
					}
				}
			}
		}

		//перегрузка
		public static CollectionType<T> operator -(CollectionType<T> set1, int num)
		{
			Type type = set1.set.GetType();
			string tp = type.ToString();
			bool flag = false;
			int kol = set1.kolElems;
			for (int i = 0; i<kol-1; i++)
			{
				if (i == num-1)
				{
					flag = true;
				}
				if(flag == true)
				{
					set1.set[i] = set1.set[i + 1];
				}
			}
			Array.Resize(ref set1.set, kol-1);
			set1.kolElems--;
			return set1;
		}

		public static CollectionType<T> operator *(CollectionType<T> set1, CollectionType<T> set2)
		{
			string type1 = set1.set.GetType().ToString();
			string type2 = set2.set.GetType().ToString();
			int size1 = set1.kolElems;
			int size2 = set2.kolElems;
			int priority, secPrior, k=0;

			if (size1 > size2) { priority = size1; secPrior = size2; }
			else { priority = size2; secPrior = size1; }

			CollectionType<T> set0 = new CollectionType<T>("0", secPrior);
			if (type1 != type2)
			{
				return new CollectionType<T>("0", 0);
			}

			for(int i = 0; i<size1; i++)
			{
				for(int j = 0; j<size2; j++)
				{
					if (set1.set[i] == set2.set[j])
					{
						set0.set[k] = set1.set[i];
						k++;
					}
				}
			}
			Array.Resize(ref set0.set, k);
			set0.kolElems = k;
			set0.convert();

			return set0;
		}

		public static CollectionType<T> operator <(CollectionType<T> set1, CollectionType<T> set2)
		{
			string type1 = set1.set.GetType().ToString();
			string type2 = set2.set.GetType().ToString();
			string setnotequal = "множества не равны";
			string setequal = "множества равны";
			int size1 = set1.kolElems;
			int size2 = set2.kolElems;
			int kolisions=0;
			bool notequal=false, equal = false;

			if (size1 != size2) { notequal = true; }
			else { equal = true; }

			if(equal)
			{
				for(int i =0; i<size2; i++)
				{
					for(int j = 0; j<size1; j++)
					{
						if(set1.set[i] == set2.set[j])
						{
							kolisions++;
						}
					}
				}
				if (kolisions == size2)
				{
					Console.WriteLine(setequal);
				}
				else if(kolisions != size2)
				{
					Console.WriteLine(setnotequal);
				}
			}
			else if (!equal)
			{
				Console.WriteLine(setnotequal);

			}
			return set1;
		}

		public static CollectionType<T> operator >(CollectionType<T> set1, CollectionType<T> set2)
		{
			string type1 = set1.set.GetType().ToString();
			string type2 = set2.set.GetType().ToString();
			string subsetAB = "множество В является подмножеством А";
			string subsetBA = "множество А является подмножеством В";
			int size1 = set1.kolElems;
			int size2 = set2.kolElems;
			int kolisions = 0;
			bool firstmain = false, secmain = false, equal = false;

			if (size1 > size2) { firstmain = true; }
			else if (size2 > size1) { secmain = true; }
			else { equal = true; }

			if (equal) { Console.WriteLine("Равное количество элементов в множествах. Для проверки на равность множест используйте оператор '<'"); }
			else if (firstmain)
			{
				for (int i = 0; i < size2; i++)
				{
					for (int j = 0; j < size1; j++)
					{
						if (set1.set[j] == set2.set[i])
						{
							kolisions++;
						}
					}
				}
				if (kolisions == size2)
				{
					Console.WriteLine(subsetAB);
					return set2;
				}
			}
			else if (secmain)
			{
				for (int i = 0; i < size1; i++)
				{
					for (int j = 0; j < size2; j++)
					{
						if (set1.set[i] == set2.set[j])
						{
							kolisions++;
						}
					}
				}
				if (kolisions == size1)
				{
					Console.WriteLine(subsetBA);
					return set1;
				}
			}
			return new CollectionType<T>("0", 0);
		}

		public static CollectionType<T> operator &(CollectionType<T> set1, CollectionType<T> set2)
		{
			CollectionType<T> set0 = new CollectionType<T>("null", 0);
			string type1 = set1.set.GetType().ToString();
			string type2 = set2.set.GetType().ToString();
			if (type1 != type2) { return set0; }
			int size1 = set1.kolElems;
			int size2 = set2.kolElems;
			int fullsize;

			fullsize = size1 + size2;
			Array.Resize(ref set0.set, fullsize);
			for(int i=0; i<fullsize; i++)
			{
				if (i < size1)
				{
					set0.set[i] = set1.set[i];
				}
				else if (i >= size1)
				{
					set0.set[i] = set2.set[i - size1];
				}
			}
			set0.kolElems = fullsize;
			set0.destroyCollision();
			return set0;
		}
	}

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

		class куст : растение, IProperties
		{
			bool IProperties.plant_living()//реализация метода интерфейса
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

	static class display_userColl<T> where T : куст
	{
		public static void display_usertype(куст t)
		{
			Console.WriteLine (t.GetType() + "\n");
		}
	}

	class MainClass
	{

		public static void Main (string[] args)
		{
			try
			{
				CollectionType<string> collstring = new CollectionType<string>();
				collstring.add("a");
				collstring.add("b");
				collstring.add("c");
				collstring.add("d");
				collstring.del("d");
				collstring.display();
				collstring.savetofile();

				CollectionType<int> collint = new CollectionType<int>();
				collint.add(1);
				collint.add(2);
				collint.add(3);
				collint.add(3);
				collint.del(3);
				collint.display();

				CollectionType<куст> usercoll = new CollectionType<куст>();
				куст a1 = new куст(10, 0.5, 1, "Belarus");
				куст a2 = new куст(10, 0.5, 1, "Belarus");
				usercoll.add(a1);
				usercoll.add(a2);
				usercoll.add(a2);
				usercoll.del(a2);
				usercoll.display();
				display_userColl<куст>.display_usertype(a1);

			}
			catch (Exception ex) { Console.WriteLine(ex); Console.ReadKey (); }
			finally { Console.WriteLine("Completed"); Console.ReadKey ();}
		}
	}
}
