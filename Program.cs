using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace async_project
{
    class Program
    {

       public static List<string> runnersPodium = new List<string>();
       public static List<string> runnersName = new List<string>();

        static async Task Main(string[] args)
        {
            runnersName.Add("Hugo");
            runnersName.Add("Rémy");
            runnersName.Add("Olivier");
            await RacePodium(runnersName);
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
            runnersPodium.Add(runnerName);
        }

        static async Task Race(List<string> runnersNames)
        {
            Console.WriteLine("Début de la course");
            List<Task> runTasks = new List<Task>();

            for (int i = 0; i < runnersNames.Count; i++)
            {
                Task runTask = Runner(runnersNames[i]);
                runTasks.Add(runTask);
            }

            foreach (Task runTask in runTasks)
            {
                await runTask;
            }

            Console.WriteLine("La course est terminée");
        }

        static async Task RacePodium(List<string> runnersNames)
        {
            Console.WriteLine("Début de la course");
            List<Task> runTasks = new List<Task>();

            for (int i = 0; i < runnersNames.Count; i++)
            {
                Task runTask = Runner(runnersNames[i]);
                runTasks.Add(runTask);
            }

            for (int i = 0; i < runTasks.Count; i++)
            {
                await runTasks[i];
            }

            Console.WriteLine("La course est terminée");

            for (int i = 0; i < runnersPodium.Count; i++)
            {
                Console.WriteLine($"{runnersPodium[i]} est arrivé en {i + 1}e position");
            }
        }
    }
}
