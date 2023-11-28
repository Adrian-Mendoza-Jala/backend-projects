namespace Class_5
{
    public class SingleAnswerQuestion : Question
    {
        public SingleAnswerQuestion(string text, string correctAnswer, int score)
            : base(text, correctAnswer, score)
        {
        }

        public override void Display()
        {
            Console.WriteLine(Text);
        }

        public override bool CheckAnswer(string answer)
        {
            return answer.Trim().Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
