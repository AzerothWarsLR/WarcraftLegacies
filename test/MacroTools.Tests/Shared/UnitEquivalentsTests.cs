using MacroTools.Shared;

namespace MacroTools.Tests.Shared;

public sealed class UnitEquivalentsTests
{
  [Fact]
  public void Pair_SameCategory_PairsByPosition()
  {
    // Arrange
    var from = new[] { new ObjectInfo(1, 1, UnitCategory.Tower), new ObjectInfo(2, 1, UnitCategory.Tower) };
    var to = new[] { new ObjectInfo(11, 1, UnitCategory.Tower), new ObjectInfo(12, 1, UnitCategory.Tower) };

    // Act
    var pairs = UnitEquivalents.Pair(from, to);

    // Assert
    Assert.Equal(11, pairs[1]);
    Assert.Equal(12, pairs[2]);
  }

  [Fact]
  public void Pair_FewerTargets_PairsWithLastTarget()
  {
    // Arrange
    var from = new[] { new ObjectInfo(1, 1, UnitCategory.Tower), new ObjectInfo(2, 1, UnitCategory.Tower) };
    var to = new[] { new ObjectInfo(11, 1, UnitCategory.Tower) };

    // Act
    var pairs = UnitEquivalents.Pair(from, to);

    // Assert
    Assert.Equal(11, pairs[2]);
  }

  [Fact]
  public void Pair_NoTargetInCategory_LeavesObjectUnpaired()
  {
    // Arrange
    var from = new[] { new ObjectInfo(1, 1, UnitCategory.Shipyard) };
    var to = new[] { new ObjectInfo(11, 1, UnitCategory.Tower) };

    // Act
    var pairs = UnitEquivalents.Pair(from, to);

    // Assert
    Assert.False(pairs.ContainsKey(1));
  }

  [Fact]
  public void Pair_Overrides_ReplaceAndKeep()
  {
    // Arrange
    var from = new[] { new ObjectInfo(1, 1, UnitCategory.Tower), new ObjectInfo(2, 1, UnitCategory.Farm) };
    var to = new[] { new ObjectInfo(11, 1, UnitCategory.Tower), new ObjectInfo(12, 1, UnitCategory.Farm) };
    var overrides = new Dictionary<int, int> { { 1, 99 }, { 2, UnitEquivalents.Keep } };

    // Act
    var pairs = UnitEquivalents.Pair(from, to, overrides);

    // Assert
    Assert.Equal(99, pairs[1]);
    Assert.False(pairs.ContainsKey(2));
  }
}
