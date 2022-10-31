using System;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.ArtifactSystem;
using WarcraftLegacies.MacroTools.Extensions;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using WCSharp.Events;
using static War3Api.Common;


namespace WarcraftLegacies.Source.ArtifactBehaviour
{
  public static class ZinrokhAssembly
  {
    private const float DUMMY_X = 22700;
    private const float DUMMY_Y = 23734;

    private static void Consume(int whichItemId)
    {
      Artifact tempArtifact = ArtifactManager.GetFromTypeId(whichItemId);
      SetItemPosition(tempArtifact.Item, DUMMY_X, DUMMY_Y);
      tempArtifact.LocationType = ArtifactLocationType.Hidden;
      tempArtifact.LocationDescription = "Used to create the Demon Soul";
    }

    private static void ItemPickup()
    {
      unit triggerUnit = GetTriggerUnit();
      if (triggerUnit.GetInventoryIndexOfItemType(FourCC("I01J")) > 0 &&
          triggerUnit.GetInventoryIndexOfItemType(FourCC("I01K")) > 0 &&
          triggerUnit.GetInventoryIndexOfItemType(FourCC("I01M")) > 0 &&
          triggerUnit.GetInventoryIndexOfItemType(FourCC("I01I")) > 0 &&
          triggerUnit.GetInventoryIndexOfItemType(FourCC("I01L")) > 0)
      {
        Consume(FourCC("I01J"));
        Consume(FourCC("I01K"));
        Consume(FourCC("I01M"));
        Consume(FourCC("I01I"));
        Consume(FourCC("I01L"));

        if (ArtifactSetup.ArtifactZinrokh != null)
        {
          ArtifactManager.Register(ArtifactSetup.ArtifactZinrokh);
          triggerUnit.AddItemSafe(ArtifactSetup.ArtifactZinrokh.Item);
          DisplayTextToPlayer(GetLocalPlayer(), 0, 0, $"{GetTriggerPlayer().GetFaction()?.ColoredName} |r has assembled Zin'rokh, Destroyer of Worlds!");
          return;
        }

        throw new InvalidOperationException("Tried to register Zik'rokh but it does not exist.");
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