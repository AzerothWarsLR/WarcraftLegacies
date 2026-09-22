using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MacroTools.Shared;
using War3Api.Object;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build;
using War3Net.CodeAnalysis.Jass.Extensions;
using Warcraft.Cartographer.Migrations;
using WarcraftLegacies.Shared;

namespace WarcraftLegacies.CLI.Migrations;

/// <summary>
/// Sets all unit tooltips in the game.
/// </summary>
public sealed class UnitTooltipExtendedMigration : IMapMigration
{
  private const string LineSeparator = "|n";
  private static string AbilitiesKnownTranslated =>
    "|cfff5962d" + BuildText.Translate("Abilities:|r ");
  private static string AbilitiesLearnableTranslated =>
    "|cfff5962d" + BuildText.Translate("Abilities (unlockable):|r ");
  private static string HeroAbilitiesKnownTranslated =>
    "|cfff5962d" + BuildText.Translate("Abilities (hero):|r ");
  private static string UnitsTrainedTranslated =>
    "|cfff5962d" + BuildText.Translate("Trains:|r ");
  private static string UnlockableUnitsTrainedTranslated =>
    "|cfff5962d" + BuildText.Translate("Trains (unlockable):|r ");
  private static string ResearchesAvailableTranslated =>
    "|cfff5962d" + BuildText.Translate("Researches:|r ");
  private static string UpgradesToTranslated =>
    "|cfff5962d" + BuildText.Translate("Upgrades to:|r ");
  private static string ItemsSoldTranslated =>
    "|cfff5962d" + BuildText.Translate("Sells items:|r ");
  private static string UnitsSoldTranslated =>
    "|cfff5962d" + BuildText.Translate("Sells units:|r ");
  private static string FoodProducedTranslated =>
    "|cfff5962d" + BuildText.Translate("Food produced:|r ");
  private const string RolePrefix = "|cff2fc6ba";

  private readonly ObjectInfoRepository _objectInfoRepository = new();

  /// <inheritdoc />
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {
    var units = objectDatabase.GetUnits();
    var copiedUnits = units.ToList();

    foreach (var unit in copiedUnits)
    {
      try
      {
        DetermineTooltip(unit);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to apply tooltip migration for {unit.TextName}: {ex}");
      }
    }

    var unitData = objectDatabase.GetAllData().UnitData;
    map.UnitObjectData = unitData;
    map.UnitSkinObjectData = unitData;
  }

  private void DetermineTooltip(Unit unit)
  {
    var tooltipBuilder = new StringBuilder();

    var unitId = (unit.NewId != 0 ? unit.NewId : unit.OldId).InvertEndianness();
    var hasObjectInfo = _objectInfoRepository.TryGetObjectInfo(unitId, out var objectInfo);

    if (hasObjectInfo && objectInfo.Categories.Count != 0)
    {
      AppendRoles(tooltipBuilder, unit, objectInfo);

      // A localised build ships the unit's description as translated map data, and it belongs in the tooltip
      // whether or not the map gives the unit a category: it is the line that says what the unit is for, and a
      // tooltip that opens on the category and then lists skills leaves it out. The category is a heading, so the
      // description follows it. A build from the base map data keeps the base behaviour, where the category
      // heading stands in for the description and only an uncategorised unit gets one.
      if (MapMigrationProvider.IsLocalized)
      {
        AppendObjectEditorTooltip(tooltipBuilder, unit);
      }
    }
    else
    {
      AppendObjectEditorTooltip(tooltipBuilder, unit);
    }

    AppendInnateUnitsTrained(tooltipBuilder, unit);
    AppendUnlockableUnitsTrained(tooltipBuilder, unit);
    AppendResearchesAvailable(tooltipBuilder, unit);
    AppendUpgradesTo(tooltipBuilder, unit);
    AppendInnateAbilities(tooltipBuilder, unit);
    AppendLearnedAbilities(tooltipBuilder, unit);
    AppendHeroAbilities(tooltipBuilder, unit);
    AppendSoldItems(tooltipBuilder, unit);
    AppendUnitsSold(tooltipBuilder, unit);
    AppendFoodProduced(tooltipBuilder, unit);

    if (hasObjectInfo)
    {
      AppendObjectLimit(tooltipBuilder, unit, objectInfo);
    }

    AppendTargetsAllowed(tooltipBuilder, unit);

    var extendedTooltip = tooltipBuilder.ToString();
    if (unit.TextTooltipExtended != extendedTooltip)
    {
      unit.TextTooltipExtended = extendedTooltip;
    }
  }

