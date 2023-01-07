using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving Illidan's faction.
  /// </summary>
  public static class IllidariDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="IllidariDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
        new[]
        {
          new ObjectiveLegendMeetsLegend(LegendNaga.LegendIllidan, LegendSentinels.Tyrande)
        }, @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan31",
        "Tyrande, what are you doing here? This battle does not concern you.",
        "Illidan Stormrage",
        new[]
        {
          IllidariSetup.Illidari,
          SentinelsSetup.Sentinels
        }));
      
      DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
        new[]
        {
          new ObjectiveLegendMeetsLegend(LegendNaga.LegendIllidan, LegendDruids.LegendMalfurion)
        }, @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan38",
        "Brother? What are you doing here?",
        "Illidan Stormrage",
        new[]
        {
          IllidariSetup.Illidari,
          DruidsSetup.Druids
        }));
      
      DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
        new[]
        {
          new ObjectiveEitherOf(new ObjectiveDamagePlayer(SentinelsSetup.Sentinels.Player)
          {
            EligibleFactions = new List<Faction>
            {
              IllidariSetup.Illidari
            }
          }, new ObjectiveDamagePlayer(DruidsSetup.Druids.Player)
          {
            EligibleFactions = new List<Faction>
            {
              IllidariSetup.Illidari
            }
          })
        }, @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Naga08",
        "Wretched Night Elves. We are the Naga! We are the future!",
        "Myrmidon",
        new[]
        {
          IllidariSetup.Illidari,
          DruidsSetup.Druids,
          SentinelsSetup.Sentinels
        }));
    }
  }
}