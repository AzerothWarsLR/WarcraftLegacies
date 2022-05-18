using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  public static class SpellHelpers
  {
    public static void StartUnitAbilityCooldownFull(unit whichUnit, int abilCode)
    {
      var fullCooldown = BlzGetUnitAbilityCooldown(whichUnit, abilCode, 0);
      BlzStartUnitAbilityCooldown(whichUnit, abilCode, fullCooldown);
    }

    public static bool IsUnitAlive(unit u)
    {
      return !IsUnitType(u, UNIT_TYPE_DEAD) && GetUnitTypeId(u) != 0;
    }

    public static bool IsUnitCorpse(unit u)
    {
      return IsUnitType(u, UNIT_TYPE_DEAD) && !IsUnitType(u, UNIT_TYPE_MECHANICAL) && !IsUnitType(u, UNIT_TYPE_HERO) &&
             !IsUnitType(u, UNIT_TYPE_ANCIENT) && !IsUnitType(u, UNIT_TYPE_SUMMONED) &&
             !IsUnitType(u, UNIT_TYPE_STRUCTURE);
    }

    public static void UnitHeal(unit caster, unit target, float amount)
    {
      SetUnitState(target, UNIT_STATE_LIFE, GetUnitState(target, UNIT_STATE_LIFE) + amount);
    }

    public static void UnitRestoreMana(unit cast, unit target, float amount)
    {
      SetUnitState(target, UNIT_STATE_MANA, GetUnitState(target, UNIT_STATE_MANA) + amount);
    }

    public static void UnitReduceMana(unit cast, unit target, float amount)
    {
      SetUnitState(target, UNIT_STATE_MANA, GetUnitState(target, UNIT_STATE_MANA) - amount);
    }

    public static void UnitTeleport(unit u, float x, float y)
    {
      SetUnitX(u, x);
      SetUnitY(u, y);
    }

    public static void UnitReanimate(unit caster, unit u, float duration)
    {
      var x = GetUnitX(u);
      var y = GetUnitY(u);
      var unitType = GetUnitTypeId(u);
      var facing = GetUnitFacing(u);
      RemoveUnit(u);
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\AnimateDead\\AnimateDeadTarget.mdl", x, y));
      var newUnit = CreateUnit(GetOwningPlayer(caster), unitType, x, y, facing);
      UnitApplyTimedLife(newUnit, FourCC("BUan"), duration);
      SetUnitVertexColor(newUnit, 200, 100, 200, 255);
      SetUnitUseFood(newUnit, false);
      UnitAddType(newUnit, UNIT_TYPE_UNDEAD);
      UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
    }

    public static unit CreateSummon(player id, int unitid, float x, float y, float face, float duration)
    {
      var u = CreateUnit(id, unitid, x, y, face);
      UnitApplyTimedLife(u, FourCC("BTLF"), duration);
      SetUnitUseFood(u, false);
      UnitAddType(u, UNIT_TYPE_SUMMONED);

      return u;
    }

    public static void ScaleUnitBaseDamage(unit u, float scale, int weaponIndex)
    {
      BlzSetUnitBaseDamage(u, R2I(I2R(BlzGetUnitBaseDamage(u, weaponIndex)) * scale), weaponIndex);
    }

    public static void ScaleUnitMaxHp(unit u, float scale)
    {
      var percHp = GetUnitLifePercent(u);
      BlzSetUnitMaxHP(u, R2I(I2R(BlzGetUnitMaxHP(u)) * scale));
      SetUnitLifePercentBJ(u, percHp);
    }
  }
}