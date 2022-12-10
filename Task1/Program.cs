using System.IO;
using Libraries;

namespace Task1;
internal class Program
{
   private static void Main(string[] args)
   {
      Deleter.DeleteEverythingInside(Utils.GetFolderPath());
   }
}