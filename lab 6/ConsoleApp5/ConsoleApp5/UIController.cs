using System;

class UIController
{
    private UIContainer container;

    public UIController(UIContainer container)
    {
        this.container = container;
    }

    public void ShowAllButtons()
    {
        foreach (var button in container.GetAllButtons())
        {
            Console.WriteLine(button.ToString());
        }
    }

    public void ShowTotalElements()
    {
        Console.WriteLine($"Всего элементов на UI: {container.GetElementCount()}");
    }

    public void ShowTotalArea()
    {
        Console.WriteLine($"Общая площадь всех фигур: {container.GetTotalArea()}");
    }
}
