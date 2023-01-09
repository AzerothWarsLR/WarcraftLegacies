using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class ScourgeDialogueSetup
  {
    public static void Setup()
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
          new ObjectiveLegendDead(LegendScourge.LegendKelthuzad)
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
              LegendScourge.LegendKelthuzad)
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
            new ObjectiveLegendMeetsLegend(LegendLordaeron.Arthas, LegendScourge.LegendKelthuzad)
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03\U03AArthas01.flac",
              caption: "Ah, wondrous, eternal Quel'Thalas. I haven't been here since I was a boy.",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03\U03AKelThuzad02.flac",
              caption: "Be wary. The elves likely wait in ambush.",
              speaker: "Kel'thuzad"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03\U03AArthas03.flac",
              caption: "The frail elves do not concern me, necromancer. Our forces are strengthened with every foe we slay.",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03\U03AKelthuzad04.flac",
              caption: "Don't be too overconfident, death knight. The elves must not be taken lightly.",
              speaker: "Kel'thuzad")),
          new[] { ScourgeSetup.Scourge },
          new[]
          {
            new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.QuelthalasAmbient, "Quel'thalas"),
            new ObjectiveLegendInRect(LegendScourge.LegendKelthuzad, Regions.QuelthalasAmbient, "Quel'thalas")
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03\U03ASylvanas12.flac",
              caption: "You are not welcome here. I am Sylvanas Windrunner, Ranger-General of Silvermoon. I advise you to turn back now.",
              speaker: "Sylvanas Windrunner"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03\U03AArthas13.flac",
              caption: "It is you who should turn back, Sylvanas. Death itself has come for your land.",
              speaker: "Arthas Menethil")),
          new[] { ScourgeSetup.Scourge },
          new[]
          {
            new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.QuelthalasAmbient, "Quel'thalas"),
            new ObjectiveLegendInRect(LegendScourge.LegendKelthuzad, Regions.QuelthalasAmbient, "Quel'thalas")
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05\U05AArthas02.flac",
              caption: "I was wondering when you'd show up.",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05\U05ATichondrius03.flac",
              caption: "I am here to ensure that you do your job, little human. Not do it for you.",
              speaker: "Tichondrius")),
          new[] { ScourgeSetup.Scourge },
          new[]
          {
            new ObjectiveLegendMeetsLegend(LegendLordaeron.Arthas, LegendLegion.LEGEND_TICHONDRIUS)
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05\U05AArthas22.flac",
              caption: "Citizens of Silvermoon! I given you ample opportunities to surrender, but you have stubbornly refused! Know that today, your entire race and your ancient heritage will end! Death itself has come to claim the high home of the elves!",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05\U05AArthas30.flac",
              caption: "Now, arise, Kel'Thuzad, and serve the Lich King once again!",
              speaker: "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05\U05AKelThuzad31.flac",
              caption: "I am reborn, as promised! The Lich King has granted me eternal life!",
              speaker: "Kel'thuzad")),
          new[] { ScourgeSetup.Scourge },
          new[]
          {
            new ObjectiveLegendMeetsLegend(LegendLordaeron.Arthas, LegendLegion.LEGEND_TICHONDRIUS)
          }));
    }
  }
}