using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class DruidsSetup
  {
    public static Faction factionDruids;
    
    public static void Setup()
    {
      Faction f;

      factionDruids = Faction.create("Druids", PLAYER_COLOR_BROWN, "|c004e2a04",
        "ReplaceableTextures\\CommandButtons\\BTNFurion.blp");
      f = factionDruids;
      f.Team = TEAM_NIGHT_ELVES;
      f.UndefeatedResearch = FourCC("R06E");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC("etol"), Faction.UNLIMITED); //Tree of Life
      f.ModObjectLimit(FourCC("etoa"), Faction.UNLIMITED); //Tree of Ages
      f.ModObjectLimit(FourCC("etoe"), Faction.UNLIMITED); //Tree of Eternity
      f.ModObjectLimit(FourCC("emow"), Faction.UNLIMITED); //Moon Well
      f.ModObjectLimit(FourCC("eate"), Faction.UNLIMITED); //Altar of Elders
      f.ModObjectLimit(FourCC("eaoe"), Faction.UNLIMITED); //Ancient of Lore
      f.ModObjectLimit(FourCC("eaow"), Faction.UNLIMITED); //Ancient of Wind
      f.ModObjectLimit(FourCC("eaom"), Faction.UNLIMITED); //Ancient of war
      f.ModObjectLimit(FourCC("etrp"), Faction.UNLIMITED); //Ancient Protector
      f.ModObjectLimit(FourCC("e010"), Faction.UNLIMITED); //Hunter)s Hall
      f.ModObjectLimit(FourCC("e019"), Faction.UNLIMITED); //Ancient of Wonders
      f.ModObjectLimit(FourCC("eshy"), Faction.UNLIMITED); //Night Elf Shipyard
      f.ModObjectLimit(FourCC("e000"), Faction.UNLIMITED); //Improved Ancient Protector

      f.ModObjectLimit(FourCC("ewsp"), Faction.UNLIMITED); //Wisp
      f.ModObjectLimit(FourCC("edry"), Faction.UNLIMITED); //Dryad
      f.ModObjectLimit(FourCC("edot"), Faction.UNLIMITED); //Druid of the Talon
      f.ModObjectLimit(FourCC("emtg"), 12); //Mountain Giant
      f.ModObjectLimit(FourCC("efdr"), 6); //Faerie Dragon
      f.ModObjectLimit(FourCC("edoc"), Faction.UNLIMITED); //Druid of the Claw
      f.ModObjectLimit(FourCC("edcm"), Faction.UNLIMITED); //Druid of the Claw bear form
      f.ModObjectLimit(FourCC("e00N"), 6); //Keeper of the Grove
      f.ModObjectLimit(FourCC("n05H"), Faction.UNLIMITED); //Furbolg
      f.ModObjectLimit(FourCC("n065"), 6); //Green Dragon
      f.ModObjectLimit(FourCC("etrs"), 12); //Night Elf Transport Ship
      f.ModObjectLimit(FourCC("edes"), 12); //Night Elf Frigate
      f.ModObjectLimit(FourCC("ebsh"), 6); //Night Elf Battleship

      f.ModObjectLimit(FourCC("Ecen"), 1); //Cenarius
      f.ModObjectLimit(FourCC("E00H"), 1); //Cenarius
      f.ModObjectLimit(FourCC("E00K"), 1); //Tortolla
      f.ModObjectLimit(FourCC("Efur"), 1); //Furion

      f.ModObjectLimit(FourCC("Redt"), Faction.UNLIMITED); //Druid of the Talon Adept Training
      f.ModObjectLimit(FourCC("Renb"), Faction.UNLIMITED); //Nature)s Blessing
      f.ModObjectLimit(FourCC("Rers"), Faction.UNLIMITED); //Resistant Skin
      f.ModObjectLimit(FourCC("Reuv"), Faction.UNLIMITED); //Ultravision
      f.ModObjectLimit(FourCC("Rews"), Faction.UNLIMITED); //Well Spring
      f.ModObjectLimit(FourCC("R01H"), Faction.UNLIMITED); //Malorne)s Power Infusion
      f.ModObjectLimit(FourCC("Redc"), Faction.UNLIMITED); //Druid of the Claw Adept Training
      f.ModObjectLimit(FourCC("R04E"), Faction.UNLIMITED); //Ysera)s Gift
      f.ModObjectLimit(FourCC("R02G"), Faction.UNLIMITED); //Emerald Flames
      f.ModObjectLimit(FourCC("R05X"), Faction.UNLIMITED); //Blessing of Ursoc
      f.ModObjectLimit(FourCC("R002"), Faction.UNLIMITED); //Blackwald Enhancement
      f.ModObjectLimit(FourCC("R00A"), Faction.UNLIMITED); //Improved Thorns
      f.ModObjectLimit(FourCC("R02T"), Faction.UNLIMITED); //Improved Moonwells
      f.ModObjectLimit(FourCC("R033"), Faction.UNLIMITED); //Limber Timber
      f.ModObjectLimit(FourCC("R046"), Faction.UNLIMITED); //Grasping Vines
      f.ModObjectLimit(FourCC("R047"), Faction.UNLIMITED); //Crippling Poison
      f.ModObjectLimit(FourCC("R048"), Faction.UNLIMITED); //Deadly Poison
      f.ModObjectLimit(FourCC("R008"), Faction.UNLIMITED); //Improved Natures FuryR015
      f.ModObjectLimit(FourCC("R015"), Faction.UNLIMITED); //Improved Mana Flare
    }
  }
}