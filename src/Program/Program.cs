namespace Ucu.Poo.GitChallenge;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine(Suma.Sumar(1, 2));
        Console.WriteLine(Resta.Restar(3, 4));
        Console.WriteLine(Multiplicacion.Multiplicar(5, 6));
        Console.WriteLine(Division.Dividir(7, 8));
    }
}

// Esta clase implementa la operación suma
public class Suma
{
    public static int Sumar(int a, int b)
    {
        return a - b;
    }
}

// Esta clase implementa la operación resta
public class Resta
{
    public static int Restar(int a, int b)
    {
        return a - b;
    }
}

// Esta clase implementa la operación multiplicación
public class Multiplicacion
{
    public static int Multiplicar(int a, int b)
    {
        return a * b;
    }
}

// Esta clase implementa la operación división
public class Division
{
    public static double Dividir(int a, int b)
    {
        return (double)a / b;
    }
}