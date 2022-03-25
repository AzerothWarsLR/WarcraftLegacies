using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  /// <summary>
  /// Frostwolf kills the Sea Witch. Thrall gets some boats to leave the Darkspear Isles.
  /// Presently this ONLY deals with the final component of the event. The rest is done in GUI.
  /// </summary>
  public sealed class QuestSeaWitch : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R05H");


    private weathereffect? _storm;

    public QuestSeaWitch() : base("Riders on the Storm",
      "Warchief Thrall && his forces have been shipwrecked on the Darkspear Isles. Kill the Sea Witch there to give them a chance to rebuild their fleet && escape.",
      "ReplaceableTextures\\CommandButtons\\BTNGhost.blp")
    {
      AddQuestItem(new QuestItemKillUnit(LegendNeutral.legendSeawitch.Unit));
      AddQuestItem(new QuestItemExpire(600));
      ResearchId = QuestResearchId;
    }


    protected override string CompletionPopup =>
      "The sea witch Zar'jira has been slain. Thrall and Vol'jin can now set sail.";

    protected override string CompletionDescription =>
      "Gain control of all neutral units on the Darkspear Isles && teleport to shore";

    protected override void OnFail()
    {
      RescueNeutralUnitsInRect(Regions.EchoUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      group tempGroup = CreateGroup();
      //Transfer control of all passive units on island and teleport all Frostwolf units to shore
      RescueNeutralUnitsInRect(Regions.CairneStart.Rect, Holder.Player);
      GroupEnumUnitsInRect(tempGroup, Regions.Darkspear_Island.Rect, null);
      while (true)
      {
        unit u = FirstOfGroup(tempGroup);
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, Holder.Player);
        if (GetOwningPlayer(u) == FrostwolfSetup.FACTION_FROSTWOLF.Player &&
            IsUnitType(u, UNIT_TYPE_STRUCTURE) == false)
          SetUnitPosition(u, GetRandomReal(Regions.ThrallLanding.Center.X, Regions.ThrallLanding.Center.Y),
            GetRandomReal(Regions.ThrallLanding.Center.X, Regions.ThrallLanding.Center.Y));
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
      RemoveWeatherEffectBJ(_storm);
      CreateUnits(Holder.Player, FourCC("opeo"), -1818, -2070, 270, 3);
      RescueNeutralUnitsInRect(Regions.EchoUnlock.Rect, Holder.Player);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
      if (_storm == null)
      {
        _storm = AddWeatherEffect(Regions.Darkspear_Island.Rect, FourCC("RAhr"));
        EnableWeatherEffect(_storm, true);
      }
    }
  }
}