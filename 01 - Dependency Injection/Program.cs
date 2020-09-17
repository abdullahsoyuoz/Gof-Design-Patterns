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
            SampleProvider _sp = new SampleProvider( new SampleA());    // SampleB gibi farklı bir sınıfı parametre girebiliriz.
        }
    }

    class SampleProvider    //Dependency Injection Model
    {
        private ISamplePrototype _sample;
        public SampleProvider(ISamplePrototype _sample) // kurucu fonksiyona SampleB gibi benzer farklı sınıf gönderebilmek için temel alan interface'i tanımlarız
        {
            this._sample = _sample;
        }
        public void Process() //etc
        {
            //todo
        }
    }

    interface ISamplePrototype
    {
        public void Process();
    }

    class SampleA : ISamplePrototype
    {
        public SampleA()
        {
            Process();
        }
        public void Process()
        {
            Console.WriteLine("SampleA.Process() is running..");
        }
    }
    
    class SampleB : ISamplePrototype
    {
        public SampleB()
        {
            Process();
        }
        public void Process()
        {
            Console.WriteLine("SampleB.Process() is running..");
        }
    }


}
