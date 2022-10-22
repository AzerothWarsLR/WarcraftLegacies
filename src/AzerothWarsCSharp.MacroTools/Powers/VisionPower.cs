using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.Powers
{
  /// <summary>
  ///   Grants the <see cref="Faction" /> permanent visibility over one or more <see cref="Rectangle" />s.
  /// </summary>
  public sealed class VisionPower : Power
  {
    private readonly List<fogmodifier> _fogModifiers = new();
    private readonly IEnumerable<Rectangle> _visionRects;

    public VisionPower(string name, string description, string iconName, IEnumerable<Rectangle> visionRects)
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
        var newFogModifier = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, region.Rect, true, true);
        _fogModifiers.Add(newFogModifier);
        FogModifierStart(newFogModifier);
      }
    }

    public override void OnRemove(player whichPlayer)
    {
      foreach (var fogModifier in _fogModifiers) DestroyFogModifier(fogModifier);
      _fogModifiers.Clear();
    }
  }
}