using System;
using MacroTools.Localization;
using MacroTools.Paths;
using MacroTools.Quests;
using MacroTools.UserInterface.Books.Core;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Books.Paths;

public sealed class PathCard : Card<FactionPath>
{
  private const float BoxWidth = 0.34f;
  private const float BoxHeight = 0.165f;
  private const float ButtonWidth = 0.075f;
  private const float ButtonHeight = 0.03f;
  private const float ProgressBarWidth = 0.17f;
  private const float ProgressBarHeight = 0.012f;
  private const float ProgressBarBorder = 0.007f;

  private FactionPath? _path;
  private bool _confirmingDecline;
  private readonly Frame _icon;
  private readonly TextFrame _title;
  private readonly TextFrame _textFrame;
  private readonly Button _acceptButton;
  private readonly Button _declineButton;
  private readonly Button _cancelButton;
  private readonly Frame _progressBarBorder;
  private readonly Frame _progressBarBack;
  private readonly Frame _progressBarFill;
  private readonly Frame _progressBarGlass;

  /// <inheritdoc />
  public override bool Occupied => Item != null;

  /// <inheritdoc />
  public override void Clear() => Item = null;

  /// <summary>
  /// The <see cref="FactionPath"/> currently being represented by this <see cref="PathCard"/>.
  /// </summary>
  public override FactionPath? Item
  {
    get => _path;
    set
    {
      Visible = value != null;

      if (_path != null)
      {
        _path.StateChanged -= OnPathChanged;
        _path.Updated -= OnPathChanged;
      }

      _path = value;
      _confirmingDecline = false;

      if (_path == null)
      {
        return;
      }

      _icon.Texture = _path.IconPath;
      _title.Text = Loc.Get(_path.Name);
      _path.StateChanged += OnPathChanged;
      _path.Updated += OnPathChanged;
      Refresh();
    }
  }

  public PathCard(Frame parent) : base(parent, BoxWidth, BoxHeight)
  {
    _icon = new Frame("BACKDROP", "ArtifactIcon", this)
    {
      Width = 0.04f,
      Height = 0.04f
    };
    _icon.SetPoint(framepointtype.TopLeft, this, framepointtype.TopLeft, 0.015f, -0.03f);
    AddFrame(_icon);

    _title = new TextFrame("ArtifactItemTitle", this, 0)
    {
      Width = BoxWidth - 0.04f,
      Height = 0
    };
    _title.SetPoint(framepointtype.Top, this, framepointtype.Top, 0, -0.012f);
    AddFrame(_title);

    _textFrame = new TextFrame("ArtifactItemOwnerText", this, 0);
    _textFrame.SetPoint(framepointtype.TopLeft, _icon, framepointtype.TopRight, 0.007f, 0);
    _textFrame.SetPoint(framepointtype.Right, this, framepointtype.Right, -0.012f, 0);
    _textFrame.SetPoint(framepointtype.Bottom, this, framepointtype.Bottom, 0, 0.045f);
    _textFrame.SetTextAlignment(textaligntype.Top, textaligntype.Left);
    AddFrame(_textFrame);

    _acceptButton = new Button("ScriptDialogButton", this, 0)
    {
      Width = ButtonWidth,
      Height = ButtonHeight,
      Text = Loc.Get("Accept"),
      OnClick = OnAcceptClicked
    };
    _acceptButton.SetPoint(framepointtype.BottomRight, this, framepointtype.BottomRight, -0.012f - ButtonWidth, 0.012f);
    AddFrame(_acceptButton);

    _declineButton = new Button("ScriptDialogButton", this, 0)
    {
      Width = ButtonWidth,
      Height = ButtonHeight,
      Text = Loc.Get("Decline"),
      OnClick = OnDeclineClicked
    };
    _declineButton.SetPoint(framepointtype.BottomRight, this, framepointtype.BottomRight, -0.012f, 0.012f);
    AddFrame(_declineButton);

    _cancelButton = new Button("ScriptDialogButton", this, 0)
    {
      Width = ButtonWidth,
      Height = ButtonHeight,
      Text = Loc.Get("Cancel"),
      OnClick = OnCancelClicked
    };
    _cancelButton.SetPoint(framepointtype.BottomRight, this, framepointtype.BottomRight, -0.012f, 0.012f);
    AddFrame(_cancelButton);

    _progressBarBorder = new Frame("ArtifactItemBox", this, 0)
    {
      Width = ProgressBarWidth + 2 * ProgressBarBorder,
      Height = ProgressBarHeight + 2 * ProgressBarBorder
    };
    _progressBarBorder.SetPoint(framepointtype.Left, _cancelButton, framepointtype.Left, -0.025f - ProgressBarWidth - 2 * ProgressBarBorder, 0);
    AddFrame(_progressBarBorder);

    _progressBarBack = new Frame("BACKDROP", "PathProgressBarBack", this)
    {
      Width = ProgressBarWidth,
      Height = ProgressBarHeight,
      Texture = @"UI\Glues\Loading\LoadBar\Loading-BarBackground.blp"
    };
    _progressBarBack.SetPoint(framepointtype.Center, _progressBarBorder, framepointtype.Center, 0, 0);
    AddFrame(_progressBarBack);

    _progressBarFill = new Frame("BACKDROP", "PathProgressBarFill", this)
    {
      Width = 0.001f,
      Height = ProgressBarHeight,
      Texture = @"UI\Glues\Loading\LoadBar\Loading-BarFill.blp"
    };
    _progressBarFill.SetPoint(framepointtype.BottomLeft, _progressBarBack, framepointtype.BottomLeft, 0, 0);
    AddFrame(_progressBarFill);

    _progressBarGlass = new Frame("BACKDROP", "PathProgressBarGlass", this)
    {
      Texture = @"UI\Glues\Loading\LoadBar\Loading-BarGlass.blp"
    };
    _progressBarGlass.SetAllPoints(_progressBarBack);
    AddFrame(_progressBarGlass);
  }

