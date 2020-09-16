using System;

namespace _06___Facade___Structural_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerA manager = new ManagerA();
            manager.Process();
        }
    }

    class ManagerA
    {
        private FacadeA _fac { get; set; }
        public ManagerA()
        {
            this._fac = new FacadeA();
        }
        public void Process()
        {
            _fac._home.Sample();
            _fac._phone.Sample();
        }
        
    }

    class FacadeA
    {
        public IHomePrototype _home;
        public IPhonePrototype _phone;
        public FacadeA()
        {
            _home = new HomeA();
            _phone = new PhoneA();
        }
    }

    class FacadeB
    {
        public IHomePrototype _home;
        public ICarPrototype _car;
        public FacadeB()
        {
            _home = new HomeA();    //etc HomeB
            _car = new CarA();
        }
    }

    interface IHomePrototype
    {
        public void Sample();
    }

    class HomeA : IHomePrototype    //etc HomeB
    {
        //props
        public void Sample()
        {
            Console.WriteLine("HomeA");
            //todo
        }
    }
    interface ICarPrototype
    {
        public void Sample();
    }

    class CarA : ICarPrototype
    {
        //props
        public void Sample()
        {
            Console.WriteLine("CarA");
            //todo
        }
    }

    interface IPhonePrototype
    {
        public void Sample();
    }

    class PhoneA : IPhonePrototype
    {
        //props
        public void Sample()
        {
            Console.WriteLine("PhoneA");
            //todo
        }
    }
}
