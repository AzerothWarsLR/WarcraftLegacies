using System;
using System.Linq;
using System.Text;
using Launcher.Extensions;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  /// <summary>
  /// Sets all unit tooltips in the game.
  /// </summary>
  public sealed class UnitTooltipMigration : IMapMigration
  {
    private const string LineSeperator = "|n";
    private const string AbilitiesKnown = "|cfff5962dAbilities:|r ";
    private const string AbilitiesLearnable = "|cfff5962dResearchable abilities:|r ";
    private const string HeroAbilitiesKnown = "|cfff5962dHero abilities:|r ";

    /// <inheritdoc />
    public void Migrate(Map map, ObjectDatabase objectDatabase)
    {
      var units = objectDatabase.GetUnits();
      var copiedUnits = units.ToList();
      foreach (var unit in copiedUnits)
      {
        DetermineTooltip(unit);
      }

      var unitData = objectDatabase.GetAllData().UnitData;
      map.UnitObjectData = unitData;
      map.UnitSkinObjectData = unitData;
    }

    private static void DetermineTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      if (unit.IsTextNameModified)
      {
        Console.WriteLine($"Modifying {unit.TextName}...");
      }
      else
      {
        return;
      }

      AppendFlavour(tooltipBuilder, unit);
      AppendInnateAbilities(tooltipBuilder, unit);
      AppendLearnedAbilities(tooltipBuilder, unit);
      AppendHeroAbilities(tooltipBuilder, unit);

      var extendedTooltip = tooltipBuilder.ToString();
      Console.WriteLine(extendedTooltip);
      unit.TextTooltipExtended = extendedTooltip;
    }

    private static void AppendInnateAbilities(StringBuilder tooltipBuilder, Unit unit)
    {
      if (!unit.IsAbilitiesNormalModified) return;
      var innateAbilities = unit.AbilitiesNormal
        .Where(x => !x.GetTechtreeRequirementsSafe().Any())
        .OrderBy(AbilityExtensions.GetPrioritySafe)
        .Select(AbilityExtensions.GetNameSafe)
        .ToArray();
      if (innateAbilities.Any())
      {
        tooltipBuilder.Append($"{LineSeperator}{AbilitiesKnown}{string.Join(", ", innateAbilities)}");
      }
    }
    
    private static void AppendLearnedAbilities(StringBuilder tooltipBuilder, Unit unit)
    {
      if (!unit.IsAbilitiesNormalModified) return;
      var learnableAbilities = unit.AbilitiesNormal
        .Where(x => x.GetTechtreeRequirementsSafe().Any())
        .OrderBy(AbilityExtensions.GetPrioritySafe)
        .Select(AbilityExtensions.GetNameSafe)
        .ToArray();
      if (learnableAbilities.Any())
      {
        tooltipBuilder.Append($"{LineSeperator}{AbilitiesLearnable}{string.Join(", ", learnableAbilities)}");
      }
    }

    private static void AppendHeroAbilities(StringBuilder tooltipBuilder, Unit unit)
    {
      if (!unit.IsAbilitiesHeroModified) return;
      var heroAbilities = unit.AbilitiesHero.OrderBy(AbilityExtensions.GetPrioritySafe).Select(AbilityExtensions.GetNameSafe).ToArray();
      if (heroAbilities.Any())
      {
        tooltipBuilder.Append($"{LineSeperator}{HeroAbilitiesKnown}{string.Join(", ", heroAbilities)}");
      }
    }

    private static void AppendFlavour(StringBuilder stringBuilder, Unit unit)
    {
      var split = unit.GetExtendedTooltipSafe().Split("|n");
      stringBuilder.Append(split[0]); 
    }
  }
}