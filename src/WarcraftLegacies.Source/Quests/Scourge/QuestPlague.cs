using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Mechanics.Scourge.Plague;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// When completed, the plague begins, granting either the Forsaken or the quest holder several Plague Cauldrons that periodically spawn undead units.
  /// </summary>
  public sealed class QuestPlague : QuestData
  {
    private readonly float _duration;

    private readonly List<PlagueCauldronSummonParameter> _plagueCauldronSummonParameters;
    private readonly int _plagueCauldronUnitTypeId;
    private readonly List<Rectangle> _plagueRects;

    /// <summary>
    /// When completed, the quest holder initiates the Plague, creating Plague Cauldrons around Lordaeron
    /// and converting villagers into Zombies.
    /// </summary>
    /// <param name="plagueParameters">Provides information about how the Plague should work.</param>
    public QuestPlague(PlagueParameters plagueParameters) : base(
      "Plague of Undeath",
      "The Cult of the Damned is prepared to unleash a devastating zombifying plague across the lands of Lordaeron.",
      "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp")
    {
      _plagueRects = plagueParameters.PlagueRects;
      _plagueCauldronUnitTypeId = plagueParameters.PlagueCauldronUnitTypeId;
      _plagueCauldronSummonParameters = plagueParameters.PlagueCauldronSummonParameters;
      _duration = plagueParameters.Duration;
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveResearch(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, FourCC("u000")),
        new ObjectiveTime(960)));
      AddObjective(new ObjectiveTime(660));
      Global = true;
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "All villagers in Lordaeron are transformed into Zombies, and several Plague Cauldrons spawn throughout Lordaeron, which periodically spawn Zombies.";

    private void CreatePlagueCauldrons(Faction completingFaction)
    {
      var plaguePlayer = (completingFaction.ScoreStatus != ScoreStatus.Defeated
        ? completingFaction.Player
        : Player(PLAYER_NEUTRAL_AGGRESSIVE)) 
                         ?? Player(PLAYER_NEUTRAL_AGGRESSIVE);

      foreach (var plagueRect in _plagueRects)
      {
        var position = plagueRect.GetRandomPoint();
        var plagueCauldron = CreateUnit(plaguePlayer, _plagueCauldronUnitTypeId, position.X, position.Y, 0)
          .SetTimedLife(_duration);
        var plagueCauldronBuff = new PlagueCauldronBuff(plagueCauldron, plagueCauldron)
        {
          ZombieUnitTypeId = Constants.UNIT_NZOM_ZOMBIE_SCOURGE
        };
        BuffSystem.Add(plagueCauldronBuff);
        foreach (var parameter in _plagueCauldronSummonParameters)
          GeneralHelpers.CreateUnits(plaguePlayer, parameter.SummonUnitTypeId,
            position.X, position.Y, 0, parameter.SummonCount);
      }
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, -Faction.UNLIMITED);
      var plaguePower = new PlaguePower();
      if (completingFaction.Player != null) 
        CreatePlagueCauldrons(completingFaction);
      completingFaction.AddPower(plaguePower);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction) => 
      whichFaction.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, Faction.UNLIMITED);
  }
}