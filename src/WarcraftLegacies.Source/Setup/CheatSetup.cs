using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Commands;
using WarcraftLegacies.Source.Cheats;

namespace WarcraftLegacies.Source.Setup;

public static class CheatSetup
{
  public static void Setup()
  {
    CommandManager.Register(new CheatAddSpell());
    CommandManager.Register(new CheatResearchLevel());
    CommandManager.Register(new CheatBuild());
    CommandManager.Register(new CheatDestroy());
    CommandManager.Register(new CheatHelp());
    CommandManager.Register(new CheatFaction());
    CommandManager.Register(new CheatPower());
    CommandManager.Register(new CheatQuest());
    CommandManager.Register(new CheatFood());
    CommandManager.Register(new CheatGod());
    CommandManager.Register(new CheatGold());
    CommandManager.Register(new CheatHp());
    CommandManager.Register(new CheatKick());
    CommandManager.Register(new CheatLevel());
    CommandManager.Register(new CheatMana());
    CommandManager.Register(new CheatMp());
    CommandManager.Register(new CheatNocd());
    CommandManager.Register(new CheatOwner());
    CommandManager.Register(new CheatRemove());
    CommandManager.Register(new CheatResearchLevel());
    CommandManager.Register(new CheatSetResearchLevel());
    CommandManager.Register(new CheatSpawn());
    CommandManager.Register(new CheatTele());
    CommandManager.Register(new CheatTime());
    CommandManager.Register(new CheatVision());
    CommandManager.Register(new CheatShore());
    CommandManager.Register(new CheatPosition());
    CommandManager.Register(new CheatGetUnitAbilities());
    CommandManager.Register(new CheatRemoveAllAbilities());
    CommandManager.Register(new CheatSkipTurns());
    CommandManager.Register(new CheatPermaKill());
    CommandManager.Register(new CheatGetUnitCurrentOrder());
    CommandManager.Register(new AssembleZinrokh(new List<Artifact>
    {
      Artifacts.AzureFragment,
      Artifacts.BronzeFragment,
      Artifacts.EmeraldFragment,
      Artifacts.RubyFragment,
      Artifacts.ObsidianFragment
    }));
    CommandManager.Register(new CheatGetWaygateDestination());
    CommandManager.Register(new CheatPause());
    CommandManager.Register(new CheatLimit());
    CommandManager.Register(new CheatForceWin());
    CommandManager.Register(new CheatBenchmark());
    TestMode.Setup();
    CheatSkipCinematic.Init();
  }
}
