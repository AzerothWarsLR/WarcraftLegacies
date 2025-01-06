using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using MacroTools.ArtifactSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  /// <summary>
  /// Scourge player loses the Frozen Throne and loses control of all mindless undead and the ability to train them.
  /// If Arthas acquires the Helm of Domination, training of those units is re-enabled.
  /// </summary>
  public sealed class QuestDefeatFrozenThrone : QuestData
  {
    private readonly Capital _frozenThrone;
    private readonly List<int> _specificUnitIds;
    private readonly Artifact _helmOfDomination;
    private readonly LegendaryHero _arthas;
    private bool _isActive;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestDefeatFrozenThrone"/> class.
    /// </summary>
    public QuestDefeatFrozenThrone(Faction scourge, Capital frozenThrone, Artifact helmOfDomination, LegendaryHero arthas)
        : base("From the Ruins, Reborn",
      "The Scourge's power crumbles as the Frozen Throne falls. The mindless undead wander the wastes. However, there is still hope; if Arthas can obtain The Helm of Domination, the Scourge may rise again!",
      @"ReplaceableTextures\CommandButtons\BTNBlackKing.blp")
    {
      _frozenThrone = frozenThrone;
      _helmOfDomination = helmOfDomination;
      _arthas = arthas;
      _specificUnitIds = new List<int>
      {
        Constants.UNIT_UGHO_GHOUL_SCOURGE,  // Ghoul
        Constants.UNIT_UABO_ABOMINATION_SCOURGE,  // Abomination
        Constants.UNIT_UFRO_FROST_WYRM_SCOURGE,  // Frost Wyrm
        Constants.UNIT_UCRM_BURROWED_CRYPT_FIEND_RED, // Burrowed Fiend  
        Constants.UNIT_UCRY_CRYPT_FIEND_SCOURGE // Crypt Fiend
      };

      AddObjective(new ObjectiveCapitalDead(frozenThrone));
      AddObjective(new ObjectiveLegendHasArtifact(arthas, helmOfDomination));
      ResearchId = UPGRADE_R008_QUEST_COMPLETED_FROM_THE_RUINS_REBORN;

      var frozenThroneDeathTrigger = CreateTrigger();
      TriggerRegisterDeathEvent(frozenThroneDeathTrigger, frozenThrone.Unit);
      TriggerAddAction(frozenThroneDeathTrigger, ChangeUnitOwnershipAndDisableTraining);
    }

    /// <inheritdoc />
    public override string RewardFlavour =>
      "Arthas has reclaimed the Helm of Domination, restoring his control over the mindless undead. The Scourge rises again under the command of its new King.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Arthas can now train and control the mindless undead once more.";

    private void ChangeUnitOwnershipAndDisableTraining()
    {
      var player = GetOwningPlayer(_frozenThrone.Unit);

      if (player != null)
      {
        var playerUnits = CreateGroup()
            .EnumUnitsOfPlayer(player)
            .EmptyToList();

        foreach (var unit in playerUnits)
        {
          if (_specificUnitIds.Contains(GetUnitTypeId(unit)))
          {
            unit.SetOwner(Player(PLAYER_NEUTRAL_AGGRESSIVE));
          }
        }

        var researchLevel = 0;
        SetPlayerTechResearched(player, ResearchId, researchLevel);
      }
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var player = completingFaction.Player;

      if (player != null && ArthasHasHelmOfDomination(_arthas, _helmOfDomination))
      {
        var researchLevel = 1;
        SetPlayerTechResearched(player, ResearchId, researchLevel);
      }
    }

    private bool ArthasHasHelmOfDomination(LegendaryHero arthas, Artifact helmOfDomination)
    {
      return helmOfDomination.OwningUnit == arthas.Unit;
    }

    /// <inheritdoc />
    protected override void OnAdd(Faction whichFaction)
    {
      var player = whichFaction.Player;
      if (player != null)
      {
        var researchLevel = 1;
        SetPlayerTechResearched(player, ResearchId, researchLevel);
      }
    }
  }
}
