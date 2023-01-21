using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatSpawn : Command
  {
    /// <inheritdoc />
    public override string CommandText => "spawn";

    /// <inheritdoc />
    public override int ParameterCount => 2;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static void SpawnUnitsOrItems(unit whichUnit, int typeId, int count)
    {
      for (var i = 0; i < count; i++)
      {
        CreateUnit(GetTriggerPlayer(), typeId, GetUnitX(whichUnit), GetUnitY(whichUnit), 0);
        CreateItem(typeId, GetUnitX(whichUnit), GetUnitY(whichUnit));
      }
    }

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;
      var enteredString = GetEventPlayerChatString();
      var triggerPlayer = GetTriggerPlayer();
      var typeIdParameter = SubString(enteredString, StringLength(Command), StringLength(Command) + 4);
      var countParameter = SubString(enteredString, StringLength(Command) + StringLength(typeIdParameter) + 1,
        StringLength(enteredString));

      if (S2I(countParameter) < 1) 
        countParameter = "1";

      if (FourCC(typeIdParameter) <= 0) 
        return;

      var firstSelectedUnit = CreateGroup().EnumSelectedUnits(triggerPlayer).EmptyToList().First();
      SpawnUnitsOrItems(firstSelectedUnit, FourCC(typeIdParameter), S2I(countParameter));
      
      DisplayTextToPlayer(triggerPlayer, 0, 0,
        $"|cffD27575CHEAT:|r Attempted to spawn {countParameter} of object {GetObjectName(FourCC(typeIdParameter))}.");
    }
  }
}