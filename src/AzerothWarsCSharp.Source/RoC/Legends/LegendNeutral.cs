using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendNeutral
  {


    public static Legend LEGEND_RAGNAROS;
    public static Legend LEGEND_SEAWITCH;

    public static Legend LEGEND_AUCHINDOUN;
    public static Legend LEGEND_DRAKTHARONKEEP;
    public static Legend LEGEND_OSHUGUN;
    public static Legend LEGEND_JINTHAALOR;
    public static Legend LEGEND_SHRINEOFULATEK;
    public static Legend LEGEND_SERADANE;
    public static Legend LEGEND_ZULGURUB;
    public static Legend LEGEND_DAZARALOR;
    public static Legend LEGEND_GUNDRAK;
    public static Legend LEGEND_DUSKWOODGRAVEYARD;
    public static Legend LEGEND_GRIMBATOL;
    public static Legend LEGEND_ETHELRETHOR;
    public static Legend LEGEND_NEXUS;
    public static Legend LEGEND_KARAZHAN;
    public static Legend LEGEND_ZULFARRAK;
    public static Legend LEGEND_FOUNTAINOFHEALTH;
    public static Legend LEGEND_FOUNTAINOFHEALTH_WETLANDS;
    public static Legend LEGEND_FOUNTAINOFHEALTH_FERALAS;
    public static Legend LEGEND_FOUNTAINOFHEALTH_TOMB;
    public static Legend LEGEND_FOUNTAINOFHEALTH_DALARAN;
    public static Legend LEGEND_FOUNTAINOFBLOOD;
    public static Legend LEGEND_CENTAURKHAN;
    public static Legend LEGEND_IMMOLTHAR;
    public static Legend LEGEND_ARUGAL;
    public static Legend LEGEND_VAELASTRASZ;
    public static Legend LEGEND_OCCULUS;
    public static Legend LEGEND_SARAGOSA;
    public static Legend LEGEND_CAERDARROW;
  

    public static void Setup( ){
      LEGEND_RAGNAROS = new Legend();
      LEGEND_RAGNAROS.Unit = gg_unit_N00D_1457;
      LEGEND_RAGNAROS.DeathMessage = "Ragnaros, the King of Fire && Lord of the Firelands, has been extinguished.";

      LEGEND_SEAWITCH = new Legend();
      LEGEND_SEAWITCH.Unit = gg_unit_O02L_0340;

      LEGEND_AUCHINDOUN = new Legend();
      LEGEND_AUCHINDOUN.Capturable = true;
      LEGEND_AUCHINDOUN.Unit = gg_unit_h026_1207;

      LEGEND_DRAKTHARONKEEP = new Legend();
      LEGEND_DRAKTHARONKEEP.Capturable = true;
      LEGEND_DRAKTHARONKEEP.Unit = gg_unit_o016_0771;

      LEGEND_OSHUGUN = new Legend();
      LEGEND_OSHUGUN.Capturable = true;
      LEGEND_OSHUGUN.Unit = gg_unit_h02Z_0726;

      LEGEND_JINTHAALOR = new Legend();
      LEGEND_JINTHAALOR.Capturable = true;
      LEGEND_JINTHAALOR.Unit = gg_unit_o02G_0310;

      LEGEND_SHRINEOFULATEK = new Legend();
      LEGEND_SHRINEOFULATEK.Capturable = true;
      LEGEND_SHRINEOFULATEK.Unit = gg_unit_o00Q_0989;

      LEGEND_SERADANE = new Legend();
      LEGEND_SERADANE.Capturable = true;
      LEGEND_SERADANE.Unit = gg_unit_e014_3083;

      LEGEND_ZULGURUB = new Legend();
      LEGEND_ZULGURUB.Capturable = true;
      LEGEND_ZULGURUB.Unit = gg_unit_o018_0017;

      LEGEND_DAZARALOR = new Legend();
      LEGEND_DAZARALOR.Capturable = true;
      LEGEND_DAZARALOR.Unit = gg_unit_o00V_2194;

      LEGEND_GUNDRAK = new Legend();
      LEGEND_GUNDRAK.Capturable = true;
      LEGEND_GUNDRAK.Unit = gg_unit_o00N_0704;

      LEGEND_DUSKWOODGRAVEYARD = new Legend();
      LEGEND_DUSKWOODGRAVEYARD.Capturable = true;
      LEGEND_DUSKWOODGRAVEYARD.Unit = gg_unit_h01F_1161;

      LEGEND_GRIMBATOL = new Legend();
      LEGEND_GRIMBATOL.Capturable = true;
      LEGEND_GRIMBATOL.Unit = gg_unit_h01Z_0618;

      LEGEND_ETHELRETHOR = new Legend();
      LEGEND_ETHELRETHOR.Capturable = true;
      LEGEND_ETHELRETHOR.Unit = gg_unit_h05I_0313;

      LEGEND_NEXUS = new Legend();
      LEGEND_NEXUS.Unit = gg_unit_h04P_1732;
      LEGEND_NEXUS.Capturable = true;

      LEGEND_KARAZHAN = new Legend();
      LEGEND_KARAZHAN.Unit = gg_unit_h00G_0084;
      LEGEND_KARAZHAN.Capturable = true;

      LEGEND_ZULFARRAK = new Legend();
      LEGEND_ZULFARRAK.Capturable = true;
      LEGEND_ZULFARRAK.Unit = gg_unit_o00K_0150;

      LEGEND_FOUNTAINOFHEALTH = new Legend();
      LEGEND_FOUNTAINOFHEALTH.Capturable = true;
      LEGEND_FOUNTAINOFHEALTH.Unit = gg_unit_nfoh_0212;

      LEGEND_FOUNTAINOFHEALTH_WETLANDS = new Legend();
      LEGEND_FOUNTAINOFHEALTH_WETLANDS.Capturable = true;
      LEGEND_FOUNTAINOFHEALTH_WETLANDS.Unit = gg_unit_nfoh_2299;

      LEGEND_FOUNTAINOFHEALTH_FERALAS = new Legend();
      LEGEND_FOUNTAINOFHEALTH_FERALAS.Capturable = true;
      LEGEND_FOUNTAINOFHEALTH_FERALAS.Unit = gg_unit_nfoh_0315;

      LEGEND_FOUNTAINOFHEALTH_TOMB = new Legend();
      LEGEND_FOUNTAINOFHEALTH_TOMB.Capturable = true;
      LEGEND_FOUNTAINOFHEALTH_TOMB.Unit = gg_unit_nfoh_1904;

      LEGEND_FOUNTAINOFHEALTH_DALARAN = new Legend();
      LEGEND_FOUNTAINOFHEALTH_DALARAN.Capturable = true;
      LEGEND_FOUNTAINOFHEALTH_DALARAN.Unit = gg_unit_nfoh_1190;

      LEGEND_FOUNTAINOFBLOOD = new Legend();
      LEGEND_FOUNTAINOFBLOOD.Capturable = true;
      LEGEND_FOUNTAINOFBLOOD.Unit = gg_unit_nbfl_0094;

      LEGEND_CENTAURKHAN = new Legend();
      LEGEND_CENTAURKHAN.Unit = gg_unit_ncnk_0573;

      LEGEND_IMMOLTHAR = new Legend();
      LEGEND_IMMOLTHAR.Unit = gg_unit_n04R_1914;

      LEGEND_VAELASTRASZ = new Legend();
      LEGEND_VAELASTRASZ.Unit = gg_unit_nrwm_1981;

      LEGEND_OCCULUS = new Legend();
      LEGEND_OCCULUS.Unit = gg_unit_O025_3426;
      LEGEND_OCCULUS.PermaDies = true;

      LEGEND_SARAGOSA = new Legend();
      LEGEND_SARAGOSA.Unit = gg_unit_nadr_0658;

      LEGEND_ARUGAL = new Legend();
      LEGEND_ARUGAL.Unit = gg_unit_Hgam_1450;

      LEGEND_CAERDARROW = new Legend();
      LEGEND_CAERDARROW.Unit = gg_unit_u01M_0484;
      LEGEND_CAERDARROW.Capturable = true;
    }

  }
}