  private static void AppendRoles(StringBuilder tooltipBuilder, Unit unit, ObjectInfo objectInfo)
  {
    string suffix;
    if (unit.AbilitiesHero.Any())
    {
      suffix = " " + BuildText.Translate("Hero");
    }
    else if (unit.StatsIsABuilding)
    {
      suffix = "";
    }
    else if (objectInfo.Categories.Contains(UnitCategory.Elite))
    {
      suffix = " " + BuildText.Translate("Elite");
    }
    else
    {
      suffix = " " + BuildText.Translate("Unit");
    }

    tooltipBuilder.AppendLine($"{RolePrefix}{objectInfo.Categories.ToFriendlyString(BuildText.Translate)}{suffix}|r");
  }

  private static void AppendObjectEditorTooltip(StringBuilder tooltipBuilder, Unit unit)
  {
    // The base build takes the description straight from the object database and states the line even when it is
    // empty, so that a build from the base map data composes exactly what it always has.
    if (!MapMigrationProvider.IsLocalized)
    {
      tooltipBuilder.AppendLine(unit.TextTooltipExtended);
      return;
    }

    // The description the map data states for the unit. The object database does not carry it into this migration,
    // so the locale's build text supplies it, keyed on the unit's own id; the value the database does carry is used
    // when nothing is stated, so a build with no locale is unaffected.
    //
    // The id is the new one when the map gives the unit a record and the old one when it does not: a unit the map
    // leaves alone carries the stock id in OldId and a zero NewId.
    //
    // It is inverted the same way the object-info lookup above inverts it. The stored value reads four characters
    // backwards, so taking the bytes without inverting spells the id the wrong way round - "atcn" for "ncta" -
    // and every build-text key missed.
    var id = (unit.NewId != 0 ? unit.NewId : unit.OldId).InvertEndianness();
    var code = new string(new[]
    {
      (char)((id >> 24) & 0xFF), (char)((id >> 16) & 0xFF),
      (char)((id >> 8) & 0xFF), (char)(id & 0xFF),
    });
    var stated = BuildText.Translate("unit description:" + code);
    var description = stated.StartsWith("unit description:", StringComparison.Ordinal)
      ? unit.TextTooltipExtended
      : stated;

    // The description the build text states ends its own line, so appending it whole adds a line to the break that
    // separates it from the sections below - the tooltip reads a blank line taller than every other gap in it.
    // Trimmed here rather than in the data: the value is authored text, and the break belongs to the composition.
    description = description?.TrimEnd();

    if (!string.IsNullOrWhiteSpace(description))
    {
      tooltipBuilder.AppendLine(description);
    }
  }

  private static void AppendInnateAbilities(StringBuilder tooltipBuilder, Unit unit)
  {
    var innateAbilities = unit.AbilitiesNormal
      .Where(HasVisibleIcon)
      .Where(x => !x.TechtreeRequirements.Any())
      .OrderBy(GetPriority)
      .Select((x) => TranslateName(x.TextName))
      .ToArray();
    if (innateAbilities.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{AbilitiesKnownTranslated}{string.Join(", ", innateAbilities)}");
    }
  }

