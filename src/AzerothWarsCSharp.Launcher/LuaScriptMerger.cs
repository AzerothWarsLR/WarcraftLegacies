using System.Text;

namespace AzerothWarsCSharp.Launcher
{
  public static class LuaScriptMerger
  {
    public static string Merge(string cSharpAsLuaScript, string jassAsLuaScript)
    {
      var stringBuilder = new StringBuilder();
      
      stringBuilder.Append(cSharpAsLuaScript);
      stringBuilder.Append(jassAsLuaScript);

      stringBuilder.Length -= 5;

      stringBuilder.AppendLine("  InitCSharp()");
      stringBuilder.AppendLine("end");
      
      return stringBuilder.ToString();
    }
  }
}