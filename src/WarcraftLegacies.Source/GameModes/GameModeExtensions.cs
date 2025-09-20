using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.GameModes;
using MacroTools.HintSystem;
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
    Player(6).SetTeam(TeamSetup.Legion);
    Player(15).SetTeam(TeamSetup.Legion);
    Player(9).SetTeam(TeamSetup.Legion);
    Player(2).SetTeam(TeamSetup.Legion);
    Player(7).SetTeam(TeamSetup.Legion);
    Player(12).SetTeam(TeamSetup.Legion);
    Player(16).SetTeam(TeamSetup.Legion);
    Player(8).SetTeam(TeamSetup.Legion);

    Player(3).SetTeam(TeamSetup.Alliance);
    Player(23).SetTeam(TeamSetup.Alliance);
    Player(1).SetTeam(TeamSetup.Alliance);
    Player(4).SetTeam(TeamSetup.Alliance);
    Player(22).SetTeam(TeamSetup.Alliance);
    Player(0).SetTeam(TeamSetup.Alliance);
    Player(11).SetTeam(TeamSetup.Alliance);
    Player(18).SetTeam(TeamSetup.Alliance);


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
