using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Commands;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.FallenPrince.Quests;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Factions.Lordaeron.Paths;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Factions.Scourge.Powers;
using WarcraftLegacies.Source.Factions.Scourge.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Takes the Fallen Prince path, completes its quests, casts the captains' and Fallen Priest's abilities on test
/// targets, and writes what happened to a file.
/// </summary>
public sealed class CheatTestFallenPrince : Command
{
  private const string ReportPath = @"WarcraftLegacies-fallenprince-report.pld";
  private const int ReportChunkLength = 200;
  private const float ArenaClearRadius = 1600;
  private const float ArenaSpacing = 3000;
  private const int TestArthasExperience = 5000;

  private static readonly List<string> _report = new();
  private static readonly List<unit> _testUnits = new();
  private static int _passed;
  private static int _failed;
  private static int _scourgeArthasExperience;

  private static readonly int[] _coastStructureTypes =
  {
    UNIT_UNPL_NECROPOLIS_SCOURGE_T1, UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, UNIT_USEP_CRYPT_SCOURGE_BARRACKS,
    UNIT_UBON_BONEYARD_SCOURGE_SIEGE, UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC,
    UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER
  };

  /// <inheritdoc />
  public override string CommandText => "testfp";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    "Takes The Fallen Prince, completes its quests, tests the new abilities, and writes a report to CustomMapData.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var lordaeron = cheater.GetPlayerData().Faction as LordaeronFaction;
    if (!RoleplaySetting.IsActive || lordaeron == null)
    {
      return "Play Lordaeron in Roleplay mode to run this.";
    }

    var path = lordaeron.GetAllPaths().OfType<PathFallenPrince>().FirstOrDefault();
    if (path == null)
    {
      return "Lordaeron has no Fallen Prince path.";
    }

    _report.Clear();
    _testUnits.Clear();
    _passed = 0;
    _failed = 0;
    Step(cheater, "before the path", () => PrepareScourge());
    Step(cheater, "take the path", () =>
    {
      KillStratholmeAndArthas();
      path.ForceAvailable();
      path.Accept(cheater);
      Log($"  path state: {path.State}");
    });

    After(35, () =>
    {
      Step(cheater, "after the path", () => CheckPath(cheater));
      Step(cheater, "quests", () => CompleteQuests(cheater));
      After(2, () => RunAbilityTests(cheater));
    });

