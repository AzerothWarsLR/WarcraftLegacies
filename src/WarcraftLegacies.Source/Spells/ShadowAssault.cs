using MacroTools.Spells;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class ShadowAssaultSpell : Spell
{
  public float BaseDamage { get; init; }
  public float DamagePerLevel { get; init; }

  public required string BlinkEffectPath { get; init; }
  public required string ExecuteEffectPath { get; init; }
  public required string DamageEffectPath { get; init; }

  public float BaseExecuteThreshold { get; init; } = 0.15f;
  public float ExecuteThresholdPerLevel { get; init; } = 0.05f;

  public ShadowAssaultSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var spellLevel = caster.GetAbilityLevel(Id);
    TeleportToTarget(caster, target);
    DealDamage(caster, target, spellLevel);
    if (!target.IsUnitType(unittype.Hero) && CanExecute(target, spellLevel))
    {
      Execute(caster, target);
    }
    else
    {
      caster.SetAbilityCooldownRemaining(Id, caster.GetAbilityCooldown(Id, spellLevel - 1));
    }

    caster.QueueOrder(ORDER_ATTACK, target);
  }

  private void TeleportToTarget(unit caster, unit target)
  {
    var behindTargetPos = Util.PositionWithPolarOffset(target.X, target.Y, -70, target.Facing);
    effect.Create(BlinkEffectPath, caster.X, caster.Y).Dispose();
    caster.SetPosition(behindTargetPos.x, behindTargetPos.y);
    effect.Create(BlinkEffectPath, behindTargetPos.x, behindTargetPos.y).Dispose();
  }

  private void DealDamage(unit caster, unit target, int spellLevel)
  {
    var damage = BaseDamage + DamagePerLevel * spellLevel;
    caster.DealDamage(target, damage, true, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    effect.Create(DamageEffectPath, caster.X, caster.Y).Dispose();
  }

  private bool CanExecute(unit target, int level)
  {
    var threshold = BaseExecuteThreshold + ExecuteThresholdPerLevel * level;
    var currentHp = target.Life;
    var maxHp = target.MaxLife;

    return currentHp < maxHp * threshold;
  }

  private void Execute(unit caster, unit target)
  {
    var currentHp = target.Life;
    caster.DealDamage(target, currentHp + 500, true, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);

    var executeEffect = effect.Create(ExecuteEffectPath, target.X, target.Y);
    executeEffect.Dispose();

    caster.SetAbilityCooldownRemaining(Id, 0);
  }
}
