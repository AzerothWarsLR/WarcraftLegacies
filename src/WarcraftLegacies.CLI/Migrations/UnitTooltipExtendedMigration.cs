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
  private const string AbilitiesKnown = "|cfff5962dAbilities:|r ";
  private const string AbilitiesLearnable = "|cfff5962dAbilities (unlockable):|r ";
  private const string HeroAbilitiesKnown = "|cfff5962dAbilities (hero):|r ";
  private const string UnitsTrained = "|cfff5962dTrains:|r ";
  private const string UnlockableUnitsTrained = "|cfff5962dTrains (unlockable):|r ";
  private const string ResearchesAvailable = "|cfff5962dResearches:|r ";
  private const string UpgradesTo = "|cfff5962dUpgrades to:|r ";
  private const string ItemsSold = "|cfff5962dSells items:|r ";
  private const string UnitsSold = "|cfff5962dSells units:|r ";
  private const string FoodProduced = "|cfff5962dFood produced:|r ";
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
      suffix = " Hero";
    }
    else if (unit.StatsIsABuilding)
    {
      suffix = "";
    }
    else if (objectInfo.Categories.Contains(UnitCategory.Elite))
    {
      suffix = " Elite";
    }
    else
    {
      suffix = " Unit";
    }

    tooltipBuilder.AppendLine($"{RolePrefix}{objectInfo.Categories.ToFriendlyString()}{suffix}|r");
  }

  private static void AppendObjectEditorTooltip(StringBuilder tooltipBuilder, Unit unit)
  {
    tooltipBuilder.AppendLine(unit.TextTooltipExtended);
  }

  private static void AppendInnateAbilities(StringBuilder tooltipBuilder, Unit unit)
  {
    if (!unit.IsAbilitiesNormalModified)
    {
      return;
    }

    var innateAbilities = unit.AbilitiesNormal
      .Where(HasVisibleIcon)
      .Where(x => !x.TechtreeRequirements.Any())
      .OrderBy(GetPriority)
      .Select((x) => x.TextName)
      .ToArray();
    if (innateAbilities.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{AbilitiesKnown}{string.Join(", ", innateAbilities)}");
    }
  }

  private static void AppendLearnedAbilities(StringBuilder tooltipBuilder, Unit unit)
  {
    if (!unit.IsAbilitiesNormalModified)
    {
      return;
    }

    var learnableAbilities = unit.AbilitiesNormal
      .Where(HasVisibleIcon).Where(HasVisibleIcon)
      .Where(x => x.TechtreeRequirements.Any())
      .OrderBy(GetPriority)
      .Select(x => x.TextName)
      .ToArray();
    if (learnableAbilities.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{AbilitiesLearnable}{string.Join(", ", learnableAbilities)}");
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
      .Select((x) => x.TextName)
      .ToArray();

    if (heroAbilities.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{HeroAbilitiesKnown}{string.Join(", ", heroAbilities)}");
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
      .Select(x => x.TextName)
      .ToArray();

    if (unitsSold.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{UnitsSold}{string.Join(", ", unitsSold)}");
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
      tooltipBuilder.Append($"{LineSeparator}{UnitsTrained}{string.Join(", ", unitsTrained)}");
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
      tooltipBuilder.Append($"{LineSeparator}{UnlockableUnitsTrained}{string.Join(", ", unitsTrained)}");
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
      tooltipBuilder.Append($"{LineSeparator}{ResearchesAvailable}{string.Join(", ", researchesAvailable)}");
    }
  }

  private static void AppendUpgradesTo(StringBuilder tooltipBuilder, Unit unit)
  {
    var upgradesTo = unit.TechtreeUpgradesTo
      .OrderBy(GetPriority)
      .Select(x => x.TextName)
      .ToArray();

    if (upgradesTo.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{UpgradesTo}{string.Join(", ", upgradesTo)}");
    }
  }

  private static void AppendSoldItems(StringBuilder tooltipBuilder, Unit unit)
  {
    var soldItems = GetTechtreeItemsSoldAndMade(unit)
      .OrderBy(GetPriority)
      .Select(x => x.TextName)
      .ToArray();

    if (soldItems.Length != 0)
    {
      tooltipBuilder.Append($"{LineSeparator}{ItemsSold}{string.Join(", ", soldItems)}");
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
      tooltipBuilder.Append($"{LineSeparator}|cff99b4d1Can only {trainType} {limit}.|r");
      if (objectInfo.LimitIncreaseHint != null)
      {
        tooltipBuilder.Append($"|cff99b4d1 This limit can be increased by {objectInfo.LimitIncreaseHint}.|r");
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

    tooltipBuilder.Append(LineSeparator + LineSeparator);

    if (CanTargetGround(targetsAllowed))
    {
      tooltipBuilder.Append(CanTargetAir(targetsAllowed)
        ? "|cffffcc00Attacks land and air units.|r"
        : "|cffffcc00Attacks land units.|r");
    }
  }

  private static void AppendFoodProduced(StringBuilder tooltipBuilder, Unit unit)
  {
    if (unit.StatsFoodProduced == 0)
    {
      return;
    }

    tooltipBuilder.Append($"{LineSeparator}{FoodProduced}{unit.StatsFoodProduced}");
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
      or ChaosPeon or ChaosKodo or ChaosRaider or ChaosShaman or ChaosCargoLoad or ReturnLumber);
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
      return upgrade.TextName[0];
    }
    catch
    {
      try
      {
        return upgrade.TextName[1];
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
