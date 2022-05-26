using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Wrappers
{
  public sealed class SoundWrapper
  {
    private readonly sound _sound;
    private bool _disposed;

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

    public SoundWrapper(string fileName, bool looping = false, bool is3D = false, bool stopWhenOutOfRange = true,
      int fadeInRate = 0, int fadeOutRate = 0, SoundEax soundEax = SoundEax.Default)
    {
      _sound = CreateSound(fileName, looping, is3D, stopWhenOutOfRange, fadeInRate, fadeOutRate,
        soundEax.GetStringEquivalent());
      SetSoundVolume(_sound, 100);
    }
  }
}