using MacroTools.CommandSystem;
using MacroTools.FactionSystem;

namespace MacroTools.Cheats
{
  /// <summary>
  /// A command that displays all quest names of a specified <see cref="Faction"/>.
  /// <para/>
  /// Example usage: -quests Scourge
  /// </summary>
  public sealed class CheatShowQuestNames : Command
  {
    /// <inheritdoc />
    public override string CommandText => "quests";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Displays all quest names of a specified faction.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!FactionManager.TryGetFactionByName(parameters[0], out var faction))
        return $"There is no faction named {parameters[0]}.";
      
      var quests = faction.GetAllQuests();
      var message = $"Attempting to display all quests names of faction {parameters[0]}.\n";

      foreach (var quest in quests)
        message += $"Quest name: {quest.Title}\n";
      return message;
    }
  }
}