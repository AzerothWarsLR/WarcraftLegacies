using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class HeroFactory : UnitFactory
  {
    private void GenerateTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.Append($"{Flavour}|n");
      tooltipBuilder.Append($"|n|c006969FFHit points|r: {unit.StatsHitPointsMaximumBase}");
      tooltipBuilder.Append($"|n|c006969FFAttack damage|r: {unit.DamageRangeString()}");
      tooltipBuilder.Append($"|n|c006969FFAbilities|r: ");
      foreach (var ability in AbilitiesNormal)
      {
        tooltipBuilder.Append($"{ability.TextName}");
      }
      tooltipBuilder.Append($"|n|c006969FFCan learn|r: ");
      foreach (var ability in AbilitiesHero)
      {
        tooltipBuilder.Append($"{ability.TextName}");
      }
      unit.TextTooltipExtended = tooltipBuilder.ToString();
    }

    private void GenerateCoreHero(Unit unit)
    {
      unit.StatsStartingStrength = Strength;
      unit.StatsStartingAgility = Agility;
      unit.StatsStartingIntelligence = Intelligence;

      unit.StatsStrengthPerLevel = StrengthPerLevel;
      unit.StatsAgilityPerLevel = AgilityPerLevel;
      unit.StatsIntelligencePerLevel = IntelligencePerLevel;

      unit.TextProperNames = new string[] { ProperName };
      unit.AbilitiesHero = AbilitiesHero;
    }

    /// <summary>
    /// Generate a unit instance.
    /// </summary>
    public new Unit Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      if (!char.IsUpper(newRawCode.First()))
      {
        throw new ArgumentException($"{newRawCode} must start with a capital letter.", nameof(newRawCode));
      }

      var newUnit = new Unit(BaseType, newRawCode, objectDatabase);
      GenerateCore(newUnit);
      GenerateCoreHero(newUnit);
      GenerateTooltip(newUnit);
      return newUnit;
    }

    private int? _strength;
    public int Strength
    {
      get => _strength ?? Parent?.Strength ?? 1;
      set => _strength = value;
    }

    private int? _agility;
    public int Agility
    {
      get => _agility ?? Parent?.Agility ?? 1;
      set => _agility = value;
    }

    private int? _intelligence;
    public int Intelligence
    {
      get => _intelligence ?? Parent?.Intelligence ?? 1;
      set => _intelligence = value;
    }

    private int? _strengthPerLevel;
    public int StrengthPerLevel
    {
      get => _strengthPerLevel ?? Parent?.StrengthPerLevel ?? 1;
      set => _strengthPerLevel = value;
    }

    private int? _agilityPerLevel;
    public int AgilityPerLevel
    {
      get => _agilityPerLevel ?? Parent?.AgilityPerLevel ?? 1;
      set => _agilityPerLevel = value;
    }

    private int? _intelligencePerLevel;
    public int IntelligencePerLevel
    {
      get => _intelligencePerLevel ?? Parent?.IntelligencePerLevel ?? 1;
      set => _intelligencePerLevel = value;
    }

    private string _properName;
    public string ProperName
    {
      get => _properName ?? Parent?.ProperName ?? "PLACEHOLDERPROPERNAME";
      set => _properName = value;
    }

    private IEnumerable<Ability> _abilitiesHero;
    public IEnumerable<Ability> AbilitiesHero
    {
      get => _abilitiesHero ?? Parent?.AbilitiesHero ?? System.Array.Empty<Ability>();
      set =>_abilitiesHero = value;
    }

    public new HeroFactory Parent { get; set; }

    public HeroFactory(UnitType baseType) : base(baseType)
    {
    }
  }
}
