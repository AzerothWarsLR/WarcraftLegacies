using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.GameModes;
using MacroTools.HintSystem;
using WarcraftLegacies.Source.Commands;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.GameModes
{
  public sealed class GreatWar : IGameMode
  {
    /// <inheritdoc />
    public string Name => "Great War (9v7)";

    /// <inheritdoc />
    public void OnChoose()
    {
      FactionManager.SharedVisionMode = TeamSharedVisionMode.CloseAlliesOnly;
      
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        DisplayTextToPlayer(player, 0, 0, "The Great War begins!");
      
      Player(3).SetTeam(TeamSetup.Legion);
      Player(23).SetTeam(TeamSetup.Legion);

      Player(6).SetTeam(TeamSetup.Legion);
      Player(15).SetTeam(TeamSetup.Legion);

      Player(0).SetTeam(TeamSetup.Legion);
      Player(5).SetTeam(TeamSetup.Legion);
      Player(8).SetTeam(TeamSetup.Legion);

      Player(9).SetTeam(TeamSetup.Alliance);
      Player(2).SetTeam(TeamSetup.Alliance);
      Player(7).SetTeam(TeamSetup.Alliance);

      Player(4).SetTeam(TeamSetup.Alliance);
      Player(1).SetTeam(TeamSetup.Alliance);
      Player(22).SetTeam(TeamSetup.Alliance);

      Player(11).SetTeam(TeamSetup.Alliance);
      Player(13).SetTeam(TeamSetup.Alliance);
      Player(18).SetTeam(TeamSetup.Alliance);
      
      SetupAllianceCommands();
      SharedQuestRepository.RegisterQuest(new QuestSharedVision());
    }

    private void SetupAllianceCommands()
    {
      Hint.Register(new Hint("You can change alliances by using the commands -invite, -uninvite, -join, and -unally."));
      Hint.Register(new Hint($"In {Name} mode, you start with shared vision with your closest allies. Later in the game, you gain shared vision with all your allies."));
      InviteCommand.Setup();
      JoinCommand.Setup();
      UnallyCommand.Setup();
      UninviteCommand.Setup();
    }
  }
}