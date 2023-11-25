namespace Class_4.Tests;

public class AddCalculatorTests
{
    [Fact]
    public void Add_TwoIntegers_ReturnsSum()
    {
        int firstNumber = 10;
        int secondNumber = 20;
        int expectedSum = 30;

        var result = AddCalculator.AddValues(firstNumber, secondNumber);
        int actualSum = Convert.ToInt32(result);

        Assert.Equal(expectedSum, actualSum);
    }

    [Fact]
    public void Add_TwoDoubles_ReturnsSum()
    {
        double firstNumber = 3.14;
        double secondNumber = 2.56;
        double expectedSum = 5.7;

        var actualSum = AddCalculator.AddValues(firstNumber, secondNumber);

        Assert.Equal(expectedSum, actualSum);
    }

    [Fact]
    public void Add_TwoStrings_ReturnsConcatenation()
    {
        string firstString = "Hello";
        string secondString = "World";
        string expectedConcatenation = "HelloWorld";

        var actualConcatenation = AddCalculator.AddValues(firstString, secondString);

        Assert.Equal(expectedConcatenation, actualConcatenation);
    }

    [Fact]
    public void Add_DifferentTypes_ThrowsArgumentException()
    {
        string stringValue = "Hello";
        int intValue = 10;
        string expectedExceptionMessage = "Values are of different types.";

        var exception = Assert.Throws<ArgumentException>(() => AddCalculator.AddValues(stringValue, intValue));
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [Fact]
    public void Add_UnsupportedType_ThrowsArgumentException()
    {
        var unsupportedTypeValue1 = new object();
        var unsupportedTypeValue2 = new object();

        Assert.Throws<ArgumentException>(() => AddCalculator.AddValues(unsupportedTypeValue1, unsupportedTypeValue2));
    }
}