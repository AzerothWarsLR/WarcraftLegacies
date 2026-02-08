using MacroTools.Commands;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.Setup;

public static class CommandSetup
{
  public static void Setup(CommandManager commandManager)
  {
    commandManager.Register(new Limited());
    commandManager.Register(new Clear("clear"));
    commandManager.Register(new Clear("c"));
    commandManager.Register(new Cam());
    commandManager.Register(new Captions());
    commandManager.Register(new QuestText());
    commandManager.Register(new Dialogue());
    commandManager.Register(new Settings());
    commandManager.Register(new Share());
    commandManager.Register(new GiveGold("givegold"));
    commandManager.Register(new GiveGold("gold"));
    commandManager.Register(new GiveGold("g"));
    commandManager.Register(new Observer());
    commandManager.CreateInfoQuest();
  }
}
