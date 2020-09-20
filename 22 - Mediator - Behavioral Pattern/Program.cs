using System;
using System.Collections.Generic;
using System.Linq;

namespace _22___Mediator___Behavioral_Pattern
{
    /*
     * Turkish:
     * Davranışsal Desendir.
     * Desenin amacı, kurgumuzda farklı taraflar var ve bu taraflar tek bir çatı alında faaliyet gösteriyorlar.
     * Örneğin bir kurs, kurs içerisinde kursiyer ve öğrenciler olsun.
     * Bu desen ile bu kurguyu kodlayabiliriz.
     *      ++ araba pazarını hayal edelim. pazarda, arabasını satmak isteyen bir kişi var.
     *      diyelim ki arabaya talip birden fazla kişi var ve araç sahibi yüksek fiyat verene satacak.
     *      işte böyle bir senaryo için, provider nesnesinde satış fonksiyonu altında koşullar kodlanabilir.
     */

    class Program
    {
        static void Main(string[] args)
        {
            ProviderA room = new ProviderA();

            Subscriber John = new Subscriber("John");
            Subscriber Alice = new Subscriber("Alice");
            Subscriber Margaret = new Subscriber("Margaret");
            Moderator Claire = new Moderator("Claire");

            room.AddPerson(John);
            room.AddPerson(Alice);
            room.AddPerson(Margaret);
            room.AddPerson(Claire);

            //room.Broadcast(Claire, "Merhabalar");     
            Claire.Broadcast("merhabalar");             // alternatif
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
        public void Send(string message)
        {
            provider.Send(provider.GetModerator(), this, message);
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
        public void Broadcast(string message) => provider.Broadcast(this, message);
        public void Send(Person acceptor, string message) => provider.Send(this, acceptor, message);
    }

    abstract class ProviderBase
    {
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
        public Person GetModerator()
        {
            foreach (var item in _listPerson)
            {
                if(item is Moderator)
                {
                    return item;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
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
            acceptor.Accept(sender, message);
        }
    }
    //  sealed anahtarı, ProviderA sınıfının bir daha kalıtılamacağını ifade eder.
    //  kısaca ProviderB gibi bir diğer sınıfı, ProviderA'dan kalıtamıyoruz, zaten A'da olduğu gibi Base'den türetmeliyiz. bu yüzden..
}
