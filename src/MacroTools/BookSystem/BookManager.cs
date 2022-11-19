using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.BookSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="IBook"/>s.
  /// </summary>
  public static class BookManager
  {
    // ReSharper disable once CollectionNeverQueried.Local
    private static readonly List<IBook> Books = new();

    /// <summary>
    /// Registers a <see cref="IBook"/> as being visible to all players.
    /// </summary>
    /// <param name="book">The book to register.</param>
    public static void Register(IBook book)
    {
      Books.Add(book);
    }

    private static void LoadToc(string tocFilePath)
    {
      if (!BlzLoadTOCFile(tocFilePath)) throw new Exception($"Failed to load TOC {tocFilePath}");
    }

    static BookManager()
    {
      LoadToc(@"ArtifactSystem.toc");
      LoadToc(@"ui\framedef\framedef.toc");
    }
  }
}