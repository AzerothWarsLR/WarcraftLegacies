

namespace MacroTools.Extensions
{
  public static class SoundExtensions
  {
    public static sound SetParamsFromLabel(this sound whichSound, string label)
    {
      SetSoundParamsFromLabel(whichSound, label);
      return whichSound;
    }

    public static sound SetDuration(this sound whichSound, int duration)
    {
      SetSoundDuration(whichSound, duration);
      return whichSound;
    }

    public static sound SetChannel(this sound whichSound, int channel)
    {
      SetSoundChannel(whichSound, channel);
      return whichSound;
    }

    public static sound SetVolume(this sound whichSound, int volume)
    {
      SetSoundVolume(whichSound, volume);
      return whichSound;
    }

    public static sound SetDistances(this sound whichSound, float minDistance, float maxDistance)
    {
      SetSoundDistances(whichSound, minDistance, maxDistance);
      return whichSound;
    }

    public static sound SetDistanceCutoff(this sound whichSound, float cutoff)
    {
      SetSoundDistanceCutoff(whichSound, cutoff);
      return whichSound;
    }
  }
}