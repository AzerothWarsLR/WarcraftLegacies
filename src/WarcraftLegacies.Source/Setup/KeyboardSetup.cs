using WarcraftLegacies.Source.KeyboardManager;

namespace WarcraftLegacies.Source.Setup
{
  public static class KeyboardSetup
  {
    public static void InitializeKeyboard()
    {
      var hotkeyManager = new HeroHotkeyManager();
      
      for (int i = 0; i < 24; i++) 
      {
        var player = Player(i);
        hotkeyManager.Initialize(player);
      }
    }
  }
}