namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class SummonGraniteGolems{

  
    private const int ABIL_ID = FourCC(A0EP);
    private const int SUMMON_ID = FourCC(nggr);
    private const int SUMMON_COUNT = 4;
    private const float DURATION = 60;
    private const float RADIUS = 400;
    private const float ANGLE_OFFSET = 45;
    private const string EFFECT = "war3mapImported\\Earth NovaTarget.mdx";
  

    private static void Cast( ){
      int i = 0;
      float angle = ANGLE_OFFSET;
      unit summonedUnit;
      float x;
      float y;
      while(true){
        if ( i == SUMMON_COUNT){ break; }
        angle = angle + 360 / SUMMON_COUNT;
        x = GetPolarOffsetX(GetUnitX(GetTriggerUnit()), RADIUS, angle);
        y = GetPolarOffsetY(GetUnitY(GetTriggerUnit()), RADIUS, angle);
        summonedUnit = CreateUnit(GetOwningPlayer(GetTriggerUnit()), SUMMON_ID, x, y, GetAngleBetweenPoints(x, y, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit())));
        UnitApplyTimedLife(summonedUnit, 0, DURATION);
        UnitAddType(summonedUnit, UNIT_TYPE_SUMMONED);
        SetUnitAnimation(summonedUnit, "birth");
        QueueUnitAnimation(summonedUnit, "stand");
        DestroyEffect(AddSpecialEffect(EFFECT, x, y));
        i = i + 1;
      }
    }

    private static void OnInit( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
