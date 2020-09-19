using System;
using System.Collections.Generic;
using System.Linq;

namespace _22___Mediator___Behavioral_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProviderA room = new ProviderA();
            room.name = "patron";

            Subscriber John = new Subscriber("John");
            Subscriber Alice = new Subscriber("Alice");
            Subscriber Margaret = new Subscriber("Margaret");
            Moderator Claire = new Moderator("Claire");

            room.AddPerson(John);
            room.AddPerson(Alice);
            room.AddPerson(Margaret);
            room.AddPerson(Claire);

            //room.Broadcast(Claire, "Merhabalar aq");
            Claire.Broadcast("merhabalar");
            
        }
    }

    abstract class Person
    {
        private string _nickname;
        private ProviderBase _provider;         //-------------------------------------
        public string nickname { get => _nickname; set => _nickname = nickname; }
        public ProviderBase provider { get => _provider; set => _provider = provider; } //-------------------------------------
        protected Person(string _nickname) => this._nickname = _nickname;
        public abstract void Accept(Person person, string message);
        public void SetProvider(ProviderBase provider)//-------------------------------------
        {
            this._provider = provider;
        }


    }

    class Subscriber : Person
    {
        private ProviderBase _provider;//-------------------------------------
        public Subscriber(string _nickname) : base(_nickname) { }   // ctor base
        public override void Accept(Person sender, string message)
        {
            Console.WriteLine(sender.nickname + " > " + this.nickname + " : " + message);
        }
    }

    class Moderator : Person
    {
        private ProviderBase _provider;//-------------------------------------
        public Moderator(string _nickname) : base(_nickname) { }   // ctor base    
        public override void Accept(Person sender, string message)
        {
            Console.WriteLine(sender.nickname + " > " + this.nickname + " : " + message);
        }
        public void Broadcast(string message)
        {
            try
            {
                _provider.Broadcast(this, message);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }

    abstract class ProviderBase
    {
        public string name;
        protected List<Person> _listPerson;
        protected ProviderBase()
        {
            _listPerson = new List<Person>();
        }
        public void AddPerson(Person a)
        {
            if(!_listPerson.Contains(a))
            {
                _listPerson.Add(a);
                a.SetProvider(this);
            }
        }
        public abstract void Broadcast(Person person, String message);
        public abstract void Send(Person sender, Person acceptor, String message);
    }

    sealed class ProviderA : ProviderBase  // ProviderB etc... like rooms on chat platforms
    {
        public ProviderA() : base() { }
        
        public override void Broadcast(Person person, string message)
        {
            foreach (var item in _listPerson)
            {
                item.Accept(person, message);
            }
        }

        public override void Send(Person sender, Person acceptor, string message)
        {
            throw new NotImplementedException();
        }
    }
    //  sealed anahtarı, ProviderA sınıfının bir daha kalıtılamacağını ifade eder.
    //  kısaca ProviderB gibi bir diğer sınıfı, ProviderA'dan kalıtamıyoruz, zaten A'da olduğu gibi Base'den türetmeliyiz. bu yüzden..
}
