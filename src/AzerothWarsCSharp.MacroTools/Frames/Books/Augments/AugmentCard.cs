using System;
using AzerothWarsCSharp.MacroTools.Augments;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books.Augments
{
   public sealed class AugmentCard : Card
   {
      private const float BoxWidth = 0.16f;
      private const float BoxHeight = 0.28f;
      private readonly Augment _augment;
      private readonly TextFrame _descriptionFrame;
      
      public event EventHandler<AugmentCard>? OnChoose;
      
      public AugmentCard(Augment augment, Frame parent) : base(parent, BoxWidth, BoxHeight)
      {
         _augment = augment;

         var icon = new Frame("BACKDROP", "ArtifactIcon", this)
         {
            Width = 0.06f,
            Height = 0.06f,
            Texture = augment.IconPath
         };
         icon.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.07f);
         AddFrame(icon);
         
         var title = new TextFrame("ArtifactItemTitle", this, 0, 0)
         {
            Text = augment.Name,
            Width = BoxWidth - 0.04f,
            Height = 0
         };
         title.SetPoint(FRAMEPOINT_TOP, icon, FRAMEPOINT_BOTTOM, 0, -0.015f);
         AddFrame(title);
         
         var buttonFrame = new Button("ScriptDialogButton", this, 0, 0)
         {
            Width = 0.11f,
            Height = 0.026f,
            Text = "Choose",
            OnClick = Choose
         };
         buttonFrame.SetPoint(FRAMEPOINT_BOTTOM, this, FRAMEPOINT_BOTTOM, 0, 0.01f);
         AddFrame(buttonFrame);
         
         _descriptionFrame = new TextFrame("AugmentDescription", this, 0, 0)
         {
            Text = augment.Description
         };
         _descriptionFrame.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.014f, 0);
         _descriptionFrame.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.014f, 0);
         _descriptionFrame.SetPoint(FRAMEPOINT_TOP, title, FRAMEPOINT_BOTTOM, 0, -0.008f);
         _descriptionFrame.SetPoint(FRAMEPOINT_BOTTOM, buttonFrame, FRAMEPOINT_TOP, 0, -0.002f);
         AddFrame(_descriptionFrame);
      }

      private void Choose(player triggerplayer)
      {
         try
         {
            triggerplayer.GetFaction()?.AddAugment(_augment);
            OnChoose?.Invoke(this, this);
         }
         catch (Exception ex)
         {
            Console.Write(ex);
         }
      }
   }
}