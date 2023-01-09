using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class WarsongDialogueSetup
  {
    public static void Setup()
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\OrcCampaign\Orc05\O05Grom26.flac",
          "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
          "Grom Hellscream"), new[]
        {
          WarsongSetup.WarsongClan
        }, new List<Objective>
        {
          new ObjectiveControlLegend(LegendWarsong.GromHellscream, false)
          {
            EligibleFactions = new List<Faction>
            {
              WarsongSetup.WarsongClan
            }
          },
          new ObjectiveControlCapital(LegendNeutral.FountainOfBlood, false)
          {
            EligibleFactions = new List<Faction>
            {
              WarsongSetup.WarsongClan
            }
          }
        }
      ));
    }
  }
}