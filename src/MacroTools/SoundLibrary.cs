using static War3Api.Common;

namespace MacroTools
{
  public static class SoundLibrary
  {
    public static sound Rescue { get; } = CreateSoundFromLabel("Rescue", false, false, false, 10000, 10000);

    public static sound Hint { get; } = CreateSoundFromLabel("Hint", false, false, false, 10000, 10000);

    public static sound Completed { get; } = CreateSoundFromLabel("QuestCompleted", false, false, false, 10000, 10000);

    public static sound Failed { get; } = CreateSoundFromLabel("QuestFailed", false, false, false, 10000, 10000);

    public static sound Warning { get; } = CreateSoundFromLabel("Warning", false, false, false, 10000, 10000);

    public static sound Discovered { get; } = CreateSoundFromLabel("QuestNew", false, false, false, 10000, 10000);
  }
}