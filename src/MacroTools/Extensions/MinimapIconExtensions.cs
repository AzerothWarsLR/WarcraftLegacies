using DesyncSafeAnalyzer.Tools;
using static War3Api.Common;

namespace MacroTools.Extensions
{
  public static class MinimapIconExtensions
  {
    [DesyncSafe]
    public static minimapicon SetVisible(this minimapicon minimapIcon, bool visible)
    {
      SetMinimapIconVisible(minimapIcon, visible);
      return minimapIcon;
    }
  }
}