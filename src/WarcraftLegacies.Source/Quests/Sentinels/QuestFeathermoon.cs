using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  public sealed class QuestFeathermoon : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestFeathermoon(Rectangle rescueRect, LegendaryHero shandris) : base("Shores of Feathermoon",
      "Feathermoon Stronghold stood guard for ten thousand years, it is time to relieve the guards from their duty.",
      "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
    {
      AddObjective(new ObjectiveLegendReachRect(shandris, Regions.FeathermoonUnlock,
        "Feathermoon Stronghold"));
      AddObjective(new ObjectiveKillAllInArea(new List<Rectangle> { Regions.FeathermoonCreeps }, "around Feathermoon Stronghold"));
      AddObjective(new ObjectiveExpire(1485, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R06M_QUEST_COMPLETED_FEATHERMOON_STRONGHOLD;
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      Required = true;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Feathermoon Stronghold has been relieved and has joined the Sentinels in their war effort";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in Feathermoon Stronghold";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\SentinelTheme.mp3");
    }
  }
}