using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.Legends;
using MacroTools;

namespace WarcraftLegacies.Source.Quests.Dragonmaw
{
  public sealed class QuestWetlandOffensive : QuestData
  {
    public QuestWetlandOffensive() : base("The Menethil Harbor Offensive",
      "Nek'rosh has a grudge against the alliance for the death of his father. His first target is the port town of Menethil Harbor.",
      "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendIronforge.LegendMenethilHarbor));
      AddObjective(new ObjectiveControlLegend(LegendDragonmaw.LegendNekrosh, false));
      AddObjective(new ObjectiveControlLegend(LegendDragonmaw.DragonmawPort, true));
    }

    protected override string CompletionPopup =>
      "Nek'rosh's revenge is finally complete and the plounder of Menethil Harbor will give the Dragonmaw plenty of ressources for the wars to come";

    protected override string RewardDescription => "3000 experience for Nek'rosh and 750 gold at turn 10";

    protected override void OnComplete(Faction completingFaction)
    {
      CreateTimer().Start(900 - GameTime.GetGameTime(), false, () =>
      {
        AddHeroXP(LegendDragonmaw.LegendNekrosh.Unit, 3000, true);
        completingFaction.Player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, 750);
        GetExpiredTimer().Destroy();
      });
    }
  }
}