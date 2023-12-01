using System;
using System.Collections.Generic;

namespace Class_8
{
    class Program
    {
        static List<Quiz> quizzes = new List<Quiz>();

        static void Main(string[] args)
        {
            InitializeQuizzes();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayQuiz();
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Quiz Game");
            Console.WriteLine("1. Play Quiz");
            Console.WriteLine("2. Exit");
        }

        static void PlayQuiz()
        {
            foreach (Quiz quiz in quizzes)
            {
                int totalScore, resultScore;

                quiz.DisplayDetails();
                totalScore = quiz.CalculateTotalScore();
                resultScore = quiz.ConductQuiz();
                Console.WriteLine($"Your Score: {resultScore}/{totalScore}");
            }
        }

        static void InitializeQuizzes()
        {
            var quizBuilder = new QuizBuilder();

            quizBuilder.StartNewQuiz("* General Knowledge *", "Quiz description.");
            quizBuilder.AddSingleAnswerQuestion("What is the common term for an error in a program?", "Bug", 10);
            quizBuilder.AddSingleAnswerQuestion("Which language is commonly used for data science and machine learning?", "Python", 10);
            quizBuilder.AddMultipleAnswerQuestion("Which of the following are programming languages?",
                                                  new List<string> { "Java", "Paris", "HTML" },
                                                  "Java", 20);

            var quiz = quizBuilder.Build();
            quizzes.Add(quiz);
        }
    }
}
