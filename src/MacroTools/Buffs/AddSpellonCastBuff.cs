using System.Collections.Generic;
using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.Buffs
{
  public sealed class AddSpellOnCastBuff : PassiveBuff
  {
    public IEnumerable<int>? AbilitiesToAdd { get; init; }
    
    public override void OnApply()
    {
      if (AbilitiesToAdd != null)
        foreach (var ability in AbilitiesToAdd)
        {
          SetPlayerAbilityAvailable(GetOwningPlayer(Caster), ability, true);
          UnitAddAbility(Caster, ability);

        }
    }

    public override void OnDispose()
    {
      if (AbilitiesToAdd != null)
        foreach (var ability in AbilitiesToAdd)
        {
          SetPlayerAbilityAvailable(GetOwningPlayer(Caster), ability, false);
          UnitRemoveAbility(Caster, ability);
        }
    }
    
    public AddSpellOnCastBuff(unit caster, unit target) : base(caster, target)
    {
    }
  }
}