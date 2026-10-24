using System;
using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Scourge;

/// <summary>Campaign dialogue for the undead Arthas, heard by whoever controls him and whoever he meets.</summary>
public static class ArthasDialogue
{
  private const string ArthasSpeaker = "Arthas Menethil";
  private const float SilvermoonRadius = 1200;

  private static ObjectiveLegendKilledByLegend? _sylvanasDeath;
  private static ObjectiveTriggered? _sylvanasLiving;

  /// <summary>Complete while Sylvanas is still a living elf; fails once she is raised, cancelling her living dialogue.</summary>
  public static ObjectiveTriggered SylvanasLiving
  {
    get
    {
      if (_sylvanasLiving == null)
      {
        _sylvanasLiving = new ObjectiveTriggered("Sylvanas is still living");
        _sylvanasLiving.Trigger();
      }

      return _sylvanasLiving;
    }
  }

  /// <summary>Whether Arthas has already killed Sylvanas and spoken over her.</summary>
  public static bool SylvanasSlainByArthas => _sylvanasDeath != null && _sylvanasDeath.Progress == QuestProgress.Complete;

  /// <summary>The factions that control the given legends when the dialogue plays.</summary>
  public static IEnumerable<Faction> OwnersOf(params LegendaryHero[] legends) => OwnersOf(Array.Empty<Faction>(), legends);

  /// <summary><paramref name="alsoHearing"/>, plus the factions that control the given legends when the dialogue plays.</summary>
  public static IEnumerable<Faction> OwnersOf(Faction[] alsoHearing, params LegendaryHero[] legends)
  {
    var owners = new List<Faction>();
    foreach (var faction in alsoHearing)
    {
      if (!owners.Contains(faction))
      {
        owners.Add(faction);
        yield return faction;
      }
    }

    foreach (var legend in legends)
    {
      var legendUnit = legend.Unit;
      if (legendUnit == null)
      {
        continue;
      }

      var owner = legendUnit.Owner.GetPlayerData().Faction;
      if (owner != null && !owners.Contains(owner))
      {
        owners.Add(owner);
        yield return owner;
      }
    }
  }

  /// <summary>Registers dialogue that only needs the legends involved, whichever factions own them.</summary>
  public static void Setup()
  {
    var arthas = AllLegends.Scourge.Arthas;
    RegisterAntonidasDeath(arthas);
    RegisterSylvanasDeath(arthas);
    RegisterSilvermoon(arthas);
    RegisterDreadlords(arthas);
    RegisterScarletCrusade(arthas);
    RegisterKael(arthas);
    RegisterIllidan(arthas);
    RegisterLichKingCalls(arthas);
  }

