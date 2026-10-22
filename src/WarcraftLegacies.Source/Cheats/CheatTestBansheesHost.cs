using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.BansheesHost;
using WarcraftLegacies.Source.Factions.BansheesHost.Paths;
using WarcraftLegacies.Source.Factions.BansheesHost.Quests;
using WarcraftLegacies.Source.Factions.Forsaken;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Factions.Quelthalas;
using WarcraftLegacies.Source.Factions.Quelthalas.Paths;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Takes the Banshee's Host path, tests its bases, roster, abilities and quests, then takes the Rise of the Forsaken,
/// and writes what happened to a file.
/// </summary>
public sealed class CheatTestBansheesHost : Command
{
  private const string ReportPath = @"WarcraftLegacies-bansheeshost-report.pld";
  private const int ReportChunkLength = 200;
  private const float ArenaClearRadius = 800;
  private const float ArenaSpacing = 2200;
  private static readonly int _silenceBuffId = FourCC("BNsi");
  private static readonly int _thunderClapBuffId = FourCC("BCtc");

  private static readonly List<string> _report = new();
  private static readonly List<unit> _testUnits = new();
  private static int _passed;
  private static int _failed;

  private static readonly int[] _deathknellStructureTypes =
  {
    UNIT_UNPL_NECROPOLIS_SCOURGE_T1, UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR,
    UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, UNIT_UBON_BONEYARD_SCOURGE_SIEGE, UNIT_USEP_CRYPT_SCOURGE_BARRACKS,
    UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER
  };

  /// <inheritdoc />
  public override string CommandText => "testbh";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    "Takes The Banshee's Host, tests its bases, abilities and quests, and writes a report to CustomMapData.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var quelthalas = cheater.GetPlayerData().Faction as QuelthalasFaction;
    if (!RoleplaySetting.IsActive || quelthalas == null)
    {
      return "Play Quel'thalas in Roleplay mode to run this.";
    }

    var path = quelthalas.GetAllPaths().OfType<PathBansheesHost>().FirstOrDefault();
    if (path == null)
    {
      return "Quel'thalas has no Banshee's Host path.";
    }

    _report.Clear();
    _testUnits.Clear();
    _passed = 0;
    _failed = 0;
    Step(cheater, "before the path", PrepareScourge);
    Step(cheater, "take the path", () =>
    {
      path.ForceAvailable();
      path.Accept(cheater);
      Log($"  path state: {path.State}");
    });

    After(35, () =>
    {
      Step(cheater, "after the path", () => CheckPath(cheater));
      Step(cheater, "roster", () => CheckRoster(cheater));
      After(2, () => RunAbilityTests(cheater));
    });

