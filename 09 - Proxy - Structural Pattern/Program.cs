using System;
using System.Diagnostics;
using System.Threading;

namespace _09___Proxy___Structural_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleProcessProxy _spp = new SampleProcessProxy();
            _spp.Calculate("merhaba");
            _spp.Calculate("merhaba");
        }
    }

    abstract class SampleProcessBase
    {
        public abstract string Calculate(string message);
    }

    class SampleProcess : SampleProcessBase
    {
        public override string Calculate(string message)
        {
            Thread.Sleep(2000); // olayı anlamak için, farzedelim ki işlemci ağır hesaplama yapıyor, bunu simüle etmek adına uyutuyoruz..
            Console.WriteLine(message + " >> From Calculate() result");
            return message;
        }
    }

    class SampleProcessProxy : SampleProcessBase
    {
        private SampleProcess _sample;
        private string _cached;
        public override string Calculate(string message)
        {
            if (this._sample == null)
            {
                this._sample = new SampleProcess();
                this._cached = this._sample.Calculate(message);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(message + " >> From cache");
                }
            }
            return _cached;
        }
    }
}
