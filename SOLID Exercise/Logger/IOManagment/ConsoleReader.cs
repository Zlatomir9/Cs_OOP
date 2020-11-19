using Logger.IOManagment.Contracts;
using System;

namespace Logger.IOManagment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
