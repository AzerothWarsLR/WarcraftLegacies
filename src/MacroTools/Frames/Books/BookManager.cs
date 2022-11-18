using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Frames.Books
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
    /// <param name="whichPlayer">If specified, the Book can only be seen by this player.</param>
    public static void Register(IBook book, player? whichPlayer = null)
    {
      Books.Add(book);
      var launcherButton = new Button("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
      {
        Width = book.LauncherParent.GetWidth(),
        Height = book.LauncherParent.GetHeight(),
        Text = book.Title,
        Visible = whichPlayer == null || whichPlayer == GetLocalPlayer()
      };
      launcherButton.SetPoint(FRAMEPOINT_TOP, book.LauncherParent, FRAMEPOINT_BOTTOM, 0, 0);
      launcherButton.OnClick = triggerPlayer =>
      {
        if (triggerPlayer != GetLocalPlayer()) 
          return;
        book.Visible = true;
        launcherButton.Visible = false;
      };
      book.OnClickExitButton = triggerPlayer =>
      {
        if (triggerPlayer != GetLocalPlayer()) 
          return;
        book.Visible = false;
        launcherButton.Visible = true;
      };
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