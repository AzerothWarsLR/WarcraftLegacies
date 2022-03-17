public class LegendNeutral{

  
    Legend LEGEND_RAGNAROS
    Legend LEGEND_SEAWITCH

    Legend LEGEND_AUCHINDOUN
    Legend LEGEND_DRAKTHARONKEEP
    Legend LEGEND_OSHUGUN
    Legend LEGEND_JINTHAALOR
    Legend LEGEND_SHRINEOFULATEK
    Legend LEGEND_SERADANE
    Legend LEGEND_ZULGURUB
    Legend LEGEND_DAZARALOR
    Legend LEGEND_GUNDRAK
    Legend LEGEND_DUSKWOODGRAVEYARD
    Legend LEGEND_GRIMBATOL
    Legend LEGEND_ETHELRETHOR
    Legend LEGEND_NEXUS
    Legend LEGEND_KARAZHAN
    Legend LEGEND_ZULFARRAK
    Legend LEGEND_FOUNTAINOFHEALTH
    Legend LEGEND_FOUNTAINOFHEALTH_WETLANDS
    Legend LEGEND_FOUNTAINOFHEALTH_FERALAS
    Legend LEGEND_FOUNTAINOFHEALTH_TOMB
    Legend LEGEND_FOUNTAINOFHEALTH_DALARAN
    Legend LEGEND_FOUNTAINOFBLOOD
    Legend LEGEND_CENTAURKHAN
    Legend LEGEND_IMMOLTHAR
    Legend LEGEND_ARUGAL
    Legend LEGEND_VAELASTRASZ
    Legend LEGEND_OCCULUS
    Legend LEGEND_SARAGOSA
    Legend LEGEND_CAERDARROW
  

  private static void OnInit( ){
    LEGEND_RAGNAROS = Legend.create();
    LEGEND_RAGNAROS.Unit = gg_unit_N00D_1457;
    LEGEND_RAGNAROS.DeathMessage = "Ragnaros, the King of Fire && Lord of the Firelands, has been extinguished.";

    LEGEND_SEAWITCH = Legend.create();
    LEGEND_SEAWITCH.Unit = gg_unit_O02L_0340;

    LEGEND_AUCHINDOUN = Legend.create();
    LEGEND_AUCHINDOUN.Capturable = true;
    LEGEND_AUCHINDOUN.Unit = gg_unit_h026_1207;

    LEGEND_DRAKTHARONKEEP = Legend.create();
    LEGEND_DRAKTHARONKEEP.Capturable = true;
    LEGEND_DRAKTHARONKEEP.Unit = gg_unit_o016_0771;

    LEGEND_OSHUGUN = Legend.create();
    LEGEND_OSHUGUN.Capturable = true;
    LEGEND_OSHUGUN.Unit = gg_unit_h02Z_0726;

    LEGEND_JINTHAALOR = Legend.create();
    LEGEND_JINTHAALOR.Capturable = true;
    LEGEND_JINTHAALOR.Unit = gg_unit_o02G_0310;

    LEGEND_SHRINEOFULATEK = Legend.create();
    LEGEND_SHRINEOFULATEK.Capturable = true;
    LEGEND_SHRINEOFULATEK.Unit = gg_unit_o00Q_0989;

    LEGEND_SERADANE = Legend.create();
    LEGEND_SERADANE.Capturable = true;
    LEGEND_SERADANE.Unit = gg_unit_e014_3083;

    LEGEND_ZULGURUB = Legend.create();
    LEGEND_ZULGURUB.Capturable = true;
    LEGEND_ZULGURUB.Unit = gg_unit_o018_0017;

    LEGEND_DAZARALOR = Legend.create();
    LEGEND_DAZARALOR.Capturable = true;
    LEGEND_DAZARALOR.Unit = gg_unit_o00V_2194;

    LEGEND_GUNDRAK = Legend.create();
    LEGEND_GUNDRAK.Capturable = true;
    LEGEND_GUNDRAK.Unit = gg_unit_o00N_0704;

    LEGEND_DUSKWOODGRAVEYARD = Legend.create();
    LEGEND_DUSKWOODGRAVEYARD.Capturable = true;
    LEGEND_DUSKWOODGRAVEYARD.Unit = gg_unit_h01F_1161;

    LEGEND_GRIMBATOL = Legend.create();
    LEGEND_GRIMBATOL.Capturable = true;
    LEGEND_GRIMBATOL.Unit = gg_unit_h01Z_0618;

    LEGEND_ETHELRETHOR = Legend.create();
    LEGEND_ETHELRETHOR.Capturable = true;
    LEGEND_ETHELRETHOR.Unit = gg_unit_h05I_0313;

    LEGEND_NEXUS = Legend.create();
    LEGEND_NEXUS.Unit = gg_unit_h04P_1732;
    LEGEND_NEXUS.Capturable = true;

    LEGEND_KARAZHAN = Legend.create();
    LEGEND_KARAZHAN.Unit = gg_unit_h00G_0084;
    LEGEND_KARAZHAN.Capturable = true;

    LEGEND_ZULFARRAK = Legend.create();
    LEGEND_ZULFARRAK.Capturable = true;
    LEGEND_ZULFARRAK.Unit = gg_unit_o00K_0150;

    LEGEND_FOUNTAINOFHEALTH = Legend.create();
    LEGEND_FOUNTAINOFHEALTH.Capturable = true;
    LEGEND_FOUNTAINOFHEALTH.Unit = gg_unit_nfoh_0212;

    LEGEND_FOUNTAINOFHEALTH_WETLANDS = Legend.create();
    LEGEND_FOUNTAINOFHEALTH_WETLANDS.Capturable = true;
    LEGEND_FOUNTAINOFHEALTH_WETLANDS.Unit = gg_unit_nfoh_2299;

    LEGEND_FOUNTAINOFHEALTH_FERALAS = Legend.create();
    LEGEND_FOUNTAINOFHEALTH_FERALAS.Capturable = true;
    LEGEND_FOUNTAINOFHEALTH_FERALAS.Unit = gg_unit_nfoh_0315;

    LEGEND_FOUNTAINOFHEALTH_TOMB = Legend.create();
    LEGEND_FOUNTAINOFHEALTH_TOMB.Capturable = true;
    LEGEND_FOUNTAINOFHEALTH_TOMB.Unit = gg_unit_nfoh_1904;

    LEGEND_FOUNTAINOFHEALTH_DALARAN = Legend.create();
    LEGEND_FOUNTAINOFHEALTH_DALARAN.Capturable = true;
    LEGEND_FOUNTAINOFHEALTH_DALARAN.Unit = gg_unit_nfoh_1190;

    LEGEND_FOUNTAINOFBLOOD = Legend.create();
    LEGEND_FOUNTAINOFBLOOD.Capturable = true;
    LEGEND_FOUNTAINOFBLOOD.Unit = gg_unit_nbfl_0094;

    LEGEND_CENTAURKHAN = Legend.create();
    LEGEND_CENTAURKHAN.Unit = gg_unit_ncnk_0573;

    LEGEND_IMMOLTHAR = Legend.create();
    LEGEND_IMMOLTHAR.Unit = gg_unit_n04R_1914;

    LEGEND_VAELASTRASZ = Legend.create();
    LEGEND_VAELASTRASZ.Unit = gg_unit_nrwm_1981;

    LEGEND_OCCULUS = Legend.create();
    LEGEND_OCCULUS.Unit = gg_unit_O025_3426;
    LEGEND_OCCULUS.PermaDies = true;

    LEGEND_SARAGOSA = Legend.create();
    LEGEND_SARAGOSA.Unit = gg_unit_nadr_0658;

    LEGEND_ARUGAL = Legend.create();
    LEGEND_ARUGAL.Unit = gg_unit_Hgam_1450;

    LEGEND_CAERDARROW = Legend.create();
    LEGEND_CAERDARROW.Unit = gg_unit_u01M_0484;
    LEGEND_CAERDARROW.Capturable = true;
  }

}
