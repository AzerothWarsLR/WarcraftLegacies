using MacroTools.GameTime;
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
    // Arrange

    // Act
    var objective = new ObjectiveExpire(5, "foo");

    // Assert
    Assert.Equal("Turn 5 hasn't started", objective.Description);
  }

  [Fact]
  public void TurnEnded_AtExpiration_SetsProgressFailed()
  {
    // Arrange
    var objective = new ObjectiveExpire(1, "foo") { ShowsInQuestLog = false };

    // Act
    GameTimeManager.SkipTurns(1);

    // Assert
    Assert.Equal(QuestProgress.Failed, objective.Progress);
  }

  [Fact]
  public void TurnEnded_AfterExpiration_DoesNotReactAgain()
  {
    // Arrange
    var progressChangedCalls = 0;
    var objective = new ObjectiveExpire(1, "foo") { ShowsInQuestLog = false };
    objective.ProgressChanged += (_, _) => progressChangedCalls++;

    // Act
    GameTimeManager.SkipTurns(3);

    // Assert
    Assert.Equal(1, progressChangedCalls);
    Assert.Equal(QuestProgress.Failed, objective.Progress);
  }

  public void Dispose()
  {
    GameTimeManagerTest.Reset();
  }
}
