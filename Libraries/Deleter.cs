using System;
using System.IO;
using Libraries;
namespace Task1;

public static class Deleter
{

   private static DateTime GetLastAccessTime(string path)
   {
      DateTime lastAccessTime;
      if (Utils.CheckIsDirectory(path))
      {
         lastAccessTime = Directory.GetLastAccessTime(path);
      }
      else
      {
         lastAccessTime = File.GetLastAccessTime(path);
      }
      return lastAccessTime;
   }

   private static bool CheckTime(string path)
   {
      DateTime lastAccessTime = GetLastAccessTime(path);
      DateTime now = DateTime.Now;
      TimeSpan difference = now - lastAccessTime;
      if (difference.TotalMinutes > 30)
      {
         return true;
      }
      else
      {
         return false;
      }
   }

   public static void DeleteEverythingInside(string folderPath)
   {
      if (!Utils.CheckFolderPath(folderPath)) { return; }
      DeleteFilesInFolder(folderPath);
      DeleteFoldersInFolder(folderPath);
   }

   private static void DeleteFoldersInFolder(string folderPath)
   {
      string[] folders = Directory.GetDirectories(folderPath);
      if (folders.Length <= 0)
      {
      }
      foreach (string folder in folders)
      {
         if (!CheckTime(folder))
         { //If we accessed the parent folder, we accessed the child files and folders as well
            continue;
         }
         DeleteEverythingInside(folder);
         Directory.Delete(folder);
      }
   }

   private static void DeleteFilesInFolder(string folderPath)
   {
      string[] files = Directory.GetFiles(folderPath);
      if (files.Length <= 0)
      {
         return;
      }
      foreach (string file in files)
      {
         if (!CheckTime(file))
         {
            continue;
         }
         File.Delete(file);
      }
   }
}