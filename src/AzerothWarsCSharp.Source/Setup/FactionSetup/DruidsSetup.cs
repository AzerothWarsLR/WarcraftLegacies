using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class DruidsSetup
  {
    public static Faction factionDruids;

    public static void Setup()
    {
      factionDruids = new Faction("Druids", PLAYER_COLOR_BROWN, "|c004e2a04",
        "ReplaceableTextures\\CommandButtons\\BTNFurion.blp")
      {
        UndefeatedResearch = FourCC("R06E"),
        StartingGold = 150,
        StartingLumber = 500,
        IntroText = @"You are playing as the venerable Druids of the Cenarion Circle.

        Without a Hero, you are perilously weak in the beginning. 
        Awaken Malfurion from his slumber as soon as possible. 

        Once awakened, use his Force of Nature to clear a path through the trees in Ashenvale and summon Cenarius to aid you. 

        The Horde is gathering to burn Ashenvale forest and all within, gather your forces and strike before they can organize their forces."
      };

      factionDruids.ModObjectLimit(FourCC("etol"), Faction.UNLIMITED); //Tree of Life
      factionDruids.ModObjectLimit(FourCC("etoa"), Faction.UNLIMITED); //Tree of Ages
      factionDruids.ModObjectLimit(FourCC("etoe"), Faction.UNLIMITED); //Tree of Eternity
      factionDruids.ModObjectLimit(FourCC("emow"), Faction.UNLIMITED); //Moon Well
      factionDruids.ModObjectLimit(FourCC("eate"), Faction.UNLIMITED); //Altar of Elders
      factionDruids.ModObjectLimit(FourCC("eaoe"), Faction.UNLIMITED); //Ancient of Lore
      factionDruids.ModObjectLimit(FourCC("eaow"), Faction.UNLIMITED); //Ancient of Wind
      factionDruids.ModObjectLimit(FourCC("eaom"), Faction.UNLIMITED); //Ancient of war
      factionDruids.ModObjectLimit(FourCC("etrp"), Faction.UNLIMITED); //Ancient Protector
      factionDruids.ModObjectLimit(FourCC("e010"), Faction.UNLIMITED); //Hunter)s Hall
      factionDruids.ModObjectLimit(FourCC("e019"), Faction.UNLIMITED); //Ancient of Wonders
      factionDruids.ModObjectLimit(FourCC("eshy"), Faction.UNLIMITED); //Night Elf Shipyard
      factionDruids.ModObjectLimit(FourCC("e000"), Faction.UNLIMITED); //Improved Ancient Protector

      factionDruids.ModObjectLimit(FourCC("ewsp"), Faction.UNLIMITED); //Wisp
      factionDruids.ModObjectLimit(FourCC("edry"), Faction.UNLIMITED); //Dryad
      factionDruids.ModObjectLimit(FourCC("edot"), Faction.UNLIMITED); //Druid of the Talon
      factionDruids.ModObjectLimit(FourCC("emtg"), 12); //Mountain Giant
      factionDruids.ModObjectLimit(FourCC("efdr"), 6); //Faerie Dragon
      factionDruids.ModObjectLimit(FourCC("edoc"), Faction.UNLIMITED); //Druid of the Claw
      factionDruids.ModObjectLimit(FourCC("edcm"), Faction.UNLIMITED); //Druid of the Claw bear form
      factionDruids.ModObjectLimit(FourCC("e00N"), 6); //Keeper of the Grove
      factionDruids.ModObjectLimit(FourCC("n05H"), Faction.UNLIMITED); //Furbolg
      factionDruids.ModObjectLimit(FourCC("n065"), 6); //Green Dragon
      factionDruids.ModObjectLimit(FourCC("etrs"), 12); //Night Elf Transport Ship
      factionDruids.ModObjectLimit(FourCC("edes"), 12); //Night Elf Frigate
      factionDruids.ModObjectLimit(FourCC("ebsh"), 6); //Night Elf Battleship

      factionDruids.ModObjectLimit(FourCC("Ecen"), 1); //Cenarius
      factionDruids.ModObjectLimit(FourCC("E00H"), 1); //Cenarius
      factionDruids.ModObjectLimit(FourCC("E00K"), 1); //Tortolla
      factionDruids.ModObjectLimit(FourCC("Efur"), 1); //Furion

      factionDruids.ModObjectLimit(FourCC("Redt"), Faction.UNLIMITED); //Druid of the Talon Adept Training
      factionDruids.ModObjectLimit(FourCC("Renb"), Faction.UNLIMITED); //Nature)s Blessing
      factionDruids.ModObjectLimit(FourCC("Rers"), Faction.UNLIMITED); //Resistant Skin
      factionDruids.ModObjectLimit(FourCC("Reuv"), Faction.UNLIMITED); //Ultravision
      factionDruids.ModObjectLimit(FourCC("Rews"), Faction.UNLIMITED); //Well Spring
      factionDruids.ModObjectLimit(FourCC("R01H"), Faction.UNLIMITED); //Malorne)s Power Infusion
      factionDruids.ModObjectLimit(FourCC("Redc"), Faction.UNLIMITED); //Druid of the Claw Adept Training
      factionDruids.ModObjectLimit(FourCC("R04E"), Faction.UNLIMITED); //Ysera)s Gift
      factionDruids.ModObjectLimit(FourCC("R02G"), Faction.UNLIMITED); //Emerald Flames
      factionDruids.ModObjectLimit(FourCC("R05X"), Faction.UNLIMITED); //Blessing of Ursoc
      factionDruids.ModObjectLimit(FourCC("R002"), Faction.UNLIMITED); //Blackwald Enhancement
      factionDruids.ModObjectLimit(FourCC("R00A"), Faction.UNLIMITED); //Improved Thorns
      factionDruids.ModObjectLimit(FourCC("R02T"), Faction.UNLIMITED); //Improved Moonwells
      factionDruids.ModObjectLimit(FourCC("R033"), Faction.UNLIMITED); //Limber Timber
      factionDruids.ModObjectLimit(FourCC("R046"), Faction.UNLIMITED); //Grasping Vines
      factionDruids.ModObjectLimit(FourCC("R047"), Faction.UNLIMITED); //Crippling Poison
      factionDruids.ModObjectLimit(FourCC("R048"), Faction.UNLIMITED); //Deadly Poison
      factionDruids.ModObjectLimit(FourCC("R008"), Faction.UNLIMITED); //Improved Natures FuryR015
      factionDruids.ModObjectLimit(FourCC("R015"), Faction.UNLIMITED); //Improved Mana Flare

      FactionManager.Register(factionDruids);
    }
  }
}