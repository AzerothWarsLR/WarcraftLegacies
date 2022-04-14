using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class PersonSetup
  {
    public static void Setup()
    {
      PlayerData.Register(new PlayerData(Player(0)) 
        {Faction = FrostwolfSetup.FACTION_FROSTWOLF}
      );

      PlayerData.Register(new PlayerData(Player(1)) 
        {Faction = LordaeronSetup.FactionLordaeron}
      );

      PlayerData.Register(new PlayerData(Player(2)) 
        {Faction = QuelthalasSetup.FactionQuelthalas}
      );

      PlayerData.Register(new PlayerData(Player(3)) 
        {Faction = ScourgeSetup.FactionScourge}
      );

      PlayerData.Register(new PlayerData(Player(4)) 
        {Faction = IronforgeSetup.FACTION_IRONFORGE}
      );

      PlayerData.Register(new PlayerData(Player(5)) 
        {Faction = WarsongSetup.FACTION_WARSONG}
      );

      PlayerData.Register(new PlayerData(Player(6)) 
        {Faction = FelHordeSetup.FactionFelHorde}
      );

      PlayerData.Register(new PlayerData(Player(7)) 
        {Faction = DalaranSetup.Dalaran}
      );

      PlayerData.Register(new PlayerData(Player(8)) 
        {Faction = GoblinSetup.factionGoblin}
      );

      PlayerData.Register(new PlayerData(Player(9)) 
        {Faction = ForsakenSetup.FACTION_FORSAKEN}
      );

      PlayerData.Register(new PlayerData(Player(10)) 
        {Faction = StormwindSetup.Stormwind}
      );

      PlayerData.Register(new PlayerData(Player(11)) 
        {Faction = DruidsSetup.factionDruids}
      );

      PlayerData.Register(new PlayerData(Player(12)) 
        {Faction = ScarletSetup.FactionScarlet}
      );

      PlayerData.Register(new PlayerData(Player(13)) 
        {Faction = DraeneiSetup.Draenei}
      );

      PlayerData.Register(new PlayerData(Player(14)) 
        {Faction = BlackEmpireSetup.FactionBlackempire}
      );

      PlayerData.Register(new PlayerData(Player(15)) 
        {Faction = NagaSetup.FactionNaga}
      );

      PlayerData.Register(new PlayerData(Player(16)) 
        {Faction = CthunSetup.FactionCthun}
      );

      PlayerData.Register(new PlayerData(Player(17)) 
        {Faction = TrollSetup.FACTION_TROLL}
      );

      PlayerData.Register(new PlayerData(Player(18)) 
        {Faction = SentinelsSetup.Sentinels}
      );

      PlayerData.Register(new PlayerData(Player(19)) 
        {Faction = TwilightSetup.FACTION_TWILIGHT}
      );

      PlayerData.Register(new PlayerData(Player(20)) 
        {Faction = GilneasSetup.FACTION_GILNEAS}
      );

      PlayerData.Register(new PlayerData(Player(22)) 
        {Faction = KultirasSetup.FACTION_KULTIRAS}
      );
      
      PlayerData.Register(new PlayerData(Player(23)) 
        {Faction = LegionSetup.FactionLegion}
      );

      PlayerData.Register(new PlayerData(Player(21))
      );
    }
  }
}