using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.Legends;
using MacroTools;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;

namespace WarcraftLegacies.Source.Quests.Dragonmaw
{
  public sealed class QuestDunAlgazSiege : QuestData
  {
    public QuestDunAlgazSiege() : base("The Siege of Dun Algaz",
      "The town of Thelsamar has accumulated riches by being the gateway between the south and north. Plundering it would provide great treasures for the Dragonmaw Clan",
      "ReplaceableTextures\\CommandButtons\\BTNDwarvenKeep.blp")
    {
      AddObjective(new ObjectiveCapitalDead(LegendIronforge.LegendThelsamar));
      AddObjective(new ObjectiveControlLegend(LegendDragonmaw.Zaela, false));
      AddObjective(new ObjectiveControlCapital(LegendNeutral.GrimBatol, false));
      AddObjective(new ObjectiveExpire(600));
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Zaela emerges victorious, having pillaged Thelsamar, uncovering great treasures to bring back to the clan.";

    /// <inheritdoc />
    protected override string RewardDescription => "3000 experience for Zaela, 750 lumber and 750 gold at turn 10";

    /// <inheritdoc />
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
      AddHeroXP(LegendDragonmaw.Zaela.Unit, 3000, true);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 750);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 750);
      GetExpiredTimer().Destroy();
    }
  }
}