using System;
using System.Collections.Generic;

namespace Class_5
{
    public class Quiz
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string name, string description)
        {
            Name = name;
            Description = description;
            Questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Quiz: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Number of Questions: {Questions.Count}");
        }

        
        public int CalculateTotalScore()
        {
            int totalScore = 0;
            foreach (var question in Questions)
            {
                totalScore += question.Score;
            }
            return totalScore;
        }


        public int ConductQuiz()
        {
            int userScore = 0;
            foreach (Question question in Questions)
            {
                question.Display();
                Console.WriteLine("Your answer: ");
                string userAnswer = Console.ReadLine();
                if (question.CheckAnswer(userAnswer))
                {
                    Console.WriteLine("Correct!");
                    userScore += question.Score;
                }
                else
                {
                    Console.WriteLine($"Incorrect! The correct answer is: {question.CorrectAnswer}");
                }
            }
            return userScore;
        }
    }
}
