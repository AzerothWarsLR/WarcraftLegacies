using System;
using System.Collections.Generic;
using System.Linq;
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
    private readonly string _caption;
    private readonly SoundWrapper _sound;
    private readonly string _speaker;

    public Dialogue(IEnumerable<Objective> objectives, string soundFile, string caption, string speaker)
    {
      _caption = caption;
      _speaker = speaker;
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
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, $"|cffffcc00{_speaker}:|r {_caption}");
      _sound.Play(true);
      Completed?.Invoke(this, this);
    }
  }
}