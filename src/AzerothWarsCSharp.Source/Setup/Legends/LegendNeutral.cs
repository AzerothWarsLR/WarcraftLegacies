using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendNeutral
  {
    public static Legend LegendRagnaros { get; private set; }
    public static Legend LegendSeawitch { get; private set; }
    public static Legend LegendAuchindoun { get; private set; }
    public static Legend LegendDraktharonkeep { get; private set; }
    public static Legend LegendOshugun { get; private set; }
    public static Legend LegendJinthaalor { get; private set; }
    public static Legend LegendShrineofulatek { get; private set; }
    public static Legend LegendSeradane { get; private set; }
    public static Legend LegendZulgurub { get; private set; }
    public static Legend LegendDazaralor { get; private set; }
    public static Legend LegendGundrak { get; private set; }
    public static Legend LegendDuskwoodgraveyard { get; private set; }
    public static Legend LegendGrimbatol { get; private set; }
    public static Legend LegendEthelrethor { get; private set; }
    public static Legend LegendNexus { get; private set; }
    public static Legend LegendKarazhan { get; private set; }
    public static Legend LegendZulfarrak { get; private set; }
    public static Legend LegendFountainofhealth { get; private set; }
    public static Legend LegendFountainofhealthWetlands { get; private set; }
    public static Legend LegendFountainofhealthFeralas { get; private set; }
    public static Legend LegendFountainofhealthTomb { get; private set; }
    public static Legend LegendFountainofhealthDalaran { get; private set; }
    public static Legend LegendFountainofblood { get; private set; }
    public static Legend LegendCentaurkhan { get; private set; }
    public static Legend LegendImmolthar { get; private set; }
    public static Legend LegendArugal { get; private set; }
    public static Legend LegendVaelastrasz { get; private set; }
    public static Legend LegendOcculus { get; private set; }
    public static Legend LegendSaragosa { get; private set; }
    public static Legend LegendCaerdarrow { get; private set; }


    public static void Setup()
    {
      LegendRagnaros = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("N00D")),
        DeathMessage = "Ragnaros, the King of Fire && Lord of the Firelands, has been extinguished."
      };

      LegendSeawitch = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("O02L"))
      };

      LegendAuchindoun = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h026"))
      };

      LegendDraktharonkeep = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o016"))
      };

      LegendOshugun = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h02Z"))
      };

      LegendJinthaalor = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o02G"))
      };

      LegendShrineofulatek = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00Q"))
      };

      LegendSeradane = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("e014"))
      };

      LegendZulgurub = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o018"))
      };

      LegendDazaralor = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00V"))
      };

      LegendGundrak = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00N"))
      };

      LegendDuskwoodgraveyard = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h01F"))
      };

      LegendGrimbatol = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h01Z"))
      };

      LegendEthelrethor = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h05I"))
      };

      LegendNexus = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h04P")),
        Capturable = true
      };

      LegendKarazhan = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h00G")),
        Capturable = true
      };

      LegendZulfarrak = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00K"))
      };

      LegendFountainofhealth = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"))
      };

      LegendFountainofhealthWetlands = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"))
      };

      LegendFountainofhealthFeralas = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"))
      };

      LegendFountainofhealthTomb = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"))
      };

      LegendFountainofhealthDalaran = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nfoh"))
      };

      LegendFountainofblood = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nbfl"))
      };

      LegendCentaurkhan = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("ncnk"))
      };

      LegendImmolthar = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("n04R"))
      };

      LegendVaelastrasz = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nrwm"))
      };

      LegendOcculus = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("O025")),
        PermaDies = true
      };

      LegendSaragosa = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("nadr"))
      };

      LegendArugal = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("Hgam"))
      };

      LegendCaerdarrow = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("u01M")),
        Capturable = true
      };
    }
  }
}