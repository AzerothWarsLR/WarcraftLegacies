using System.Collections.Generic;
using WarcraftLegacies.MacroTools.DialogueSystem;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
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