  private static void AppendLearnedAbilities(StringBuilder tooltipBuilder, Unit unit)
  {
    var learnableAbilities = unit.AbilitiesNormal
      .Where(HasVisibleIcon).Where(HasVisibleIcon)
      .Where(x => x.TechtreeRequirements.Any())
      .OrderBy(GetPriority)
      .Select(x => TranslateName(x.TextName))
      .ToArray();
    if (learnableAbilities.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{AbilitiesLearnableTranslated}{string.Join(", ", learnableAbilities)}");
    }
  }

  private static void AppendHeroAbilities(StringBuilder tooltipBuilder, Unit unit)
  {
    if (!unit.IsAbilitiesHeroModified)
    {
      return;
    }

    var heroAbilities = unit.AbilitiesHero
      .OrderBy(GetPriority)
      .Select((x) => TranslateName(x.TextName))
      .ToArray();

    if (heroAbilities.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{HeroAbilitiesKnownTranslated}{string.Join(", ", heroAbilities)}");
    }
  }

  private static void AppendUnitsSold(StringBuilder tooltipBuilder, Unit unit)
  {
    if (!unit.IsTechtreeUnitsSoldModified)
    {
      return;
    }

    var unitsSold = unit.TechtreeUnitsSold
      .OrderBy(GetPriority)
      .Select(x => TranslateName(x.TextName))
      .ToArray();

    if (unitsSold.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{UnitsSoldTranslated}{string.Join(", ", unitsSold)}");
    }
  }

  private static void AppendInnateUnitsTrained(StringBuilder tooltipBuilder, Unit unit)
  {
    var unitsTrained = unit.TechtreeUnitsTrained
      .Where(x => !x.TechtreeRequirements.Any(IsUpgrade))
      .OrderBy(GetPriority)
      .Select(GetBestName)
      .ToArray();

    if (unitsTrained.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{UnitsTrainedTranslated}{string.Join(", ", unitsTrained)}");
    }
  }

  private static void AppendUnlockableUnitsTrained(StringBuilder tooltipBuilder, Unit unit)
  {
    var unitsTrained = unit.TechtreeUnitsTrained
      .Where(x => x.TechtreeRequirements.Any(IsUpgrade))
      .OrderBy(GetPriority)
      .Select(GetBestName)
      .ToArray();

    if (unitsTrained.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{UnlockableUnitsTrainedTranslated}{string.Join(", ", unitsTrained)}");
    }
  }

  private static void AppendResearchesAvailable(StringBuilder tooltipBuilder, Unit unit)
  {
    var researchesAvailable = unit.TechtreeResearchesAvailable
      .OrderBy(GetPriority)
      .Select(GetTextName)
      .ToArray();

    if (researchesAvailable.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{ResearchesAvailableTranslated}{string.Join(", ", researchesAvailable)}");
    }
  }

  private static void AppendUpgradesTo(StringBuilder tooltipBuilder, Unit unit)
  {
    // The name goes through the same table the ability and unit lists use. A unit the map does not state at all has
    // no locale overlay, so its name is the game's own English - the corrupted night elf halls upgrade into a stock
    // `ncta`, and the line read `Upgrades to: Corrupted Tree of Ages` in an otherwise translated tooltip.
    var upgradesTo = unit.TechtreeUpgradesTo
      .OrderBy(GetPriority)
      .Select(x => TranslateName(x.TextName))
      .ToArray();

    if (upgradesTo.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{UpgradesToTranslated}{string.Join(", ", upgradesTo)}");
    }
  }

  private static void AppendSoldItems(StringBuilder tooltipBuilder, Unit unit)
  {
    // Translated the same way the upgrades list is: what a shop sells is named from the object database, and an item
    // the map does not name is the game's own English.
    var soldItems = GetTechtreeItemsSoldAndMade(unit)
      .OrderBy(GetPriority)
      .Select(x => TranslateName(x.TextName))
      .ToArray();

    if (soldItems.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{ItemsSoldTranslated}{string.Join(", ", soldItems)}");
    }
  }

