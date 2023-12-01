using Class_8;
using Moq;
using System.Text.RegularExpressions;

namespace Class_8_Tests
{
    public class QuizTests
    {
        [Fact]
        public void ConductQuiz_CorrectAnswer_IncreasesScore()
        {
            var mockQuestion = new Mock<Question>("What is 2+2?", "4", 10);
            mockQuestion.Setup(q => q.Display()).Callback(() => Console.WriteLine(mockQuestion.Object.Text));
            mockQuestion.Setup(q => q.CheckAnswer(It.IsAny<string>())).Returns((string answer) => answer == mockQuestion.Object.CorrectAnswer);

            var quiz = new Quiz("Test Quiz", "A simple test");
            quiz.AddQuestion(mockQuestion.Object);

            var input = new StringReader("4\n");
            Console.SetIn(input);

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            int score = quiz.ConductQuiz();

            Assert.Equal(10, score);
        }

        [Fact]
        public void ConductQuiz_IncorrectAnswer_DoesNotIncreaseScore()
        {
            var quiz = new Quiz("Test Quiz", "A simple test");
            quiz.AddQuestion(new SingleAnswerQuestion("What is 2+2?", "4", 10));
            StringReader input = new StringReader("5");
            Console.SetIn(input);

            int score = quiz.ConductQuiz();

            Assert.Equal(0, score);
        }

        //[Fact]
        //public void ConductQuiz_InvalidInput_ThrowsInvalidInputException()
        //{
        //    var quiz = new Quiz("Test Quiz", "A simple test");
        //    quiz.AddQuestion(new SingleAnswerQuestion("What is 2+2?", "4", 10));
        //    StringReader input = new StringReader("?{}[]~’’ ” ”");
        //    Console.SetIn(input);

        //    Assert.Throws<InvalidInputException>(() => quiz.ConductQuiz());
        //}

        [Fact]
        public void ConductQuiz_InvalidInput_PromptsAgain()
        {
            var quiz = new Quiz("Test Quiz", "A simple test");
            quiz.AddQuestion(new SingleAnswerQuestion("What is 2+2?", "4", 10));

            var input = new StringReader("?{}[]~’’ ” ”\n4\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            quiz.ConductQuiz();

            string expectedErrorMessage = "Input contains restricted symbols.";
            string expectedQuestionText = "What is 2+2?";

            var outputString = output.ToString();
            Assert.Contains(expectedErrorMessage, outputString);
            Assert.Equal(2, Regex.Matches(outputString, expectedQuestionText).Count);
        }

        [Fact]
        public void ConductQuiz_MultipleQuestions_CalculatesTotalScore()
        {
            var quiz = new Quiz("Test Quiz", "A simple test");
            quiz.AddQuestion(new SingleAnswerQuestion("What is 2+2?", "4", 10));
            quiz.AddQuestion(new SingleAnswerQuestion("What is the capital of Bolivia?", "Sucre", 15));
            StringReader input = new StringReader("4\nSucre");
            Console.SetIn(input);

            int score = quiz.ConductQuiz();

            Assert.Equal(25, score);
        }
    }
}