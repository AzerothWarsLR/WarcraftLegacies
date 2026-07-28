using System;
using MacroTools.ControlPoints;
using MacroTools.Localization;
using MacroTools.UserInterface.Frames;
using MacroTools.UserInterface.Voting;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.UserInterface;

/// <summary>
/// A vote page shown after the game mode is chosen, letting players tune a handful of gameplay knobs. New
/// categories are added by appending to <see cref="BuildCategories"/> - the page lays itself out around
/// however many there are.
/// </summary>
public static class CustomOptionsSelection
{
  private const float ButtonWidth = 0.08f;
  private const float ButtonHeight = 0.035f;
  private const float ButtonSpacing = 0.012f;
  private const float GroupSpacing = 0.015f;
  private const float Margin = 0.03f;

  // Guards against the panel being narrower than a category title needs, since title width isn't measured -
  // only the (now much narrower) button row is.
  private const float MinContentWidth = 0.3f;

  /// <summary>
  /// Builds the Custom Options voting UI and shows it immediately, giving players <paramref name="voteLength"/>
  /// seconds to vote. Calls <paramref name="onConcluded"/> once every category has a winner and its effect has
  /// been applied. Does not pause the game - that's the caller's job.
  /// </summary>
  public static void Setup(float voteLength, Action onConcluded)
  {
    var categories = BuildCategories();

    var root = new Frame("ArtifactMenuBackdrop", originframetype.GameUI.GetOriginFrame(0), 0);
    root.SetAbsPoint(framepointtype.Center, 0.4f, 0.35f);

    var groups = new VoteGroup[categories.Length];
    var y = -Margin;
    var contentWidth = MinContentWidth;
    for (var i = 0; i < categories.Length; i++)
    {
      var group = new VoteGroup(root, groupId: i + 1, Loc.Get(categories[i].Title), categories[i].Options,
        Margin, y, ButtonWidth, ButtonHeight, ButtonSpacing);
      groups[i] = group;
      y -= group.Height + GroupSpacing;
      contentWidth = Math.Max(contentWidth, group.Width);
    }

    root.Width = contentWidth + Margin * 2;
    root.Height = -y - GroupSpacing + Margin;

    timer.Create().Start(voteLength, false, () =>
    {
      for (var i = 0; i < groups.Length; i++)
      {
        groups[i].Conclude();
      }

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        for (var i = 0; i < groups.Length; i++)
        {
          player.DisplayTextTo(Loc.Format("{category}: {value}",
            ("{category}", Loc.Get(categories[i].Title)), ("{value}", groups[i].Winner!.Name)));
        }
      }

      root.Visible = false;
      onConcluded();
    });
  }

  private static (string Title, VoteOption[] Options)[] BuildCategories()
  {
    return new (string, VoteOption[])[]
    {
      ("Control Point Gold Rate", new[]
      {
        new VoteOption { Name = Loc.Get("Low"), OnChosen = () => ControlPointManager.IncomeMultiplier = 0.75f },
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => ControlPointManager.IncomeMultiplier = 1f },
        new VoteOption { Name = Loc.Get("High"), OnChosen = () => ControlPointManager.IncomeMultiplier = 1.25f }
      }),
      ("Hero Damage Taken", new[]
      {
        new VoteOption { Name = Loc.Get("Low"), OnChosen = () => HeroDamageTakenSetting.Multiplier = 0.75f },
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => HeroDamageTakenSetting.Multiplier = 1f },
        new VoteOption { Name = Loc.Get("High"), OnChosen = () => HeroDamageTakenSetting.Multiplier = 1.25f }
      }),
      ("Hero Revival Time", new[]
      {
        new VoteOption { Name = Loc.Get("Fast"), OnChosen = () => SetAllPlayersReviveHandicap(0.75f) },
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => SetAllPlayersReviveHandicap(1f) },
        new VoteOption { Name = Loc.Get("Slow"), OnChosen = () => SetAllPlayersReviveHandicap(1.25f) }
      }),
      ("Teleport Scroll Options", new[]
      {
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = TeleportScrollSetting.SeedNormalScrolls },
        new VoteOption { Name = Loc.Get("Global"), OnChosen = TeleportScrollSetting.EnableGlobalScrolls }
      })
    };
  }

  private static void SetAllPlayersReviveHandicap(float handicap)
  {
    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      SetPlayerHandicapReviveTime(player, handicap);
    }
  }
}
