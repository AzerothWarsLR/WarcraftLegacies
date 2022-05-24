using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Mechanics.Scourge.Plague;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  /// <summary>
  /// When completed, the plague begins, granting either the Forsaken or the quest holder several Plague Cauldrons that periodically spawn undead units.
  /// Also forcibly opens Scholomance and clears the creeps outside it.
  /// </summary>
  public sealed class QuestPlague : QuestData
  {
    private readonly IEnumerable<unit> _cultistsOfTheDamned;
    private readonly float _duration;
    private readonly unit _lordBarov;

    private readonly List<PlagueCauldronSummonParameter> _plagueCauldronSummonParameters;
    private readonly int _plagueCauldronUnitTypeId;
    private readonly List<Rectangle> _plagueRects;
    private readonly Faction _preferredPlagueFaction;

    /// <summary>
    /// When completed, the quest holder initiates the Plague, creating Plague Cauldrons around Lordaeron
    /// and converting villagers into Zombies.
    /// </summary>
    /// <param name="preferredPlagueFaction">If this Faction is still in the game, it gets control of the Plague Cauldrons instead of the quest holder.</param>
    /// <param name="lordBarov">Gets killed when the quest is completed.</param>
    /// <param name="cultistsOfTheDamned">Gets killed when the quest is completed.</param>
    /// <param name="plagueParameters">Provides information about how the Plague should work.</param>
    public QuestPlague(Faction preferredPlagueFaction, unit lordBarov, IEnumerable<unit> cultistsOfTheDamned,
      PlagueParameters plagueParameters) : base(
      "Plague of Undeath",
      "The Cult of the Damned is prepared to unleash a devastating zombifying plague across the lands of Lordaeron.",
      "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp")
    {
      _preferredPlagueFaction = preferredPlagueFaction;
      _lordBarov = lordBarov;
      _cultistsOfTheDamned = cultistsOfTheDamned;
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

    public unit? ScholomanceInner { private get; init; }
    public unit? ScholomanceOuter { private get; init; }

    protected override string CompletionPopup =>
      "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies.";

    protected override string RewardDescription =>
      "All villagers in Lordaeron are transformed into Zombies, and several Plague Cauldrons spawn throughout Lordaeron, which periodically spawn Zombies.";

    private void CreatePlagueCauldrons(player whichPlayer)
    {
      foreach (var plagueRect in _plagueRects)
      {
        var position = plagueRect.GetRandomPoint();
        var plagueCauldron = CreateUnit(whichPlayer, _plagueCauldronUnitTypeId, position.X, position.Y, 0);
        UnitApplyTimedLife(plagueCauldron, 0, _duration);
        var plagueCauldronBuff = new PlagueCauldronBuff(plagueCauldron, plagueCauldron)
        {
          ZombieUnitTypeId = Constants.UNIT_NZOM_ZOMBIE_SCOURGE
        };
        BuffSystem.Add(plagueCauldronBuff);
        foreach (var parameter in _plagueCauldronSummonParameters)
          GeneralHelpers.CreateUnits(parameter.FactionOverride?.Player ?? whichPlayer, parameter.SummonUnitTypeId,
            position.X, position.Y, 0, parameter.SummonCount);
      }
    }

    protected override void OnComplete(Faction completingFaction)
    {
      OpenScholomance();
      completingFaction.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, -Faction.UNLIMITED);
      foreach (var unit in _cultistsOfTheDamned)
      {
        KillUnit(unit);
      }

      KillUnit(_lordBarov);

      var plaguePower = new PlaguePower();
      if (_preferredPlagueFaction.ScoreStatus == ScoreStatus.Undefeated)
      {
        _preferredPlagueFaction.AddPower(plaguePower);
        CreatePlagueCauldrons(_preferredPlagueFaction.Player);
      }
      else
      {
        CreatePlagueCauldrons(completingFaction.Player);
      }

      completingFaction.AddPower(plaguePower);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, Faction.UNLIMITED);
    }

    private void OpenScholomance()
    {
      ForsakenSetup.FACTION_FORSAKEN.SetObjectLevel(Constants.UPGRADE_R02X_OPEN_THE_SCHOLOMANCE_SCOURGE,
        1); //Todo: this should probably be a Forsaken quest that completes when this quest completes
      WaygateActivate(ScholomanceInner, true);
      WaygateSetDestination(ScholomanceInner, Regions.Scholomance_Entrance.Center.X,
        Regions.Scholomance_Entrance.Center.Y);

      WaygateActivate(ScholomanceOuter, true);
      WaygateSetDestination(ScholomanceOuter, Regions.Scholomance_Exit.Center.X, Regions.Scholomance_Exit.Center.Y);
    }
  }
}