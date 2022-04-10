using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierCodeOfChivalry{

    private static void Research( ){
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("h01B"), -Faction.UNLIMITED)      ;//Outrider
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("h054"), Faction.UNLIMITED)       ;//Stormwind Knight
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC("R030"),  Research);
    }

  }
}