  private void OnAcceptClicked(player whichPlayer)
  {
    if (_path != null)
    {
      _path.Accept(whichPlayer);
    }
  }

  private void OnDeclineClicked(player whichPlayer)
  {
    if (_path == null)
    {
      return;
    }

    if (!_confirmingDecline)
    {
      _confirmingDecline = true;
      Refresh();
      return;
    }

    _confirmingDecline = false;
    _path.Decline(whichPlayer);
  }

  private void OnCancelClicked(player whichPlayer)
  {
    if (_path != null)
    {
      _path.Cancel(whichPlayer);
    }
  }

  private void OnPathChanged(FactionPath path) => Refresh();

  private void Refresh()
  {
    if (_path == null)
    {
      return;
    }

    var state = _path.State;
    var blocked = state == PathState.Available && _path.BlockedReason != null;
    _textFrame.Text = $"{GetStatusText(_path)}\n{GetBodyText(_path)}";

    _acceptButton.Visible = state == PathState.Available && !blocked;
    if (state != PathState.Available)
    {
      _confirmingDecline = false;
    }

    _declineButton.Visible = state == PathState.Available && _path.CanDecline;
    _declineButton.Text = _confirmingDecline ? Loc.Get("Confirm?") : Loc.Get("Decline");
    _cancelButton.Visible = state == PathState.Committing;
    _progressBarBorder.Visible = state == PathState.Committing;
    _progressBarBack.Visible = state == PathState.Committing;
    _progressBarFill.Visible = state == PathState.Committing;
    _progressBarGlass.Visible = state == PathState.Committing;
    _progressBarFill.Width = Math.Max(0.001f, ProgressBarWidth * _path.CommitProgress);
  }

  private static string GetStatusText(FactionPath path)
  {
    switch (path.State)
    {
      case PathState.Locked:
        return $"|cffaaaaaa{Loc.Get("Locked")}|r";
      case PathState.Available when path.BlockedReason != null:
        return path.OfferDuration > 0
          ? $"|cffff8800{Loc.Get("On hold")}|r - {Loc.Format("closes in {time}", ("{time}", CardText.FormatTime(path.OfferTimeRemaining)))}\n{path.BlockedReason}"
          : $"|cffff8800{Loc.Get("On hold")}|r - {path.BlockedReason}";
      case PathState.Available when path.OfferDuration > 0:
        return $"|cff00ff00{Loc.Get("Available")}|r - {Loc.Format("closes in {time}", ("{time}", CardText.FormatTime(path.OfferTimeRemaining)))}";
      case PathState.Available:
        return $"|cff00ff00{Loc.Get("Available")}|r";
      case PathState.Committing:
        return $"|cffffcc00{Loc.Get("Committing")}|r - {Loc.Format("taken in {time}", ("{time}", CardText.FormatTime(path.CommitTimeRemaining)))}";
      case PathState.Taken:
        return $"|cffffcc00{Loc.Get("Taken")}|r";
      case PathState.Declined:
        return $"|cffaaaaaa{Loc.Get("Declined")}|r";
      default:
        return $"|cffff0000{Loc.Get("Closed")}|r";
    }
  }

  private static string GetBodyText(FactionPath path)
  {
    var text = Loc.Get(path.Description);
    if (path.DeclineDescription != null)
    {
      text += $"\n|cffff8800{Loc.Get("If declined:")}|r {Loc.Get(path.DeclineDescription)}";
    }

    foreach (var requirement in path.Requirements)
    {
      var color = path.IsRequirementMet(requirement)
        ? "|cff00ff00"
        : requirement.Progress == QuestProgress.Failed ? "|cffff0000" : "|cffaaaaaa";
      text += $"\n{color}- {requirement.Description}|r";
    }

    return text;
  }
}
