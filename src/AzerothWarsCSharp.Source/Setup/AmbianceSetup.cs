using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static AzerothWarsCSharp.Source.AmbianceLibrary;

namespace AzerothWarsCSharp.Source.Setup
{
  /// <summary>
  /// Responsible for adding sound ambience to regions across the map.
  /// </summary>
  public static class AmbianceSetup
  {
    /// <summary>
    /// Adds ambient sounds to regions across the map.
    /// </summary>
    public static void Setup()
    {
      SetupEasternKingdoms();
      SetupKalimdor();
    }
    
    private static void SetupEasternKingdoms()
    {
      AddSoundToRegion(true, LordaeronSummerDay, Regions.QuelthalasAmbient);
      AddSoundToRegion(true, LordaeronSummerDay, Regions.LordaeronAmbient1);
      AddSoundToRegion(true, LordaeronSummerDay, Regions.LordaeronAmbient2);
      AddSoundToRegion(true, LordaeronSummerDay, Regions.LordaeronAmbient3);
      AddSoundToRegion(true, LordaeronSummerDay, Regions.LordaeronAmbient4);
      AddSoundToRegion(true, LordaeronSummerDay, Regions.LordaeronAmbient5);
      AddSoundToRegion(true, LordaeronSummerDay, Regions.ElwinForestAmbient);
      AddSoundToRegion(true, CityscapeDay, Regions.SunwellAmbient);
      AddSoundToRegion(true, CityscapeDay, Regions.StratholmeAmbient);
      AddSoundToRegion(true, CityscapeDay, Regions.Terenas);
      AddSoundToRegion(true, CityscapeDay, Regions.TyrHandAmbient);
      AddSoundToRegion(true, CityscapeDay, Regions.Dalaran);
      AddSoundToRegion(true, CityscapeDay, Regions.Stromgarde);
      AddSoundToRegion(true, CityscapeDay, Regions.StormwindAmbient2);
      AddSoundToRegion(true, CityscapeDay, Regions.Stromwind_antiship);
      AddSoundToRegion(true, CityscapeDay, Regions.ScarletAmbient);
      AddSoundToRegion(true, CityscapeDay, Regions.ShipAmbient);
      AddSoundToRegion(true, DalaranRuinsDay, Regions.Gilneas);
      AddSoundToRegion(true, LordaeronSummerNight, Regions.ShadowfangAmbient);
      AddSoundToRegion(true, IceCrownDay, Regions.LordamereLakeAmbient);
      AddSoundToRegion(true, IceCrownDay, Regions.BridgeAmbient);
      AddSoundToRegion(true, IceCrownDay, Regions.Aerie_Peak);
      AddSoundToRegion(true, IceCrownDay, Regions.DunmoroghAmbient1);
      AddSoundToRegion(true, IceCrownDay, Regions.DunmoroghAmbient2);
      AddSoundToRegion(true, IceCrownDay, Regions.DunmoroghAmbient3);
      AddSoundToRegion(true, IceCrownNight, Regions.IronforgeAmbient);
      AddSoundToRegion(true, LordaeronFallDay, Regions.SouthshoreAmbient);
      AddSoundToRegion(true, LordaeronFallDay, Regions.SouthshoreAmbient2);
      AddSoundToRegion(true, LordaeronFallDay, Regions.SouthshoreAmbient3);
      AddSoundToRegion(true, LordaeronFallDay, Regions.SouthshoreAmbient4);
      AddSoundToRegion(true, LordaeronFallDay, Regions.SouthshoreAmbient5);
      AddSoundToRegion(true, LordaeronFallDay, Regions.ScholomanceAmbient1);
      AddSoundToRegion(true, LordaeronFallDay, Regions.ScholomanceAmbient2);
      AddSoundToRegion(true, LordaeronFallDay, Regions.ScholomanceAmbient3);
      AddSoundToRegion(true, LordaeronFallDay, Regions.Kultiras);
      AddSoundToRegion(true, LordaeronFallDay, Regions.SentinelTowerAmbient);
      AddSoundToRegion(true, LordaeronFallDay, Regions.GrimBatolAmbient1);
      AddSoundToRegion(true, LordaeronFallDay, Regions.GrimBatolAmbient2);
      AddSoundToRegion(true, LordaeronFallNight, Regions.ZulAman_trolls);
      AddSoundToRegion(true, NorthrendDay, Regions.AlteracAmbient);
      AddSoundToRegion(true, LordaeronWinterNight, Regions.HinterlandAmbient1);
      AddSoundToRegion(true, LordaeronWinterNight, Regions.HinterlandAmbient2);
      AddSoundToRegion(true, DalaranRuinsDay, Regions.TolbaradAmbient);
      AddSoundToRegion(true, DalaranRuinsDay, Regions.UndercityUnlock);
      AddSoundToRegion(true, DalaranRuinsDay, Regions.DarkshireAmbient1);
      AddSoundToRegion(true, DalaranRuinsDay, Regions.DarkshireAmbient2);
      AddSoundToRegion(true, DalaranRuinsDay, Regions.DarkshireAmbient3);
      AddSoundToRegion(true, WetlandsNight, Regions.BalorAmbient);
      AddSoundToRegion(true, WetlandsNight, Regions.StranglethornAmbient1);
      AddSoundToRegion(true, WetlandsNight, Regions.StranglethornAmbient2);
      AddSoundToRegion(true, WetlandsNight, Regions.StranglethornAmbient3);
      AddSoundToRegion(true, BlackCitadelOutlandNight, Regions.BlastedlandAmbient);
      AddSoundToRegion(true, AshenvaleNight, Regions.SwampofSorrowsAmbient);
      AddSoundToRegion(true, AshenvaleNight, Regions.WetlandAmbient1);
      AddSoundToRegion(true, AshenvaleNight, Regions.WetlandAmbient2);
      AddSoundToRegion(true, BarrensDay, Regions.BurningSteppesAmbient);
      AddSoundToRegion(true, BarrensDay, Regions.BurningSteppeAmbient2);
      AddSoundToRegion(true, LordaeronWinterDay, Regions.LochModanAmbient);
    }

