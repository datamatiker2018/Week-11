public class Program
{
    public static void Main()
    {
        Foo.Call();
    }
}

class Foo
{
    public static void Call()
    {
        Baz.Call();
    }
}

class Baz
{
    public static void Call()
    {
        Bar.Call();
    }
}

class Bar
{
    public static void Call()
    {
        Console.WriteLine("Hello World!");
    }
}
