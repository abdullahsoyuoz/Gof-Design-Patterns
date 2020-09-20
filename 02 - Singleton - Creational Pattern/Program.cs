using System;

namespace _02___Singleton___Creational_Pattern
{
    /* Turkish:
     * Oluşturucu Desendir.
     * Bu pattern, Runtime sırasında herhangi bir nesnenin tek bir kez üretildiğini temin eder.
     */

    class Program
    {
        static void Main(string[] args)
        {
            object sampleA = SampleA.Create();
            object sampleB = SampleA.Create();

            Console.WriteLine("Oluşturulan sampleA nesnesinin hash kodu: " + sampleA.GetHashCode());
            Console.WriteLine("Oluşturulan sampleB nesnesinin hash kodu: " + sampleB.GetHashCode());
            
        }
    }

    class SampleA
    {
        private static volatile SampleA _sampleA;   // volatile anahtarı burada tercihtir. Farklı kaynaklardan kullanımına bakabilirsiniz.
        static object _lock = new object();         // multithread singleton
        private SampleA() { }                       // pattern gereği kurucu fonksiyon boş bırakılır
        public static SampleA Create()
        {
            lock(_lock)
            {
                if (_sampleA == null)               // kontrol bloğunda tek satırlık işlemler için parantez kullanılması gerekmiyor.
                    _sampleA = new SampleA();
                return _sampleA;
            }
        }
        //todo
    }
}
