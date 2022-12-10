using System.IO;

namespace Libraries;

public static class Mass
{

   public static long Calculate(string path)
   {
      if (!Utils.CheckFolderPath(path)) { return 0; }
      long size = 0;
      size += CalculateFiles(path);
      size += CalculateFolders(path);
      return size;
   }

   private static long CalculateFiles(string path)
   {
      string[] files = Directory.GetFiles(path);
      if (files.Length <= 0) { return 0; }
      long size = 0;
      foreach (string file in files)
      {
         FileInfo currFile = new(file);
         size += currFile.Length;
      }
      return size;
   }

   private static long CalculateFolders(string path)
   {
      string[] folders = Directory.GetDirectories(path);
      if (folders.Length <= 0) { return 0; }
      long size = 0;
      foreach (string folder in folders)
      {
         size += Calculate(folder);
      }
      return size;
   }
}