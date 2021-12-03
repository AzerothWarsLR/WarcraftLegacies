using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public abstract class QuestObjective
  {
    private minimapicon? _minimapIcon;
    
    public event EventHandler<QuestObjectiveEventArgs>? ProgressChanged;
    
    public string Description { get; protected init; } = "DefaultObjectiveText";
    
    public float X { get; protected init; }
    
    public float Y { get; protected init; }
    
    public bool HasLocation { get; protected init; }
    
    internal Quest? ParentQuest { get; set; }
    
    protected Faction? ParentFaction => ParentQuest?.ParentFaction;

    private QuestProgress _progress;

    internal void Render(player player)
    {
      if (ParentQuest == null)
      {
        throw new NullReferenceException(nameof(ParentQuest));
      }
      if (GetLocalPlayer() == player && Progress == QuestProgress.Incomplete && ParentQuest.Progress == QuestProgress.Incomplete && HasLocation)
      {
        _minimapIcon ??= CreateMinimapIcon(X, Y, 255, 255, 0, SkinManagerGetLocalPath("MinimapQuestObjectivePrimary"), FOG_OF_WAR_MASKED);
        SetMinimapIconVisible(_minimapIcon, true);
      }
    }
    
    public QuestProgress Progress
    {
      protected set
      {
        _progress = value;
        ProgressChanged?.Invoke(this, new QuestObjectiveEventArgs(this));
        Console.WriteLine("Quest objective changed progress");
      }
      get => _progress;
    }

    ~QuestObjective()
    {
      DestroyMinimapIcon(_minimapIcon);
    }
  }
}