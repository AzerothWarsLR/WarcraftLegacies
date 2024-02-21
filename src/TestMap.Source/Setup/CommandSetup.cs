using MacroTools.Commands;
using MacroTools.CommandSystem;

namespace TestMap.Source.Setup
{
  public static class CommandSetup
  {
    public static void Setup(CommandManager commandManager)
    {
      commandManager.Register(new ListArtifacts());
      commandManager.Register(new Artifact());
      commandManager.CreateInfoQuest();
    }
  }
}