    return "Banshee's Host test started, it takes about 3 minutes. Don't touch anything until it says it's finished.";
  }

  private static void PrepareScourge()
  {
    var scourge = GetScourge();
    var scourgePlayer = scourge?.Player;
    if (scourge == null || scourgePlayer == null)
    {
      Log("  SKIP no Scourge player: taking over Deathknell and En'kilah isn't tested, they are built fresh instead");
      return;
    }

    var plague = scourge.GetAllQuests().OfType<QuestPlague>().FirstOrDefault();
    if (plague != null && plague.Progress != QuestProgress.Complete)
    {
      plague.Progress = QuestProgress.Complete;
      Log("  completed the Plague so the Scourge holds Deathknell");
    }

    foreach (var structure in GetStructures(Regions.DeathknellUnlock, scourgePlayer))
    {
      if (structure.UnitType == UNIT_UBON_BONEYARD_SCOURGE_SIEGE)
      {
        structure.Kill();
        Log("  destroyed the Deathknell Boneyard so it must be rebuilt");
        break;
      }
    }
  }

  private static void CheckPath(player cheater)
  {
    var faction = cheater.GetPlayerData().Faction;
    Check(faction is BansheesHostFaction, "you are now the Banshee's Host");
    var bansheesHost = faction as BansheesHostFaction;
    if (bansheesHost == null)
    {
      return;
    }

    var sylvanas = AllLegends.Quel.Sylvanas.Unit;
    Check(sylvanas != null && sylvanas.Owner == cheater && sylvanas.Alive, "Sylvanas is alive and yours");
    Check(sylvanas != null && sylvanas.UnitType == UNIT_U03B_BANSHEE_QUEEN_BANSHEESHOST, "Sylvanas is the Banshee Queen");

    foreach (var typeId in _deathknellStructureTypes)
    {
      var expected = typeId == UNIT_UZIG_ZIGGURAT_SCOURGE_FARM || typeId == UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER ? 2 : 1;
      var count = GetStructures(Regions.DeathknellUnlock, cheater).Count(x => x.UnitType == typeId);
      Check(count == expected, $"Deathknell has {count} {GetObjectName(typeId)} (expected {expected})");
    }

    var enKilah = GetStructures(BansheesHostTransformation.NorthrendBase, cheater);
    Check(enKilah.Count(x => x.UnitType == UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3) == 1, "En'kilah has a Black Citadel");
    Check(enKilah.All(x => x.UnitType != UNIT_UNPL_NECROPOLIS_SCOURGE_T1), "En'kilah has no Necropolis left");

    var scourgePlayer = GetScourge()?.Player;
    if (scourgePlayer != null)
    {
      var leftovers = GetStructures(Regions.DeathknellUnlock, scourgePlayer).Select(x => GetObjectName(x.UnitType)).ToList();
      Check(leftovers.Count == 0, $"the Scourge has nothing left at Deathknell ({string.Join(", ", leftovers)})");
    }

    Check(HasQuest<QuestBansheesVengeance>(bansheesHost), "has The Banshee's Vengeance");
    Check(HasQuest<QuestRangerLord>(bansheesHost), "has The Ranger-Lord");
    if (FactionManager.TryGetFactionByType<LegionFaction>(out var legion))
    {
      var summoned = legion.GetAllQuests().OfType<QuestSummonLegion>().Any(x => x.Progress == QuestProgress.Complete);
      Check(summoned || HasQuest<QuestHeraldOfArchimonde>(bansheesHost), "has Herald of Archimonde");
    }

    foreach (var forsakenPath in bansheesHost.GetAllPaths().OfType<PathRiseOfTheForsaken>())
    {
      Check(forsakenPath.State == PathState.Locked, $"{forsakenPath.Name} is still locked ({forsakenPath.State})");
    }
  }

  private static void CheckRoster(player cheater)
  {
    CheckLimit(cheater, UNIT_U10A_WAILING_SORROW_BANSHEESHOST_ELITE, 4);
    CheckLimit(cheater, UNIT_UMTW_MEAT_WAGON_SCOURGE, 6);
    CheckLimit(cheater, UNIT_UOBS_OBSIDIAN_STATUE_SCOURGE, 2);
    CheckLimit(cheater, UNIT_U01O_GRAND_APOTHECARY_FORSAKEN, 1);
    CheckLimit(cheater, UNIT_H049_RANGER_LORD_FORSAKEN, 0);
    CheckLimit(cheater, UNIT_UGHO_GHOUL_SCOURGE, 0);
    CheckLimit(cheater, UNIT_UNEC_NECROMANCER_SCOURGE, 0);
    CheckLimit(cheater, UNIT_UGAR_GARGOYLE_SCOURGE, 0);
    CheckLimit(cheater, UNIT_UABO_ABOMINATION_SCOURGE, 0);
    CheckLimit(cheater, UNIT_H02G_VRYKUL_WARRIOR_SCOURGE, 0);
    foreach (var unlimited in new[]
             {
               UNIT_H08O_ROTGUARD_FORSAKEN, UNIT_H08N_DREADGUARD_FORSAKEN_CULT, UNIT_N07S_DEADEYE_FORSAKEN_CULT,
               UNIT_UBAN_BANSHEE_SCOURGE, UNIT_U01R_APOTHECARY_FORSAKEN_CULT
             })
    {
      Check(GetPlayerTechMaxAllowed(cheater, unlimited) != 0, $"can train {GetObjectName(unlimited)}");
    }
  }

  private static void CheckLimit(player cheater, int typeId, int expected)
  {
    var limit = GetPlayerTechMaxAllowed(cheater, typeId);
    var actual = limit < 0 ? 0 : limit;
    Check(actual == expected, $"{GetObjectName(typeId)} limit is {limit} (expected {expected})");
  }

  private static void RunAbilityTests(player cheater)
  {
    var arenas = FindArenas(3);
    Log($"[arenas] found {arenas.Count}: {string.Join(" / ", arenas.Select(x => $"{(int)x.X},{(int)x.Y}"))}");
    var sylvanas = AllLegends.Quel.Sylvanas.Unit;
    if (arenas.Count < 3 || sylvanas == null)
    {
      Check(false, "found three empty spots to test abilities in, and Sylvanas exists");
      Finish(cheater);
      return;
    }

    sylvanas.SetPosition(arenas[1].X, arenas[1].Y);
    PrepareHero(sylvanas, ABILITY_A17N_SPIRIT_LASH_BANSHEESHOST_SYLVANAS, ABILITY_A17O_ETHEREAL_VEIL_BANSHEESHOST_SYLVANAS,
      ABILITY_A17P_MOURNING_CHORUS_BANSHEESHOST_SYLVANAS, ABILITY_A17M_INSPIRE_MADNESS_BANSHEESHOST_SYLVANAS);

    TestKeeningWail(cheater, arenas[0]);
    After(3, () => TestAnguish(cheater, arenas[0]));
    After(9, () => TestLingeringGrief(cheater, arenas[0]));
    After(13, () => TestSpiritLash(cheater, sylvanas));
    After(16, () => TestEtherealVeil(cheater, sylvanas));
    After(22, () => TestMourningChorus(cheater, sylvanas));
    After(25, () => TestInspireMadness(cheater, sylvanas));
    After(28, () => TestRangerLord(cheater));
    After(34, () => TestBansheesVengeance(cheater, arenas[2]));
  }

  private static void TestKeeningWail(player cheater, Point arena)
  {
    var sorrow = CreateTestUnit(cheater, UNIT_U10A_WAILING_SORROW_BANSHEESHOST_ELITE, arena.X, arena.Y);
    var enemies = new List<unit>();
    for (var i = 0; i < 12; i++)
    {
      var angle = i * 0.52f;
      enemies.Add(CreateEnemy(arena.X + 250 * Cos(angle), arena.Y + 250 * Sin(angle), 3000));
    }

    sorrow.Mana = sorrow.MaxMana;
    sorrow.IssueOrder(OrderId("thunderclap"));
    After(1, () => Step(cheater, "Keening Wail", () =>
    {
      var damaged = enemies.Count(x => x.Life < x.MaxLife);
      Check(damaged == 12, $"all 12 enemies were struck ({damaged})");
      var total = enemies.Sum(x => x.MaxLife - x.Life);
      Check(total >= 650 && total <= 720, $"total damage was {(int)total} (expected 700, the cap)");
      Check(enemies.Count(x => x.GetAbilityLevel(_thunderClapBuffId) > 0) == 12, "all 12 enemies are slowed");
      foreach (var enemy in enemies)
      {
        enemy.Kill();
      }
    }));
  }

  private static void TestAnguish(player cheater, Point arena)
  {
    var sorrow = GetTestUnit(UNIT_U10A_WAILING_SORROW_BANSHEESHOST_ELITE);
    if (sorrow == null)
    {
      Check(false, "the Wailing Sorrow still exists for Anguish");
      return;
    }

    var target = CreateEnemy(arena.X + 300, arena.Y, 3000);
    sorrow.Life = sorrow.MaxLife * 0.5f;
    var lifeBefore = sorrow.Life;
    sorrow.Mana = sorrow.MaxMana;
    sorrow.IssueOrder(OrderId("cripple"), target);
    After(4.5f, () => Step(cheater, "Anguish", () =>
    {
      Check(target.GetAbilityLevel(BUFF_B108_ANGUISH) > 0, "the target has Anguish");
      var damage = target.MaxLife - target.Life;
      Check(damage >= 120 && damage <= 200, $"Anguish dealt {(int)damage} after about 4 seconds (expected 160)");
      Check(sorrow.Life > lifeBefore, $"the Wailing Sorrow was healed ({(int)lifeBefore} to {(int)sorrow.Life})");
      target.Kill();
    }));
  }

  private static void TestLingeringGrief(player cheater, Point arena)
  {
    var sorrow = GetTestUnit(UNIT_U10A_WAILING_SORROW_BANSHEESHOST_ELITE);
    if (sorrow == null)
    {
      Check(false, "the Wailing Sorrow still exists for Lingering Grief");
      return;
    }

    var mourner = CreateEnemy(sorrow.X + 150, sorrow.Y, 3000);
    var distant = CreateEnemy(sorrow.X + 700, sorrow.Y, 3000);
    sorrow.Kill();
    After(3.5f, () => Step(cheater, "Lingering Grief", () =>
    {
      var damage = mourner.MaxLife - mourner.Life;
      Check(damage >= 90 && damage <= 180, $"a nearby enemy took {(int)damage} after about 3 seconds (expected 135)");
      Check(distant.Life >= distant.MaxLife, "a distant enemy took nothing");
    }));
  }

  private static void TestSpiritLash(player cheater, unit sylvanas)
  {
    var inLine = new List<unit>();
    for (var i = 1; i <= 3; i++)
    {
      inLine.Add(CreateEnemy(sylvanas.X + 200 * i, sylvanas.Y, 3000));
    }

    var outOfLine = CreateEnemy(sylvanas.X + 400, sylvanas.Y + 500, 3000);
    sylvanas.Mana = sylvanas.MaxMana;
    sylvanas.IssueOrder(OrderId("shockwave"), sylvanas.X + 800, sylvanas.Y);
    After(2, () => Step(cheater, "Spirit Lash", () =>
    {
      foreach (var enemy in inLine)
      {
        var damage = enemy.MaxLife - enemy.Life;
        Check(damage >= 180 && damage <= 240, $"an enemy in the line took {(int)damage} (expected 210)");
      }

      Check(inLine.Count(x => x.GetAbilityLevel(_silenceBuffId) > 0) >= 2, "the enemies in the line are silenced");
      Check(outOfLine.Life >= outOfLine.MaxLife, "an enemy off the line took nothing");
    }));
  }

  private static void TestEtherealVeil(player cheater, unit sylvanas)
  {
    var caster = unit.Create(player.NeutralAggressive, FourCC("hsor"), sylvanas.X + 200, sylvanas.Y, 180);
    _testUnits.Add(caster);
    caster.IsPaused = true;
    caster.Mana = caster.MaxMana;
    sylvanas.Mana = sylvanas.MaxMana;
    sylvanas.IssueOrder(OrderId("berserk"));
    After(1, () =>
    {
      Step(cheater, "Ethereal Veil", () =>
      {
        Check(sylvanas.GetAbilityLevel(BUFF_B109_ETHEREAL_VEIL) > 0, "Sylvanas has Ethereal Veil");
        var lifeBefore = sylvanas.Life;
        caster.DealDamage(sylvanas, 150, true, false, attacktype.Normal, damagetype.Normal, weapontype.WhoKnows);
        Check(sylvanas.Life >= lifeBefore, $"an attack didn't hurt her ({(int)lifeBefore} to {(int)sylvanas.Life})");
      });
      sylvanas.IssueOrder(ORDER_ATTACK, caster);
    });
    After(4, () => Step(cheater, "Ethereal Veil mana burn", () =>
    {
      Check(caster.Mana < caster.MaxMana, $"her attacks burned mana ({(int)caster.Mana} of {(int)caster.MaxMana} left)");
      caster.Kill();
      sylvanas.IssueOrder(ORDER_STOP);
    }));
  }

  private static void TestMourningChorus(player cheater, unit sylvanas)
  {
    var victim = CreateEnemy(sylvanas.X + 300, sylvanas.Y - 300, 100);
    victim.Kill();
    After(1, () => Step(cheater, "Mourning Chorus", () =>
    {
      var spirits = GlobalGroup.EnumUnitsInRange(sylvanas.X, sylvanas.Y, 800)
        .Count(x => x.UnitType == UNIT_U10B_MOURNING_SPIRIT_BANSHEESHOST && x.Owner == cheater && x.Alive);
      Check(spirits == 1, $"a Mourning Spirit rose for you ({spirits}, level 4 is a 100% chance)");
    }));
  }

  private static void TestInspireMadness(player cheater, unit sylvanas)
  {
    var victims = new List<unit>();
    for (var i = 0; i < 3; i++)
    {
      victims.Add(CreateEnemy(sylvanas.X - 400 + 60 * i, sylvanas.Y + 300, 3000));
    }

    sylvanas.Mana = sylvanas.MaxMana;
    sylvanas.IssueOrder(OrderId("darkconversion"), sylvanas.X - 340, sylvanas.Y + 300);
    After(2, () => Step(cheater, "Inspire Madness", () =>
    {
      var taken = victims.Count(x => x.Owner == cheater);
      Check(taken == 3, $"Sylvanas took control of {taken} of 3 enemies");
      foreach (var victim in victims)
      {
        victim.Kill();
      }
    }));
  }

  private static void TestRangerLord(player cheater)
  {
    var bansheesHost = cheater.GetPlayerData().Faction as BansheesHostFaction;
    var sylvanas = AllLegends.Quel.Sylvanas.Unit;
    if (bansheesHost == null || sylvanas == null)
    {
      return;
    }

    var stead = QuestRangerLord.MarrisStead.Center;
    sylvanas.SetPosition(stead.X, stead.Y);
    After(1.5f, () => Step(cheater, "The Ranger-Lord", () =>
    {
      var nathanos = GlobalGroup.EnumUnitsInRange(stead.X, stead.Y, 600)
        .FirstOrDefault(x => x.UnitType == UNIT_H049_RANGER_LORD_FORSAKEN && x.Owner == player.NeutralAggressive && x.Alive);
      Check(nathanos != null, "Wretched Nathanos rose at Marris Stead");
      if (nathanos == null)
      {
        return;
      }

      nathanos.Kill();
      Check(bansheesHost.GetQuestByType<QuestRangerLord>().Progress == QuestProgress.Complete, "the quest is complete");
      Check(GetPlayerTechMaxAllowed(cheater, UNIT_H049_RANGER_LORD_FORSAKEN) == 1, "Nathanos can be trained");
    }));
  }

  private static void TestBansheesVengeance(player cheater, Point arena)
  {
    var bansheesHost = cheater.GetPlayerData().Faction as BansheesHostFaction;
    var spire = AllLegends.Quel.Spire.Unit;
    var sylvanas = AllLegends.Quel.Sylvanas.Unit;
    if (bansheesHost == null || spire == null || sylvanas == null)
    {
      Log("[The Banshee's Vengeance]\n  SKIP Windrunner Spire or Sylvanas is missing");
      Finish(cheater);
      return;
    }

    spire.SetOwner(cheater);
    var channelSpot = Regions.WindrunnerSpireUnlock.Center;
    sylvanas.SetPosition(channelSpot.X, channelSpot.Y);
    After(5, () => Step(cheater, "The Banshee's Vengeance channel", () =>
      Check(bansheesHost.GetQuestByType<QuestBansheesVengeance>().Progress != QuestProgress.Complete,
        "the quest isn't complete while Sylvanas channels")));
    After(33, () => Step(cheater, "Dar'Khan", () =>
    {
      var darKhan = GlobalGroup.EnumUnitsInRange(channelSpot.X, channelSpot.Y, 900)
        .FirstOrDefault(x => x.UnitType == UNIT_H0CS_BETRAYER_OF_SILVERMOON_SUNFURY && x.Owner == player.NeutralAggressive && x.Alive);
      Check(darKhan != null, "Dar'Khan rose after the channel");
      if (darKhan != null)
      {
        darKhan.Kill();
      }
    }));
    After(35, () =>
    {
      Step(cheater, "The Banshee's Vengeance reward", () =>
      {
        Check(bansheesHost.GetQuestByType<QuestBansheesVengeance>().Progress == QuestProgress.Complete, "the quest is complete");
        var darkRanger = AllLegends.Quel.Sylvanas.Unit;
        Check(darkRanger != null && darkRanger.UnitType == UNIT_USYL_DARK_RANGER_FORSAKEN, "Sylvanas is a Dark Ranger");
        Check(darkRanger != null && darkRanger.GetAbilityLevel(ABILITY_A17R_BLACK_ARROW_FORSAKEN_SYLVANAS) == 1,
          "she has Black Arrow innately");
        foreach (var forsakenPath in bansheesHost.GetAllPaths().OfType<PathRiseOfTheForsaken>())
        {
          Check(forsakenPath.State == PathState.Available, $"{forsakenPath.Name} is now available ({forsakenPath.State})");
        }
      });
      var darkRangerUnit = AllLegends.Quel.Sylvanas.Unit;
      if (darkRangerUnit == null)
      {
        Finish(cheater);
        return;
      }

      darkRangerUnit.SetPosition(arena.X, arena.Y);
      PrepareHero(darkRangerUnit, ABILITY_A17U_SHADOW_STEP_FORSAKEN_SYLVANAS, ABILITY_A083_SILENCE_QUEL_THALAS_SYLVANAS_LEGION_MALGANIS,
        ABILITY_A17S_RANGER_GENERAL_S_FOCUS_FORSAKEN_SYLVANAS, ABILITY_A17T_WAILING_ARROW_FORSAKEN_SYLVANAS);
      TestRangerGeneralsFocus(cheater, darkRangerUnit);
      After(9, () => TestWailingArrow(cheater, darkRangerUnit));
      After(13, () => TestShadowStep(cheater, darkRangerUnit));
      After(16, () => TestRiseOfTheForsaken(cheater));
    });
  }

  private static void TestRangerGeneralsFocus(player cheater, unit sylvanas)
  {
    var target = CreateEnemy(sylvanas.X + 400, sylvanas.Y, 5000);
    var behind = CreateEnemy(sylvanas.X + 700, sylvanas.Y, 3000);
    var aside = CreateEnemy(sylvanas.X + 700, sylvanas.Y + 500, 3000);
    sylvanas.IssueOrder(ORDER_ATTACK, target);
    After(8, () => Step(cheater, "Ranger-General's Focus", () =>
    {
      Check(behind.Life < behind.MaxLife, $"an enemy behind the target was pierced ({(int)(behind.MaxLife - behind.Life)} damage)");
      Check(aside.Life >= aside.MaxLife, "an enemy off to the side wasn't");
      sylvanas.IssueOrder(ORDER_STOP);
      target.Kill();
      behind.Kill();
      aside.Kill();
    }));
  }

  private static void TestWailingArrow(player cheater, unit sylvanas)
  {
    var target = CreateEnemy(sylvanas.X + 600, sylvanas.Y, 3000);
    var nearby = CreateEnemy(sylvanas.X + 750, sylvanas.Y + 100, 3000);
    sylvanas.Mana = sylvanas.MaxMana;
    sylvanas.IssueOrder(OrderId("acidbomb"), target);
    After(1, () => Step(cheater, "Wailing Arrow first wail", () =>
    {
      var damage = target.MaxLife - target.Life;
      Check(damage >= 550 && damage <= 650, $"the target took {(int)damage} (expected 600: 400 arrow + 200 wail)");
      Check(nearby.GetAbilityLevel(_silenceBuffId) > 0, "a nearby enemy is silenced");
    }));
    After(2.5f, () => Step(cheater, "Wailing Arrow second wail", () =>
    {
      var damage = nearby.MaxLife - nearby.Life;
      Check(damage >= 350 && damage <= 450, $"a nearby enemy took {(int)damage} from both wails (expected 400)");
    }));
  }

  private static void TestShadowStep(player cheater, unit sylvanas)
  {
    sylvanas.Facing = 0;
    var startX = sylvanas.X;
    var startY = sylvanas.Y;
    var enemy = CreateEnemy(startX + 250, startY, 3000);
    sylvanas.Mana = sylvanas.MaxMana;
    sylvanas.IssueOrder(OrderId("roar"));
    After(1.5f, () => Step(cheater, "Shadow Step", () =>
    {
      var moved = startX - sylvanas.X;
      Check(moved >= 300 && moved <= 450, $"Sylvanas leapt {(int)moved} backwards (expected 400)");
      var damage = enemy.MaxLife - enemy.Life;
      Check(damage >= 120 && damage <= 140, $"the enemy in front took {(int)damage} from one arrow (expected 130)");
      enemy.Kill();
    }));
  }

  private static void TestRiseOfTheForsaken(player cheater)
  {
    var bansheesHost = cheater.GetPlayerData().Faction as BansheesHostFaction;
    var path = bansheesHost?.GetAllPaths().OfType<PathRiseOfTheForsakenScourge>().FirstOrDefault();
    if (path == null)
    {
      Log("[Rise of the Forsaken]\n  SKIP no Scourge-side Rise of the Forsaken path");
      Finish(cheater);
      return;
    }

    Step(cheater, "take Rise of the Forsaken", () =>
    {
      path.ForceAvailable();
      path.Accept(cheater);
    });
    After(35, () =>
    {
      Step(cheater, "after Rise of the Forsaken", () =>
      {
        var forsaken = cheater.GetPlayerData().Faction as ForsakenFaction;
        Check(forsaken != null, "you are now the Forsaken");
        if (forsaken == null)
        {
          return;
        }

        Check(HasQuest<QuestUndercity>(forsaken), "has The Undercity");
        var palace = AllLegends.Lordaeron.CapitalPalace.Unit;
        if (palace == null || !palace.Alive)
        {
          Log("  SKIP the Capital Palace is gone");
          return;
        }

        palace.SetOwner(cheater);
        Check(forsaken.GetQuestByType<QuestUndercity>().Progress == QuestProgress.Complete, "taking Capital City completes The Undercity");
        var undercity = GlobalGroup.EnumUnitsInRange(8384, 9216, 300)
          .Count(x => x.UnitType == UNIT_H08S_UNDERCITY_FORSAKEN && x.Owner == cheater);
        Check(undercity == 1, $"the Undercity was built ({undercity})");
      });
      Finish(cheater);
    });
  }

  private static void PrepareHero(unit hero, int first, int second, int third, int ultimate)
  {
    hero.SetLevel(10, false);
    foreach (var abilityId in new[] { first, second, third })
    {
      hero.AddAbility(abilityId);
      hero.SetAbilityLevel(abilityId, 4);
    }

    hero.AddAbility(ultimate);
    hero.SetAbilityLevel(ultimate, 3);
    hero.Mana = hero.MaxMana;
  }

  private static unit CreateEnemy(float x, float y, float life)
  {
    var enemy = unit.Create(player.NeutralAggressive, FourCC("hfoo"), x, y, 0);
    enemy.MaxLife = (int)life;
    enemy.Life = life;
    enemy.IsPaused = true;
    _testUnits.Add(enemy);
    return enemy;
  }

  private static unit CreateTestUnit(player owner, int unitTypeId, float x, float y)
  {
    var testUnit = unit.Create(owner, unitTypeId, x, y, 270);
    _testUnits.Add(testUnit);
    return testUnit;
  }

  private static unit? GetTestUnit(int unitTypeId) =>
    _testUnits.FirstOrDefault(x => x.UnitType == unitTypeId && x.Alive);

  private static List<Point> FindArenas(int count)
  {
    var found = new List<Point>();
    var bounds = GetWorldBounds();
    var minX = GetRectMinX(bounds) + 2000;
    var maxX = GetRectMaxX(bounds) - 2000;
    var minY = GetRectMinY(bounds) + 2000;
    var maxY = GetRectMaxY(bounds) - 2000;
    for (var x = minX; x < maxX && found.Count < count; x += 1000)
    {
      for (var y = minY; y < maxY && found.Count < count; y += 1000)
      {
        if (IsArena(x, y) && found.All(other => MathEx.GetDistanceBetweenPoints(other, new Point(x, y)) > ArenaSpacing))
        {
          found.Add(new Point(x, y));
        }
      }
    }

    return found;
  }

  private static bool IsArena(float x, float y)
  {
    for (var dx = -600; dx <= 600; dx += 300)
    {
      for (var dy = -600; dy <= 600; dy += 300)
      {
        if (IsTerrainPathable(x + dx, y + dy, PATHING_TYPE_WALKABILITY))
        {
          return false;
        }
      }
    }

    return !GlobalGroup.EnumUnitsInRange(x, y, ArenaClearRadius)
      .Any(other => other.Alive && other.Owner != player.NeutralPassive && other.IsSelectable());
  }

  private static List<unit> GetStructures(Rectangle area, player owner) =>
    GlobalGroup.EnumUnitsInRect(area)
      .Where(x => x.Alive && x.Owner == owner && x.IsUnitType(unittype.Structure))
      .ToList();

  private static ScourgeFaction? GetScourge() =>
    FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge) ? scourge : null;

  private static bool HasQuest<T>(Faction faction) where T : QuestData => faction.GetAllQuests().OfType<T>().Any();

  private static void Check(bool passed, string description)
  {
    if (passed)
    {
      _passed++;
    }
    else
    {
      _failed++;
    }

    Log($"  {(passed ? "PASS" : "FAIL")} {description}");
  }

  private static void Finish(player cheater)
  {
    foreach (var testUnit in _testUnits)
    {
      if (testUnit.Alive && testUnit.Owner == player.NeutralAggressive)
      {
        testUnit.Kill();
      }
    }

    Log($"[done] {_passed} passed, {_failed} failed");
    WriteReport(cheater);
    cheater.DisplayTextTo($"Banshee's Host test finished: {_passed} passed, {_failed} failed. Report in CustomMapData/{ReportPath}");
  }

  private static void Step(player cheater, string name, Action action)
  {
    Log($"[{name}]");
    try
    {
      action();
    }
    catch (Exception ex)
    {
      _failed++;
      Log($"  ERROR: {ex.Message}");
      cheater.DisplayTextTo($"|cffff0000Banshee's Host test error|r in {name}: {ex.Message}");
    }
  }

  private static void Log(string line) => _report.Add(line);

  private static void WriteReport(player cheater)
  {
    if (player.LocalPlayer != cheater)
    {
      return;
    }

    var report = string.Join("\n", _report);
    PreloadGenClear();
    PreloadGenStart();
    for (var offset = 0; offset < report.Length; offset += ReportChunkLength)
    {
      Preload(report.Substring(offset, Math.Min(ReportChunkLength, report.Length - offset)));
    }

    PreloadGenEnd(ReportPath);
  }

  private static void After(float delay, Action action)
  {
    var delayTimer = timer.Create();
    delayTimer.Start(delay, false, () =>
    {
      delayTimer.Dispose();
      action();
    });
  }
}
