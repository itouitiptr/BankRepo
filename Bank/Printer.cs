using System;

namespace Bank
{
    public class Printer : IConsole
    {
        public void PrintLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}