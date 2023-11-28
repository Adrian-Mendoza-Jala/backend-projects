namespace Class_5
{
    public class MultipleAnswerQuestion : Question
    {
        public List<string> Choices { get; private set; }

        public MultipleAnswerQuestion(string text, List<string> choices, string correctAnswer, int score)
            : base(text, correctAnswer, score)
        {
            Choices = choices;
        }

        public override void Display()
        {
            Console.WriteLine(Text);
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswer(string answer)
        {
            return answer.Trim().Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
