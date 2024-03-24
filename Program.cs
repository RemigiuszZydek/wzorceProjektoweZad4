using System;

public interface IShape
{
    float GetArea();
}


public class Square
{
    private float sideLength;

    public Square(float sideLength)
    {
        this.sideLength = sideLength;
    }

    public float GetArea()
    {
        return sideLength * sideLength;
    }
}

public class SquareAdapter : IShape
{
    private Square square;

    public SquareAdapter(Square square)
    {
        this.square = square;
    }

    public float GetArea()
    {
        return square.GetArea();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(5);
        SquareAdapter adapter = new SquareAdapter(square);

        Console.WriteLine("Pole kwadratu (Square): " + square.GetArea());
        Console.WriteLine("Pole kwadratu (SquareAdapter): " + adapter.GetArea());


        Console.WriteLine("Pole kwadratu (Funkcja oczekująca na GetArea): " + FunctionExpectGetArea(adapter));
        Console.WriteLine("Pole kwadratu (Funkcja oczekująca na GetArea z adapterem): " + FunctionExpectGetArea(adapter));
    }

    static float FunctionExpectGetArea(IShape obj)
    {
        return obj.GetArea();
    }
}
