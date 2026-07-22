using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Shared.UnitTraits;

public sealed class TauntOnAvatarCast : UnitTrait, IEffectOnSpellEffect
{
  private readonly int _avatarAbilityId;
  private readonly int _tauntAbilityId;
  private readonly int _tauntOrderId;

  public TauntOnAvatarCast(int avatarAbilityId, int tauntAbilityId, int tauntOrderId)
  {
    _avatarAbilityId = avatarAbilityId;
    _tauntAbilityId = tauntAbilityId;
    _tauntOrderId = tauntOrderId;
  }

  public void OnSpellEffect()
  {
    if (@event.SpellAbilityId != _avatarAbilityId)
    {
      return;
    }

    var caster = @event.Unit;
    caster.IssueOrder(_tauntOrderId);
    BlzUnitHideAbility(caster, _tauntAbilityId, true);
  }
}
