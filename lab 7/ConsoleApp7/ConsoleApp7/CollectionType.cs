using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class CollectionType<T> where T : class
{
    private List<T> collection = new List<T>();

    public void Add(T item)
    {
        collection.Add(item);
    }

    public bool Remove(T item)
    {
        return collection.Remove(item);
    }

    public IEnumerable<T> ViewAll()
    {
        return collection;
    }

    public T Find(Predicate<T> predicate)
    {
        return collection.Find(predicate);
    }


    public void SaveToFile(string filePath)
    {
        try
        {
            string json = JsonConvert.SerializeObject(collection, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto 
            });
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Коллекция успешно сохранена в файл: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении в файл: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Finally");
        }
    }

    public void LoadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                collection = JsonConvert.DeserializeObject<List<T>>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto 
                });
                Console.WriteLine($"Коллекция успешно загружена из файла: {filePath}");
            }
            else
            {
                Console.WriteLine($"Файл не найден: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке из файла: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Finally");
        }
    }
}
