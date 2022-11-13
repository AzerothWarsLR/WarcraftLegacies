using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static MacroTools.Libraries.GeneralHelpers;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  ///   Frostwolf kills the Sea Witch. Thrall gets some boats to leave the Darkspear Isles.
  ///   Presently this ONLY deals with the final component of the event. The rest is done in GUI.
  /// </summary>
  public sealed class QuestSeaWitch : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    private weathereffect? _storm;
    private readonly trigger _rescueTrigger;

    public QuestSeaWitch(Rectangle rescueRect) : base("Riders on the Storm",
      "Warchief Thrall and his forces have been shipwrecked on the Darkspear Isles. Kill the Sea Witch there to give them a chance to rebuild their fleet and escape.",
      "ReplaceableTextures\\CommandButtons\\BTNGhost.blp")
    {
      AddObjective(new ObjectiveKillUnit(LegendNeutral.LegendSeawitch.Unit));
      AddObjective(new ObjectiveExpire(600));
      ResearchId = FourCC("R05H");
      _rescueUnits = rescueRect.PrepareUnitsForRescue(Player(PLAYER_NEUTRAL_PASSIVE));
      CreateTrigger()
        .RegisterEnterRegion(Regions.Thrall_Landing1)
        .AddAction(() =>
        {
          var triggerUnit = GetTriggerUnit();
          if (GetOwningPlayer(triggerUnit) != FrostwolfSetup.Frostwolf.Player) return;
          Regions.Thrall_Landing1.RescueNeutralUnitsInRect(GetOwningPlayer(triggerUnit));
        });
    }

    protected override string CompletionPopup =>
      "The sea witch Zar'jira has been slain. Thrall and Vol'jin can now set sail.";

    protected override string RewardDescription =>
      "Gain control of all neutral units on the Darkspear Isles and teleport to shore";

    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      _rescueUnits.Clear();
      DestroyTrigger(_rescueTrigger);
    }

    protected override void OnComplete(Faction completingFaction)
    {
      //Transfer control of all passive units on island and teleport all Frostwolf units to shore
      Regions.CairneStart.RescueNeutralUnitsInRect(completingFaction.Player);
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Regions.Darkspear_Island.Rect).EmptyToList())
      {
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE)) unit.Rescue(completingFaction.Player);
        if (GetOwningPlayer(unit) == FrostwolfSetup.Frostwolf.Player &&
            IsUnitType(unit, UNIT_TYPE_STRUCTURE) == false)
          SetUnitPosition(unit, GetRandomReal(GetRectMinX(Regions.ThrallLanding.Rect), GetRectMaxX(Regions.ThrallLanding.Rect)),
            GetRandomReal(GetRectMinY(Regions.ThrallLanding.Rect), GetRectMaxY(Regions.ThrallLanding.Rect)));
      }
      RemoveWeatherEffect(_storm);
      CreateUnits(completingFaction.Player, FourCC("opeo"), -1818, -2070, 270, 3);
      completingFaction.Player.RescueGroup(_rescueUnits);
      _rescueUnits.Clear();
      DestroyTrigger(_rescueTrigger);
    }

    protected override void OnAdd(Faction whichFaction)
    {
      if (_storm != null) return;
      _storm = AddWeatherEffect(Regions.Darkspear_Island.Rect, FourCC("RAhr"));
      EnableWeatherEffect(_storm, true);
    }
  }
}