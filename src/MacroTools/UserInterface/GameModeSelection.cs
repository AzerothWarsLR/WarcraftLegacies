using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.GameModes;
using MacroTools.Localization;
using MacroTools.UserInterface.Frames;
using MacroTools.UserInterface.Voting;

namespace MacroTools.UserInterface;

public static class GameModeSelection
{
  private const float ButtonWidth = 0.17f;
  private const float ButtonHeight = 0.055f;
  private const float ButtonSpacing = 0.02f;
  private const float Margin = 0.03f;

  public static void Setup(IEnumerable<IGameMode> gameModes, float voteLength, Action<IGameMode> onConcluded)
  {
    var gameModesArray = gameModes.ToArray();
    var options = gameModesArray.Select(gameMode => new VoteOption
    {
      Name = gameMode.Name,
      Description = gameMode.Description,
      VoteOffset = gameMode.VoteOffset,
      OnChosen = gameMode.OnChoose
    }).ToArray();

    var root = new Frame("ArtifactMenuBackdrop", originframetype.GameUI.GetOriginFrame(0), 0);
    root.SetAbsPoint(framepointtype.Center, 0.4f, 0.35f);

    var voteGroup = new VoteGroup(root, groupId: 0, Loc.Get("Game Mode"), options, Margin, -Margin,
      ButtonWidth, ButtonHeight, ButtonSpacing);

    root.Width = voteGroup.Width + Margin * 2;
    root.Height = voteGroup.Height + Margin * 2;

    VotePageTimer.Start(voteLength, new[] { voteGroup }, () =>
    {
      voteGroup.Conclude();

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        player.DisplayTextTo(Loc.Format("The {mode} game mode has been chosen.", ("{mode}", voteGroup.Winner!.Name)));
      }

      root.Visible = false;
      onConcluded(gameModesArray[Array.IndexOf(options, voteGroup.Winner)]);
    });
  }
}
