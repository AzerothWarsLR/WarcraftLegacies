using MacroTools.Cheats;
using MacroTools.CommandSystem;
using MacroTools.QuestSystem;

namespace TestMap.Source.Setup
{
  public static class CheatSetup
  {
    public static void Setup(CommandManager commandManager)
    {
      commandManager.Register(new CheatLevel());
      commandManager.Register(new CheatResearchLevel());
      commandManager.Register(new CheatBuild());
      commandManager.Register(new CheatControl());
      commandManager.Register(new CheatFaction());
      commandManager.Register(new CheatFood());
      commandManager.Register(new CheatGold());
      commandManager.Register(new CheatHp());
      commandManager.Register(new CheatKick());
      commandManager.Register(new CheatQuestProgress("complete", QuestProgress.Complete));
      commandManager.Register(new CheatQuestProgress("fail", QuestProgress.Failed));
      commandManager.Register(new CheatQuestProgress("uncomplete", QuestProgress.Incomplete));
      commandManager.Register(new CheatQuestProgress("undiscover", QuestProgress.Undiscovered));
      commandManager.Register(new CheatMana());
      commandManager.Register(new CheatMp());
      commandManager.Register(new CheatNocd());
      commandManager.Register(new CheatOwner());
      commandManager.Register(new CheatRemove());
      commandManager.Register(new CheatSpawn());
      commandManager.Register(new CheatTele());
      commandManager.Register(new CheatTime());
      commandManager.Register(new CheatUncontrol());
      commandManager.Register(new CheatVision());
      commandManager.Register(new CheatTeam());
      commandManager.Register(new CheatAddSpell());
      commandManager.Register(new CheatSetResearchLevel());
      commandManager.Register(new CheatDestroy());
      commandManager.Register(new CheatGod());
      commandManager.Register(new CheatPosition());
      commandManager.Register(new CheatGetUnitAbilities());
      commandManager.Register(new CheatRemoveAllAbilities());
      commandManager.Register(new CheatGetUnitCurrentOrder());
      commandManager.Register(new CheatRemovePower());
      TestMode.Setup(commandManager);
    }
  }
}