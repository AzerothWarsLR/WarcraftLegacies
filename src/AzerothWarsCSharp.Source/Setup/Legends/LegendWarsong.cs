using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendWarsong
  {
    public static Legend? GromHellscream { get; private set; }
    public static Legend? Jergosh { get; private set; }
    public static Legend? Mannoroth { get; private set; }
    public static Legend? StonemaulKeep { get; private set; }
    public static Legend? WarsongEncampment { get; private set; }
    public static Legend? ChenStormstout { get; private set; }
    public static Legend? Saurfang { get; private set; }
    
    public static void Setup()
    {
      ChenStormstout = new Legend
      {
        UnitType = Constants.UNIT_NSJS_BREWMASTER_WARSONG,
        StartingXp = 1000
      };
      Legend.Register(ChenStormstout);

      Saurfang = new Legend
      {
        UnitType = Constants.UNIT_OBLA_HIGH_OVERLORD_OF_THE_KOR_KRON_VASSAL,
        StartingXp = 2800
      };
      Legend.Register(Saurfang);

      Jergosh = new Legend
      {
        UnitType = Constants.UNIT_OTHS_INVOKER_OF_THE_SEARING_BLADE_WARSONG_BLOODPACT
      };
      Legend.Register(Jergosh);

      Mannoroth = new Legend
      {
        UnitType = Constants.UNIT_NMAN_THE_DESTRUCTOR_WARSONG_BLOODPACT
      };
      Legend.Register(Mannoroth);

      StonemaulKeep = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_O004_STONEMAUL_KEEP),
        DeathMessage = "The fortress of the Stonemaul Clan has fallen."
      };
      Legend.Register(StonemaulKeep);

      WarsongEncampment = new Legend();
      Legend.Register(WarsongEncampment);

      GromHellscream = new Legend
      {
        UnitType = Constants.UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_WARSONG
      };
      Legend.Register(GromHellscream);
    }
  }
}