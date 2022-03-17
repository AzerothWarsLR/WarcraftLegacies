namespace AzerothWarsCSharp.Source.RoC.Mechanics.Scourge
{
  public class EventKelthuzadDeath{

    //When Kel)thuzad (Necromancer) is permanently killed
    //Record his experience, and create Kel)thuzad (Ghost) as a replacement
    //This experience is given to Kel)thuzad (Lich) in QuestKelthuzadLich

  
    int KelthuzadExp = 0;
    private const int GHOST_ID = FourCC(uktg);
  

    private static void Dies( ){
      if (LEGEND_KELTHUZAD == GetTriggerLegend() && GetTriggerLegend().UnitType == UNITTYPE_KELTHUZAD_NECROMANCER){
        KelthuzadExp = GetHeroXP(LEGEND_KELTHUZAD.Unit);
        LEGEND_KELTHUZAD.UnitType = UNITTYPE_KELTHUZAD_GHOST;
        LEGEND_KELTHUZAD.PermaDies = false;
        LEGEND_KELTHUZAD.Spawn(FACTION_SCOURGE.Player, GetRectCenterX(gg_rct_FTSummon), GetRectCenterY(gg_rct_FTSummon), 270);
        DestroyTrigger(GetTriggeringTrigger());
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger();
      OnLegendPermaDeath.register(trig);
      TriggerAddCondition(trig, ( Dies));
    }

  }
}
