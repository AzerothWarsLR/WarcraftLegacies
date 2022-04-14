using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class PersonSetup
  {
    public static void Setup()
    {
      Player(0).SetFaction(FrostwolfSetup.FACTION_FROSTWOLF);
      Player(1).SetFaction(LordaeronSetup.FactionLordaeron);
      Player(2).SetFaction(QuelthalasSetup.FactionQuelthalas);
      Player(3).SetFaction(ScourgeSetup.FactionScourge);
      Player(4).SetFaction(IronforgeSetup.FACTION_IRONFORGE);
      Player(5).SetFaction(WarsongSetup.FACTION_WARSONG);
      Player(6).SetFaction(FelHordeSetup.FactionFelHorde);
      Player(7).SetFaction(DalaranSetup.Dalaran);
      Player(8).SetFaction(GoblinSetup.factionGoblin);
      Player(9).SetFaction(ForsakenSetup.FACTION_FORSAKEN);
      Player(10).SetFaction(StormwindSetup.Stormwind);
      Player(11).SetFaction(DruidsSetup.factionDruids);
      Player(12).SetFaction(ScarletSetup.FactionScarlet);
      Player(13).SetFaction(DraeneiSetup.Draenei);
      Player(14).SetFaction(BlackEmpireSetup.FactionBlackempire);
      Player(15).SetFaction(NagaSetup.FactionNaga);
      Player(16).SetFaction(CthunSetup.FactionCthun);
      Player(17).SetFaction(TrollSetup.FACTION_TROLL);
      Player(18).SetFaction(SentinelsSetup.Sentinels);
      Player(19).SetFaction(TwilightSetup.FACTION_TWILIGHT);
      Player(20).SetFaction(GilneasSetup.FACTION_GILNEAS);
      Player(21).SetFaction(KultirasSetup.FACTION_KULTIRAS);
      Player(22).SetFaction(LegionSetup.FactionLegion);
    }
  }
}