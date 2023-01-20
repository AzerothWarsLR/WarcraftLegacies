using System.Collections.Generic;
using MacroTools;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue related to the Druids.
  /// </summary>
  public static class DruidsDialogueSetup
  {
    /// <summary>
    /// Sets up all dialogue related to the Druids.
    /// </summary>
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup legendSetup)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          "Cenarius"), new[]
        {
          SentinelsSetup.Sentinels,
          DruidsSetup.Druids,
          FrostwolfSetup.Frostwolf,
          WarsongSetup.WarsongClan
        }, new[]
        {
          new ObjectiveControlLegend(legendSetup.Druids.LegendCenarius, false)
          {
            EligibleFactions = new List<Faction>
            {
              DruidsSetup.Druids
            }
          }
        }));

      TriggeredDialogueManager.Add(new TriggeredDialogue(new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion01",
            "It has been a thousand years since I last looked up you, Tyrande. I thought of you every moment I roamed through the Emerald Dream.",
            "Malfurion Stormrage"), 
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Tyrande02",
            "My heart rejoices to see you again, Furion. But I would not have awakened you unless the need was urgent.",
            "Tyrande Whisperwind"), 
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion03",
            "In the Dream, I felt our land being corrupted, just as if it were my own body. You were right to awaken me.",
            "Malfurion Stormrage")
        ), 
        new[] { DruidsSetup.Druids, SentinelsSetup.Sentinels },
        new[] { new ObjectiveLegendMeetsLegend(legendSetup.Druids.LegendMalfurion, legendSetup.Sentinels.Tyrande) }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Satyr29",
            "Come no further, weakling!  Lord Tichondrius commanded us to kill anyone attempting to enter this place, and we shall.",
            "Satyr"),
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion30",
            "Patches wretches! It pains me that you once called yourselves Night Elves.",
            "Malfurion Stormrage")
        ), 
        new[] { DruidsSetup.Druids },
        new Objective[]
        {
          new ObjectiveUnitAlive(preplacedUnitSystem.GetUnit(Constants.UNIT_NSTH_SATYR_HELLCALLER, Regions.SatyrCamp.Center)),
          new ObjectiveLegendInRect(legendSetup.Druids.LegendMalfurion, Regions.SatyrCamp, "Satyr camp")
        }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf03\N03Furion22",
            "The horn has sounded, and I have come as promised! I smell the stench of decay and corruption in our land. That angers me greatly.",
            "Malfurion Stormrage"),
          new[] { DruidsSetup.Druids },
        new Objective[]
        {
          new ObjectiveControlLegend(legendSetup.Druids.LegendMalfurion, false)
          {
            EligibleFactions = new List<Faction>
            {
              DruidsSetup.Druids
            }
          }
        }));
    }
  }
}