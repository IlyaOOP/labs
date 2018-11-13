using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Растение
{
    interface IProperties
    {
        double prevalence { get; set; }
        double condition { get; set; }
    }

    abstract class растение : IProperties
    {
        public string grown_in;
        public abstract double prevalence { get; set; }
        public abstract double condition { get; set; }
        public растение(string a)
        {
            grown_in = a;
        }
    }

    class куст : растение
    {
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
            return (this.GetType() + " произрастает в: " + grown_in + " высота: " + length + " распространенность: " + prevalence);
        }
    }

    class бумага : растение
    {
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
            return (this.GetType() + " произведено в: " + grown_in + " длина: " + height + " ширина: " + width + " распространенность: " + prevalence);
        }
    }

    class цветок : растение
    {
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
            return (this.GetType() + " произрастает в: " + grown_in + " высота: " + length + " распространенность: " + prevalence);
        }
    }

    class роза : цветок
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            куст kyst = new куст(100, 0.1, 1, "belarus");
            Console.WriteLine(kyst.ToString());

            бумага paper = new бумага(100, 90, 1, 0, "belarus");
            Console.WriteLine(paper.ToString());

            цветок flower = new цветок(15, 0.9, 0.5, "belarus");
            Console.WriteLine(flower.ToString());
        }
    }
}
