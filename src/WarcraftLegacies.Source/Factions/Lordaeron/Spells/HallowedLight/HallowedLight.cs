using MacroTools.Spells;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Spells.HallowedLight;

public sealed class HallowedLight : Spell
{
  public float Duration { get; init; }
  public string BuffEffect { get; init; }
  public string DebuffEffect { get; init; }

  public HallowedLight(int id) : base(id) { }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var isAlly = caster.Owner.IsAlly(target.Owner);

    BuffSystem.Add(new HallowedLightBuff(caster, target)
    {
      Active = true,
      Duration = Duration,
      IsBeneficial = isAlly,
      EffectString = isAlly ? BuffEffect : DebuffEffect,
      BuffId = isAlly ? BUFF_B001_HALLOWED_LIGHT : BUFF_B003_HALLOWED_LIGHT,
      ArmorAbilityId = isAlly ? ABILITY_A00G_HALLOWED_LIGHT_BUFF_PALADIN : ABILITY_A00K_HALLOWED_LIGHT_DEBUFF_PALADIN
    });
  }
}
