using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>Brands an enemy so lightning strikes it every few seconds, arcing to a nearby enemy.</summary>
public sealed class StormBrandSpell : Spell
{
  public required float Duration { get; init; }
  public required float StrikeInterval { get; init; }
  public required float StrikeDamage { get; init; }
  public required float ArcDamage { get; init; }
  public required float ArcRadius { get; init; }
  public required string BrandEffectPath { get; init; }
  public required string StrikeEffectPath { get; init; }

  public StormBrandSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var brand = effect.Create(BrandEffectPath, target, "overhead");
    var strikes = (int)(Duration / StrikeInterval);
    var struck = 0;
    var storm = timer.Create();
    storm.Start(StrikeInterval, true, () =>
    {
      struck++;
      if (target.Alive)
      {
        Strike(caster, target);
      }

      if (struck < strikes && target.Alive)
      {
        return;
      }

      storm.Dispose();
      brand.Dispose();
    });
  }

  private void Strike(unit caster, unit target)
  {
    effect.Create(StrikeEffectPath, target.X, target.Y).Dispose();
    caster.DealDamage(target, StrikeDamage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    unit? arcTarget = null;
    var closest = ArcRadius;
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(target.X, target.Y, ArcRadius))
    {
      if (nearby == target || nearby.UnitType == DummyCasterManager.UnitTypeId ||
          !CastFilters.IsTargetEnemyAndAliveUnits(caster, nearby))
      {
        continue;
      }

      var distance = MathEx.GetDistanceBetweenPoints(new Point(target.X, target.Y), new Point(nearby.X, nearby.Y));
      if (distance <= closest)
      {
        closest = distance;
        arcTarget = nearby;
      }
    }

    if (arcTarget == null)
    {
      return;
    }

    effect.Create(StrikeEffectPath, arcTarget.X, arcTarget.Y).Dispose();
    caster.DealDamage(arcTarget, ArcDamage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
  }
}
