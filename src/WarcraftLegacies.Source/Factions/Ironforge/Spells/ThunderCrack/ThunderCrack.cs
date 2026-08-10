using System.Linq;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.ThunderCrack;

public sealed class ThunderCrack : Spell
{
  public ThunderCrack(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var index = level - 1;
    var ability = caster.GetAbility(Id);
    var radius = ability.GetAreaOfEffect_aare(index);
    var durationNormal = ability.GetDurationNormal_adur(index);
    var durationHero = ability.GetDurationHero_ahdu(index);

    var enemies = GlobalGroup.EnumUnitsInRange(caster.GetPosition(), radius)
      .Where(enemy => CastFilters.IsTargetEnemyAliveAndGroundUnits(caster, enemy) && !enemy.IsUnitType(unittype.MagicImmune))
      .ToList();

    foreach (var enemy in enemies)
    {
      BuffSystem.Add(new ThunderCrackBuff(caster, enemy, level)
      {
        Active = true,
        Duration = enemy.IsUnitType(unittype.Hero) ? durationHero : durationNormal,
        IsBeneficial = false
      }, StackBehaviour.Stack);
    }
  }
}
