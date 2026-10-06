using System;
using MacroTools.Quests;
using MacroTools.WorldEvents;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A throwaway <see cref="WorldEvent"/> used to try out the Events menu.
/// </summary>
public sealed class TestWorldEvent : WorldEvent
{
  private readonly Action _onHappened;

  public TestWorldEvent(Action onHappened, params Objective[] requirements)
  {
    _onHappened = onHappened;
    foreach (var requirement in requirements)
    {
      AddRequirement(requirement);
    }
  }

  /// <inheritdoc />
  protected override void OnHappened() => _onHappened();
}
