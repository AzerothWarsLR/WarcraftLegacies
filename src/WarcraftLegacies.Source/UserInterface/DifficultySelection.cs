using System;
using MacroTools.Hints;
using MacroTools.Localization;
using MacroTools.UserInterface.Frames;
using MacroTools.UserInterface.Voting;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.UserInterface;

/// <summary>
/// The winner of the Difficulty vote in <see cref="DifficultySelection"/>.
/// </summary>
public enum Difficulty
{
  Normal,
  Hard,
  Custom
}

/// <summary>
/// Shown right after the game mode is chosen: lets players vote for a difficulty (Normal/Hard/Custom) and, if
/// the winning mode doesn't require it, separately for diplomacy rules (Open/Closed).
/// </summary>
public static class DifficultySelection
{
  private const float ButtonWidth = 0.16f;
  private const float ButtonHeight = 0.04f;
  private const float ButtonSpacing = 0.012f;
  private const float GroupSpacing = 0.015f;
  private const float Margin = 0.03f;
  private const float LabelHeight = 0.025f;

  /// <summary>
  /// Builds the voting UI and shows it immediately, giving players <paramref name="voteLength"/> seconds to
  /// vote. If <paramref name="forceOpenDiplomacy"/> is true (the winning game mode assigns fixed teams itself,
  /// making a Closed vote meaningless - see <see cref="MacroTools.GameModes.IGameMode.ForcesOpenDiplomacy"/>),
  /// Diplomacy is shown as a plain "Open" label instead of a vote. Calls <paramref name="onConcluded"/> once
  /// concluded, passing which <see cref="Difficulty"/> won - the caller decides what that means (e.g. whether
  /// to show the Custom Options page next, or apply Hard mode's effects).
  /// </summary>
  public static void Setup(float voteLength, bool forceOpenDiplomacy, Action<Difficulty> onConcluded)
  {
    var root = new Frame("ArtifactMenuBackdrop", originframetype.GameUI.GetOriginFrame(0), 0);
    root.SetAbsPoint(framepointtype.Center, 0.4f, 0.35f);

    var difficulty = Difficulty.Normal;
    var difficultyOptions = new[]
    {
      new VoteOption
      {
        Name = Loc.Get("Normal"),
        Description = Loc.Get("The standard experience - build your faction from the ground up."),
        OnChosen = () => difficulty = Difficulty.Normal
      },
      new VoteOption
      {
        Name = Loc.Get("Hard"),
        Description = Loc.Get("Skip the early game - Capitals and most heroes are unlocked from the start, with some early quests already completed."),
        OnChosen = () => difficulty = Difficulty.Hard
      },
      new VoteOption
      {
        Name = Loc.Get("Custom"),
        Description = Loc.Get("Choose your own settings to customise the game."),
        OnChosen = () => difficulty = Difficulty.Custom
      }
    };

    var contentY = -Margin - VotePageTitle.Height - VotePageTitle.Gap;
    var difficultyGroup = new VoteGroup(root, groupId: 0, Loc.Get("Difficulty"), difficultyOptions, Margin,
      contentY, ButtonWidth, ButtonHeight, ButtonSpacing);

    var diplomacyY = contentY - difficultyGroup.Height - GroupSpacing;
    VoteGroup? diplomacyGroup = null;
    float diplomacySectionHeight;
    float diplomacySectionWidth;

    if (forceOpenDiplomacy)
    {
      var label = new TextFrame("ArtifactMenuTitle", root, 0)
      {
        Width = difficultyGroup.Width,
        Height = LabelHeight,
        Text = Loc.Format("{category}: {value}", ("{category}", Loc.Get("Diplomacy")), ("{value}", Loc.Get("Open")))
      };
      label.SetPoint(framepointtype.Center, root, framepointtype.TopLeft,
        Margin + difficultyGroup.Width / 2, diplomacyY - LabelHeight / 2);
      label.CenterText();
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

      // Diplomacy has fewer options than Difficulty, so it's narrower - centered under Difficulty's row rather
      // than sharing its left edge, or it'd hug the left side of the panel instead of looking like part of the
      // same centered layout.
      var diplomacyWidth = diplomacyOptions.Length * ButtonWidth + (diplomacyOptions.Length - 1) * ButtonSpacing;
      var diplomacyX = Margin + (difficultyGroup.Width - diplomacyWidth) / 2;

      diplomacyGroup = new VoteGroup(root, groupId: 1, Loc.Get("Diplomacy"), diplomacyOptions, diplomacyX,
        diplomacyY, ButtonWidth, ButtonHeight, ButtonSpacing);
      diplomacySectionHeight = diplomacyGroup.Height;
      diplomacySectionWidth = diplomacyGroup.Width;
    }

    root.Width = Math.Max(difficultyGroup.Width, diplomacySectionWidth) + Margin * 2;
    root.Height = VotePageTitle.Height + VotePageTitle.Gap + difficultyGroup.Height + GroupSpacing +
                  diplomacySectionHeight + Margin * 2;

    VotePageTitle.Add(root, Loc.Get("Difficulty & Diplomacy"), root.Width, Margin);

    var groups = forceOpenDiplomacy
      ? new[] { difficultyGroup }
      : new[] { difficultyGroup, diplomacyGroup! };

    VotePageTimer.Start(voteLength, groups, () =>
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
      onConcluded(difficulty);
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
