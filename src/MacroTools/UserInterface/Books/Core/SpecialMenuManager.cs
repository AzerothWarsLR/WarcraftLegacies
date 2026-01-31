using System;
using System.Collections.Generic;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Core;

/// <summary>
/// Responsible for managing all <see cref="ISpecialMenu"/>s.
/// </summary>
public static class SpecialMenuManager
{
  // ReSharper disable once CollectionNeverQueried.Local
  private static readonly List<ISpecialMenu> _books = new();

  /// <summary>
  /// Registers a <see cref="ISpecialMenu"/> as being visible to all players.
  /// </summary>
  /// <param name="specialMenu">The book to register.</param>
  /// <param name="whichPlayer">If specified, the Book can only be seen by this player.</param>
  public static void Register(ISpecialMenu specialMenu, player? whichPlayer = null)
  {
    _books.Add(specialMenu);
    specialMenu.LauncherButton = new Button("SpectrumMenuButtonMenu", originframetype.GameUI.GetOriginFrame(0))
    {
      Width = specialMenu.LauncherParent.Width,
      Height = specialMenu.LauncherParent.Height,
      Text = specialMenu.Title,
      Visible = whichPlayer == null || whichPlayer == player.LocalPlayer
    };
    specialMenu.LauncherButton.SetPoint(framepointtype.Top, specialMenu.LauncherParent, framepointtype.Bottom, 0, 0);
    specialMenu.LauncherButton.OnClick = specialMenu.Open;

  }

  private static void LoadToc(string tocFilePath)
  {
    if (!BlzLoadTOCFile(tocFilePath))
    {
      throw new Exception($"Failed to load TOC {tocFilePath}");
    }
  }

  static SpecialMenuManager()
  {
    LoadToc("ArtifactSystem.toc");
    LoadToc(@"ui\framedef\framedef.toc");
  }
}
