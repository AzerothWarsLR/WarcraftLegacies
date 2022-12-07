using System.Collections.Generic;
using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  public sealed class QuestFirstWave : QuestData
  {
    private readonly List<unit> _unitsToKill;

    public QuestFirstWave(PreplacedUnitSystem preplacedUnitSystem) : base("Broken Civilisation",
      "The Fel Orc attack will begin at any moment, the Draenei need to evacuate their civilians aboard the Exodar",
      "ReplaceableTextures\\CommandButtons\\BTNDraeneiDivineCitadel.blp")
    {
      AddObjective(new ObjectiveTime(540));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendDraenei.LegendExodarship));
      AddObjective(new ObjectiveSelfExists());
      _unitsToKill = new List<unit>
      {
        preplacedUnitSystem.GetUnit(Constants.UNIT_O051_DIVINE_CITADEL_DRAENEI, Regions.DraeneiEvacuation.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_O055_CRYSTAL_SPIRE_DRAENEI, Regions.DraeneiEvacuation.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_O054_ASTRAL_SANCTUM_DRAENEI, Regions.DraeneiEvacuation.Center),
      };
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The Draenei have held long enough and most of their civilisation had time to join the Exodar";

    /// <inheritdoc />
    protected override string PenaltyDescription =>
      "You lose the Divine Citadel, Teleporter, Astral Sanctum and Crystal Spire at Azuremyst Isle";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _unitsToKill) KillUnit(unit);
    }
  }
}