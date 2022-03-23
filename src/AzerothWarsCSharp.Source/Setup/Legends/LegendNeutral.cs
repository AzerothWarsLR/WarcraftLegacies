using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendNeutral
  {


    public static Legend legendRagnaros;
    public static Legend legendSeawitch;

    public static Legend legendAuchindoun;
    public static Legend legendDraktharonkeep;
    public static Legend legendOshugun;
    public static Legend legendJinthaalor;
    public static Legend legendShrineofulatek;
    public static Legend legendSeradane;
    public static Legend legendZulgurub;
    public static Legend legendDazaralor;
    public static Legend legendGundrak;
    public static Legend legendDuskwoodgraveyard;
    public static Legend legendGrimbatol;
    public static Legend legendEthelrethor;
    public static Legend legendNexus;
    public static Legend legendKarazhan;
    public static Legend legendZulfarrak;
    public static Legend legendFountainofhealth;
    public static Legend legendFountainofhealthWetlands;
    public static Legend legendFountainofhealthFeralas;
    public static Legend legendFountainofhealthTomb;
    public static Legend legendFountainofhealthDalaran;
    public static Legend legendFountainofblood;
    public static Legend legendCentaurkhan;
    public static Legend legendImmolthar;
    public static Legend legendArugal;
    public static Legend legendVaelastrasz;
    public static Legend legendOcculus;
    public static Legend legendSaragosa;
    public static Legend legendCaerdarrow;
  

    public static void Setup( ){
      legendRagnaros = new Legend();
      legendRagnaros.Unit = gg_unit_N00D_1457;
      legendRagnaros.DeathMessage = "Ragnaros, the King of Fire && Lord of the Firelands, has been extinguished.";

      legendSeawitch = new Legend();
      legendSeawitch.Unit = gg_unit_O02L_0340;

      legendAuchindoun = new Legend();
      legendAuchindoun.Capturable = true;
      legendAuchindoun.Unit = gg_unit_h026_1207;

      legendDraktharonkeep = new Legend();
      legendDraktharonkeep.Capturable = true;
      legendDraktharonkeep.Unit = gg_unit_o016_0771;

      legendOshugun = new Legend();
      legendOshugun.Capturable = true;
      legendOshugun.Unit = gg_unit_h02Z_0726;

      legendJinthaalor = new Legend();
      legendJinthaalor.Capturable = true;
      legendJinthaalor.Unit = gg_unit_o02G_0310;

      legendShrineofulatek = new Legend();
      legendShrineofulatek.Capturable = true;
      legendShrineofulatek.Unit = gg_unit_o00Q_0989;

      legendSeradane = new Legend();
      legendSeradane.Capturable = true;
      legendSeradane.Unit = gg_unit_e014_3083;

      legendZulgurub = new Legend();
      legendZulgurub.Capturable = true;
      legendZulgurub.Unit = gg_unit_o018_0017;

      legendDazaralor = new Legend();
      legendDazaralor.Capturable = true;
      legendDazaralor.Unit = gg_unit_o00V_2194;

      legendGundrak = new Legend();
      legendGundrak.Capturable = true;
      legendGundrak.Unit = gg_unit_o00N_0704;

      legendDuskwoodgraveyard = new Legend();
      legendDuskwoodgraveyard.Capturable = true;
      legendDuskwoodgraveyard.Unit = gg_unit_h01F_1161;

      legendGrimbatol = new Legend();
      legendGrimbatol.Capturable = true;
      legendGrimbatol.Unit = gg_unit_h01Z_0618;

      legendEthelrethor = new Legend();
      legendEthelrethor.Capturable = true;
      legendEthelrethor.Unit = gg_unit_h05I_0313;

      legendNexus = new Legend();
      legendNexus.Unit = gg_unit_h04P_1732;
      legendNexus.Capturable = true;

      legendKarazhan = new Legend();
      legendKarazhan.Unit = gg_unit_h00G_0084;
      legendKarazhan.Capturable = true;

      legendZulfarrak = new Legend();
      legendZulfarrak.Capturable = true;
      legendZulfarrak.Unit = gg_unit_o00K_0150;

      legendFountainofhealth = new Legend();
      legendFountainofhealth.Capturable = true;
      legendFountainofhealth.Unit = gg_unit_nfoh_0212;

      legendFountainofhealthWetlands = new Legend();
      legendFountainofhealthWetlands.Capturable = true;
      legendFountainofhealthWetlands.Unit = gg_unit_nfoh_2299;

      legendFountainofhealthFeralas = new Legend();
      legendFountainofhealthFeralas.Capturable = true;
      legendFountainofhealthFeralas.Unit = gg_unit_nfoh_0315;

      legendFountainofhealthTomb = new Legend();
      legendFountainofhealthTomb.Capturable = true;
      legendFountainofhealthTomb.Unit = gg_unit_nfoh_1904;

      legendFountainofhealthDalaran = new Legend();
      legendFountainofhealthDalaran.Capturable = true;
      legendFountainofhealthDalaran.Unit = gg_unit_nfoh_1190;

      legendFountainofblood = new Legend();
      legendFountainofblood.Capturable = true;
      legendFountainofblood.Unit = gg_unit_nbfl_0094;

      legendCentaurkhan = new Legend();
      legendCentaurkhan.Unit = gg_unit_ncnk_0573;

      legendImmolthar = new Legend();
      legendImmolthar.Unit = gg_unit_n04R_1914;

      legendVaelastrasz = new Legend();
      legendVaelastrasz.Unit = gg_unit_nrwm_1981;

      legendOcculus = new Legend();
      legendOcculus.Unit = gg_unit_O025_3426;
      legendOcculus.PermaDies = true;

      legendSaragosa = new Legend();
      legendSaragosa.Unit = gg_unit_nadr_0658;

      legendArugal = new Legend();
      legendArugal.Unit = gg_unit_Hgam_1450;

      legendCaerdarrow = new Legend();
      legendCaerdarrow.Unit = gg_unit_u01M_0484;
      legendCaerdarrow.Capturable = true;
    }

  }
}
