public class CenariusGhost{

  private static void Dies( ){
    if (LEGEND_CENARIUS == GetTriggerLegend() && GetTriggerLegend().UnitType == UNITTYPE_CENARIUS_ALIVE){
      LEGEND_CENARIUS.UnitType = UNITTYPE_CENARIUS_GHOST;
      LEGEND_CENARIUS.PermaDies = false;
      LEGEND_CENARIUS.ClearUnitDependencies();
      LEGEND_CENARIUS.Spawn(FACTION_DRUIDS.Player, GetRectCenterX(gg_rct_Cenarius), GetRectCenterY(gg_rct_Cenarius), 270);
      DestroyTrigger(GetTriggeringTrigger());
    }
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger();
    OnLegendPermaDeath.register(trig);
    TriggerAddCondition(trig, ( Dies));
    LEGEND_CENARIUS.DeathMessage = "Cenarius, Demigod of the Night Elves, has fallen. His spirit lives on, a mere echo of his former self.";
  }

}
