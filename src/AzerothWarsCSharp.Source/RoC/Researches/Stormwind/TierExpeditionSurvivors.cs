namespace AzerothWarsCSharp.Source.RoC.Researches.Stormwind
{
  public class TierExpeditionSurvivors{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(h00A), -UNLIMITED)     ;//Spearman
      FACTION_STORMWIND.ModObjectLimit(FourCC(h05N), UNLIMITED)      ;//Marksman
    }

    private static void OnInit( ){
      RegisterResearchFinishedAction(FourCC(R031),  Research);
    }

  }
}
