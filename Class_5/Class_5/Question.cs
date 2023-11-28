namespace Class_5
{
    public abstract class Question
    {
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }

        protected Question(string text, string correctAnswer, int score)
        {
            Text = text;
            CorrectAnswer = correctAnswer;
            Score = score;
        }

        public abstract void Display();
        public abstract bool CheckAnswer(string answer);
    }
}
