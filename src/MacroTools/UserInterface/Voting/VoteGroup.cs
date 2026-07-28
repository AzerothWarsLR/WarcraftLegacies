using System;
using MacroTools.UserInterface.Frames;
using MacroTools.Utils;
using WCSharp.Sync;
using Environment = MacroTools.Utils.Environment;

namespace MacroTools.UserInterface.Voting;

/// <summary>
/// A row of buttons - one per <see cref="VoteOption"/> - that players click to vote, with a live vote-count
/// label under each button. Multiple <see cref="VoteGroup"/>s can run concurrently on the same page under a
/// single shared timer; each is only responsible for its own buttons and tally, not for display timing or
/// pausing the game, which are the caller's responsibility.
/// </summary>
/// <remarks>
/// <para>
/// Custom frame click events only fire locally, on the clicking player's own client - they are not part of the
/// synchronized simulation. Every vote is therefore broadcast to all clients explicitly via
/// <see cref="SyncSystem"/> (a thin, typed wrapper around <c>BlzSendSyncData</c>) and stored in a fixed-size
/// array indexed by player slot, so every client ends up running identical tally logic over identical data.
/// </para>
/// <para>
/// Votes are deliberately kept in a plain array rather than a <see cref="System.Collections.Generic.Dictionary{TKey,TValue}"/>:
/// enumeration order over a dictionary is not guaranteed to be identical across clients once transpiled to Lua,
/// which would make tie-breaking a desync hazard. Iterating a fixed-size array in index order sidesteps that
/// entirely.
/// </para>
/// </remarks>
public sealed class VoteGroup
{
  private readonly int _groupId;
  private readonly VoteOption[] _options;
  private readonly int[] _votesByPlayerSlot;
  private readonly TextFrame[] _countTexts;
  private Action<VoteSyncMessage>? _voteReceivedHandler;
  private bool _concluded;

  /// <summary>
  /// The total vertical space this group occupies, so callers can stack multiple groups on one panel.
  /// </summary>
  public float Height { get; }

  /// <summary>
  /// The total horizontal space this group's button row occupies, so callers can size their panel to fit it.
  /// </summary>
  public float Width { get; }

  /// <summary>
  /// The option that won this group's vote. Only set after <see cref="Conclude"/> has run.
  /// </summary>
  public VoteOption? Winner { get; private set; }

  /// <summary>
  /// Builds the group's title, option buttons, and vote-count labels as children of <paramref name="parent"/>,
  /// anchored at (<paramref name="x"/>, <paramref name="y"/>) from its top-left corner, and starts listening
  /// for votes. The group is visible whenever <paramref name="parent"/> is visible.
  /// </summary>
  public VoteGroup(Frame parent, int groupId, string title, VoteOption[] options, float x, float y,
    float buttonWidth, float buttonHeight, float buttonSpacing)
  {
    _groupId = groupId;
    _options = options;
    _votesByPlayerSlot = new int[Environment.MaxPlayers];
    for (var i = 0; i < _votesByPlayerSlot.Length; i++)
    {
      _votesByPlayerSlot[i] = -1;
    }

    _countTexts = new TextFrame[options.Length];

    const float titleHeight = 0.025f;
    const float titleGap = 0.01f;
    const float countGap = 0.005f;
    const float countWidth = 0.03f;
    const float countHeight = 0.02f;
    const float descriptionGap = 0.004f;
    const float descriptionHeight = 0.05f;
    const float descriptionScale = 0.7f;

    var titleFrame = new TextFrame("ArtifactMenuTitle", parent, 0)
    {
      Text = title
    };
    titleFrame.SetPoint(framepointtype.TopLeft, parent, framepointtype.TopLeft, x, y);
    parent.AddFrame(titleFrame);

    var hasAnyDescription = false;
    foreach (var option in options)
    {
      if (!string.IsNullOrEmpty(option.Description))
      {
        hasAnyDescription = true;
        break;
      }
    }

    // Order top-to-bottom: title, description, button, vote-count chip.
    var descriptionY = y - titleHeight - titleGap;
    var buttonY = descriptionY - (hasAnyDescription ? descriptionHeight + descriptionGap : 0);
    var countY = buttonY - buttonHeight - countGap;
    for (var i = 0; i < options.Length; i++)
    {
      var optionIndex = i;
      var buttonX = x + optionIndex * (buttonWidth + buttonSpacing);

      if (hasAnyDescription)
      {
        var descriptionFrame = new TextFrame("ArtifactMenuTitle", parent, 0)
        {
          Width = buttonWidth,
          Height = descriptionHeight,
          Text = string.IsNullOrEmpty(options[optionIndex].Description) ? "" : $"|cffffffff{options[optionIndex].Description}|r"
        };
        descriptionFrame.SetPoint(framepointtype.TopLeft, parent, framepointtype.TopLeft, buttonX, descriptionY);
        descriptionFrame.SetScale(descriptionScale);
        parent.AddFrame(descriptionFrame);
      }

      var button = new Button("ScriptDialogButton", parent, 0)
      {
        Width = buttonWidth,
        Height = buttonHeight,
        Text = options[optionIndex].Name,
        OnClick = triggerPlayer => OnButtonClicked(triggerPlayer, optionIndex)
      };
      button.SetPoint(framepointtype.TopLeft, parent, framepointtype.TopLeft, buttonX, buttonY);
      parent.AddFrame(button);

      // A plain framehandle keeps its own border/backdrop from the "ScriptDialogButton" template (same as the
      // vote buttons above), so the count reads as a small counter chip rather than floating bare text. It's
      // deliberately much narrower than the button and centered under it, rather than matching its full width.
      var countX = buttonX + (buttonWidth - countWidth) / 2;
      var countFrame = new Frame("ScriptDialogButton", parent, 0)
      {
        Width = countWidth,
        Height = countHeight
      };
      countFrame.SetPoint(framepointtype.TopLeft, parent, framepointtype.TopLeft, countX, countY);
      parent.AddFrame(countFrame);

      var countText = new TextFrame("ArtifactMenuTitle", countFrame, 0)
      {
        Width = countWidth,
        Height = countHeight,
        Text = "0"
      };
      countText.SetPoint(framepointtype.Center, countFrame, framepointtype.Center, 0, 0);
      countText.CenterText();
      countFrame.AddFrame(countText);
      _countTexts[optionIndex] = countText;
    }

    Height = titleHeight + titleGap + (hasAnyDescription ? descriptionHeight + descriptionGap : 0) +
             buttonHeight + countGap + countHeight;
    Width = options.Length * buttonWidth + (options.Length - 1) * buttonSpacing;

    RegisterSyncListener();
  }

