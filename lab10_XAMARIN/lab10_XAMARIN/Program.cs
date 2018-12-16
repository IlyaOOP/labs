using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;


namespace lab10_XAMARIN
{
	class куст : IComparable<куст>
	{
		public int CompareTo(куст obj)
		{
			if (this.length > obj.length) return 1;
			if (this.length < obj.length) return -1;
			else return 0;
		}

		public int length;
		public double prevalence { get; set; }
		public double condition { get; set; }
		public куст(int len, double preval, double cond)
		{
			length = len;
			prevalence = preval;
			condition = cond;
		}
		public override string ToString()
		{
			return (this.GetType() + "\nвысота: " + length + "\nраспространенность: " + prevalence);
		}
		public void print()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(this.GetType());
			Console.ResetColor();
			Console.WriteLine("высота: " + length + "\nраспространенность: " + prevalence);
			Console.ResetColor();
		}
	}
	public static class student
	{
		public static string name = "name";
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			ArrayList list = new ArrayList();

			Random rand = new Random ();
			int temp;

			for (int i = 0; i < 5; i++) {
				temp = rand.Next (100);
				list.Add (temp);
			}
			list.Add("string");
			list.Add (student.name);

			Console.WriteLine("введите номер элемента для удаления: ");
			int num;
			num = Convert.ToInt32(Console.ReadLine ());

			list.RemoveAt (num);
			Console.WriteLine ("count of elements: "+list.Count);
			for (int i = 0; i < list.Count; i++) {
				Console.WriteLine (list[i]);
			}

			Console.WriteLine("введите значение элемента для поиска: ");
			string value;
			value = Console.ReadLine ();
			num = 0;
			bool isparse = Int32.TryParse (value, out num);
			if (isparse == true) {
				Console.WriteLine ("finded value: " + list.IndexOf (num));
			} else {
				Console.WriteLine ("finded value: " + list.IndexOf (value));
			}

			//ex2

			List<float> fl = new List<float>();
			for (int i = 0; i < 10; i++) {
				double tempdbl = rand.NextDouble ();
				float tempfl = (float)tempdbl;
				list.Add (tempfl);
				fl.Add (tempfl);
			}
			for (int i = 0; i < fl.Count; i++) {
				Console.WriteLine (fl[i]);
			}

			a:
			Console.WriteLine ("введите начальную позицию для удаления n последовательных элементов");
			int start = Convert.ToInt32(Console.ReadLine ());
			Console.WriteLine ("введите количество для удаления n последовательных элементов");
			int coun = Convert.ToInt32(Console.ReadLine ());
			if (start > fl.Count||coun>fl.Count-start) {
				goto a;
			}

			fl.RemoveRange (start, coun);

			Console.WriteLine ("удалено "+coun);

			double tempd = rand.NextDouble ();
			float tempfloat = (float)tempd;
			fl.Add (tempfloat);
			fl.Insert (3, tempfloat);
			Console.WriteLine ("добавлено 2");

			Console.WriteLine ("__________________________stack_____________________________");

			Stack<float> st = new Stack<float> ();
			for(int i = 0; i<fl.Count; i++){
				st.Push(fl[i]);
			}
			float[] arrfl = new float[st.Count];
			st.CopyTo (arrfl, 0);
			for (int i = 0; i < st.Count; i++) {
				Console.WriteLine (arrfl[i]);
			}

			Console.WriteLine ("введите значение для поиска: ");
			string valstr = Console.ReadLine ();
			string[] arrst = new string[st.Count];//поиск элемента
			for (int i = 0; i < arrfl.Length; i++) {
				if (valstr == arrfl [i].ToString ()) {
					Console.WriteLine ("значение найдено");
				}
			}


			//ex3

			куст k1 = new куст (1, 0.5, 0.9);
			куст k2 = new куст (2, 0.5, 0.9);
			куст k3 = new куст (3, 0.5, 0.9);
			куст k4 = new куст (4, 0.5, 0.9);
			куст k5 = new куст (5, 0.5, 0.9);
			List<куст> ky = new List<куст>();
			ky.Add (k1);
			ky.Add (k2);
			ky.Add (k3);
			ky.Add (k4);
			ky.Add (k5);
			for (int i = 0; i < ky.Count; i++) {
				Console.WriteLine (ky[i]);
			}

			b:
			Console.WriteLine ("введите начальную позицию для удаления n последовательных элементов");
			int startky = Convert.ToInt32(Console.ReadLine ());
			Console.WriteLine ("введите количество для удаления n последовательных элементов");
			int counky = Convert.ToInt32(Console.ReadLine ());
			if (startky > ky.Count||counky>ky.Count-startky) {
				goto b;
			}

			ky.RemoveRange (startky, counky);

			Console.WriteLine ("удалено "+counky);

			Console.WriteLine ("__________________________stack kyst_____________________________");

			Stack<куст> stky = new Stack<куст> ();
			for(int i = 0; i<ky.Count; i++){
				stky.Push(ky[i]);
			}
			куст[] arrky = new куст[stky.Count];
			stky.CopyTo (arrky, 0);
			for (int i = 0; i < stky.Count; i++) {
				Console.WriteLine (arrky[i]);
			}
				
			//поиск элемента
			куст k6 = new куст(4, 0.5, 0.9);
			for (int i = 0; i < arrky.Length; i++) {
				if (arrky[i].CompareTo(k6) == 0) {
					Console.WriteLine ("результат поиска: значение найдено");
				}
			}

			//----------------
			ObservableCollection<куст> observableCollection = new ObservableCollection<куст>();
			observableCollection.CollectionChanged += Collectionchanged;
			observableCollection.Add(k1);
			observableCollection.Remove(k1);

			Console.ReadKey ();
		}
		static void Collectionchanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			Console.WriteLine("collection changed");
		}
	}
}
