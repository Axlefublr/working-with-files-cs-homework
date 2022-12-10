using System.IO;

namespace Task1;
internal class Program
{
   private static void Main(string[] args)
   {
      Deleter.DeleteEverythingInside(GetFolderPath());
   }

   private static string GetFolderPath()
   {
      string? input = "";
      while (string.IsNullOrEmpty(input))
      {
         Console.Write("Enter the directory path: ");
         input = Console.ReadLine();
      }
      return input;
   }
}