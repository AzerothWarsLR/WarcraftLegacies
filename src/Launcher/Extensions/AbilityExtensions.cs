using War3Api.Object;
using War3Api.Object.Abilities;

namespace Launcher.Extensions
{
  public static class AbilityExtensions
  {
    public static bool HasVisibleIcon(this Ability ability)
    {
      return ability is not (InventoryPackMule or Inventory2SlotUnitHuman or Inventory2SlotUnitOrc or Inventory2SlotUnitUndead
        or Inventory2SlotUnitNightElf or Invulnerable or DefenseBonus1 or Ultravision or SellItem or AlliedBuilding or 
        PurchaseItem or LightningAttack or Inventory or AttributeModifierSkill or OrbOfCorruption);
    }

    /// <summary>
    /// Determines the order that abilities appear in tooltips.
    /// </summary>
    public static int GetPriority(this Ability ability)
    {
        var (x, y) = (ability.ArtButtonPositionNormalX, ability.ArtButtonPositionNormalY);
        return x - y * 10;
    }
  }
}