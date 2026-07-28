using System;
using MacroTools.ControlPoints;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.UserInterface.Frames;
using MacroTools.UserInterface.Voting;
using WarcraftLegacies.Source.GameLogic;
using WCSharp.Shared.Data;

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
  private const int ColumnCount = 2;
  private const float ColumnSpacing = 0.05f;

  // Guards against a column being narrower than its longest category title needs, since title width isn't
  // measured - only the (usually much narrower) button row is.
  private const float MinColumnWidth = 0.3f;

  /// <summary>
  /// Builds the Custom Options voting UI and shows it immediately, giving players <paramref name="voteLength"/>
  /// seconds to vote. Categories are laid out into <see cref="ColumnCount"/> columns (filled top-to-bottom,
  /// then left-to-right) so the page stays short enough to fit on screen as more categories are added. Calls
  /// <paramref name="onConcluded"/> once every category has a winner and its effect has been applied. Does not
  /// pause the game - that's the caller's job.
  /// </summary>
  public static void Setup(float voteLength, Action onConcluded)
  {
    var categories = BuildCategories();
    var rowsPerColumn = (categories.Length + ColumnCount - 1) / ColumnCount;

    var root = new Frame("ArtifactMenuBackdrop", originframetype.GameUI.GetOriginFrame(0), 0);
    root.SetAbsPoint(framepointtype.Center, 0.4f, 0.35f);

    // First pass: figure out how wide each column needs to be, from the widest category assigned to it.
    var columnWidths = new float[ColumnCount];
    for (var i = 0; i < categories.Length; i++)
    {
      var column = i / rowsPerColumn;
      var optionCount = categories[i].Options.Length;
      var categoryWidth = optionCount * ButtonWidth + (optionCount - 1) * ButtonSpacing;
      columnWidths[column] = Math.Max(Math.Max(columnWidths[column], categoryWidth), MinColumnWidth);
    }

    var columnX = new float[ColumnCount];
    columnX[0] = Margin;
    for (var c = 1; c < ColumnCount; c++)
    {
      columnX[c] = columnX[c - 1] + columnWidths[c - 1] + ColumnSpacing;
    }

    // Second pass: actually build each category into its assigned column, tracking that column's running Y.
    var groups = new VoteGroup[categories.Length];
    var columnY = new float[ColumnCount];
    for (var c = 0; c < ColumnCount; c++)
    {
      columnY[c] = -Margin;
    }

    for (var i = 0; i < categories.Length; i++)
    {
      var column = i / rowsPerColumn;
      var group = new VoteGroup(root, groupId: i + 1, Loc.Get(categories[i].Title), categories[i].Options,
        columnX[column], columnY[column], ButtonWidth, ButtonHeight, ButtonSpacing);
      groups[i] = group;
      columnY[column] -= group.Height + GroupSpacing;
    }

    var contentHeight = 0f;
    for (var c = 0; c < ColumnCount; c++)
    {
      contentHeight = Math.Max(contentHeight, -columnY[c] - GroupSpacing);
    }

    root.Width = columnX[ColumnCount - 1] + columnWidths[ColumnCount - 1] + Margin;
    root.Height = contentHeight + Margin;

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
      }),
      ("Flight Availability", new[]
      {
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => { } },
        new VoteOption { Name = Loc.Get("Unlocked"), OnChosen = () => ResearchGranting.GrantToAllPlayers(UPGRADE_R09X_FLIGHT_UNIVERSAL_UPGRADE) }
      }),
      ("Navigation Availability", new[]
      {
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => { } },
        new VoteOption
        {
          Name = Loc.Get("Unlocked"), OnChosen = () =>
          {
            ResearchGranting.GrantToAllPlayers(UPGRADE_R04R_NAVIGATION_UNIVERSAL_UPGRADE);
            // Ahn'Qiraj has no ships - Deep Burrow is its equivalent way to cross water, so it belongs here too.
            ResearchGranting.GrantToAllPlayers(UPGRADE_RDBD_DEEP_BURROW_C_THUN);
          }
        }
      }),
      ("Fog of War", new[]
      {
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => { } },
        new VoteOption { Name = Loc.Get("All Allies"), OnChosen = () => FactionManager.SharedVisionMode = TeamSharedVisionMode.All },
        new VoteOption
        {
          Name = Loc.Get("Everything"), OnChosen = () =>
          {
            FactionManager.SharedVisionMode = TeamSharedVisionMode.All;
            RevealMapForAllPlayers();
          }
        }
      }),
      ("Early Game (PvE)", new[]
      {
        new VoteOption { Name = Loc.Get("Normal"), OnChosen = () => { } },
        new VoteOption { Name = Loc.Get("Skipped"), OnChosen = HardModeSetting.ApplyWithoutTechUnlocks }
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

  private static void RevealMapForAllPlayers()
  {
    foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
    {
      Rectangle.WorldBounds.Rect.AddFogModifier(player, fogstate.Visible, false, false).Start();
    }
  }
}
