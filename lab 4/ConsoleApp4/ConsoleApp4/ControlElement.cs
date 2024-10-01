using System;
using System.Xml.Linq;

interface IControl
{
    void Show();
    void Input();
    void Resize();
}

abstract class ControlElements 
{
    public string Name { get; set; }

    public ControlElements(string name)
    {
        Name = name;
    }

    public virtual void Show()
    {
        Console.WriteLine($"{Name} отображен на экране");
    }
    public abstract void Input();
    public abstract void Resize();

    public override string ToString()
    {
        return $"Элемент управления: {Name}";
    }
}

sealed class CheckBox : ControlElements, IControl
{
    public bool IsChecked { get; set; }

    public CheckBox(string name, bool isChecked) : base(name)
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

class RadioButton : ControlElements, IControl
{
    public bool IsSelected { get; set; }

    public RadioButton(string name, bool isSelected) : base(name)
    {
        IsSelected = isSelected;
    }

    void IControl.Show()
    {
        Console.WriteLine($" IControl {Name}. Выбран: {IsSelected}");
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
    public Button(string name) : base(name) { }

    public override void Input()
    {
        Console.WriteLine($"Ввод для {Name}. Нажата.");
    }

    public override void Resize()
    {
        Console.WriteLine($"{Name} изменен.");
    }
}
