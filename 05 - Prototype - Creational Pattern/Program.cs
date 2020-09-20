using System;

namespace _05___Prototype___Creational_Pattern
{
    /*
     * Turkish:
     * Oluşturucu Desendir.
     * Prototype Pattern'i nesne kopyalamadır fakat kopya nesnenin bellek adresi farklıdır.
     * bkz. MemberWiseClone
     */
    class Program
    {
        static void Main(string[] args)
        {
            ModelA instance = new ModelA { _kod = 90, _ulke = "Türkiye" };
            var copy = instance.Clone();

            Console.WriteLine("instance hash code: "+instance.GetHashCode());
            Console.WriteLine("copy hash code: "+copy.GetHashCode());
        }
    }

    abstract class ModelPrototype
    {
        public int _kod { get; set; }
        public string _ulke { get; set; }
        public abstract ModelPrototype Clone();
    }

    class ModelA : ModelPrototype
    {
        public override ModelPrototype Clone()
        {
            return (ModelPrototype)MemberwiseClone();
        }
    }
}
