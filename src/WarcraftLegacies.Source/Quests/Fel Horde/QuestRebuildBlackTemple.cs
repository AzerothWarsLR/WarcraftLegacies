using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  /// <summary>
  /// Construct various buildings near the Black Temple to gain resources
  /// </summary>
  public sealed class QuestRuinsofShadowmoon : QuestData
  {
    private readonly List<unit> _rescueUnits;
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRuinsofShadowmoon"/> class.
    /// </summary>
    public QuestRuinsofShadowmoon(Rectangle rescueRect) : base("Ash and Smoke",
      "In the ashes of the battle of Black Temple, the Fel Horde will rebuild their bases of operation to support their new overlord",
      @"ReplaceableTextures\CommandButtons\BTNFelOrcAltarOfStorms.blp")
    {
      
      AddObjective(new ObjectiveAnyUnitInRect(rescueRect, "Shadowmoon Valley", false));
      AddObjective(new ObjectiveControlPoint(UNIT_N02T_TEROKKAR_FOREST));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
      {
        whichFaction.Player.RescueGroup(_rescueUnits);
      }
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "The camp in Shadowmoon Valley has been recaptured for the Fel Horde";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain a base with a goldmine in Shadowmoon Valley";
  }
}