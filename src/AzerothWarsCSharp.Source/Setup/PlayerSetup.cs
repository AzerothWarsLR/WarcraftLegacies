using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class PlayerSetup
  {
    public static void Initialize()
    {
      ScourgeSetup.Scourge.Player = Player(0);
      LegionSetup.Legion.Player = Player(1);
      FelHordeSetup.FelHorde.Player = Player(2);
      LordaeronSetup.Lordaeron.Player = Player(3);
      IronforgeSetup.Ironforge.Player = Player(4);
      DalaranSetup.Dalaran.Player = Player(5);
      QuelthalasSetup.Quelthalas.Player = Player(6);
      FrostwolfSetup.Frostwolf.Player = Player(7);
      WarsongSetup.Warsong.Player = Player(8);
      SentinelsSetup.Sentinels.Player = Player(9);
      StormwindSetup.Stormwind.Player = Player(10);
      DruidsSetup.Druids.Player = Player(11);
    }
  }
}
