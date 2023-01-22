using MacroTools.CommandSystem;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// A command that completes a specified <see cref="QuestData"/>.
  /// </summary>
  public sealed class CheatCompleteQuest : Command
  {
    /// <inheritdoc />
    public override string CommandText => "complete";

    /// <inheritdoc />
    public override int ParameterCount => 2;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Completes a specified quest be the specified faction.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var faction = FactionManager.GetFromName(parameters[0]);
      if (faction != null)
      {
        var quest = faction.GetQuestByTitle(parameters[1]);
        quest.Progress = QuestProgress.Complete;
        return $"Completed quest {parameters[1]} of faction {parameters[0]}.";
      }
      return $"Failed to complete {parameters[1]} of faction {parameters[0]}.";
    }
  }
}