using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;

using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Artifacts
{
  public static class ZinrokhAssembly
  {
    private const float DUMMY_X = 22700;
    private const float DUMMY_Y = 23734;

    private static void Consume(int whichItemId)
    {
      Artifact tempArtifact = ArtifactManager.GetFromTypeId(whichItemId);
      SetItemPosition(tempArtifact.Item, DUMMY_X, DUMMY_Y);
      tempArtifact.Status = ArtifactStatus.Hidden;
      tempArtifact.Description = "Used to create the Demon Soul";
    }

    private static void ItemPickup()
    {
      unit triggerUnit = GetTriggerUnit();
      if (GetInventoryIndexOfItemTypeBJ(triggerUnit, FourCC("I01J")) > 0 &&
          GetInventoryIndexOfItemTypeBJ(triggerUnit, FourCC("I01K")) > 0 &&
          GetInventoryIndexOfItemTypeBJ(triggerUnit, FourCC("I01M")) > 0 &&
          GetInventoryIndexOfItemTypeBJ(triggerUnit, FourCC("I01I")) > 0 &&
          GetInventoryIndexOfItemTypeBJ(triggerUnit, FourCC("I01L")) > 0)
      {
        Consume(FourCC("I01J"));
        Consume(FourCC("I01K"));
        Consume(FourCC("I01M"));
        Consume(FourCC("I01I"));
        Consume(FourCC("I01L"));
        var zinrokh = ArtifactManager.GetFromTypeId(FourCC("I016"));
        UnitAddItemSafe(triggerUnit, zinrokh.Item);
        DisplayTextToForce(bj_FORCE_ALL_PLAYERS,
          GetTriggerPlayer().GetFaction()?.ColoredName + "|r has assembled Zin'rokh, Destroyer of Worlds!");
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypePicksUpItem, ItemPickup, FourCC("I01J"));
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypePicksUpItem, ItemPickup, FourCC("I01K"));
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypePicksUpItem, ItemPickup, FourCC("I01M"));
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypePicksUpItem, ItemPickup, FourCC("I01I"));
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypePicksUpItem, ItemPickup, FourCC("I01L"));
    }
  }
}