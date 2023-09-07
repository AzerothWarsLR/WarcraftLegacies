using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

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
    public static void Setup(AllLegendSetup legendSetup)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfCampaign\NightElf06Interlude\N06Medivh42",
            "Now, at long last, I have returned to set things right. I... am Medivh, the Last Guardian. I tell you now, the only chance for this world is for you to unite in arms against the enemies of all who live!",
            "Medivh"))
          , new[]
          {
            DalaranSetup.Dalaran
          }, new[]
          {
            new ObjectiveControlLegend(legendSetup.Dalaran.Medivh, false)
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
          new ObjectiveLegendInRect(legendSetup.Dalaran.Jaina, Regions.Hearthglen, "Hearthglen")
        }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas13.flac",
            "It pains me to even look at you, Arthas.",
            "Arthas Menethil"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas14.flac",
            "I'll be happy to end your torment, old man. I told you that your magics could not stop me.",
            "Antonidas")
        ), new[]
        {
          ScourgeSetup.Scourge,
          DalaranSetup.Dalaran
        }, new List<Objective>
        {
          new ObjectiveLegendDead(legendSetup.Dalaran.Antonidas)
          {
            DeathFilter = dyingLegend => MathEx.GetDistanceBetweenPoints(legendSetup.Scourge.Arthas.Unit.GetPosition(),
              dyingLegend.Unit.GetPosition()) < 500
          }
        }
      ));
    }
  }
}