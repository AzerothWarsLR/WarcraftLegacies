using MacroTools.Commands;
using MacroTools.CommandSystem;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.Setup
{
  public static class CommandSetup
  {
    public static void Setup(CommandManager commandManager)
    {
      ObserverCommand.Setup();
      commandManager.Register(new Limited());
      commandManager.Register(new Clear("clear"));
      commandManager.Register(new Clear("c"));
      commandManager.Register(new Cam());
      commandManager.Register(new Captions());
      commandManager.Register(new QuestText());
      commandManager.Register(new MacroTools.Commands.Dialogue());
      commandManager.Register(new Settings());
      commandManager.Register(new Share());
      commandManager.Register(new GiveGold("givegold"));
      commandManager.Register(new GiveGold("gold"));
      commandManager.Register(new GiveGold("g"));
      commandManager.Register(new GiveLumber("givelumber"));
      commandManager.Register(new GiveLumber("lumber"));
      commandManager.Register(new GiveLumber("l"));
      commandManager.Register(new ListArtifacts());
      commandManager.Register(new Artifact());
      commandManager.Register(new MacroTools.Commands.Powers());
      commandManager.CreateInfoQuest();
    }
  }
}