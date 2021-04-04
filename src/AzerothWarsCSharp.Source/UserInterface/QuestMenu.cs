using AzerothWarsCSharp.Source.Libraries;
using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UserInterface
{
  public static class QuestMenu
  {
    private static void SetupQuestForPlayer(QuestEx quest, player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
      {
        var blzQuest = CreateQuest();
        QuestSetTitle(blzQuest, quest.Title);
        QuestSetDescription(blzQuest, quest.Description);
        QuestSetIconPath(blzQuest, quest.Icon);
        foreach (var objective in quest.Objectives)
        {
          var blzQuestItem = QuestCreateItem(blzQuest);
          QuestItemSetDescription(blzQuestItem, objective.Description);
          QuestItemSetCompleted(blzQuestItem, objective.Progress == QuestProgress.Complete);
          _blzQuestitemsByLogSubEntry[objective] = blzQuestItem;
        }
      }
    }

    private static void UpdateQuestForPlayer(QuestEx quest, player whichPlayer)
    {
      if (GetLocalPlayer() == whichPlayer)
      {
        QuestSetDescription(_blzQuestsByQuestEx[quest], quest.Description);
      }
    }

    private static void OnFactionQuestProgressChanged(object sender, FactionQuestProgressChangedEventArgs e)
    {
      if (e.Faction != null)
      {
        UpdateQuestForPlayer(e.QuestEx, e.Faction.Player);
      }
    }

    private static void OnFactionQuestAdded(object sender, FactionQuestAddedEventArgs e)
    {
      if (GetLocalPlayer() == e.Faction.Player)
      {
        var questEx = e.QuestEx;
        {
          if (_blzQuestsByQuestEx.ContainsKey(questEx))
          {
            var blzQuest = _blzQuestsByQuestEx[questEx];
            QuestSetEnabled(blzQuest, true);
          }
          else
          {
            SetupQuestForPlayer(questEx, e.Faction.Player);
          }
        }
      }
    }

    private static void OnFactionQuestRemoved(object sender, FactionQuestAddedEventArgs e)
    {
      throw new NotImplementedException();
    }

    private static void UnregisterFaction(Faction faction)
    {
      faction.QuestAdded += OnFactionQuestAdded;
      faction.QuestRemoved += OnFactionQuestRemoved;
      faction.QuestProgressChanged += OnFactionQuestProgressChanged;
    }

    private static void RegisterFaction(Faction faction)
    {
      faction.QuestAdded += OnFactionQuestAdded;
      faction.QuestRemoved += OnFactionQuestRemoved;
      faction.QuestProgressChanged += OnFactionQuestProgressChanged;
      faction.Destroyed += OnFactionDestroyed;
    }

    private static void OnFactionDestroyed(object sender, FactionEventArgs e)
    {
      UnregisterFaction(e.Faction);
    }

    private static void OnFactionCreated(object sender, FactionEventArgs e)
    {
      RegisterFaction(e.Faction);
    }

    public static void Initialize()
    {
      foreach (var faction in Faction.All)
      {
        RegisterFaction(faction);
      }
      Faction.FactionCreated += OnFactionCreated;
    }

    private static readonly Dictionary<QuestEx, quest> _blzQuestsByQuestEx = new();
    private static readonly Dictionary<Objective, questitem> _blzQuestitemsByLogSubEntry = new();
  }
}