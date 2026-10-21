using MacroTools.Commands;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Helps test Daelin's Vengeance.</summary>
public sealed class CheatTestDaelin : Command
{
  /// <inheritdoc />
  public override string CommandText => "testdaelin";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Puts Theramore on the Horde if it exists and offers Kul Tiras the path. Add \"land\" to land the fleet straight away.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var daelinsVengeance = RoleplaySetting.DaelinsVengeance;
    if (daelinsVengeance == null)
    {
      return "Daelin's Vengeance only exists in Roleplay mode.";
    }

    if (parameters.Length > 0 && parameters[0].ToLower() == "land")
    {
      daelinsVengeance.ForceHappen();
      return "Daelin's fleet has landed.";
    }

    daelinsVengeance.ForceOffer();
    return "Kul Tiras has been offered Daelin's Vengeance.";
  }
}
