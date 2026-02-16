using MacroTools.Commands;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.Setup;

public static class CommandSetup
{
  public static void Setup()
  {
    CommandManager.Register(new Limited());
    CommandManager.Register(new Clear("clear"));
    CommandManager.Register(new Clear("c"));
    CommandManager.Register(new Cam());
    CommandManager.Register(new Captions());
    CommandManager.Register(new QuestText());
    CommandManager.Register(new Dialogue());
    CommandManager.Register(new Settings());
    CommandManager.Register(new Share());
    CommandManager.Register(new Unshare());
    CommandManager.Register(new Text());
    CommandManager.Register(new GiveGold("givegold"));
    CommandManager.Register(new GiveGold("gold"));
    CommandManager.Register(new GiveGold("g"));
    CommandManager.Register(new Observer());
    CommandManager.CreateInfoQuest();
  }
}
