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
    "Illidan maintains an unquenchable thirst for power. The Skull of Gul'dan, the Warglaives of Azzinoth - these artifacts are not enough. He demands more.",
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
        return "Illidan pores over the prophet's tome, unveiling arcane secrets that enhance his already prodigious mastery over magic.";
      }

      if (_chosenArtifact == Artifacts.ScepterOfTheQueen)
      {
        return "Azshara's contains extraordinary energies, even so long after her death. Illidan relishes in recovering these once-lost Highborne secrets.";
      }

      return "The Soulflayer's blade, though shattered and spread to the corners of Azeroth, still hold immense power. Even Illidan cannot decipher the sword's origin - but he can relish its power.";
    }
  }
}
