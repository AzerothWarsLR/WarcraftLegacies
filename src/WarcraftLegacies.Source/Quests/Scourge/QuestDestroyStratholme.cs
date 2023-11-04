using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Lordaeron;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestDestroyStratholme : QuestData
  {
    private readonly LegendaryHero _arthas;
    
    public QuestDestroyStratholme(Capital stratholme, LegendaryHero arthas) : base("The Culling",
      "When the city of Stratholme falls, Prince Arthas' despair will make him more susceptible to the power of the Lich King.",
      @"ReplaceableTextures\CommandButtons\BTNRuneblade.blp")
    {
      if (LordaeronSetup.Lordaeron == null)
        throw new InvalidOperationException($"Could not construct {nameof(QuestDestroyStratholme)} because {nameof(LordaeronSetup.Lordaeron)} is null.");
      
      _arthas = arthas;
      AddObjective(new ObjectiveCapitalDead(stratholme));
      var lineOfSuccession = LordaeronSetup.Lordaeron.GetQuestByType<QuestKingArthas>();
      AddObjective(new ObjectiveFactionQuestNotComplete(lineOfSuccession, LordaeronSetup.Lordaeron));
      ResearchId = Constants.UPGRADE_R01K_QUEST_COMPLETED_THE_CULLING;
      Required = true;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion.";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Arthas abandons Lordaeron to join the Scourge; learn to train {_arthas.Name} from the {GetObjectName(Constants.UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR)}";

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