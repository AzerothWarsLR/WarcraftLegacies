using System;
using System.Collections.Generic;
using MacroTools.Frames;

namespace MacroTools.BookSystem.Core
{
  /// <summary>
  /// Responsible for managing all <see cref="ISpecialMenu"/>s.
  /// </summary>
  public static class SpecialMenuManager
  {
    // ReSharper disable once CollectionNeverQueried.Local
    private static readonly List<ISpecialMenu> Books = new();

    /// <summary>
    /// Registers a <see cref="ISpecialMenu"/> as being visible to all players.
    /// </summary>
    /// <param name="specialMenu">The book to register.</param>
    /// <param name="whichPlayer">If specified, the Book can only be seen by this player.</param>
    public static void Register(ISpecialMenu specialMenu, player? whichPlayer = null)
    {
      Books.Add(specialMenu);
      specialMenu.LauncherButton = new Button("SpectrumMenuButtonMenu", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0))
      {
        Width = BlzFrameGetWidth(specialMenu.LauncherParent),
        Height = BlzFrameGetHeight(specialMenu.LauncherParent),
        Text = specialMenu.Title,
        Visible = whichPlayer == null || whichPlayer == GetLocalPlayer()
      };
      specialMenu.LauncherButton.SetPoint(FRAMEPOINT_TOP, specialMenu.LauncherParent, FRAMEPOINT_BOTTOM, 0, 0);
      specialMenu.LauncherButton.OnClick = specialMenu.Open;
      
    }

    private static void LoadToc(string tocFilePath)
    {
      if (!BlzLoadTOCFile(tocFilePath)) throw new Exception($"Failed to load TOC {tocFilePath}");
    }

    static SpecialMenuManager()
    {
      LoadToc("ArtifactSystem.toc");
      LoadToc(@"ui\framedef\framedef.toc");
    }
  }
}