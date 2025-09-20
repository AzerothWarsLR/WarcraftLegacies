using WarcraftLegacies.Source.KeyboardManager;

namespace WarcraftLegacies.Source.Setup;

public static class KeyboardSetup
{
  public static void InitializeKeyboard()
  {
    for (var i = 0; i < 24; i++)
    {
      var player = Player(i);
      var hotkeyManager = new HeroHotkeyManager();
      hotkeyManager.Initialize(player);
    }
  }
}
