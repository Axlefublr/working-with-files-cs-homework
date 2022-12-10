using System;
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
   
   private static DateTime GetLastAccessTime(string path) {
      DateTime lastAccessTime;
      if (CheckIsDirectory(path)) {
         lastAccessTime = Directory.GetLastAccessTime(path);
      }
      else {
         lastAccessTime = File.GetLastAccessTime(path);
      }
      return lastAccessTime;
   }
   
   private static bool CheckTime(string path) {
      DateTime lastAccessTime = GetLastAccessTime(path);
      DateTime now = DateTime.Now;
      TimeSpan difference = now - lastAccessTime;
      if (difference.TotalMinutes > 30) {
         return true;
      }
      else {
         return false;
      }
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
         if (!CheckTime(folder)) { //If we accessed the parent folder, we accessed the child files and folders as well
            continue;
         }
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
         if (!CheckTime(file)) {
            continue;
         }
         File.Delete(file);
      }
   }
}