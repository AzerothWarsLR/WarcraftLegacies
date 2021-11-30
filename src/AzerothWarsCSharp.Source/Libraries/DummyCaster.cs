using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class DummyCaster
  {
    private static bool _initialized;
    private static unit _dummyUnit;

    private static void Initialize()
    {
      if (!_initialized)
      {
        _dummyUnit = CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), FourCC("u00X"), 0, 0, 0);
        _initialized = true;
      }
    }
    
    public static unit DummyUnit
    {
      get
      {
        if (!_initialized)
        {
          Initialize();
        }
        return _dummyUnit;
      }
    }
  }
}