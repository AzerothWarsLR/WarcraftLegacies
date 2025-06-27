using System;
using MacroTools.SpellSystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.WhimOfTheWinds
{
  public sealed class WhimOfTheWinds : Spell
  {
    private readonly struct BuffSpell
    {
      public readonly int AbilityId;
      public readonly int OrderId;
      public readonly string Name;

      public BuffSpell(int abilityId, int orderId, string name)
      {
        AbilityId = abilityId;
        OrderId = orderId;
        Name = name;
      }
    }

    private readonly BuffSpell[] _possibleBuffs;

    public WhimOfTheWinds(int id) : base(id)
    {
      _possibleBuffs = new[]
      {
        new BuffSpell(ABILITY_FAWW_FROST_ARMOR_WHIM_OF_THE_WINDS, ORDER_FROST_ARMOR, "Frost Armor"),
        new BuffSpell(ABILITY_IFWW_INNER_FIRE_WHIM_OF_THE_WINDS, ORDER_INNER_FIRE, "Inner Fire"),
        new BuffSpell(ABILITY_BLWW_BLOODLUST_WHIM_OF_THE_WINDS, ORDER_BLOODLUST, "Bloodlust")
      };
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      try
      {
        if (!CastFilters.IsTargetAllyAndAlive(caster, target))
        {
          Console.WriteLine("WhimOfTheWinds: Target is not a valid ally");
          return;
        }
        
        foreach (var buff in _possibleBuffs)
        {
          if (GetUnitAbilityLevel(target, buff.AbilityId) > 0)
          {
            Console.WriteLine($"WhimOfTheWinds: Target already has {buff.Name}");
            return;
          }
        }

        var randomValue = GetRandomReal(0, 1);
        var randomIndex = (int)(randomValue * _possibleBuffs.Length);
        var selectedBuff = _possibleBuffs[randomIndex];

        Console.WriteLine(
          $"WhimOfTheWinds: Selected {selectedBuff.Name} (index {randomIndex}, random value {randomValue})");

        BuffSystem.Add(new WhimOfTheWindsBuff(caster, target, selectedBuff.AbilityId, selectedBuff.OrderId)
        {
          Active = true
        });
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to cast {nameof(WhimOfTheWinds)}: {ex}");
      }
    }
  }
}