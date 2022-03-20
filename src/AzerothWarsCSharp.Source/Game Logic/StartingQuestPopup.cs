//Displays each Faction)s starting quest after the cinematic phase ends

using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Game_Logic
{
  public static class StartingQuestPopup
  {
    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 63, false);
      TriggerAddAction(trig, () =>
      {
        foreach (var player in GeneralHelpers.GetAllPlayers())
        {
          if (Person.ByHandle(player)?.Faction.StartingQuest != null && GetLocalPlayer() == player)
          {
            Person.ByHandle(player)?.Faction.StartingQuest.DisplayDiscovered();
          }
        }
      });
    }
  }
}