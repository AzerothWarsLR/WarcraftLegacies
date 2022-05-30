using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class BlackEmpireSetup
  {
    public static Faction FactionBlackempire { get; private set; }

    public static void Setup()
    {
      FactionBlackempire = new Faction("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080",
        "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        Team = TeamSetup.OldGods
      };

      //Units
      FactionBlackempire.ModObjectLimit(FourCC("h06U"), Faction.UNLIMITED); //Siphoning Crystal
      FactionBlackempire.ModObjectLimit(FourCC("h09E"), Faction.UNLIMITED); //Madness Pool
      FactionBlackempire.ModObjectLimit(FourCC("n0B2"), Faction.UNLIMITED); //Ominous Vault
      FactionBlackempire.ModObjectLimit(FourCC("n0AV"), Faction.UNLIMITED); //Altar of madness
      FactionBlackempire.ModObjectLimit(FourCC("n0AT"), Faction.UNLIMITED); //Cathedral of madness
      FactionBlackempire.ModObjectLimit(FourCC("n0AW"), Faction.UNLIMITED); //Creation hive
      FactionBlackempire.ModObjectLimit(FourCC("n0B3"), Faction.UNLIMITED); //Library of forbidden knowledge
      FactionBlackempire.ModObjectLimit(FourCC("n0AX"), Faction.UNLIMITED); //prison of the unspeakable
      FactionBlackempire.ModObjectLimit(FourCC("n0AU"), Faction.UNLIMITED); //pulsating portal
      FactionBlackempire.ModObjectLimit(FourCC("n0AR"), Faction.UNLIMITED); //twisted halls
      FactionBlackempire.ModObjectLimit(FourCC("n0AS"), Faction.UNLIMITED); //whispering chambers
      FactionBlackempire.ModObjectLimit(FourCC("n0AY"), Faction.UNLIMITED); //acid spitter
      FactionBlackempire.ModObjectLimit(FourCC("n0AZ"), Faction.UNLIMITED); //sleepeless watcher
      FactionBlackempire.ModObjectLimit(FourCC("n0B1"), Faction.UNLIMITED); //Improved Spitter
      FactionBlackempire.ModObjectLimit(FourCC("n0B0"), Faction.UNLIMITED); //Improved Watcher


      //Structures
      FactionBlackempire.ModObjectLimit(FourCC("n0B5"), Faction.UNLIMITED); //Cultist
      FactionBlackempire.ModObjectLimit(FourCC("o04Z"), 12); //Flying horror
      FactionBlackempire.ModObjectLimit(FourCC("n0AH"), 4); //Deformed Chimera
      FactionBlackempire.ModObjectLimit(FourCC("n0B4"), 6); //Reaper
      FactionBlackempire.ModObjectLimit(FourCC("o01G"), Faction.UNLIMITED); //Macemen
      FactionBlackempire.ModObjectLimit(FourCC("o04V"), Faction.UNLIMITED); //Huntsman
      FactionBlackempire.ModObjectLimit(FourCC("u029"), 12); //Stygian Reavver
      FactionBlackempire.ModObjectLimit(FourCC("n077"), Faction.UNLIMITED); //Sorcerer
      FactionBlackempire.ModObjectLimit(FourCC("o04Y"), Faction.UNLIMITED); //Fateweaver
      FactionBlackempire.ModObjectLimit(FourCC("h09F"), Faction.UNLIMITED); //Gladiator
      FactionBlackempire.ModObjectLimit(FourCC("u02F"), 2); //Forgotten one

      FactionBlackempire.ModObjectLimit(FourCC("E01D"), 1); //Volazj
      FactionBlackempire.ModObjectLimit(FourCC("U02B"), 1); //Soggoth
      FactionBlackempire.ModObjectLimit(FourCC("U00P"), 1); //Zakajz

      FactionBlackempire.ModObjectLimit(FourCC("u02E"), 1); //Heralds

      //Upgrades
      FactionBlackempire.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Void Infusion
      FactionBlackempire.ModObjectLimit(FourCC("R07N"), Faction.UNLIMITED); //Sorcerer Training
      FactionBlackempire.ModObjectLimit(FourCC("R07O"), Faction.UNLIMITED); //Fateweaver Training

      FactionManager.Register(FactionBlackempire);

      BlackEmpirePortalSetup.Setup();
      var heraldUnitEffect = new HeraldUnitEffect(Constants.UNIT_U02E_HERALD_OF_NY_ALOTHA_BLACK_EMPRIE);
      SpellSystem.Register(heraldUnitEffect);
      var obeliskCast =
        new BlackEmpireObeliskSpell(Constants.ABILITY_A06Z_SUMMON_OBELISK, Constants.UNIT_N0BA_NY_ALOTHA_OBELISK)
        {
          Duration = 300
        };
      SpellSystem.Register(obeliskCast);
    }
  }
}