  /// <summary>Registers dialogue about the summoning of Archimonde, which needs the Legion's quest.</summary>
  public static void SetupSummoning(QuestSummonLegion summonLegion, Faction legion)
  {
    var arthas = AllLegends.Scourge.Arthas;
    var kelthuzad = AllLegends.Scourge.Kelthuzad;

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead08\U08Arthas04.flac",
        "Defend Kel'Thuzad at all costs! The summoning must not be disrupted!", ArthasSpeaker),
      OwnersOf(arthas, kelthuzad),
      new Objective[]
      {
        new ObjectiveLegendaryHeroTrained(arthas),
        new ObjectiveStartSpell(ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false, kelthuzad)
      }));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead08\U08Arthas25.flac",
          "This has got to be a joke! What happens to us now?", ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead08\U08KelThuzad26.flac",
          "Be patient, young death knight. The Lich King foresaw this as well. You may yet have a part to play in his grand design.",
          "Kel'thuzad")),
      OwnersOf(arthas, kelthuzad),
      new Objective[]
      {
        new ObjectiveLegendaryHeroTrained(arthas),
        new ObjectiveFactionQuestComplete(summonLegion, legion)
      }));
  }

  /// <summary>Registers dialogue for the Fallen Prince's own quests and journeys.</summary>
  public static void SetupFallenPrince(Faction fallenPrince, QuestData throneOfLordaeron, QuestData stratholmeRisen)
  {
    var arthas = AllLegends.Scourge.Arthas;
    var audience = new[] { fallenPrince };

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead01\U01Tichondrius04.flac",
          "By killing your own father and delivering this land to the Scourge, you have passed your first test. The Lich King is pleased with your... enthusiasm.",
          "Tichondrius"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead01\U01Arthas05.flac",
          "Yes. I've damned everyone and everything I've ever loved in his name, and I still feel no remorse. No shame. No pity.",
          ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead01x\L01Arthas15.flac",
          "Now, we must secure the kingdom by scouring the last remnants of humanity from it!", ArthasSpeaker)),
      audience,
      new[]
      {
        new ObjectiveQuestComplete(throneOfLordaeron) { EligibleFactions = new List<Faction> { fallenPrince } }
      }));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead01\U01Arthas16.flac",
          "I'm in luck. These graves were dug recently.", ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead01\U01Arthas17.flac",
          "Arise in the name of the Lich King.", ArthasSpeaker)),
      audience,
      new[]
      {
        new ObjectiveQuestComplete(stratholmeRisen) { EligibleFactions = new List<Faction> { fallenPrince } }
      }));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead04x\L04Arthas01.flac",
          "Northrend. It feels like a lifetime since I was last here.", ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead04x\L04Arthas03.flac",
          "Something out there is threatening the Lich King. We must reach Icecrown quickly.", ArthasSpeaker)),
      audience,
      new[]
      {
        new ObjectiveLegendReachRect(arthas, Regions.Northrend_Ambiance, "Northrend")
      }));
  }

  /// <summary>Registers Sylvanas' revenge once she has broken free as the Forsaken.</summary>
  public static void SetupForsakenBetrayal()
  {
    var arthas = AllLegends.Scourge.Arthas;
    var sylvanas = AllLegends.Quel.Sylvanas;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead02xInterlude\L02Sylvanas56.flac",
          "You walked right into this one, Arthas. It's time to even the scales.", "Sylvanas Windrunner"),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead02xInterlude\L02Arthas57.flac",
          "Traitor! What have you done to me?", ArthasSpeaker)),
      OwnersOf(arthas, sylvanas),
      new[]
      {
        new ObjectiveLegendFightsLegend(sylvanas, arthas)
      }));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead02xInterlude\L02Sylvanas61.flac",
        "Give my regards to hell, you son of a bitch.", "Sylvanas Windrunner"),
      OwnersOf(arthas, sylvanas),
      new[]
      {
        new ObjectiveLegendKilledByLegend(arthas, sylvanas)
      }));
  }

  /// <summary>Registers Uther confronting the Scourge's Arthas, which can only happen while Lordaeron is still in the game.</summary>
  public static void SetupUther(Faction scourge, Faction lordaeron)
  {
    var arthas = AllLegends.Scourge.Arthas;
    var uther = AllLegends.Lordaeron.Uther;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead02\U02Uther21.flac",
          "Your father ruled this land for seventy years, and you've ground it to dust in a matter of days.",
          "Uther the Lightbringer"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead02\U02Arthas22.flac",
          "Very dramatic, Uther. Give me the urn, and I'll make sure you die quickly.", ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead02\U02Uther23.flac",
          "The urn holds your father's ashes, Arthas! What, were you hoping to piss on them one last time before you left his kingdom to rot?",
          "Uther the Lightbringer"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead02\U02Arthas24.flac",
          "I didn't know what it held. Nor does it matter. I'll take what I came for one way or another.",
          ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead02\U02Uther25.flac",
          "I dearly hope that there's a special place in hell waiting for you, Arthas.",
          "Uther the Lightbringer"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead02\U02Arthas26.flac",
          "We may never know, Uther. I intend to live forever.", ArthasSpeaker)),
      new[] { scourge, lordaeron },
      new[]
      {
        new ObjectiveLegendFightsLegend(arthas, uther)
      }));
  }

  private static void RegisterAntonidasDeath(LegendaryHero arthas)
  {
    var antonidas = AllLegends.Dalaran.Antonidas;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas13.flac",
          "It pains me to even look at you, Arthas.", "Antonidas"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas14.flac",
          "I'll be happy to end your torment, old man. I told you that your magics could not stop me.",
          ArthasSpeaker)),
      OwnersOf(arthas, antonidas),
      new[]
      {
        new ObjectiveLegendKilledByLegend(antonidas, arthas)
      }));
  }

  private static void RegisterSylvanasDeath(LegendaryHero arthas)
  {
    var sylvanas = AllLegends.Quel.Sylvanas;
    _sylvanasDeath = new ObjectiveLegendKilledByLegend(sylvanas, arthas);
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead04A\U04ASylvanas21.flac",
          "Finish it! I deserve... a clean death.", "Sylvanas Windrunner"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead04A\U04AArthas22.flac",
          "After all you've put me through, woman, the last thing I'll give you is the peace of death.",
          ArthasSpeaker)),
      OwnersOf(arthas, sylvanas),
      new Objective[]
      {
        _sylvanasDeath,
        SylvanasLiving
      }));
  }

  private static void RegisterSilvermoon(LegendaryHero arthas)
  {
    var silvermoon = AllLegends.Quel.Silvermoon.Unit;
    if (silvermoon == null)
    {
      return;
    }

    var outskirts = new Rectangle(silvermoon.X - SilvermoonRadius, silvermoon.Y - SilvermoonRadius,
      silvermoon.X + SilvermoonRadius, silvermoon.Y + SilvermoonRadius);
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead05A\U05AArthas22.flac",
        "Citizens of Silvermoon! I have given you ample opportunities to surrender, but you have stubbornly refused! Know that today, your entire race and your ancient heritage will end! Death itself has come to claim the high home of the elves!",
        ArthasSpeaker),
      null,
      new[]
      {
        new ObjectiveLegendReachRect(arthas, outskirts, "Silvermoon")
      }));
  }

  private static void RegisterDreadlords(LegendaryHero arthas)
  {
    var legion = AllLegends.Legion;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead01x\L01Arthas07.flac",
        "Greetings, dreadlords. I should thank you for looking after my kingdom during my absence. However, I won't be requiring your services any longer.",
        ArthasSpeaker),
      OwnersOf(arthas, legion.Tichondrius, legion.Malganis),
      new[]
      {
        new ObjectiveEitherOf(new ObjectiveLegendFightsLegend(arthas, legion.Tichondrius),
          new ObjectiveLegendFightsLegend(arthas, legion.Malganis))
      }));
  }

  private static void RegisterScarletCrusade(LegendaryHero arthas)
  {
    var renault = AllLegends.Scarlet.Renault;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead01x\L01PaladinOne21.flac",
          "Arthas, you wear your father's crown as if you earned it. You may kill me, but my brethren will never stop hounding you!",
          "Paladin"),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead01x\L01Arthas22.flac",
          "I can't believe that any of you survived the first purge. No matter. After today, your self-righteous order will cease to exist.",
          ArthasSpeaker)),
      OwnersOf(arthas, renault),
      new[]
      {
        new ObjectiveLegendFightsLegend(arthas, renault)
      }));
  }

  private static void RegisterKael(LegendaryHero arthas)
  {
    var kael = AllLegends.Sunfury.Kael;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Arthas30.flac",
          "Are you still upset that I stole Jaina from you, Kael?", ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Kael31.flac",
          "You've taken everything I ever cared for, Arthas. Vengeance is all I have left.",
          "Kael'thas Sunstrider")),
      OwnersOf(arthas, kael),
      new[]
      {
        new ObjectiveLegendFightsLegend(arthas, kael)
      }));
  }

  private static void RegisterIllidan(LegendaryHero arthas)
  {
    var illidan = AllLegends.Naga.Illidan;
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Illidan27.flac",
          "Hello, Arthas.", "Illidan Stormrage"),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Arthas28.flac",
          "You look different, Illidan. I guess the Skull of Gul'dan didn't agree with you.", ArthasSpeaker),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Illidan29.flac",
          "You and your Lich King duped me once, but now I have the upper hand.", "Illidan Stormrage")),
      OwnersOf(arthas, illidan),
      new[]
      {
        new ObjectiveLegendFightsLegend(arthas, illidan)
      }));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Arthas40.flac",
        "Leave this world and never return. If you do, I'll be waiting.", ArthasSpeaker),
      OwnersOf(arthas, illidan),
      new[]
      {
        new ObjectiveLegendKilledByLegend(illidan, arthas)
      }));
  }

  private static void RegisterLichKingCalls(LegendaryHero arthas)
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead07CxInterlude\L07CLichKing44.flac",
          "Arthas, my champion. You have come at last.", "The Lich King"),
        new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead07CxInterlude\L07CArthas45.flac",
          "Master?", ArthasSpeaker)),
      OwnersOf(arthas),
      new Objective[]
      {
        new ObjectiveLegendLevel(arthas, 12),
        new ObjectiveLegendReachRect(arthas, Regions.Ice_Crown, "Icecrown")
      }));
  }
}
