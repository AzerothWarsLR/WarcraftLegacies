namespace MacroTools.Shared;

/// <summary>
/// An arbitrary category that units can be assigned to. Primarily used to know which units need to be swapped out
/// for which when changing to another faction.
/// </summary>
public enum UnitCategory
{
  //Buildings
  TownHall,
  Keep,
  Castle,
  GilneasManor,
  Shipyard,
  Lighthouse,
  Farm,
  Altar,
  Specialist,
  Waygate,
  SiegeWorkshop,
  Barracks,
  Research,
  Magic,
  Tower,
  Shop,
  Teleport,
  FlyingBuilding,

  //Units
  Worker,
  Elite,
  Support,
  Marksman,
  Fighter,
  Flyer,
  Siege,
  Destroyer,
  Tank,
  Assassin,
  Summoner,
  AntiMage,
  AntiAir,
  Unique,
  Scout
}

public static class UnitCategoryExtensions
{
  public static string ToFriendlyString(this UnitCategory category)
  {
    switch (category)
    {
      case UnitCategory.TownHall:
        return "Town Hall";
      case UnitCategory.Keep:
        return "Keep";
      case UnitCategory.Castle:
        return "Castle";
      case UnitCategory.GilneasManor:
        return "Gilneas Manor";
      case UnitCategory.Shipyard:
        return "Shipyard";
      case UnitCategory.Lighthouse:
        return "Lighthouse";
      case UnitCategory.Farm:
        return "Food";
      case UnitCategory.Altar:
        return "Altar";
      case UnitCategory.Specialist:
        return "Specialist Production";
      case UnitCategory.Waygate:
        return "Waygate";
      case UnitCategory.SiegeWorkshop:
        return "Siege Production";
      case UnitCategory.Barracks:
        return "Troop Production";
      case UnitCategory.Research:
        return "Research";
      case UnitCategory.Magic:
        return "Caster Production";
      case UnitCategory.Tower:
        return "Defensive Tower";
      case UnitCategory.Shop:
        return "Shop";
      case UnitCategory.Teleport:
        return "Teleport";
      case UnitCategory.FlyingBuilding:
        return "Flyer Production";
      case UnitCategory.Worker:
        return "Worker";
      case UnitCategory.Elite:
        return string.Empty;
      case UnitCategory.Support:
        return "Support";
      case UnitCategory.Marksman:
        return "Marksman";
      case UnitCategory.Fighter:
        return "Fighter";
      case UnitCategory.Flyer:
        return "Flying";
      case UnitCategory.Siege:
        return "Siege";
      case UnitCategory.Destroyer:
        return "Destroyer";
      case UnitCategory.Tank:
        return "Tank";
      case UnitCategory.Assassin:
        return "Assassin";
      case UnitCategory.Summoner:
        return "Summoner";
      case UnitCategory.AntiMage:
        return "Anti-mage";
      case UnitCategory.AntiAir:
        return "Anti-air";
      case UnitCategory.Unique:
        return "Unique";
      case UnitCategory.Scout:
        return "Scout";
    }

    return category.ToString();
  }

  public static string ToFriendlyString(this List<UnitCategory> categories)
  {
    var parts = new List<string>(categories.Count);

    foreach (var category in categories)
    {
      var categoryName = category.ToFriendlyString();
      if (!string.IsNullOrEmpty(categoryName))
      {
        parts.Add(categoryName);
      }
    }

    return string.Join("/", parts);
  }
}
