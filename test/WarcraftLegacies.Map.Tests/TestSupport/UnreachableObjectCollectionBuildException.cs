using Xunit.Sdk;

namespace WarcraftLegacies.Map.Tests.TestSupport;

/// <summary>
/// Thrown when a test cannot proceed because <see cref="Warcraft.Integrity.UnreachableObjectCollection"/> failed to build cleanly.
/// </summary>
public sealed class UnreachableObjectCollectionBuildException(IEnumerable<Exception> exceptions) : XunitException(
  "Test cannot start because there were issues building the UnreachableObjectCollection.",
  new AggregateException(exceptions));
