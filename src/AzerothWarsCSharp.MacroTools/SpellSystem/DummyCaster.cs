namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  public static class DummyCaster
  {
    private static bool _initialized;
    private static unit _dummyUnit;

    private static void Initialize()
    {
      if (!_initialized)
      {
        _dummyUnit = CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE), UnitTypeId, 0, 0, 0);
        _initialized = true;
      }
    }

    public static int UnitTypeId { get; } = FourCC("u00X");
    
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