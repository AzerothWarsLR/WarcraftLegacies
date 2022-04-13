using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestHonorHold : QuestData
  {
    private readonly List<unit> _honorHoldUnits;
    
    public QuestHonorHold(List<unit> honorHoldUnits) : base("Honor Hold", "Despite Outland's incredibly harsh climate, some Alliance forces have managed to make a home there - a town called Honor Hold", "ReplaceableTextures\\CommandButtons\\BTNHumanBarracks.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendFelHorde.LegendHellfirecitadel));
      _honorHoldUnits = honorHoldUnits;
    }
    
    protected override string CompletionPopup =>
      "Honor Hold is now free from the constant looming threat of Hellfire Citadel. Danath Trollbane and his people elect to rejoin the Alliance.";

    protected override string RewardDescription =>
      "The demihero Danath Trollbane, and control of all units at Honor Hold";

    protected override void OnComplete()
    {
      foreach (var unit in _honorHoldUnits)
      {
        UnitRescue(unit, Holder.Player);
      }
      Holder.ModObjectLimit(Constants.UNIT_H03W_DANATH_TROLLBANE_ARATHOR_DEMI, 1);
      //Set animations of doodads within Honor Hold
      SetDoodadAnimationRectBJ("hide", FourCC("ISrb"), Regions.HonorHold.Rect);
      SetDoodadAnimationRectBJ("hide", FourCC("LSst"), Regions.HonorHold.Rect);
      SetDoodadAnimationRectBJ("unhide", FourCC("CSra"), Regions.HonorHold.Rect);
    }
  }
}