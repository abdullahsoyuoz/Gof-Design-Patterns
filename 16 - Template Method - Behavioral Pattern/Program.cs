using System;

namespace _16___Template_Method___Behavioral_Pattern
{
    /*
     * Turkish:
     * Davranışsal Desendir.
     * Algoritma farklı koşul hesaplamalarına karşı pratik bir çözüm getirmektedir.
     *      Burada püf nokta, hesaplamalar nihayetinde benzer adımlardan geçmesi ve
     *      buna kasten HandleBase'in bu adımları içermesi ve farklı sınıfların HandleBase'den türetilmesidir.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("bir Sayı girin: ");
            double item = double.Parse(Console.ReadLine());

            HandleBase handle = new ConditionA();
            Console.WriteLine("A kondisyonu: "+handle.Calculate(5));

            handle = new ConditionB();
            Console.WriteLine("B Kondisyonu: "+handle.Calculate(5));
        }
    }

    abstract class HandleBase
    {
        public abstract double Calculate(double item);
    }

    class ConditionA : HandleBase
    {
        public override double Calculate(double item)
        {
            return Math.Pow(item,2);
        }
    }
    class ConditionB : HandleBase
    {
        public override double Calculate(double item)
        {
            return Math.Pow(item,3);
        }
    }
}
