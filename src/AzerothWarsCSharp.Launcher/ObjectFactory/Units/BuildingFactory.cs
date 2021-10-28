using System.Collections.Generic;
using System.Linq;
using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class BuildingFactory : UnitFactory
  {
    private void GenerateTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.Append($"{Flavour}|n");
      tooltipBuilder.Append($"|n|c006969FFHit points|r: {unit.StatsHitPointsMaximumBase}");
      //Trains
      if (unit.TechtreeUnitsTrained != null && unit.TechtreeUnitsTrained.Any())
      {
        tooltipBuilder.Append($"|n|c006969FFTrains|r: ");
        foreach (var unitTrained in unit.TechtreeUnitsTrained)
        {
          tooltipBuilder.Append($"{unitTrained.TextName}");
        }
      }
      //Researches
      if (unit.TechtreeResearchesAvailable != null && unit.TechtreeResearchesAvailable.Any())
      {
        tooltipBuilder.Append($"|n|c006969FFResearches|r: ");
        foreach (var research in unit.TechtreeResearchesAvailable)
        {
          tooltipBuilder.Append($"{research.TextName}");
        }
      }
      unit.TextTooltipExtended = tooltipBuilder.ToString();
    }

    /// <summary>
    /// Generate a building instance.
    /// </summary>
    public new Unit Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newUnit = new Unit(BaseType, newRawCode, objectDatabase)
      {
        TechtreeStructuresBuilt = StructuresBuilt,
        StatsBuildTime = BuildTime,
        ArtScalingValue = ScalingValue,
        PathingCollisionSize = CollisionSize,
        ArtButtonPositionX = ButtonPosition.X,
        ArtButtonPositionY = ButtonPosition.Y,
        CombatAttack1DamageBase = DamageBase,
        CombatAttack1DamageNumberOfDice = DamageNumberOfDice,
        CombatAttack1DamageSidesPerDie = DamageSidesPerDie,
        StatsHitPointsMaximumBase = HitPoints,
        TextName = Name,
        ArtModelFile = Model,
        ArtIconGameInterface = Icon,
        AbilitiesNormal = AbilitiesNormal,
        TechtreeUnitsTrained = UnitsTrained,
        TechtreeResearchesAvailable = ResearchesAvailable,
        PathingPlacementPreventedBy = PathingPrevent,
        PathingPlacementRequires = PathingRequire,
        ArtRequiredAnimationNames = RequiredAnimationNames
      };
      GenerateTooltip(newUnit);
      return newUnit;
    }

    /// <summary>
    /// Units that can be trained by generated buildings.
    /// </summary>
    public IEnumerable<Unit> UnitsTrained { get; set; } = System.Array.Empty<Unit>();

    /// <summary>
    /// Researches that can be researched by generated buildings.
    /// </summary>
    public IEnumerable<Upgrade> ResearchesAvailable { get; set; } = System.Array.Empty<Upgrade>();

    public IEnumerable<PathingRequire> PathingPrevent { get; set; } = System.Array.Empty<PathingRequire>();

    public IEnumerable<PathingPrevent> PathingRequire { get; set; } = System.Array.Empty<PathingPrevent>();

    public BuildingFactory(UnitType baseType) : base(baseType)
    {
    }
  }
}