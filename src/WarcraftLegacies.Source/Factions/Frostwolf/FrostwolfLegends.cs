using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.Frostwolf;

public sealed class FrostwolfLegends
{
  public Capital ThunderBluff { get; }
  public Capital DarkspearHold { get; }

  public FrostwolfLegends()
  {
    ThunderBluff = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O00J_THUNDER_BLUFF_FROSTWOLF_OTHER),
      Capturable = true,
      DeathMessage =
        "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
      Essential = true
    };

    DarkspearHold = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O02D_DARKSPEAR_HOLD_FROSTWOLF_OTHER),
      Essential = true
    };
  }

  public void RegisterLegends()
  {
    CapitalManager.Register(ThunderBluff);
    CapitalManager.Register(DarkspearHold);
  }
}
