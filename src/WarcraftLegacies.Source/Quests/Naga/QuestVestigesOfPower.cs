using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ArtifactBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
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

    var roll = GetRandomInt(1, 100);

    if (roll <= 40)
    {
      _chosenArtifact = Artifacts.BookOfMedivh;
    }
    else if (roll <= 80)
    {
      _chosenArtifact = Artifacts.ScepterOfTheQueen;
    }
    else
    {
      var fragments = new List<Artifact>
    {
      Artifacts.AzureFragment,
      Artifacts.EmeraldFragment,
      Artifacts.RubyFragment,
      Artifacts.ObsidianFragment,
      Artifacts.BronzeFragment
    };
      var randIndex = GetRandomInt(0, fragments.Count - 1);
      _chosenArtifact = fragments[randIndex];
    }
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
        return "Azshara's scepter contains extraordinary energies, even so long after her death. Illidan relishes in recovering these once-lost Highborne secrets.";
      }

      return "The Soulflayer's blade, though shattered and spread to the corners of Azeroth, still hold immense power. Even Illidan cannot decipher the sword's origin - but he can relish its power.";
    }
  }
}
