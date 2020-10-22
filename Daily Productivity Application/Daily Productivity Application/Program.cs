using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Daily_Productivity_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Daily Planner!");
            Console.WriteLine();
            Console.WriteLine();
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Lets start with some brainstorming...");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine("Let's get everything in our brain out of our brain so that we can think clearly");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //Thread.Sleep(TimeSpan.FromSeconds(2));






            bool convertedanswer = true;
            int taskcounter = 0;
            string input;
            string answer;
            string task;
            Dictionary<int, string> braindump = new Dictionary<int, string>(20);





            Console.WriteLine("Would you like to start?");
            Console.WriteLine("Type [Yes] or [No]");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            input = Console.ReadLine();
            answer = input.ToLower();
            if (answer == "yes")
            {
                convertedanswer = true;
            }
            else
            {
                convertedanswer = false;
                return;
            }

            Console.WriteLine("What is one thing you must do today?");
            while (convertedanswer == true)
            {



                if (taskcounter == 0)
                {
                    input = Console.ReadLine();
                    taskcounter++;
                }
                task = input;
                
                

                

                braindump.Add(taskcounter, task);
                taskcounter++;

                // Read all items    
                Console.WriteLine("All Braindumped tasks:");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < braindump.Count; i++)
                {
                    Console.WriteLine("Task {0}: {1}", braindump.ElementAt(i).Key, braindump.ElementAt(i).Value);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("What is another thing on your mind that must be done today? Or press enter if you of emptied your brain of everything that must be done today");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    convertedanswer = false;
                }
                else
                {
                    convertedanswer = true;
                }
            }

            





        }
    }
}
