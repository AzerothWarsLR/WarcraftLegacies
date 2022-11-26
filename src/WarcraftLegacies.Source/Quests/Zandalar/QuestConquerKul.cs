using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using System.Collections.Generic;
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
    private readonly List<QuestData> _failOnFailQuests;
    private readonly Rectangle _onFailSpawnRect;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestConquerKul"/> class
    /// </summary>
    /// <param name="onFailSpawnRect"></param>
    /// <param name="completeOnFailQuest">Quest that gets completed upon failing <see cref="QuestConquerKul"/>.</param>
    /// <param name="failOnFailQuests">Quests that are failed upon failing <see cref="QuestConquerKul"/>. </param>
    public QuestConquerKul(Rectangle onFailSpawnRect, QuestData completeOnFailQuest, List<QuestData> failOnFailQuests) : base("Conquer Boralus",
      "The Kul'tiran people and their fleet have been a threat to the Zandalari Empire for ages, it is time to put them to rest.",
      "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendNeutral.Dazaralor, true));
      AddObjective(new ObjectiveLegendDead(LegendKultiras.LegendBoralus));
      ResearchId = Constants.UPGRADE_R08D_QUEST_COMPLETED_CONQUER_BORALUS;
      _onFailSpawnRect = onFailSpawnRect;
      _completeOnFailQuest = completeOnFailQuest;
      _failOnFailQuests = failOnFailQuests;
      Required = true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string CompletionPopup => "Before setting sails we need to conquer Kul'tiras";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string RewardDescription => "Unlock shipyards";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string FailurePopup => "Zandalar has fallen.";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string PenaltyDescription => "You lose everything you control and can no longer build shipyards, but you unlock Zul'Farrak";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
        whichFaction.Player.AddGold(750);
      
      KultirasSetup.Kultiras?.Player?.SetTeam(TeamSetup.Alliance);
      ZandalarSetup.Zandalar?.Player?.SetTeam(TeamSetup.Horde);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnFail(Faction completingFaction)
    {
      completingFaction.Obliterate();
      if (completingFaction.Player != null)
      {
        _completeOnFailQuest.Progress = QuestProgress.Complete;
        foreach (var quest in _failOnFailQuests)
          quest.Progress = QuestProgress.Failed;
               
        LegendTroll.LEGEND_PRIEST.ForceCreate(completingFaction.Player, new Point(_onFailSpawnRect.Center.X, _onFailSpawnRect.Center.Y), 110);
        LegendTroll.LEGEND_RASTAKHAN.ForceCreate(completingFaction.Player, new Point(_onFailSpawnRect.Center.X, _onFailSpawnRect.Center.Y), 110);
        if (GetLocalPlayer() == completingFaction.Player)
          SetCameraPosition(_onFailSpawnRect.Center.X, _onFailSpawnRect.Center.Y);
        completingFaction.Player.AddGold(1500);
        completingFaction.Player.AddLumber(2000);
      }
      KultirasSetup.Kultiras?.Player?.SetTeam(TeamSetup.Alliance);
      ZandalarSetup.Zandalar?.Player?.SetTeam(TeamSetup.Horde);
    }
  }
}