using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)//статический метод Main
        {
            sbyte num1 = 1;//хранит целое число от -128 до 127 и занимает 1 байт.
            short num2 = 2;//хранит целое число от -32768 до 32767 и занимает 2 байта.
            int num3 = 3;//хранит целое число от -2147483648 до 2147483647 и занимает 4 байта.
            long num4 = 4;//хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт.
            byte num5 = 5;//хранит целое число от 0 до 255 и занимает 1 байт.
            ushort num6 = 6;//хранит целое число от 0 до 65535 и занимает 2 байта.
            uint num7 = 7;//хранит целое число от 0 до 4294967295 и занимает 4 байта.
            ulong num8 = 8;//хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт.
            char ch = 'a';//хранит одиночный символ в кодировке Unicode и занимает 2 байта.
            bool flag = true;
            float fl = 1.1223f;//хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта. f в конце переменной указыает на тип float
            double dbl = 0.256;//хранит число с плавающей точкой от ±5.0*10-324 до ±1.7*10308 и занимает 8 байта.
            decimal dcm = 0.2128865m;//хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет значение от 0 до +/–79 228 162 514 264 337 593 543 950 335; если с запятой, то от 0 до +/–7,9228162514264337593543950335 с 28 разрядами после запятой и занимает 16 байт.
            string str = "asdfg";//хранит набор символов Unicode
            object obj = "hbhb";//может хранить значение любого типа данных и занимает 4 байта на 32 - разрядной платформе и 8 байт на 64 - разрядной платформе.


            //неявное приведение
            byte a = 5;
            Int16 b = a;
            int c = b;
            float d = c;
            double e = d;
            //явное преобазование||byte>short>int>long>float>double
            decimal a1 = (decimal)a;
            Int64 a2 = (Int64)a1;
            Int32 a3 = (Int32)a2;
            Int16 a4 = (Int16)a3;
            byte a5 = (byte)a4;


            //упаковка и распаковка
            int var = 3;
            object obj_var = var;//упаковка
            int get_var = (int)obj_var;//распаковка

            //неявно типизированная переменная
            //var num = NULL;
            var num = 10;
            num++;
            num = num3 + num;


            //Nullable-переменная
            int? q = null;
            int w = q ?? 1;


            //2)строки
            //строковые литералы
            string patch;
            patch = "C:\\users";
            patch = @"c:\users";//буквальный сроковый литерал
            patch = "C:/users";

            //создать строки на основе string
            string str1 = "string1";
            string str2 = "string2";
            string str3 = "string3";

            string s4 = string.Concat(str1, str2);
            string s5 = string.Copy(str3);
            string s6 = str1.Substring(4);//запишет строку начиная с 4 символа
            string[] s7 = str2.Split('i');//будет содержать 2 элемента массива
            string s8 = str3.Insert(6, " ");//вставит пробел перед числом
            string s9 = str3.Remove(6);//удалит цифру

            //создать пустую и NULL строку
            string s = "";
            string s_NULL = null;

            if (s == s_NULL) { Console.WriteLine("true"); }
            s = string.Concat(s, s_NULL);

            //создать строку на основе stringbuilder
            StringBuilder sb = new StringBuilder("hello" ,50);
            sb = sb.Remove(2, 1);
            sb = sb.Insert(0, "h");
            sb = sb.Append('o');


            //массивы
            Console.WriteLine("двумерный массив:");
            int[,] arr = { {1, 2, 3}, {1, 2, 3} };
            for (int i = 0; i < 2; i++) { for (int j = 0; j < 3; j++) { if (i == 1&&flag == true) { Console.WriteLine(""); flag = false; };
                    Console.Write(arr[i, j]); } }
            Console.WriteLine("");
            //создать одномерный массив строк
            Console.WriteLine("массив строк:");
            string[] s_arr = {"qwe", "rty", "uio"};
            for (int i = 0; i < 3; i++) { Console.WriteLine(s_arr[i]); }

            Console.WriteLine("Length: " + s_arr.Length);//длина массива

            //замена элемента
            Console.WriteLine("введите позицию элемента который необходимо заменить");
            try
            {
                int pos;
                pos = Convert.ToInt32(Console.ReadLine());

                Console.Write("введите элемент\n");//-------------------------------------------------
                string change_elem;
                change_elem = Convert.ToString(Console.ReadLine());

                if (pos > 2)
                    Console.WriteLine("массив содержит всего 3 элемента");
                else
                {
                    s_arr[pos] = change_elem;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка ввода" /*+ ex*/);
            }
    Console.WriteLine("полученный массив:");
            for(int i=0; i < 3; i++) { Console.WriteLine(s_arr[i]); }

            //создать ступенчатый массив
            int[][] stepped_arr = new int[3][];
            stepped_arr[0] = new int[2];
            stepped_arr[1] = new int[3];
            stepped_arr[2] = new int[4];

            int number;
            for (int i = 0; i < 9; i++)//заполнение ступенчатого массива66
            {
                Console.WriteLine("введите число");
                number = Convert.ToInt32(Console.ReadLine());
                if (i < 2) { stepped_arr[0][i] = number; }
                if (i >= 2 && i < 5) {stepped_arr[1][i-2] = number; }
                if (i >= 5 && i < 9) { stepped_arr[2][i - 5] = number; }
            }

            for (int i = 0; i < 9; i++)//вывод
            {
                if (i < 2) { Console.Write(stepped_arr[0][i] + " ");}
                if (i == 1) { Console.WriteLine(""); }
                if (i >= 2 && i < 5) { Console.Write(stepped_arr[1][i - 2] + " ");}
                if (i == 4) { Console.WriteLine(""); }
                if (i >= 5 && i < 9) { Console.Write(stepped_arr[2][i - 5] + " ");}
                if (i == 8) { Console.WriteLine(""); }
            }

            //неявно типизированные переменные
            var t_arr = new []{1, 2, 3, 4, 5};
            var t_str = "asdf";


            //кортежи
            Console.WriteLine("вывод кортежей целиком и выборочно");
            (int number, string smstring, char smchar, string anotherstring, ulong ylong) kort = (1, "asd", 'c', "str", 123);//іменование
            Console.WriteLine(kort);
            Console.WriteLine(kort.number + " " + kort.smchar + " " + kort.ylong);

            //распаковка в переменные
            var (one, two, three, four, five) = kort;

            //сравнение двух кортежей
            Console.WriteLine("сравнение кортежей");
            (int number2, string smstring2, char smchar2, string anotherstring2, ulong ylong2) kort2 = (1, "asd", 'в', "str", 123);
            Console.WriteLine(kort.Equals(kort2));

            Console.WriteLine("локальная функция:  ");
            //локальная функция
            (int, int, int, string) locfun(int[,] array, string str23)
            {
                int min = Int32.MaxValue;
                int max = Int32.MinValue;
                int sum = 0;
                foreach (int i in arr)
                {
                    sum += i;//нахождение суммы
                    if (i < min)//нахождение минимального элемента
                    {
                        min = i;
                    }
                }
                foreach (int i in arr)
                {
                    if (i > max)//нахождение максимального элемента
                    {
                        max = i;
                    }
                }
                return (min, max, sum, str3.Substring(0, 1));
            }
            Console.WriteLine($"{locfun(arr, str1)}");
        }
    }
}