using System;
using System.Collections.Generic;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books
{
   public abstract class Book<T> : Frame where T : Page, new()
   {
      private readonly Button _launcher;
      private readonly Button _nextButton;
      private readonly Button _previousButton;
      private readonly TextFrame _title;

      protected readonly List<T> Pages = new();

      private int _activePageIndex;

      /// <summary>
      /// Creates a new Book.>.
      /// </summary>
      /// <param name="width">How wide the Book should be.</param>
      /// <param name="height">How tall the Book should be.</param>
      /// <param name="bottomButtonXOffset">How far the Previous and Next buttons should be from the left side of the Book.</param>
      /// <param name="bottomButtonYOffset">How far the Previous and Next buttons should be from the bottom side of the Book.</param>
      protected Book(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset) : base(
         "ArtifactMenuBackdrop", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
      {
         Width = width;
         Height = height;
         Visible = false;
         
         _launcher = new Button("ScriptDialogButton", BlzGetOriginFrame(ORIGIN_FRAME_GAME_UI, 0), 0)
         {
            Width = 0.09f,
            Height = 0.025f,
            OnClick = OpenFirstPage
         };
      
         var exitButton = new Button("ScriptDialogButton", this, 0)
         {
            Width = 0.03f,
            Height = 0.03f,
            Text = "x",
            OnClick = OnClickExitButton
         };
         exitButton.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOPRIGHT, -0.015f, -0.015f);
         AddFrame(exitButton);
      
         _nextButton = new Button("ScriptDialogButton", this, 0)
         {
            Width = 0.09f,
            Height = 0.037f,
            Text = "Next",
            OnClick = OnClickNextButton,
            Visible = true
         };
         _nextButton.SetPoint(FRAMEPOINT_BOTTOMRIGHT, this, FRAMEPOINT_BOTTOMRIGHT, -bottomButtonXOffset,
            bottomButtonYOffset);
         AddFrame(_nextButton);
      
         _previousButton = new Button("ScriptDialogButton", this, 0)
         {
            Width = 0.09f,
            Height = 0.037f,
            Text = "Previous",
            OnClick = OnClickPreviousButton,
            Visible = true
         };
         _previousButton.SetPoint(FRAMEPOINT_BOTTOMLEFT, this, FRAMEPOINT_BOTTOMLEFT, bottomButtonXOffset,
            bottomButtonYOffset);
         AddFrame(_previousButton);
      
         _title = new TextFrame("ArtifactMenuTitle", this, 0)
         {
            Text = "Artifacts"
         };
         _title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_TOP, 0, -0.025f);
         AddFrame(_title);
      }

      /// <summary>
      ///    The name of the Book's launcher Button.
      /// </summary>
      protected string BookTitle
      {
         init
         {
            _launcher.Text = value;
            _title.Text = value;
         }
      }

      /// <summary>
      /// When set, the Book's Launcher button is moved directly below the provided parent with the same width and height.
      /// Useful for mimicking existing Blizzard buttons like the Quest or Allies menu.
      /// </summary>
      protected framehandle LauncherParent
      {
         init
         {
            _launcher.Width = BlzFrameGetWidth(value);
            _launcher.Height = BlzFrameGetHeight(value);
            _launcher.SetPoint(FRAMEPOINT_TOP, value, FRAMEPOINT_BOTTOM, 0, 0);
         }
      }
   
      /// <summary>
      ///    The position of the Book's launcher Button.
      /// </summary>
      protected Point LauncherPosition
      {
         init => _launcher.SetAbsPoint(FRAMEPOINT_CENTER, value.X, value.Y);
      }

      protected Point Position
      {
         init => SetAbsPoint(FRAMEPOINT_CENTER, value.X, value.Y);
      }

      private int ActivePageIndex
      {
         get => _activePageIndex;
         set
         {
            var pageCount = Pages.Count;
            if (value >= pageCount)
               throw new ArgumentOutOfRangeException(nameof(value),
                  $"ActivePageIndex must be lower than page count {pageCount}.");
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "ActivePageIndex cannot be negative.");
            Pages[_activePageIndex].Visible = false;
            _activePageIndex = value;
            Pages[_activePageIndex].Visible = true;
            RefreshNavigationButtonVisiblity();
         }
      }

      private void OnClickNextButton(player whichPlayer)
      {
         try
         {
            ActivePageIndex++;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
      }

      private void OnClickPreviousButton(player whichPlayer)
      {
         try
         {
            ActivePageIndex--;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
      }

      private void OnClickExitButton(player triggerPlayer)
      {
         Visible = false;
         _launcher.Visible = true;
      }

      private void OpenFirstPage(player whichPlayer)
      {
         if (whichPlayer == GetLocalPlayer())
         {
            Visible = true;
            _launcher.Visible = false;
         }
      }

      /// <summary>
      ///    Adds a new Page to the end of the Book.
      /// </summary>
      protected T AddPage()
      {
         var newPage = new T
         {
            Width = Width,
            Height = Height,
            PageNumber = Pages.Count + 1,
            Parent = this
         };
         newPage.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0);

         Pages.Add(newPage);
         RefreshNavigationButtonVisiblity();
         return newPage;
      }

      /// <summary>
      ///    Makes the Previous button visible if there are any pages to navigate back to,
      ///    and makes the Next button visible if there are any pages to navigate forward to.
      /// </summary>
      private void RefreshNavigationButtonVisiblity()
      {
         var pageCount = Pages.Count;

         _nextButton.Visible = pageCount > ActivePageIndex + 1;
         _previousButton.Visible = ActivePageIndex > 0;
      }
   }
}