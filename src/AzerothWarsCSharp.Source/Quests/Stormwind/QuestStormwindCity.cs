using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestStormwindCity : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R02S");
    private readonly List<unit> _rescueUnits = new();

    public QuestStormwindCity(Rectangle rescueRect) : base("Clear the Outskirts",
      "The outskirts of Stormwind are infested by evil creatures. Kill their leaders and regain control of the Towns.",
      "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00V"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n00Z"))));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n011"))));
      AddQuestItem(new QuestItemUpgrade(FourCC("h06K"), FourCC("h06K")));
      AddQuestItem(new QuestItemExpire(1020));
      AddQuestItem(new QuestItemSelfExists());
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }

      ResearchId = FourCC("R02S");
    }


    protected override string CompletionPopup =>
      "Stormwind has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription =>
      "Control of all units in Stormwind and enable Varian to be trained at the altar";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      if (GetLocalPlayer() == Holder.Player) PlayThematicMusicBJ("war3mapImported\\StormwindTheme.mp3");
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
    }
  }
}