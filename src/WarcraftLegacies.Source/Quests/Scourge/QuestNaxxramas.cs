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
    private readonly unit _naxxramas;
    private readonly List<unit> _rescueUnits = new();

    public QuestNaxxramas(Rectangle rescueRect, unit naxxramas) : base("The Dread Citadel",
      "This fallen necropolis can be transformed into a potent war machine by the Lich Kel'thuzad",
      @"ReplaceableTextures\CommandButtons\BTNBlackCitadel.blp")
    {
      _naxxramas = naxxramas;
      ObjectiveChannelRect objectiveChannelRect =
        new(Regions.NaxUnlock, "Naxxramas", LegendScourge.LegendKelthuzad, 60, 270);
      AddObjective(objectiveChannelRect);
      SetUnitInvulnerable(naxxramas, true);

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          ShowUnit(unit, false);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      $"The Naxxramas has now been raised and under the control of the Scourge.";

    protected override string RewardDescription => "Control of all units in Naxxramas";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player ?? Player(GetBJPlayerNeutralVictim()));
      _naxxramas.Rescue(completingFaction.Player ?? Player(GetBJPlayerNeutralVictim()));
      SetPlayerAbilityAvailable(completingFaction.Player, FourCC("A0O2"), false);
    }
  }
}