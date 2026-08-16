namespace Warcraft.Cartographer.Extensions;

public static class CollectionExtensions
{
  extension(List<string> list)
  {
    public void Replace(string oldValue, string newValue)
    {
      var index = list.IndexOf(oldValue);
      if (index < 0)
      {
        throw new InvalidOperationException($"Could not find '{oldValue}' to replace.");
      }

      list[index] = newValue;
    }
  }
}
