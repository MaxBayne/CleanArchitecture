namespace CleanArchitecture.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            while (true)
            {
                Console.WriteLine(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                Thread.Sleep(1000);
            }
        }
    }
}
