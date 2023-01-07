using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using static War3Api.Common;

namespace MacroTools.DialogueSystem
{
  /// <summary>
  /// Can play a piece of dialogue from the Warcraft 3 campaign.
  /// </summary>
  public sealed class Dialogue
  {
    /// <summary>
    /// Fired when the <see cref="Dialogue"/> plays.
    /// </summary>
    public event EventHandler<Dialogue>? Completed;
    
    internal List<Objective> Objectives { get; }
    
    private readonly IEnumerable<Faction>? _audience;
    private readonly string _caption;
    private readonly SoundWrapper _sound;
    private readonly string _speaker;
    private bool _completed;

    private QuestProgress Progress
    {
      set
      {
        switch (value)
        {
          case QuestProgress.Complete:
            if (_audience != null)
            {
              _sound.Play(x => _audience.Contains(x.GetFaction()), true);
              foreach (var faction in _audience)
              {
                var player = faction.Player;
                if (player != null) 
                  DisplayTextToPlayer(player, 0, 0, $"|cffffcc00{_speaker}:|r {_caption}");
              }
            }
            else
            {
              DisplayTextToPlayer(GetLocalPlayer(), 0, 0, $"|cffffcc00{_speaker}:|r {_caption}");
              _sound.Play(true);
            }

            _completed = true;
            Completed?.Invoke(this, this);
            break;
          case QuestProgress.Failed:
            _completed = true;
            Completed?.Invoke(this, this);
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
      }
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Dialogue"/> class.
    /// </summary>
    /// <param name="objectives">When these are completed, the dialogue plays.</param>
    /// <param name="soundFile">A path to the sound file which the dialogue will play.</param>
    /// <param name="caption">Gets displayed to the user when the dialogue is played.</param>
    /// <param name="speaker">The character that is saying the dialogue.</param>
    /// <param name="audience">A list of factions that can hear the dialogue being played.</param>
    public Dialogue(IEnumerable<Objective> objectives, string soundFile, string caption, string speaker,
      IEnumerable<Faction>? audience = null)
    {
      _caption = caption;
      _speaker = speaker;
      _audience = audience;
      Objectives = objectives.ToList();
      _sound = new SoundWrapper(soundFile, soundEax: SoundEax.HeroAcks);
    }

    internal void OnObjectiveCompleted(object? sender, Objective completedObjective)
    {
      if (_completed)
        return;

      var allComplete = true;
      var anyFailed = false;

      foreach (var objective in Objectives)
      {
        if (objective.Progress == QuestProgress.Complete) 
          continue;
        allComplete = false;
        if (objective.Progress == QuestProgress.Failed)
          anyFailed = true;
      }

      if (allComplete)
        Progress = QuestProgress.Complete;
      else if (anyFailed)
        Progress = QuestProgress.Failed;
    }
  }
}