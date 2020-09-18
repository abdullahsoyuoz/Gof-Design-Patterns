using System;

namespace _11___Bridge___Behavioral_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new MessageSenderA());

            manager.Update("Overflow", "Error");    // !!!
        }
    }

    class Manager
    {
        private MessageSenderBase _msb;
        public MessageSenderBase msb { get => _msb; set => _msb = msb; }
        public Manager(MessageSenderBase msb)
        {
            this._msb = msb;
        }

        public void Update(string msg, string type) => _msb.Process(new Content() { Message = msg, Type = type });
        
    }

    abstract class MessageSenderBase
    {
        public abstract void Process(Content _content);
    }

    class MessageSenderA : MessageSenderBase
    {
        public override void Process(Content _content)
        {
            Console.WriteLine(_content.Message+" >> "+_content.Type);
        }
    }

    class Content
    {
        public string Message { get; set; }
        public string Type { get; set; }
    }
}
