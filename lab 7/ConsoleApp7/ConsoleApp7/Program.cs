using System;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {

        //CollectionType<int> intCollection = new CollectionType<int>();
        //Console.WriteLine("-----------(int)-----------");
        //intCollection.Add(111);
        //intCollection.Add(2222);
        //intCollection.Add(33333);

        //Console.WriteLine("Коллекция целых чисел:\n");
        //foreach (var item in intCollection.ViewAll())
        //{
        //    Console.WriteLine(item);
        //}

        //CollectionType<char> charCollection = new CollectionType<char>();
        //Console.WriteLine("\n-----------(char)-----------");
        //charCollection.Add('F');
        //charCollection.Add('I');
        //charCollection.Add('T');

        //Console.WriteLine("Коллекция вещественных чисел:\n");
        //foreach (var item in charCollection.ViewAll())
        //{
        //    Console.WriteLine(item);
        //}

        //CollectionType<string> stringCollection = new CollectionType<string>();
        //Console.WriteLine("\n-----------(string)-----------");
        //stringCollection.Add("Babich");
        //stringCollection.Add("Violetta");
        //stringCollection.Add("BSTU");

        //Console.WriteLine("Коллекция строк:\n");
        //foreach (var item in stringCollection.ViewAll())
        //{
        //    Console.WriteLine(item);
        //}

        Console.WriteLine("\n-------------------------------------------------");

        OneDimensionalArray array1 = new OneDimensionalArray(new int[] { 1, 2, 3, 4, 5 });
        OneDimensionalArray array2 = new OneDimensionalArray(new int[] { 6, 7, 8, 9, 10 });

        Console.WriteLine("Массивы:\n");
        Console.WriteLine("Массив 1: " + array1.ToString());
        Console.WriteLine("Массив 2: " + array2.ToString());

        Console.WriteLine("\n-------------------------------------------------");

        GeometricShape circle = new Circle(5);
        GeometricShape rectangle = new Rectangle(4, 6);

        Console.WriteLine("Геометрические фигуры:\n");
        Console.WriteLine(circle.ToString());
        Console.WriteLine(rectangle.ToString());

        Console.WriteLine("\n-------------------------------------------------");

        CollectionType<OneDimensionalArray> arrayCollection = new CollectionType<OneDimensionalArray>();
        arrayCollection.Add(array1);
        arrayCollection.Add(array2);

        Console.WriteLine("Коллекция одномерных массивов\n");
        foreach (var item in arrayCollection.ViewAll())
        {
            Console.WriteLine("Массив: " + item);
        }

        Console.WriteLine("\n-------------------------------------------------");

        CollectionType<GeometricShape> shapeCollection = new CollectionType<GeometricShape>();
        shapeCollection.Add(circle);
        shapeCollection.Add(rectangle);

        Console.WriteLine("Коллекция геометрических фигур:\n");
        foreach (var shape in shapeCollection.ViewAll())
        {
            Console.WriteLine(shape);
        }

        Console.WriteLine("\n-------------------------------------------------");

        string filePath = "D:\\3 семестр\\OOP\\lab 7\\ConsoleApp7\\ConsoleApp7\\collection.json";

        CollectionType<OneDimensionalArray> loadedCollection = new CollectionType<OneDimensionalArray>();
        loadedCollection.LoadFromFile(filePath);

        Console.WriteLine("\nЗагруженная коллекция из файла:\n");
        foreach (var item in loadedCollection.ViewAll())
        {
            Console.WriteLine(item);
        }

        var foundItem = loadedCollection.Find(arr => arr.ToString() == "1,2,3,4,5");
        if (foundItem != null)
        {
            Console.WriteLine("\nНайденный массив: " + foundItem);
        }
    }
}
