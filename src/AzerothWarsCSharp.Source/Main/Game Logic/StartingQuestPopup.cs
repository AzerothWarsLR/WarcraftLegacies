//Displays each Faction)s starting quest after the cinematic phase ends

using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public static class StartingQuestPopup
  {
    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 63, false);
      TriggerAddAction(trig, () =>
      {
        foreach (var player in GetAllPlayers())
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