using System;
using System.Collections.Generic;
using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatVision : Command
  {
    /// <inheritdoc />
    public override string CommandText => "vision";
    
    /// <inheritdoc />
    public override int ParameterCount => 2;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static readonly Dictionary<player, fogmodifier> Fogs = new();

    /// <inheritdoc />
    public override string Description => "When activated, grants vision of the entire map.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (Enum.TryParse<Toggle>(parameters[0], out var toggle))
        return "You must specify \"on\" or \"off\" as the first parameter.";

      switch (toggle)
      {
        case Toggle.On:
          var newFog = CreateFogModifierRect(cheater, FOG_OF_WAR_VISIBLE,
            WCSharp.Shared.Data.Rectangle.WorldBounds.Rect, true, false);
          FogModifierStart(newFog);
          Fogs.Add(cheater, newFog);
          return "|cffD27575CHEAT:|r Whole map revealed.";
        case Toggle.Off:
          DestroyFogModifier(Fogs[cheater]);
          return "|cffD27575CHEAT:|r Whole map unrevealed.";
        default:
          throw new ArgumentOutOfRangeException($"{nameof(parameters)}");
      }
    }
  }
}