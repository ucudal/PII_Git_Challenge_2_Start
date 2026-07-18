namespace Ucu.Poo.GitChallenge;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine(Addition.Add(4, 5));
        Console.WriteLine(Subtraction.Subtract(10, 1));
        Console.WriteLine(Multiplication.Multiply(3, 3));
        Console.WriteLine(Division.Divide(18, 2));
    }
}

// Esta clase implementa la operación suma
public class Addition
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

// Esta clase implementa la operación resta
public class Subtraction
{
    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}

// Esta clase implementa la operación multiplicación
public class Multiplication
{
    public static int Multiply(int a, int b)
    {
        return a * b;
    }
}

// Esta clase implementa la operación división
public class Division
{
    public static double Divide(int a, int b)
    {
        return (double)a / b;
    }
}