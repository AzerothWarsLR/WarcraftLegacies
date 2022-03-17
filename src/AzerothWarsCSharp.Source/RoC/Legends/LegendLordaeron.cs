public class LegendLordaeron{

  
    Legend LEGEND_UTHER
    Legend LEGEND_ARTHAS
    Legend LEGEND_MOGRAINE
    Legend LEGEND_GARITHOS
    Legend LEGEND_GOODCHILD

    Legend LEGEND_CAPITALPALACE
    Legend LEGEND_STRATHOLME
    Legend LEGEND_TYRSHAND
  

  private static void OnInit( ){
    LEGEND_MOGRAINE = Legend.create();
    LEGEND_MOGRAINE.UnitType = FourCC(H01J);
    LEGEND_MOGRAINE.StartingXP = 2800;

    LEGEND_GARITHOS = Legend.create();
    LEGEND_GARITHOS.UnitType = FourCC(Hlgr);
    LEGEND_GARITHOS.StartingXP = 2800;

    LEGEND_GOODCHILD = Legend.create();
    LEGEND_GOODCHILD.UnitType = FourCC(E00O);
    LEGEND_GOODCHILD.StartingXP = 2800;

    LEGEND_CAPITALPALACE = Legend.create();
    LEGEND_CAPITALPALACE.Unit = gg_unit_h000_0406;
    LEGEND_CAPITALPALACE.DeathMessage = "The capital city of Lordaeron has been razed, && King Terenas is dead.";
    LEGEND_CAPITALPALACE.IsCapital = true;

    LEGEND_STRATHOLME = Legend.create();
    LEGEND_STRATHOLME.Unit = gg_unit_h01G_0885;
    LEGEND_STRATHOLME.DeathMessage = "The majestic city of Stratholme has been destroyed.";
    LEGEND_STRATHOLME.IsCapital = true;

    LEGEND_TYRSHAND = Legend.create();
    LEGEND_TYRSHAND.Unit = gg_unit_h030_0839;
    LEGEND_TYRSHAND.DeathMessage = "TyrFourCC(s Hand, the bastion of human power in Lordaeron, has fallen.";
    LEGEND_TYRSHAND.IsCapital = true;

    LEGEND_UTHER = Legend.create();
    LEGEND_UTHER.UnitType = FourCC(Huth);
    LEGEND_UTHER.AddUnitDependency(gg_unit_h000_0406);
    LEGEND_UTHER.AddUnitDependency(gg_unit_nico_0666);
    LEGEND_UTHER.DeathMessage = "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, && humanity itself, has lost one of its finest exemplars in this dark hour.";
    LEGEND_UTHER.PlayerColor = PLAYER_COLOR_LIGHT_BLUE;
    LEGEND_UTHER.StartingXP = 1000;

    LEGEND_ARTHAS = Legend.create();
    LEGEND_ARTHAS.UnitType = FourCC(Hart);
    LEGEND_ARTHAS.PlayerColor = PLAYER_COLOR_BLUE;
    LEGEND_ARTHAS.AddUnitDependency(LEGEND_STRATHOLME.Unit);
    LEGEND_ARTHAS.AddUnitDependency(gg_unit_nico_0666);
    LEGEND_ARTHAS.Essential = true;

  }

}
