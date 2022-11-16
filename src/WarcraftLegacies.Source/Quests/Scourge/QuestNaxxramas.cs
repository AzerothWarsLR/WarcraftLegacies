using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestNaxxramas : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestNaxxramas(Rectangle rescueRect, unit naxxramas) : base("The Dread Citadel",
      "This fallen necropolis can be transformed into a potent war machine by the Lich Kel'thuzad",
      @"ReplaceableTextures\CommandButtons\BTNBlackCitadel.blp")
    {
      ObjectiveChannelRect objectiveChannelRect =
        new(Regions.NaxUnlock, "Naxxramas", LegendScourge.LegendKelthuzad, 60, 270);
      AddObjective(objectiveChannelRect);
      SetUnitInvulnerable(naxxramas, true);
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    }

    protected override string CompletionPopup =>
      $"The Naxxramas has now been raised and under the control of the Scourge.";

    protected override string RewardDescription => "Control of all units in Naxxramas";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player ?? Player(GetBJPlayerNeutralVictim()));
      completingFaction.Player?.RescueGroup(_rescueUnits);
      SetPlayerAbilityAvailable(completingFaction.Player, FourCC("A0O2"), false);
    }
  }
}