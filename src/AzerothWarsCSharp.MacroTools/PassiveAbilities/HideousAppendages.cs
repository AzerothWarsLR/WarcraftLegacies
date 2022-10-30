using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.PassiveAbilities
{
  /// <summary>
  ///   Causes the specified unit type to always have a squad of tentacles surrounding them.
  /// </summary>
  public sealed class HideousAppendages : PassiveAbility
  {
    public HideousAppendages(int id) : base(id)
    {
    }

    public int TentacleUnitTypeId { get; init; } = FourCC("hfoo");

    public int TentacleCount { get; init; } = 6;

    /// <summary>
    ///   How far away from the buff holder to position the tentacles.
    /// </summary>
    public float RadiusOffset { get; init; } = 250;

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