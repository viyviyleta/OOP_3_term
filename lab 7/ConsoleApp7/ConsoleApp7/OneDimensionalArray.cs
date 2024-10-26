using System;
using System.Linq;

public class OneDimensionalArray
{
    private int[] array;

    public OneDimensionalArray(int[] array)
    {
        this.array = array;
    }
    public int this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    public override string ToString()
    {
        return string.Join(",", array);
    }
}


abstract class GeometricShape
{
    public abstract double Area();  
    public abstract double Perimeter();  
    public override string ToString()
    {
        return $"Тип объекта: {this.GetType().Name}";
    }
}

class Circle : GeometricShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть положительным числом.");

        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string ToString()
    {
        return base.ToString() + $", Радиус: {Radius}, Площадь: {Area()}, Периметр: {Perimeter()}";
    }
}

class Rectangle : GeometricShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Ширина и высота должны быть положительными числами.");

        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public override double Perimeter()
    {
        return 2 * (Height + Width);
    }

    public override string ToString()
    {
        return base.ToString() + $", Ширина: {Width}, Высота: {Height}, Площадь: {Area()}, Периметр: {Perimeter()}";
    }
}

