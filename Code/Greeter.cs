public class Program
{
    public static void Main()
    {
        Greeter greeter = new Greeter("Hello ");
            
        greeter.Greet("Rune");
        greeter.Greet("Rune", true);

        Console.Read();
    }
}

class Greeter
{
    private string _greeting;

    public Greeter(string greeting)
    {
        _greeting = greeting;
    }

    public void Greet(string name, bool yell = false)
    {
        string greeting = _greeting + name;

        if (yell)
        {
            greeting = greeting + "!";
        }

        Console.WriteLine(greeting);
    }
}
