namespace Task2;

internal class Program
{
   private static void Main(string[] args)
   {
      long size = Mass.Calculate(@"C:/Programming");
      Console.WriteLine(size);
   }
}