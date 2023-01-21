using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatMp : Command
  {
    /// <inheritdoc />
    public override string CommandText => "mp";
    
    /// <inheritdoc />
    public override int ParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static string? _parameter;
    
    private static void SetMana(unit whichUnit)
    {
      SetUnitState(whichUnit, UNIT_STATE_MANA, S2R(_parameter));
    }

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      _parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      if (S2I(_parameter) >= 0)
      {
        foreach (var unit in CreateGroup().EnumSelectedUnits(p).EmptyToList())
        {
          SetMana(unit);
        }
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting mana of selected units to " + _parameter + ".");
      }
    }
  }
}