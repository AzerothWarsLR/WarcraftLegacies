using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public static class DruidsSetup
  {
    public static Faction FACTION_DRUIDS;
    
    public static void Setup()
    {
      Faction f;

      FACTION_DRUIDS = Faction.create("Druids", PLAYER_COLOR_BROWN, "|c004e2a04",
        "ReplaceableTextures\\CommandButtons\\BTNFurion.blp");
      f = FACTION_DRUIDS;
      f.Team = TEAM_NIGHT_ELVES;
      f.UndefeatedResearch = FourCC(R06E);
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC(etol), UNLIMITED); //Tree of Life
      f.ModObjectLimit(FourCC(etoa), UNLIMITED); //Tree of Ages
      f.ModObjectLimit(FourCC(etoe), UNLIMITED); //Tree of Eternity
      f.ModObjectLimit(FourCC(emow), UNLIMITED); //Moon Well
      f.ModObjectLimit(FourCC(eate), UNLIMITED); //Altar of Elders
      f.ModObjectLimit(FourCC(eaoe), UNLIMITED); //Ancient of Lore
      f.ModObjectLimit(FourCC(eaow), UNLIMITED); //Ancient of Wind
      f.ModObjectLimit(FourCC(eaom), UNLIMITED); //Ancient of war
      f.ModObjectLimit(FourCC(etrp), UNLIMITED); //Ancient Protector
      f.ModObjectLimit(FourCC(e010), UNLIMITED); //Hunter)s Hall
      f.ModObjectLimit(FourCC(e019), UNLIMITED); //Ancient of Wonders
      f.ModObjectLimit(FourCC(eshy), UNLIMITED); //Night Elf Shipyard
      f.ModObjectLimit(FourCC(e000), UNLIMITED); //Improved Ancient Protector

      f.ModObjectLimit(FourCC(ewsp), UNLIMITED); //Wisp
      f.ModObjectLimit(FourCC(edry), UNLIMITED); //Dryad
      f.ModObjectLimit(FourCC(edot), UNLIMITED); //Druid of the Talon
      f.ModObjectLimit(FourCC(emtg), 12); //Mountain Giant
      f.ModObjectLimit(FourCC(efdr), 6); //Faerie Dragon
      f.ModObjectLimit(FourCC(edoc), UNLIMITED); //Druid of the Claw
      f.ModObjectLimit(FourCC(edcm), UNLIMITED); //Druid of the Claw bear form
      f.ModObjectLimit(FourCC(e00N), 6); //Keeper of the Grove
      f.ModObjectLimit(FourCC(n05H), UNLIMITED); //Furbolg
      f.ModObjectLimit(FourCC(n065), 6); //Green Dragon
      f.ModObjectLimit(FourCC(etrs), 12); //Night Elf Transport Ship
      f.ModObjectLimit(FourCC(edes), 12); //Night Elf Frigate
      f.ModObjectLimit(FourCC(ebsh), 6); //Night Elf Battleship

      f.ModObjectLimit(FourCC(Ecen), 1); //Cenarius
      f.ModObjectLimit(FourCC(E00H), 1); //Cenarius
      f.ModObjectLimit(FourCC(E00K), 1); //Tortolla
      f.ModObjectLimit(FourCC(Efur), 1); //Furion

      f.ModObjectLimit(FourCC(Redt), UNLIMITED); //Druid of the Talon Adept Training
      f.ModObjectLimit(FourCC(Renb), UNLIMITED); //Nature)s Blessing
      f.ModObjectLimit(FourCC(Rers), UNLIMITED); //Resistant Skin
      f.ModObjectLimit(FourCC(Reuv), UNLIMITED); //Ultravision
      f.ModObjectLimit(FourCC(Rews), UNLIMITED); //Well Spring
      f.ModObjectLimit(FourCC(R01H), UNLIMITED); //Malorne)s Power Infusion
      f.ModObjectLimit(FourCC(Redc), UNLIMITED); //Druid of the Claw Adept Training
      f.ModObjectLimit(FourCC(R04E), UNLIMITED); //Ysera)s Gift
      f.ModObjectLimit(FourCC(R02G), UNLIMITED); //Emerald Flames
      f.ModObjectLimit(FourCC(R05X), UNLIMITED); //Blessing of Ursoc
      f.ModObjectLimit(FourCC(R002), UNLIMITED); //Blackwald Enhancement
      f.ModObjectLimit(FourCC(R00A), UNLIMITED); //Improved Thorns
      f.ModObjectLimit(FourCC(R02T), UNLIMITED); //Improved Moonwells
      f.ModObjectLimit(FourCC(R033), UNLIMITED); //Limber Timber
      f.ModObjectLimit(FourCC(R046), UNLIMITED); //Grasping Vines
      f.ModObjectLimit(FourCC(R047), UNLIMITED); //Crippling Poison
      f.ModObjectLimit(FourCC(R048), UNLIMITED); //Deadly Poison
      f.ModObjectLimit(FourCC(R008), UNLIMITED); //Improved Natures FuryR015
      f.ModObjectLimit(FourCC(R015), UNLIMITED); //Improved Mana Flare
    }
  }
}