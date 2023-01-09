using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving <see cref="DalaranSetup.Dalaran"/>.
  /// </summary>
  public static class DalaranDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="DalaranDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf06Interlude\N06Medivh38",
            "I... am the reason for the Legion's return.",
            "Medivh"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf06Interlude\N06Medivh39",
            "Years ago, I brought the orcs into this world, and by doing so, I opened a path for the demons as well.",
            "Medivh"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf06Interlude\N06Medivh40",
            "For my sins, I was murdered by those who I cared for most.",
            "Medivh"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf06Interlude\N06Medivh41",
            "Despite my death, war raged across the lands of the east for many long years, leaving entire kingdoms devastated in its wake.",
            "Medivh"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf06Interlude\N06Medivh42",
            "Now, at long last, I have returned to set things right. I... am Medivh, the Last Guardian. I tell you now, the only chance for this world is for you to unite in arms against the enemies of all who live!",
            "Medivh"))
          , new[]
          {
            DalaranSetup.Dalaran
          }, new[]
          {
            new ObjectiveControlLegend(LegendDalaran.LegendMedivh, false)
            {
              EligibleFactions = new List<Faction>
              {
                DalaranSetup.Dalaran
              }
            }
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          soundFile: @"Sound\Dialogue\HumanCampaign\Human05\H05Jaina01.flac",
          caption:
          "Hearthglen, finally! I could use some rest!",
          speaker: "Jaina Proudmoore"), new[]
        {
          DalaranSetup.Dalaran,
        }, new[]
        {
          new ObjectiveLegendInRect(LegendDalaran.LegendJaina, Regions.Hearthglen, "Hearthglen")
        }));
    }
  }
}