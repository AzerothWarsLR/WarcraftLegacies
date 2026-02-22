using MacroTools.GameTime;
using MacroTools.TestSupport;

namespace MacroTools.Tests.GameTime;

[Collection(nameof(GameTimeManagerCollection))]
public sealed class TurnCallbackTests : IDisposable
{
  public TurnCallbackTests() => GameTimeManagerTest.Reset();

  public void Dispose() => GameTimeManagerTest.Reset();

  [Theory]
  [InlineData(5, 4)]
  [InlineData(10, 1)]
  public void Ctor_ThrowsWhenEndTurnIsLessThanStartTurn(int startTurn, int endTurn)
  {
    // Arrange

    // Act
    var exception = Record.Exception(() => new TurnCallback(startTurn, endTurn, 1, () => { }));

    // Assert
    Assert.IsType<ArgumentException>(exception);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void Ctor_ThrowsWhenIntervalIsZeroOrNegative(int interval)
  {
    // Arrange

    // Act
    var exception = Record.Exception(() => new TurnCallback(1, TurnCallback.Infinite, interval, () => { }));

    // Assert
    Assert.IsType<ArgumentException>(exception);
  }

  [Theory]
  [InlineData(5, 5)]
  [InlineData(5, 4)]
  public void Ctor_ThrowsWhenStartTurnIsLessThanOrEqualToCurrentTurn(int currentTurn, int startTurn)
  {
    // Arrange
    GameTimeManagerTest.Turn = currentTurn;

    // Act
    var exception = Record.Exception(() => new TurnCallback(startTurn, TurnCallback.Infinite, 1, () => { }));

    // Assert
    Assert.IsType<ArgumentException>(exception);
  }

  [Theory]
  [InlineData(5, 5)]
  [InlineData(5, 4)]
  public void Ctor_ThrowsWhenEndTurnIsLessThanOrEqualToCurrentTurn(int currentTurn, int endTurn)
  {
    // Arrange
    GameTimeManagerTest.Turn = currentTurn;

    // Act
    var exception = Record.Exception(() => new TurnCallback(6, endTurn, 1, () => { }));

    // Assert
    Assert.IsType<ArgumentException>(exception);
  }

  [Fact]
  public void Advance_ReturnsFalseWhenInfinite()
  {
    // Arrange
    var callback = new TurnCallback(1, TurnCallback.Infinite, 1, () => { });

    // Act
    var completed = callback.Advance(1);

    // Assert
    Assert.False(completed);
  }

  [Fact]
  public void Advance_ReturnsTrueWhenPastEndTurn()
  {
    // Arrange
    var callback = new TurnCallback(1, 1, 1, () => { });

    // Act
    var completed = callback.Advance(1);

    // Assert
    Assert.True(completed);
  }

  [Theory]
  [InlineData(1, 1, 5, 5)]
  [InlineData(1, 2, 5, 3)]
  [InlineData(2, 3, 10, 3)] // interval is relative to startTurn
  public void Advance_SchedulesNextExecutionBasedOnInterval(int startTurn, int interval, int maxTurn, int expectedCalls)
  {
    // Arrange
    var callCount = 0;
    var callback = new TurnCallback(startTurn, TurnCallback.Infinite, interval, () => callCount++);

    // Act
    for (var turn = 1; turn <= maxTurn; turn++)
    {
      callback.Advance(turn);
    }

    // Assert
    Assert.Equal(expectedCalls, callCount);
  }

  [Theory]
  [InlineData(1, 5, 1, 5)]
  public void Advance_StopsExecutingAfterEndTurn(int start, int end, int interval, int expectedCalls)
  {
    // Arrange
    var completed = false;
    var callCount = 0;
    var callback = new TurnCallback(start, end, interval, () => callCount++);

    // Act
    for (var turn = 1; turn <= end + 5; turn++)
    {
      completed |= callback.Advance(turn);
    }

    // Assert
    Assert.True(completed);
    Assert.Equal(expectedCalls, callCount);
  }

  [Theory]
  [InlineData(true, 1)]
  [InlineData(false, 0)]
  public void Advance_RespectsCondition(bool conditionResult, int expectedCalls)
  {
    // Arrange
    var callCount = 0;

    var callback = new TurnCallback(1, TurnCallback.Infinite, 1, () => callCount++, () => conditionResult);

    // Act
    callback.Advance(1);

    // Assert
    Assert.Equal(expectedCalls, callCount);
  }
}
