using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierVeteranGuard{

    private static void Research( ){
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(h03K), -Faction.UNLIMITED)      ;//Marshal
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(h03U), 12)              ;//Marshal (Defensive)
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(R03B), Faction.UNLIMITED)       ;//Exploit Weakness
      StormwindSetup.Stormwind.ModObjectLimit(FourCC(R02Z), Faction.UNLIMITED)       ;//Reflective Plating
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R03D),  Research);
    }

  }
}
