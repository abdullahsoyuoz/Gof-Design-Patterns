using System;
using System.Collections.Generic;

namespace _18___Command___Behavioral_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            ConditionA conditionA = new ConditionA(manager);
            ConditionB conditionB = new ConditionB(manager);

            OrderTracker tracker = new OrderTracker();
            tracker.TakeOrder(conditionA);
            tracker.TakeOrder(conditionB);

            tracker.RunOrders();
        }
    }

    class Manager
    {
        private int _id;
        public int ID { get => _id; set => _id = ID; }  // like prop's

        public void ConditionAProcess() 
        {
            //todo
            Console.WriteLine("Condition A Processed !");
        }
        public void ConditionBProcess() 
        {
            //todo
            Console.WriteLine("Condition B Processed !");
        }
        
    }

    class OrderTracker  // zinciri takip edip, işleyen
    {
        private List<IOrderCondition> _list;
        public OrderTracker()
        {
            _list = new List<IOrderCondition>();
        }

        public void TakeOrder(IOrderCondition item) => _list.Add(item);
        public void RunOrders()
        {
            foreach (var item in _list)
            {
                item.Execute();
            }
            _list.Clear();  // zincirin tüm işlemleri tamamlandı, todo list temizlendi !!
            Console.WriteLine("\nSipariş zinciri temizlendi !!");
        }
    }

    interface IOrderCondition
    {
        void Execute();
    }

    class ConditionA : IOrderCondition  // zincirleme işlemler, alış-satış yada yeni-düzenle-kaydet vbvbvb
    {
        private Manager _manager;

        public ConditionA(Manager _manager)
        {
            this._manager = _manager;
        }
        public void Execute()
        {
            _manager.ConditionAProcess();
        }
    }
    class ConditionB : IOrderCondition
    {
        private Manager _manager;

        public ConditionB(Manager _manager)
        {
            this._manager = _manager;
        }
        public void Execute()
        {
            _manager.ConditionBProcess();
        }
    }
}
