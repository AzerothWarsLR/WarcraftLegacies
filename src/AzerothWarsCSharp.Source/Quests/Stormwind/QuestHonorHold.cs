using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestHonorHold : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestHonorHold(Rectangle rescueRect) : base("Honor Hold",
      "Despite Outland's incredibly harsh climate, some Alliance forces have managed to make a home there - a town called Honor Hold",
      "ReplaceableTextures\\CommandButtons\\BTNHumanBarracks.blp")
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      AddQuestItem(new ObjectiveLegendDead(LegendFelHorde.LegendHellfirecitadel));
    }

    protected override string CompletionPopup =>
      "Honor Hold is now free from the constant looming threat of Hellfire Citadel. Danath Trollbane and his people elect to rejoin the Alliance.";

    protected override string RewardDescription =>
      "The demihero Danath Trollbane, and control of all units at Honor Hold";

    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
      completingFaction.ModObjectLimit(Constants.UNIT_H03W_DANATH_TROLLBANE_ARATHOR_DEMI, 1);
      //Set animations of doodads within Honor Hold
      SetDoodadAnimationRect(Regions.HonorHold.Rect, FourCC("ISrb"), "hide", false);
      SetDoodadAnimationRect(Regions.HonorHold.Rect, FourCC("LSst"), "hide", false);
      SetDoodadAnimationRect(Regions.HonorHold.Rect, FourCC("CSra"), "unhide", false);
    }
  }
}