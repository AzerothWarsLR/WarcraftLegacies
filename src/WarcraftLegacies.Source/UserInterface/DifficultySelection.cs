using System;
using MacroTools.Hints;
using MacroTools.Localization;
using MacroTools.UserInterface.Frames;
using MacroTools.UserInterface.Voting;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.UserInterface;

/// <summary>
/// Shown right after the game mode is chosen: lets players vote for a difficulty (Normal/Hard/Custom) and, if
/// the winning mode doesn't require it, separately for diplomacy rules (Open/Closed).
/// </summary>
public static class DifficultySelection
{
  private const float ButtonWidth = 0.08f;
  private const float ButtonHeight = 0.035f;
  private const float ButtonSpacing = 0.012f;
  private const float GroupSpacing = 0.015f;
  private const float Margin = 0.03f;
  private const float LabelHeight = 0.025f;

  /// <summary>
  /// Builds the voting UI and shows it immediately, giving players <paramref name="voteLength"/> seconds to
  /// vote. If <paramref name="forceOpenDiplomacy"/> is true (the winning game mode assigns fixed teams itself,
  /// making a Closed vote meaningless - see <see cref="MacroTools.GameModes.IGameMode.ForcesOpenDiplomacy"/>),
  /// Diplomacy is shown as a plain "Open" label instead of a vote. Calls <paramref name="onConcluded"/> once
  /// concluded, passing whether "Custom" won the difficulty vote - the caller decides what that means (e.g.
  /// whether to show the Custom Options page next).
  /// </summary>
  public static void Setup(float voteLength, bool forceOpenDiplomacy, Action<bool> onConcluded)
  {
    var root = new Frame("ArtifactMenuBackdrop", originframetype.GameUI.GetOriginFrame(0), 0);
    root.SetAbsPoint(framepointtype.Center, 0.4f, 0.35f);

    var customChosen = false;
    var difficultyOptions = new[]
    {
      new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => { } },
      new VoteOption { Name = Loc.Get("Hard"), OnChosen = () => { } },
      new VoteOption { Name = Loc.Get("Custom"), OnChosen = () => customChosen = true }
    };

    var difficultyGroup = new VoteGroup(root, groupId: 0, Loc.Get("Difficulty"), difficultyOptions, Margin,
      -Margin, ButtonWidth, ButtonHeight, ButtonSpacing);

    var diplomacyY = -Margin - difficultyGroup.Height - GroupSpacing;
    VoteGroup? diplomacyGroup = null;
    float diplomacySectionHeight;
    float diplomacySectionWidth;

    if (forceOpenDiplomacy)
    {
      var label = new TextFrame("ArtifactMenuTitle", root, 0)
      {
        Text = Loc.Format("{category}: {value}", ("{category}", Loc.Get("Diplomacy")), ("{value}", Loc.Get("Open")))
      };
      label.SetPoint(framepointtype.TopLeft, root, framepointtype.TopLeft, Margin, diplomacyY);
      root.AddFrame(label);

      diplomacySectionHeight = LabelHeight;
      diplomacySectionWidth = difficultyGroup.Width;
    }
    else
    {
      var diplomacyOptions = new[]
      {
        new VoteOption { Name = Loc.Get("Open"), OnChosen = SetupOpenDiplomacy },
        new VoteOption { Name = Loc.Get("Closed"), OnChosen = SetupClosedDiplomacy }
      };

      diplomacyGroup = new VoteGroup(root, groupId: 1, Loc.Get("Diplomacy"), diplomacyOptions, Margin, diplomacyY,
        ButtonWidth, ButtonHeight, ButtonSpacing);
      diplomacySectionHeight = diplomacyGroup.Height;
      diplomacySectionWidth = diplomacyGroup.Width;
    }

    root.Width = Math.Max(difficultyGroup.Width, diplomacySectionWidth) + Margin * 2;
    root.Height = difficultyGroup.Height + GroupSpacing + diplomacySectionHeight + Margin * 2;

    timer.Create().Start(voteLength, false, () =>
    {
      difficultyGroup.Conclude();

      var diplomacyResultName = Loc.Get("Open");
      if (forceOpenDiplomacy)
      {
        SetupOpenDiplomacy();
      }
      else
      {
        diplomacyGroup!.Conclude();
        diplomacyResultName = diplomacyGroup.Winner!.Name;
      }

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        player.DisplayTextTo(Loc.Format("Difficulty: {value}", ("{value}", difficultyGroup.Winner!.Name)));
        player.DisplayTextTo(Loc.Format("Diplomacy: {value}", ("{value}", diplomacyResultName)));
      }

      root.Visible = false;
      onConcluded(customChosen);
    });
  }

  private static void SetupOpenDiplomacy()
  {
    Hint.Register(new Hint(() => Loc.Get("You can change alliances by using the commands -invite, -uninvite, -join, and -unally.")));
    InviteCommand.Setup();
    JoinCommand.Setup();
    UnallyCommand.Setup();
    UninviteCommand.Setup();
  }

  private static void SetupClosedDiplomacy()
  {
    Hint.Register(new Hint(() => Loc.Get("You can leave your current alliances by typing -unally, but you won't be able to join a new one.")));
    UnallyCommand.Setup();
  }
}
