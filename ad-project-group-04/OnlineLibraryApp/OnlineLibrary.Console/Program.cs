using OnlineLibrary.Console.Views;

internal class Program
{
    private static void Main(string[] args)
    {
        Data.NewData();
        Console.WriteLine("Done Processing!");

        Console.Clear();
        ReadFromUser.runApp();
    }
}