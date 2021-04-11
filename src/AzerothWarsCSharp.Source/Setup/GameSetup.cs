using AzerothWarsCSharp.Source.Commands;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.UserInterface;

namespace AzerothWarsCSharp.Source.Setup
{
  public class GameSetup
  {
    public static void Initialize()
    {
			//Commands
			CheatControl.Initialize();
			CheatFaction.Initialize();
			CheatFood.Initialize();
			CheatGod.Initialize();
			CheatGold.Initialize();
			CheatHasResearch.Initialize();
			CheatHP.Initialize();
			CheatKick.Initialize();
			CheatLevel.Initialize();
			CheatLumber.Initialize();
			CheatMP.Initialize();
			CheatNoCD.Initialize();
			CheatOwner.Initialize();
			CheatRemove.Initialize();
			CheatSkipCinematic.Initialize();
			CheatSpawn.Initialize();
			CheatTeam.Initialize();
			CheatTele.Initialize();
			CheatUncontrol.Initialize();
			CheatUnlimitedMana.Initialize();
			CheatVision.Initialize();
			//General
			Hint.Initialize();
			NormalHintsSetup.Initialize();
			VictoryHintsSetup.Initialize();
			TeamSetup.Initialize();
      FactionSetup.Initialize();
			//User interface
      FactionMultiboard.Initialize();
    }
  }
}
