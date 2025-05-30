using MacroTools.Extensions;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using System;
using System.Linq;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Target a friendly unit with a nova, healing allies and damage enemies.
  /// </summary>
  public sealed class LegionNova : Spell
  {
    public LegionNova(int id) : base(id)
    {
    }

    /// <summary>The radius of the nova around the target. </summary>
    public float Radius { get; init; }

    public float Damage { get; init; }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      
      var targetPosition = target.GetPosition();
      var unitsInRange = GlobalGroup
                .EnumUnitsInRange(targetPosition, Radius)
                .Where(x => x != null && UnitAlive(x))
                .ToList();

      var casterPlayer = caster.OwningPlayer();


      foreach (var unit in unitsInRange)
      {
        if (IsValidEnemy(unit, caster))
        {
          unit.TakeDamage(caster, Damage, false, false, damageType: DAMAGE_TYPE_NORMAL);
          Console.WriteLine(unit + " took damage.");
        }

        if (IsValidAlly(unit, caster))
        {
          unit.Heal(Damage);
          Console.WriteLine(unit + " healed damage.");

        }
      }
      var EffectTarget = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl";

      AddSpecialEffect(EffectTarget, GetUnitX(target), GetUnitY(target)).SetLifespan();

    }

    private static bool IsValidEnemy(unit target, unit caster) =>
      UnitAlive(target) &&
      !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
      !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
      !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
      !IsPlayerAlly(caster.OwningPlayer(), target.OwningPlayer());

    private static bool IsValidAlly(unit target, unit caster) =>
      UnitAlive(target) &&
      !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
      !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
      !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
      IsPlayerAlly(caster.OwningPlayer(), target.OwningPlayer());
  }
}