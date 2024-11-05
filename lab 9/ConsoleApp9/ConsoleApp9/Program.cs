using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;

public class Programm
{
    public static void Main()
    {
        IBookColection library = new BookColection();

        Console.WriteLine("Первая коллекция:\n");

        library.AddBook(new Book("Бойцовский клуб", "Чак Паланик", 1996));
        library.AddBook(new Book("Призраки", "Чак Паланик", 2005));
        library.AddBook(new Book("Зеленая миля", "Стивен Кинг", 1996));
        library.AddBook(new Book("Бегущий в лабиринте", "Джеймс Дэшнер", 2013));
        library.AddBook(new Book("Куджо", "Стивен Кинг", 1981));
        library.AddBook(new Book("Выбор", "Эдит Ева Эгер", 2022));
        library.AddBook(new Book("Игрок", "Достоевский", 1866));
        library.AddBook(new Book("1408", "Стивен Кинг", 1997));
        library.AddBook(new Book("Триумфальная арка", "Эрих Мария Ремарк", 1946));

        Console.WriteLine("\n------------------------------------------------------\n");

        library.ShowAllBooks();

        Console.WriteLine("\n------------------------------------------------------\n");

        for (int id = 5; id <= 7; id++)
        {
            library.RemoveBookById(id);
        }

        Console.WriteLine("\n------------------------------------------------------\n");

        Console.WriteLine("Стек\n");

        var stackCollection = new Stack<Book>();

        stackCollection.Push(new Book("На Западном фронте без перемен", "Эрих Мария Ремарк", 1928));
        stackCollection.Push(new Book("Мастер и Маргарита", "Михаил Булгаков", 1966));
        stackCollection.Push(new Book("Выбор", "Эдит Ева Эгер", 2022));
        stackCollection.Push(new Book("Игрок", "Достоевский", 1866));
        stackCollection.Push(new Book("1408", "Стивен Кинг", 1997));

        var popElement = stackCollection.Pop();
        Console.WriteLine("Pop элемент\n" + popElement + "\n");

        var peekElement = stackCollection.Peek();
        Console.WriteLine("Peek элемент\n" + peekElement + "\n");

        foreach (var book in stackCollection)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\n------------------------------------------------------\n");

        var secondCollection = new List<Book>(library.GetBooksDictionary().Values);

        secondCollection.Add(new Book("На Западном фронте без перемен", "Эрих Мария Ремарк", 1928));
        secondCollection.Add(new Book("Мастер и Маргарита", "Михаил Булгаков", 1966));
        secondCollection.Add(new Book("1984", "Джордж Оруэлл", 1949));

        Console.WriteLine("Вторая коллекция:\n");
        foreach (var book in secondCollection)
        {
            Console.WriteLine(book);
        }
        
        secondCollection.RemoveAt(1);

        secondCollection.RemoveAll(book => book.Author == "Эрих Мария Ремарк");

        secondCollection.RemoveAll(book => book.Author == "Стивен Кинг");

        Console.WriteLine("\nОставшиеся книги во второй коллекции:");
        foreach (var book in secondCollection)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\n------------------------------------------------------\n");

        string searchTitle = "1984";
        var bookInSecondCollection = secondCollection.Find(b => b.Title == searchTitle);
        Console.WriteLine($"Результат поиска во второй коллекции для '{searchTitle}': {bookInSecondCollection}");

        Console.WriteLine("\n------------------------------------------------------\n");

        Console.WriteLine("--- ObservableCollection<Book> ---\n");

        ObservableCollection<Book> observableCollection = new ObservableCollection<Book>();

        observableCollection.CollectionChanged += ObservableCollection_Changed;

        observableCollection.Add(new Book("Куджо", "Стивен Кинг", 1981));
        observableCollection.Add(new Book("Выбор", "Эдит Ева Эгер", 2022));
        observableCollection.Add(new Book("Игрок", "Достоевский", 1866));
        observableCollection.Add(new Book("1408", "Стивен Кинг", 1997));
        observableCollection.Add(new Book("Триумфальная арка", "Эрих Мария Ремарк", 1946));

        Console.WriteLine("\n------------------------------------------------------\n");

        observableCollection.RemoveAt(1);
        observableCollection.RemoveAt(3);

        Console.WriteLine("\n------------------------------------------------------\n");

        foreach (var book in observableCollection)
        {
            Console.WriteLine(book.ToString());
        }

    }
    private static void ObservableCollection_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            Console.WriteLine("Добавлен новый элемент: ");
            foreach (Book newBook in e.NewItems)
            {
                Console.WriteLine(newBook);
            }
        }
        else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
        {
            Console.WriteLine("Элемент удален: ");
            foreach (Book oldBook in e.OldItems)
            {
                Console.WriteLine(oldBook);
            }
        }
    }
}