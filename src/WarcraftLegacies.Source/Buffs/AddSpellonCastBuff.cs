using System.Collections.Generic;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

public sealed class AddSpellOnCastBuff : BoundBuff
{
  public IEnumerable<int>? AbilitiesToAdd { get; init; }

  public override void OnApply()
  {
    if (AbilitiesToAdd != null)
    {
      foreach (var ability in AbilitiesToAdd)
      {
        Caster.AddAbility(ability);

      }
    }
  }

  public override void OnDispose()
  {
    if (AbilitiesToAdd != null)
    {
      foreach (var ability in AbilitiesToAdd)
      {
        Caster.RemoveAbility(ability);
      }
    }
  }

  public AddSpellOnCastBuff(unit caster, unit target, int bindApplicatorId, int bindBuffId) : base(caster, target)
  {
    BindAura(bindApplicatorId, bindBuffId);
  }
}
