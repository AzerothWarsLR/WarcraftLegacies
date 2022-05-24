using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  /// <summary>
  ///   Frostwolf kills the Sea Witch. Thrall gets some boats to leave the Darkspear Isles.
  ///   Presently this ONLY deals with the final component of the event. The rest is done in GUI.
  /// </summary>
  public sealed class QuestSeaWitch : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private weathereffect? _storm;

    public QuestSeaWitch(Rectangle rescueRect) : base("Riders on the Storm",
      "Warchief Thrall and his forces have been shipwrecked on the Darkspear Isles. Kill the Sea Witch there to give them a chance to rebuild their fleet and escape.",
      "ReplaceableTextures\\CommandButtons\\BTNGhost.blp")
    {
      AddQuestItem(new ObjectiveKillUnit(LegendNeutral.LegendSeawitch.Unit));
      AddQuestItem(new ObjectiveExpire(600));
      ResearchId = FourCC("R05H");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "The sea witch Zar'jira has been slain. Thrall and Vol'jin can now set sail.";

    protected override string RewardDescription =>
      "Gain control of all neutral units on the Darkspear Isles and teleport to shore";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      group tempGroup = CreateGroup();
      //Transfer control of all passive units on island and teleport all Frostwolf units to shore
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      GroupEnumUnitsInRect(tempGroup, Regions.Darkspear_Island.Rect, null);
      while (true)
      {
        unit u = FirstOfGroup(tempGroup);
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) u.Rescue(completingFaction.Player);
        if (GetOwningPlayer(u) == FrostwolfSetup.FACTION_FROSTWOLF.Player &&
            IsUnitType(u, UNIT_TYPE_STRUCTURE) == false)
          SetUnitPosition(u, GetRandomReal(Regions.ThrallLanding.Center.X, Regions.ThrallLanding.Center.Y),
            GetRandomReal(Regions.ThrallLanding.Center.X, Regions.ThrallLanding.Center.Y));
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
      RemoveWeatherEffect(_storm);
      CreateUnits(completingFaction.Player, FourCC("opeo"), -1818, -2070, 270, 3);
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      if (_storm == null)
      {
        _storm = AddWeatherEffect(Regions.Darkspear_Island.Rect, FourCC("RAhr"));
        EnableWeatherEffect(_storm, true);
      }
    }
  }
}