using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Theramore;

/// <summary>Campaign dialogue for Jaina as the leader of Theramore.</summary>
public static class TheramoreDialogue
{
  private const string JainaSpeaker = "Jaina Proudmoore";
  private const string DaelinSpeaker = "Daelin Proudmoore";
  private const string ThrallSpeaker = "Thrall";

  /// <summary>Registers Jaina facing her father as an enemy.</summary>
  public static void SetupFatherAndDaughter()
  {
    var jaina = AllLegends.Dalaran.Jaina;
    var daelin = AllLegends.Kultiras.LegendAdmiral;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest13x\D13Jaina21.flac",
          "Father, wait!", JainaSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest13x\D13Jaina23.flac",
          "The Horde is no longer our enemy! The orcs have their own kingdom now. We--", JainaSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest13x\D13Proudmoore24.flac",
          "You have always been naive, my daughter. You aren't old enough to remember what these monsters did to our homeland. The orcs and their kin cannot be trusted. They must be exterminated like the mongrels they are!",
          DaelinSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest13x\D13Jaina25.flac",
          "I won't let you do it, father. You don't understand!", JainaSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest13x\D13Proudmoore26.flac",
          "I understand more than you suspect, my dear. Perhaps in time, you will too. Seize them all!",
          DaelinSpeaker)),
      ArthasDialogue.OwnersOf(jaina, daelin),
      new[]
      {
        new ObjectiveEitherOf(new ObjectiveLegendFightsLegend(jaina, daelin),
          new ObjectiveLegendFightsLegend(daelin, jaina))
      }));
  }

  /// <summary>Registers Jaina begging Thrall to spare her father's men, once Daelin's fleet has landed.</summary>
  public static void SetupPleaToThrall()
  {
    var jaina = AllLegends.Dalaran.Jaina;
    var thrall = AllLegends.Orc.Thrall;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest19x\D19Jaina03.flac",
          "Thrall, Rexxar... I come in peace. You must believe me--I had no part in my father's plans. I wish none of this had ever happened. I... I don't know what to do.",
          JainaSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest19x\D19Thrall04.flac",
          "We've bled together on many battlefields, Jaina. We've faced untold perils as allies. But your father threatens the security of our nation and the very future of my people. You know how this has to end.",
          ThrallSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest19x\D19Jaina05.flac",
          "I know, Thrall. Do what you must. There is a goblin shipyard on a nearby island that could provide you with warships of your own. With those, you could scatter the blockade surrounding Theramore.",
          JainaSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest19x\D19Jaina05A.flac",
          "But please, spare my men if you can. My father will try to use them against you, but they're the only real family I'll have left when this is over. Please do this... for me.",
          JainaSpeaker),
        new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest19x\D19Thrall06.flac",
          "We'll do all we can, Jaina. You have my word. Now you'd better make yourself scarce. The battle's about to begin.",
          ThrallSpeaker)),
      ArthasDialogue.OwnersOf(jaina, thrall),
      new[]
      {
        new ObjectiveEitherOf(new ObjectiveLegendMeetsLegend(jaina, thrall),
          new ObjectiveLegendMeetsLegend(thrall, jaina))
      }));
  }

  /// <summary>Plays Jaina mourning her father, with Rexxar's words if he fights alongside her.</summary>
  public static void PlayDaelinDeath(Faction theramore)
  {
    var lines = new List<Dialogue>
    {
      new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Jaina12.flac",
        "Father... why wouldn't you listen?", JainaSpeaker)
    };
    var audience = new List<Faction> { theramore };
    var theramorePlayer = theramore.Player;
    var rexxar = AllLegends.Tauren.Rexxar.Unit;
    if (theramorePlayer != null && rexxar != null && rexxar.Alive && rexxar.IsAllyTo(theramorePlayer))
    {
      lines.Add(new Dialogue(@"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Rexxar13.flac",
        "Above all else, Jaina, he was a proud warrior. Remember him as such.", "Rexxar"));
      var rexxarFaction = rexxar.Owner.GetPlayerData().Faction;
      if (rexxarFaction != null && rexxarFaction != theramore)
      {
        audience.Add(rexxarFaction);
      }
    }

    var dialogue = new DialogueSequence(lines.ToArray());
    foreach (var faction in audience)
    {
      var whichPlayer = faction.Player;
      if (whichPlayer != null)
      {
        whichPlayer.QueueDialogue(dialogue);
      }
    }
  }
}
