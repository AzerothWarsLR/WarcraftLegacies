using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using static War3Api.Common;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestDestroyStratholme : QuestData
  {
    private readonly LegendaryHero _arthas;
    
    public QuestDestroyStratholme(Capital stratholme, LegendaryHero arthas) : base("The Culling", "When the city of Stratholme falls, Prince Arthas' despair will make him more susceptible to the power of the Lich King.", @"ReplaceableTextures\CommandButtons\BTNRuneblade.blp")
    {
      _arthas = arthas;
      AddObjective(new ObjectiveCapitalDead(stratholme));
      Required = true;
    }

    /// <inheritdoc />
    protected override string RewardFlavour => "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion.";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train {_arthas.Name} from the {GetObjectName(Constants.UNIT_UAOD_ALTAR_OF_DARKNESS)}";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      var arthas = _arthas.Unit;

      if (arthas == null || !UnitAlive(arthas))
        return;

      arthas.Kill();
      arthas.Remove();
    }
  }
}