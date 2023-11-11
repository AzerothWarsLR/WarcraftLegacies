using System.Collections.Generic;
using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.Buffs
{
  public sealed class AddSpellOnCastBuff : BoundBuff
  {
    public IEnumerable<int>? AbilitiesToAdd { get; init; }
    
    public override void OnApply()
    {
      if (AbilitiesToAdd != null)
        foreach (var ability in AbilitiesToAdd)
        {
          UnitAddAbility(Caster, ability);

        }
    }

    public override void OnDispose()
    {
      if (AbilitiesToAdd != null)
        foreach (var ability in AbilitiesToAdd)
        {
          UnitRemoveAbility(Caster, ability);
        }
    }

    public AddSpellOnCastBuff(unit caster, unit target, int bindApplicatorId, int bindBuffId) : base(caster, target)
    {
      Bind(bindApplicatorId, bindBuffId);
    }
  }
}