using System.Collections.Generic;
using System.Drawing;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class UnitFactory : IObjectFactory<Unit>
  {
    private void GenerateTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.Append($"{Flavour}|n|n");
      tooltipBuilder.Append($"|c006969FFHit points|r: {unit.StatsHitPointsMaximumBase}|n");
      tooltipBuilder.Append($"|c006969FFAttack damage|r: {unit.DamageRangeString()}|n");
      tooltipBuilder.Append($"|c006969FFAbilities|r: ");
      foreach (var ability in unit.AbilitiesNormal)
      {
        tooltipBuilder.Append($"{ability.TextName}");
      }
      unit.TextTooltipExtended = tooltipBuilder.ToString();
    }

    /// <summary>
    /// Generate a unit instance.
    /// </summary>
    public Unit Generate(string newRawCode)
    {
      var newUnit = new Unit(BaseType, newRawCode)
      {
        TechtreeStructuresBuilt = StructuresBuilt,
        StatsBuildTime = BuildTime,
        ArtScalingValue = ScalingValue,
        ArtSelectionScale = SelectionScale,
        PathingCollisionSize = CollisionSize,
        ArtButtonPositionX = ButtonPosition.X,
        ArtButtonPositionY = ButtonPosition.Y,
        CombatAttack1DamageBase = DamageBase,
        CombatAttack1DamageNumberOfDice = DamageNumberOfDice,
        CombatAttack1DamageSidesPerDie = DamageSidesPerDie,
        StatsHitPointsMaximumBase = HitPoints,
        TextName = TextName,
        ArtModelFile = ArtModelFile,
        ArtIconGameInterface = ArtIconGameInterface,
        AbilitiesNormal = AbilitiesNormal
      };
      GenerateTooltip(newUnit);
      return newUnit;
    }

    public IEnumerable<Unit> StructuresBuilt { get; set; } = System.Array.Empty<Unit>();

    public int BuildTime { get; set; } = 60;

    public float ScalingValue { get; set; } = 1;

    public float SelectionScale { get; set; } = 2;

    public float CollisionSize { get; set; } = 1;

    public Point ButtonPosition { get; set; } = new Point(0, 0);

    public string Flavour { get; set; } = "PLACEHOLDERFLAVOR";

    public int DamageBase { get; set; } = 0;

    public int DamageNumberOfDice { get; set; } = 0;

    public int DamageSidesPerDie { get; set; } = 0;

    public int HitPoints { get; set; } = 100;

    public string TextName { get; set; } = "PLACEHOLDERNAME";

    public string ArtModelFile { get; set; } = @"units\human\Peasant\Peasant";

    public string ArtIconGameInterface { get; set; } = @"ReplaceableTextures\CommandButtons\BTNPeasant.blp";

    public UnitType BaseType { get; set; }

    public IEnumerable<Ability> AbilitiesNormal { get; set; } = System.Array.Empty<Ability>();

    public UnitFactory(UnitType baseType)
    {
      BaseType = baseType;
      Flavour = "";
    }
  }
}