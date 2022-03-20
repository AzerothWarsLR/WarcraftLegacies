using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Spells
{
  public static class InspireMadness
  {
    private static readonly int AbilId = FourCC("A10M");
    
    private const float RADIUS = 400;
    private const int COUNT_BASE = 2; //How many units to charm
    private const int COUNT_LEVEL = 4;
    private const float DURATION = 16; //The units kill themselves after this duration

    private const string EFFECT = "war3mapImported\\Call of Dread Purple.mdx";
    private const float EFFECT_SCALE = 11;
    private const string EFFECT_TARGET = "Abilities\\Spells\\Other\\Charm\\CharmTarget.mdl";
    private const float EFFECT_SCALE_TARGET = 05;
    
    private static void Cast()
    {
      var i = 0; //Tracks number of units charmed
      effect tempEffect;
      unit caster = GetTriggerUnit();
      player triggerPlayer = GetOwningPlayer(caster);
      var level = GetUnitAbilityLevel(caster, AbilId);
      @group tempGroup = CreateGroup();
      GroupEnumUnitsInRange(tempGroup, GetSpellTargetX(), GetSpellTargetY(), RADIUS, null);
      while (true)
      {
        if (BlzGroupGetSize(tempGroup) == 0 || i == COUNT_BASE + COUNT_LEVEL * level)
        {
          break;
        }

        unit u = BlzGroupUnitAt(tempGroup, GetRandomInt(0, BlzGroupGetSize(tempGroup) - 1));
        if (!IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT) &&
            !IsUnitType(u, UNIT_TYPE_MECHANICAL) && !IsUnitType(u, UNIT_TYPE_RESISTANT) &&
            !IsUnitType(u, UNIT_TYPE_HERO) && !IsUnitAlly(u, triggerPlayer) && IsUnitAliveBJ(u))
        {
          SetUnitOwner(u, triggerPlayer, true);
          UnitApplyTimedLife(u, FourCC("Bpos"), DURATION);
          SetUnitExploded(u, true);
          tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(u), GetUnitY(u));
          BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET);
          DestroyEffect(tempEffect);
          i += 1;
        }

        GroupRemoveUnit(tempGroup, u);
      }

      tempEffect = AddSpecialEffect(EFFECT, GetSpellTargetX(), GetSpellTargetY());
      BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE);
      DestroyEffect(tempEffect);
      DestroyGroup(tempGroup);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, Cast, AbilId);
    }
  }
}