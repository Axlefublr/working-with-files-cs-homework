using Libraries;
using Task1;

namespace Task3;
internal class Program
{
   private static void Main(string[] args)
   {
      string path = Utils.GetFolderPath();
      long size = Mass.Calculate(path);
      Console.WriteLine("Size of the folder yet to be cleaned, in bytes: " + size);
      Deleter.DeleteEverythingInside(path);
      long sizeAfterDeletion = Mass.Calculate(path);
      long deletedSize = size - sizeAfterDeletion;
      Console.WriteLine("Amount of data deleted, in bytes: " + deletedSize);
      Console.WriteLine("Size of the cleaned folder: " + sizeAfterDeletion);
      // Instead of trying to implement the size measurer in the methods of the Deleter class,
      // We can just use plain math to calculate it
   }
}