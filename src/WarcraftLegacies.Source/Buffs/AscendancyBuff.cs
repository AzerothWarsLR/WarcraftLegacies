using System.Collections.Generic;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

public sealed class AscendancyBuff : PassiveBuff
{
  public IEnumerable<int>? AbilitiesToRemove { get; init; }

  public override void OnApply()
  {
    if (AbilitiesToRemove != null)
    {
      foreach (var ability in AbilitiesToRemove)
      {
        Caster.Owner.SetAbilityAvailable(ability, false);
      }
    }
  }

  public override void OnDispose()
  {
    if (AbilitiesToRemove != null)
    {
      foreach (var ability in AbilitiesToRemove)
      {
        Caster.Owner.SetAbilityAvailable(ability, true);
      }
    }
  }

  public AscendancyBuff(unit caster, unit target) : base(caster, target)
  {
  }
}
