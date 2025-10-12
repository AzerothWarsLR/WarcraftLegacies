#pragma warning disable CS0626 // Method, operator, or accessor is marked external and has no attributes on it

namespace MacroTools.Utils;

public static class FourCc
{
  /// @CSharpLua.Template = "string.pack(">I4", {0})"
  public static extern string GetString(int value);
}