    return "Fallen Prince test started, it takes about 2 minutes. Don't touch anything until it says it's finished.";
  }

  private static void PrepareScourge()
  {
    var scourge = GetScourge();
    var scourgePlayer = scourge?.Player;
    if (scourge == null || scourgePlayer == null)
    {
      Log("  SKIP no Scourge player: the coast base takeover and taking Arthas from the Scourge aren't tested");
      return;
    }

    var plague = scourge.GetAllQuests().OfType<QuestPlague>().FirstOrDefault();
    if (plague != null && plague.Progress != QuestProgress.Complete)
    {
      plague.Progress = QuestProgress.Complete;
      Log("  completed the Plague so the Scourge holds the coast base");
    }

    var killed = new List<string>();
    foreach (var structure in GetCoastStructures(scourgePlayer))
    {
      if (structure.UnitType == UNIT_UBON_BONEYARD_SCOURGE_SIEGE && !killed.Contains("Boneyard") ||
          structure.UnitType == UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER && !killed.Contains("Spirit Tower"))
      {
        killed.Add(structure.UnitType == UNIT_UBON_BONEYARD_SCOURGE_SIEGE ? "Boneyard" : "Spirit Tower");
        structure.Kill();
      }
    }

    Log($"  destroyed on the coast so they must be rebuilt: {string.Join(", ", killed)}");

    var arthas = AllLegends.Scourge.Arthas;
    arthas.ForceCreate(scourgePlayer, Regions.StratholmeScourgeBase.Center, 270);
    var arthasUnit = arthas.Unit;
    if (arthasUnit != null)
    {
      arthasUnit.SetExperience(TestArthasExperience, false);
      _scourgeArthasExperience = arthasUnit.Experience;
      Log($"  gave the Scourge Arthas with {_scourgeArthasExperience} experience");
    }
  }

  private static void KillStratholmeAndArthas()
  {
    var stratholme = AllLegends.Lordaeron.Stratholme.Unit;
    if (stratholme != null && stratholme.Alive)
    {
      stratholme.Kill();
    }

    AllLegends.Lordaeron.Arthas.PermanentlyKill();
  }

  private static void CheckPath(player cheater)
  {
    var faction = cheater.GetPlayerData().Faction;
    Check(faction is FallenPrinceFaction, "you are now the Fallen Prince");
    var fallenPrince = faction as FallenPrinceFaction;
    if (fallenPrince == null)
    {
      return;
    }

    var arthas = AllLegends.Scourge.Arthas.Unit;
    Check(arthas != null && arthas.Owner == cheater, "Arthas belongs to the Fallen Prince");
    var scourge = GetScourge();
    if (_scourgeArthasExperience > 0 && arthas != null)
    {
      Check(arthas.Experience >= _scourgeArthasExperience,
        $"Arthas kept his experience ({arthas.Experience}, had {_scourgeArthasExperience})");
    }

    if (scourge != null)
    {
      Check(scourge.GetObjectLimit(UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE) == 0, "the Scourge can no longer train Arthas");
      Check(!scourge.GetAllQuests().OfType<QuestLichKingArthas>().Any(), "the Scourge no longer has The Ascension");
    }

    foreach (var structureType in _coastStructureTypes)
    {
      var expected = structureType == UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER ? 2 : 1;
      var count = GetCoastStructures(cheater).Count(x => x.UnitType == structureType);
      Check(count == expected, $"coast base has {count} {GetObjectName(structureType)} (expected {expected})");
    }

    var others = GlobalGroup.EnumUnitsInRect(Regions.StratholmeScourgeBase)
      .Count(x => x.Alive && x.IsUnitType(unittype.Structure) && x.Owner != cheater && !x.IsControlPoint());
    Check(others == 0, $"no other structures left on the coast ({others})");

    Check(HasQuest<QuestThroneOfLordaeron>(fallenPrince), "has The Throne of Lordaeron");
    Check(HasQuest<QuestStratholmeRisen>(fallenPrince), "has The Culled Rise");
    Check(HasQuest<QuestKeyOfTheThreeMoons>(fallenPrince), "has The Key of the Three Moons");
    Check(HasQuest<QuestLichKingArthas>(fallenPrince), "has The Ascension");
    if (FactionManager.TryGetFactionByType<LegionFaction>(out var legion))
    {
      var summoned = legion.GetAllQuests().OfType<QuestSummonLegion>().Any(x => x.Progress == QuestProgress.Complete);
      Check(summoned || HasQuest<QuestHeraldOfArchimonde>(fallenPrince), "has Herald of Archimonde");
    }
  }

  private static void CompleteQuests(player cheater)
  {
    var fallenPrince = cheater.GetPlayerData().Faction as FallenPrinceFaction;
    if (fallenPrince == null)
    {
      return;
    }

    fallenPrince.GetQuestByType<QuestThroneOfLordaeron>().Progress = QuestProgress.Complete;
    var falric = fallenPrince.Falric.Unit;
    Check(falric != null && falric.Owner == cheater, "Captain Falric joined after The Throne of Lordaeron");
    if (falric != null)
    {
      Check(GetHeroProperName(falric) == "Captain Falric", $"Falric's name is {GetHeroProperName(falric)}");
    }

    fallenPrince.GetQuestByType<QuestStratholmeRisen>().Progress = QuestProgress.Complete;
    Check(GetPlayerTechCount(cheater, UPGRADE_R105_QUEST_COMPLETED_THE_CULLED_RISE_FALLENPRINCE, true) == 1,
      "The Culled Rise unlocked Captain Marwyn");
  }

  private static void RunAbilityTests(player cheater)
  {
    var fallenPrince = cheater.GetPlayerData().Faction as FallenPrinceFaction;
    if (fallenPrince == null)
    {
      Finish(cheater);
      return;
    }

    var arenas = FindArenas(3);
    Log($"[arenas] found {arenas.Count}: {string.Join(" / ", arenas.Select(x => $"{(int)x.X},{(int)x.Y}"))}");
    if (arenas.Count < 3)
    {
      Check(false, "found three empty spots to test abilities in");
      Finish(cheater);
      return;
    }

    var falric = fallenPrince.Falric.Unit;
    fallenPrince.Marwyn.ForceCreate(cheater, arenas[1], 270);
    var marwyn = fallenPrince.Marwyn.Unit;
    if (falric == null || marwyn == null)
    {
      Check(false, "both captains exist");
      Finish(cheater);
      return;
    }

    Step(cheater, "captain kits", () =>
    {
      falric.SetPosition(arenas[0].X, arenas[0].Y);
      PrepareHero(falric, ABILITY_A175_GRIM_TOLL_FALLENPRINCE_FALRIC, ABILITY_A176_DEATHGUARD_S_BULWARK_FALLENPRINCE_FALRIC,
        ABILITY_A178_SHIELD_CHARGE_FALLENPRINCE_FALRIC, ABILITY_A17A_DEFILING_HORROR_FALLENPRINCE_FALRIC);
      PrepareHero(marwyn, ABILITY_A17D_SHARED_SUFFERING_FALLENPRINCE_MARWYN, ABILITY_A17G_SOUL_ECHO_FALLENPRINCE_MARWYN,
        ABILITY_A17F_WARD_OF_CORRUPTION_FALLENPRINCE_MARWYN, ABILITY_A17H_SOUL_REND_FALLENPRINCE_MARWYN);
      Check(GetHeroProperName(marwyn) == "Captain Marwyn", $"Marwyn's name is {GetHeroProperName(marwyn)}");
      foreach (var captain in new[] { falric, marwyn })
      {
        var name = GetHeroProperName(captain);
        Check(captain.GetAbilityLevel(ABILITY_A17I_DEATH_PACT_FALLENPRINCE) > 0, $"{name} has Death Pact");
        Check(captain.GetAbilityLevel(ABILITY_A0LR_ASCEND_ARTHAS) == 0, $"{name} doesn't have Ascend");
        Check(captain.GetAbilityLevel(ABILITY_A08V_FROSTMOURNE_GLOW_ATTACHMENT) == 0, $"{name} doesn't have Frostmourne Glow");
      }
    });

    TestGrimToll(cheater, falric);
    After(3, () => TestShieldCharge(cheater, falric));
    After(6, () => TestDefilingHorror(cheater, falric));
    After(9, () => TestBulwark(cheater, falric, arenas[1]));
    After(12, () => TestDeathPact(cheater, falric));
    After(15, () => TestSharedSufferingAndSoulEcho(cheater, marwyn));
    After(19, () => TestWardOfCorruption(cheater, marwyn));
    After(22, () => TestSoulRend(cheater, marwyn));
    After(26, () => TestFallenPriest(cheater, arenas[2]));
    After(36, () => TestKeyOfTheThreeMoons(cheater, fallenPrince));
    After(39, () => TestAscension(cheater));
    After(46, () => Finish(cheater));
  }

  private static void TestGrimToll(player cheater, unit falric)
  {
    var target = CreateEnemy(falric.X + 150, falric.Y, 3000);
    target.Life = 1500;
    falric.Mana = falric.MaxMana;
    falric.IssueOrder(OrderId("faeriefire"), target);
    After(1.5f, () => Step(cheater, "Grim Toll", () =>
    {
      var damage = 1500 - target.Life;
      Check(damage >= 400 && damage <= 650, $"Grim Toll dealt {(int)damage} (expected about 525: 225 plus 20% of 1500 missing)");
    }));
  }

  private static void TestShieldCharge(player cheater, unit falric)
  {
    var target = CreateEnemy(falric.X + 600, falric.Y, 3000);
    falric.Mana = falric.MaxMana;
    falric.IssueOrder(OrderId("berserk"), target);
    After(1.0f, () => Step(cheater, "Shield Charge", () =>
    {
      var distance = MathEx.GetDistanceBetweenPoints(falric.GetPosition(), target.GetPosition());
      Check(distance < 300, $"Falric charged to the target ({(int)distance} away)");
      Check(target.GetAbilityLevel(FourCC("BPSE")) > 0, "the target is stunned");
      var damage = target.MaxLife - target.Life;
      Check(damage >= 180 && damage <= 300, $"Shield Charge dealt {(int)damage} (expected about 225)");
    }));
  }

  private static void TestDefilingHorror(player cheater, unit falric)
  {
    var first = CreateEnemy(falric.X + 250, falric.Y + 100, 3000);
    var second = CreateEnemy(falric.X - 250, falric.Y - 100, 3000);
    falric.Mana = falric.MaxMana;
    falric.IssueOrder(OrderId("howlofterror"));
    After(0.6f, () => Step(cheater, "Defiling Horror", () =>
    {
      foreach (var enemy in new[] { first, second })
      {
        Check(enemy.GetAbilityLevel(BUFF_B105_DEFILING_HORROR) > 0, "a nearby enemy is feared");
        Check(enemy.GetAbilityLevel(BUFF_B106_DEFILED) > 0, "a nearby enemy is Defiled");
      }
    }));
  }

  private static void TestBulwark(player cheater, unit falric, Point farAway)
  {
    var guarded = CreateTestUnit(cheater, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, falric.X, falric.Y - 400);
    var unguarded = CreateTestUnit(cheater, UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, farAway.X, farAway.Y - 800);
    var attacker = CreateEnemy(falric.X, falric.Y - 700, 3000);
    After(1.5f, () => Step(cheater, "Deathguard's Bulwark", () =>
    {
      Check(guarded.GetAbilityLevel(BUFF_B104_DEATHGUARD_S_BULWARK) > 0, "a nearby friendly unit has the Bulwark buff");
      Check(unguarded.GetAbilityLevel(BUFF_B104_DEATHGUARD_S_BULWARK) == 0, "a far away unit doesn't");
      var guardedBefore = guarded.Life;
      var unguardedBefore = unguarded.Life;
      attacker.DealDamage(guarded, 200, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      attacker.DealDamage(unguarded, 200, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      var guardedLoss = guardedBefore - guarded.Life;
      var unguardedLoss = unguardedBefore - unguarded.Life;
      var ratio = unguardedLoss > 0 ? guardedLoss / unguardedLoss : 0;
      Check(ratio > 0.87f && ratio < 0.93f,
        $"spell damage taken inside the aura is {(int)(ratio * 100)}% of outside (expected 90%: {(int)guardedLoss} vs {(int)unguardedLoss})");
    }));
  }

  private static void TestDeathPact(player cheater, unit falric)
  {
    var ghoul = CreateTestUnit(cheater, UNIT_UGHO_GHOUL_SCOURGE, falric.X + 150, falric.Y + 150);
    falric.Life = falric.MaxLife * 0.5f;
    var lifeBefore = falric.Life;
    falric.Mana = falric.MaxMana;
    falric.IssueOrder(OrderId("darkconversion"), ghoul);
    After(2, () => Step(cheater, "Death Pact", () =>
    {
      Check(!ghoul.Alive, "the ghoul was sacrificed");
      Check(falric.Life > lifeBefore, $"Falric was healed ({(int)lifeBefore} to {(int)falric.Life})");
    }));
  }

  private static void TestSharedSufferingAndSoulEcho(player cheater, unit marwyn)
  {
    var target = CreateEnemy(marwyn.X + 300, marwyn.Y, 3000);
    var bystanders = new List<unit>();
    for (var i = 0; i < 4; i++)
    {
      var angle = 1.2f + i * 1.1f;
      bystanders.Add(CreateEnemy(marwyn.X + 400 * Cos(angle), marwyn.Y + 400 * Sin(angle), 3000));
    }

    marwyn.Mana = marwyn.MaxMana;
    marwyn.IssueOrder(OrderId("curse"), target);
    After(2, () => Step(cheater, "Shared Suffering and Soul Echo", () =>
    {
      Check(target.GetAbilityLevel(BUFF_B107_SHARED_SUFFERING) > 0, "the target is cursed by Shared Suffering");
      Check(target.Life < target.MaxLife, "the curse is dealing damage");
      var struck = bystanders.Count(x => x.Life < x.MaxLife);
      Check(struck >= 2 && struck <= 3, $"Soul Echo bolts struck {struck} of 4 bystanders (expected 2 or 3, the third bolt can hit the target)");
      foreach (var bystander in bystanders)
      {
        bystander.Kill();
      }

      target.Kill();
    }));
  }

  private static void TestWardOfCorruption(player cheater, unit marwyn)
  {
    marwyn.Mana = marwyn.MaxMana;
    marwyn.IssueOrder(OrderId("healingward"), marwyn.X, marwyn.Y + 300);
    After(1.5f, () => Step(cheater, "Ward of Corruption", () =>
    {
      var wards = GlobalGroup.EnumUnitsInRange(marwyn.X, marwyn.Y, 800)
        .Count(x => x.UnitType == UNIT_U108_WARD_OF_CORRUPTION_FALLENPRINCE && x.Owner == cheater && x.Alive);
      Check(wards == 1, $"a Ward of Corruption was summoned ({wards})");
    }));
  }

  private static void TestSoulRend(player cheater, unit marwyn)
  {
    var centerX = marwyn.X;
    var centerY = marwyn.Y - 500;
    var victims = new List<unit>();
    for (var i = 0; i < 3; i++)
    {
      var victim = CreateEnemy(centerX + 120 * Cos(i * 2.1f), centerY + 120 * Sin(i * 2.1f), 3000);
      victim.Life = 50;
      victims.Add(victim);
    }

    var survivor = CreateEnemy(centerX + 450, centerY - 150, 3000);
    marwyn.Mana = marwyn.MaxMana;
    marwyn.IssueOrder(OrderId("deathanddecay"), centerX, centerY);
    After(2.5f, () => Step(cheater, "Soul Rend", () =>
    {
      var dead = victims.Count(x => !x.Alive);
      Check(dead == 3, $"Soul Rend killed the weakened enemies in the area ({dead} of 3)");
      Check(survivor.Life < survivor.MaxLife, $"a released soul struck the enemy outside the area ({(int)(survivor.MaxLife - survivor.Life)} damage)");
    }));
  }

  private static void TestFallenPriest(player cheater, Point arena)
  {
    var priest = CreateTestUnit(cheater, UNIT_U107_FALLEN_PRIEST_FALLENPRINCE, arena.X, arena.Y);
    var cursed = CreateEnemy(arena.X + 300, arena.Y, 3000);
    var bolted = CreateEnemy(arena.X - 300, arena.Y, 3000);
    priest.Mana = priest.MaxMana;
    priest.IssueOrder(OrderId("firebolt"), bolted);
    After(1.5f, () =>
    {
      Step(cheater, "Shadow Bolt", () =>
        Check(bolted.Life < bolted.MaxLife, $"Shadow Bolt dealt {(int)(bolted.MaxLife - bolted.Life)} (expected about 60)"));
      priest.Mana = priest.MaxMana;
      priest.Life = priest.MaxLife;
      priest.IssueOrder(OrderId("cripple"), cursed);
    });
    After(2.5f, () => Step(cheater, "Shadow Word: Death applied", () =>
      Check(cursed.GetAbilityLevel(BUFF_B103_SHADOW_WORD_DEATH) > 0, "the target has Shadow Word: Death")));
    After(9.5f, () => Step(cheater, "Shadow Word: Death backlash", () =>
    {
      var lost = 1 - priest.Life / priest.MaxLife;
      Check(lost > 0.12f && lost < 0.18f, $"the priest lost {(int)(lost * 100)}% of its health when the target survived (expected 15%)");
    }));

    Step(cheater, "Plague Arrows data", () =>
    {
      var archer = CreateTestUnit(cheater, UNIT_U103_RISEN_ARCHER_FALLENPRINCE, arena.X, arena.Y + 400);
      var plagueArrows = BlzGetUnitAbility(archer, ABILITY_A16Y_PLAGUE_ARROWS_FALLENPRINCE_RISEN_ARCHER);
      var duration = BlzGetAbilityRealLevelField(plagueArrows, ConvertAbilityRealLevelField(FourCC("Nba3")), 0);
      var count = BlzGetAbilityIntegerLevelField(plagueArrows, ConvertAbilityIntegerLevelField(FourCC("Nba2")), 0);
      Check((int)duration == 60, $"Plague Arrows ghouls last {(int)duration} seconds (expected 60)");
      Check(count == 1, $"Plague Arrows raises {count} ghoul (expected 1)");
    });
  }

  private static void TestKeyOfTheThreeMoons(player cheater, FallenPrinceFaction fallenPrince)
  {
    var sunwell = AllLegends.Quel.Sunwell.Unit;
    var arthas = AllLegends.Scourge.Arthas.Unit;
    if (sunwell == null || !sunwell.Alive || arthas == null)
    {
      Log("[Key of the Three Moons]\n  SKIP the Sunwell or Arthas is missing");
      return;
    }

    sunwell.SetOwner(cheater);
    arthas.SetPosition(Regions.Sunwell.Center.X, Regions.Sunwell.Center.Y);
    After(1.5f, () => Step(cheater, "Key of the Three Moons", () =>
    {
      Check(fallenPrince.GetQuestByType<QuestKeyOfTheThreeMoons>().Progress == QuestProgress.Complete, "the quest is complete");
      Check(GetPlayerTechCount(cheater, UPGRADE_R107_QUEST_COMPLETED_THE_KEY_OF_THE_THREE_MOONS_FALLENPRINCE, true) == 1,
        "its research is done");
      Check(GetPlayerTechMaxAllowed(cheater, UNIT_UBON_BONEYARD_SCOURGE_SIEGE) != 0, "Boneyards can be built");
      Check(GetPlayerTechMaxAllowed(cheater, UNIT_UBSP_OBSIDIAN_DESTROYER_SCOURGE) == 4, "up to 4 Obsidian Destroyers");
      var scourgePlayer = GetScourge()?.Player;
      if (scourgePlayer != null)
      {
        Check(GetPlayerTechCount(scourgePlayer, UPGRADE_R107_QUEST_COMPLETED_THE_KEY_OF_THE_THREE_MOONS_FALLENPRINCE, true) == 1,
          "the Scourge still has its Boneyard requirement met");
      }
    }));
  }

  private static void TestAscension(player cheater)
  {
    var arthas = AllLegends.Scourge.Arthas.Unit;
    var throne = AllLegends.Scourge.TheFrozenThrone.Unit;
    if (arthas == null || throne == null)
    {
      Log("[The Ascension]\n  SKIP Arthas or the Frozen Throne is missing");
      return;
    }

    var throneOwner = throne.Owner;
    arthas.SetLevel(12, false);
    arthas.SetPosition(throne.X - 350, throne.Y - 350);
    arthas.IssueOrder(OrderId("farsight"), throne);
    After(5, () => Step(cheater, "The Ascension", () =>
    {
      var lichKing = AllLegends.Scourge.Arthas.Unit;
      Check(lichKing != null && lichKing.UnitType == UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE, "Arthas became the Lich King");
      Check(throne.Owner == throneOwner, $"the Frozen Throne stayed with {throneOwner.Name} (now {throne.Owner.Name})");
      var scourge = GetScourge();
      if (scourge != null)
      {
        Check(scourge.GetPowerByType<Domination>() != null, "the Scourge has Domination");
      }

      var utgarde = AllLegends.Scourge.Utgarde.Unit;
      Check(utgarde != null && utgarde.Owner == cheater, "Utgarde Keep went to the Fallen Prince");
    }));
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

  private static List<Point> FindArenas(int count)
  {
    var found = new List<Point>();
    var bounds = GetWorldBounds();
    var minX = GetRectMinX(bounds) + 2000;
    var maxX = GetRectMaxX(bounds) - 2000;
    var minY = GetRectMinY(bounds) + 2000;
    var maxY = GetRectMaxY(bounds) - 2000;
    for (var x = minX; x < maxX && found.Count < count; x += 1500)
    {
      for (var y = minY; y < maxY && found.Count < count; y += 1500)
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
    for (var dx = -800; dx <= 800; dx += 400)
    {
      for (var dy = -800; dy <= 800; dy += 400)
      {
        if (IsTerrainPathable(x + dx, y + dy, PATHING_TYPE_WALKABILITY))
        {
          return false;
        }
      }
    }

    return GlobalGroup.EnumUnitsInRange(x, y, ArenaClearRadius).Count == 0;
  }

  private static List<unit> GetCoastStructures(player owner) =>
    GlobalGroup.EnumUnitsInRect(Regions.StratholmeScourgeBase)
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
    cheater.DisplayTextTo($"Fallen Prince test finished: {_passed} passed, {_failed} failed. Report in CustomMapData/{ReportPath}");
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
      cheater.DisplayTextTo($"|cffff0000Fallen Prince test error|r in {name}: {ex.Message}");
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
