using System;

namespace _01___Dependency_Injection
{
    /* Turkish:
     * Dependency Injection yapısı sınıflar arası bağlılığı azaltmaya yarayan bir tekniktir.
     * bu yapı sayesinde daha modüler bir kodlama ortaya çıkmaktadır.
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
        public SampleProvider(ISamplePrototype _sample) // *1
        {
            this._sample = _sample;
        }
        public void Process() //etc
        {
            //todo
        }
    }
    //  *1 : kurucu fonksiyona SampleA gibi aynı interface'i implemente alan farklı bir SampleB gibi bir sınıf göndermek için
    //  interface nesnesi parametre ediyoruz

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
    
    //class SampleB : ISamplePrototype
    //{
    //    public SampleB()
    //    {
    //        Process();
    //    }
    //    public void Process()
    //    {
    //        Console.WriteLine("SampleB.Process() is running..");
    //    }
    //}
}
