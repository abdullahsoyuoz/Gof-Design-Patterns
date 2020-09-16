using System;

namespace _04___Builder___Creational_Pattern
{
    /*
     * Oluşturucu Desendir.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.Generate(new BuilderA());
        }
    }

    class Manager
    {
        public void Generate(SampleBuilder _builder) => _builder.Process();
    }

    abstract class SampleBuilder
    {
        public abstract void Process(); //etc
        public abstract Model GetModel();
    }

    class BuilderA : SampleBuilder
    {
        Model model = new Model() { _id = 256 };        // gelen veriyi temsilen..
        public override void Process()  //etc
        {
            //todo
            Console.WriteLine("işlem yapılacak modelin ID:" + GetModel()._id);
        }
        public override Model GetModel()
        {
            return model;
        }

    }

    class Model
    {
        public int _id { get; set; }
    }
}
