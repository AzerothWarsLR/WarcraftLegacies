using System.Text;
using Xunit.Sdk;

namespace WarcraftLegacies.Map.Tests.ValidityTests;

internal static class ValidityTestHelpers
{
  internal static void ThrowIfAny(List<string> issues)
  {
    if (issues.Count == 0)
    {
      return;
    }

    var sb = new StringBuilder();
    foreach (var issue in issues)
    {
      sb.AppendLine(issue);
    }

    throw new XunitException(sb.ToString());
  }
}
