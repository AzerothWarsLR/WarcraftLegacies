using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Paths;

/// <summary>With Mannoroth slain, the Chaos Orcs can throw off the blood curse and return to the Horde.</summary>
public sealed class PathTheBloodFades : FactionPath
{
  private readonly ChaosOrcs _chaosOrcs;
  private readonly ObjectiveTriggered _mannorothSlain;

  public PathTheBloodFades(ChaosOrcs chaosOrcs)
  {
    _chaosOrcs = chaosOrcs;
    Name = "The Blood Fades";
    IconName = "HellScream";
    Description = "Mannoroth is dead, and with him dies the hold of his blood. The orcs wake as if from a long nightmare. Seek redemption: Grom gives his life to break the curse, Thrall returns to lead his people, and the orcs cast off the Legion to rejoin the Horde.";
    DeclineDescription = "Remain with the Legion. The fury burns on, even without Mannoroth to stoke it.";
    _mannorothSlain = new ObjectiveTriggered("Mannoroth has been slain") { ShowsInQuestLog = false };
    AddRequirement(_mannorothSlain);
    CanGoSolo = true;
  }

  /// <summary>Offers the path, since Mannoroth has fallen.</summary>
  public void Open() => _mannorothSlain.Trigger();

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  public override bool IgnoresTeamChangeCooldown => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Horde;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _chaosOrcs.Redeem();
}
