using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
      var innateAbilities = unit.AbilitiesNormal.Where(x => !GetTechtreeRequirements(x).Any()).OrderBy(GetAbilityPriority).Select(GetAbilityName).ToArray();
      if (innateAbilities.Any())
      {
        tooltipBuilder.Append($"{LineSeperator}{AbilitiesKnown}{string.Join(", ", innateAbilities)}");
      }
    }
    
    private static void AppendLearnedAbilities(StringBuilder tooltipBuilder, Unit unit)
    {
      if (!unit.IsAbilitiesNormalModified) return;
      var learnableAbilities = unit.AbilitiesNormal.Where(x => GetTechtreeRequirements(x).Any()).OrderBy(GetAbilityPriority).Select(GetAbilityName).ToArray();
      if (learnableAbilities.Any())
      {
        tooltipBuilder.Append($"{LineSeperator}{AbilitiesLearnable}{string.Join(", ", learnableAbilities)}");
      }
    }

    private static void AppendHeroAbilities(StringBuilder tooltipBuilder, Unit unit)
    {
      if (!unit.IsAbilitiesHeroModified) return;
      var heroAbilities = unit.AbilitiesHero.OrderBy(GetAbilityPriority).Select(GetAbilityName).ToArray();
      if (heroAbilities.Any())
      {
        tooltipBuilder.Append($"{LineSeperator}{HeroAbilitiesKnown}{string.Join(", ", heroAbilities)}");
      }
    }

    private static void AppendFlavour(StringBuilder stringBuilder, Unit unit)
    {
      var split = GetExtendedTooltip(unit).Split("|n");
      stringBuilder.Append(split[0]);
    }

    private static IEnumerable<Tech> GetTechtreeRequirements(Ability unit)
    {
      try
      {
        return unit.TechtreeRequirements;
      }
      catch
      {
        return Array.Empty<Tech>();
      }
    }
    
    private static string GetExtendedTooltip(Unit unit)
    {
      try
      {
        return unit.TextTooltipExtended;
      }
      catch
      {
        return "";
      }
    }

    /// <summary>
    /// Gets a name that can be used to describe an ability. Usually just the name field.
    /// </summary>
    private static string GetAbilityName(Ability ability)
    {
      try
      {
        return ability.TextName;
      }
      catch
      {
        return "Not found";
      }
    }

    /// <summary>
    /// Determines the order that abilities appear in tooltips.
    /// </summary>
    private static int GetAbilityPriority(Ability ability)
    {
      try
      {
        var (x, y) = (ability.ArtButtonPositionNormalX, ability.ArtButtonPositionNormalY);
        return x - y * 10;
      }
      catch
      {
        return 0;
      }
    }
  }
}