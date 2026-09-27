namespace Lab2_App;

public static class Variant7Utils
{
    public static bool AreAnagrams(string? str1, string? str2)
    {
        if (str1 == null || str2 == null)
            return false;

        var cleanStr1 = new string(str1.ToLower().Where(char.IsLetterOrDigit).OrderBy(c => c).ToArray());
        var cleanStr2 = new string(str2.ToLower().Where(char.IsLetterOrDigit).OrderBy(c => c).ToArray());

        return cleanStr1 == cleanStr2;
    }

    public static double CalculateAverage(int[]? numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Масив не може бути порожнім.");

        return numbers.Average();
    }
}