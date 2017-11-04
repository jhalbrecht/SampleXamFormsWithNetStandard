using System;
using MqttTest.Data.Services;

namespace Hermes.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello jeffa World! Testing Xamarin hermes mqtt client");
            System.Console.WriteLine("Look in the Debug window...");
            var hermes = new MqttDataServices();
            hermes.Connect();
            System.Console.ReadKey();
        }
    }
}
