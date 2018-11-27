using System;
using System.Collections.Generic;

namespace Растение
{
	sealed partial class куст : растение
	{
		public override bool plant_living()
		{
			throw new NotImplementedException(); // метод не реализован, но будет реализован в будущем
		}
	}

	class букет : List<Object>
	{
		public int count = 0; 
		public букет(params object[] list)
		{
			for (int i = 0; i < list.Length; i++) {
				this.Add (list [i]);
				count++;
			}
		}

		public void DelObj(int n)
		{
			this.RemoveAt (n);
			count--;
		}

		public void PrintBouqet()
		{
			foreach (object o in this) {
				Console.WriteLine (o);
			}
		}
	}

	class Controller : букет
	{
		public int cost(букет b)
		{
			int cost = 0, nr;
			Random r = new Random ();
			for (int i = 0; i < b.count; i++) {
				nr = r.Next (1, 100);
				cost+=nr;
			}
			return cost;
		}

		public void sort(букет bq)
		{
			Console.WriteLine ("Состояние |  плохо  |  хорошо  |  отлично");

			for (int i = 0; i < bq.count; i++) {
				цветок fl = new цветок (0, 0, 0, "", "");
				fl = (цветок)bq [i];
				if (fl.condition == 0) {
					Console.WriteLine ("          " + fl.GetType ());
				} else if (fl.condition >= 0 && fl.condition <= 0.5) {
					Console.WriteLine ("                   " + fl.GetType ());
				} else {
					Console.WriteLine ("                               " + fl.GetType ());
				}
			}
		}

		public void findbycolor(букет bq, string col)
		{
			for (int i = 0; i < bq.count; i++) {
				цветок fl = new цветок (0, 0, 0, "", "");
				fl = (цветок)bq [i];
				if (fl.color == col) {
					Console.WriteLine (fl);
				}
			}
		}
	}
}
