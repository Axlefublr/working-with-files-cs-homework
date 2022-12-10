using Libraries;
namespace Task2;

internal class Program
{
   private static void Main(string[] args)
   {
      long size = Mass.Calculate(Utils.GetFolderPath());
      Console.WriteLine("The size of this folder is: " + size + " (in bytes)");
   }
}