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
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      if (parameter == "on")
      {
        var newFog = CreateFogModifierRect(p, FOG_OF_WAR_VISIBLE, WCSharp.Shared.Data.Rectangle.WorldBounds.Rect, true, false);
        FogModifierStart(newFog);
        Fogs.Add(p, newFog);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map revealed.");
      }
      else if (parameter == "off")
      {
        DestroyFogModifier(Fogs[p]);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map unrevealed.");
      }
    }
  }
}