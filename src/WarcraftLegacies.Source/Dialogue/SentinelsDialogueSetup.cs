using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
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
    public static void Setup(AllLegendSetup legendSetup)
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
          new ObjectiveLegendMeetsLegend(legendSetup.Sentinels.Maiev, legendSetup.Druids.LegendMalfurion)
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
          new ObjectiveLegendMeetsLegend(legendSetup.Sentinels.Maiev, legendSetup.Sentinels.Tyrande)
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
          new ObjectiveLegendMeetsLegend(legendSetup.Sentinels.Maiev, legendSetup.Naga.LegendIllidan)
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
          new ObjectiveLegendMeetsLegend(legendSetup.Sentinels.Tyrande, legendSetup.Legion.LEGEND_ARCHIMONDE)
        }
      ));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Maiev02.flac",
            "I suspected as much. These islands must have been formed only recently.",
            "Maiev Shadowsong"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Naisha03.flac",
            "What makes you say that?",
            "Naisha"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Maiev04.flac",
            "The ruins all around us, Naisha... I recognize them.",
            "Maiev Shadowsong"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Maiev05.flac",
            "This was once the great city of Suramar, built before our civilization was blasted beneath the sea ten thousand years ago.",
            "Maiev Shadowsong")
        )
        , new[]
        {
          SentinelsSetup.Sentinels
        }, new List<Objective>
        {
          new ObjectiveLegendReachRect(legendSetup.Sentinels.Maiev, Regions.BrokenIslesA, "the Broken Isles")
        }
      ));
    }
  }
}