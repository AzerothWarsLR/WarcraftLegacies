using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using Environment = MacroTools.Libraries.Environment;

namespace MacroTools.ObjectiveSystem
{
  public abstract class Objective
  {
    private string _description = "";
    private effect? _mapEffect; //The visual effect that appears on the map, usually a Circle of Power
    private minimapicon? _minimapIcon;
    private effect? _overheadEffect;

    private QuestProgress _progress = QuestProgress.Incomplete;

    /// <summary>
    ///   An arbitrary objective that can be completed or failed.
    /// </summary>
    protected Objective()
    {
      OverheadEffectPath = "Abilities\\Spells\\Other\\TalkToMe\\TalkToMe";
    }

    public List<Faction> EligibleFactions { get; init; } = new();

    /// <summary>
    ///   Where the <see cref="Objective" /> can be completed.
    /// </summary>
    public Point? Position { get; protected init; }

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

    internal questitem QuestItem { get; set; }

    /// <summary>
    ///  Whether or not this can be seen as a bullet point in the quest log.
    /// </summary>
    public bool ShowsInQuestLog { get; protected init; } = true;

    internal bool ProgressLocked { get; set; }

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
          }
          else if (value == QuestProgress.Complete)
          {
            QuestItemSetCompleted(QuestItem, true);
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

    /// <summary>
    /// Describes what must be done in order to complete the <see cref="Objective"/>
    /// </summary>
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

    protected bool? IsPlayerOnSameTeamAsAnyEligibleFaction(player? whichPlayer)
    {
      if (whichPlayer == null)
        return null;
      
      foreach (var eligibleFaction in EligibleFactions)
      {
        if (eligibleFaction.Player == null)
          return null;

        if (eligibleFaction.Player == Player(PLAYER_NEUTRAL_PASSIVE) || eligibleFaction.Player == Player(PLAYER_NEUTRAL_AGGRESSIVE))
          return null;
        
        if (eligibleFaction.Player.GetTeam() == whichPlayer.GetTeam())
          return true;
      }
      return false;
    }

    internal void AddEligibleFaction(Faction faction)
    {
      EligibleFactions.Add(faction);
    }

    /// <summary>
    /// Fires after the <see cref="Progress"/> of this quest has changed
    /// </summary>
    public event EventHandler<Objective>? ProgressChanged;

    /// <summary>
    ///   Runs when this <see cref="Objective"/> is registered to a <see cref="QuestData"/> or the <see cref="TriggeredDialogueManager"/>.
    /// </summary>
    internal virtual void OnAdd(Faction faction)
    {
    }

    /// <summary>
    /// Shows the local aspects of this QuestItem, namely the minimap icon.
    /// </summary>
    /// <param name="parentQuestProgress"></param>
    internal void ShowLocal(QuestProgress parentQuestProgress)
    {
      if (Progress == QuestProgress.Incomplete &&
          parentQuestProgress == QuestProgress.Incomplete)
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
    internal void ShowSync(QuestProgress parentQuestProgress)
    {
      if (Progress == QuestProgress.Incomplete && parentQuestProgress == QuestProgress.Incomplete)
      {
        string effectPath;
        if (MapEffectPath != null && _mapEffect == null)
        {
          effectPath = EligibleFactions.Contains(GetLocalPlayer()) is true ? MapEffectPath : "";
          _mapEffect = AddSpecialEffect(effectPath, Position.X, Position.Y);
          BlzSetSpecialEffectColorByPlayer(_mapEffect, EligibleFactions.First().Player);
          BlzSetSpecialEffectHeight(_mapEffect, 100 + Environment.GetPositionZ(Position));
        }

        if (OverheadEffectPath != null && _overheadEffect == null && TargetWidget != null)
        {
          effectPath = EligibleFactions.Contains(GetLocalPlayer()) is true ? OverheadEffectPath : "";
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