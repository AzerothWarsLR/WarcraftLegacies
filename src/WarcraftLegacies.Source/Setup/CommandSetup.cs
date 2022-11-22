using MacroTools.Commands;
using MacroTools.CommandSystem;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.Setup
{
  public static class CommandSetup
  {
    public static void Setup()
    {
      InviteCommand.Setup();
      JoinCommand.Setup();
      LimitedCommand.Setup();
      ObserverCommand.Setup();
      UnallyCommand.Setup();
      UninviteCommand.Setup();
      CommandManager.Register(new Limited());
      CommandManager.Register(new Clear());
      CommandManager.Register(new Cam());
    }
  }
}