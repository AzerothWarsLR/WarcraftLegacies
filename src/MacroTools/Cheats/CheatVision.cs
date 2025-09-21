using System.Collections.Generic;
using MacroTools.CommandSystem;

namespace MacroTools.Cheats;

public sealed class CheatVision : Command
{
  /// <inheritdoc />
  public override string CommandText => "vision";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  private static readonly Dictionary<player, fogmodifier> _fogs = new();

  /// <inheritdoc />
  public override string Description => "When activated, grants vision of the entire map.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var toggle = parameters[0];

    switch (toggle)
    {
      case "on":
        var newFog = WCSharp.Shared.Data.Rectangle.WorldBounds.Rect.AddFogModifier(cheater, fogstate.Visible, true, false);
        newFog.Start();
        _fogs.Add(cheater, newFog);
        return "Whole map revealed.";
      case "off":
        _fogs[cheater].Dispose();
        return "Whole map unrevealed.";
      default:
        return "You must specify \"on\" or \"off\" as the first parameter.";
    }
  }
}
