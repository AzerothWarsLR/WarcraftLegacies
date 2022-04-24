using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
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
        Unit = PreplacedUnitSystem.GetUnit(FourCC("N00D")),
        DeathMessage = "Ragnaros, the King of Fire and Lord of the Firelands, has been extinguished."
      };
      Legend.Register(LegendRagnaros);

      LegendSeawitch = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("O02L"))
      };
      Legend.Register(LegendSeawitch);

      LegendAuchindoun = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h026"))
      };
      Legend.Register(LegendAuchindoun);

      LegendDraktharonkeep = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o016"))
      };
      Legend.Register(LegendDraktharonkeep);

      LegendOshugun = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h02Z"))
      };
      Legend.Register(LegendOshugun);

      LegendJinthaalor = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o02G"))
      };
      Legend.Register(LegendJinthaalor);

      LegendShrineofulatek = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o00Q"))
      };
      Legend.Register(LegendShrineofulatek);

      LegendSeradane = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("e014"))
      };
      Legend.Register(LegendSeradane);

      LegendZulgurub = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o018"))
      };
      Legend.Register(LegendZulgurub);

      LegendDazaralor = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o00V"))
      };
      Legend.Register(LegendDazaralor);

      LegendGundrak = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o00N"))
      };
      Legend.Register(LegendGundrak);

      LegendDuskwoodgraveyard = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h01F"))
      };
      Legend.Register(LegendDuskwoodgraveyard);

      LegendGrimbatol = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h01Z"))
      };
      Legend.Register(LegendGrimbatol);

      LegendEthelrethor = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h05I"))
      };
      Legend.Register(LegendEthelrethor);

      LegendNexus = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h04P")),
        Capturable = true
      };
      Legend.Register(LegendNexus);

      LegendKarazhan = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h00G")),
        Capturable = true
      };
      Legend.Register(LegendKarazhan);

      LegendZulfarrak = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o00K"))
      };
      Legend.Register(LegendZulfarrak);

      LegendFountainofhealth = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nfoh"))
      };
      Legend.Register(LegendFountainofhealth);

      LegendFountainofhealthWetlands = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nfoh"))
      };
      Legend.Register(LegendFountainofhealthWetlands);

      LegendFountainofhealthFeralas = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nfoh"))
      };
      Legend.Register(LegendFountainofhealthFeralas);

      LegendFountainofhealthTomb = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nfoh"))
      };
      Legend.Register(LegendFountainofhealthTomb);

      LegendFountainofhealthDalaran = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nfoh"))
      };
      Legend.Register(LegendFountainofhealthDalaran);

      LegendFountainofblood = new Legend
      {
        Capturable = true,
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nbfl"))
      };
      Legend.Register(LegendFountainofblood);

      LegendCentaurkhan = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("ncnk"))
      };
      Legend.Register(LegendCentaurkhan);

      LegendImmolthar = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("n04R"))
      };
      Legend.Register(LegendImmolthar);

      LegendVaelastrasz = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nrwm"))
      };
      Legend.Register(LegendVaelastrasz);

      LegendOcculus = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("O025")),
        PermaDies = true
      };
      Legend.Register(LegendOcculus);

      LegendSaragosa = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("nadr"))
      };
      Legend.Register(LegendSaragosa);

      LegendCaerdarrow = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("u01M")),
        Capturable = true
      };
      Legend.Register(LegendCaerdarrow);
    }
  }
}