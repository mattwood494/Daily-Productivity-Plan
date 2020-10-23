using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Threading;

namespace Daily_Productivity_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConsoleFormatter formatter = new ConsoleFormatter(); //instantiate formatting class
            string s = ""; // s will be used to store strings that I will format to be more aesthetically pleasing

            
            // I use a similar pattern throughout the code as the block below to make program easier to read
            // Welcome user:
            formatter.MiddlePage(); // prints a new line enough times to make text appear close to the middle of the screen.
            formatter.CenterText("Welcome to the Daily Planner!");
            Thread.Sleep(TimeSpan.FromSeconds(2)); // delays moving on the the next step by two seconds
            Console.Clear();


            // Ask user if they would like to start planning their day
            formatter.MiddlePage();
            formatter.CenterText("Would you like to start?");
            formatter.CenterText("Type [Yes] or [No]");
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - 3) / 2, Console.CursorTop); //This formatts text to be in the middle of the screen
            Console.Write("Answer: ");
            string answer = Console.ReadLine();
            Console.Clear();


            // This block checks to see what the user typed. If yes then app will run, if no then it will exit.
            answer.ToLower();
            if (answer == "yes")
            {
                
            }
            else
            {
                formatter.MiddlePage();
                formatter.CenterText("Good Bye!");
                formatter.MiddlePage();

                return;
            }

            // This block is used to show user some categories to inspire ideas or tasks that may need to be done.
            formatter.MiddlePage();
            formatter.CenterText("Before we get started lets look at some common task categories to inspire our list... ");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            formatter.NewPage();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            var collection = Enum.GetValues(typeof(brainFilter)); //stores Enum values in an array
            foreach (var item in collection) //iterates over values
            {
                Console.SetCursorPosition((Console.WindowWidth - 10) / 2, Console.CursorTop);
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            s = "Press ENTER when you are ready to move on. Take your time.";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ReadLine();
            Console.Clear();



            // Gathers the date on which the To Do list should be done.
            formatter.MiddlePage();
            formatter.CenterText("Lets get started. What day would you like to create a to-do list for?");
            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, Console.CursorTop);
            Console.Write("Date(MM/DD/YY): ");
            string date = Console.ReadLine();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.Clear();

            //Obtains file path to location that user would like to store list.
            formatter.MiddlePage();
            formatter.CenterText("Ok great! Where would you like the to-do list to be stored?");
            s = "Paste your file path here (ensure it ends with a backward slash): ";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.Write(s);
            string filePath = Console.ReadLine();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.Clear();

            // Obtains name that user wants to give to file
            formatter.MiddlePage();
            formatter.CenterText("Sounds good. What would you like your to-do list to be called?");
            s = "Type your file name followed by .txt here: ";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.Write(s);
            string fileName = Console.ReadLine();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.Clear();

            //instiantes the DailyPlanner class using the non-default constructor
            DailyPlanner dailyPlan = new DailyPlanner(filePath, fileName, date);

            
            //Create task list
            Dictionary<int, string> MyDailyPlan = dailyPlan.TaskListCreator();


            Console.Clear(); 
            //Display Task List
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            dailyPlan.DisplayTaskList(MyDailyPlan);



            //Save Document to fle
            dailyPlan.SaveToFile();
            


        }

        

        
    }


    public class DailyPlanner
    {
        private string _filePath { get; set; }
        private string _fileName { get; set; }
        private string _fullPath { get; set; }
        private Dictionary<int, string> _taskList { get; set; }
        private string _date { get; set; }
        
        

        public DailyPlanner(string fileDest, string fileName, string dateToBeCompleted) // sets values prefered by user and instantiates the Dictionary
        {
            _filePath = fileDest;
            _fileName = fileName;
            _date = dateToBeCompleted;
            _taskList = new Dictionary<int, string>();
            _fullPath = _filePath + _fileName;
            

        }

        public Dictionary<int, string> TaskListCreator() // Fills the dictionary _taskList based on user preferences
        {
            
            ConsoleFormatter formatter = new ConsoleFormatter();
            bool convertedanswer = true; //this is used to determine if while loop will continue
            int taskcounter = 0; //used to test if it is the first time through the while loop as well as to signify what number to assign the key to.
            string input = ""; //input will refernce user input
            string answer;
            string task;



            formatter.MiddlePage();
            formatter.CenterText("What is one thing you must do on this day?");
            Console.WriteLine();

            //This loop allows user to continuously add tasks until satisfied with list contents
            while (convertedanswer == true) 
            {

                if (taskcounter == 0) // if first time through loop execute if block
                {
                    Console.SetCursorPosition((Console.WindowWidth - 10) / 2, Console.CursorTop);
                    Console.Write("Answer: ");
                    input = Console.ReadLine();
                    taskcounter++; //ensures this block will not be run again
                    Console.Clear();
                }

                task = input; // task will be used to add string to the dictionary later




                _taskList.Add(taskcounter, task); // key value pair created based off counter and user input
                taskcounter++;

                // Read all items   
                formatter.CenterText("Daily Task Summary: ");
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < _taskList.Count; i++)
                {

                    Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                    Console.WriteLine("Task {0}: {1}", _taskList.ElementAt(i).Key, _taskList.ElementAt(i).Value); // Neatly display key value pair on console.

                }


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                //This block allows user to either break out of loop or enter another task
                string s = "";
                s = "Enter another task or press enter if you are done: ";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.Write(s);
                input = Console.ReadLine();
                Console.Clear();
                if (String.IsNullOrWhiteSpace(input))
                {
                    convertedanswer = false;
                }
                else
                {
                    convertedanswer = true;
                }



            }

            return _taskList;
        }

        public void DisplayTaskList(Dictionary<int, string> taskList) //Displays all tasks that have been entered by user
        {
            ConsoleFormatter formatter = new ConsoleFormatter();

            formatter.CenterText("Daily Task Summary: ");
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < _taskList.Count; i++)
            {

                Console.SetCursorPosition((Console.WindowWidth - 20) / 2, Console.CursorTop);
                Console.WriteLine("Task {0}: {1}", _taskList.ElementAt(i).Key, _taskList.ElementAt(i).Value);

            }

            formatter.MiddlePage();
        }

        public void SaveToFile() //Uses streamwriter to save task to file using the user specified location
        {
            
            try
            {
                using (StreamWriter writer = new StreamWriter(_fullPath))
                {
                    writer.WriteLine(_date);
                    writer.WriteLine();
                    writer.WriteLine("Daily Task Summary: ");
                    writer.WriteLine();
                    writer.WriteLine();
                    for (int i = 0; i < _taskList.Count; i++)
                    {

                        writer.WriteLine("Task {0}: {1}", _taskList.ElementAt(i).Key, _taskList.ElementAt(i).Value);

                    }
                }
            }
            catch (Exception exp) // message will display if exception is thrown
            {
                Console.Write(exp.Message);
            }
        }

        
    }

    public class ConsoleFormatter //This class was used to make code look cleaner as well as help appearance of output to be more aesthetic
    {

        public void MiddlePage()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void CenterText(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        
    }

    enum brainFilter //generic categories that my generate thoughts and ideas for tasks that need to be addressed
    {
        CSC205HW,
        CSC305HW,
        CSC160HW,
        Appointments,
        Emails,
        LinkedIn,
        Resume,
        Applications,
        Network,
        Family,
        Vacation,
        Cooking,
        Shopping,
        PlanNextWeek

    }
}
