using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.BansheesHost;

/// <summary>Campaign dialogue for Sylvanas as the Banshee's Host and the Forsaken.</summary>
public static class SylvanasDialogue
{
  private const string SylvanasSpeaker = "Sylvanas Windrunner";
  private const string ArthasSpeaker = "Arthas Menethil";

  /// <summary>Plays Arthas raising Sylvanas as a banshee, for the Banshee's Host and whoever controls Arthas.</summary>
  public static void PlayBansheeRaised(Faction bansheesHost)
  {
    var refusal = new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead04A\U04ASylvanas23.flac",
      "No! You wouldn't dare!", SylvanasSpeaker);
    IHasPlayableDialogue dialogue = refusal;
    if (!ArthasDialogue.SylvanasSlainByArthas)
    {
      dialogue = new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead04A\U04AArthas22.flac",
          "After all you've put me through, woman, the last thing I'll give you is the peace of death.",
          ArthasSpeaker),
        refusal);
    }

    Play(dialogue, ArthasDialogue.OwnersOf(new[] { bansheesHost }, AllLegends.Scourge.Arthas));
  }

  /// <summary>Plays Sylvanas realising she is free of the Lich King.</summary>
  public static void PlayBrokenFree(Faction forsaken)
  {
    Play(new DialogueSequence(
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead03x\L03Banshee01.flac",
        "You seem troubled, mistress.", "Banshee"),
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead03x\L03Sylvanas02a.flac",
        "Aren't you, sister? Only days ago we were the Lich King's slaves. We existed only to slaughter in his name.",
        SylvanasSpeaker),
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead03x\L03Sylvanas02b.flac",
        "And now we are... free.", SylvanasSpeaker),
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead03x\L03Banshee03.flac",
        "I don't understand, mistress. I thought you'd be overjoyed.", "Banshee"),
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead03x\L03Sylvanas04a.flac",
        "What joy is there in this curse? We are still undead, sister--still monstrosities.", SylvanasSpeaker),
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead03x\L03Sylvanas04b.flac",
        "What are we if not slaves to this torment?", SylvanasSpeaker)), new[] { forsaken });
  }

  /// <summary>Plays Sylvanas naming the Forsaken once they take the Undercity, with Varimathras at her side.</summary>
  public static void PlayUndercity(Faction forsaken)
  {
    var lines = new List<Dialogue>();
    if (!IsAlliedWithScourge(forsaken))
    {
      lines.Add(new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead06x\L06Sylvanas62a.flac",
        "The capital city is ours, but we are no longer part of the Scourge.", SylvanasSpeaker));
    }

    lines.Add(new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead06x\L06Sylvanas62b.flac",
      "From here on out, we shall be known as the Forsaken.", SylvanasSpeaker));
    lines.Add(new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead06x\L06Sylvanas63.flac",
      "We will find our own path in this world, dreadlord... and slaughter anyone who stands in our way.",
      SylvanasSpeaker));
    lines.Add(new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead05x\L05Varimathras62.flac",
      "You sound more like one of us with every passing day, my lady.", "Varimathras"));
    Play(new DialogueSequence(lines.ToArray()), new[] { forsaken });
  }

  private static bool IsAlliedWithScourge(Faction faction)
  {
    var whichPlayer = faction.Player;
    if (whichPlayer == null)
    {
      return false;
    }

    if (!FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      return false;
    }

    var scourgePlayer = scourge.Player;
    return scourgePlayer != null && scourgePlayer.GetPlayerData().Team == whichPlayer.GetPlayerData().Team;
  }

  /// <summary>Registers the Forsaken Sylvanas meeting her old enemies.</summary>
  public static void SetupForsaken()
  {
    var sylvanas = AllLegends.Quel.Sylvanas;
    var garithos = AllLegends.Lordaeron.Garithos;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead05x\L05Sylvanas33.flac",
          "You must be the human in command of this rabble.", SylvanasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead05x\L05Garithos57.flac",
          "Why should we trust you? You're part of the Scourge that drove us out in the first place!", "Garithos"),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead05x\L05Sylvanas58.flac",
          "Not anymore. My only interest here is vengeance.", SylvanasSpeaker)),
      ArthasDialogue.OwnersOf(sylvanas, garithos),
      new[]
      {
        new ObjectiveLegendFightsLegend(sylvanas, garithos)
      }));

    var legion = AllLegends.Legion;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead03x\L03Sylvanas59.flac",
        "Come and face me, dreadlord! Are you afraid?", SylvanasSpeaker),
      ArthasDialogue.OwnersOf(sylvanas, legion.Tichondrius, legion.Malganis),
      new[]
      {
        new ObjectiveEitherOf(new ObjectiveLegendFightsLegend(sylvanas, legion.Tichondrius),
          new ObjectiveLegendFightsLegend(sylvanas, legion.Malganis))
      }));
  }

  private static void Play(IHasPlayableDialogue dialogue, IEnumerable<Faction> audience)
  {
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
