using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Druids
{
  public sealed class QuestAshenvale : QuestData
  {
    private readonly List<unit> _rescueUnits = new();
    
    public QuestAshenvale(Rectangle rescueRect) : base("The Spirits of Ashenvale",
      "The forest needs healing. Regain control of it to summon it's Guardian, the Demigod Cenarius",
      "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp")
    {
      AddQuestItem(
        new QuestItemLegendReachRect(LegendDruids.LegendMalfurion, Regions.AshenvaleUnlock, "Ashenvale"));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n07C"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01Q"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08U"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("etol"), FourCC("etol")));
      AddQuestItem(new QuestItemExpire(1440));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R06R");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }
    
    protected override string CompletionPopup => "Ashenvale is under control and Cenarius can now be awaken";

    protected override string RewardDescription =>
      "Control of all units in Ashenvale and make Cenarius trainable at the Altar";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      _rescueUnits.Clear();
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) UnitRescue(unit, Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\DruidTheme.mp3");
      _rescueUnits.Clear();
    }
  }
}