using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public class WorkerFactory : UnitFactory
  {
    private void GenerateTooltip(Unit unit)
    {
      var tooltipBuilder = new StringBuilder();
      tooltipBuilder.Append($"{Flavour}|n");
      tooltipBuilder.Append($"|n|c006969FFHit points|r: {unit.StatsHitPointsMaximumBase}");
      unit.TextTooltipExtended = tooltipBuilder.ToString();
    }

    /// <summary>
    /// Generate a worker unit instance.
    /// </summary>
    public new Unit Generate()
    {
      var newUnit = new Unit(BaseType, NewRawCode)
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
        AbilitiesNormal = AbilitiesNormal,
      };
      GenerateTooltip(newUnit);
      return newUnit;
    }

    public WorkerFactory(UnitType baseType, string newRawCode) : base(baseType, newRawCode)
    {
    }
  }
}