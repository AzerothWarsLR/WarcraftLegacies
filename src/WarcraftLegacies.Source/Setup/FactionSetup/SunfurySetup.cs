using MacroTools;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class SunfurySetup
  {
    public static Faction? Sunfury { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Sunfury = new Faction(FactionNames.Sunfury, PLAYER_COLOR_MAROON, "|cffff0000",
          "ReplaceableTextures\\CommandButtons\\BTNBloodMage2.blp")
      {
        StartingGold = 200,
        StartingLumber = 700,
        CinematicMusic = "BloodElfTheme",
        FoodMaximum = 250,
        ControlPointDefenderUnitTypeId = Constants.UNIT_N0BC_CONTROL_POINT_DEFENDER_QUELTHALAS,
        IntroText = @"You are playing as the power-hungry |cffff0000Sunfury|r.

You begin in Tranquilien, separated from Silvermoon.
The Trolls of Zul'Aman have laid siege to the city, and are preparing attacks on your base.

Train soldiers to repel the attacks, then gather enough strength to besiege Zul'Aman and take the head of Zul'jin.

The Plague of Undeath is coming and Lordaeron will need your help with the Scourge soon. Be ready to join them as once you have secured Silvermoon and dealt with the Amani invasion."
      };

      //Structures
      Sunfury.ModObjectLimit(FourCC("h02P"), Faction.UNLIMITED); //t1
      Sunfury.ModObjectLimit(FourCC("h0C4"), Faction.UNLIMITED); //t2
      Sunfury.ModObjectLimit(FourCC("h0C5"), Faction.UNLIMITED); //t3
      Sunfury.ModObjectLimit(FourCC("h0C7"), Faction.UNLIMITED); //house
      Sunfury.ModObjectLimit(FourCC("h0C8"), Faction.UNLIMITED); //forge
      Sunfury.ModObjectLimit(FourCC("h0C9"), Faction.UNLIMITED); //barrack
      Sunfury.ModObjectLimit(FourCC("h0CB"), Faction.UNLIMITED); //magic
      Sunfury.ModObjectLimit(FourCC("h0CA"), Faction.UNLIMITED); //VOid Well
      Sunfury.ModObjectLimit(FourCC("h0CI"), Faction.UNLIMITED); //Tempest-Forge
      Sunfury.ModObjectLimit(FourCC("h0C6"), Faction.UNLIMITED); //Altar
      Sunfury.ModObjectLimit(FourCC("h0CC"), Faction.UNLIMITED); //Vault
      Sunfury.ModObjectLimit(FourCC("h0CD"), Faction.UNLIMITED); //Scout tower
      Sunfury.ModObjectLimit(FourCC("n0E0"), Faction.UNLIMITED); //Skyfury tower
      Sunfury.ModObjectLimit(FourCC("n0E1"), Faction.UNLIMITED); //improved skyfury tower
      Sunfury.ModObjectLimit(FourCC("N0DZ"), 1); //Fountain
      Sunfury.ModObjectLimit(FourCC("h077"), Faction.UNLIMITED); //Alliance Shipyard

      //Units
      Sunfury.ModObjectLimit(FourCC("n0E2"), Faction.UNLIMITED); //worker
      Sunfury.ModObjectLimit(FourCC("n09S"), Faction.UNLIMITED); //Elven Warrior
      Sunfury.ModObjectLimit(FourCC("h0CF"), Faction.UNLIMITED); //Elven Ranger
      Sunfury.ModObjectLimit(FourCC("h0CE"), Faction.UNLIMITED); //Knight
      Sunfury.ModObjectLimit(FourCC("h0CH"), Faction.UNLIMITED); //Astromancer
      Sunfury.ModObjectLimit(FourCC("h0CG"), Faction.UNLIMITED); //Flamekeeper
      Sunfury.ModObjectLimit(FourCC("n0E3"), 6); //Warlock
      Sunfury.ModObjectLimit(FourCC("n0E4"), 6); //Elven Ballista
      Sunfury.ModObjectLimit(FourCC("n0E8"), 3); //Skyship
      Sunfury.ModObjectLimit(FourCC("n0E7"), 6); //Bloodwarder
      Sunfury.ModObjectLimit(FourCC("n0E5"), 8); //Fel Reaver
      Sunfury.ModObjectLimit(FourCC("n0E6"), 4); //Shivarra
      Sunfury.ModObjectLimit(FourCC("e01B"), 6); //Arcane Annihilator
      Sunfury.ModObjectLimit(FourCC("n006"), 2); //Ancient of the Arcane

      //Ships
      Sunfury.ModObjectLimit(FourCC("hbot"), Faction.UNLIMITED); //Alliance Transport Ship
      Sunfury.ModObjectLimit(FourCC("h0AR"), Faction.UNLIMITED); //Alliance Scout
      Sunfury.ModObjectLimit(FourCC("h0AX"), Faction.UNLIMITED); //Alliance Frigate
      Sunfury.ModObjectLimit(FourCC("h0B3"), Faction.UNLIMITED); //Alliance Fireship
      Sunfury.ModObjectLimit(FourCC("h0B0"), Faction.UNLIMITED); //Alliance Galley
      Sunfury.ModObjectLimit(FourCC("h0B6"), Faction.UNLIMITED); //Alliance Boarding
      Sunfury.ModObjectLimit(FourCC("h0AN"), Faction.UNLIMITED); //Alliance Juggernaut
      Sunfury.ModObjectLimit(FourCC("h0B7"), 6); //Alliance Bombard

      //Demi-heroes
      Sunfury.ModObjectLimit(FourCC("H098"), 1); //Pathaleon
      Sunfury.ModObjectLimit(FourCC("U02V"), 1); //Solarian
      Sunfury.ModObjectLimit(FourCC("Hkal"), 1); //Kael
      Sunfury.ModObjectLimit(FourCC("U004"), 1); //Kil

      //Upgrades
      Sunfury.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      Sunfury.ModObjectLimit(FourCC("R09H"), Faction.UNLIMITED); //Priest Adept Training
      Sunfury.ModObjectLimit(FourCC("R09G"), Faction.UNLIMITED); //Flamekeeper Adept Training

      Sunfury.AddGoldMine(preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(17716, 13000)));

      FactionManager.Register(Sunfury);
    }
  }
}