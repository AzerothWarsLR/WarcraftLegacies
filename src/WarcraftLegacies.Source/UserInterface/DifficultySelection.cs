using System;
using MacroTools.Hints;
using MacroTools.Localization;
using MacroTools.UserInterface.Frames;
using MacroTools.UserInterface.Voting;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.UserInterface;

public enum Difficulty
{
  Normal,
  Hard,
  Custom
}

public static class DifficultySelection
{
  private const float ButtonWidth = 0.16f;
  private const float ButtonHeight = 0.04f;
  private const float ButtonSpacing = 0.012f;
  private const float GroupSpacing = 0.015f;
  private const float Margin = 0.03f;
  private const float LabelHeight = 0.025f;

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
