using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public class Quest
  {
    public string Name { get; internal set; }
    public string Icon { get; internal set; }
    public Faction? Faction { get; internal set; }

    private readonly quest _quest;

    /// <summary>
    /// Makes this Quest visible to the specified player.
    /// It will appear in their Quest (F9) menu.
    /// </summary>
    /// <param name="player"></param>
    internal void Render(player player)
    {
      if (GetLocalPlayer() == player)
      {
        QuestSetEnabled(_quest, true);
      }
    }
    
    public Quest(string name, string icon)
    {
      Name = name;
      Icon = icon;
      _quest = CreateQuest();
      QuestSetTitle(_quest, name);
      QuestSetIconPath(_quest, $@"ReplaceableTextures\CommandButtons\BTN{icon}.blp");
      QuestSetRequired(_quest, false);
      QuestSetEnabled(_quest, false);
    }

    ~Quest()
    {
      DestroyQuest(_quest);
    }
  }
}