using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    class бумага : растение, IProperties
    {
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
            return (this.GetType() + " произведено в: " + grown_in + "\nдлина: " + height + "\nширина: " + width + "\nраспространенность: " + prevalence);
        }
        public void print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(this.GetType() + " произрастает в: " + grown_in);
            Console.ResetColor();
            Console.WriteLine("длина: " + height + "\nширина: " + width + "\nраспространенность: " + prevalence);
            Console.ResetColor();
        }
    }

    class цветок : растение, IProperties
    {
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
        public цветок(int len, double preval, double cond, string grown) : base(grown)
        {
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
        public роза(int len, double preval, double cond, string grown, string clr) : base(len, preval, cond, grown)
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
        public гладиолус(int len, double preval, double cond, string grown, string clr) : base(len, preval, cond, grown)
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
        public кактус(int len, double preval, double cond, string grown, string clr) : base(len, preval, cond, grown)
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

    class букет : цветок
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
    }
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

    class Program
    {
        static void Main(string[] args)
        {
            куст kyst = new куст(100, 0.1, 1, "belarus");
            kyst.print();

            бумага paper = new бумага(100, 90, 1, 0, "belarus");
            paper.print();

            цветок flower = new цветок(15, 0.9, 0.5, "belarus");
            flower.print();

            роза rose = new роза(40, 0.7, 0.5, "England", "white");
            rose.print();

            object[] objarr = { flower, rose };
            букет bouquet = new букет(15, 0.5, 1, "belarus", objarr);
            bouquet.print();

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
            spisok.Add(bouquet);
            Console.WriteLine(pr.iAmPrinting(spisok[0]));
            Console.WriteLine(pr.iAmPrinting(spisok[1]));
            Console.WriteLine(pr.iAmPrinting(spisok[2]));
            Console.WriteLine(pr.iAmPrinting(spisok[3]));
            Console.WriteLine(pr.iAmPrinting(spisok[4]));
        }
    }
}
