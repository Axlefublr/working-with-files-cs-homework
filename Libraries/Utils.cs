namespace Libraries;

public static class Utils
{

   public static bool CheckIsDirectory(string path)
   {
      FileAttributes attr = File.GetAttributes(path);
      if (attr.HasFlag(FileAttributes.Directory))
         return true;
      else
         return false;
   }

}