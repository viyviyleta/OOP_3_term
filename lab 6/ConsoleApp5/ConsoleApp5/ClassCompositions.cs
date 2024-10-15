using System;
using CustomExceptions;
using System.Diagnostics;
abstract class GeometricShape
{
    public abstract double Area();
    public abstract double Perimetr();
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
            throw new InvalidShapeDimensionsException("Радиус должен быть положительным");
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimetr()
    {
        return 2 * Math.PI * Radius;
    }

    public override string ToString()
    {
        return base.ToString() + $", Радиус: {Radius}, Площадь: {Area()}, Периметр: {Perimetr()}";
    }
}

class Rectangle : GeometricShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new InvalidShapeDimensionsException("Ширина и высота должны быть положительными");
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public override double Perimetr()
    {
        return 2 * (Height + Width);
    }

    public override string ToString()
    {
        return base.ToString() + $", Ширина: {Width}, Высота: {Height}, Площадь: {Area()}, Периметр: {Perimetr()}";
    }
}