using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Dalaran
{
  public sealed class QuestShadowfang : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestShadowfang(Rectangle rescueRect, unit worgenToKill) : base("Shadows of Silverspine Forest",
      "The woods of Silverspine are unsafe for travellers, they need to be investigated",
      "ReplaceableTextures\\CommandButtons\\BTNworgen.blp")
    {
      AddObjective(new ObjectiveKillUnit(worgenToKill)); //Worgen
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01D"))));
      AddObjective(new ObjectiveExpire(1444));
      AddObjective(new ObjectiveSelfExists());

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Shadowfang has been liberated, and its military is now free to assist Dalaran.";

    protected override string RewardDescription => "Control of all units in Shadowfang";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}