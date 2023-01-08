using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
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
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan31",
            "Tyrande! What are you doing here? This battle does not concern you.",
            "Illidan Stormrage"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Tyrande32",
            "I was wrong to set you free, Illidan. I can see that now. You've become a monster.",
            "Tyrande Whisperwind"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan33",
            "Monster? Is that what you think of me? I have always...cared about you, Tyrande. I sought only to prove my worthiness--my power!",
            "Illidan Stormrage"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Tyrande34",
            "Raw power is no substitute for true strength, Illidan. That is why I chose your brother over you.",
            "Tyrande Whisperwind"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan35",
            "Still you refuse to see me for what I truly am. You believe me to be a villain--your enemy. But soon now, you will see our enemies are the same!",
            "Illidan Stormrage"))
          , new[]
          {
            IllidariSetup.Illidari,
            SentinelsSetup.Sentinels
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(LegendNaga.LegendIllidan, LegendSentinels.Tyrande)
          }));

      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan38",
              "Brother? What are you doing here?",
              "Illidan Stormrage"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Furion39",
              "I've come to stop you, Illidan. Instead of banishing you, I should have returned you to your cage when I had the chance! I was weak then--but no longer.",
              "Malfurion Stormrage")),
          new[]
          {
            IllidariSetup.Illidari,
            DruidsSetup.Druids
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(LegendNaga.LegendIllidan, LegendDruids.LegendMalfurion)
          }));

      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Tyrande06",
              "What are these vile serpents?",
              "Tyrande Whisperwind"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Furion07",
              "I don't know, but these creatures feel familiar somehow.",
              "Malfurion Stormrage"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Naga08",
              "Wretched Night Elves. We are the Naga! We are the future!",
              "Myrmidon")),
          new[]
          {
            IllidariSetup.Illidari,
            DruidsSetup.Druids
          }, new[]
          {
            new ObjectiveEitherOf(
              new ObjectiveDamagePlayer(SentinelsSetup.Sentinels.Player)
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
          }));

      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Illidan45.flac",
          "At last! The Tomb of Sargeras is found!",
          "Illidan Stormrage")
        , new[]
        {
          IllidariSetup.Illidari
        }, new List<Objective>
        {
          new ObjectiveLegendReachRect(LegendNaga.LegendIllidan, Regions.Sargeras_Entrance,
            "the Tomb of Sargeras' entrance")
        }
      ));
    }
  }
}