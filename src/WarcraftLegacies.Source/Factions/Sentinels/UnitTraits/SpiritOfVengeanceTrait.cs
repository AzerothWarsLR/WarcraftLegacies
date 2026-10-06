using System;
using MacroTools.Extensions;
using MacroTools.UnitTraits;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Sentinels.UnitTraits;

public sealed class SpiritOfVengeanceTrait : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityId { get; init; }
  public required int ChancePercent { get; init; }
  public required string SpiritModelPath { get; init; }
  public required float SpiritScale { get; init; }
  public required float SpiritDistance { get; init; }
  public required float StrikeDelay { get; init; }
  public required float FadeDuration { get; init; }

  private const float FadeInterval = 0.05f;

  public void OnDealsDamage()
  {
    var warden = @event.DamageSource;
    var target = @event.Unit;
    if (!@event.IsAttack || warden.GetAbilityLevel(AbilityId) == 0 || !target.Alive ||
        GetRandomInt(1, 100) > ChancePercent)
    {
      return;
    }

    var damage = Math.Max(target.GetAverageDamage(0), warden.GetAverageDamage(0));
    var attackType = @event.AttackType;
    var damageType = @event.DamageType;
    var angle = MathEx.GetAngleBetweenPoints(warden.X, warden.Y, target.X, target.Y);
    var spirit = effect.Create(SpiritModelPath, MathEx.GetPolarOffsetX(target.X, SpiritDistance, angle),
      MathEx.GetPolarOffsetY(target.Y, SpiritDistance, angle));
    spirit.Scale = SpiritScale;
    spirit.SetYaw((angle + 180) * MathEx.DegToRad);
    spirit.PlayAnimation(animtype.Attack);

    timer.Create().Start(StrikeDelay, false, () =>
    {
      if (target.Alive)
      {
        target.TakeDamage(warden, damage, false, false, attackType, damageType);
      }

      @event.ExpiredTimer.Dispose();
      FadeOut(spirit);
    });
  }

  private void FadeOut(effect spirit)
  {
    var elapsed = 0f;
    timer.Create().Start(FadeInterval, true, () =>
    {
      elapsed += FadeInterval;
      if (elapsed < FadeDuration)
      {
        spirit.SetAlpha((int)(255 * (1 - elapsed / FadeDuration)));
        return;
      }

      spirit.SetAlpha(0);
      spirit.SetZ(-5000);
      spirit.Dispose();
      @event.ExpiredTimer.Dispose();
    });
  }
}
