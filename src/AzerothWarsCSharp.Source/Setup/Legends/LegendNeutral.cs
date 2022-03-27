using AzerothWarsCSharp.MacroTools;
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
      legendRagnaros.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("N00D"));
      legendRagnaros.DeathMessage = "Ragnaros, the King of Fire && Lord of the Firelands, has been extinguished.";

      legendSeawitch = new Legend();
      legendSeawitch.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("O02L"));

      legendAuchindoun = new Legend();
      legendAuchindoun.Capturable = true;
      legendAuchindoun.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h026"));

      legendDraktharonkeep = new Legend();
      legendDraktharonkeep.Capturable = true;
      legendDraktharonkeep.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o016"));

      legendOshugun = new Legend();
      legendOshugun.Capturable = true;
      legendOshugun.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h02Z"));

      legendJinthaalor = new Legend();
      legendJinthaalor.Capturable = true;
      legendJinthaalor.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o02G"));

      legendShrineofulatek = new Legend();
      legendShrineofulatek.Capturable = true;
      legendShrineofulatek.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00Q"));

      legendSeradane = new Legend();
      legendSeradane.Capturable = true;
      legendSeradane.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("e014"));

      legendZulgurub = new Legend();
      legendZulgurub.Capturable = true;
      legendZulgurub.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o018"));

      legendDazaralor = new Legend();
      legendDazaralor.Capturable = true;
      legendDazaralor.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00V"));

      legendGundrak = new Legend();
      legendGundrak.Capturable = true;
      legendGundrak.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00N"));

      legendDuskwoodgraveyard = new Legend();
      legendDuskwoodgraveyard.Capturable = true;
      legendDuskwoodgraveyard.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h01F"));

      legendGrimbatol = new Legend();
      legendGrimbatol.Capturable = true;
      legendGrimbatol.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h01Z"));

      legendEthelrethor = new Legend();
      legendEthelrethor.Capturable = true;
      legendEthelrethor.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h05I"));

      legendNexus = new Legend();
      legendNexus.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h04P"));
      legendNexus.Capturable = true;

      legendKarazhan = new Legend();
      legendKarazhan.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h00G"));
      legendKarazhan.Capturable = true;

      legendZulfarrak = new Legend();
      legendZulfarrak.Capturable = true;
      legendZulfarrak.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00K"));

      legendFountainofhealth = new Legend();
      legendFountainofhealth.Capturable = true;
      legendFountainofhealth.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"));

      legendFountainofhealthWetlands = new Legend();
      legendFountainofhealthWetlands.Capturable = true;
      legendFountainofhealthWetlands.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"));

      legendFountainofhealthFeralas = new Legend();
      legendFountainofhealthFeralas.Capturable = true;
      legendFountainofhealthFeralas.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"));

      legendFountainofhealthTomb = new Legend();
      legendFountainofhealthTomb.Capturable = true;
      legendFountainofhealthTomb.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"));

      legendFountainofhealthDalaran = new Legend();
      legendFountainofhealthDalaran.Capturable = true;
      legendFountainofhealthDalaran.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"));

      legendFountainofblood = new Legend();
      legendFountainofblood.Capturable = true;
      legendFountainofblood.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nbfl"));

      legendCentaurkhan = new Legend();
      legendCentaurkhan.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("ncnk"));

      legendImmolthar = new Legend();
      legendImmolthar.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n04R"));

      legendVaelastrasz = new Legend();
      legendVaelastrasz.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nrwm"));

      legendOcculus = new Legend();
      legendOcculus.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("O025"));
      legendOcculus.PermaDies = true;

      legendSaragosa = new Legend();
      legendSaragosa.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nadr"));

      legendArugal = new Legend();
      legendArugal.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Hgam"));

      legendCaerdarrow = new Legend();
      legendCaerdarrow.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("u01M"));
      legendCaerdarrow.Capturable = true;
    }

  }
}
