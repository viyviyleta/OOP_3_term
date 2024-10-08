using System;
using System.Collections.Generic;

class UIContainer
{
    private List<object> elements = new List<object>();

    public List<object> Elements
    {
        get { return elements; }
        set { elements = value; }
    }

    public void AddElement(object element)
    {
        elements.Add(element);
    }

    public void RemoveElement(object element)
    {
        elements.Remove(element);
    }

    public ControlElements GetElement(int index)
    {
        if (index < 0 || index >= elements.Count)
            throw new IndexOutOfRangeException("Индекс за пределами диапазона элементов.");

        return elements[index] as ControlElements
               ?? throw new InvalidCastException("Элемент не является типом ControlElements.");
    }

    public void ShowAllElements()
    {
        foreach (object element in elements)
        {
            if (element is ControlElements controlElement)
            {
                controlElement.Show();
            }
            else
                if (element is GeometricShape shape)
            {
                Console.WriteLine(shape.ToString());
            }
        }
    }

    public int GetElementCount()
    {
        return elements.Count;
    }

    public double GetTotalArea()
    {
        double totalArea = 0;
        foreach (var element in elements)
        {
            if (element is GeometricShape shape)
            {
                totalArea += shape.Area();
            }
        }
        return totalArea;
    }

    public IEnumerable<Button> GetAllButtons()
    {
        foreach (var element in elements)
        {
            if (element is Button button)
            {
                yield return button;
            }
        }
    }
}

