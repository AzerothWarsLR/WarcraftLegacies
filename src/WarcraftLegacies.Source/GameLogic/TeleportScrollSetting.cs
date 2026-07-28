using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Controls the Teleport Scroll Options Custom Options vote. Normal mode leaves every faction shop selling the
/// owned-structure-only Town Portal Scroll (<c>stwp</c>) and the Goblin Merchant (<c>ngme</c>) selling its
/// original, stock-delayed Scroll of Teleportation (<c>I000</c>) unchanged. Global mode swaps every faction
/// shop's scroll for the unrestricted <c>I005</c> clone, and swaps every Goblin Merchant for <c>ngm2</c>, a
/// dedicated clone that's identical except <c>I005</c> is baked in statically in place of <c>I000</c>.
/// </summary>
/// <remarks>
/// Every faction shop's real item list (potions, scrolls, faction-specific items) is static Object Editor data
/// and is left untouched - only the restricted scroll was removed from each shop's static field (see the
/// corresponding <c>mapdata/WarcraftLegacies/UnitData/*.json</c>), so seeding a faction shop only ever needs one
/// <see cref="AddItemToStock"/> call.
/// <para/>
/// WC3 shops have a hard cap of 11 total stock items (static + triggered combined); every faction shop here has
/// 7-10 static items after the scroll was removed, so seeding the scroll leaves it comfortably under the cap.
/// <para/>
/// The Goblin Merchant is handled differently: it's swapped to a whole separate unit type
/// (<c>UNIT_NGM2_GOBLIN_MERCHANT</c>) rather than having its scroll trigger-added, because every trigger-based
/// approach that was tried turned out to be unreliable for reproducing <c>I000</c>'s original ~25 minute
/// purchase restriction once it's not statically present:
/// <list type="number">
/// <item><c>isst</c> (Stock Start Delay) only appears to apply to items present in a shop's static item list at
/// map load - a shop with no static scroll at all, seeded purely via <see cref="AddItemToStock"/>, makes
/// <c>I000</c> purchasable immediately regardless of <c>isst</c>.</item>
/// <item>The item's <c>ureq</c> (Requirements) field, pointed at a tech, does NOT gate a shop purchase the way
/// it gates unit training - confirmed in-game purchasable/usable immediately despite the required tech being
/// unresearched.</item>
/// <item>A code-only delay (withholding <see cref="AddItemToStock"/> until a target turn via
/// <c>GameTimeManager.RegisterOnTurn</c>) worked, but leaves the scroll entirely absent from the shop until it
/// unlocks, which reads as unintuitive/buggy rather than "temporarily out of stock".</item>
/// </list>
/// Swapping to a second, fully-static unit type sidesteps all of the above - both <c>ngme</c> and <c>ngm2</c>
/// behave exactly like every other shop always has, since neither ever has a scroll trigger-added to it.
/// <para/>
/// The seeding sweep must NOT run from <see cref="Setup"/> for shops/merchants that already exist - at that
/// point in <c>GameSetup.Setup()</c>, faction starting buildings don't exist in the world yet, so a sweep there
/// would find nothing. <see cref="Setup"/> only registers <c>FinishesBeingConstructed</c> hooks for shops built
/// after this point; <see cref="SeedNormalScrolls"/>/<see cref="EnableGlobalScrolls"/> handle the sweep for
/// shops that already exist, called from the vote's <c>OnChosen</c> callbacks (see
/// <c>CustomOptionsSelection.BuildCategories</c>), which fire well after every faction's starting buildings
/// exist.
/// </remarks>
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

  /// <summary>
  /// Registers hooks so any of these shops/merchants built after this point are handled too. Does NOT seed or
  /// swap existing ones - see the remarks on this class for why that has to wait for the vote to resolve.
  /// </summary>
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

  /// <summary>
  /// Seeds every existing faction shop with the Town Portal Scroll. The Goblin Merchant needs no action - it
  /// already sells its original <c>I000</c> unmodified. Called when the Teleport Scroll Options vote resolves
  /// to Normal.
  /// </summary>
  public static void SeedNormalScrolls()
  {
    SeedShopsOfTypes(_factionShopUnitTypes, ITEM_STWP_TOWN_PORTAL_SCROLL);
  }

  /// <summary>
  /// Seeds every existing faction shop with the unrestricted <c>I005</c> scroll, and swaps every existing
  /// Goblin Merchant for its <c>ngm2</c> Global-mode variant. Called when the Teleport Scroll Options vote
  /// resolves to Global.
  /// </summary>
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
