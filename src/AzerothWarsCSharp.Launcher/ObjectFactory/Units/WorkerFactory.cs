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
        ArtIconGameInterface = $@"ReplaceableTextures\CommandButtons\BTN{Icon}.blp",
        AbilitiesNormal = AbilitiesNormal,
      };
      GenerateTooltip(newUnit);
      return newUnit;
    }

    public WorkerFactory(UnitType baseType) : base(baseType)
    {
    }
  }
}