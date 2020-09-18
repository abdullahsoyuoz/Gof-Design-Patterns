using System;

namespace _15___Memento___Behavioral_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yeni bir Kitap !");
            Model bookA = new Model("Halide Edip Adıvar","Ateşten Gömlek",253);
            Console.WriteLine(bookA);

            Taker taker = new Taker();
            taker._yedek = bookA.Recover();

            Console.WriteLine("\nManipüle Ettik.");
            bookA._title = "Sinekli Bakkal";
            bookA._pagenumber = 424;
            Console.WriteLine(bookA);

            Console.WriteLine("\nAsıl bilgilere restore ettik !");
            bookA.Restore(taker._yedek);
            Console.WriteLine(bookA);
        }
    }

    class Model
    {
        public string _author;
        public string _title;
        public int _pagenumber;
        public DateTime _lastEdit;
        public Model(string Author, string Title, int PageNumber)
        {
            this._author = Author;
            this._title = Title;
            this._pagenumber = PageNumber;
            getLastEdited();
        }

        public void Restore(Yedek model)
        {
            this._author = model.Author;
            this._title = model.Title;
            this._pagenumber = model.PageNumber;
        }
        public Yedek Recover() => new Yedek(this._author, this._title, this._pagenumber, this._lastEdit);
        public void getLastEdited() => _lastEdit = DateTime.UtcNow;
        public override string ToString() => "Title: "+this._title+", Author: "+this._author+", PageNumber: "+this._pagenumber+" & Last Edit Time: "+this._lastEdit;
        
    }
    class Yedek //  Memento
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int PageNumber { get; set; }
        public DateTime _lastEdited { get; set; }

        public Yedek(string Author, string Title, int PageNumber, DateTime _lastedited)
        {
            this.Author = Author;
            this.Title = Title;
            this.PageNumber = PageNumber;
            this._lastEdited = _lastedited;
        }
    }

    class Taker
    {
        public Yedek _yedek { get; set; }
    }

}
