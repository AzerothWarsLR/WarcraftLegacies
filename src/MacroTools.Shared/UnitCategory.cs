namespace MacroTools.Shared;

/// <summary>
/// An arbitrary category that units can be assigned to. Primarily used to know which units need to be swapped out
/// for which when changing to another faction.
/// </summary>
public enum UnitCategory
{
  //Buildings
  TownHall,
  GilneasManor,
  Shipyard,
  LightHouse,
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
  Assassin
}
