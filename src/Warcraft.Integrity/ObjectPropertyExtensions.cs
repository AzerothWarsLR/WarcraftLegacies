using War3Api.Object;

namespace Warcraft.Integrity;

/// <summary>
/// Helpers for reading levelled <see cref="ObjectProperty{T}"/> fields that
/// may not exist on every level of an ability.
/// </summary>
public static class ObjectPropertyExtensions
{
  extension(ObjectProperty<string> property)
  {
    /// <summary>
    /// Returns the string value at <paramref name="level"/>, or <c>null</c>
    /// when the field does not exist at that level in the modification chain.
    /// </summary>
    /// <inheritdoc cref="TryGetAtLevel"/>
    public string? TryGetStringAtLevel(int level, bool isFieldModified)
    {
      return property.TryGetAtLevel(level, isFieldModified);
    }
  }

  extension(ObjectProperty<IEnumerable<Buff>> property)
  {
    /// <summary>
    /// Returns the buff collection at <paramref name="level"/>, or an empty sequence
    /// when the field does not exist at that level in the modification chain.
    /// </summary>
    /// <inheritdoc cref="TryGetAtLevel"/>
    public IEnumerable<Buff> TryGetBuffsAtLevel(int level, bool isFieldModified)
    {
      return property.TryGetAtLevel(level, isFieldModified) ?? [];
    }
  }

  extension<T>(ObjectProperty<T> property)
  {
    /// <param name="level">The ability level to read.</param>
    /// <param name="isFieldModified">
    /// When <c>true</c>, a missing key is treated as an error and the exception propagates.
    /// When <c>false</c>, a missing key returns <c>null</c>.
    /// </param>
    private T? TryGetAtLevel(int level, bool isFieldModified)
    {
      try
      {
        return property[level];
      }
      catch (KeyNotFoundException) when (!isFieldModified)
      {
        return default;
      }
    }
  }
}
