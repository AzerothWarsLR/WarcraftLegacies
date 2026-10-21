using MacroTools.Commands;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Puts Magtheridon in chains outside Hellfire Citadel so his rescue can be tested.</summary>
public sealed class CheatTestChainedMag : Command
{
  /// <inheritdoc />
  public override string CommandText => "testchainedmag";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    "Puts Magtheridon in chains outside Hellfire Citadel. Bring a Fel Horde hero to him to free him.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var chainedMagtheridon = RoleplaySetting.ChainedMagtheridon;
    if (chainedMagtheridon == null)
    {
      return "Magtheridon's chains aren't set up. Is this Roleplay mode with the Fel Horde?";
    }

    if (chainedMagtheridon.IsChained)
    {
      return "Magtheridon is already in chains.";
    }

    chainedMagtheridon.Chain();
    return "Magtheridon is in chains outside Hellfire Citadel.";
  }
}
