using AzerothWarsCSharp.Template.Source.Libraries;
using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.Template.Source.UserInterface
{
  public static class QuestMenu
  {
    private static void OnFactionQuestProgressChanged(object sender, FactionQuestProgressChangedArgs e)
    {
      throw new NotImplementedException();
    }

    private static void OnFactionQuestAdded(object sender, FactionQuestAddedArgs e)
    {
      if (GetLocalPlayer() == e.Faction.Player)
      {
        QuestSetEnabled(e.QuestEx.BlzQuest, true);
      }
    }

    static QuestMenu()
    {
      Faction.QuestAdded += OnFactionQuestAdded;
      Faction.QuestProgressChanged += OnFactionQuestProgressChanged;
    }
  }
}