using WarcraftLegacies.MacroTools.Cheats;
using WarcraftLegacies.MacroTools.CheatSystem;
using WarcraftLegacies.Source.Cheats;

namespace WarcraftLegacies.Source.Setup
{
  public static class CheatSetup
  {
    public static void Setup()
    {
      TestSafety.Setup();
      CheatBuild.Setup();
      CheatControl.Setup();
      CheatFaction.Setup();
      CheatFood.Setup();
      CheatGod.Setup();
      CheatGold.Setup();
      CheatHasResearch.Setup();
      CheatHp.Setup();
      CheatKick.Setup();
      CheatLevel.Setup();
      CheatLumber.Setup();
      CheatMana.Setup();
      CheatMp.Setup();
      CheatNocd.Setup();
      CheatOwner.Setup();
      CheatRemove.Setup();
      CheatSkipCinematic.Setup();
      CheatSpawn.Setup();
      CheatTeam.Setup();
      CheatTele.Setup();
      CheatTime.Setup();
      CheatUncontrol.Setup();
      CheatVision.Setup();
      CheatCompleteQuest.Setup();
      CheatAddRandomAugment.Setup();
      CheatAugment.Setup();
      CheatManager.Register(new CheatAddSpell());
      CheatManager.Register(new CheatSetResearchLevel());
    }
  }
}