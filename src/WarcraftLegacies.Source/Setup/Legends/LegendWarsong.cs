using MacroTools;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendWarsong
  {
    public static LegendaryHero? GromHellscream { get; private set; }
    public static Capital? StonemaulKeep { get; private set; }
    public static Capital? WarsongEncampment { get; private set; }
    public static LegendaryHero? ChenStormstout { get; private set; }
    public static LegendaryHero? Saurfang { get; private set; }
    
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      ChenStormstout = new LegendaryHero("Chen Stormstout")
      {
        UnitType = Constants.UNIT_NSJS_BREWMASTER_WARSONG,
        StartingXp = 1000
      };
      LegendaryHeroManager.Register(ChenStormstout);

      Saurfang = new LegendaryHero("Varok Saurfang")
      {
        UnitType = Constants.UNIT_OBLA_HIGH_OVERLORD_OF_THE_KOR_KRON_VASSAL,
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(Saurfang);

      StonemaulKeep = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_O004_STONEMAUL_KEEP),
        DeathMessage = "The fortress of the Stonemaul Clan has fallen."
      };
      CapitalManager.Register(StonemaulKeep);

      WarsongEncampment = new Capital();
      CapitalManager.Register(WarsongEncampment);

      GromHellscream = new LegendaryHero("Grom Hellscream")
      {
        UnitType = Constants.UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_WARSONG,
        StartingArtifactItemTypeIds = new[]
        {
          Constants.ITEM_I01V_GOREHOWL
        }
      };
      LegendaryHeroManager.Register(GromHellscream);
    }
  }
}