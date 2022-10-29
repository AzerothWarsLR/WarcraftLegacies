using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class BlackEmpireSetup
  {
    public static Faction? BlackEmpire { get; private set; }

    public static void Setup()
    {
      BlackEmpire = new Faction("Black Empire", PLAYER_COLOR_TURQUOISE, "|cff008080",
        "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        FoodMaximum = 75,
        IntroText = @"You are playing as the horrifying |cff008080Black Empire|r.

You are cut off in a horrible alternate world, Ny'alotha.

To exit it, you need to first create 3 Obelisks at 3 points in Azeroth: Storm Peaks, Tanaris and Twilight Highlands, in that order. 

Use your Heralds to summon the Obelisk. Move them to the corners of Ny'alotha to move them to Azeroth.

While summoning the Obelisks, you can temporarily send your armies through the portals into Azeroth. But until all 3 Obelisks are summoned, your units will all return to Ny'alotha when the summoning is over."
      };

      //Units
      BlackEmpire.ModObjectLimit(FourCC("h06U"), Faction.UNLIMITED); //Siphoning Crystal
      BlackEmpire.ModObjectLimit(FourCC("h09E"), Faction.UNLIMITED); //Madness Pool
      BlackEmpire.ModObjectLimit(FourCC("n0B2"), Faction.UNLIMITED); //Ominous Vault
      BlackEmpire.ModObjectLimit(FourCC("n0AV"), Faction.UNLIMITED); //Altar of madness
      BlackEmpire.ModObjectLimit(FourCC("n0AT"), Faction.UNLIMITED); //Cathedral of madness
      BlackEmpire.ModObjectLimit(FourCC("n0AW"), Faction.UNLIMITED); //Creation hive
      BlackEmpire.ModObjectLimit(FourCC("n0B3"), Faction.UNLIMITED); //Library of forbidden knowledge
      BlackEmpire.ModObjectLimit(FourCC("n0AX"), Faction.UNLIMITED); //prison of the unspeakable
      BlackEmpire.ModObjectLimit(FourCC("n0AU"), Faction.UNLIMITED); //pulsating portal
      BlackEmpire.ModObjectLimit(FourCC("n0AR"), Faction.UNLIMITED); //twisted halls
      BlackEmpire.ModObjectLimit(FourCC("n0AS"), Faction.UNLIMITED); //whispering chambers
      BlackEmpire.ModObjectLimit(FourCC("n0AY"), Faction.UNLIMITED); //acid spitter
      BlackEmpire.ModObjectLimit(FourCC("n0AZ"), Faction.UNLIMITED); //sleepeless watcher
      BlackEmpire.ModObjectLimit(FourCC("n0B1"), Faction.UNLIMITED); //Improved Spitter
      BlackEmpire.ModObjectLimit(FourCC("n0B0"), Faction.UNLIMITED); //Improved Watcher
      
      //Structures
      BlackEmpire.ModObjectLimit(FourCC("n0B5"), Faction.UNLIMITED); //Cultist
      BlackEmpire.ModObjectLimit(FourCC("o04Z"), 12); //Flying horror
      BlackEmpire.ModObjectLimit(FourCC("n0AH"), 4); //Deformed Chimera
      BlackEmpire.ModObjectLimit(FourCC("n0B4"), 6); //Reaper
      BlackEmpire.ModObjectLimit(FourCC("o01G"), Faction.UNLIMITED); //Macemen
      BlackEmpire.ModObjectLimit(FourCC("o04V"), Faction.UNLIMITED); //Huntsman
      BlackEmpire.ModObjectLimit(FourCC("u029"), 12); //Stygian Reavver
      BlackEmpire.ModObjectLimit(FourCC("n077"), Faction.UNLIMITED); //Sorcerer
      BlackEmpire.ModObjectLimit(FourCC("o04Y"), Faction.UNLIMITED); //Fateweaver
      BlackEmpire.ModObjectLimit(FourCC("h09F"), Faction.UNLIMITED); //Gladiator
      BlackEmpire.ModObjectLimit(FourCC("u02F"), 2); //Forgotten one

      BlackEmpire.ModObjectLimit(FourCC("E01D"), 1); //Volazj
      BlackEmpire.ModObjectLimit(FourCC("U02B"), 1); //Soggoth
      BlackEmpire.ModObjectLimit(FourCC("U00P"), 1); //Zakajz

      BlackEmpire.ModObjectLimit(FourCC("u02E"), 1); //Heralds

      //Upgrades
      BlackEmpire.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Void Infusion
      BlackEmpire.ModObjectLimit(FourCC("R07N"), Faction.UNLIMITED); //Sorcerer Training
      BlackEmpire.ModObjectLimit(FourCC("R07O"), Faction.UNLIMITED); //Fateweaver Training

      //Special mechanics
      BlackEmpirePortalSetup.Setup();
      var heraldUnitEffect = new HeraldUnitEffect(Constants.UNIT_U02E_HERALD_OF_NY_ALOTHA_BLACK_EMPRIE);
      SpellSystem.Register(heraldUnitEffect);
      var obeliskCast =
        new BlackEmpireObeliskSpell(Constants.ABILITY_A06Z_SUMMON_OBELISK_BLACK_EMPIRE, Constants.UNIT_N0BA_NY_ALOTHA_OBELISK)
        {
          Duration = 180
        };
      SpellSystem.Register(obeliskCast);

      //Powers
      var visionPower = new VisionPower("All-Seeing",
        "Grants permanent vision over Ny'alotha.",
        "Charm", new[]
        {
          Regions.NyalothaInstance,
        });
      BlackEmpire.AddPower(visionPower);

      FactionManager.Register(BlackEmpire);
    }
  }
}