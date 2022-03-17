
public class SpellHelpers{
    
        group TempGroup = CreateGroup();
    

  static void StartUnitAbilityCooldownFull(unit whichUnit, int abilCode ){
    float fullCooldown = BlzGetUnitAbilityCooldown(whichUnit, abilCode, 0);
    BlzStartUnitAbilityCooldown(whichUnit, abilCode, fullCooldown);
  }

    static boolean IsUnitAlive(unit u ){
         return !IsUnitType(u, UNIT_TYPE_DEAD) && GetUnitTypeId(u) != 0;
    }

    static boolean IsUnitCorpse(unit u ){
        return IsUnitType(u, UNIT_TYPE_DEAD) && !IsUnitType(u,UNIT_TYPE_MECHANICAL) && !IsUnitType(u,UNIT_TYPE_HERO) && !IsUnitType(u,UNIT_TYPE_ANCIENT) && !IsUnitType(u,UNIT_TYPE_SUMMONED) && !IsUnitType(u,UNIT_TYPE_STRUCTURE);
    }

    static void UnitHeal(unit caster, unit target, float amount ){
        SetUnitState(target, UNIT_STATE_LIFE, GetUnitState(target,UNIT_STATE_LIFE)+amount);
    }

    static void UnitRestoreMana(unit cast, unit target, float amount ){
        SetUnitState(target, UNIT_STATE_MANA, GetUnitState(target,UNIT_STATE_MANA)+amount);
    }

    static void UnitReduceMana(unit cast, unit target, float amount ){
        SetUnitState(target, UNIT_STATE_MANA, GetUnitState(target,UNIT_STATE_MANA)-amount);
    }

    static void UnitTeleport(unit u, float x,real y ){
        SetUnitX(u, x);
        SetUnitY(u, y);
    }

    static void UnitReanimate(unit caster, unit u, float duration ){
        float x = GetUnitX(u);
        float y = GetUnitY(u);
        int unitType = GetUnitTypeId(u);
        float facing = GetUnitFacing(u);
        unit newUnit;
        RemoveUnit(u);
        DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\AnimateDead\\AnimateDeadTarget.mdl", x, y));
        newUnit = CreateUnit(GetOwningPlayer(caster), unitType, x, y, facing);
        UnitApplyTimedLife(newUnit, FourCC(BUan), duration);
        SetUnitVertexColor(newUnit, 200, 100, 200, 255);
        SetUnitUseFood(newUnit, false);
        UnitAddType(newUnit, UNIT_TYPE_UNDEAD);
        UnitAddType(newUnit, UNIT_TYPE_SUMMONED);
    }

    static unit CreateSummon(player id, int unitid, float x, float y, float face, float duration ){
        unit u;

        u = CreateUnit(id, unitid, x, y, face);
        UnitApplyTimedLife(u, FourCC(BTLF), duration);
        SetUnitUseFood(u, false);
        UnitAddType(u, UNIT_TYPE_SUMMONED);

        return u;
    }

    static void ScaleUnitBaseDamage(unit u, float scale, int weaponIndex ){
        BlzSetUnitBaseDamage(u, R2I(I2R(BlzGetUnitBaseDamage(u, weaponIndex)) * scale), weaponIndex);
    }

    static void ScaleUnitMaxHP(unit u, float scale ){
        float percHP = GetUnitLifePercent(u);
        BlzSetUnitMaxHP(u, R2I(I2R(BlzGetUnitMaxHP(u)) * scale));
        SetUnitLifePercentBJ(u, percHP);
    }

}


