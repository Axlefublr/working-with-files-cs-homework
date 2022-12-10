using Libraries;

namespace Task2;

internal static class Mass {

   internal static void Calculate(string path) {
      if (!Utils.CheckFolderPath(path)) { return; }
      if (Utils.CheckIsDirectory(path)) {

      } else {

      }
   }
}