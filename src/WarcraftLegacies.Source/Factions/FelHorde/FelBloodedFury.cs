using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared.Powers;

namespace WarcraftLegacies.Source.Factions.FelHorde;

/// <summary>Strengthens the Fel Horde while it fights for the Burning Legion.</summary>
public sealed class FelBloodedFury
{
  private const float Bonus = 0.1f;

  private readonly Faction _felHorde;
  private readonly EmpoweredUnits _power = new(x => !x.IsUnitType(unittype.Structure), Bonus)
  {
    Name = "Fel-blooded Fury",
    IconName = "BloodLust",
    DescriptionTemplate = "Demon blood burns in the veins of the Fel Horde while it serves the Legion. Your units deal {bonus}% more damage and take {reduction}% less damage. The fury fades should the Fel Horde ever turn from the Legion."
  };

  private bool _hasPower;

  public FelBloodedFury(Faction felHorde)
  {
    _felHorde = felHorde;
    TeamChanges.OnAnyTeamChanged(Refresh);
    Refresh();
  }

  private void Refresh()
  {
    var felHordePlayer = _felHorde.Player;
    var servesLegion = felHordePlayer != null && felHordePlayer.GetPlayerData().Team == TeamSetup.Legion;
    if (servesLegion == _hasPower)
    {
      return;
    }

    _hasPower = servesLegion;
    if (servesLegion)
    {
      _felHorde.AddPower(_power);
    }
    else
    {
      _felHorde.RemovePower(_power);
    }
  }
}
