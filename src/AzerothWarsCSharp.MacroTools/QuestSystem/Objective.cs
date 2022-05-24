using System;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using Environment = AzerothWarsCSharp.MacroTools.Libraries.Environment;

namespace AzerothWarsCSharp.MacroTools.QuestSystem
{
  public abstract class Objective
  {
    private string _description = "";
    private effect? _mapEffect; //The visual effect that appears on the map, usually a Circle of Power
    private minimapicon? _minimapIcon;
    private effect? _overheadEffect;

    private Objective? _parentQuestItem;
    private QuestProgress _progress = QuestProgress.Incomplete;

    /// <summary>
    /// An arbitrary objective that can be completed or failed.
    /// </summary>
    protected Objective()
    {
      OverheadEffectPath = "Abilities\\Spells\\Other\\TalkToMe\\TalkToMe";
    }

    /// <summary>
    ///   Where the <see cref="Objective" /> can be completed.
    /// </summary>
    public virtual Point Position { get; }

    /// <summary>
    ///   Whether or not the <see cref="Objective" /> should display a position.
    /// </summary>
    protected bool DisplaysPosition { get; init; }

    /// <summary>
    ///   Overhead effects get rendered over the target widget.
    /// </summary>
    protected widget? TargetWidget { get; init; }

    /// <summary>
    ///   The file path for the overhead effect to use for this item.
    /// </summary>
    private string? OverheadEffectPath { get; }

    protected string? MapEffectPath { get; init; }

    internal Objective ParentQuestItem
    {
      set => _parentQuestItem = value;
    }

    internal QuestData ParentQuest { get; set; }

    internal questitem QuestItem { get; set; }

    /// <summary>
    ///   Whether or not this can be seen as a bullet point in the quest log.
    /// </summary>
    public bool ShowsInQuestLog { get; protected init; } = true;
    
    protected bool ProgressLocked
    {
      get
      {
        if (ParentQuest != null) return ParentQuest.ProgressLocked;

        return _parentQuestItem == null || _parentQuestItem.ProgressLocked;
      }
    }

    public QuestProgress Progress
    {
      get => _progress;
      set
      {
        if (ProgressLocked || _progress == value) return;

        _progress = value;
        if (ShowsInQuestLog)
          if (value == QuestProgress.Incomplete)
          {
            QuestItemSetCompleted(QuestItem, false);
            if (_eligibleFactions.ContainsPlayer(GetLocalPlayer())) 
              ShowLocal();

            ShowSync();
          }
          else if (value == QuestProgress.Complete)
          {
            QuestItemSetCompleted(QuestItem, true);
            if (_eligibleFactions.ContainsPlayer(GetLocalPlayer())) 
              HideLocal();

            HideSync();
          }
          else if (value == QuestProgress.Undiscovered)
          {
            QuestItemSetCompleted(QuestItem, false);
          }
          else if (value == QuestProgress.Failed)
          {
            QuestItemSetCompleted(QuestItem, false);
          }

        ProgressChanged?.Invoke(this, this);
      }
    }

    public string Description
    {
      get => _description;
      protected set
      {
        _description = value;
        QuestItemSetDescription(QuestItem, _description);
      }
    }

    /// <summary>
    ///   The texture path for the icon that appears showing where this <see cref="Objective" />
    ///   can be completed.
    /// </summary>
    protected string PingPath { get; init; } = "MinimapQuestObjectivePrimary";

    public event EventHandler<Objective>? ProgressChanged;

    /// <summary>
    ///   Runs when a <see cref="QuestData" /> with this <see cref="Objective" /> is added to a <see cref="Faction" />.
    /// </summary>
    internal virtual void OnAdd()
    {
    }

    //Shows the local aspects of this QuestItem, namely the minimap icon.
    internal void ShowLocal()
    {
      if (Progress == QuestProgress.Incomplete &&
          ParentQuest.Progress == QuestProgress.Incomplete)
      {
        if (_minimapIcon == null && DisplaysPosition)
          _minimapIcon = CreateMinimapIcon(Position.X, Position.Y, 255, 255, 0, SkinManagerGetLocalPath(PingPath),
            FOG_OF_WAR_MASKED);
        else if (_minimapIcon != null) 
          SetMinimapIconVisible(_minimapIcon, true);
      }
    }

    /// <summary>
    ///   Shows the synchronous aspects of this QuestItem, namely the visible target circle.
    /// </summary>
    internal void ShowSync()
    {
      if (Progress == QuestProgress.Incomplete && ParentQuest.Progress == QuestProgress.Incomplete)
      {
        string effectPath;
        if (MapEffectPath != null && _mapEffect == null)
        {
          effectPath = _eligibleFactions.ContainsPlayer(GetLocalPlayer()) ? MapEffectPath : "";
          _mapEffect = AddSpecialEffect(effectPath, Position.X, Position.Y);
          BlzSetSpecialEffectColorByPlayer(_mapEffect, _eligibleFactions.First().Player);
          BlzSetSpecialEffectHeight(_mapEffect, 100 + Environment.GetPositionZ(Position.X, Position.Y));
        }

        if (OverheadEffectPath != null && _overheadEffect == null && TargetWidget != null)
        {
          effectPath = _eligibleFactions.ContainsPlayer(GetLocalPlayer()) ? OverheadEffectPath : "";
          _overheadEffect = AddSpecialEffectTarget(effectPath, TargetWidget, "overhead");
        }
      }
    }

    /// <summary>
    ///   Hides the synchronous aspects of this QuestItem, namely the minimap icon.
    /// </summary>
    internal void HideLocal()
    {
      if (_minimapIcon != null) SetMinimapIconVisible(_minimapIcon, false);
    }

    /// <summary>
    ///   Hides the synchronous aspects of this QuestItem, namely the map effect.
    /// </summary>
    internal void HideSync()
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
  }
}