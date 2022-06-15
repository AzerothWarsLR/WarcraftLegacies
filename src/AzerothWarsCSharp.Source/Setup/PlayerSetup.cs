using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class PlayerSetup
  {
    public static void Setup()
    {
      Player(0).SetFaction(FrostwolfSetup.FACTION_FROSTWOLF);
      Player(0).SetTeam(TeamSetup.Horde);
      
      Player(1).SetFaction(LordaeronSetup.FactionLordaeron);
      Player(1).SetTeam(TeamSetup.Alliance);
      
      Player(2).SetFaction(QuelthalasSetup.FactionQuelthalas);
      Player(2).SetTeam(TeamSetup.Alliance);
      
      Player(3).SetFaction(ScourgeSetup.FactionScourge);
      Player(3).SetTeam(TeamSetup.Legion);
      
      Player(4).SetFaction(IronforgeSetup.FACTION_IRONFORGE);
      Player(4).SetTeam(TeamSetup.Alliance);
      
      Player(5).SetFaction(WarsongSetup.FACTION_WARSONG);
      Player(5).SetTeam(TeamSetup.Horde);
      
      Player(6).SetFaction(FelHordeSetup.FactionFelHorde);
      Player(6).SetTeam(TeamSetup.Legion);
      
      Player(7).SetFaction(DalaranSetup.Dalaran);
      Player(7).SetTeam(TeamSetup.Alliance);
      
      Player(8).SetFaction(GoblinSetup.factionGoblin);
      Player(8).SetTeam(TeamSetup.Horde);
      
      Player(9).SetFaction(ForsakenSetup.FACTION_FORSAKEN);
      Player(9).SetTeam(TeamSetup.Legion);
      
      Player(10).SetFaction(StormwindSetup.Stormwind);
      Player(10).SetTeam(TeamSetup.Alliance);
      
      Player(11).SetFaction(DruidsSetup.factionDruids);
      Player(11).SetTeam(TeamSetup.NightElves);
      
      Player(12).SetFaction(ScarletSetup.FactionScarlet);
      Player(12).SetTeam(TeamSetup.Alliance);
      
      Player(13).SetFaction(DraeneiSetup.Draenei);
      Player(13).SetTeam(TeamSetup.NightElves);
      
      Player(14).SetFaction(BlackEmpireSetup.FactionBlackempire);
      Player(14).SetTeam(TeamSetup.OldGods);
      
      Player(15).SetFaction(NagaSetup.FactionNaga);
      Player(15).SetTeam(TeamSetup.NightElves);
      
      Player(16).SetFaction(CthunSetup.FactionCthun);
      Player(16).SetTeam(TeamSetup.OldGods);
      
      Player(17).SetFaction(TrollSetup.FACTION_TROLL);
      Player(17).SetTeam(TeamSetup.Horde);
      
      Player(18).SetFaction(SentinelsSetup.Sentinels);
      Player(18).SetTeam(TeamSetup.NightElves);
      
      Player(19).SetFaction(TwilightSetup.FACTION_TWILIGHT);
      Player(19).SetTeam(TeamSetup.OldGods);
      
      Player(20).SetFaction(GilneasSetup.FACTION_GILNEAS);
      Player(20).SetTeam(TeamSetup.Alliance);
      
      Player(21).SetFaction(KultirasSetup.FACTION_KULTIRAS);
      Player(21).SetTeam(TeamSetup.Alliance);
      
      Player(22).SetFaction(LegionSetup.FactionLegion);
      Player(22).SetTeam(TeamSetup.Legion);
    }
  }
}