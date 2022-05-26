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

      if (disposeAfter)
      {
        KillSoundWhenDone(_sound);
        _disposed = true;
      }

      StartSound(_sound);
    }

    public SoundWrapper(string fileName, bool looping = false, bool is3D = false, bool stopWhenOutOfRange = false,
      int fadeInRate = 1, int fadeOutRate = 1, SoundEax soundEax = SoundEax.Default)
    {
      _sound = CreateSoundFilenameWithLabel(fileName, looping, is3D, stopWhenOutOfRange, fadeInRate, fadeOutRate,
        soundEax.GetStringEquivalent());
      SetSoundDuration(_sound, GetSoundFileDuration(fileName));
    }
  }
}