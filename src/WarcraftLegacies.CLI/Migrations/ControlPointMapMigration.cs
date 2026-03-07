using System.Linq;
using War3Api.Object;
using War3Api.Object.Enums;
using War3Net.Build;
using Warcraft.Cartographer.Migrations;

namespace WarcraftLegacies.CLI.Migrations;

/// <summary>
/// Sets up all Control Point objects in the map.
/// </summary>
public sealed class ControlPointMapMigration : IMapMigration
{
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {
    foreach (var unit in objectDatabase.GetUnits().Where(IsControlPoint))
    {
      unit.CombatAttack1DamageBase = -1;
      unit.CombatAttack1DamageNumberOfDice = 1;
      unit.CombatAttack1DamageSidesPerDie = 1;
      unit.CombatAttacksEnabled = AttackBits.Attack1Only;
      unit.CombatAttack1Range = 900;
      unit.CombatAcquisitionRange = 900;
      unit.CombatAttack1TargetsAllowed = new[] { Target.Bridge };
      unit.EditorDisplayAsNeutralHostile = true;
      unit.StatsRace = UnitRace.Creeps;
      unit.PathingPathingMap = @"PathTextures\4x4SimpleSolid.tga";

      //Some Control Points are also Gold Mines. Dynamically changing Gold Remaining count is only supported for unit
      //types that started the game with Gold Mine Ability, so ALL Control Points must start with it.
      //Control Points that are not Gold Mines can have it removed at the start of the game, and it can be re-added
      //at any time and will still work.
      unit.AbilitiesNormal = unit.AbilitiesNormal.Append(objectDatabase.GetAbility(1684825921));
    }

    map.UnitObjectData = objectDatabase.GetAllData().UnitData;
  }

  private static bool IsControlPoint(Unit unit)
  {
    return unit.IsStatsUnitClassificationModified &&
           unit.StatsUnitClassification.Contains(UnitClassification.Sapper) &&
           unit.StatsUnitClassification.Contains(UnitClassification.Ancient) &&
           !unit.StatsUnitClassification.Contains(UnitClassification.Mechanical);
  }
}
