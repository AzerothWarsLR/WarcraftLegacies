using MacroTools.CommandSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// A command that sets a specified <see cref="QuestData"/>'s progress to the specified level.
  /// </summary>
  public sealed class CheatQuestProgress : Command
  {
    private readonly QuestProgress _progress;
    private readonly string _commandText;

    /// <inheritdoc />
    public override string CommandText => _commandText;

    /// <inheritdoc />
    public override int ParameterCount => 2;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => $"Sets the specified quest's progress to {_progress.ToString()} for the specified faction.";

    /// <summary>
    /// Initializes a new instance of the <see cref="CheatQuestProgress"/> class.
    /// </summary>
    public CheatQuestProgress(string commandText, QuestProgress progress)
    {
      _commandText = commandText;
      _progress = progress;
    }
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var faction = FactionManager.GetFromName(parameters[0]);
      if (faction != null)
      {
        var quest = faction.GetQuestByTitle(parameters[1]);
        quest.Progress = _progress;
        return $"Setting quest progress of {parameters[1]} to {_progress.ToString()} for faction {parameters[0]}.";
      }
      return $"Failed to set quest progress of {parameters[1]} for faction {parameters[0]}.";
    }
  }
}