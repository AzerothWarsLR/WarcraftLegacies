using War3Api.Object;
using War3Api.Object.Abilities;

namespace Launcher.Extensions
{
  public static class AbilityExtensions
  {
    public static bool HasVisibleIcon(this Ability ability)
    {
      if (ability.ArtButtonPositionNormalY == -11)
        return false;
      
      return ability is not (InventoryPackMule or Inventory2SlotUnitHuman or Inventory2SlotUnitOrc or Inventory2SlotUnitUndead
        or Inventory2SlotUnitNightElf or Invulnerable or DefenseBonus1 or Ultravision or SellItem or AlliedBuilding or 
        PurchaseItem or LightningAttack or Inventory or AttributeModifierSkill or OrbOfCorruption or ReinforcedBurrows
        or SpikedBarricades or BlightDispelSmall or BlightDispelLarge or CargoHoldBurrow or CargoHoldDeath
        or CargoHoldDevour or CargoHoldShip or CargoHoldTank or CargoHoldTransport or CargoHoldGoldMine
        or CargoHoldMeatWagon or AuraRegenerationStatue or TreeOfLifeForAttachingArt or ChaosGrom or ChaosGrunt
        or ChaosPeon or ChaosKodo or ChaosRaider or ChaosShaman or ChaosCargoLoad);
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