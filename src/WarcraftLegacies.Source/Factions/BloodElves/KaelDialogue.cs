using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.BloodElves;

/// <summary>Campaign dialogue for Kael'thas as the Blood Elves and the Sunfury.</summary>
public static class KaelDialogue
{
  private const string KaelSpeaker = "Kael'thas Sunstrider";

  /// <summary>Plays Kael'thas naming his people the blood elves as they leave for Outland.</summary>
  public static void PlayExodus(Faction bloodElves) =>
    Play(new DialogueSequence(
      new Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf06x\S06Kael23a.flac",
        "The Scourge devoured our ancient homeland of Quel'Thalas. The once-proud bloodline of my people is nearly spent.",
        KaelSpeaker),
      new Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf06x\S06Kael23b.flac",
        "The few of us that remain now call ourselves blood elves, in homage to our murdered people.", KaelSpeaker),
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human02xInterlude\A02Kael28.flac",
        "We have been cut off from our power, from our birthright! Without a new source of magic, my people will surely die.",
        KaelSpeaker)), new[] { bloodElves });

  /// <summary>Plays Kael'thas turning to the demons as the Sunfury.</summary>
  public static void PlayPact(Faction sunfury) =>
    Play(new DialogueSequence(
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human02xInterlude\A02Kael24.flac",
        "I can't explain it exactly, but ever since our homeland was destroyed, my brethren and I have felt empty... almost drained of our spirit.",
        KaelSpeaker),
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human02xInterlude\A02Kael25.flac",
        "There is a hunger now that has... hardened our hearts.", KaelSpeaker)), new[] { sunfury });

  /// <summary>Registers Lady Vashj tempting Kael'thas with demonic power when they meet as allies.</summary>
  public static void RegisterVashjMeeting()
  {
    var kael = AllLegends.Sunfury.Kael;
    var vashj = AllLegends.Naga.Vashj;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human02xInterlude\A02LadyVashj29.flac",
        "There are other founts of power in this world, Kael. Demons, for instance.", "Lady Vashj"),
      ArthasDialogue.OwnersOf(kael, vashj),
      new Objective[]
      {
        new ObjectiveLegendMeetsLegend(kael, vashj),
        new ObjectiveTeamCondition("Kael'thas and Lady Vashj are allies", () => AreAllied(kael, vashj))
      }));
  }

  private static bool AreAllied(LegendaryHero first, LegendaryHero second)
  {
    var firstUnit = first.Unit;
    var secondUnit = second.Unit;
    if (firstUnit == null || secondUnit == null)
    {
      return false;
    }

    return firstUnit.Owner.GetPlayerData().Team == secondUnit.Owner.GetPlayerData().Team;
  }

  /// <summary>Plays Kil'jaeden arriving at the Sunwell and Kael'thas swearing to serve him.</summary>
  public static void PlayKiljaedenSummoned(Faction summoner) =>
    Play(new DialogueSequence(
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human05xInterlude\A05Kiljaeden58.flac",
        "My creation, the Lich King, has betrayed me. He dared to break the pact that binds him to my will, but his spirit still lies trapped inside the Frozen Throne of Icecrown. Destroy it for me, and I will grant you your heart's desire.",
        "Kil'jaeden"),
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human07xInterlude\A07Kael33.flac",
        "The blood elves are yours, as well, master. We will drive the Scourge before us -- and shatter the Frozen Throne as you command.",
        KaelSpeaker)), new[] { summoner });

  /// <summary>Registers Kael'thas pledging the blood elves to Illidan when they meet, for Blood Elves who joined him.</summary>
  public static void RegisterIllidanPledge()
  {
    var kael = AllLegends.Sunfury.Kael;
    var illidan = AllLegends.Naga.Illidan;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human05xInterlude\A05Kael50.flac",
          "Can you help us, Lord Illidan? Can you cure us?", KaelSpeaker),
        new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human05xInterlude\A05Illidan49.flac",
          "You were right to come to me, Kael. I share the pain of your addiction--your hunger for magic.",
          "Illidan Stormrage"),
        new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human05xInterlude\A05Illidan51.flac",
          "There is no cure, young one. But there are ways to feed the hunger. Follow me, and I will grant your people more magic than they can imagine.",
          "Illidan Stormrage"),
        new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human05xInterlude\A05Kael52.flac",
          "So be it. Lord Illidan, my fellow blood elves and I humbly pledge ourselves to your service.",
          KaelSpeaker)),
      ArthasDialogue.OwnersOf(kael, illidan),
      new[]
      {
        new ObjectiveLegendMeetsLegend(kael, illidan)
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
