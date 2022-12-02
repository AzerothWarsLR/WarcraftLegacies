using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Stormwind
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
      AddObjective(_objectiveAnyUnitInRect);
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R01M_QUEST_COMPLETED_STROMGARDE_STORMWIND;
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "Galen Trollbane has pledged his forces to Stormwind's cause.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units at Stromgarde, the artifact Trol'kalar, and you can summon the hero Galen Trollbane from the Altar of Kings";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      SetItemPosition(RegisterTrolkalar().Item, 140889, 12363);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      _objectiveAnyUnitInRect.CompletingUnit?.AddItemSafe(RegisterTrolkalar().Item);
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      whichFaction.ModObjectLimit(HeroId, 1);
    }

    private static Artifact RegisterTrolkalar()
    {
      var artifactTrolkalar = new Artifact(CreateItem(Constants.ITEM_I01O_TROL_KALAR, 0, 0))
      {
        TitanforgedAbility = Constants.ABILITY_A0VM_TITANFORGED_9_STRENGTH
      };
      ArtifactManager.Register(artifactTrolkalar);
      return artifactTrolkalar;
    }
  }
}