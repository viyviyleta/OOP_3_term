using System;
using System.Linq;

public static class StatisticOperation
{
    public static int Sum(OneDimensionalArray array)
    {
        return array.ToString().Split(',').Select(int.Parse).Sum();
    }

    public static int MaxMinDifference(OneDimensionalArray array)
    {
        int[] elements = array.ToString().Split(',').Select(int.Parse).ToArray();
        return elements.Max() - elements.Min();
    }

    public static int CountElements(OneDimensionalArray array)
    {
        return array.ToString().Split(',').Length;
    }
}
