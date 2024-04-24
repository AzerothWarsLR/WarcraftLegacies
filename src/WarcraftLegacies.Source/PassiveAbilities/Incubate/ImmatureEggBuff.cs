using MacroTools.Extensions;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.Incubate
{
  /// <summary>
  /// Causes the egg to mature when the buff expires, allowing it to hatch.
  /// </summary>
  public sealed class ImmatureEggBuff : PassiveBuff
  {
    /// <summary>The unit type ID of the unit that gets hatched.</summary>
    public required int HatchedUnitTypeId { get; init; }
    
    /// <summary>The unit type ID of the mature egg version to transform into.</summary>
    public required int MatureEggUnitTypeId { get; init; }
    
    /// <inheritdoc />
    public ImmatureEggBuff(unit caster) : base(caster, caster)
    {
    }

    /// <inheritdoc />
    public override void OnApply()
    {
      Target
        .IssueOrder("setrally", Target.GetPosition())
        .SetTimedLife(Duration + 1);
    }

    /// <inheritdoc />
    public override void OnExpire()
    {
      var formerLifePercent = Target.GetLifePercent();
      var formerPosition = Target.GetPosition();
      var formerRallyPoint = Target.GetRallyPoint();
      var formerOwner = Target.OwningPlayer();
      
      Target.Kill().Remove();
      
      var matureEgg = CreateUnit(formerOwner, MatureEggUnitTypeId, formerPosition.X, formerPosition.Y, 270)
        .SetLifePercent(formerLifePercent)
        .IssueOrder("setrally", formerRallyPoint);
      
      var matureEggBuff = new MatureEggBuff(matureEgg)
      {
        HatchedUnitTypeId = HatchedUnitTypeId
      };
      BuffSystem.Add(matureEggBuff);
    }
  }
}