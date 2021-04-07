using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War3Api.Object;
using War3Net.Build.Object;

namespace AzerothWarsCSharp.Launcher.SanityChecker
{
  public static class UnitSanityChecker
  {
    public static void Main()
    {
      using var fileReader = new BinaryReader(File.Open("filename", FileMode.Open));
      var db = ObjectDatabase.DefaultDatabase.GetAllData();
    }
  }
}
