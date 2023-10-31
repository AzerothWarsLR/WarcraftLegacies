using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using WarcraftLegacies.Source.Quests.Naga;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

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
    public static void Setup(AllLegendSetup legendSetup)
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
            new ObjectiveLegendMeetsLegend(legendSetup.Naga.Illidan, legendSetup.Sentinels.Tyrande)
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
            new ObjectiveLegendMeetsLegend(legendSetup.Naga.Illidan, legendSetup.Druids.Malfurion)
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
          new ObjectiveLegendReachRect(legendSetup.Naga.Illidan, Regions.Sargeras_Entrance,
            "the Tomb of Sargeras' entrance")
        }
      ));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Illidan33.flac",
          "You're out of your league, old king. You should have stayed hidden underground.",
          "Illidan Stormrage")
        , new[]
        {
          IllidariSetup.Illidari,
          ScourgeSetup.Scourge
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(legendSetup.Naga.Illidan, legendSetup.Scourge.Anubarak)
        }
      ));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Illidan27",
              "Hello, Arthas.",
              "Illidan Stormrage"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Arthas28",
              "You look different, Illidan. I guess the Skull of Gul'dan didn't agree with you.",
              "Arthas Menethil")),
          new[]
          {
            IllidariSetup.Illidari,
            ScourgeSetup.Scourge
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Naga.Illidan, legendSetup.Scourge.Arthas)
          }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\HumanExpCamp\Human07x\A07Illidan24",
          "Hear me now, you trembling mortals! I am your lord and master! Illidan reigns supreme!",
          "Illidan Stormrage")
        , new[]
        {
          IllidariSetup.Illidari
        }, new List<Objective>
        {
          new ObjectiveQuestComplete(IllidariSetup.Illidari.GetQuestByType(typeof(QuestBlackTemple)))
        }
      ));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03LadyVashj31",
              "You've come far enough, little warden. Your vaunted night elf justice has no jurisdiction here.",
              "Lady Vashj"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03Maiev32",
              "What would you know of us or our justice, naga witch?",
              "Maiev Shadowsong")),
          new[]
          {
            IllidariSetup.Illidari,
            SentinelsSetup.Sentinels
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Naga.Vashj, legendSetup.Sentinels.Maiev)
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03Illidan45",
              "So, Warden Shadowsong, you've made it at last. I knew you would.",
              "Illidan Stormrage"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03Maiev46",
              "You have much to pay for, Illidan. I'm taking you back to your cell.",
              "Maiev Shadowsong")),
          new[]
          {
            IllidariSetup.Illidari,
            SentinelsSetup.Sentinels
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Naga.Illidan, legendSetup.Sentinels.Maiev)
          }));
    }
  }
}