using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ArtifactBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestVestigesOfPower : QuestData
{
  private Artifact? _chosenArtifact;

  public QuestVestigesOfPower(QuestData prerequisite) : base(
    "Vestiges of Power",
    "Illidan pursues a relic of prodigious power. He will wield it, and all challengers will fall.",
    @"ReplaceableTextures\CommandButtons\BTNPhilosophersStone.blp")
  {
    Knowledge = 15;

    var questCompleteObjective = new ObjectiveQuestComplete(prerequisite)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    };
    AddObjective(questCompleteObjective);
  }

  protected override void OnAdd(Faction whichFaction)
  {
    var possibleArtifacts = new List<Artifact>
    {
      Artifacts.BookOfMedivh,
      Artifacts.ScepterOfTheQueen,
      Artifacts.AzureFragment,
      Artifacts.EmeraldFragment,
      Artifacts.RubyFragment,
      Artifacts.ObsidianFragment,
      Artifacts.BronzeFragment
    };

    var randIndex = (int)GetRandomReal(0, possibleArtifacts.Count - 0.01f);
    _chosenArtifact = possibleArtifacts[randIndex];

    AddObjective(new ObjectiveAcquireArtifact(_chosenArtifact));
  }

  public override string RewardFlavour
  {
    get
    {
      if (_chosenArtifact == Artifacts.BookOfMedivh)
      {
        return "Illidan studies the tome of Medivh, unlocking arcane secrets that enhance his mastery over magic.";
      }

      if (_chosenArtifact == Artifacts.ScepterOfTheQueen)
      {
        return "Azshara's contains extraordinary energies, even so long after her death. Illidan relishes in recovering these once-lost Highborne secrets.";
      }

      return "Illidan claims the fragment of Zin’rokh, harnessing its titan energy to bolster the Illidari's might.";
    }
  }
}
