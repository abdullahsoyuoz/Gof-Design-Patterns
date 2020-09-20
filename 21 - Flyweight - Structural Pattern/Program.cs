using System;
using System.Collections.Generic;

namespace _21___Flyweight___Structural_Pattern
{
    /*
     * Turkish:
     * Yapısal Desendir.
     * Algoritmanın uzunluğu, bilhassa Flyweight'in esas yapısı Artboard sınıfının uzunluğu korkutmasın, mantığı basit.
     * Örneğin aklınızda 3.bakıç açısından oynanan strateji-savaş oyunu hayal edin.
     *      koca bir ordu içerisindeki her bir askeri tek tek üretmemiz, ram belleğe yük bindireceğinden,
     *      bu algoritma sayesinde tek bir kez üretiyoruz.
     *      Burada iş yükünün iyi hesaplanması lazım çünkü aynı betimleme üzerinden düşünürsek
     *      Kocaman bir ordu aslında tek bir asker olabilir ama, koca bir ordunun fonksiyonlarını tek bir asket yapması
     *      işlemciye ağır yük bindirebilir. Bu yüzden iyi düşünülmeli ve farklı kaynaklardan araştırmalar yapabilirsiniz.
     */

    class Program
    {
        static void Main(string[] args)
        {   
            // TEST EDİYORUZ, BU YÜZDEN UZUN OLDU :)

            Artboard artboard = Artboard.Create();

            Element a1 = new Element(Elements.A);
            Element b1 = new Element(Elements.B);
            Element c1 = new Element(Elements.C);
            Element d1 = new Element(Elements.D);
            Element a2 = new Element(Elements.A);
            Element b2 = new Element(Elements.B);
            Element d2 = new Element(Elements.D);
            Element b3 = new Element(Elements.B);
            Element d3 = new Element(Elements.D);
            Element d4 = new Element(Elements.D);

            Artboard.AddElement(a1);
            Artboard.AddElement(b1);
            Artboard.AddElement(c1);
            Artboard.AddElement(d1);
            Artboard.AddElement(a2);
            Artboard.AddElement(b2);
            Artboard.AddElement(d2);
            Artboard.AddElement(b3);
            Artboard.AddElement(d3);
            Artboard.AddElement(d4);

            Console.WriteLine("\n"+artboard.CountElement +" adet nesne üretildi !");
        }
    }

    public enum Elements { A, B, C, D}  // farklı nesne tiplerini temsilen

    public abstract class ElementTemplate
    {
        public abstract void Use();
        //todo etc
    }

    public class Element : ElementTemplate, IComparable
    {
        private Elements _type;
        public Elements type { get => _type; set => _type = type; }
        public Element(Elements _type) => this._type = _type;
        public override void Use()
        {
            Console.WriteLine(_type.ToString()+" üretildi ve kullanıldı !");
        }

        public int CompareTo(object obj)    // implement from IComparable , FLYWEIGHT ICIN EN ONEMLI KISMI
        {
            if (obj is Element)
            {
                Element e = (Element)obj;
                if (e.type == this.type)     // burayı her tipin Element sınıfından türetildiğini göz önüne alarak düşünün
                {
                    return 1;
                }
                else
                    return 0;
            }
            else
                return -1;
        }
    }

    public class Artboard   // FLYWEIGHT MANAGER 
    {
        private static Artboard _artboard = null;
        private static List<ElementTemplate> _list;
        public int CountElement { get => _list.Count; }     // test'te patern kontrol için, gerçekten aynı elemenı ikinci kez üretmiyor mu? gibi
        private Artboard()      // Singleton ;)
        {
            _list = new List<ElementTemplate>();
        }
        public static Artboard Create()
        {
            if(_artboard == null)
            {
                lock(new object())
                {
                    _artboard = new Artboard();
                }
            }
            return _artboard;
        }
        public static ElementTemplate AddElement(Element e)
        {
            ElementTemplate temp = null;
            for (int i = 0; i < _list.Count; i++)
            {
                if(((Element)_list[i]).CompareTo(e) == 1)
                {
                    temp = e;
                    break;
                }
            }
            if(temp == null)
            {
                temp = new Element(e.type);
                _list.Add(temp);
            }
            temp.Use();
            return temp;
        }
    }
}
