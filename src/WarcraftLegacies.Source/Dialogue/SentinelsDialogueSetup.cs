using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving the <see cref="SentinelsSetup.Sentinels"/> faction.
  /// </summary>
  public static class SentinelsDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="SentinelsDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev22",
          "Elune be praised! I knew you would come, Shan'do Stormrage.",
          "Illidan Stormrage"), new[]
        {
          SentinelsSetup.Sentinels,
          DruidsSetup.Druids
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(LegendSentinels.Maiev, LegendDruids.LegendMalfurion)
        }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev24",
          "Priestess Tyrande. I'm surprised you came in person. Are you here to absolve your guilty conscience?",
          "Maiev Shadowsong"), new[]
        {
          SentinelsSetup.Sentinels
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(LegendSentinels.Maiev, LegendSentinels.Tyrande)
        }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev37",
          "I am the hand of justice, Illidan. Long ago, I swore an oath to keep you chained, and by all the gods, I shall.",
          "Maiev Shadowsong"), new[]
        {
          SentinelsSetup.Sentinels,
          IllidariSetup.Illidari
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(LegendSentinels.Maiev, LegendNaga.LegendIllidan)
        }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf02\N02Tyrande03.flac",
            "Archimonde... After ten thousand years, how is it possible?",
            "Tyrande Whisperwind"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf02\N02Archimonde04.flac",
            "The Legion has returned to consume this world, woman. And this time, your troublesome race will not stop us.",
            "Archimonde")
        )
        , new[]
        {
          LegionSetup.Legion,
          SentinelsSetup.Sentinels
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(LegendSentinels.Tyrande, LegendLegion.LEGEND_ARCHIMONDE)
        }
      ));
    }
  }
}