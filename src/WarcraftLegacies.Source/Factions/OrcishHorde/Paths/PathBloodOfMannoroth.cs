using System;
using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Paths;

/// <summary>With the Fountain of Blood in their hands, the orcs can drink the blood of Mannoroth and return to the Legion.</summary>
public sealed class PathBloodOfMannoroth : FactionPath
{
  private readonly ChaosOrcs _chaosOrcs;
  private readonly Action<Faction> _onDrunk;

  public PathBloodOfMannoroth(ChaosOrcs chaosOrcs, Action<Faction> onDrunk)
  {
    _chaosOrcs = chaosOrcs;
    _onDrunk = onDrunk;
    Name = "The Blood of Mannoroth";
    IconName = "ChaosGrom";
    Description = "The dark waters of the Fountain of Blood call to the orcs as they did on the plains of Draenor. Drink, and be reborn in fury as the Chaos Orcs, bound once more to the Burning Legion. Thrall will have no part of it, and leaves to stand with the tauren. Mannoroth himself comes to lead you, and Varok Saurfang will answer the call at your altar.";
    AddMustStayTrueRequirement(new ObjectiveControlCapital(AllLegends.Neutral.FountainOfBlood, false) { ShowsInQuestLog = false });
    CanGoSolo = true;
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Legion;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    _chaosOrcs.Corrupt();
    _onDrunk(_chaosOrcs.ChaosFaction ?? faction);
  }
}
