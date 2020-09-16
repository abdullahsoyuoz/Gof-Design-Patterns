using System;
using System.Collections;
using System.Collections.Generic;

namespace _08___Composite___Structural_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface IModel
    {
        public int _id { get; set; }
        public string _name { get; set; }   //etc
    }

    class TypeA : IModel, IEnumerable<IModel>
    {
        public int _id { get; set; }
        public string _name { get; set; }

        public IEnumerator<IModel> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
