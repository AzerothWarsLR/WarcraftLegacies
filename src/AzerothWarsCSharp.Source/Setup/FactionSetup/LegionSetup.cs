using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class LegionSetup
  {
    public static Faction FactionLegion { get; private set; }


    public static void Setup()
    {
      Faction f;

      LegionSetup.FactionLegion = new Faction("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F",
        "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp");
      f = LegionSetup.FactionLegion;
      f.UndefeatedResearch = FourCC("R04T");
      f.Team = TeamSetup.TeamLegion;
      f.StartingGold = 150;
      f.StartingLumber = 500;
      //Structures
      f.ModObjectLimit(FourCC("u00H"), Faction.UNLIMITED); //Legion Defensive Pylon
      f.ModObjectLimit(FourCC("u00I"), Faction.UNLIMITED); //Improved Defensive Pylon
      f.ModObjectLimit(FourCC("u00F"), Faction.UNLIMITED); //Dormant Spire
      f.ModObjectLimit(FourCC("u00C"), Faction.UNLIMITED); //Legion Bastion
      f.ModObjectLimit(FourCC("u00N"), Faction.UNLIMITED); //Burning Citadel
      f.ModObjectLimit(FourCC("n040"), Faction.UNLIMITED); //Armory
      f.ModObjectLimit(FourCC("u009"), Faction.UNLIMITED); //Undead Shipyard
      f.ModObjectLimit(FourCC("u00E"), Faction.UNLIMITED); //Generator
      f.ModObjectLimit(FourCC("u01N"), Faction.UNLIMITED); //Burning Altar
      f.ModObjectLimit(FourCC("u015"), Faction.UNLIMITED); //Unholy Reliquary
      f.ModObjectLimit(FourCC("u006"), Faction.UNLIMITED); //Void Summoning Spire
      f.ModObjectLimit(FourCC("ndmg"), Faction.UNLIMITED); //Demon Gate
      f.ModObjectLimit(FourCC("n04N"), Faction.UNLIMITED); //Infernal Machine Factory
      f.ModObjectLimit(FourCC("n04Q"), Faction.UNLIMITED); //Nether Pit
      f.ModObjectLimit(FourCC("e01F"), 1); //Monolith
      f.ModObjectLimit(FourCC("e01G"), 1); //Satue
      f.ModObjectLimit(FourCC("e01H"), 1); //Fortress

      //Units
      f.ModObjectLimit(FourCC("u00D"), Faction.UNLIMITED); //Legion Herald
      f.ModObjectLimit(FourCC("u007"), 6); //Dreadlord
      f.ModObjectLimit(FourCC("n04P"), Faction.UNLIMITED); //Warlock
      f.ModObjectLimit(FourCC("ninc"), Faction.UNLIMITED); //Burning archer
      f.ModObjectLimit(FourCC("n04K"), Faction.UNLIMITED); //Succubus
      f.ModObjectLimit(FourCC("n04J"), Faction.UNLIMITED); //Felstalker
      f.ModObjectLimit(FourCC("ubot"), 12); //Undead Transport SHip
      f.ModObjectLimit(FourCC("udes"), 12); //Undead Frigate
      f.ModObjectLimit(FourCC("uubs"), 6); //Undead Battleship
      f.ModObjectLimit(FourCC("n04O"), 6); //Doomguard
      f.ModObjectLimit(FourCC("n04L"), 6); //Infernal Juggernaut
      f.ModObjectLimit(FourCC("ninf"), 12); //Infernal
      f.ModObjectLimit(FourCC("n04H"), Faction.UNLIMITED); //Fel Guard
      f.ModObjectLimit(FourCC("n04U"), 4); //Dragon
      f.ModObjectLimit(FourCC("n03L"), 4); //Barge

      f.ModObjectLimit(FourCC("n05R"), 1); //Felguard
      f.ModObjectLimit(FourCC("n06H"), 1); //Pit Fiend
      f.ModObjectLimit(FourCC("n07B"), 1); //Queen
      f.ModObjectLimit(FourCC("n07D"), 1); //Maiden
      f.ModObjectLimit(FourCC("n07o"), 1); //Terror
      f.ModObjectLimit(FourCC("n07N"), 1); //Lord

      //Researches
      f.ModObjectLimit(FourCC("R02C"), Faction.UNLIMITED); //Acute Sensors
      f.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Chaos Infusion
      f.ModObjectLimit(FourCC("R028"), Faction.UNLIMITED); //Shadow Priest Adept Training
      f.ModObjectLimit(FourCC("R027"), Faction.UNLIMITED); //Warlock Adept Training
      f.ModObjectLimit(FourCC("R01Y"), Faction.UNLIMITED); //Astral Walk
      f.ModObjectLimit(FourCC("R04G"), Faction.UNLIMITED); //Improved Carrion Swarm
      f.ModObjectLimit(FourCC("R03Z"), Faction.UNLIMITED); //War Plating
      f.ModObjectLimit(FourCC("R040"), Faction.UNLIMITED); //Flying horrors

      //Heroes
      f.ModObjectLimit(FourCC("U00L"), 1); //Anetheron
      f.ModObjectLimit(FourCC("Umal"), 1); //Mal)ganis
      f.ModObjectLimit(FourCC("Utic"), 1); //Tichondrius
    }
  }
}