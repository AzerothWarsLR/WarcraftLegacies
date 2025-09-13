using MacroTools.Buffs;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  ///   Causes the specified unit type to always have a squad of tentacles surrounding them.
  /// </summary>
  public sealed class HideousAppendages : PassiveAbility
  {
    public HideousAppendages(int id) : base(id)
    {
    }

    public required int TentacleUnitTypeId { get; init; }

    public required int TentacleCount { get; init; }

    /// <summary>
    ///   How far away from the buff holder to position the tentacles.
    /// </summary>
    public required float RadiusOffset { get; init; }

    public override void OnCreated(unit createdUnit)
    {
      var hideousAppendagesBuff = new HideousAppendagesBuff(createdUnit, createdUnit)
      {
        TentacleUnitTypeId = TentacleUnitTypeId,
        TentacleCount = TentacleCount,
        Duration = float.MaxValue,
        RadiusOffset = RadiusOffset
      };
      BuffSystem.Add(hideousAppendagesBuff);
    }
  }
}