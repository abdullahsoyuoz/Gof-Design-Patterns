using System;

namespace _07___Adapter___Structural_Pattern
{
    /*
     * Turkish:
     * Oluşturucu Desendir.
     * Dışarıdan projemize entegre etmek istediğimiz sınıfların, projemize adaptasyonunu sağlayan yapıdır.
     * Örnek üzerinde hali hazırda bir SampleA sınıfımız var ve 
     * SampleX adında kullanmak istediğimiz bir yapıyı entegre etmek için; SampleXAdapter sınıfı yazıyoruz.
     * SampleXAdapter kod bloğunu iyi inceleyiniz.
     */
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
