using System;
using System.Threading.Tasks;

namespace async_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner("Hugo");
        }

        static void Runner(string runnerName)
        {
            Random rand = new Random();
            int reflexPhase = rand.Next(2, 10) * 100;
            Task.Delay(reflexPhase).Wait();
            Console.WriteLine($"{runnerName} commence à courir");

            int arrivalPhase = rand.Next(8, 16) * 1000;
            Task.Delay(arrivalPhase).Wait();
            Console.WriteLine($"{runnerName} est arrivé");
        }
    }
}
