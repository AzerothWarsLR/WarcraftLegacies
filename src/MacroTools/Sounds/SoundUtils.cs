namespace MacroTools.Sounds;

public static class SoundUtils
{
  /// <summary>Creates a sound using some sensible defaults.</summary>
  public static sound CreateNormalSound(string fileName, bool looping = false, bool is3D = false, bool stopWhenOutOfRange = true,
    int fadeInRate = 0, int fadeOutRate = 0, SoundEax soundEax = SoundEax.Default)
  {
    sound sound = sound.CreateFromFile(fileName, looping, is3D, stopWhenOutOfRange, fadeInRate, fadeOutRate, soundEax.GetStringEquivalent());
    sound.SetVolume(100);

    return sound;
  }
}
