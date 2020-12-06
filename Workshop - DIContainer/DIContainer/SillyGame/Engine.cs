using DIContainer.Attributes;
using SillyGame.IO.Contracts;
using System;

namespace SillyGame
{
    class Engine
    {
        private IWriter writer;
        private IReader reader;

        [Inject]
        public Engine(IReader reader, IWriter writer)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            while (true)
            {
                writer.Write("work");
            }
        }
    }
}