  private void OnButtonClicked(player triggerPlayer, int optionIndex)
  {
    if (_concluded || triggerPlayer != player.LocalPlayer)
    {
      return;
    }

    SyncSystem.Send(new VoteSyncMessage
    {
      GroupId = _groupId,
      PlayerId = GetPlayerId(triggerPlayer),
      OptionIndex = optionIndex
    });
  }

  private void RegisterSyncListener()
  {
    _voteReceivedHandler = message =>
    {
      if (message.GroupId != _groupId)
      {
        return;
      }

      if (message.OptionIndex < 0 || message.OptionIndex >= _options.Length ||
          message.PlayerId < 0 || message.PlayerId >= _votesByPlayerSlot.Length)
      {
        Logger.LogWarning($"Received an out-of-range vote from player {message.PlayerId} for vote group {_groupId}.");
        return;
      }

      _votesByPlayerSlot[message.PlayerId] = message.OptionIndex;
      RefreshCounts();
    };
    SyncSystem.Subscribe(_voteReceivedHandler);
  }

  private void RefreshCounts()
  {
    var counts = ComputeRawCounts();
    for (var i = 0; i < _options.Length; i++)
    {
      _countTexts[i].Text = counts[i].ToString();
    }
  }

  private int[] ComputeRawCounts()
  {
    var counts = new int[_options.Length];
    for (var slot = 0; slot < _votesByPlayerSlot.Length; slot++)
    {
      var votedIndex = _votesByPlayerSlot[slot];
      if (votedIndex >= 0)
      {
        counts[votedIndex]++;
      }
    }

    return counts;
  }

  /// <summary>
  /// Tallies votes deterministically: fixed-size arrays, iterated strictly in index order, with ties broken in
  /// favor of whichever <see cref="VoteOption"/> was declared first. This must produce bit-identical results on
  /// every client, since it runs independently (not synced) on each of them once every client's local copy of
  /// the vote array has received the same synced votes. Stops listening for further votes, invokes the winning
  /// option's <see cref="VoteOption.OnChosen"/>, and sets <see cref="Winner"/>.
  /// </summary>
  public void Conclude()
  {
    _concluded = true;

    if (_voteReceivedHandler != null)
    {
      SyncSystem.Unsubscribe(_voteReceivedHandler);
      _voteReceivedHandler = null;
    }

    var counts = ComputeRawCounts();
    for (var i = 0; i < _options.Length; i++)
    {
      counts[i] += _options[i].VoteOffset;
    }

    var winningIndex = 0;
    for (var i = 1; i < counts.Length; i++)
    {
      if (counts[i] > counts[winningIndex])
      {
        winningIndex = i;
      }
    }

    Winner = _options[winningIndex];
    Winner.OnChosen();
  }
}
