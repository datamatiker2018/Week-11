public class Program
{
    public static void Main()
    {
        Greeter greeter = new Greeter("Hello ");

        greeter.Greet("Rune");
    }
}

class Greeter
{
    private string _greeting;

    public Greeter(string greeting)
    {
        _greeting = greeting;
    }

    public void Greet(string name)
    {
        Console.WriteLine(_greeting + name);
    }
}
