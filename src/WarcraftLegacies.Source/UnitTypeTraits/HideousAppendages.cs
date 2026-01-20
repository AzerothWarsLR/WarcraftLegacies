using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
///   Causes the specified unit type to always have a squad of tentacles surrounding them.
/// </summary>
public sealed class HideousAppendages : UnitTrait, IEffectOnCreated
{
  public required int TentacleUnitTypeId { get; init; }

  public required int TentacleCount { get; init; }

  /// <summary>
  ///   How far away from the buff holder to position the tentacles.
  /// </summary>
  public required float RadiusOffset { get; init; }

  public void OnCreated(unit createdUnit)
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
