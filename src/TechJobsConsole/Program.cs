using System;
using System.Collections.Generic;

namespace TechJobsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two Dictionary vars to hold info for menu and data

            // Top-level menu options
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");

            // Column options
            Dictionary<string, string> columnChoices = new Dictionary<string, string>();
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");

            Console.WriteLine("Welcome to LaunchCode's TechJobs App!");

            // Allow user to search/list until they manually quit with ctrl+c
            while (true)
            {

                string actionChoice = GetUserSelection("View Jobs", actionChoices);

                if (actionChoice.Equals("list"))
                {
                    string columnChoice = GetUserSelection("List", columnChoices);

                    if (columnChoice.Equals("all"))
                    {
                        PrintJobs(JobData.FindAll());
                    }
                    else
                    {
                        List<string> results = JobData.FindAll(columnChoice);

                        Console.WriteLine("\n*** All " + columnChoices[columnChoice] + " Values ***");
                        foreach (string item in results)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else // choice is "search"
                {
                    // How does the user want to search (e.g. by skill or employer)
                    string columnChoice = GetUserSelection("Search", columnChoices);

                    // What is their search term?
                    Console.WriteLine("\nSearch term: ");
                    string searchTerm = Console.ReadLine();

                    List<Dictionary<string, string>> searchResults;

                    // Fetch results
                    if (columnChoice.Equals("all"))
                    {
                        Console.WriteLine("Search all fields not yet implemented.");
                    }
                    else
                    {
                        searchResults = JobData.FindByColumnAndValue(columnChoice, searchTerm);
                        PrintJobs(searchResults);
                    }
                }
            }
        }

        /*
         * Returns the key of the selected item from the choices Dictionary
         */
        private static string GetUserSelection(string choiceHeader, Dictionary<string, string> choices)
        {
            int choiceIdx;
            bool isValidChoice = false;
            string[] choiceKeys = new string[choices.Count];

            int i = 0;
            foreach (KeyValuePair<string, string> choice in choices)
            {
                choiceKeys[i] = choice.Key;
                i++;
            }

            do
            {
                Console.WriteLine("\n" + choiceHeader + " by:");

                for (int j = 0; j < choiceKeys.Length; j++)
                {
                    Console.WriteLine(j + " - " + choices[choiceKeys[j]]);
                }

                string input = Console.ReadLine();
                choiceIdx = int.Parse(input);

                if (choiceIdx < 0 || choiceIdx >= choiceKeys.Length)
                {
                    Console.WriteLine("Invalid choices. Try again.");
                }
                else
                {
                    isValidChoice = true;
                }

            } while (!isValidChoice);

            return choiceKeys[choiceIdx];
        }

        private static void PrintJobs(List<Dictionary<string, string>> someJobs)
        {
            if (someJobs.Count <= 0)
            {
                Console.WriteLine("There are no listings available");
            }
            else
                
            //Iterate over a list of jobs
            foreach (var someJob in someJobs)
            {
                    //Print list of skills, employers, etc
                    Console.WriteLine("\n*****");
                    //nested loop to iterate over each dictionary key
                    foreach (KeyValuePair<string, string> job in someJob)
                {
                    
                    Console.WriteLine("{0} : {1}", job.Key, job.Value);
                  
                }
                
                
            
            }

        }
    }
}
//foreach (KeyValuePair<string, string> job in someJobs)
//{
//    Console.WriteLine(job.Value);
//}



//foreach (string job in someJobs[i].Values)
//{
//    Console.WriteLine(job);
//}


//Console.WriteLine("*****" + "\n"
//                    + "name: " + job.Value[1] + "\n"
//                    + "employer: " + job.Value[2] + "\n"
//                    + "location: " + job.Value[3] + "\n"
//                    + "position type: " + job.Value[4] + "\n"
//                    + "core competency: " + job.Value[5] + "\n"
//                    + "***** ");



//"*****" + "\n"
//                                        + "name: " + job.Value + "\n"
//                                        + "employer: " + job.Value + "\n"
//                                        + "location: " + job.Value + "\n"
//                                        + "position type: " + job.Value + "\n"
//                                        + "core competency: " + job.Value + "\n"
//                                        + "***** ");


//TechJobs in Java 
//private static void printJobs(ArrayList<HashMap<String, String>> someJobs)
//{
//    if (someJobs.size() <= 0)
//    {
//        System.out.println("There are no listings available");

//    }
//    else
//    {
//        // Print list of skills, employers, etc
//        System.out.println("\n*****");

//        for (HashMap<String, String> someJob : someJobs) {
//    for (Map.Entry<String, String> job : someJob.entrySet())
//    {
//        System.out.println(job.getKey() + " : " + job.getValue());
//    }
//    System.out.println("*****");
//}
//        }