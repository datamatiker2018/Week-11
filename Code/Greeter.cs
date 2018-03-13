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
