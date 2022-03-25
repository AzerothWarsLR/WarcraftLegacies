using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class BlackEmpireSetup
  {
    public static Faction factionBlackempire;
    
    public static void Setup()
    {
      Faction f;
      factionBlackempire = Faction.create("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080",
        "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp");
      f = factionBlackempire;
      f.Team = TEAM_OLDGOD;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Units
      f.ModObjectLimit(FourCC("h06U"), Faction.UNLIMITED); //Siphoning Crystal
      f.ModObjectLimit(FourCC("h09E"), Faction.UNLIMITED); //Madness Pool
      f.ModObjectLimit(FourCC("n0B2"), Faction.UNLIMITED); //Ominous Vault
      f.ModObjectLimit(FourCC("n0AV"), Faction.UNLIMITED); //Altar of madness
      f.ModObjectLimit(FourCC("n0AT"), Faction.UNLIMITED); //Cathedral of madness
      f.ModObjectLimit(FourCC("n0AW"), Faction.UNLIMITED); //Creation hive
      f.ModObjectLimit(FourCC("n0B3"), Faction.UNLIMITED); //Library of forbidden knowledge
      f.ModObjectLimit(FourCC("n0AX"), Faction.UNLIMITED); //prison of the unspeakable
      f.ModObjectLimit(FourCC("n0AU"), Faction.UNLIMITED); //pulsating portal
      f.ModObjectLimit(FourCC("n0AR"), Faction.UNLIMITED); //twisted halls
      f.ModObjectLimit(FourCC("n0AS"), Faction.UNLIMITED); //whispering chambers
      f.ModObjectLimit(FourCC("n0AY"), Faction.UNLIMITED); //acid spitter
      f.ModObjectLimit(FourCC("n0AZ"), Faction.UNLIMITED); //sleepeless watcher
      f.ModObjectLimit(FourCC("n0B1"), Faction.UNLIMITED); //Improved Spitter
      f.ModObjectLimit(FourCC("n0B0"), Faction.UNLIMITED); //Improved Watcher


      //Structures
      f.ModObjectLimit(FourCC("n0B5"), Faction.UNLIMITED); //Cultist
      f.ModObjectLimit(FourCC("o04Z"), 12); //Flying horror
      f.ModObjectLimit(FourCC("n0AH"), 4); //Deformed Chimera
      f.ModObjectLimit(FourCC("n0B4"), 6); //Reaper
      f.ModObjectLimit(FourCC("o01G"), Faction.UNLIMITED); //Macemen
      f.ModObjectLimit(FourCC("o04V"), Faction.UNLIMITED); //Huntsman
      f.ModObjectLimit(FourCC("u029"), 12); //Stygian Reavver
      f.ModObjectLimit(FourCC("n077"), Faction.UNLIMITED); //Sorcerer
      f.ModObjectLimit(FourCC("o04Y"), Faction.UNLIMITED); //Fateweaver
      f.ModObjectLimit(FourCC("h09F"), Faction.UNLIMITED); //Gladiator
      f.ModObjectLimit(FourCC("u02F"), 2); //Forgotten one

      f.ModObjectLimit(FourCC("E01D"), 1); //Volazj
      f.ModObjectLimit(FourCC("U02B"), 1); //Soggoth
      f.ModObjectLimit(FourCC("U00P"), 1); //Zakajz

      f.ModObjectLimit(FourCC("u02E"), 1); //Heralds

      //Upgrades
      f.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Void Infusion
      f.ModObjectLimit(FourCC("R07N"), Faction.UNLIMITED); //Sorcerer Training
      f.ModObjectLimit(FourCC("R07O"), Faction.UNLIMITED); //Fateweaver Training

      //Masteries
    }
  }
}