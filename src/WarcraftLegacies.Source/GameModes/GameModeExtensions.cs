using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameModes;
using MacroTools.Hints;
using WarcraftLegacies.Source.Commands;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.GameLogic.GameEnd;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.GameModes;

public static class GameModeExtensions
{
  public static IGameMode SetupGreatWarTeams(this IGameMode gameMode)
  {
    FactionManager.SharedVisionMode = TeamSharedVisionMode.TraditionalAlliesOnly;
    player.Create(6).GetPlayerData().SetTeam(TeamSetup.Legion);
    player.Create(15).GetPlayerData().SetTeam(TeamSetup.Legion);
    player.Create(9).GetPlayerData().SetTeam(TeamSetup.Legion);
    player.Create(2).GetPlayerData().SetTeam(TeamSetup.Legion);
    player.Create(7).GetPlayerData().SetTeam(TeamSetup.Legion);
    player.Create(12).GetPlayerData().SetTeam(TeamSetup.Legion);
    player.Create(16).GetPlayerData().SetTeam(TeamSetup.Legion);
    player.Create(8).GetPlayerData().SetTeam(TeamSetup.Legion);

    player.Create(3).GetPlayerData().SetTeam(TeamSetup.Alliance);
    player.Create(23).GetPlayerData().SetTeam(TeamSetup.Alliance);
    player.Create(1).GetPlayerData().SetTeam(TeamSetup.Alliance);
    player.Create(4).GetPlayerData().SetTeam(TeamSetup.Alliance);
    player.Create(22).GetPlayerData().SetTeam(TeamSetup.Alliance);
    player.Create(0).GetPlayerData().SetTeam(TeamSetup.Alliance);
    player.Create(11).GetPlayerData().SetTeam(TeamSetup.Alliance);
    player.Create(18).GetPlayerData().SetTeam(TeamSetup.Alliance);

    SharedQuestRepository.RegisterQuest(new QuestSharedVision());
    return gameMode;
  }

  public static IGameMode SetupAllianceCommands(this IGameMode gameMode)
  {
    Hint.Register(new Hint("You can change alliances by using the commands -invite, -uninvite, -join, and -unally."));
    InviteCommand.Setup();
    JoinCommand.Setup();
    UnallyCommand.Setup();
    UninviteCommand.Setup();
    return gameMode;
  }

  public static IGameMode SetupControlPointVictory(this IGameMode gameMode)
  {
    ControlPointVictory.Setup();
    Hint.Register(new Hint($"Win the game by capturing {ControlPointVictory.CpsVictory} Control Points."));
    return gameMode;
  }

  public static IGameMode SetupUnallyCommand(this IGameMode gameMode)
  {
    Hint.Register(new Hint("You can leave your current alliances by typing -unally, but you won't be able to join a new one."));
    UnallyCommand.Setup();
    return gameMode;
  }
}
