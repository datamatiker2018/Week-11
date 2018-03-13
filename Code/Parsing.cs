public class Program
{
    public static void Main()
    {
        Console.Write("What's you favorite number? ");

        string input = Console.ReadLine();
        int number;

        // See https://msdn.microsoft.com/en-us/library/f02979c7(v=vs.110).aspx
        if (!int.TryParse(input, out number))
        {
            Console.WriteLine("You didn't enter a valid integer.");
        }

        Console.WriteLine("Your favorite number squared is " + (number * number));
        Console.Read();
    }
}
