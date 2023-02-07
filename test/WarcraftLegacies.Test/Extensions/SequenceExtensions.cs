using ModelTester.Objects;

namespace WarcraftLegacies.Test.Extensions
{
  public static class SequenceExtensions
  {
    public static string GetToken(this Sequence sequence) => sequence.Name.ToLower().Trim().Split('-')[0].Split(' ')[0];
  }
}