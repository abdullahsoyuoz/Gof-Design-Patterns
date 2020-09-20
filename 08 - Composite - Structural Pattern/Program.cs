using System;
using System.Collections;
using System.Collections.Generic;

namespace _08___Composite___Structural_Pattern
{
    /*
     * Turkish:
     * Yapısal Desendir.
     * Hiyerarşiyi sağlamak için kullanılır.
     * Örnek özelinde TypeA'yı Vehicle olarak adlandırıp, TypeA'dan kalıtarak 
     * Coupe ve Cabrio sınıflarını oluşturabilirdik (bunlar tercihe bağlı).
     * Kısaca Coupe ve Cabrio, hali hazırda bir araçtır (alt sınıflarıdır).
     * Burada oluşturduğumuz TypeA sınıfı araç nesnesinde tanımlı AddSub ile
     *      cabrio ve coupe nesnelerini, araç nesnesinin alt sınıfı olduğunu bildiriyoruz. !!
     */
    class Program
    {
        static void Main(string[] args)
        {
            TypeA _vehicle = new TypeA();
            TypeA _coupe = new TypeA();
            TypeA _cabriolet = new TypeA();

            _vehicle.AddSub(_coupe);
            _vehicle.AddSub(_cabriolet);
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
        List<IModel> _sub;
        public TypeA()
        {
            _sub = new List<IModel>();
        }

        public void AddSub(IModel item)
        {
            _sub.Add(item);
        }

        public void RemoveSub(IModel item)
        {
            _sub.Remove(item);
        }

        public IModel Get(int index)
        {
            return _sub[index];
        }

        //implemente edilmesinden gelenler
        public IEnumerator<IModel> GetEnumerator()
        {
            foreach (var item in _sub)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // class TypeB: IModel, IEnumerable<IModel> ..etc
    }
}
