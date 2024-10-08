using System;

class Program
{
    static void Main()
    {
        ControlElements radio = new RadioButton("Radio", false)
        {
            Position = new ScreenPosition(12, 21)
        };
        Console.WriteLine($"Cоздан элемент:{radio.Type} - {radio.Name} - {radio.Position}");

        Console.WriteLine("------------------------------------------");

        UIContainer container = new UIContainer();

        container.AddElement(new Button("Кнопка"));
        container.AddElement(new Button("Button"));
        container.AddElement(new CheckBox("Чекбокс", true));

        ScreenPosition[] newPositions = {
            new ScreenPosition(10, 20),
            new ScreenPosition(12, 22),
            new ScreenPosition(33, 99),
            new ScreenPosition(10, 34)
        };

        int positionIndex = 0;
        for (int i = 0; i < container.GetElementCount(); i++)
        {
            if (container.GetElement(i) is ControlElements element && positionIndex < newPositions.Length)
            {
                element.MoveTo(newPositions[positionIndex]);
                positionIndex++;
            }
        }

        container.AddElement(new Circle(5));
        container.AddElement(new Rectangle(3, 4));

        Console.WriteLine("------------------------------------------");

        container.ShowAllElements();

        Console.WriteLine("------------------------------------------");

        foreach (var button in container.GetAllButtons())
        {
            Console.WriteLine(button.Name);
        }

        Console.WriteLine("------------------------------------------");

        Console.WriteLine($"Общая площадь: {container.GetTotalArea()}");

        Console.WriteLine($"Всего элементов: {container.GetElementCount()}");
    }
}
