using System;
using System.Linq;

public static class Extensions
{
    public static string RemoveVowels(this string str)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        return new string(str.Where(c => !vowels.Contains(c)).ToArray());
    }

    public static OneDimensionalArray RemoveFirstFive(this OneDimensionalArray array)
    {
        if (array.ToString().Split(',').Length <= 5) return new OneDimensionalArray(new int[] { });
        int[] result = array.ToString().Split(',').Select(int.Parse).Skip(5).ToArray();
        return new OneDimensionalArray(result);
    }
}
