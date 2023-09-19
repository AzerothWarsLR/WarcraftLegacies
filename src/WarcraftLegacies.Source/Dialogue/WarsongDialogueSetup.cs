using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class WarsongDialogueSetup
  {
    public static void Setup(AllLegendSetup legendSetup)
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\OrcCampaign\Orc05\O05Grom26.flac",
          "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
          "Grom Hellscream"), new[]
        {
          WarsongSetup.WarsongClan
        }, new List<Objective>
        {
          new ObjectiveControlLegend(legendSetup.Warsong.GromHellscream, false)
          {
            EligibleFactions = new List<Faction>
            {
              WarsongSetup.WarsongClan
            }
          },
          new ObjectiveControlCapital(legendSetup.Neutral.FountainOfBlood, false)
          {
            EligibleFactions = new List<Faction>
            {
              WarsongSetup.WarsongClan
            }
          }
        }
      ));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\RandomOrcQuest02x\DR02Chen01",
            "Ah, greetings, my friend. I am Chen Stormstout, humble brewmaster of Pandaria. I have traveled the wide world searching for rare, exotic ingredients to use in my special brew! After all, good ale can solve all the problems of this world, don't you agree?",
            "Chen Stormstout")
          , new[]
          {
            WarsongSetup.WarsongClan
          }, new[]
          {
            new ObjectiveControlLegend(legendSetup.Warsong.ChenStormstout, false)
            {
              EligibleFactions = new List<Faction>{ WarsongSetup.WarsongClan }
            }
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcCampaign\Orc04\O04Grom01",
              "Damn Thrall for sending us away! He chooses to use his greatest warriors for manual labor? He'll be lost without me.",
              "Grom Hellscream"))
          , new[]
          {
            WarsongSetup.WarsongClan
          }, new[]
          {
            new ObjectiveControlLegend(legendSetup.Warsong.GromHellscream, false)
            {
              EligibleFactions = new List<Faction>{WarsongSetup.WarsongClan}
            }
          }));
    }
  }
}