using System.Text.RegularExpressions;

namespace WarcraftLegacies.Map.Tests.TestSupport;

public static partial class MapDataRegex
{
  [GeneratedRegex(@"(?<![A-Z\d])[A-Z\d]{4}(?![A-Z\d])", RegexOptions.IgnoreCase)]
  public static partial Regex ParseFourCcs();

  [GeneratedRegex(@"<(?<fourcc>[A-Z\d]{4}),(?<field>[^,>]+)(?:,(?<format>[^>]+))?>", RegexOptions.IgnoreCase)]
  public static partial Regex ParseTags();
}
