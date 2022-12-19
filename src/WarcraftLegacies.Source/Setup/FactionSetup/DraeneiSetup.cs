using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class DraeneiSetup
  {
    public static Faction? Draenei { get; private set; }

    public static void Setup()
    {
      Draenei = new Faction("The Exodar", PLAYER_COLOR_NAVY, "|cff000080",
        "ReplaceableTextures\\CommandButtons\\BTNBOSSVelen.blp")
      {
        UndefeatedResearch = FourCC("R06E"),
        StartingGold = 150,
        StartingLumber = 500,
        ControlPointDefenderTemplateUnitTypeId = Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI,
        IntroText = @"You are playing as the exiled |cff000080Draenei|r.

You must evacuate your people from Shattrah and migrate North to Tempest Keep, there you will find a valuable goldmine.

The Fel Horde is mobilizing to wipe out your people, this is a fight you cannot win.

Escape as soon as you can and  try to save as many Draenei as you can. If you are trapped in Outland by turn 15, it may be too late to save your people."
      };

      Draenei.ModObjectLimit(FourCC("o02P"), Faction.UNLIMITED); //Crystal Hall
      Draenei.ModObjectLimit(FourCC("o050"), Faction.UNLIMITED); //Metropolis
      Draenei.ModObjectLimit(FourCC("o051"), Faction.UNLIMITED); //Divine Citadel
      Draenei.ModObjectLimit(FourCC("o058"), Faction.UNLIMITED); //Altar of Light
      Draenei.ModObjectLimit(FourCC("o052"), Faction.UNLIMITED); //Ceremonial Altar
      Draenei.ModObjectLimit(FourCC("o053"), Faction.UNLIMITED); //Smithery
      Draenei.ModObjectLimit(FourCC("o054"), Faction.UNLIMITED); //Astral Sanctum
      Draenei.ModObjectLimit(FourCC("o055"), Faction.UNLIMITED); //Crystal Spire
      Draenei.ModObjectLimit(FourCC("o056"), Faction.UNLIMITED); //Arcane Well
      Draenei.ModObjectLimit(FourCC("o057"), Faction.UNLIMITED); //Vaults of Relic
      Draenei.ModObjectLimit(FourCC("u00U"), Faction.UNLIMITED); //Crystal Protector
      Draenei.ModObjectLimit(FourCC("u01Q"), Faction.UNLIMITED); //Crystal Protector improved
      Draenei.ModObjectLimit(FourCC("o059"), Faction.UNLIMITED); //Improved Ancient Protector

      Draenei.ModObjectLimit(FourCC("o05A"), Faction.UNLIMITED); //Wisp
      Draenei.ModObjectLimit(FourCC("o05B"), Faction.UNLIMITED); //Defender
      Draenei.ModObjectLimit(FourCC("h09T"), Faction.UNLIMITED); //Rangari
      Draenei.ModObjectLimit(FourCC("e01K"), 3); //Polybolos
      Draenei.ModObjectLimit(FourCC("o05D"), Faction.UNLIMITED); //Elementalist
      Draenei.ModObjectLimit(FourCC("o05C"), Faction.UNLIMITED); //Luminarch
      Draenei.ModObjectLimit(FourCC("h09R"), 6); //Vindicator
      Draenei.ModObjectLimit(FourCC("nmdr"), Faction.UNLIMITED); //Elekk
      Draenei.ModObjectLimit(FourCC("h09U"), 4); //Elekk Knight
      Draenei.ModObjectLimit(FourCC("u02H"), 6); //Nether Ray

      Draenei.ModObjectLimit(FourCC("etrs"), Faction.UNLIMITED); //Night Elf Transport Ship
      Draenei.ModObjectLimit(FourCC("edes"), Faction.UNLIMITED); //Night Elf Frigate
      Draenei.ModObjectLimit(FourCC("ebsh"), 6); //Night Elf Battleship

      Draenei.ModObjectLimit(FourCC("H09S"), 1); //Maraad
      Draenei.ModObjectLimit(FourCC("E01I"), 1); //Velen
      Draenei.ModObjectLimit(FourCC("E01J"), 1); //Nobundo

      Draenei.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      Draenei.ModObjectLimit(FourCC("R078"), Faction.UNLIMITED); //Elementalist training
      Draenei.ModObjectLimit(FourCC("R07C"), Faction.UNLIMITED); //Luminarch training

      FactionManager.Register(Draenei);
    }
  }
}