namespace Libraries;

public static class Utils
{

   public static string GetFolderPath()
   {
      string? input = "";
      while (string.IsNullOrEmpty(input))
      {
         Console.Write("Enter the directory path: ");
         input = Console.ReadLine();
      }
      return input;
   }

   public static bool CheckIsDirectory(string path)
   {
      FileAttributes attr = File.GetAttributes(path);
      if (attr.HasFlag(FileAttributes.Directory))
         return true;
      else
         return false;
   }

   public static bool CheckFolderPath(string folderPath)
   {
      if (!Directory.Exists(folderPath))
      {
         Console.WriteLine("Folder with the path of: '" + folderPath + "' does not exist");
         return false;
      }
      return true;
   }

}