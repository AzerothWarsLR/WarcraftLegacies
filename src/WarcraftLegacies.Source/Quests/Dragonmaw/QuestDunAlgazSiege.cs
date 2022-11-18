using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.Legends;
using MacroTools;

namespace WarcraftLegacies.Source.Quests.Dragonmaw
{
  public sealed class QuestDunAlgazSiege : QuestData
  {
    public QuestDunAlgazSiege() : base("The Siege of Dun Algaz",
      "The town of Thelsamar has accumulated riches by being the gateway between the south and north. Plundering it would provide great treasures for the Dragonmaw Clan",
      "ReplaceableTextures\\CommandButtons\\BTNDwarvenKeep.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendIronforge.LegendThelsamar));
      AddObjective(new ObjectiveControlLegend(LegendDragonmaw.LegendZaela, false));
      AddObjective(new ObjectiveControlLegend(LegendNeutral.LegendGrimbatol, true));
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Zaela emerges victorious, having pillaged Thelsamar, uncovering great treasures to bring back to the clan.";

    /// <inheritdoc />
    protected override string RewardDescription => "3000 experience for Zaela and 750 gold at turn 10";

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
      AddHeroXP(LegendDragonmaw.LegendZaela.Unit, 3000, true);
      completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 750);
      GetExpiredTimer().Destroy();
    }
  }
}