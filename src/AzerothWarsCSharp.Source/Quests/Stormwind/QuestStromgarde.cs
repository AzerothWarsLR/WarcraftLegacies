using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestStromgarde : QuestData
  {
    private static readonly int HeroId = FourCC("H00Z");
    private readonly ObjectiveAnyUnitInRect _objectiveAnyUnitInRect;
    private readonly List<unit> _rescueUnits = new();

    public QuestStromgarde(Rectangle rescueRect) : base("Stromgarde",
      "Although Stromgarde's strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind.",
      "ReplaceableTextures\\CommandButtons\\BTNTheCaptain.blp")
    {
      _objectiveAnyUnitInRect = new ObjectiveAnyUnitInRect(Regions.Stromgarde, "Stromgarde", true);
      AddQuestItem(_objectiveAnyUnitInRect);
      AddQuestItem(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R01M_QUEST_COMPLETED_STROMGARDE_STORMWIND;
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "Galen Trollbane has pledged his forces to Stormwind's cause.";

    protected override string RewardDescription =>
      "Control of all units at Stromgarde, the artifact Trol'kalar, and you can summon the hero Galen Trollbane from the Altar of Kings";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      SetItemPosition(ArtifactSetup.ArtifactTrolkalar.Item, 140889, 12363);
      ArtifactSetup.ArtifactTrolkalar.Status = ArtifactStatus.Ground;
    }

    protected override void OnComplete()
    {
      _objectiveAnyUnitInRect.TriggerUnit.AddItemSafe(ArtifactSetup.ArtifactTrolkalar.Item);
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      Holder.ModObjectLimit(HeroId, 1);
    }
  }
}