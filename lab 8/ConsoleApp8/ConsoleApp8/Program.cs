using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Programm
{
    public static void Main()
    {
        var user1 = new User("Violetta");
        var user2 = new User("Anna");
        var user3 = new User("Maksimus");

        user1.MoveUser += user1.MoveOn;

        user2.MoveUser += user2.MoveOn;
        user2.Compress += user2.CompressOn;

        Console.WriteLine("--------Перемещение--------\n");
        user1.TriggerMove(2, 3);
        user2.TriggerMove(-12, 23);
        user3.TriggerMove(12, 12);

        Console.WriteLine("\n--------Сжатие--------\n");
        try
        {
            user1.TriggerComress(2);
            user2.TriggerComress(1);
            user3.TriggerComress(1.2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n--------Работа со строкой--------\n");

        string text = "С,:егоДНя  -  т!!от  сам...ый   ---ДЕн--Ь";

        var processingPipeline = new List<Func<string, string>>
        {
            EditString.RemovePunctuation,
            EditString.RemoveSpaces,
            EditString.ToUpperCase,
            EditString.ToLowerCase,
            EditString.AddExclamation
        };

        foreach (var process in processingPipeline)
        {
            text = process(text);
            Console.WriteLine(text);
        }

        Console.WriteLine("\nИтоговая обработанная строка:");
        Console.WriteLine(text);
    }
}