using AzerothWarsCSharp.MacroTools.Wrappers;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatSpawn
  {
    private const string Command = "-spawn ";

    private static void SpawnUnitsOrItems(unit whichUnit, int typeId, int count)
    {
      for (var i = 0; i < count; i++)
      {
        CreateUnit(GetTriggerPlayer(), typeId, GetUnitX(whichUnit), GetUnitY(whichUnit), 0);
        CreateItem(typeId, GetUnitX(whichUnit), GetUnitY(whichUnit));
      }
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      var enteredString = GetEventPlayerChatString();
      var triggerPlayer = GetTriggerPlayer();
      var typeIdParameter = SubString(enteredString, StringLength(Command), StringLength(Command) + 4);
      var countParameter = SubString(enteredString, StringLength(Command) + StringLength(typeIdParameter) + 1,
        StringLength(enteredString));

      if (S2I(countParameter) < 1) 
        countParameter = "1";

      if (FourCC(typeIdParameter) <= 0) 
        return;
      
      foreach (var unit in new GroupWrapper().EnumSelectedUnits(triggerPlayer).EmptyToList())
      {
        SpawnUnitsOrItems(unit, FourCC(typeIdParameter), S2I(countParameter));
      }

      DisplayTextToPlayer(triggerPlayer, 0, 0,
        $"|cffD27575CHEAT:|r Attempted to spawn {countParameter} of object {GetObjectName(FourCC(typeIdParameter))}.");
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}