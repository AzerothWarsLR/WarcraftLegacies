using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierSolarFlareRitual{

    private static void Research( ){
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(R03V), Faction.UNLIMITED)       ;//Stromgarde
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(R03W), Faction.UNLIMITED)       ;//Honor Hold
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R03U),  Research);
    }

  }
}
