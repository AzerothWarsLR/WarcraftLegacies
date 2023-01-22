using MacroTools.Commands;
using MacroTools.CommandSystem;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.Setup
{
  public static class CommandSetup
  {
    public static void Setup(CommandManager commandManager)
    {
      InviteCommand.Setup();
      JoinCommand.Setup();
      LimitedCommand.Setup();
      ObserverCommand.Setup();
      UnallyCommand.Setup();
      UninviteCommand.Setup();
      commandManager.Register(new Limited());
      commandManager.Register(new Clear());
      commandManager.Register(new Cam());
    }
  }
}