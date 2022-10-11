using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace async_project
{
    class Program
    {

       public static List<string> runnersClassement = new List<string>();
       public static List<string> runnersName = new List<string>();

        static async Task Main(string[] args)
        {
            runnersName.Add("Hugo");
            runnersName.Add("Rémy");
            runnersName.Add("Olivier");
            await RacePodiumCancellable(runnersName);
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
            runnersClassement.Add(runnerName);
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

            foreach (Task runTask in runTasks)
            {
                await runTask;
            }

            Console.WriteLine("La course est terminée");

            for (int i = 0; i < runnersClassement.Count; i++)
            {
                Console.WriteLine($"{runnersClassement[i]} est arrivé en {i + 1}e position");
            }
        }

        static async Task RacePodiumCancellable(List<string> runnersNames)
        {
            Task raceTask = RacePodium(runnersName);
            Task stopTask = StopCourse();
        }

        static async Task StopCourse()
        {
            while (Console.ReadKey().Key != ConsoleKey.C) Console.Write("\b");
            Environment.Exit(0);
        }
    }
}
