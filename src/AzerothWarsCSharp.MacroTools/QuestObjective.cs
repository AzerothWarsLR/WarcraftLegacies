using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public abstract class QuestObjective
  {
    private minimapicon? _minimapIcon;
    private effect? _overheadEffect;

    private QuestProgress _progress;

    /// <summary>
    ///   A description of how to complete the Objective.
    /// </summary>
    public string Description { get; protected init; } = "DefaultObjectiveText";

    /// <summary>
    ///   The X location of this Objective in the world.
    /// </summary>
    protected float X { get; init; }

    /// <summary>
    ///   The Y location of this Objective in the world.
    /// </summary>
    protected float Y { get; init; }

    /// <summary>
    ///   Whether or not this Objective is situated somewhere specific in the world.
    /// </summary>
    protected bool HasLocation { get; init; }

    /// <summary>
    ///   The target of this Objective.
    ///   Objectives with targets display an exclamation mark or question mark above the target's head.
    /// </summary>
    public widget? Target { get; protected init; }

    internal Quest? ParentQuest { get; set; }

    protected Faction? ParentFaction => ParentQuest?.ParentFaction;

    public QuestProgress Progress
    {
      protected set
      {
        _progress = value;
        switch (value)
        {
          case QuestProgress.Incomplete:
            Render();
            break;
          case QuestProgress.Failed:
            Unrender();
            break;
          case QuestProgress.Complete:
            Unrender();
            break;
          case QuestProgress.Undiscovered:
            Unrender();
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }

        ProgressChanged?.Invoke(this, new QuestObjectiveEventArgs(this));
      }
      get => _progress;
    }

    public event EventHandler<QuestObjectiveEventArgs>? ProgressChanged;

    internal void Unrender()
    {
      if (_minimapIcon != null)
      {
        DestroyMinimapIcon(_minimapIcon);
        _minimapIcon = null;
      }

      if (_overheadEffect != null)
      {
        DestroyEffect(_overheadEffect);
        _overheadEffect = null;
      }
    }

    /// <summary>
    ///   Displays the Objective for a particular player.
    ///   Displayed Objectives might have a map marker, an exclamation mark above a target's head, or nothing.
    /// </summary>
    internal void Render()
    {
      var player = ParentQuest?.ParentFaction?.Player;
      //Render the map marker.
      if (player != null && ParentQuest != null && GetLocalPlayer() == player && Progress == QuestProgress.Incomplete &&
          ParentQuest.Progress == QuestProgress.Incomplete && HasLocation)
      {
        _minimapIcon ??= CreateMinimapIcon(X, Y, 255, 255, 0, SkinManagerGetLocalPath("MinimapQuestObjectivePrimary"),
          FOG_OF_WAR_MASKED);
        SetMinimapIconVisible(_minimapIcon, true);
      }

      //Render an effect above the target's head.
      var overheadEffectPath = "";
      if (Target != null && _overheadEffect == null)
      {
        if (GetLocalPlayer() == player) overheadEffectPath = @"Abilities\Spells\Other\TalkToMe\TalkToMe";
        _overheadEffect = AddSpecialEffectTarget(overheadEffectPath, Target, "overhead");
      }
    }

    ~QuestObjective()
    {
      DestroyMinimapIcon(_minimapIcon);
      DestroyEffect(_overheadEffect);
    }
  }
}