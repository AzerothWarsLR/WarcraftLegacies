using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  public static class PlayerSetup
  {
    public static void Setup()
    {
      Player(0).SetFaction(FrostwolfSetup.Frostwolf);
      Player(0).SetTeam(TeamSetup.Horde);
      
      Player(1).SetFaction(LordaeronSetup.Lordaeron);
      Player(1).SetTeam(TeamSetup.Alliance);
      
      Player(2).SetFaction(QuelthalasSetup.Quelthalas);
      Player(2).SetTeam(TeamSetup.Alliance);
      
      Player(3).SetFaction(ScourgeSetup.Scourge);
      Player(3).SetTeam(TeamSetup.Legion);
      
      Player(4).SetFaction(IronforgeSetup.Ironforge);
      Player(4).SetTeam(TeamSetup.Alliance);
      
      Player(5).SetFaction(WarsongSetup.WarsongClan);
      Player(5).SetTeam(TeamSetup.Horde);
      
      Player(6).SetFaction(FelHordeSetup.FelHorde);
      Player(6).SetTeam(TeamSetup.Legion);
      
      Player(7).SetFaction(DalaranSetup.Dalaran);
      Player(7).SetTeam(TeamSetup.Alliance);
      
      Player(8).SetFaction(GoblinSetup.Goblin);
      Player(8).SetTeam(TeamSetup.Horde);
      
      Player(9).SetFaction(ForsakenSetup.Forsaken);
      Player(9).SetTeam(TeamSetup.Legion);
      
      Player(10).SetFaction(StormwindSetup.Stormwind);
      Player(10).SetTeam(TeamSetup.Alliance);
      
      Player(11).SetFaction(DruidsSetup.Druids);
      Player(11).SetTeam(TeamSetup.NightElves);
      
      Player(12).SetFaction(ScarletSetup.ScarletCrusade);
      Player(12).SetTeam(TeamSetup.Alliance);
      
      Player(13).SetFaction(DraeneiSetup.Draenei);
      Player(13).SetTeam(TeamSetup.Draenei);

      Player(15).SetFaction(IllidanSetup.Illidan);
      Player(15).SetTeam(TeamSetup.NightElves);

      Player(16).SetFaction(DragonmawSetup.Dragonmaw);
      Player(16).SetTeam(TeamSetup.Dragonmaw);
      
      Player(17).SetFaction(ZandalarSetup.Zandalar);
      Player(17).SetTeam(TeamSetup.Horde);
      
      Player(18).SetFaction(SentinelsSetup.Sentinels);
      Player(18).SetTeam(TeamSetup.NightElves);
      
      Player(20).SetFaction(GilneasSetup.Gilneas);
      Player(20).SetTeam(TeamSetup.Alliance);
      
      Player(22).SetFaction(KultirasSetup.Kultiras);
      Player(22).SetTeam(TeamSetup.Alliance);
      
      Player(23).SetFaction(LegionSetup.Legion);
      Player(23).SetTeam(TeamSetup.Legion);
    }
  }
}