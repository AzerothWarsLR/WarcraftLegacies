using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Mechanics.Scourge.Plague;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
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
    private readonly Faction _preferredPlagueFaction;
    private readonly unit _lordBarov;
    private readonly IEnumerable<unit> _cultistsOfTheDamned;

    public unit? ScholomanceInner { private get; init; }
    public unit? ScholomanceOuter { private get; init; }

    public QuestPlague(Faction preferredPlagueFaction, unit lordBarov, IEnumerable<unit> cultistsOfTheDamned) : base(
      "Plague of Undeath",
      "The Cult of the Damned is prepared to unleash a devastating zombifying plague across the lands of Lordaeron.",
      "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp")
    {
      _preferredPlagueFaction = preferredPlagueFaction;
      _lordBarov = lordBarov;
      _cultistsOfTheDamned = cultistsOfTheDamned;
      AddQuestItem(new QuestItemEitherOf(
        new QuestItemResearch(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, FourCC("u000")),
        new QuestItemTime(960)));
      AddQuestItem(new QuestItemTime(660));
      Global = true;
    }

    protected override string CompletionPopup =>
      "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies.";

    protected override string RewardDescription => "A plague is unleashed upon the lands of Lordaeron";

    protected override void OnComplete()
    {
      OpenScholomance();
      Holder.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, -Faction.UNLIMITED);
      foreach (var unit in _cultistsOfTheDamned)
      {
        KillUnit(unit);
      }

      KillUnit(_lordBarov);

      var plagueRects = new List<Rectangle>
      {
        Regions.Plague_1,
        Regions.Plague_2,
        Regions.Plague_3,
        Regions.Plague_4,
        Regions.Plague_5,
        Regions.Plague_6,
        Regions.Plague_7
      };

      var plagueCauldronSummonParameters = new List<PlagueCauldronSummonParameter>()
      {
        new(1, Constants.UNIT_U01R_APOTHECARY_FORSAKEN),
        new(2, Constants.UNIT_UACO_ACOLYTE_SCOURGE, Holder),
        new(2, Constants.UNIT_U01K_ACOLYTE_FORSAKEN),
        new(4, Constants.UNIT_N07S_DEADEYE_FORSAKEN),
        new(4, Constants.UNIT_H08O_ROTGUARD_FORSAKEN),
      };

      var plaguePower = new PlaguePower(plagueRects, Constants.UNIT_H02W_PLAGUE_CAULDRON, plagueCauldronSummonParameters, 35);

      if (_preferredPlagueFaction.ScoreStatus == ScoreStatus.Undefeated)
      {
        _preferredPlagueFaction.AddPower(plaguePower);
        return;
      }

      Holder.AddPower(plaguePower);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(Constants.UPGRADE_R06I_PLAGUE_OF_UNDEATH_SCOURGE, Faction.UNLIMITED);
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