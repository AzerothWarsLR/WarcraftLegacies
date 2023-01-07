using MacroTools.DialogueSystem;
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
      DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
        new[]
        {
          new ObjectiveLegendMeetsLegend(LegendSentinels.Maiev, LegendDruids.LegendMalfurion)
        }, @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev22",
        "Elune be praised! I knew you would come, Shan'do Stormrage.",
        "Illidan Stormrage",
        new[]
        {
          SentinelsSetup.Sentinels,
          DruidsSetup.Druids
        }));
      
      DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
        new[]
        {
          new ObjectiveLegendMeetsLegend(LegendSentinels.Maiev, LegendSentinels.Tyrande)
        }, @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev24",
        "Priestess Tyrande. I'm surprised you came in person. Are you here to absolve your guilty conscience?",
        "Maiev Shadowsong",
        new[]
        {
          SentinelsSetup.Sentinels
        }));
      
      DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
        new[]
        {
          new ObjectiveLegendMeetsLegend(LegendSentinels.Maiev, LegendNaga.LegendIllidan)
        }, @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev37",
        "I am the hand of justice, Illidan. Long ago, I swore an oath to keep you chained, and by all the gods, I shall.",
        "Maiev Shadowsong",
        new[]
        {
          SentinelsSetup.Sentinels,
          IllidariSetup.Illidari
        }));
    }
  }
}