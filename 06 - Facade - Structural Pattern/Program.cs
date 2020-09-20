using System;

namespace _06___Facade___Structural_Pattern
{
    /*
     * Turkish:
     * Yapısal Desendir.
     * Genel bir Facade sınıfı altında modellerden oluşan kombinasyonların kontrolü ve işlenmesidir.
     * Facade'ler ve modeller çeşitlendirilebilir.
     */
    class Program
    {
        static void Main(string[] args)
        {
            FacadeA kombinasyon1 = new FacadeA();
            kombinasyon1.ModelAFunction();
        }
    }

    class FacadeA   // alternatif modeller ve facade'ler yazılabilir !
    {
        public IModelAPrototype _modelA;
        public IModelBPrototype _ModelB;
        public IModelCPrototype _ModelC;
        public FacadeA()
        {
            _modelA = new ModelA();
            _ModelB = new ModelB();
            _ModelC = new ModelC();
        }
        public void ModelAFunction() => _modelA.Sample();
        public void ModelBFunction() => _ModelB.Sample();
        public void ModelCFunction() => _ModelC.Sample();
    }

    interface IModelAPrototype
    {
        public void Sample();
    }

    class ModelA : IModelAPrototype    //etc HomeB
    {
        //props
        private string _name;
        public string name { get => _name; set => _name = name; }
        public void Sample()
        {
            Console.WriteLine("ModelA Sample");
            //todo
        }
    }
    interface IModelBPrototype
    {
        public void Sample();
    }

    class ModelB : IModelBPrototype
    {
        //props
        private string _name;
        public string name { get => _name; set => _name = name; }
        public void Sample()
        {
            Console.WriteLine("ModelB Sample");
            //todo
        }
    }

    interface IModelCPrototype
    {
        public void Sample();
    }

    class ModelC : IModelCPrototype
    {
        //props
        private string _name;
        public string name { get => _name; set => _name = name; }
        public void Sample()
        {
            Console.WriteLine("ModelC Sample");
            //todo
        }
    }
}
