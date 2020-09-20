using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _20___Iterator___Behavioral_Pattern
{
    /*
     * Turkish:
     * Davranışsal Desendir.
     * Aslında bir desenden ziyade idiom'dur.   BKZ. IDIOM
     * Farklı yapılarda tutulan modelleriniz var (TypeA ve TypeB yapılarında tutulan SampleObject nesnesi).
     * Bu verilerin, hepsinin çağırıldığını düşünelim.
     * bu veriler farklı biçimlerde önümüze çıkabilir. Tam bu noktada böyle karmaşıklığın yaşanmaması için
     *      bir SampleObjectIterator sınıfı yazıyor ve farklı düzende get edilen verilerin tek bir düzende get edilmesini sağlıyoruz.
     */

    class Program
    {
        static void Main(string[] args)
        {
            TypeA a = new TypeA();
            TypeB b = new TypeB(5);

            List<SampleObject> fakelistList = new List<SampleObject>()
            {
                new SampleObject(1),
                new SampleObject(2),
                new SampleObject(3),
                new SampleObject(4),
                new SampleObject(5),
            };  // FAKE DATA

            SampleObject[] fakelistArray =  
            {
                new SampleObject(6),
                new SampleObject(7),
                new SampleObject(8),
                new SampleObject(9),
                new SampleObject(10),
            };  // FAKE DATA

            a.Setter(fakelistList);
            b.Setter(fakelistArray);
            
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
        private int _lenght;
        public TypeB(int _lenght)
        {
            this._lenght = _lenght;
            _list = new SampleObject[_lenght];
            //todo
        }
        public SampleObjectIterator Getter() => new SampleObjectIterator(_list.ToList());
        public void Setter(SampleObject[] item) => _list = item;
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
