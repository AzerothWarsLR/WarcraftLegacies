using System.Collections.Generic;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Powers;

/// <summary>
///   Grants the <see cref="Faction" /> permanent visibility over one or more <see cref="Rectangle" />s.
/// </summary>
public sealed class RegionVisionPower : Power
{
  private readonly List<fogmodifier> _fogModifiers = new();
  private readonly IEnumerable<Rectangle> _visionRects;

  public RegionVisionPower(string name, string description, string iconName, IEnumerable<Rectangle> visionRects)
  {
    Name = name;
    Description = description;
    IconName = iconName;
    _visionRects = visionRects;
  }

  public override void OnAdd(player whichPlayer)
  {
    foreach (var region in _visionRects)
    {
      var newFogModifier = region.Rect.AddFogModifier(whichPlayer, fogstate.Visible, true, true);
      _fogModifiers.Add(newFogModifier);
      newFogModifier.Start();
    }
  }

  public override void OnRemove(player whichPlayer)
  {
    foreach (var fogModifier in _fogModifiers)
    {
      fogModifier.Dispose();
    }

    _fogModifiers.Clear();
  }
}
