using System.IO;

namespace Task1;
internal class Program
{
   private static void Main(string[] args)
   {
      Deleter.DeleteEverythingInside(Utils.GetFolderPath());
   }
}