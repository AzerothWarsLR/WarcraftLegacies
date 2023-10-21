using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using WarcraftLegacies.Source.Quests.Scourge;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class ScourgeDialogueSetup
  {
    public static void Setup(AllLegendSetup legendSetup)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          soundFile: @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
          caption:
          "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
          speaker: "Kel'thuzad"), new[]
        {
          ScourgeSetup.Scourge,
          LordaeronSetup.Lordaeron,
        }, new[]
        {
          new ObjectiveLegendDead(legendSetup.Scourge.Kelthuzad)
        }));

      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
            caption: "Come forth, Lord Archimonde! Enter this world, and let us bask in your power!",
            speaker: "Kel'thuzad"),
          null,
          new[]
          {
            new ObjectiveStartSpell(Constants.ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false,
              legendSetup.Scourge.Kelthuzad)
          }));

      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead02\U02KelThuzad27.flac",
              caption: "Told you my death would mean little.",
              speaker: "Kel'thuzad"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead02\U02Arthas28.flac",
              caption: "What the... Am I hearing ghosts now?",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead02\U02KelThuzad29.flac",
              caption: "It is I, Kel'Thuzad. I was right about you, Prince Arthas.",
              speaker: "Kel'thuzad")),
          new[] { ScourgeSetup.Scourge },
          new Objective[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Scourge.Arthas, legendSetup.Scourge.Kelthuzad),
            new ObjectiveQuestComplete(ScourgeSetup.Scourge.GetQuestByType(typeof(QuestKelthuzadDies))),
            new ObjectiveQuestNotComplete(ScourgeSetup.Scourge.GetQuestByType(typeof(QuestKelthuzadLich)))
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AArthas01.flac",
              caption: "Ah, wondrous, eternal Quel'Thalas. I haven't been here since I was a boy.",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AKelThuzad02.flac",
              caption: "Be wary. The elves likely wait in ambush.",
              speaker: "Kel'thuzad"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AArthas03.flac",
              caption: "The frail elves do not concern me, necromancer. Our forces are strengthened with every foe we slay.",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AKelthuzad04.flac",
              caption: "Don't be too overconfident, death knight. The elves must not be taken lightly.",
              speaker: "Kel'thuzad")),
          new[]
          {
            ScourgeSetup.Scourge,
            QuelthalasSetup.Quelthalas
          },
          new Objective[]
          {
            new ObjectiveLegendInRect(legendSetup.Scourge.Arthas, Regions.QuelthalasAmbient, "Quel'thalas"),
            new ObjectiveLegendInRect(legendSetup.Scourge.Kelthuzad, Regions.QuelthalasAmbient, "Quel'thalas"),
            new ObjectiveQuestComplete(ScourgeSetup.Scourge.GetQuestByType(typeof(QuestKelthuzadDies))),
            new ObjectiveQuestNotComplete(ScourgeSetup.Scourge.GetQuestByType(typeof(QuestKelthuzadLich)))
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03ASylvanas12.flac",
              caption: "You are not welcome here. I am Sylvanas Windrunner, Ranger-General of Silvermoon. I advise you to turn back now.",
              speaker: "Sylvanas Windrunner"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AArthas13.flac",
              caption: "It is you who should turn back, Sylvanas. Death itself has come for your land.",
              speaker: "Arthas Menethil")),
          new[]
          {
            ScourgeSetup.Scourge,
            QuelthalasSetup.Quelthalas
          },
          new[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Scourge.Arthas, legendSetup.Quelthalas.Sylvanas)
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05AArthas02.flac",
              caption: "I was wondering when you'd show up.",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05ATichondrius03.flac",
              caption: "I am here to ensure that you do your job, little human. Not do it for you.",
              speaker: "Tichondrius")),
          new[]
          {
            ScourgeSetup.Scourge,
            LegionSetup.Legion
          },
          new[]
          {
            new ObjectiveLegendMeetsLegend(legendSetup.Scourge.Arthas, legendSetup.Legion.Tichondrius)
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05AArthas22.flac",
              caption: "Citizens of Silvermoon! I have given you ample opportunities to surrender, but you have stubbornly refused! Know that today, your entire race and your ancient heritage will end! Death itself has come to claim the high home of the elves!",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05AArthas30.flac",
              caption: "Now, arise, Kel'Thuzad, and serve the Lich King once again!",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05AKelThuzad31.flac",
              caption: "I am reborn, as promised! The Lich King has granted me eternal life!",
              speaker: "Kel'thuzad")),
          new[]
          {
            ScourgeSetup.Scourge,
            QuelthalasSetup.Quelthalas
          },
          new[]
          {
            new ObjectiveQuestComplete(ScourgeSetup.Scourge.GetQuestByType(typeof(QuestKelthuzadLich)))
          }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas01.flac",
            "Wizards of the Kirin Tor! I am Arthas, first of the Lich King's death knights! I demand that you open your gates and surrender to the might of the Scourge!",
            "Arthas Menethil"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas02.flac",
            "Greetings, Prince Arthas. How fares your noble father?",
            "Antonidas"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas03.flac",
            "Lord Antonidas. There's no need to be snide.",
            "Arthas Menethil"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas04.flac",
            "We've prepared for your coming, Arthas. My brethren and I have erected auras that will destroy any undead that pass through them.",
            "Antonidas"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas05.flac",
            "Your petty magics will not stop me, Antonidas.",
            "Arthas Menethil"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas06.flac",
            "Pull your troops back, or we will be forced to unleash our full powers against you! Make your choice, death knight.",
            "Antonidas")
        ), new[]
        {
          ScourgeSetup.Scourge,
          DalaranSetup.Dalaran
        }, new List<Objective>
        {
          new ObjectiveLegendInRect(legendSetup.Dalaran.Antonidas, Regions.Dalaran, "Dalaran"),
          new ObjectiveLegendInRect(legendSetup.Scourge.Arthas, Regions.Dalaran, "Dalaran")
        }
      ));
    }
  }
}