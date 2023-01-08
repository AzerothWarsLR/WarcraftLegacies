using System.Collections.Generic;
using MacroTools;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class LordaeronDialogueSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\HumanCampaign\Human07\H01Uther01",
            "Welcome, Prince Arthas. The men and I are honored by your presence.",
            "Uther the Lightbringer"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Arthas02",
              "Can the formalities, Uther. I'm not king yet. It's good to see you.",
              "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Uther03",
              "Welcome, Prince Arthas. The men and I are honored by your presence.",
              "Uther the Lightbringer"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Arthas04",
              "Father still hopes your patience and experience might rub off on me.",
              "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Uther05",
              "It is a father's right to dream, isn't it?",
              "Uther the Lightbringer")
            ), 
          new[]
        {
          LordaeronSetup.Lordaeron
        }, new Objective[]
        {
          new ObjectiveLegendMeetsLegend(LegendLordaeron.Arthas, LegendLordaeron.Uther),
          new ObjectiveControlLegend(LegendLordaeron.Arthas, false)
          {
            EligibleFactions = new List<Faction> { LordaeronSetup.Lordaeron }
          }
        }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human02\H02Blademaster11",
              "Paladin fool! The warlocks of the Blackrock clan have spoken! Soon, demons will rain from the sky, and this wretched world will burn!",
              "Jubei'this"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human02\H02Uther12",
              "Yes, I've heard this rhetoric before. You orcs will never learn!",
              "Uther the Lightbringer")
          ), 
          new[]
          {
            LordaeronSetup.Lordaeron
          }, new Objective[]
          {
            new ObjectiveLegendInRect(LegendLordaeron.Uther, Regions.AlteracAmbient, "Alterac"),
            new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(Constants.UNIT_O00B_JUBEI_THOS_LEGION_DEMI, new Point(11066, 6291)))
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\HumanCampaign\Human07\H07Captain01",
          "This is a Light-forsaken land, isn't it? You can barely even see the sun! This howling wind cuts to the bone and you're not even shaking. Mi'lord, are you alright?",
          "Captain Falric"), new[]
        {
          LordaeronSetup.Lordaeron
        }, new Objective[]
        {
          new ObjectiveLegendReachRect(LegendLordaeron.Arthas, Regions.Central_Northrend, "central Northrend"),
          new ObjectiveControlLegend(LegendLordaeron.Arthas, false)
          {
            EligibleFactions = new List<Faction> { LordaeronSetup.Lordaeron }
          }
        }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Arthas06",
              "Looks like you haven't lost your touch. It's good to see you again, Jaina.",
              "Arthas Menethil"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Jaina07",
              "You too, Arthas. It's been awhile since a prince escorted me anywhere.",
              "Jaina Proudmoore"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Arthas08",
              "Yes, it has. Well, I guess we should get underway.",
              "Arthas Menethil")
          ), 
          new[]
          {
            LordaeronSetup.Lordaeron
          }, new Objective[]
          {
            new ObjectiveLegendMeetsLegend(LegendLordaeron.Arthas, LegendDalaran.LegendJaina),
            new ObjectiveControlLegend(LegendLordaeron.Arthas, false)
            {
              EligibleFactions = new List<Faction> { LordaeronSetup.Lordaeron, DalaranSetup.Dalaran }
            }
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Arthas12",
              "This must be the shrine that the old man spoke of. Any man who drinks from these Light-blessed waters will be healed.",
              "Arthas Menethil")
          ), 
          new[]
          {
            LordaeronSetup.Lordaeron
          }, new Objective[]
          {
            new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.FountainOfHealthAlterac, "Fountain of Health in Alterac"),
            new ObjectiveControlLegend(LegendLordaeron.Arthas, false)
            {
              EligibleFactions = new List<Faction> { LordaeronSetup.Lordaeron, DalaranSetup.Dalaran }
            }
          }));
    }
  }
}