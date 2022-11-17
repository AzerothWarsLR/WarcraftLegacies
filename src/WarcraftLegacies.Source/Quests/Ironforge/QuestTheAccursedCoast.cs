using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.Legends;
using MacroTools;

namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestTheAccursedCoast : QuestData
  {
    public QuestTheAccursedCoast() : base("The Accused Coast",
      "The Dragonmaw orcs of the Dragonmaw Port have been getting more and more daring. They are now menacing to destroy Menethil Harbor. The Dwarves will have to respond in kind to keep their lands safe",
      "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendIronforge.LegendMenethilHarbor, true));
      AddObjective(new ObjectiveLegendDead(LegendDragonmaw.DragonmawPort));
    }

    protected override string CompletionPopup =>
      "With the Dragonmaw Port destroyed, the threat of the Dragonmaw Clan to Menethil Harbor is all but gone.";

    protected override string RewardDescription => "500 gold at turn 10";

    protected override void OnComplete(Faction completingFaction)
    {
      CreateTimer().Start(600 - GameTime.GetGameTime(), false, () =>
      {
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 500);
        GetExpiredTimer().Destroy();
      });
    }
  }
}