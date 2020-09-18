using System;

namespace _19___Visitor___Behavioral_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerA controllerA = new ControllerA();
            SampleControlVisitor visitor = new SampleControlVisitor();

            visitor.Supplier(controllerA);
        }

        abstract class SampleControl
        {
            protected long _id;
            public long ID { get => _id; set => _id = ID; }
            public abstract void Supply(IVisitor visitor);
        }

        class ControllerA : SampleControl  // like can derive.. ControlB.. etc
        {
            public override void Supply(IVisitor visitor)
            {
                visitor.Supplier(this);
            }
        }

        interface IVisitor
        {
            void Supplier(SampleControl control);
        }

        class SampleControlVisitor : IVisitor
        {
            public void Supplier(SampleControl control)
            {
                if(control is ControllerA)
                {
                    Console.WriteLine("ControllerVisitor'un eylemi uygulandı !");
                    //todo
                }
            }
        }
    }
}
