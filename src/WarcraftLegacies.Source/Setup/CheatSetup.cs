using MacroTools.Cheats;
using MacroTools.CommandSystem;
using WarcraftLegacies.Source.Cheats;

namespace WarcraftLegacies.Source.Setup
{
  public static class CheatSetup
  {
    public static void Setup()
    {
      TestMode.Setup();
      CheatBuild.Setup();
      CheatControl.Setup();
      CheatFaction.Setup();
      CheatFood.Setup();
      CheatGold.Setup();
      CheatHasResearch.Setup();
      CheatHp.Setup();
      CheatKick.Setup();
      CheatLevel.Setup();
      CommandManager.Register(new CheatLumber());
      CommandManager.Register(new CheatMana());
      CommandManager.Register(new CheatMp());
      CommandManager.Register(new CheatNocd());
      CommandManager.Register(new CheatOwner());
      CommandManager.Register(new CheatRemove());
      CheatSkipCinematic.Setup();
      CommandManager.Register(new CheatSpawn());
      CommandManager.Register(new CheatTele());
      CommandManager.Register(new CheatTime());
      CommandManager.Register(new CheatUncontrol());
      CommandManager.Register(new CheatVision());
      CheatCompleteQuest.Setup();
      CheatAddRandomAugment.Setup();
      CheatAugment.Setup();
      CommandManager.Register(new CommandTeam());
      CommandManager.Register(new CommandAddSpell());
      CommandManager.Register(new CommandSetResearchLevel());
      CommandManager.Register(new CommandDestroy());
      CommandManager.Register(new CheatGod());
    }
  }
}