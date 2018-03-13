public class Program
{
    public static void Main()
    {
        // Create some instances of our Greeter, with unique greetings
        Greeter traditional = new Greeter("Hello!");
        Greeter casual = new Greeter("Hey!");
        Greeter cool = new Greeter("Yo!");

        traditional.Greet(); // Hello!
        casual.Greet(); // Hey!
        cool.Greet(); // Yo!
    }
}

class Greeter
{
    private string _greeting;

    public Greeter(string greeting)
    {
        // We want a unique greeting for each instance of our greeter
        _greeting = greeting;
    }

    public void Greet()
    {
        // Now the greeter will use the instance specific greeting
        Console.WriteLine(_greeting);
    }
}
