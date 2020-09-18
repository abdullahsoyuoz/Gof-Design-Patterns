using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _20___Iterator___Behavioral_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeA a = new TypeA();
            a.Setter(new List<SampleObject>()       // fake data
            {
                new SampleObject(0),
                new SampleObject(1),
                new SampleObject(2),
                new SampleObject(3),
                new SampleObject(4),
                new SampleObject(5),
                    
            });
                
            
            TypeB b = new TypeB(5);
            b.Setter(new List<SampleObject>()       // fake data
            {
                new SampleObject(0),
                new SampleObject(1),
                new SampleObject(2),
                new SampleObject(3),
                new SampleObject(4),
                new SampleObject(5),

            });

            SampleObjectIterator.GetSampleObject(a.Getter());
            SampleObjectIterator.GetSampleObject(b.Getter());
        }
    }

    class SampleObject
    {
        private int _id;
        public int ID { get => _id; set => _id = ID; }
        public SampleObject(int _id)
        {
            this._id = _id;
        }
        // sample functions etc
    }

    class TypeA
    {
        private List<SampleObject> _list;
        public TypeA()
        {
            _list = new List<SampleObject>();
            //todo
        }
        public SampleObjectIterator Getter() => new SampleObjectIterator(_list);
        public void Setter(List<SampleObject> item) => this._list = item;
    }

    class TypeB
    {
        private SampleObject[] _list;
        public TypeB(int lenght)
        {
            _list = new SampleObject[lenght];
            //todo
        }
        public SampleObjectIterator Getter() => new SampleObjectIterator(_list.ToList());
        public void Setter(List<SampleObject> item) => _list = item.ToArray();
    }

    class SampleObjectIterator : IEnumerator  //  !!
    {
        private List<SampleObject> _list;
        private int index;  // default: 0
        public SampleObjectIterator(List<SampleObject> _list)
        {
            this._list = _list;
        }
        public object Current   // implemente
        {
            get
            {
                SampleObject item = _list[index];
                index++;
                return item;
            }
        }
        public bool MoveNext()  // implemente
        {
            if (index < _list.Count)
            {
                return true;
            }
            else
                Reset();
            return false;
        }
        public void Reset() => index = 0;
        public static void GetSampleObject(IEnumerator item)
        {
            while(item.MoveNext())
            {
                SampleObject current = (SampleObject)item.Current;
                int currentID = current.ID;
                Console.WriteLine("\t"+current.ID);
            }
        }
    }

}
