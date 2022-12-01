using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Researches.Stormwind
{
  public static class TierMagesOfStromgarde
  {
    private const int UnittypePortal = Constants.UNIT_N09P_PORTAL_STORMWIND;
    private const float WaygateOffset = 100;
    private static destructable? _destructableA;
    private static destructable? _destructableB;

    private static void EnablePortals()
    {
      var waygateA = CreateUnit(StormwindSetup.Stormwind.Player, UnittypePortal, _destructableA.GetPosition().X,
        _destructableA.GetPosition().Y, 94.14f);

      
      var waygateB = CreateUnit(StormwindSetup.Stormwind.Player, UnittypePortal, _destructableB.GetPosition().X,
        _destructableB.GetPosition().Y, 91.71f);

      SetUnitPathing(waygateA, false);
      SetUnitPathing(waygateB, false);

      var polarOffsetA = WCSharp.Shared.Util.PositionWithPolarOffset(GetUnitX(waygateB), GetUnitY(waygateB),
        WaygateOffset, GetUnitFacing(waygateB));
      waygateA.SetWaygateDestination(new Point(polarOffsetA.x, polarOffsetA.y));

      var polarOffsetB = WCSharp.Shared.Util.PositionWithPolarOffset(GetUnitX(waygateA), GetUnitY(waygateA),
        WaygateOffset, GetUnitFacing(waygateA));
      waygateB.SetWaygateDestination(new Point(polarOffsetB.x, polarOffsetB.y));

      QueueUnitAnimation(waygateA, "birth");
      QueueUnitAnimation(waygateB, "birth");
      QueueUnitAnimation(waygateA, "stand");
      QueueUnitAnimation(waygateB, "stand");
    }

    private static void Research()
    {
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("R03X"), Faction.UNLIMITED); //High Sorcerer Andromath
      StormwindSetup.Stormwind.ModObjectLimit(FourCC("R03Y"), Faction.UNLIMITED); //Katrana Prestor
      EnablePortals();
    }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      _destructableA = preplacedUnitSystem.GetDestructable(FourCC("B017"), new Point(8611, -11985));
      _destructableB = preplacedUnitSystem.GetDestructable(FourCC("B017"), Regions.Stromgarde.Center);
      PlayerUnitEvents.Register(ResearchEvent.IsFinished, Research,
        Constants.UPGRADE_R03V_MAGES_OF_STROMGARDE_ARATHOR_T2);
    }
  }
}