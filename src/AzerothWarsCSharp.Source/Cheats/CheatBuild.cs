using AzerothWarsCSharp.MacroTools;
using WCSharp.Events;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatBuild
  {
    private const string COMMAND = "-build ";
    private static readonly bool[] BuildToggle = new bool[Environment.MAX_PLAYERS];

    private static void Build()
    {
      if (GetIssuedOrderId() == 851976 && BuildToggle[GetPlayerId(GetTriggerPlayer())])
      {
        UnitSetUpgradeProgress(GetTriggerUnit(), 100);
      }
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var enteredString = GetEventPlayerChatString();
      var p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      var parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      BuildToggle[pId] = parameter switch
      {
        "on" => true,
        "off" => false,
        _ => BuildToggle[pId]
      };
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);

      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeReceivesOrder, Build);
    }
  }
}