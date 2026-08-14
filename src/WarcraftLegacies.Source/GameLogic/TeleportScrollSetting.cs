using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

public static class TeleportScrollSetting
{
  private const int StockAmount = 2;

  private static readonly int[] _factionShopUnitTypes =
  {
    UNIT_UTOM_TOMB_OF_RELICS_SCOURGE_SHOP,
    UNIT_U01I_CHAMBER_OF_WONDERS_CTHUN_SHOP,
    UNIT_U015_UNHOLY_RELIQUARY_LEGION_SHOP,
    UNIT_U00Q_TREASURY_FEL_SHOP,
    UNIT_OVLN_VOODOO_LOUNGE_FROSTWOLF_SHOP,
    UNIT_O057_VAULT_OF_RELICS_DRAENEI_SHOP,
    UNIT_O03X_AUCTION_HOUSE_CREEP_SHOP,
    UNIT_O01T_TREASURE_HOARD_WARSONG_SHOP,
    UNIT_NMRK_MARKETPLACE_LORDAERON_SHOP,
    UNIT_NMRB_STEAMVAULT_ILLIDARI_SHOP,
    UNIT_N0D8_VENDOR_HALL_SCARLET_SHOP,
    UNIT_N0B2_OMINOUS_VAULT_NZOTH_SHOP,
    UNIT_N07T_AUCTION_HOUSE_STORMWIND_SHOP,
    UNIT_N07J_FORGE_OF_WISHES_SKYWALL_SHOP,
    UNIT_N07H_TRADE_HOUSE_KULTIRAS_SHOP,
    UNIT_N008_TRADE_HOUSE_GILNEAS_SHOP,
    UNIT_N07U_EXPLORER_S_VAULT_IRONFORGE_SHOP,
    UNIT_HVLT_ARCANE_VAULT_DALARAN_SHOP,
    UNIT_H04V_ARCANE_VAULT_QUELTHALAS_SHOP,
    UNIT_H0CC_SHAPER_S_HALL_SUNFURY_SHOP,
    UNIT_H086_FIELD_STOCKPILE_SCARLET_SHOP,
    UNIT_EDEN_DEN_OF_WONDERS_SENTINELS_SHOP,
    UNIT_E019_ANCIENT_OF_WONDERS_DRUIDS_SHOP
  };

  private static bool _globalScrollsEnabled;

  public static void Setup()
  {
    foreach (var unitTypeId in _factionShopUnitTypes)
    {
      PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingConstructed,
        () => SeedShop(@event.Unit, _globalScrollsEnabled ? ITEM_I005_SCROLL_OF_TELEPORTATION : ITEM_STWP_TOWN_PORTAL_SCROLL),
        unitTypeId);
    }

    PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingConstructed,
      () =>
      {
        if (_globalScrollsEnabled)
        {
          SwapToGlobalVariant(@event.Unit);
        }
      },
      UNIT_NGME_GOBLIN_MERCHANT);
  }

  public static void SeedNormalScrolls()
  {
    SeedShopsOfTypes(_factionShopUnitTypes, ITEM_STWP_TOWN_PORTAL_SCROLL);
  }

  public static void EnableGlobalScrolls()
  {
    _globalScrollsEnabled = true;
    SeedShopsOfTypes(_factionShopUnitTypes, ITEM_I005_SCROLL_OF_TELEPORTATION);
    SwapGoblinMerchantsToGlobalVariant();
  }

  private static void SwapGoblinMerchantsToGlobalVariant()
  {
    foreach (var shop in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds))
    {
      if (shop.UnitType == UNIT_NGME_GOBLIN_MERCHANT)
      {
        SwapToGlobalVariant(shop);
      }
    }
  }

  private static void SwapToGlobalVariant(unit shop)
  {
    var position = shop.GetPosition();
    var owner = shop.Owner;
    var facing = shop.Facing;
    shop.Dispose();
    unit.Create(owner, UNIT_NGM2_GOBLIN_MERCHANT, position.X, position.Y, facing);
  }

  private static void SeedShopsOfTypes(int[] unitTypeIds, int scrollItemId)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRect(Rectangle.WorldBounds))
    {
      foreach (var unitTypeId in unitTypeIds)
      {
        if (unit.UnitType == unitTypeId)
        {
          SeedShop(unit, scrollItemId);
          break;
        }
      }
    }
  }

  private static void SeedShop(unit shop, int scrollItemId)
  {
    AddItemToStock(shop, scrollItemId, StockAmount, StockAmount);
  }
}
