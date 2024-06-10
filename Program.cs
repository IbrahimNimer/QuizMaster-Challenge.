using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuizMaster_Challenge_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartQuiz().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Quiz is done.");
            }
        }

        static async Task StartQuiz()
        {
            Console.WriteLine("Welcome to the World Cup 2022 Quiz!");
            Console.WriteLine("Answer by writing the correct player or team name.\n");

            List<string> questions = new List<string>
            {
                "Q1) World Cup 2022 Winner?\n1. Brazil\n2. France\n3. Argentina\n4. Spain",
                "Q2) World Cup 2022 Best Player?\n1. Mbappe\n2. Messi\n3. Neymar\n4. Modric",
                "Q3) World Cup 2022 Topscorer?\n1. Lewandowski\n2. Messi\n3. Kane\n4. Mbappe",
                "Q4) World Cup 2022 Best Young Player?\n1. Gavi\n2. Pedri\n3. Bellingham\n4. Enzo",
                "Q5) World Cup 2022 Best Goalkeeper?\n1. Alisson\n2. Lloris\n3. Martinez\n4. Courtois",
                "Q6) World Cup 2022 Best Goal?\n1. Richarlison vs Serbia\n2. Mbappe vs Argentina\n3. Messi vs Mexico\n4. Di Maria vs France",
                "Q7) World Cup 2022 Best Coach?\n1. Tite\n2. Deschamps\n3. Scaloni\n4. Southgate"
            };

            List<string> answers = new List<string>
            {
                "3. Argentina",
                "2. Messi",
                "4. Mbappe",
                "4. Enzo",
                "3. Martinez",
                "1. Richarlison vs Serbia",
                "3. Scaloni"
            };

            List<string> options = new List<string>
            {
                "1", "2", "3", "4"
            };

            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                bool validAnswer = false;

                while (!validAnswer)
                {
                    Console.WriteLine(questions[i]);

                    string userAnswer = "";
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    while (stopwatch.Elapsed < TimeSpan.FromSeconds(10))
                    {
                        if (Console.KeyAvailable)
                        {
                            Console.WriteLine("\nYour answer :");
                            userAnswer = Console.ReadLine();
                            break;
                        }
                        Console.Write($"\rTime remaining: {10 - stopwatch.Elapsed.Seconds} seconds  ");
                        await Task.Delay(100);
                    }

                    stopwatch.Stop();

                    if (string.IsNullOrWhiteSpace(userAnswer))
                    {
                        Console.WriteLine("\nTime's up! Moving to the next question.");
                        break;
                    }

                    if (!options.Contains(userAnswer.Trim()))
                    {
                        Console.WriteLine("Invalid answer. Please choose a valid option (1, 2, 3, or 4).\n");
                        continue;
                    }

                    if (userAnswer.Trim().Equals(answers[i].Substring(0, 1), StringComparison.OrdinalIgnoreCase))
                    {
                        score++;
                        Console.WriteLine("Correct!\n");
                        validAnswer = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect. The correct answer is: " + answers[i] + "\n");
                        validAnswer = true;
                    }
                }
            }
            Console.WriteLine("Quiz completed. Your score is: " + score + " out of " + questions.Count);
        }
    }
}
