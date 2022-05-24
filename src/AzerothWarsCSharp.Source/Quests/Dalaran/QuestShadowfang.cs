using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestShadowfang : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestShadowfang(Rectangle rescueRect, unit worgenToKill) : base("Shadows of Silverspine Forest",
      "The woods of Silverspine are unsafe for travellers, they need to be investigated",
      "ReplaceableTextures\\CommandButtons\\BTNworgen.blp")
    {
      AddQuestItem(new ObjectiveKillUnit(worgenToKill)); //Worgen
      AddQuestItem(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01D"))));
      AddQuestItem(new ObjectiveExpire(1444));
      AddQuestItem(new ObjectiveSelfExists());

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Shadowfang has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Shadowfang";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
    }
  }
}