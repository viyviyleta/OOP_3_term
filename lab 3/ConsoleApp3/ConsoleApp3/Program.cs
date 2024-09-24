using System;

class Program
{
    static void Main(string[] args)
    {
        OneDimensionalArray array1 = new OneDimensionalArray(new int[] { 1, 2, 3, 4, 5, 6});
        OneDimensionalArray array2 = new OneDimensionalArray(new int[] { 6, 7, 8, 9, 10 });

        OneDimensionalArray resultArray = array1 - 2;
        Console.WriteLine("Результат вычитания: " + resultArray + "\n");

        bool contains = array1 > 3;
        Console.WriteLine("Содержит ли 3: " + contains + "\n");

        if (array1 == array2)
        {
            Console.WriteLine("Массивы равны.\n");
        }
        else
        {
            Console.WriteLine("Массивы не равны.\n");
        }

        OneDimensionalArray combinedArray = array1 + array2;
        Console.WriteLine("Объединение массивов: " + combinedArray + '\n');

        Console.WriteLine("Сумма элементов: " + StatisticOperation.Sum(array1) + '\n');
        Console.WriteLine("Разница между max и min: " + StatisticOperation.MaxMinDifference(array1) + '\n');
        Console.WriteLine("Количество элементов: " + StatisticOperation.CountElements(array1) + '\n');

        string text = "Hello World";

        Console.WriteLine("Удаление гласных: " + text.RemoveVowels() + '\n');

        OneDimensionalArray reduceArray = array1.RemoveFirstFive();
        Console.WriteLine("Удаление первых пяти элементов: " + reduceArray + '\n');

        int[] arr = { 1, 2, 3, 4, 5 };
        OneDimensionalArray oneDimArray = new OneDimensionalArray(arr);

        Console.WriteLine("Информация о производственной организации:");
        Console.WriteLine(oneDimArray.production.ToString());


        Console.WriteLine("\nИнформация о разработчике:");
        Console.WriteLine(oneDimArray.developer.ToString());
    }
}
