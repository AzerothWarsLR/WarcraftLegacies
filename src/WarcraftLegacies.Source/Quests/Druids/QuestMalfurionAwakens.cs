using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ArtifactBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Druids
{
  /// <summary>
  /// The Druids acquire Malfurion, Moonglade and the World Tree.
  /// </summary>
  public sealed class QuestMalfurionAwakens : QuestData
  {
    private readonly unit _worldTree;
    private readonly Artifact _hornofCenarius;
    private readonly LegendaryHero _malfurion;
    private readonly List<unit> _moongladeUnits;
    private readonly List<unit> _darnassusUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestMalfurionAwakens"/> class.
    /// </summary>
    /// <param name="moonglade">All units here start invulnerable and are rescued when the quest is completed.</param>
    /// <param name="worldTree">Starts invulnerable and is recued when the quest is completed.</param>
    /// <param name="hornofCenarius">Required to complete the quest.</param>
    /// <param name="malfurion">Awakened when the quest is completed.</param>
    public QuestMalfurionAwakens(Rectangle moonglade, Rectangle darnassus, unit worldTree, Artifact hornofCenarius, LegendaryHero malfurion) : base("Awakening of Stormrage",
      "Ever since the War of the Ancients ten thousand years ago, Malfurion Stormrage and his druids have slumbered within the Barrow Den. Now, their help is required once again.",
      "ReplaceableTextures\\CommandButtons\\BTNFurion.blp")
    {
      _worldTree = worldTree;
      _hornofCenarius = hornofCenarius;
      _malfurion = malfurion;
      AddObjective(new ObjectiveAcquireArtifact(hornofCenarius));
      AddObjective(new ObjectiveArtifactInRect(hornofCenarius, Regions.Moonglade,
        "The Barrow Den"));
      AddObjective(new ObjectiveExpire(1440, Title));
      AddObjective(new ObjectiveSelfExists());
      _moongladeUnits = moonglade.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      _darnassusUnits = darnassus.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      worldTree.SetInvulnerable(true);
      Required = true;
    }

    /// <inheritdoc />
    protected override string RewardFlavour => "Malfurion has emerged from his deep slumber in the Barrow Den. Darnassus and the Moonglade ancients have been awakened.";

    /// <inheritdoc />
    protected override string RewardDescription => "Gain Nordrassil, the Darnassus base, the Moonglade base, the hero Malfurion, and the artifact G'hanir";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_moongladeUnits);
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_darnassusUnits);
      _worldTree.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_moongladeUnits);
      completingFaction.Player.RescueGroup(_darnassusUnits);
      _worldTree.Rescue(completingFaction.Player);
      if (_malfurion.Unit == null)
      {
        _malfurion.ForceCreate(completingFaction.Player, Regions.Moonglade.Center,
          270);
        _malfurion.Unit?
          .SetLevel(3, false)
          .AddItemSafe(_hornofCenarius.Item);
      }
      else
      {
        _hornofCenarius.Item.SetPositionSafe(GetTriggerUnit().GetPosition());
      }
    }
  }
}