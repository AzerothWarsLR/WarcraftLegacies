using War3Api.Object.Enums;

namespace AzerothWarsCSharp.ObjectFactory
{
  public class Faction
  {
    public string Name { get; set; }
    public UnitRace Race { get; set; }
    public bool IsCampaign { get; set; }
  }
}