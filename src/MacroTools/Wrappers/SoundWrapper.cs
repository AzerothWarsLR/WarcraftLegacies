using System;
using static War3Api.Common;

namespace MacroTools.Wrappers
{
  public sealed class SoundWrapper
  {
    public delegate bool PlayCondition(player whichPlayer);

    /// <summary>
    /// The internal Warcraft 3 sound that this wrapper wraps.
    /// </summary>
    public sound Sound { get; }
    
    private bool _disposed;

    /// <summary>Initializes a new instance of the <see cref="SoundWrapper"/> class.</summary>
    public SoundWrapper(string fileName, bool looping = false, bool is3D = false, bool stopWhenOutOfRange = true,
      int fadeInRate = 0, int fadeOutRate = 0, SoundEax soundEax = SoundEax.Default)
    {
      Sound = CreateSound(fileName, looping, is3D, stopWhenOutOfRange, fadeInRate, fadeOutRate,
        soundEax.GetStringEquivalent());
      SetSoundVolume(Sound, 100);
    }

    /// <summary>
    /// Plays the sound for all players.
    /// </summary>
    /// <param name="disposeAfter">Whether or not to dispose of the sound after it's finished playing.</param>
    /// <exception cref="ObjectDisposedException">Thrown if the sound is already disposed.</exception>
    public void Play(bool disposeAfter)
    {
      if (_disposed)
      {
        throw new ObjectDisposedException(nameof(SoundWrapper));
      }

      StartSound(Sound);

      if (disposeAfter)
      {
        KillSoundWhenDone(Sound);
        _disposed = true;
      }
    }

    /// <summary>
    /// Plays the sound for players meeting a condition.
    /// </summary>
    /// <param name="playCondition">The sound only plays if <see cref="GetLocalPlayer"/> meets this condition.</param>
    /// <param name="disposeAfter">Whether or not to dispose of the sound after it's finished playing.</param>
    /// <exception cref="ObjectDisposedException">Thrown if the sound is already disposed.</exception>
    public void Play(PlayCondition playCondition, bool disposeAfter)
    {
      if (_disposed)
      {
        throw new ObjectDisposedException(nameof(SoundWrapper));
      }

      if (playCondition(GetLocalPlayer()))
      {
        StartSound(Sound);
      }

      if (disposeAfter)
      {
        KillSoundWhenDone(Sound);
        _disposed = true;
      }
    }
  }
}