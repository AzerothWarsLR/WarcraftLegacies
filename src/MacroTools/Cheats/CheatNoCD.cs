using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;


namespace MacroTools.Cheats
{
  public sealed class CheatNocd : Command
  {
    /// <inheritdoc />
    public override string CommandText => "nocd";
    
    /// <inheritdoc />
    public override bool Exact => false;
    
    /// <inheritdoc />
    public override int MinimumParameterCount => 1;
    
    /// <inheritdoc />
    public override string Description => "When activated, your units reset all cooldowns after they cast a spell.";
    
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
      var toggle = parameters[0];

      switch (toggle)
      {
        case "on":
          SetCheatActive(cheater, true);
          return "No cooldowns activated.";
        case "off":
          SetCheatActive(cheater, false);
          return "No cooldowns deactivated.";
        default:
          return "You must specify \"on\" or \"off\" as the first parameter.";
      }
    }

    /// <inheritdoc />
    public override void OnRegister() => 
      PlayerUnitEvents.Register(UnitTypeEvent.SpellEndCast, Spell);
  }
}