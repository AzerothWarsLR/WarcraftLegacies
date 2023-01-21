using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatRemove : Command
  {
    /// <inheritdoc />
    public override string CommandText => "remove";

    /// <inheritdoc />
    public override int ParameterCount => 0;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static void Remove(unit whichUnit)
    {
      RemoveUnit(whichUnit);
    }

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;
      player p = GetTriggerPlayer();
      foreach (var unit in CreateGroup().EnumSelectedUnits(p).EmptyToList())
      {
        Remove(unit);
      }
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Permanently removing selected units.");
    }
  }
}