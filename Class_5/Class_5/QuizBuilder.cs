using System.Collections.Generic;

namespace Class_5
{
    public class QuizBuilder
    {
        private Quiz quiz;

        public void StartNewQuiz(string name, string description)
        {
            quiz = new Quiz(name, description);
        }

        public void AddSingleAnswerQuestion(string text, string correctAnswer, int score)
        {
            var question = new SingleAnswerQuestion(text, correctAnswer, score);
            quiz.AddQuestion(question);
        }

        public void AddMultipleAnswerQuestion(string text, List<string> choices, string correctAnswer, int score)
        {
            var question = new MultipleAnswerQuestion(text, choices, correctAnswer, score);
            quiz.AddQuestion(question);
        }

        public Quiz Build()
        {
            return quiz;
        }
    }
}