  private void AppendObjectLimit(StringBuilder tooltipBuilder, Unit unit, ObjectInfo objectInfo)
  {
    if (unit.IsAbilitiesHeroModified && unit.AbilitiesHero.Any())
    {
      return;
    }

    var isABuilding = unit.StatsIsABuilding;
    var trainType = isABuilding ? "build" : "train";

    var limit = objectInfo.LimitTooltipOverride ?? objectInfo.Limit;

    if (limit is > 0 and < 200)
    {
      // The colour code is added around the translated sentence rather than inside the lookup key: build text is
      // keyed by the words a reader sees, and a key carrying Warcraft 3 text commands would never match one.
      var limitText = BuildText.Format("Can only " + trainType + " {n}.", limit.ToString());
      tooltipBuilder.Append(LineSeparator + "|cff99b4d1" + limitText + "|r");
      if (objectInfo.LimitIncreaseHint != null)
      {
        tooltipBuilder.Append($"|cff99b4d1 {BuildText.Format("This limit can be increased by {name}.", BuildText.Translate(objectInfo.LimitIncreaseHint))}|r");
      }
    }
  }

  private static void AppendTargetsAllowed(StringBuilder tooltipBuilder, Unit unit)
  {
    var targetsAllowed = GetAllTargetsAllowed(unit);

    if (targetsAllowed.Count == 0)
    {
      return;
    }

    // Two breaks separate one paragraph of the tooltip from the next, and the line before this section may already
    // end in one: `AppendLine` writes the role line and the description line, and a unit with no skill, research,
    // resource or limit line after them carries that break into this one. Writing `|n|n` unconditionally left every
    // such unit a blank line taller than the rest, which is what made a description-only unit read
    // `描述。|n|n|n|cffffcc00可攻击地面单位。|r`. A builder that already ends in a break takes a single `|n`.
    var endsWithBreak = tooltipBuilder.Length != 0 &&
      (tooltipBuilder[tooltipBuilder.Length - 1] == '\n' || tooltipBuilder[tooltipBuilder.Length - 1] == '\r');
    tooltipBuilder.Append(endsWithBreak ? LineSeparator : LineSeparator + LineSeparator);

    if (CanTargetGround(targetsAllowed))
    {
      tooltipBuilder.Append(CanTargetAir(targetsAllowed)
        ? $"|cffffcc00{BuildText.Translate("Attacks land and air units.")}|r"
        : $"|cffffcc00{BuildText.Translate("Attacks land units.")}|r");
    }
  }

  private static void AppendFoodProduced(StringBuilder tooltipBuilder, Unit unit)
  {
    if (unit.StatsFoodProduced == 0)
    {
      return;
    }

    tooltipBuilder.Append($"{LineSeparator}{FoodProducedTranslated}{unit.StatsFoodProduced}");
  }

  /// <summary>
  /// Gets the best name for a unit, preferring hero proper name over their text name.
  /// </summary>
  private static string GetBestName(Unit unit)
  {
    try
    {
      if (unit.TextProperNames.Any())
      {
        return unit.TextProperNames.First();
      }
    }
    catch
    {
      //do nothing
    }
    return unit.TextName;
  }

  /// <summary>
  /// The name a composed tooltip prints for a unit, ability, upgrade or item the map did not name itself.
  /// <para>
  /// The migration reads these names out of the object database, which holds the game's own English for anything the
  /// map leaves stock - Faerie Fire, Spiked Shell, Improved Lumber Harvesting - and no locale overlay exists for a
  /// record the map does not state at all. `BuildText.Translate` is the build's own table, keyed by the words a
  /// reader sees, so an entry here is what keeps a green ability line from ending in English. It returns its input
  /// unchanged for a name the table does not state and for a build with no locale, so the English map data composes
  /// exactly what it always has.
  /// </para>
  /// </summary>
  private static string TranslateName(string name) =>
    string.IsNullOrEmpty(name) ? name : BuildText.Translate(name);

