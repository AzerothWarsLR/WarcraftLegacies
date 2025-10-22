using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.WhimOfTheWinds;

public sealed class WhimOfTheWinds : Spell
{
  private readonly struct BuffSpell
  {
    public readonly int AbilityId;
    public readonly int OrderId;

    public BuffSpell(int abilityId, int orderId)
    {
      AbilityId = abilityId;
      OrderId = orderId;
    }
  }

  private readonly BuffSpell[] _possibleBuffs;

  public WhimOfTheWinds(int id) : base(id)
  {
    _possibleBuffs = new[]
    {
      new BuffSpell(ABILITY_WWIR_ROAR_WHIM_OF_THE_WINDS, ORDER_INNER_FIRE),
      new BuffSpell(ABILITY_IFWW_INNER_FIRE_WHIM_OF_THE_WINDS, ORDER_INNER_FIRE),
      new BuffSpell(ABILITY_BLWW_BLOODLUST_WHIM_OF_THE_WINDS, ORDER_BLOODLUST)
    };
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (!CastFilters.IsTargetAllyAndAlive(caster, target))
    {
      return;
    }

    foreach (var buff in _possibleBuffs)
    {
      if (target.GetAbilityLevel(buff.AbilityId) > 0)
      {
        return;
      }
    }

    var randomValue = GetRandomReal(0, 1);
    var randomIndex = (int)(randomValue * _possibleBuffs.Length);
    var selectedBuff = _possibleBuffs[randomIndex];

    BuffSystem.Add(new WhimOfTheWindsBuff(caster, target, selectedBuff.AbilityId, selectedBuff.OrderId)
    {
      Active = true
    });
  }
}
