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

    public QuestFirstWave() : base("Broken Civilisation",
      "The Fel Orc attack will begin at any moment, the Draenei need to evacuate their civilians aboard the Exodar",
      "ReplaceableTextures\\CommandButtons\\BTNDraeneiDivineCitadel.blp")
    {
      AddObjective(new ObjectiveTime(720));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendDraenei.LegendExodarship));
      AddObjective(new ObjectiveSelfExists());
      _unitsToKill = new List<unit>
      {
        PreplacedUnitSystem.GetUnit(FourCC("o051"), Regions.DraeneiEvacuation.Center),
        PreplacedUnitSystem.GetUnit(FourCC("o055"), Regions.DraeneiEvacuation.Center),
        PreplacedUnitSystem.GetUnit(FourCC("o054"), Regions.DraeneiEvacuation.Center),
        PreplacedUnitSystem.GetUnit(FourCC("n0BU"), Regions.DraeneiEvacuation.Center)
      };
    }

    protected override string CompletionPopup =>
      "The Draenei have holded long enough and most of their civilisation had time to join the Exodar";

    protected override string PenaltyDescription =>
      "You lose the Divine Citadel, Teleporter, Astral Sanctum and Crystal Spire at Azuremyst Isle";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _unitsToKill) KillUnit(unit);
    }
  }
}