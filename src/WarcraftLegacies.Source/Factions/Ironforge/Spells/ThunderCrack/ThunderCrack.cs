using System.Linq;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.ThunderCrack;

public sealed class ThunderCrack : Spell
{
  public float DebuffDuration { get; init; } = 3f;

  public ThunderCrack(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var ability = caster.GetAbility(Id);
    var radius = ability.GetAreaOfEffect_aare(level - 1);

    var enemies = GlobalGroup.EnumUnitsInRange(caster.GetPosition(), radius)
      .Where(enemy => CastFilters.IsTargetEnemyAliveAndGroundUnits(caster, enemy))
      .ToList();

    foreach (var enemy in enemies)
    {
      BuffSystem.Add(new ThunderCrackBuff(caster, enemy, level)
      {
        Active = true,
        Duration = DebuffDuration,
        IsBeneficial = false
      }, StackBehaviour.Stack);
    }
  }
}
