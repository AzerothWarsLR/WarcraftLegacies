//using WCSharp.Events;
//using static War3Api.Common;
//using static War3Api.Blizzard;
//using AzerothWarsCSharp.Source.Libraries;

//namespace AzerothWarsCSharp.Source.GameLogic
//{
//  public static class DemonSoulAssembly
//  {
//    private static int[] _fragmentTypes = new int[] {
//      Constants.ITEM_I01I_AZURE_DEMON_SOUL_FRAGMENT,
//      Constants.ITEM_I01J_RUBY_DEMON_SOUL_FRAGMENT,
//      Constants.ITEM_I01K_EMERALD_DEMON_SOUL_FRAGMENT,
//      Constants.ITEM_I01L_OBSIDIAN_DEMON_SOUL_FRAGMENT,
//      Constants.ITEM_I01M_BRONZE_DEMON_SOUL_FRAGMENT,
//    };

//    private static bool UnitHasAllShards(unit whichUnit)
//    {
//      foreach (var fragment in _fragmentTypes)
//      {
//        if (!UnitHasItemOfTypeBJ(whichUnit, fragment))
//        {
//          return false;
//        };
//      }
//      return true;
//    }

//    private static void OnShardPickedUp()
//    {
//      var triggerUnit = GetTriggerUnit();
//      if (UnitHasAllShards(triggerUnit))
//      {
//        foreach (var fragment in _fragmentTypes)
//        {
//          RemoveItem(GetItemOfTypeFromUnitBJ(triggerUnit, fragment));
//          UnitAddItem(triggerUnit, CreateItem(Constants.ITEM_I01A_DEMON_SOUL, GetUnitX(triggerUnit), GetUnitY(triggerUnit)));
//          var triggerFaction = Faction.ByPlayerHandle(GetOwningPlayer(triggerUnit));
//          DisplayTextToForce(bj_FORCE_ALL_PLAYERS, triggerFaction.ColoredName + "|r has assembled the Demon Soul!");
//        }
//      }
//    }

//    public static void Initialize()
//    {
//      foreach (var fragment in _fragmentTypes)
//      {
//        PlayerUnitEvents.Register(PlayerUnitEvent.ItemTypeIsPickedUp, OnShardPickedUp, fragment);
//      }
//    }
//  }
//}
