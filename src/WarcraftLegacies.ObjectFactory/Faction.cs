using War3Api.Object.Enums;

namespace WarcraftLegacies.ObjectFactory
{
  public class Faction
  {
    public string Name { get; set; }
    public UnitRace Race { get; set; }
    public bool IsCampaign { get; set; }
  }
}