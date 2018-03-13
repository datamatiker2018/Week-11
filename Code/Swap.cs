public class Program
{
    public static void Main()
    {
        int a = 10;
        int b = 20;

        Swap(ref a, ref b);

        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.Read();
    }

    static void Swap(ref int a, ref int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }
}
