using MacroTools.GameTime;
using MacroTools.Quests;
using MacroTools.TestSupport;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Tests.Objectives.TurnBased;

[Collection(nameof(GameTimeManagerCollection))]
public sealed class ObjectiveTurnTests : IDisposable
{
  public ObjectiveTurnTests()
  {
    GameTimeManagerTest.Reset();
  }

  [Fact]
  public void Constructor_SetsDescription()
  {
    // Arrange

    // Act
    var objective = new ObjectiveTurn(5);

    // Assert
    Assert.Equal("Turn 5 has started", objective.Description);
  }

  [Fact]
  public void TurnEnded_AtTargetTurn_CompletesObjective()
  {
    // Arrange
    var objective = new ObjectiveTurn(1) { ShowsInQuestLog = false };

    // Act
    GameTimeManager.SkipTurns(1);

    // Assert
    Assert.Equal(QuestProgress.Complete, objective.Progress);
  }

  [Fact]
  public void TurnEnded_AfterTargetTurn_DoesNotReactAgain()
  {
    // Arrange
    var progressChangedCalls = 0;
    var objective = new ObjectiveTurn(1) { ShowsInQuestLog = false };
    objective.ProgressChanged += (_, _) => progressChangedCalls++;

    // Act
    GameTimeManager.SkipTurns(2);

    // Assert
    Assert.Equal(1, progressChangedCalls);
    Assert.Equal(QuestProgress.Complete, objective.Progress);
  }

  public void Dispose()
  {
    GameTimeManagerTest.Reset();
  }
}
