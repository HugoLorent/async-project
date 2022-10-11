using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace async_project
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> runnersName = new List<string>();
            runnersName.Add("Hugo");
            runnersName.Add("Rémy");
            runnersName.Add("Olivier");
            await Race(runnersName);
        }

        static async Task Runner(string runnerName)
        {
            Random rand = new Random();

            int reflexPhase = rand.Next(2, 10) * 100;
            await Task.Delay(reflexPhase);
            Console.WriteLine($"{runnerName} commence à courir");

            int arrivalPhase = rand.Next(8, 16) * 1000;
            await Task.Delay(arrivalPhase);
            Console.WriteLine($"{runnerName} est arrivé");
        }

        static async Task Race(List<string> runnersNames)
        {
            Console.WriteLine("Début de la course");
            Task[] runTasks = new Task[runnersNames.Count];

            for (int i = 0; i < runTasks.Length; i++)
            {
                Task runTask = Runner(runnersNames[i]);
                runTasks[i] = runTask;
            }

            Task.WaitAll(runTasks);

            Console.WriteLine("La course est terminée");
        }
    }
}
