using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Core;

/// <summary>Sparkles around a book's launcher button to show something new is inside.</summary>
public sealed class LauncherGlow
{
  private const string Model = @"UI\Feedback\QuestButton\UI-QuestButtonOn.mdx";

  private readonly Sprite _sprite;

  public LauncherGlow(string name, Button launcher)
  {
    _sprite = new Sprite(name, originframetype.GameUI.GetOriginFrame(0)) { Model = Model, Visible = false };
    _sprite.SetAllPoints(launcher);
  }

  /// <summary>Whether the sparkles are showing.</summary>
  public bool Visible
  {
    set => _sprite.Visible = value;
  }
}
