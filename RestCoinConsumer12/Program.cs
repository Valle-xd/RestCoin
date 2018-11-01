using System;
using RestCoinConsumer;
using RestCoinConsumer12;

namespace RestCoinConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            RestHandler handler = new RestHandler();
            handler.Start();

            Console.ReadLine();
        }
    }
}
