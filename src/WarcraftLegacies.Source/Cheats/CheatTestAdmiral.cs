using MacroTools.Commands;
using MacroTools.Extensions;
using WarcraftLegacies.Source.Factions.Kultiras;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Destroys Boralus and kills Daelin so The Admiral's Fall opens.</summary>
public sealed class CheatTestAdmiral : Command
{
  /// <inheritdoc />
  public override string CommandText => "testadmiral";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Destroys Boralus and kills Daelin Proudmoore so The Admiral's Fall opens.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (cheater.GetPlayerData().Faction is not KultirasFaction)
    {
      return "Play Kul Tiras to run this.";
    }

    var boralus = AllLegends.Kultiras.LegendBoralus.Unit;
    if (boralus != null && boralus.Alive)
    {
      boralus.Kill();
    }

    var daelin = AllLegends.Kultiras.LegendAdmiral.Unit;
    if (daelin != null && daelin.Alive)
    {
      daelin.Kill();
    }

    return "Boralus destroyed and Daelin killed. Open the Paths book.";
  }
}
