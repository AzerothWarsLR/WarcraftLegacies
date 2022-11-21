using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.Legends;
using MacroTools;
using System;

namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestGrimBatolOffensive : QuestData
  {
    public QuestGrimBatolOffensive() : base("Grim Batol",
      "The cursed fortress of Grim Batol was once a Dwarf hold. It is now used as a base of operation to threaten the safety of the town of Thelsamar. Conquer the fortress back in the name of Khaz Modan.",
      "ReplaceableTextures\\CommandButtons\\BTNDwarvenKeep.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendIronforge.LegendThelsamar, false));
      AddObjective(new ObjectiveControlLegend(LegendNeutral.GrimBatol, false));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendIronforge.LegendThelsamar));
      AddObjective(new ObjectiveExpire(600));
    }

    protected override string CompletionPopup =>
      "With Grim Batol under the control of the Dwarf, Thelsamar and the surrounding lands are now safe again";

    protected override string RewardDescription => "500 gold at turn 10";

    protected override void OnComplete(Faction completingFaction)
    {
      var timeUntilReward = 600 - GameTime.GetGameTime();
      if (timeUntilReward <= 0)
        GiveReward(completingFaction);
      else
        CreateTimer().Start(Math.Max(600 - GameTime.GetGameTime(), 0), false, () =>
        {
          GiveReward(completingFaction);
        });
    }

    private static void GiveReward(Faction completingFaction)
    {
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 500);
      GetExpiredTimer().Destroy();
    }
  }
}