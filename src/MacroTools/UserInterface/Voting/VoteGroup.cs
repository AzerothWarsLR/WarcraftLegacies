using System;
using MacroTools.UserInterface.Frames;
using MacroTools.Utils;
using WCSharp.Sync;
using Environment = MacroTools.Utils.Environment;

namespace MacroTools.UserInterface.Voting;

public sealed class VoteGroup
{
  private readonly int _groupId;
  private readonly VoteOption[] _options;
  private readonly int[] _votesByPlayerSlot;
  private readonly TextFrame[] _countTexts;
  private Action<VoteSyncMessage>? _voteReceivedHandler;
  private bool _concluded;

  public float Height { get; }

  public float Width { get; }

  public VoteOption? Winner { get; private set; }

  public bool AllPlayersVoted()
  {
    foreach (var activePlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      if (_votesByPlayerSlot[GetPlayerId(activePlayer)] < 0)
      {
        return false;
      }
    }

    return true;
  }

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
    const float titleGap = 0.008f;
    const float countGap = 0.004f;
    const float countWidth = 0.045f;
    const float countHeight = 0.024f;
    const float descriptionGap = 0.008f;
    const float descriptionHeight = 0.09f;
    const float descriptionScale = 0.7f;

    var groupWidth = options.Length * buttonWidth + (options.Length - 1) * buttonSpacing;

    var titleFrame = new TextFrame("ArtifactMenuTitle", parent, 0)
    {
      Width = groupWidth,
      Height = titleHeight,
      Text = title
    };
    titleFrame.SetPoint(framepointtype.Center, parent, framepointtype.TopLeft, x + groupWidth / 2, y - titleHeight / 2);
    titleFrame.CenterText();
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

    var descriptionCenterY = y - titleHeight - titleGap - descriptionHeight / 2;
    var buttonCenterY = y - titleHeight - titleGap - (hasAnyDescription ? descriptionHeight + descriptionGap : 0) - buttonHeight / 2;
    var countCenterY = buttonCenterY - buttonHeight / 2 - countGap - countHeight / 2;
    for (var i = 0; i < options.Length; i++)
    {
      var optionIndex = i;
      var optionCenterX = x + optionIndex * (buttonWidth + buttonSpacing) + buttonWidth / 2;

      if (hasAnyDescription)
      {
        var descriptionFrame = new TextFrame("ArtifactMenuTitle", parent, 0)
        {
          Width = buttonWidth,
          Height = descriptionHeight,
          Text = string.IsNullOrEmpty(options[optionIndex].Description) ? "" : $"|cffffffff{options[optionIndex].Description}|r"
        };
        descriptionFrame.SetPoint(framepointtype.Center, parent, framepointtype.TopLeft,
          optionCenterX / descriptionScale, descriptionCenterY / descriptionScale);
        descriptionFrame.SetScale(descriptionScale);
        descriptionFrame.CenterText();
        parent.AddFrame(descriptionFrame);
      }

      var button = new Button("ScriptDialogButton", parent, 0)
      {
        Width = buttonWidth,
        Height = buttonHeight,
        Text = options[optionIndex].Name,
        OnClick = triggerPlayer => OnButtonClicked(triggerPlayer, optionIndex)
      };
      button.SetPoint(framepointtype.Center, parent, framepointtype.TopLeft, optionCenterX, buttonCenterY);
      parent.AddFrame(button);

      var countFrame = new Frame("ScriptDialogButton", parent, 0)
      {
        Width = countWidth,
        Height = countHeight
      };
      countFrame.SetPoint(framepointtype.Center, parent, framepointtype.TopLeft, optionCenterX, countCenterY);
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
    Width = groupWidth;

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
