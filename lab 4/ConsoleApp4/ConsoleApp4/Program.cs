using System;

class Programm
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(3, 4);
        CheckBox checkbox = new CheckBox("Чекбокс", true);
        RadioButton radiobutton = new RadioButton("Радиокнопка", false);
        Button button = new Button("Кнопка");

        Printer printer = new Printer();

        printer.IAmPrinting(circle);
        printer.IAmPrinting(rectangle);

        printer.IAmPrinting(checkbox);
        printer.IAmPrinting(radiobutton);
        printer.IAmPrinting(button);

        IControl control = checkbox;
        control.Show();
        control.Input();
        control.Resize();

        IControl controls = radiobutton;
        controls.Show();

        ControlElements controlse = radiobutton;
        controlse.Show();


        if (checkbox is ControlElements)
        {
            Console.WriteLine("Объект checkbox является элементом управления.");
        }

        ControlElements element = checkbox as ControlElements;

        if (element != null)
        {
            Console.WriteLine("Успешно выполнено приведение к типу ControlElement через 'as'.");
            element.Show();
        }
        else
        {
            Console.WriteLine("Не удалось привести объект к типу ControlElement.");
        }

    }
}