using System.Collections.Generic;
using MacroTools.CommandSystem;


namespace MacroTools.Cheats
{
  public sealed class CheatVision : Command
  {
    /// <inheritdoc />
    public override string CommandText => "vision";
    
    /// <inheritdoc />
    public override bool Exact => false;
    
    /// <inheritdoc />
    public override int MinimumParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static readonly Dictionary<player, fogmodifier> Fogs = new();

    /// <inheritdoc />
    public override string Description => "When activated, grants vision of the entire map.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var toggle = parameters[0];

      switch (toggle)
      {
        case "on":
          var newFog = CreateFogModifierRect(cheater, FOG_OF_WAR_VISIBLE,
            WCSharp.Shared.Data.Rectangle.WorldBounds.Rect, true, false);
          FogModifierStart(newFog);
          Fogs.Add(cheater, newFog);
          return "Whole map revealed.";
        case "off":
          DestroyFogModifier(Fogs[cheater]);
          return "Whole map unrevealed.";
        default:
          return "You must specify \"on\" or \"off\" as the first parameter.";
      }
    }
  }
}