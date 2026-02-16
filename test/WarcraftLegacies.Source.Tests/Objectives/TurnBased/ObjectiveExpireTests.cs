using MacroTools.Quests;
using MacroTools.TestSupport;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Tests.Objectives.TurnBased;

[Collection(nameof(GameTimeManagerCollection))]
public sealed class ObjectiveExpireTests : IDisposable
{
  public ObjectiveExpireTests()
  {
    GameTimeManagerTest.Reset();
  }

  [Fact]
  public void Constructor_SetsDescription()
  {
    var objective = new ObjectiveExpire(5, "foo");

    Assert.Equal("Turn 5 hasn't started", objective.Description);
  }

  [Fact]
  public void TurnEnded_AtExpiration_SetsProgressFailed()
  {
    // Arrange
    var objective = new ObjectiveExpire(5, "foo") { ShowsInQuestLog = false };
    GameTimeManagerTest.TurnCount = 5;

    // Act
    GameTimeManagerTest.RaiseTurnEnded();

    // Assert
    Assert.Equal(QuestProgress.Failed, objective.Progress);
  }

  [Fact]
  public void TurnEnded_AfterExpiration_DoesNotReactAgain()
  {
    // Arrange
    var progressChangedCalls = 0;
    var objective = new ObjectiveExpire(5, "foo") { ShowsInQuestLog = false };
    objective.ProgressChanged += (_, _) => progressChangedCalls++;
    GameTimeManagerTest.TurnCount = 5;
    GameTimeManagerTest.RaiseTurnEnded();

    // Act
    GameTimeManagerTest.TurnCount++;
    GameTimeManagerTest.RaiseTurnEnded();

    // Assert
    Assert.Equal(1, progressChangedCalls);
    Assert.Equal(QuestProgress.Failed, objective.Progress);
  }

  public void Dispose()
  {
    GameTimeManagerTest.Reset();
  }
}
