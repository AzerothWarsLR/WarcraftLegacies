using System;
using System.Collections.Generic;
using System.Linq;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.DialogueSystem
{
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

    internal void OnComplete(object? sender, Objective objective)
    {
      Console.WriteLine("a");
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, $"|cffffcc00{_speaker}:|r {_caption}");
      _sound.Play(true);
    }
  }
}