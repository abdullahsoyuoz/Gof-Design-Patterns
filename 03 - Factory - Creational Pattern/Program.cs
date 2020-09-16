using System;

namespace _03___Factory___Creational_Pattern
{
    /* Turkish:
     * Oluşturucu Desendir.
     * Factory Pattern'i yapılacak değişiklikleri bir Manager nesnesi üzerinden kontrol etmemizi sağlar.
     * Birde Abstract Factory Pattern vardır. Abstract classların kalıtımlanması görülür.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new FactoryA());  // parametreyi " new FactoryB() " vererek farkı görebilirsiniz..
            manager.Process();
        }
    }

    class Manager
    {
        private IFactoryPrototype _facpro;
        public Manager(IFactoryPrototype _facpro) => this._facpro = _facpro;
        public void Process()
        {
            ISamplePrototype _sample = _facpro.Create();
            _sample.Process();
        }
        
    }

    interface IFactoryPrototype
    {
        ISamplePrototype Create();
    }

    class FactoryA : IFactoryPrototype
    {
        public ISamplePrototype Create()
        {
            return new SampleA();
        }
    }

    class FactoryB : IFactoryPrototype
    {
        public ISamplePrototype Create()
        {
            return new SampleB();
        }
    }

    interface ISamplePrototype
    {
        void Process();
    }

    class SampleA : ISamplePrototype //etc
    {
        public void Process()
        {
            Console.WriteLine("SampleA Process fonksiyonu uygulandı..");
            //todo
        }
    }
    class SampleB : ISamplePrototype //etc
    {
        public void Process()
        {
            Console.WriteLine("SampleB Process fonksiyonu uygulandı..");
            //todo
        }
    }


}
