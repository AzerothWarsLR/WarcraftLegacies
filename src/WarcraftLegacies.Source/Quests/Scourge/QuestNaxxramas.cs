using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// Kel'thuzad channels near Naxxramas for a bit to take control of it.
  /// </summary>
  public sealed class QuestNaxxramas : QuestData
  {
    private readonly unit _naxxramas;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestNaxxramas"/> class.
    /// </summary>
    public QuestNaxxramas(Rectangle rescueRect, unit naxxramas) : base("The Dread Citadel",
      "This fallen necropolis can be transformed into a potent war machine by the Lich Kel'thuzad",
      @"ReplaceableTextures\CommandButtons\BTNBlackCitadel.blp")
    {
      _naxxramas = naxxramas;
      ObjectiveChannelRect objectiveChannelRect =
        new(Regions.NaxUnlock, "Naxxramas", LegendScourge.LegendKelthuzad, 180, 270);
      AddObjective(objectiveChannelRect);
      SetUnitInvulnerable(naxxramas, true);
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    }

    /// <inheritdoc />
    protected override string CompletionPopup =>
      "The Naxxramas has now been raised and under the control of the Scourge.";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in Naxxramas";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.RescueGroup(_rescueUnits);
      _naxxramas.Rescue(completingFaction.Player ?? Player(GetBJPlayerNeutralVictim()));
      completingFaction.Player?.RescueGroup(_rescueUnits);
      SetPlayerAbilityAvailable(completingFaction.Player, FourCC("A0O2"), false);
    }
  }
}