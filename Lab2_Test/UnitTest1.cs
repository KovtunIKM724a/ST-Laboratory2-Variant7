using Lab2_App;
using Xunit;

namespace Lab2_Test;

public class UnitTest1
{
    [Theory]
    [InlineData("listen", "silent", true)]
    [InlineData("triangle", "integral", true)]
    [InlineData("apple", "banana", false)]
    [InlineData("Hello", "Olleh", true)]
    public void AreAnagrams_ReturnsExpectedResult(string str1, string str2, bool expected)
    {
        bool actual = Variant7Utils.AreAnagrams(str1, str2);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AreAnagrams_NullInput_ReturnsFalse()
    {
        bool result = Variant7Utils.AreAnagrams(null, "test");
        Assert.False(result);
    }

    [Fact]
    public void CalculateAverage_ValidArray_ReturnsCorrectAverage()
    {
        int[] numbers = { 2, 4, 6, 8, 10 };
        double actual = Variant7Utils.CalculateAverage(numbers);
        Assert.Equal(6.0, actual);
    }

    [Fact]
    public void CalculateAverage_EmptyArray_ThrowsArgumentException()
    {
        int[] numbers = Array.Empty<int>();
        Assert.Throws<ArgumentException>(() => Variant7Utils.CalculateAverage(numbers));
    }
}