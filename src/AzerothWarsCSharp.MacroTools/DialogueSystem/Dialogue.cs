using System;
using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.DialogueSystem
{
  /// <summary>
  /// Can play a piece of dialogue from the Warcraft 3 campaign.
  /// </summary>
  public sealed class Dialogue
  {
    private readonly IEnumerable<Faction>? _audience;
    private readonly string _caption;
    private readonly SoundWrapper _sound;
    private readonly string _speaker;

    public Dialogue(IEnumerable<Objective> objectives, string soundFile, string caption, string speaker,
      IEnumerable<Faction>? audience = null)
    {
      _caption = caption;
      _speaker = speaker;
      _audience = audience;
      Objectives = objectives.ToList();
      _sound = new SoundWrapper(soundFile, soundEax: SoundEax.HeroAcks);
    }

    public List<Objective> Objectives { get; }

    /// <summary>
    /// Fired when the <see cref="Dialogue"/> plays.
    /// </summary>
    public event EventHandler<Dialogue>? Completed;

    internal void OnObjectiveCompleted(object? sender, Objective objective)
    {
      if (_audience != null)
      {
        foreach (var faction in _audience)
        {
          var player = faction.Player;
          if (player != null)
          {
            DisplayTextToPlayer(player, 0, 0, $"|cffffcc00{_speaker}:|r {_caption}");
            _sound.Play(player, true);
          }
        }
      }
      else
      {
        _sound.Play(true);
      }

      Completed?.Invoke(this, this);
    }
  }
}