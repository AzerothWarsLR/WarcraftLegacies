namespace WarcraftLegacies.Test
{
  /// <summary>
  /// Represents a path to a Warcraft 3 model.
  /// </summary>
  public readonly struct ModelPath
  {
    public readonly string FilePath;

    /// <inheritdoc />
    public override string ToString()
    {
      return Path.GetFileNameWithoutExtension(FilePath);
    }

    public ModelPath(string filePath)
    {
      FilePath = filePath;
    }
  }
}