using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestQueldanil : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestQueldanil(rect rescueRect) : base("Quel'danil Lodge",
      "Quel'danil Lodge is a High Elven outpost situated in the Hinterlands. It's been some time since the rangers there have been in contact with Quel'thalas.",
      "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
    {
      AddQuestItem(new ObjectiveAnyUnitInRect(Regions.QuelDanil_Lodge, "Quel'danil Lodge", true));
      AddQuestItem(new ObjectiveTime(1200));
      ResearchId = FourCC("R074");

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          _rescueUnits.Add(unit);
          SetUnitInvulnerable(unit, true);
        }
    }

    protected override string CompletionPopup =>
      "Quel'thalas has finally reunited with its lost rangers in the Hinterlands.";

    protected override string RewardDescription => "Control of Quel'danil Lodge";

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}