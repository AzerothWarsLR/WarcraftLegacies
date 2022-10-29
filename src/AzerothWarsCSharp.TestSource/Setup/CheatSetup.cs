using AzerothWarsCSharp.MacroTools.Cheats;
using AzerothWarsCSharp.MacroTools.CheatSystem;

namespace AzerothWarsCSharp.TestSource.Setup
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