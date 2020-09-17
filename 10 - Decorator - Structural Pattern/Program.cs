using System;

namespace _10___Decorator___Structural_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelA sample = new ModelA() { Name = "Bilgisayar", Price = 10000};

            StandartSales standartSales = new StandartSales(sample);
            Console.Write("indirim yüzdesini giriniz: ");
            DiscountSales discountSales = new DiscountSales(sample, decimal.Parse(Console.ReadLine()));

            Console.WriteLine(sample.Name + " ürününün standart fiyatı: "+ standartSales.Price+" ve indirimli fiyatı: "+discountSales.Price);

        }
    }

    abstract class ModelBase
    {
        public abstract string Name { get; set; }
        public abstract decimal Price { get; set; }
    }

    class ModelA : ModelBase     //  olası şablon
    {
        public override string Name { get; set; }
        public override decimal Price { get; set; }
    }

    abstract class SalesBase : ModelBase
    {
        private ModelBase _carbase;

        protected SalesBase(ModelBase carBase)
        {
            _carbase = carBase;
        }
    }

    class StandartSales : SalesBase
    {
        private readonly ModelBase _carBase;
        public StandartSales(ModelBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Name { get; set; }
        public override decimal Price
        {
            get
            { 
                return _carBase.Price; 
            }
            set
            { 
                /*    pass    */
            }
        }
    }
    class DiscountSales : SalesBase
    {
        public decimal DiscountPercentage { get; set; }
        private readonly ModelBase _carBase;
        public DiscountSales(ModelBase carBase, decimal DiscountPercentage) : base(carBase)
        {
            _carBase = carBase;
            this.DiscountPercentage = DiscountPercentage;
        }

        public override string Name { get; set; }
        public override decimal Price
        {
            get
            { 
                return _carBase.Price - (_carBase.Price * DiscountPercentage / 100); 
            }
            set
            { 
                /*    pass    */
            }
        }
    }
}
