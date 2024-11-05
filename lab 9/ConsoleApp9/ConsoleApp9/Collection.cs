using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBookColection
{
    void AddBook(Book book);
    void RemoveBookById(int id);
    Book FindBookByTitle(string title);
    void ShowAllBooks();
    IDictionary<int, Book> GetBooksDictionary();
}

public class BookColection: IBookColection
{
    private IDictionary<int, Book> bookDictionary = new Dictionary<int, Book>();
    private int nextID = 1;

    public void AddBook(Book book)
    {
        bookDictionary[nextID] = book;
        nextID++;
        Console.WriteLine($"Добавлена книга: {book}");
    }

    public void RemoveBookById(int id)
    {
        if (bookDictionary.ContainsKey(id))
        {
            var book = bookDictionary[id];
            bookDictionary.Remove(id);
            Console.WriteLine($"Удалена книга: {book.Title}, автор: {book.Author}, год: {book.Year}");
        }
        else
        {
            Console.WriteLine("Такой книги в коллекции нет!");
        }
    }

    public Book FindBookByTitle(string title)
    {
        return bookDictionary.Values.FirstOrDefault(book =>
        book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public void ShowAllBooks()
    {
        Console.WriteLine("Список книг в коллекции:");
        foreach(var book in bookDictionary)
        {
            Console.WriteLine($"ID: {book.Key}, Книга: {book.Value}");
        }
    }

    public IDictionary<int, Book> GetBooksDictionary()
    {
        return bookDictionary;
    }
}

