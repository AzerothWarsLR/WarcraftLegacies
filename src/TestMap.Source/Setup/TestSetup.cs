namespace TestMap.Source.Setup;

public static class TestSetup
{
  public static void Setup()
  {
    CreateUnit(Player(0), FourCC("halt"), 0, 0, 0);
    SetPlayerState(Player(0), PLAYER_STATE_RESOURCE_LUMBER, 20000);
    SetPlayerState(Player(0), PLAYER_STATE_RESOURCE_GOLD, 20000);
  }
}
