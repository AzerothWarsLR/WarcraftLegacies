using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestDominion : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestDominion(Rectangle rescueRect) : base("Dwarven Dominion",
      "The Dwarven Dominion must be established before Ironforge can join the war.",
      "ReplaceableTextures\\CommandButtons\\BTNNorthrendCastle.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n017"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n014"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n013"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("h07G"), FourCC("h07E")));
      AddQuestItem(new QuestItemExpire(1462));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R043");
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "The Dwarven Empire is re-united again, Ironforge is ready for war again.";

    protected override string RewardDescription => "Control of all units in Ironforge";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player ?? Player(PLAYER_NEUTRAL_AGGRESSIVE));
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\DwarfTheme.mp3");
    }
  }
}