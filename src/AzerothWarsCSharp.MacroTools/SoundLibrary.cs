namespace AzerothWarsCSharp.MacroTools
{
  public static class SoundLibrary
  {
    private static sound? _rescue;
    public static sound Rescue => _rescue ??= CreateSoundFromLabel("Rescue", false, false, false, 10000, 10000);
    
    private static sound? _hint;
    public static sound Hint => _hint ??= CreateSoundFromLabel("Hint", false, false, false, 10000, 10000);
    
    private static sound? _completed;
    public static sound Completed => _completed ??= CreateSoundFromLabel("QuestCompleted", false, false, false, 10000, 10000);

    private static sound? _failed;
    public static sound Failed => _failed ??= CreateSoundFromLabel("QuestFailed", false, false, false, 10000, 10000);
    
    private static sound? _warning;
    public static sound Warning => _warning ??= CreateSoundFromLabel("Warning", false, false, false, 10000, 10000);
    
    private static sound? _discovered;
    public static sound Discovered => _discovered ??= CreateSoundFromLabel("QuestNew", false, false, false, 10000, 10000);
  }
}