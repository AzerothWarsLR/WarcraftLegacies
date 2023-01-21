using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatNocd : Command
  {
    /// <inheritdoc />
    public override string CommandText => "nocd";
    
    /// <inheritdoc />
    public override int ParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static readonly List<player> PlayersWithCheat = new();

    private static bool IsCheatActive(player whichPlayer)
    {
      return PlayersWithCheat.Contains(whichPlayer);
    }

    private static void SetCheatActive(player whichPlayer, bool isActive)
    {
      if (isActive && !PlayersWithCheat.Contains(whichPlayer))
      {
        PlayersWithCheat.Add(whichPlayer);
        return;
      }

      if (!isActive && PlayersWithCheat.Contains(whichPlayer)) PlayersWithCheat.Remove(whichPlayer);
    }

    private static void Spell()
    {
      if (IsCheatActive(GetTriggerPlayer()))
        BlzEndUnitAbilityCooldown(GetTriggerUnit(), GetSpellAbilityId());
    }

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      if (parameter == "on")
      {
        SetCheatActive(p, true);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r No cooldowns activated.");
      }
      else if (parameter == "off")
      {
        SetCheatActive(p, false);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r No cooldowns deactivated.");
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(UnitTypeEvent.SpellEndCast, Spell);
    }
  }
}