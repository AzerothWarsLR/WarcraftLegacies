using MacroTools.Cheats;
using MacroTools.CommandSystem;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Cheats;

namespace WarcraftLegacies.Source.Setup
{
  public static class CheatSetup
  {
    public static void Setup()
    {
      TestMode.Setup();
      CommandManager.Register(new CheatAddSpell());
      CommandManager.Register(new CheatResearchLevel());
      CommandManager.Register(new CheatBuild());
      CommandManager.Register(new CheatQuestProgress("complete", QuestProgress.Complete));
      CommandManager.Register(new CheatQuestProgress("fail", QuestProgress.Failed));
      CommandManager.Register(new CheatQuestProgress("uncomplete", QuestProgress.Incomplete));
      CommandManager.Register(new CheatQuestProgress("undiscover", QuestProgress.Undiscovered));
      CommandManager.Register(new CheatControl());
      CommandManager.Register(new CommandDestroy());
      CommandManager.Register(new CheatFaction());
      CommandManager.Register(new CheatFood());
      CommandManager.Register(new CheatGod());
      CommandManager.Register(new CheatGold());
      CommandManager.Register(new CheatHp());
      CommandManager.Register(new CheatKick());
      CommandManager.Register(new CheatLevel());
      CommandManager.Register(new CheatLumber());
      CommandManager.Register(new CheatMana());
      CommandManager.Register(new CheatMp());
      CommandManager.Register(new CheatNocd());
      CommandManager.Register(new CheatOwner());
      CommandManager.Register(new CheatRemove());
      CommandManager.Register(new CheatResearchLevel());
      CommandManager.Register(new CommandSetResearchLevel());
      CommandManager.Register(new CheatShowQuestNames());
      CommandManager.Register(new CheatSpawn());
      CommandManager.Register(new CommandTeam());   
      CommandManager.Register(new CheatTele());
      CommandManager.Register(new CheatTime());
      CommandManager.Register(new CheatUncontrol());
      CommandManager.Register(new CheatVision());
      CheatSkipCinematic.Setup();
    }
  }
}