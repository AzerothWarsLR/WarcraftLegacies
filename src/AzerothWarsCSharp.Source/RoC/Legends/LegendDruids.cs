public class LegendDruids{

  
    Legend LEGEND_CENARIUS
    Legend LEGEND_MALFURION
    Legend LEGEND_FANDRAL
    Legend LEGEND_URSOC
    Legend LEGEND_TORTOLLA

    Legend LEGEND_NORDRASSIL

    const int UNITTYPE_CENARIUS_ALIVE = FourCC(Ecen);
    const int UNITTYPE_CENARIUS_GHOST = FourCC(E00H);
  

  private static void OnInit( ){
    LEGEND_CENARIUS = Legend.create();
    LEGEND_CENARIUS.UnitType = FourCC(Ecen);
    LEGEND_CENARIUS.PermaDies = true;
    LEGEND_CENARIUS.DeathMessage = "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor.";
    LEGEND_CENARIUS.DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl";
    LEGEND_CENARIUS.PlayerColor = PLAYER_COLOR_CYAN;
    LEGEND_CENARIUS.StartingXP = 1000;

    LEGEND_MALFURION = Legend.create();
    LEGEND_MALFURION.UnitType = FourCC(Efur);
    LEGEND_MALFURION.Essential = true;

    LEGEND_FANDRAL = Legend.create();
    LEGEND_FANDRAL.UnitType = FourCC(E00K);

    LEGEND_URSOC = Legend.create();
    LEGEND_URSOC.UnitType = FourCC(E00A);
    LEGEND_URSOC.StartingXP = 7000;

    LEGEND_NORDRASSIL = Legend.create();
    LEGEND_NORDRASSIL.Unit = gg_unit_n002_0130;
    LEGEND_NORDRASSIL.Capturable = true;
    LEGEND_NORDRASSIL.IsCapital = true;

    LEGEND_TORTOLLA = Legend.create();
    LEGEND_TORTOLLA.UnitType = FourCC(H04U);
    LEGEND_TORTOLLA.StartingXP = 1800;
  }

}
