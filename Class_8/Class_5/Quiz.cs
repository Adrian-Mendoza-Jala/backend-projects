using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Class_8
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

        private bool IsValidInput(string input)
        {
            var restrictedSymbols = new Regex("[?{}\\[\\]~’“”]");
            return !restrictedSymbols.IsMatch(input);
        }

        public int ConductQuiz()
        {
            int userScore = 0;
            foreach (Question question in Questions)
            {
                bool isValidInputReceived = false;
                while (!isValidInputReceived)
                {
                    try
                    {
                        question.Display();
                        Console.WriteLine("Your answer: ");
                        string userAnswer = Console.ReadLine();

                        if (!IsValidInput(userAnswer))
                        {
                            throw new InvalidInputException("Input contains restricted symbols.");
                        }

                        isValidInputReceived = true;

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
                    catch (InvalidInputException ex)
                    {
                        Logger.LogException(ex);
                        Console.WriteLine(ex.Message);
                        //throw;
                    }
                }
            }
            return userScore;
        }
    }
}
