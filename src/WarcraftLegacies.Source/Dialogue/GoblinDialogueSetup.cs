using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using WarcraftLegacies.Source.Quests.Warsong;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class GoblinDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="GoblinDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest03x\D03Gazlowe01",
            "Ah, new guy, huh? I'm Gazlowe, chief engineer around these parts. But enough about me. We got work to do, buddy!",
            "Gazlowe")
          , new[]
          {
            GoblinSetup.Goblin
          }, new[]
          {
            new ObjectiveControlLegend(LegendGoblin.Gazlowe, false)
            {
              EligibleFactions = new List<Faction>{ GoblinSetup.Goblin }
            }
          }));
    }
  }
}