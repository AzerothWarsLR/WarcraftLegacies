using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using WarcraftLegacies.Source.Quests.Warsong;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving the <see cref="FrostwolfSetup.Frostwolf"/> faction.
  /// </summary>
  public static class FrostwolfDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="FrostwolfDialogueSetup"/>.
    /// </summary>
    public static void Setup(AllLegendSetup legendSetup)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\OrcCampaign\Orc08\O08Thrall07",
          "Hellscream is like a brother to me, Cairne. But he and his clan have fallen under the demon's influence. If I can't save him, then my people might be damned for all time.",
          "Thrall"), new[]
        {
          FrostwolfSetup.Frostwolf
        }, new[]
        {
          new ObjectiveQuestComplete(WarsongSetup.WarsongClan.GetQuestByType(typeof(QuestFountainOfBlood)))
        }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar01",
            "I have wandered alone for many years, little Misha. Yet sometimes, even I grow weary of this endless solitude.",
            "Rexxar"), 
            new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar02",
            "I have watched the other races. I have seen their squabbling, their ruthlessness. Their wars do nothing but scar the land and drive the wild things to extinction.",
            "Rexxar"), 
            new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar03",
            "No, they cannot be trusted. Only beasts are above deceit.",
            "Rexxar"))
          , new[]
          {
            FrostwolfSetup.Frostwolf
          }, new[]
          {
            new ObjectiveControlLegend(legendSetup.Frostwolf.Rexxar, false)
            {
              EligibleFactions = new List<Faction>{FrostwolfSetup.Frostwolf}
            }
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Thrall25",
              "Who are you, warrior?",
              "Thrall"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcExpCamp\OrcQuest00x\D00Rexxar26",
              "I am Rexxar, last son of the Mok'Nathal.",
              "Rexxar"))
            , new[]
          {
            FrostwolfSetup.Frostwolf
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Frostwolf.Thrall, legendSetup.Frostwolf.Rexxar)
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcCampaign\Orc01\O01Grunt01",
              "Warchief, our ship sustained heavy damage when we passed through the raging maelstrom. It's unsalvageable.",
              "Grunt"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcCampaign\Orc01\O01Thrall02",
              "I knew it. Can we confirm our location? Is this Kalimdor?",
              "Thrall"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcCampaign\Orc01\O01Grunt03",
              "We traveled due west, as you instructed. This should be it.",
              "Grunt"))
          , new[]
          {
            FrostwolfSetup.Frostwolf
          }, new[]
          {
            new ObjectiveControlLegend(legendSetup.Frostwolf.Thrall, false)
            {
              EligibleFactions = new List<Faction>{FrostwolfSetup.Frostwolf}
            }
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcCampaign\Orc01\O01Cairne23",
              "I am Cairne, chief of the Bloodhoof tauren. You greenskins fight with both savagery and valor. I am intrigued.",
              "Cairne Bloodhoof"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcCampaign\Orc01\O01Thrall24",
              "I am Thrall, and these are my brethren, the orcs. We've come seeking the destiny promised to us.",
              "Thrall"))
          , new[]
          {
            FrostwolfSetup.Frostwolf
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Frostwolf.Cairne, legendSetup.Frostwolf.Thrall)
          }));
    }
  }
}