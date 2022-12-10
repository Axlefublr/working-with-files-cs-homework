using System.IO;
namespace Task1;

internal static class Deleter
{

   private static bool CheckFolderPath(string folderPath)
   {
      if (!Directory.Exists(folderPath))
      {
         Console.WriteLine("Folder with the path of: '" + folderPath + "' does not exist");
         return false;
      }
      return true;
   }
   
   private static void CheckTime(string path) {
      
   }
   
   private static bool CheckIsDirectory(string path) {
      FileAttributes attr = File.GetAttributes(path);
      if (attr.HasFlag(FileAttributes.Directory))
         return true;
      else
         return false;
   }

   internal static void DeleteEverythingInside(string folderPath)
   {
      if (!CheckFolderPath(folderPath)) { return; }
      DeleteFilesInFolder(folderPath);
      DeleteFoldersInFolder(folderPath);
   }
   
   private static void DeleteFoldersInFolder(string folderPath) {
      string[] folders = Directory.GetDirectories(folderPath);
      if (folders.Length <= 0) {
      }
      foreach (string folder in folders) {
         DeleteEverythingInside(folder);
         Directory.Delete(folder);
      }
   }
   
   private static void DeleteFilesInFolder(string folderPath) {
      string[] files = Directory.GetFiles(folderPath);
      if (files.Length <= 0) {
         return;
      }
      foreach (string file in files) {
         File.Delete(file);
      }
   }
}