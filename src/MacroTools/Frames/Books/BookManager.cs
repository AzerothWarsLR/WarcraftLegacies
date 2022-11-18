using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Frames.Books
{
  public static class BookManager
  {
    private static List<IBook> _books = new();
    private static Dictionary<player, IBook> _booksByPlayer = new();

    /// <summary>
    /// Registers a <see cref="IBook"/> as being visible to all players.
    /// </summary>
    public static void Register(IBook book)
    {
      _books.Add(book);
      var launcherButton = new Button("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
      {
        Width = book.LauncherParent.GetWidth(),
        Height = book.LauncherParent.GetHeight()
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

    /// <summary>
    /// Registers an <see cref="IBook"/> as being visible to a specific player.
    /// </summary>
    public static void Register(IBook book, player whichPlayer)
    {
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