using MacroTools.ArtifactSystem;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Frostwolf;

public sealed class QuestDrektharsSpellbook : QuestData
{
  private readonly LegendaryHero _thrall;

  public QuestDrektharsSpellbook(Capital vortex, LegendaryHero thrall) : base("Drekthar's Spellbook",
    "The elemental planes are out of control. Bring Thrall to the Vortex Pinnacle to bring back the balance.",
    @"ReplaceableTextures\CommandButtons\BTNSorceressMaster.blp")
  {
    _thrall = thrall;
    AddObjective(new ObjectiveControlCapital(vortex, false));
    AddObjective(new ObjectiveLegendInRect(thrall, Regions.Tempest_Rain,
      "Vortex Pinnacle"));
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Vortex Pinnacle has been captured by the Horde. Drek'thar has gifted Warchief Thrall his magical spellbook for this achievement.";

  /// <inheritdoc />
  protected override string RewardDescription => "Drek'thar's Spellbook";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var drektharsSpellBook = new Artifact(item.Create(ITEM_DTSB_DREK_THAR_S_SPELLBOOK, 0, 0));
    ArtifactManager.Register(drektharsSpellBook);
    _thrall.Unit?.AddItemSafe(drektharsSpellBook.Item);
  }
}
