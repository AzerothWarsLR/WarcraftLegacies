namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Tracks whether Roleplay mode is active, so faction-specific path/betrayal quests know whether to register themselves.
/// </summary>
public static class RoleplaySetting
{
  public static bool IsActive { get; private set; }

  public static void Apply()
  {
    IsActive = true;
  }
}
