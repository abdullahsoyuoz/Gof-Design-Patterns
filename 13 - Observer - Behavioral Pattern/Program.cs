using System;
using System.Collections.Generic;

namespace _13___Observer___Behavioral_Pattern
{
    /*
     * Turkish:
     * Davanışsal Desendir.
     * Örnekten anlaşılacağı üzerine tüm nesnelerin tek bir manager üzerinden update'i söz konusudur.
     */
    class Program
    {
        static void Main(string[] args)
        {
            ModelA model1 = new ModelA("Samsung Galaxy S10");
            ModelA model2 = new ModelA("Samsung Galaxy S10 Plus");

            Manager manager = new Manager();

            manager.AddModel(model1);
            manager.AddModel(model2);

            manager.Notify();   // Android güncelleme olsun ;)
        }
    }

    class Manager
    {
        private List<ModelBase> _list;
        public List<ModelBase> list { get => _list; set => _list = list; }
        public Manager()
        {
            _list = new List<ModelBase>();
        }
        public void AddModel(ModelA item) => _list.Add(item);
        public void RemoveModel(ModelA item) => _list.Remove(item);
        public void Notify()    // parametre gönderilebilir !!
        {
            foreach (var item in _list)
            {
                item.Update();
            }
        }
    }

    abstract class ModelBase
    {
        public abstract string name { get; set; }
        public abstract void Update();
    }

    class ModelA : ModelBase    //etc
    {
        public override string name { get; set; }
        public ModelA(string value)
        {
            this.name = value;
        }

        public override void Update()
        {
            Console.WriteLine(name+" updated !");
        }
    }
}