  private static bool HasVisibleIcon(Ability ability)
  {
    if (ability.ArtButtonPositionNormalY == -11)
    {
      return false;
    }

    return ability is not (InventoryPackMule or Inventory2SlotUnitHuman or Inventory2SlotUnitOrc or Inventory2SlotUnitUndead
      or Inventory2SlotUnitNightElf or Invulnerable or DefenseBonus1 or Ultravision or SellItem or AlliedBuilding or
      PurchaseItem or LightningAttack or Inventory or AttributeModifierSkill or OrbOfCorruption or ReinforcedBurrows
      or SpikedBarricades or BlightDispelSmall or BlightDispelLarge or CargoHoldBurrow or CargoHoldDeath
      or CargoHoldDevour or CargoHoldShip or CargoHoldTank or CargoHoldTransport or CargoHoldGoldMine
      or CargoHoldMeatWagon or AuraRegenerationStatue or TreeOfLifeForAttachingArt or ChaosGrom or ChaosGrunt
      or ChaosPeon or ChaosKodo or ChaosRaider or ChaosShaman or ChaosCargoLoad or ReturnLumber or Warp);
  }

  /// <summary>
  /// Determines the order that abilities appear in tooltips.
  /// </summary>
  private static int GetPriority(Ability ability)
  {
    var (x, y) = (ability.ArtButtonPositionNormalX, ability.ArtButtonPositionNormalY);
    return x - y * 10;
  }

  private static int GetPriority(Item item)
  {
    try
    {
      var (x, y) = (item.ArtButtonPositionX, item.ArtButtonPositionY);
      return x - y * 10;
    }
    catch
    {
      return 0;
    }
  }

  private static bool CanTargetGround(List<Target> targets)
  {
    if (targets.Contains(Target.Ground))
    {
      return true;
    }

    return !targets.Contains(Target.Air);
  }

  private static bool CanTargetAir(List<Target> targets)
  {
    if (targets.Contains(Target.Air))
    {
      return true;
    }

    return !targets.Contains(Target.Ground);
  }

  private static bool IsUpgrade(Tech tech)
  {
    try
    {
      _ = tech.AsUpgrade;
      return true;
    }
    catch
    {
      return false;
    }
  }

  private static string GetTextName(Upgrade upgrade)
  {
    try
    {
      return TranslateName(upgrade.TextName[0]);
    }
    catch
    {
      try
      {
        return TranslateName(upgrade.TextName[1]);
      }
      catch
      {
        return "";
      }
    }
  }

  private static int GetPriority(Upgrade upgrade)
  {
    try
    {
      var (x, y) = (upgrade.ArtButtonPositionX, upgrade.ArtButtonPositionY);
      return x - y * 10;
    }
    catch
    {
      return 0;
    }
  }
  private static List<Target> GetAllTargetsAllowed(Unit unit)
  {
    List<Target> targetsAllowed = new();
    if (unit.CombatAttacksEnabledRaw is 1 or 3)
    {
      try
      {
        targetsAllowed.AddRange(unit.CombatAttack1TargetsAllowed);
      }
      catch
      {
        //do nothing
      }
    }
    if (unit.CombatAttacksEnabledRaw is 2 or 3)
    {
      try
      {
        targetsAllowed.AddRange(unit.CombatAttack2TargetsAllowed);
      }
      catch
      {
        //do nothing
      }
    }

    return targetsAllowed;
  }

  private static IEnumerable<Item> GetTechtreeItemsSoldAndMade(Unit unit)
  {
    var itemsSold = new List<Item>();
    itemsSold.AddRange(unit.TechtreeItemsSold);

    itemsSold.AddRange(unit.TechtreeItemsMade);

    return itemsSold;
  }

  private static int GetPriority(Unit unit)
  {
    var (x, y) = (unit.ArtButtonPositionX, unit.ArtButtonPositionY);
    return x + y * 10;
  }
}
