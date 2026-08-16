using System.Collections.Generic;

namespace MacroTools.Extensions;

/// <summary>
/// Shims for .NET APIs that CSharp.lua does not support when transpiling to Lua.
/// </summary>
public static class CSharpLuaExtensions
{
  /// <inheritdoc cref="CollectionExtensions.GetValueOrDefault{TKey,TValue}(IReadOnlyDictionary{TKey,TValue},TKey)"/>
  public static TValue? GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
    where TKey : notnull
  {
    return dictionary.GetValueOrDefault(key, default!);
  }

  /// <inheritdoc cref="CollectionExtensions.GetValueOrDefault{TKey,TValue}(IReadOnlyDictionary{TKey,TValue},TKey,TValue)"/>
  public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    where TKey : notnull
  {
    // ReSharper disable once CanSimplifyDictionaryTryGetValueWithGetValueOrDefault
    return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
  }
}
