namespace Launcher.DataTransferObjects
{
  public class MapUnitsDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public bool UseNewFormat { get; set; }
    public Units[] Units { get; set; }
  }

  public class Units
  {
    public int Flags { get; set; }
    public int OwnerId { get; set; }
    public int Unk1 { get; set; }
    public int Unk2 { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int GoldAmount { get; set; }
    public int TargetAcquisition { get; set; }
    public int HeroLevel { get; set; }
    public int HeroStrength { get; set; }
    public int HeroAgility { get; set; }
    public int HeroIntelligence { get; set; }
    public InventoryData[] InventoryData { get; set; }
    public AbilityData[] AbilityData { get; set; }
    public RandomData RandomData { get; set; }
    public int CustomPlayerColorId { get; set; }
    public int WaygateDestinationRegionId { get; set; }
    public int TypeId { get; set; }
    public int Variation { get; set; }
    public Position Position { get; set; }
    public double Rotation { get; set; }
    public Scale Scale { get; set; }
    public int SkinId { get; set; }
    public int MapItemTableId { get; set; }
    public ItemTableSets[] ItemTableSets { get; set; }
    public int CreationNumber { get; set; }
  }

  public class InventoryData
  {
    public int Slot { get; set; }
    public int ItemId { get; set; }
  }

  public class AbilityData
  {
    public int AbilityId { get; set; }
    public bool IsAutocastActive { get; set; }
    public int HeroAbilityLevel { get; set; }
  }

  public class RandomData
  {
  }

  public class Position
  {
  }

  public class Scale
  {
  }

  public class ItemTableSets
  {
    public Items[] Items { get; set; }
  }

  public class Items
  {
    public int Chance { get; set; }
    public int ItemId { get; set; }
  }
}