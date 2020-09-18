using System;

namespace _17___State___Behavioral_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicPlayer musicplayer = new MusicPlayer();

            Console.WriteLine("1 for play or 2 for pause");
            int selected = int.Parse(Console.ReadLine());
            switch (selected)
            {
                case 1:
                    Play play = new Play();
                    play.Action(musicplayer);
                    break;
                case 2:
                    Pause deleted = new Pause();
                    deleted.Action(musicplayer);
                    break;
                default:
                    break;
            }
        }
    }

    class MusicPlayer  // müzik çalar için düşünülebilir
    {
        private ISampleState _state;
        public void SetState(ISampleState _state) => this._state = _state;
        //todo action
    }

    interface ISampleState
    {
        void Action(MusicPlayer service); 
    }

    class Play : ISampleState   // bunlar state'ler
    {
        public void Action(MusicPlayer service)
        {
            service.SetState(this);
            Console.WriteLine("Music Player is playing !");
            //todo
        }
    }

    class Pause : ISampleState  // next, previous.. etc
    {
        public void Action(MusicPlayer service)
        {
            service.SetState(this);
            Console.WriteLine("Music Player is paused !");
            //todo
        }
    }
}
