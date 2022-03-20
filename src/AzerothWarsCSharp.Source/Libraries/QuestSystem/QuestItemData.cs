using System;
using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Libraries.QuestSystem
{
  public abstract class QuestItemData
  {
    public static event EventHandler<QuestItemData> ProgressChanged;

    private QuestItemData _parentQuestItem;
    private int _progress = QuestData.QUEST_PROGRESS_INCOMPLETE;
    private string _description = "";
    private minimapicon _minimapIcon;
    private effect _mapEffect; //The visual effect that appears on the map, usually a Circle of Power
    private effect _overheadEffect;
    private readonly widget _targetWidget = null;

    /// <summary>
    /// Overhead effects get rendered over the target widget.
    /// </summary>
    public widget TargetWidget => _targetWidget;

    /// <summary>
    /// The file path for the overhead effect to use for this item.
    /// </summary>
    public string OverheadEffectPath { get; }

    public string MapEffectPath { get; set; }

    public QuestItemData ParentQuestItem
    {
      set => _parentQuestItem = value;
    }

    public QuestData ParentQuest { get; set; }

    public questitem QuestItem { get; set; }

    /// <summary>
    /// Whether or not this can be seen as a bullet point in the quest log.
    /// </summary>
    public bool ShowsInQuestLog => true;

    public float X => 0;

    public float Y => 0;

    public Faction Holder => ParentQuest != null ? ParentQuest.Holder : _parentQuestItem?.Holder;

    public bool ProgressLocked
    {
      get
      {
        if (ParentQuest != null)
        {
          return ParentQuest.ProgressLocked;
        }

        return _parentQuestItem == null || _parentQuestItem.ProgressLocked;
      }
    }

    public int Progress
    {
      get => _progress;
      set
      {
        if (ProgressLocked || _progress == value)
        {
          return;
        }

        _progress = value;
        if (ShowsInQuestLog)
        {
          switch (value)
          {
            case QuestData.QUEST_PROGRESS_INCOMPLETE:
            {
              QuestItemSetCompleted(QuestItem, false);
              if (GetLocalPlayer() == Holder.Player)
              {
                ShowLocal();
              }

              ShowSync();
              break;
            }
            case QuestData.QUEST_PROGRESS_COMPLETE:
            {
              QuestItemSetCompleted(QuestItem, true);
              if (GetLocalPlayer() == Holder.Player)
              {
                HideLocal();
              }

              HideSync();
              break;
            }
            case QuestData.QUEST_PROGRESS_UNDISCOVERED:
            case QuestData.QUEST_PROGRESS_FAILED:
              QuestItemSetCompleted(QuestItem, false);
              break;
          }
        }

        ProgressChanged?.Invoke(this, this);
      }
    }

    public string Description
    {
      get => _description;
      set
      {
        _description = value;
        if (QuestItem != null)
        {
          QuestItemSetDescription(QuestItem, _description);
        }
      }
    }

    public string PingPath => "MinimapQuestObjectivePrimary";

    //Run when added to a Quest
    public void OnAdd()
    {
    }

    //Shows the local aspects of this QuestItem, namely the minimap icon.
    public void ShowLocal()
    {
      if (Progress == QuestData.QUEST_PROGRESS_INCOMPLETE &&
          ParentQuest.Progress == QuestData.QUEST_PROGRESS_INCOMPLETE)
      {
        if (_minimapIcon == null && X != 0 && Y != 0)
        {
          _minimapIcon = CreateMinimapIcon(X, Y, 255, 255, 0, SkinManagerGetLocalPath(PingPath),
            FOG_OF_WAR_MASKED);
        }
        else if (_minimapIcon != null)
        {
          SetMinimapIconVisible(_minimapIcon, true);
        }
      }
    }

    //Shows the synchronous aspects of this QuestItem, namely the visible target circle.
    public void ShowSync()
    {
      if (Progress == QuestData.QUEST_PROGRESS_INCOMPLETE && ParentQuest.Progress == QuestData.QUEST_PROGRESS_INCOMPLETE)
      {
        string effectPath;
        if (MapEffectPath != null && _mapEffect == null)
        {
          effectPath = GetLocalPlayer() == Holder.Player ? MapEffectPath : "";
          _mapEffect = AddSpecialEffect(effectPath, X, Y);
          BlzSetSpecialEffectColorByPlayer(_mapEffect, Holder.Player);
          BlzSetSpecialEffectHeight(_mapEffect, 100 + Environment.GetPositionZ(X, Y));
        }

        if (OverheadEffectPath != null && _overheadEffect == null && TargetWidget != null)
        {
          effectPath = GetLocalPlayer() == Holder.Player ? OverheadEffectPath : "";
          _overheadEffect = AddSpecialEffectTarget(effectPath, TargetWidget, "overhead");
        }
      }
    }

    //Hides the synchronous aspects of this QuestItem, namely the minimap icon.
    public void HideLocal()
    {
      if (_minimapIcon != null)
      {
        SetMinimapIconVisible(_minimapIcon, false);
      }
    }

    //Hides the synchronous aspects of this QuestItem, namely the minimap icon.
    public void HideSync()
    {
      if (_mapEffect != null)
      {
        DestroyEffect(_mapEffect);
        _mapEffect = null;
      }

      if (OverheadEffectPath != null)
      {
        DestroyEffect(_overheadEffect);
        _overheadEffect = null;
      }
    }

    public QuestItemData()
    {
      OverheadEffectPath = "Abilities\\Spells\\Other\\TalkToMe\\TalkToMe";
    }
  }
}