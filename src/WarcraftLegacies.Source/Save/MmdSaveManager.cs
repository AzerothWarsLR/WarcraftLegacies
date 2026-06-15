using System.Collections.Generic;
using WCSharp.SaveLoad;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Save;

public static class MmdSaveManager
{
  private static SaveSystem<MmdSaveData>? _system;
  private static readonly Dictionary<player, MmdSaveData> Saves = new();
  private static readonly Dictionary<int, player> LoadingPlayers = new();

  public static void Initialize()
  {
    _system = new SaveSystem<MmdSaveData>(new SaveSystemOptions
    {
      Hash1 = 912345,
      Hash2 = 551122,
      Salt = "MMD_Save_Salt_123",
      BindSavesToPlayerName = true,
      SaveFolder = "WarcraftLegacies"
    });

    _system.OnSaveLoaded += OnLoaded;

    foreach (var p in Util.EnumeratePlayers())
    {
      int id = p.Id;
      LoadingPlayers[id] = p;
      _system.Load(p, 0);
    }
  }

  private static void OnLoaded(MmdSaveData save, LoadResult result)
  {
    var p = LoadingPlayers[save.PlayerId];
    Saves[p] = save;
  }

  public static MmdSaveData Get(player p)
  {
    if (!Saves.TryGetValue(p, out var save))
    {
      save = new MmdSaveData { PlayerId = p.Id };
      Saves[p] = save;
    }

    return save;
  }

  public static void Save(MmdSaveData save)
  {
    _system?.Save(save);
  }
}
