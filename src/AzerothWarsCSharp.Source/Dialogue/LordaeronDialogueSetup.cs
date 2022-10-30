using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.DialogueSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Dialogue
{
  public static class LordaeronDialogueSetup
  {
    public static void Setup()
    {
      DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
        new[]
        {
          new ObjectiveAnyUnitInRect(Regions.Central_Northrend, "Central Northrend", false)
          {
            EligibleFactions = new List<Faction> { LordaeronSetup.Lordaeron }
          }
        }, @"Sound\Dialogue\HumanCampaign\Human07\H07Captain01",
        "This is a Light-forsaken land, isn't it? You can barely even see the sun! this howling wind cuts to the bone and you're not even shaking. Milord, are you alright?",
        "Captain",
        new[]
        {
          LordaeronSetup.Lordaeron
        }));
    }
  }
}