using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Wrappers
{
  public sealed class SoundWrapper
  {
    private readonly sound _sound;
    private bool _disposed;

    public SoundWrapper(string fileName, bool looping = false, bool is3D = false, bool stopWhenOutOfRange = true,
      int fadeInRate = 0, int fadeOutRate = 0, SoundEax soundEax = SoundEax.Default)
    {
      _sound = CreateSound(fileName, looping, is3D, stopWhenOutOfRange, fadeInRate, fadeOutRate,
        soundEax.GetStringEquivalent());
      SetSoundVolume(_sound, 100);
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

      StartSound(_sound);

      if (disposeAfter)
      {
        KillSoundWhenDone(_sound);
        _disposed = true;
      }
    }

    /// <summary>
    /// Plays the sound for a particular player.
    /// </summary>
    /// <param name="audience">Whom to play the sound for.</param>
    /// <param name="disposeAfter">Whether or not to dispose of the sound after it's finished playing.</param>
    /// <exception cref="ObjectDisposedException">Thrown if the sound is already disposed.</exception>
    public void Play(player audience, bool disposeAfter)
    {
      if (_disposed)
      {
        throw new ObjectDisposedException(nameof(SoundWrapper));
      }

      if (GetLocalPlayer() == audience)
      {
        StartSound(_sound);
      }

      if (disposeAfter)
      {
        KillSoundWhenDone(_sound);
        _disposed = true;
      }
    }
  }
}