    private static void SetupKalimdor()
    {
      AddSoundToRegion(true, NorthrendNight, Regions.Northrend_Ambiance);
      AddSoundToRegion(true, NorthrendNight, Regions.Coldarra);
      AddSoundToRegion(true, DalaranRuinsNight, Regions.InstanceDalaranDungeon1);
      AddSoundToRegion(true, DalaranRuinsNight, Regions.InstanceScholomance);
      AddSoundToRegion(true, BlackCitadelOutlandNight, Regions.InstanceDireMaul);
      AddSoundToRegion(true, BlackCitadelOutlandNight, Regions.AethneumCatacombs);
      AddSoundToRegion(true, BlackCitadelOutlandNight, Regions.InstanceSargerasTomb);
      AddSoundToRegion(true, BlackCitadelOutlandDay, Regions.InstanceOutland);
      AddSoundToRegion(true, BlackCitadelOutlandDay, Regions.InstanceBlackrock);
      AddSoundToRegion(true, BlackCitadelOutlandDay, Regions.MonolithNoBuild);
      AddSoundToRegion(true, IceCrownNight, Regions.InstanceAzjolNerub);
      AddSoundToRegion(true, AshenvaleNight, Regions.TeldrassilAmbient);
      AddSoundToRegion(true, AshenvaleNight, Regions.FeralasAmbient1);
      AddSoundToRegion(true, AshenvaleNight, Regions.FeralasAmbient2);
      AddSoundToRegion(true, AshenvaleNight, Regions.RanazjarAmbient);
      AddSoundToRegion(true, AshenvaleNight, Regions.DusthallowAmbient);
      AddSoundToRegion(true, LordaeronFallDay, Regions.AzuremystAmbient);
      AddSoundToRegion(true, LordaeronFallDay, Regions.AszharaAmbient1);
      AddSoundToRegion(true, LordaeronFallDay, Regions.AzsharaAmbient2);
      AddSoundToRegion(true, LordaeronFallDay, Regions.EchoIsleAmbient);
      AddSoundToRegion(true, LordaeronFallDay, Regions.MaelstromAmbient);
      AddSoundToRegion(true, AshenvaleDay, Regions.AshenvaleAmbient);
      AddSoundToRegion(true, AshenvaleDay, Regions.AshenvaleAmbient2);
      AddSoundToRegion(true, AshenvaleDay, Regions.AshenvaleAmbient3);
      AddSoundToRegion(true, AshenvaleDay, Regions.AshenvaleAmbient4);
      AddSoundToRegion(true, BarrensDay, Regions.BarrenAmbient1);
      AddSoundToRegion(true, BarrensDay, Regions.BarrenAmbient2);
      AddSoundToRegion(true, BarrensDay, Regions.BarrenAmbient3);
      AddSoundToRegion(true, BarrensDay, Regions.BarrenAmbient4);
      AddSoundToRegion(true, BarrensDay, Regions.BarrenAmbient5);
      AddSoundToRegion(true, BarrensDay, Regions.UldumAmbiance);
      AddSoundToRegion(true, BarrensDay, Regions.AhnqirajInstance);
      AddSoundToRegion(true, DalaranRuinsDay, Regions.SilithusAmbient);
      AddSoundToRegion(true, WetlandsNight, Regions.UngoroAmbient);
      AddSoundToRegion(true, Wetlandsday, Regions.ZulfarrakAmbient);
      AddSoundToRegion(true, Wetlandsday, Regions.KezanAmbient);
      AddSoundToRegion(true, Wetlandsday, Regions.Darkspear_Island);
      AddSoundToRegion(true, Wetlandsday, Regions.Broken_Isles);
      AddSoundToRegion(true, IceCrownDay, Regions.WinterspringAmbient1);
      AddSoundToRegion(true, IceCrownDay, Regions.WinterspringAmbient2);
    }
  }
}