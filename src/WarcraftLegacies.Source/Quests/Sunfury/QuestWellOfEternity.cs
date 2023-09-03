using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Sunfury
{
  public sealed class QuestWellOfEternity : QuestData
  {
    private readonly LegendaryHero _kiljaeden;
    private readonly unit _well;

    public QuestWellOfEternity(PreplacedUnitSystem preplacedUnitSystem, LegendaryHero kiljaeden) : base("The Well of Eternity",
      "The Maelstrom still hides the shattered Well of Eternity. With his immense power, Kil'jaeden can summon a new well that will bring forth the destruction of the world.",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      _kiljaeden = kiljaeden;
      _well = preplacedUnitSystem.GetUnit(Constants.UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_MAGIC).Show(false);
      AddObjective(new ObjectiveChannelRect(Regions.MaelstromChannel, "The Maelstrom", _kiljaeden, 420, 90, Title));
      Global = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Well of Eternity has been reformed, the Sunfury now have unlimited arcane energy";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "The Well of Eternity will give every Sunfury unit infinite mana";


    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      _well.Show(true);
      SetUnitOwner(_well, completingFaction.Player, true);
    }
  }
}