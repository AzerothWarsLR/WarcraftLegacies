using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A throwaway <see cref="FactionPath"/> used to try out the Paths menu. Gives gold when taken.
/// </summary>
public sealed class TestPath : FactionPath
{
  private readonly int _goldReward;

  public TestPath(int goldReward, params Objective[] requirements)
  {
    _goldReward = goldReward;
    foreach (var requirement in requirements)
    {
      AddRequirement(requirement);
    }
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    if (faction.Player != null)
    {
      faction.Player.SetState(playerstate.ResourceGold, faction.Player.GetState(playerstate.ResourceGold) + _goldReward);
    }
  }
}
