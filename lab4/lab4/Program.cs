using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Set
    {
        public int kolElems = 1;
        public string[] set;
        public int[] setInt;

        public Set(string zero, int size)//конструктор пустого множества
        {
            set = new string[size];
        }
        public Set()//конструктор ввода множества
        {
            string inputSet, setElem = "";
            char check = ' ';
            int stlen;
            int errNum = 0;

            link1:
            Console.WriteLine("Введите множество: {1, 2, 3}");
            inputSet = Console.ReadLine();
            stlen = inputSet.Length;

            //проверка на корректность введенных данных-----------------------
            if (inputSet[0] == '{' && inputSet[stlen-1] == '}')
            {
                bool flag = false;
                for (int i = 0; i < stlen; i++)
                {
                    if (inputSet[i] == ',') { flag = true; }
                    if (check==',' && inputSet[i] == ',')
                    {
                        errNum = 1;
                    }
                    check = inputSet[i];
                }
                check = ' ';
                if (flag == false) { errNum = 2; }
            }
            else
            {
                errNum = 1;
            }

            if (errNum == 1) { Console.WriteLine("некорректное множество"); goto link1; }
            if (errNum == 2)
            {
                link2:
                Console.WriteLine("множество состоит из одного элемента? 1-да 2-нет");
                int answ;
                answ = Convert.ToInt32(Console.ReadLine());
                if (answ > 0 && answ < 3)
                {
                    if (answ == 1) { }
                    if (answ == 2) { goto link1; }
                }
                else { goto link2; }
            }
            //----------------------------------------------------------------------------

            for (int i = 0; i<stlen; i++)//определение количества элементов множества
            {
                if (inputSet[i]==',') { kolElems++; }
            }

            set = new string[kolElems];
            int j = 0;

            //извлечние элементов множества из строки
            for(int i = 1; i<stlen; i++)
            {
                if (inputSet[i] == ','||inputSet[i]=='}')
                {
                    set[j] = setElem;
                    setElem = "";
                    j++;
                }
                if(inputSet[i]!=' '&&inputSet[i]!=',')
                {
                    setElem += inputSet[i];
                }
            }
            this.convert();
        }

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
            if(result == true) { Console.WriteLine("множество чисел");}
            else { Console.WriteLine("множество строк");}
        }

        public void printSet()
        {
            for(int i = 0; i<kolElems; i++)
            {
                Console.WriteLine(set[i]);
            }
            Console.WriteLine("________________________________________________");
        }

        //перегрузка
        public static Set operator -(Set set1, int num)
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
            Array.Resize(ref set1.set, kol);
            set1.kolElems--;
            return set1;
        }

        public static Set operator *(Set set1, Set set2)
        {
            string type1 = set1.set.GetType().ToString();
            string type2 = set2.set.GetType().ToString();
            int size1 = set1.kolElems;
            int size2 = set2.kolElems;
            int priority, secPrior, k=0;

            if (size1 > size2) { priority = size1; secPrior = size2; }
            else { priority = size2; secPrior = size1; }

            Set set0 = new Set("0", secPrior);
            if (type1 != type2)
            {
                return new Set("0", 0);
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Set set1 = new Set();
            set1.printSet();
            Set set2 = set1 - 2;//удаление второго элемента
            set2.printSet();
            Set set3 = set1 * set2;
            Console.WriteLine("пересечение: " + set3.kolElems + " элемента");
            set3.printSet();
        }
    }
}
