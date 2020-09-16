using System;

namespace _01___Dependency_Injection
{
    /* Turkish:
     * Dependency Injection yapısı sınıflar arası bağlılığı azaltmaya yarayan bir tekniktir.
     * bu yapı sayesinde daha modüler bir proje ortaya çıkmaktadır.
     * ilerideki pattern'lerde sık karşılaşabileceğimiz bir yapıdır.
     */

    class Program
    {
        static void Main(string[] args)
        {
            SampleProvider _sp = new SampleProvider( new SampleA());
        }
    }

    class SampleProvider    //Dependency Injection Model
    {
        private ISamplePrototype _sample;
        public SampleProvider(ISamplePrototype _sample)
        {
            this._sample = _sample;
        }
        public void ProcessA() //etc
        {
            //todo
        }
    }

    interface ISamplePrototype
    {
        public void ProcessB();
    }

    class SampleA : ISamplePrototype
    {
        public SampleA()
        {
            ProcessB();
        }
        public void ProcessB()
        {
            Console.WriteLine("SampleA.ProcessB() is running..");
        }
    }


}
