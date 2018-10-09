using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Data
    {
        //массив с названиями месяцев
        string[] arr = { "", "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
        public const int maxDay = 31;
        public const int maxMonth = 12;
        static int count;
        int day;
        int month;
        int year;
        public static int type;//используется для запрашивания даты 01/01/2018 или 1 января 2018 года
        public readonly int ID;//поле тоько для чтения

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

        static Data()
        {
            Console.WriteLine("Статический конструктор");
            count++;
        }

        public Data() {//конструктор с параметрами по умолчанию
            day = 5;
            month = 1;
            year = 2018;
            ID = this.GetHashCode();
        }

        public Data(int d, int m, int y)//конструктор с параметрами
        {
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
            ID = this.GetHashCode();
        }

        private Data(int d, int m)//закрытый конструктор
        {
            this.day = d;
            this.month = m;
        }

        public static void return_count()
        {
            Console.WriteLine("количество объектов: " + count);
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

        public static void period(ref int a, ref int b, ref int c, out int time)
        {
            DateTime date1 = new DateTime();
            date1 = DateTime.Now;
            string date = Convert.ToString(date1);
            string[] words = date.Split(new char[] { '.' });
            words[2] = words[2].Substring(0, words[2].Length - 9);
            int now_time_in_days = (Convert.ToInt32(words[0])) + (Convert.ToInt32(words[1])) * 30 + (Convert.ToInt32(words[2])) * 365;
            int input_time_in_days = a + b * 30 + c * 365;
            Console.WriteLine("до введенной вами даты "+(input_time_in_days-now_time_in_days)+ " дней");
            time = input_time_in_days - now_time_in_days;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int f;
            string fs = null;

            Console.WriteLine("Выберите формат даты: 1-'00/00/0000', 2-'00 января 0000 года'");

            while (string.Equals(fs, "1") != true && string.Equals(fs, "2") != true)
            {
                fs = Console.ReadLine();
            }
            f = Convert.ToInt32(fs);
            Data.type = f;

            Data now = new Data();
            now.print();

            Data sec = new Data(31, 45, 2019);
            sec.accs_month = 5;
            sec.print();

            Data.return_count();

            Console.WriteLine("введите информация для расчета промежутка времени");
            Console.WriteLine("день:");
            int rDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("месяц:");
            int rMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("год:");
            int rYear = Convert.ToInt32(Console.ReadLine());

            int time;//функция с ref и out параметрами
            Data.period(ref rDay, ref rMonth, ref rYear, out time);

            Console.ReadKey();
        }
    }
}
