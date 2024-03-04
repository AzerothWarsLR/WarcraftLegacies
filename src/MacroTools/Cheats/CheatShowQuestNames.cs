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
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Displays all quest names of a specified faction.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var quests = FactionManager.GetFactionByName(parameters[0])?.GetAllQuests();
      var message = $"Attempting to display all quests names of faction {parameters[0]}.\n";
      if (quests != null)
        foreach (var quest in quests)
          message += $"Quest name: {quest.Title}\n";
      return message;
    }
  }
}