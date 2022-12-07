using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static WarcraftLegacies.Source.Setup.Legends.LegendFelHorde;
using static WarcraftLegacies.Source.Setup.Legends.LegendDraenei;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  /// <summary>
  /// Capture some territory to get your main bases.
  /// </summary>
  public sealed class QuestKilsorrow : QuestData
  {
    private readonly unit _kilsorrowFortress;
    private readonly List<unit> _rescueUnits = new();
    private readonly unit _goldmine;
    private readonly unit _demonGate;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestKilsorrow"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable, and be granted when the quest is completed.</param>
    /// <param name="kilsorrowFortress">Rescued when the quest is completed.</param>
    /// <param name="goldmine">Hidden at game start, and shown when the quest is completed.</param>
    /// <param name="demonGate">Invulnerable at game start, and rescued when the quest is completed.</param>
    public QuestKilsorrow(Rectangle rescueRect, unit kilsorrowFortress, unit goldmine, unit demonGate) : base("Kil'sorrow Fortress",
      "This sinister fortress will serve the Fel Horde well, clear the surrounding lands to establish it",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcWatchTower.blp")
    {
      AddObjective(new ObjectiveLegendDead(Shattrah ?? throw new SystemNotInitializedException(nameof(LegendDraenei))));
      AddObjective(new ObjectiveLegendDead(Halaar ?? throw new SystemNotInitializedException(nameof(LegendDraenei))));
      AddObjective(new ObjectiveExpire(1452));
      AddObjective(new ObjectiveSelfExists());

      Required = true;
      
      _kilsorrowFortress = kilsorrowFortress;
      _goldmine = goldmine;
      _demonGate = demonGate;
      _goldmine.Show(false);
      _demonGate.SetInvulnerable(true);

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      LegendExodarship.Unit?.SetInvulnerable(true);
    }

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Kil'sorrow is now established, the Black Temple and its military is now free to assist the Fel Horde.";
    
    /// <inheritdoc />
    protected override string RewardDescription => "Control of the Black Temple and all units in Kil'sorrow, control of a Demon Gate, and The Exodar becomes vulnerable";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      _demonGate.Kill();
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var rewardPlayer = completingFaction.Player ?? Player(PLAYER_NEUTRAL_AGGRESSIVE);
      rewardPlayer.RescueGroup(_rescueUnits);
      _kilsorrowFortress.Rescue(rewardPlayer);
      _demonGate.Rescue(rewardPlayer);
      _goldmine.Show(true);
      LegendBlacktemple.Unit?.Rescue(rewardPlayer);
      LegendExodarship.Unit?.SetInvulnerable(false);
      if (LegendBlacktemple.Unit != null)
        LegendMagtheridon.AddUnitDependency(LegendBlacktemple.Unit);
    }
  }
}