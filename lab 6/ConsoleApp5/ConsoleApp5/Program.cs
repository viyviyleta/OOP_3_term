using CustomExceptions;
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            UIContainer container = new UIContainer();

            ScreenPosition screenPosition = new ScreenPosition(2, 3);
            var checkBox = new CheckBox("", true);
            checkBox.Position = screenPosition;
            checkBox.Show();
  
            try
            {
                ScreenPosition invalidPosition = new ScreenPosition(-10, -20);
                var button = new Button("InvalidPositionButton");
                button.Position = invalidPosition;
                button.Show();
            }
            catch (InvalidPositionException ex)
            {
                Console.WriteLine($"Ошибка: Неверная позиция элемента. {ex.Message}");
            }

            try
            {
                ControlType unsupportedType = (ControlType)99;  
                var unsupportedControl = new CheckBox("UnsupportedTypeCheckBox", true);

                if (!Enum.IsDefined(typeof(ControlType), unsupportedType))
                {
                    throw new UnsupportedControlTypeException("Недопустимый тип элемента управления.");
                }
            }
            catch (UnsupportedControlTypeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                var invalidCircle = new Circle(-5); 
                container.AddElement(invalidCircle);
            }
            catch (InvalidShapeDimensionsException ex)
            {
                Console.WriteLine($"Ошибка: Неверный размер фигуры. {ex.Message}");
            }

            try
            {
                var nonExistentElement = container.GetElement(11); 
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: Попытка доступа к несуществующему элементу. {ex.Message}");
            }

            Console.WriteLine("------------------------------------------");

            container.ShowAllElements();
            Console.WriteLine($"Общая площадь: {container.GetTotalArea()}");
            Console.WriteLine($"Всего элементов: {container.GetElementCount()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Обработка исключений завершена!");
        }
    }
}
