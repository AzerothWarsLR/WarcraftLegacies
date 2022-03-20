using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class LegionSetup{

  
    Faction FACTION_LEGION
  

    public static void Setup( ){
      Faction f;

      FACTION_LEGION = Faction.create("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F","ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp");
      f = FACTION_LEGION;
      f.UndefeatedResearch = FourCC(R04T);
      f.Team = TEAM_LEGION;
      f.StartingGold = 150;
      f.StartingLumber = 500;
      //Structures
      f.ModObjectLimit(FourCC(u00H), UNLIMITED)   ;//Legion Defensive Pylon
      f.ModObjectLimit(FourCC(u00I), UNLIMITED)   ;//Improved Defensive Pylon
      f.ModObjectLimit(FourCC(u00F), UNLIMITED)   ;//Dormant Spire
      f.ModObjectLimit(FourCC(u00C), UNLIMITED)   ;//Legion Bastion
      f.ModObjectLimit(FourCC(u00N), UNLIMITED)   ;//Burning Citadel
      f.ModObjectLimit(FourCC(n040), UNLIMITED)   ;//Armory
      f.ModObjectLimit(FourCC(u009), UNLIMITED)   ;//Undead Shipyard
      f.ModObjectLimit(FourCC(u00E), UNLIMITED)   ;//Generator
      f.ModObjectLimit(FourCC(u01N), UNLIMITED)   ;//Burning Altar
      f.ModObjectLimit(FourCC(u015), UNLIMITED)   ;//Unholy Reliquary
      f.ModObjectLimit(FourCC(u006), UNLIMITED)   ;//Void Summoning Spire
      f.ModObjectLimit(FourCC(ndmg), UNLIMITED)   ;//Demon Gate
      f.ModObjectLimit(FourCC(n04N), UNLIMITED)   ;//Infernal Machine Factory
      f.ModObjectLimit(FourCC(n04Q), UNLIMITED)   ;//Nether Pit
      f.ModObjectLimit(FourCC(e01F), 1)   ;//Monolith
      f.ModObjectLimit(FourCC(e01G), 1)   ;//Satue
      f.ModObjectLimit(FourCC(e01H), 1)   ;//Fortress

      //Units
      f.ModObjectLimit(FourCC(u00D), UNLIMITED)   ;//Legion Herald
      f.ModObjectLimit(FourCC(u007), 6)           ;//Dreadlord
      f.ModObjectLimit(FourCC(n04P), UNLIMITED)   ;//Warlock
      f.ModObjectLimit(FourCC(ninc), UNLIMITED)   ;//Burning archer
      f.ModObjectLimit(FourCC(n04K), UNLIMITED)   ;//Succubus
      f.ModObjectLimit(FourCC(n04J), UNLIMITED)   ;//Felstalker
      f.ModObjectLimit(FourCC(ubot), 12) 	        ;//Undead Transport SHip
      f.ModObjectLimit(FourCC(udes), 12) 	        ;//Undead Frigate
      f.ModObjectLimit(FourCC(uubs), 6)          ;//Undead Battleship
      f.ModObjectLimit(FourCC(n04O), 6)           ;//Doomguard
      f.ModObjectLimit(FourCC(n04L), 6)           ;//Infernal Juggernaut
      f.ModObjectLimit(FourCC(ninf), 12)          ;//Infernal
      f.ModObjectLimit(FourCC(n04H), UNLIMITED)   ;//Fel Guard
      f.ModObjectLimit(FourCC(n04U), 4)           ;//Dragon
      f.ModObjectLimit(FourCC(n03L), 4)           ;//Barge

      f.ModObjectLimit(FourCC(n05R), 1)           ;//Felguard
      f.ModObjectLimit(FourCC(n06H), 1)           ;//Pit Fiend
      f.ModObjectLimit(FourCC(n07B), 1)           ;//Queen
      f.ModObjectLimit(FourCC(n07D), 1)           ;//Maiden
      f.ModObjectLimit(FourCC(n07o), 1)           ;//Terror
      f.ModObjectLimit(FourCC(n07N), 1)           ;//Lord

      //Researches
      f.ModObjectLimit(FourCC(R02C), UNLIMITED)   ;//Acute Sensors
      f.ModObjectLimit(FourCC(R02A), UNLIMITED)   ;//Chaos Infusion
      f.ModObjectLimit(FourCC(R028), UNLIMITED)   ;//Shadow Priest Adept Training
      f.ModObjectLimit(FourCC(R027), UNLIMITED)   ;//Warlock Adept Training
      f.ModObjectLimit(FourCC(R01Y), UNLIMITED)   ;//Astral Walk
      f.ModObjectLimit(FourCC(R04G), UNLIMITED)   ;//Improved Carrion Swarm
      f.ModObjectLimit(FourCC(R03Z), UNLIMITED)   ;//War Plating
      f.ModObjectLimit(FourCC(R040), UNLIMITED)   ;//Flying horrors

      //Heroes
      f.ModObjectLimit(FourCC(U00L), 1)           ;//Anetheron
      f.ModObjectLimit(FourCC(Umal), 1)           ;//Mal)ganis
      f.ModObjectLimit(FourCC(Utic), 1)           ;//Tichondrius

    }

  }
}
