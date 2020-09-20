using System;

namespace _14___Chain_of_Responsibility___Behavioral_Pattern
{
    /*
     * Turkish:
     * Davranışsal Desendir.
     * Algoritmayı karmaşıklaştırmamak adına Handle() fonksiyonu için if kontrol bloğu ile basit bir kıyas sonucu
     *      işlemi sonuca ulaştırdım fakat ilk görenlere karışık gelebilir, Dikkatle incelemelerini tavsiye ederim.
     * Mevzu kısaca, yapabilite veya bir işi yapmaya rütbesi yetmesi diyelim, herhangi bir vasıftan ötürü yapabiliyorsan
     *      yap, yapamıyorsan bir üst sınıfa pasla işidir.
     * Elinizde güncel bir oyun var ve elinizdeki bilgisayar açamıyorsa daha iyi bir bilgisayarda aç şeklinde uyarı alıyorsunuz gibi...
     */

    class Program
    {
        static void Main(string[] args)
        {
            Junior Jack = new Junior(new Person("Jack", 45));
            Senior Chris = new Senior(new Person("Chris", 95));

            Jack.SetSenior(Chris);
            Jack.Handle();
        }
    }

    class Person
    {
        private string _name;
        public string name { get => _name; set => _name = name; }

        private int _strength { get; set; }
        public int strength { get => _strength; set => _strength = strength; }

        public Person(string name, int strength)
        {
            this._name = name;
            this._strength = strength;
        }
    }

    abstract class PositionBase
    {
        protected PositionBase _senior;
        public void SetSenior(PositionBase senior) => this._senior = senior;
        public abstract void Handle();
    }
    class Junior : PositionBase
    {
        public Person person;
        public override void Handle()
        {
            if (person.strength < 50)
            {
                _senior.Handle();
            }
            else if (person != null)
                Console.WriteLine(person.name + " bu işi yapar !");
        }

        public Junior(Person person)
        {
            this.person = person;
        }
    }

    class Senior : PositionBase
    {
        public Person person;
        public override void Handle()
        {
            Console.WriteLine(person.name + " bu işi yapar !");
        }

        public Senior(Person person)
        {
            this.person = person;
        }
    }

}
