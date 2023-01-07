using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class LordaeronDialogueSetup
  {
    public static void Setup()
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\HumanCampaign\Human07\H07Captain01",
          "This is a Light-forsaken land, isn't it? You can barely even see the sun! this howling wind cuts to the bone and you're not even shaking. Mi'lord, are you alright?",
          "Captain"), new[]
        {
          LordaeronSetup.Lordaeron
        }, new[]
        {
          new ObjectiveAnyUnitInRect(Regions.Central_Northrend, "Central Northrend", false)
          {
            EligibleFactions = new List<Faction> { LordaeronSetup.Lordaeron }
          }
        }));
    }
  }
}