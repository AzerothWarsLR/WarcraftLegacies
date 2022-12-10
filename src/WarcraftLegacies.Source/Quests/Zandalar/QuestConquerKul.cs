using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Zandalar
{
  /// <summary>
  /// Destroy <see cref="LegendKultiras.LegendBoralus"/> without losing <see cref="LegendNeutral.Dazaralor"/> 
  /// </summary>
  public sealed class QuestConquerKul : QuestData
  {
    private readonly QuestData _completeOnFailQuest;
    private readonly QuestData _failOnFailQuest;
    private readonly Rectangle _onFailSpawnRect;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestConquerKul"/> class
    /// </summary>
    /// <param name="onFailSpawnRect"></param>
    /// <param name="completeOnFailQuest">Quest that gets completed upon failing <see cref="QuestConquerKul"/>.</param>
    /// <param name="failOnFailQuest">Quest that is failed upon failing <see cref="QuestConquerKul"/>. </param>
    public QuestConquerKul(Rectangle onFailSpawnRect, QuestData completeOnFailQuest, QuestData failOnFailQuest) : base(
      "Conquer Boralus",
      "The Kul'tiran people and their fleet have been a threat to the Zandalari Empire for ages, it is time to put them to rest.",
      "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Dazaralor, true));
      AddObjective(new ObjectiveLegendDead(LegendKultiras.LegendBoralus));
      ResearchId = Constants.UPGRADE_R08D_QUEST_COMPLETED_CONQUER_BORALUS;
      _onFailSpawnRect = onFailSpawnRect;
      _completeOnFailQuest = completeOnFailQuest;
      _failOnFailQuest = failOnFailQuest;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "Before setting sails we need to conquer Kul'tiras";

    /// <inheritdoc/>>
    protected override string RewardDescription => "Unlock shipyards";

    /// <inheritdoc/>
    protected override string FailurePopup => "Zandalar has fallen.";

    /// <inheritdoc/>
    protected override string PenaltyDescription =>
      "You lose everything you control and can no longer build shipyards, but you unlock Zul'Farrak";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.Player?.AddGold(750);
      KultirasSetup.Kultiras?.Player?.SetTeam(TeamSetup.Alliance);
      ZandalarSetup.Zandalar?.Player?.SetTeam(TeamSetup.Horde);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      completingFaction.Obliterate();
      if (completingFaction.Player != null)
      {
        _completeOnFailQuest.Progress = QuestProgress.Complete;
        _failOnFailQuest.Progress = QuestProgress.Failed;

        LegendTroll.LEGEND_PRIEST.ForceCreate(completingFaction.Player,
          new Point(_onFailSpawnRect.Center.X, _onFailSpawnRect.Center.Y), 110);
        LegendTroll.LEGEND_RASTAKHAN.ForceCreate(completingFaction.Player,
          new Point(_onFailSpawnRect.Center.X, _onFailSpawnRect.Center.Y), 110);
        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(_onFailSpawnRect.Center.X, _onFailSpawnRect.Center.Y);
        completingFaction.Player.AddGold(1500);
        completingFaction.Player.AddLumber(2000);

        GeneralHelpers.CreateUnits(completingFaction.Player, Constants.UNIT_H021_WATCHER_TROLL,
          Regions.TrollSecondChance.Center.X, Regions.TrollSecondChance.Center.Y, 270, 8);
        GeneralHelpers.CreateUnits(completingFaction.Player, Constants.UNIT_O04A_GATHERER_TROLL_ZANDALARI_WORKER,
          Regions.TrollSecondChance.Center.X, Regions.TrollSecondChance.Center.Y, 270, 8);
        GeneralHelpers.CreateUnits(completingFaction.Player, Constants.UNIT_O04D_SCOUT_TROLL,
          Regions.TrollSecondChance.Center.X, Regions.TrollSecondChance.Center.Y, 270, 6);
        GeneralHelpers.CreateUnits(completingFaction.Player, Constants.UNIT_H05D_RAPTOR_RIDER_TROLL,
          Regions.TrollSecondChance.Center.X, Regions.TrollSecondChance.Center.Y, 270, 4);
        GeneralHelpers.CreateUnits(completingFaction.Player, Constants.UNIT_O04W_GOLDEN_VESSEL_ZANDALAR,
          Regions.TrollSecondChance.Center.X, Regions.TrollSecondChance.Center.Y, 270, 3);
      }

      KultirasSetup.Kultiras?.Player?.SetTeam(TeamSetup.Alliance);
      ZandalarSetup.Zandalar?.Player?.SetTeam(TeamSetup.Horde);
    }
  }
}