using System;
using CustomExceptions;
using System.Diagnostics;
using System.Xml.Linq;
interface IControl
{
    void Show();
    void Input();
    void Resize();
    void MoveTo(ScreenPosition newPosition);
}
public enum ControlType
{
    Button,
    CheckBox,
    RadioButton
}

public abstract partial class ControlElements
{
    public string Name { get; set; }
    public ScreenPosition Position { get; set; }
    public ControlType Type { get; set; }

    public ControlElements(string name, ScreenPosition position, ControlType type)
    {
        Debug.Assert(!string.IsNullOrWhiteSpace(name), "Ошибка: Имя элемента не должно быть пустым");

        Name = name;
        Position = position;
        Type = type;
    }

    public virtual void Show()
    {
        Console.WriteLine($"'{Name}' отображен на экране на позиции {Position}");
    }

    public abstract void Input();
    public abstract void Resize();

    public override string ToString()
    {
        return $"Элемент управления: {Type} - {Name}, Позиция: {Position}";
    }
}

sealed class CheckBox : ControlElements
{
    public bool IsChecked { get; set; }

    public CheckBox(string name, bool isChecked) 
        : base(name, new ScreenPosition(0, 0), ControlType.CheckBox)
    {
        IsChecked = isChecked;
    }

    public override void Input()
    {
        Console.WriteLine($"Ввод для {Name}. Установлен: {IsChecked}");
    }

    public override void Resize()
    {
        Console.WriteLine($"{Name} изменен.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Установлен: {IsChecked}";
    }
}
class RadioButton : ControlElements
{
    public bool IsSelected { get; set; }

    public RadioButton(string name, bool isSelected) 
        : base(name, new ScreenPosition(0, 0), ControlType.RadioButton)
    {
        IsSelected = isSelected;
    }
    public override void Show()
    {
        Console.WriteLine($" ControlElements {Name}. Выбран: {IsSelected}");
    }

    public override void Input()
    {
        Console.WriteLine($"Ввод для {Name}. Выбран: {IsSelected}");
    }

    public override void Resize()
    {
        Console.WriteLine($"{Name} изменен.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Выбран: {IsSelected}";
    }
}

class Button : ControlElements
{
    public Button(string name) 
        : base(name, new ScreenPosition(0, 0), ControlType.Button) { }

    public override void Input()
    {
        Console.WriteLine($"Ввод для {Name}. Нажата.");
    }

    public override void Resize()
    {
        Console.WriteLine($"{Name} изменен.");
    }
}
