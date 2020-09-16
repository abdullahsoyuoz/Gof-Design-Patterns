using System;

namespace _07___Adapter___Structural_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new SampleXAdapter());        // Parametreye Adapter girilir.
            manager.Process();
        }
    }

    class Manager
    {
        private ISample _sample;
        public Manager(ISample _sample) => this._sample = _sample;
        public void Process() => _sample.Process();
    }

    interface ISample
    {
        void Process();
    }

    class SampleA : ISample             // normalde kullanılan yapı
    {
        public void Process()
        {
            Console.WriteLine("SampleA running...");
        }
    }

    class SampleX                       // dışarıdan çektiğimiz yapı
    {
        public void Operation()
        {
            Console.WriteLine("SampleX running...");
        }
    }

    class SampleXAdapter : ISample      // projemize adaptasyonu sağlayacak blok
    {
        public SampleX samplex;
        public void Process()
        {
            samplex = new SampleX();
            samplex.Operation();
        }
    }
}
