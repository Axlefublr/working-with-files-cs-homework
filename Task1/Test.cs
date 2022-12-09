using System.IO;

namespace Task1;

internal static class Test {

   internal static string CreateTree() {
      CreateFolder(@"C:/TestParentFolder");
      CreateFolder(@"C:/TestParentFolder/TestChildFolder");
      CreateFile(@"C:/TestParentFolder/file1.txt");
      CreateFile(@"C:/TestParentFolder/file2.txt");
      CreateFile(@"C:/TestChildFolder/file1.txt");
      CreateFile(@"C:/TestChildFolder/file2.txt");
      return @"C:/TestParentFolder";
   }
   
   private static void CreateFolder(string path) {
      if (Directory.Exists(path)) { return; }
      Directory.CreateDirectory(path);
   }
   
   private static void CreateFile(string path) {
      if (File.Exists(path)) { return; }
      File.Create(path);
   }
   
}