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
        static int count = 0;
        int day;
        int month;
        int year;
        public static int type;//используется для запрашивания даты 01/01/2018 или 1 января 2018 года
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
            ID = this.GetHashCode();
        }

        private Data(int d, int m)//закрытый конструктор
        {
            this.day = d;
            this.month = m;
        }

        public static void Return_count()
        {
            Console.WriteLine($"Создано {count} объектов");
        } //Счётчик

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

    public partial class part1
    {
        public void first()
        {
            Console.WriteLine("I'm first");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int f;
            string fs = null;
            int rDay, rMonth, rYear;

            Console.WriteLine("Выберите формат даты: 1-'00/00/0000', 2-'00 января 0000 года'");

            while (string.Equals(fs, "1") != true && string.Equals(fs, "2") != true)
            {
                fs = Console.ReadLine();
            }
            f = Convert.ToInt32(fs);
            Data.type = f;

            Data now = new Data();//объект1

            Data sec = new Data(31, 45, 2019);//объект2
            sec.accs_month = 5;//свойство
            sec.print();//метод

            Data.Return_count();

            Console.WriteLine("сравнение объектов: " + now.Equals(sec));

            Console.WriteLine("тип второго объекта: " + sec.GetType());

            Console.WriteLine("введите информация для расчета промежутка времени");
            link1:
            Console.WriteLine("день:");
            string strDay = Console.ReadLine();
            try
            {
                rDay = Convert.ToInt32(strDay);
                if (rDay > 31 || rDay < 1) { Console.WriteLine("ERROR"); goto link1;}
            }
            catch
            {
                Console.WriteLine("ERROR");
                goto link1;
            }
            link2:
            Console.WriteLine("месяц:");
            string strMonth = Console.ReadLine();
            try
            {
                rMonth = Convert.ToInt32(strMonth);
                if (rMonth > 12 || rMonth < 1) { Console.WriteLine("ERROR"); goto link2;}
            }
            catch
            {
                Console.WriteLine("ERROR");
                goto link2;
            }
            link3:
            Console.WriteLine("год:");
            string strYear = Console.ReadLine();
            try
            {
                rYear = Convert.ToInt32(strYear);
            }
            catch
            {
                Console.WriteLine("ERROR");
                goto link3;
            }

            int time;//функция с ref и out параметрами
            Data.period(ref rDay, ref rMonth, ref rYear, out time);

            part1 obj = new part1();
            Console.WriteLine("partial classes");
            obj.first();
            obj.second();

            //массив из элементов типа data
            Data[] array = new Data[]
            {
                new Data(5,3,2018),
                new Data(29,6,2019),
                new Data(21,12,2002)
            };

            //список дат для заданного года
            int inp_year;
            Console.WriteLine("введите год:");
            inp_year = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i<3; i++)
            {
                if (array[i].accs_year == inp_year)
                {
                    array[i].print();
                }
            }
            //список дат, которые имеют заданное число
            int inp_day;
            Console.WriteLine("введите день:");
            inp_day = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                if (array[i].accs_day == inp_day)
                {
                    array[i].print();
                }
            }

            // Создайте и выведите анонимный тип
            Console.WriteLine("анонимный тип:");
            var anonym = new Data();
            Console.WriteLine(anonym);
        }
    }
}
