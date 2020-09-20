using System;

namespace _12___Strategy___Behavioral_Pattern
{
    /*
     * Turkish:
     * Davranışsal Desendir.
     * Bridge desenine benzetilebilir.
     * Farklı kondisyonlara karşı, yine benzer işlemler yapılıyorsa 
     *      bunların bir Manager sınıfı üzerinden kontrolü ve işlenmesidir.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new ConditionA());    // bağlama noktası
            manager.Get();
        }
    }

    class Manager
    {
        private ConditionBase _conditionBase;
        public ConditionBase conditionBase { get => _conditionBase; set => _conditionBase = conditionBase; }
        public Manager(ConditionBase conditionBase)
        {
            this._conditionBase = conditionBase;
        }
        public void Get()
        {
            _conditionBase.Process();
        }
    }

    abstract class ConditionBase
    {
        public abstract void Process();
    }

    class ConditionA : ConditionBase
    {
        public override void Process()
        {
            Console.WriteLine("A kondisyonu uygunlandı !");
            //todo
        }
    }

    class ConditionB : ConditionBase
    {
        public override void Process()
        {
            Console.WriteLine("B kondisyonu uygulandı !");
            //todo
        }
    }
}
