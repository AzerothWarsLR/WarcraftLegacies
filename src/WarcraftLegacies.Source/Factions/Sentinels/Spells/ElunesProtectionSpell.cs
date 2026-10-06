using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Spells;

public sealed class ElunesProtectionSpell : Spell
{
  public required float Radius { get; init; }

  public required float Duration { get; init; }

  public required int ArmorBonus { get; init; }

  public required float ManaRegenerationBonus { get; init; }

  public required int BuffApplicatorId { get; init; }

  public required int BuffId { get; init; }

  public ElunesProtectionSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (!CastFilters.IsTargetAllyAndAlive(caster, unit) || unit.IsUnitType(unittype.Structure))
      {
        continue;
      }

      BuffSystem.Add(new ElunesProtectionBuff(caster, unit, BuffApplicatorId, BuffId, ArmorBonus,
        ManaRegenerationBonus)
      {
        Duration = Duration
      }, StackBehaviour.Stack);
    }
  }
}

public sealed class ElunesProtectionBuff : BoundBuff
{
  private readonly int _armorBonus;
  private readonly float _manaRegenerationBonus;
  private bool _applied;

  public ElunesProtectionBuff(unit caster, unit target, int buffApplicatorId, int buffId, int armorBonus,
    float manaRegenerationBonus) : base(caster, target)
  {
    _armorBonus = armorBonus;
    _manaRegenerationBonus = manaRegenerationBonus;
    BindAura(buffApplicatorId, buffId);
  }

  public override void OnApply()
  {
    _applied = true;
    BlzSetUnitArmor(Target, BlzGetUnitArmor(Target) + _armorBonus);
    BlzSetUnitRealField(Target, UNIT_RF_MANA_REGENERATION,
      BlzGetUnitRealField(Target, UNIT_RF_MANA_REGENERATION) + _manaRegenerationBonus);
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  public override void OnDispose()
  {
    if (_applied)
    {
      BlzSetUnitArmor(Target, BlzGetUnitArmor(Target) - _armorBonus);
      BlzSetUnitRealField(Target, UNIT_RF_MANA_REGENERATION,
        BlzGetUnitRealField(Target, UNIT_RF_MANA_REGENERATION) - _manaRegenerationBonus);
    }

    base.OnDispose();
  }
}
