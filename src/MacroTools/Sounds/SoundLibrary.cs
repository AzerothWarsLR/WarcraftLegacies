namespace MacroTools.Sounds;

public static class SoundLibrary
{
  public static sound Rescue { get; private set; }

  public static sound Hint { get; private set; }

  public static sound Completed { get; private set; }

  public static sound Failed { get; private set; }

  public static sound Warning { get; private set; }

  public static sound Discovered { get; private set; }

  public static void Setup()
  {
    Rescue = sound.CreateFromLabel("Rescue", false, false, false, 10000, 10000);
    Hint = sound.CreateFromLabel("Hint", false, false, false, 10000, 10000);
    Completed = sound.CreateFromLabel("QuestCompleted", false, false, false, 10000, 10000);
    Failed = sound.CreateFromLabel("QuestFailed", false, false, false, 10000, 10000);
    Warning = sound.CreateFromLabel("Warning", false, false, false, 10000, 10000);
    Discovered = sound.CreateFromLabel("QuestNew", false, false, false, 10000, 10000);
  }
}
