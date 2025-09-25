using MacroTools.CommandSystem;

namespace MacroTools.Cheats;

/// <summary>
/// Tells the cheater how many times they have researched a specified research.
/// </summary>
public sealed class CheatResearchLevel : Command
{

  /// <inheritdoc />
  public override string CommandText => "hasresearch";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Displays how many times a specified research has been researched.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var obj = FourCC(parameters[0]);
    return "Level of research " + GetObjectName(obj) + ": " + I2S(cheater.GetTechResearched(obj));
  }
}
