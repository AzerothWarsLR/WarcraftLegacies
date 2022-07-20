using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.UnitEffects;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendScourge
  {
    public static Legend? LegendKelthuzad { get; private set; }
    public static Legend? LegendAnubarak { get; private set; }
    public static Legend? LegendRivendare { get; private set; }
    public static Legend? LegendLichking { get; private set; }
    public static Legend? LegendUtgarde { get; private set; }
    public static Legend? Naxxramas { get; private set; }

    public static int UnittypeKelthuzadNecromancer { get; } = FourCC("U001");
    public static int UnittypeKelthuzadGhost { get; } = FourCC("U00M");
    public static int UnittypeKelthuzadLich { get; } = FourCC("Uktl");

    public static void Setup()
    {
      LegendKelthuzad = new Legend
      {
        UnitType = FourCC("U001"),
        PermaDies = true,
        DeathMessage =
          "Kel'thuzad has been slain. He lives on in spectral form, and may yet return if (he is brought to the Sunwell.",
        DeathSfx = "Abilities\\Spells\\Undead\\DeathCoil\\DeathCoilSpecialArt.mdl",
        StartingXp = 1000,
        Name = "Kel'thuzad"
      };
      Legend.Register(LegendKelthuzad);

      LegendAnubarak = new Legend
      {
        UnitType = FourCC("Uanb")
      };
      Legend.Register(LegendAnubarak);

      LegendRivendare = new Legend
      {
        UnitType = FourCC("U00A"),
        StartingXp = 1000
      };
      Legend.Register(LegendRivendare);

      LegendUtgarde = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h00O")),
        Capturable = true
      };
      Legend.Register(LegendUtgarde);

      LegendLichking = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("u000")),
        Hivemind = true,
        DeathMessage =
          "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue."
      };
      Legend.Register(LegendLichking);
      SetUnitInvulnerable(LegendLichking.Unit, true);

      Naxxramas = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_U01X_HEART_OF_NAXXRAMAS)
      };
      Legend.Register(Naxxramas);
      SetUnitInvulnerable(Naxxramas.Unit, true);
      SetUnitTimeScale(Naxxramas.Unit, 0);
    }
  }
}