using System;

abstract class GeometricShape
{
    public abstract double Area();
    public abstract double Perimetr();
    public virtual string ToString()
    {
        return $"Тип объекта: {this.GetType().Name}";
    }
}

class Circle : GeometricShape
{
    public double Radius { get; set; }


    public Circle(double radius)
    {
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