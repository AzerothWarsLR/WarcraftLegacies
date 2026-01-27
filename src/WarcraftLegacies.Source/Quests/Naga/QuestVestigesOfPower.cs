using System.Collections.Generic;
using MacroTools.ArtifactSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.ObjectiveSystem.Objectives.ArtifactBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestVestigesOfPower : QuestData
{
    private Artifact? _chosenArtifact;
    private string _rewardFlavour = "";
    private string _iconPath;

    public QuestVestigesOfPower(QuestData prerequisite) : base(
        "Vestiges of Power",
        "Illidan seeks a powerful artifact to increase his strength. He will not rest until he claims it.",
        @"ReplaceableTextures\CommandButtons\BTNBookOfMedivh.blp")
    {
        _iconPath = @"ReplaceableTextures\CommandButtons\BTNBookOfMedivh.blp";
        Knowledge = 10;

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

        if (_chosenArtifact == Artifacts.BookOfMedivh)
        {
            _rewardFlavour = "The tome of the Guardian Medivh contains secrets of immense arcane power. Illidan will not rest until its knowledge is his.";
            _iconPath = @"ReplaceableTextures\CommandButtons\BTNBookOfMedivh.blp";
        }
        else if (_chosenArtifact == Artifacts.ScepterOfTheQueen)
        {
            _rewardFlavour = "The Scepter of the Queen pulses with ancient Highborne power. Illidan seeks it to harness the magic of the deep Naga for his own designs.";
            _iconPath = @"ReplaceableTextures\CommandButtons\BTNNagaWeaponUp2.blp";
        }
        else
        {
            _rewardFlavour = "A fragment of Zin’rokh pulses with raw titan energy. Illidan must claim it before others can wield its power.";
            _iconPath = @"ReplaceableTextures\CommandButtons\BTNPhilosophersStone.blp";
        }
    }

    public override string RewardFlavour => _rewardFlavour;
}
