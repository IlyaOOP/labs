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
        public bool isnum = false;

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
            errNum = 0;
            Console.WriteLine("Введите множество: {1, 2, 3}");
            inputSet = Console.ReadLine();
            stlen = inputSet.Length;
            if(stlen == 0) { goto link1; }

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
                string answer;
                answer = Console.ReadLine();
                if (answer.Length == 0) { goto link1; }
                answ = Convert.ToInt32(answer);
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
                    if (setElem == "") { setElem = " "; }
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
            this.destroyCollision();
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
                return $"{this.day}.{this.month}.{this.year}";
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
            Array.Resize(ref set1.set, kol-1);
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

        public static Set operator <(Set set1, Set set2)
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

        public static Set operator >(Set set1, Set set2)
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
            return new Set("0", 0);
        }

        public static Set operator &(Set set1, Set set2)
        {
            Set set0 = new Set("null", 0);
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

    static class MathObject
    {
        public static int Findmax(Set s)
        {
            int max = 0;
            if (s.isnum != true) { Console.WriteLine("данное множество не является множеством чисел"); return 0; }
            else
            {
                for (int i = 0; i < s.kolElems; i++)
                {
                    if (s.setInt[i] > max) { max = s.setInt[i]; }
                }
            }
            return max;
        }

        public static int Findmin(Set s)
        {
            int min = 0;
            if (s.isnum != true) { Console.WriteLine("данное множество не является множеством чисел"); return 0; }
            else
            {
                min = s.setInt[0];
                for (int i = 0; i < s.kolElems; i++)
                {
                    if (s.setInt[i] < min) { min = s.setInt[i]; }
                }
            }
            return min;
        }

        public static int amount(Set s)
        {
            int am = 0;
            am = s.set.Length;
            return am;
        }

        public static string addot(this string str)//метод расширения для string
        {
            str += ".";
            return str;
        }

        public static int destroyNULL(this Set set)
        {
            int kolelems = set.kolElems;
            for (int i = 0; i < kolelems; i++)
            {
                if (set.set[i] == ""||set.set[i]==" ")
                {
                    set = set - (i+1);
                    kolelems--;
                }
            }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Set set1 = new Set();
            Set set2 = new Set();
            set1.printSet();
            set2.printSet();
            set2 = set2 - 2;//удаление второго элемента
            set2.printSet();
            Set set3 = set1 * set2;
            Console.WriteLine("пересечение: " + set3.kolElems + " элемента");
            set3.printSet();
            Set set4 = set1 < set2;//проверка на равность
            Set set5 = set1 > set2;//проверка на подмножество
            Set set6 = set1 & set2;//объединение множеств
            set6.printSet();
            Console.WriteLine(MathObject.addot("string"));
            Set set7 = new Set();
            set7.printSet();
            MathObject.destroyNULL(set7);
            set7.printSet();
        }
    }
}
