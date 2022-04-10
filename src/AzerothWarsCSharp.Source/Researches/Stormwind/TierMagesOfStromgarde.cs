using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierMagesOfStromgarde{

  
    private const int UNITTYPE_PORTAL = FourCC("n09P");
    private const float WAYGATE_OFFSET = 100;
  

    private static void EnablePortals( ){


      SetUnitPathing(waygateA, false);
      SetUnitPathing(waygateB, false);


      WaygateActivate(waygateA, true);
      WaygateActivate(waygateB, true);
      WaygateSetDestination(waygateA, GetPolarOffsetX(GetUnitX(waygateB), WAYGATE_OFFSET, GetUnitFacing(waygateB)), GetPolarOffsetY(GetUnitY(waygateB), WAYGATE_OFFSET, GetUnitFacing(waygateB)));
      WaygateSetDestination(waygateB, GetPolarOffsetX(GetUnitX(waygateA), WAYGATE_OFFSET, GetUnitFacing(waygateA)), GetPolarOffsetY(GetUnitY(waygateA), WAYGATE_OFFSET, GetUnitFacing(waygateA)));
      QueueUnitAnimation(waygateA, "birth");
      QueueUnitAnimation(waygateB, "birth");
      QueueUnitAnimation(waygateA, "stand");
      QueueUnitAnimation(waygateB, "stand");
    }

    private static void Research( ){
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("R03X"), Faction.UNLIMITED)       ;//High Sorcerer Andromath
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("R03Y"), Faction.UNLIMITED)       ;//Katrana Prestor
      EnablePortals();
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC("R03V"),  Research);
    }

  }
}
