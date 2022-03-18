namespace AzerothWarsCSharp.Source.RoC.Researches.Lordaeron
{
  public class VeteranFootmen{

  
    private const int RESEARCH_ID = FourCC(R00B);
  

    private static void Research( ){
      FACTION_LORDAERON.ModObjectLimit(FourCC(hfoo), -UNLIMITED)  ;//Footman
      FACTION_LORDAERON.ModObjectLimit(FourCC(h029), UNLIMITED)   ;//Veteran Footman
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(RESEARCH_ID,  Research);
    }

  }
}
