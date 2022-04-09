using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierExpeditionSurvivors{

    private static void Research( ){
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(h00A), -Faction.UNLIMITED)     ;//Spearman
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(h05N), Faction.UNLIMITED)      ;//Marksman
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R031),  Research);
    }

  }
}
