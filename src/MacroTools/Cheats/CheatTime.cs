using MacroTools.CommandSystem;

namespace MacroTools.Cheats
{
  public sealed class CheatTime : Command
  {
    /// <inheritdoc />
    public override string CommandText => "time";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    /// <inheritdoc />
    public override string Description => "Sets the time to a particular value.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!float.TryParse(parameters[0], out var time))
        return "You must specify a valid float as the first parameter.";

      SetFloatGameState(GAME_STATE_TIME_OF_DAY, time);
      return $"Setting time of day to {time}.";
    }
  }
}