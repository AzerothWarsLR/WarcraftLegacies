using AzerothWarsCSharp.MacroTools.Augments;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books.Augments
{
   public sealed class AugmentCard : Card
   {
      private const float BoxWidth = 0.28f;
      private const float BoxHeight = 0.092f;
      private readonly Augment _augment;
      private readonly TextFrame _textFrame;

      public AugmentCard(Augment augment, Frame parent) : base(parent, BoxWidth, BoxHeight)
      {
         _augment = augment;
         var icon = new Frame("BACKDROP", "ArtifactIcon", this)
         {
            Width = 0.04f,
            Height = 0.04f,
            Texture = augment.IconPath
         };
         icon.SetPoint(FRAMEPOINT_LEFT, this, FRAMEPOINT_LEFT, 0.015f, -0.0090f);
         AddFrame(icon);

         var title = new TextFrame("ArtifactItemTitle", this, 0, 0)
         {
            Text = augment.Name,
            Width = BoxWidth - 0.04f,
            Height = 0
         };
         title.SetPoint(FRAMEPOINT_CENTER, this, FRAMEPOINT_CENTER, 0, 0.0255f);
         AddFrame(title);

         _textFrame = new TextFrame("ArtifactItemOwnerText", this, 0, 0)
         {
            Text = augment.Description
         };
         _textFrame.SetPoint(FRAMEPOINT_TOPLEFT, icon, FRAMEPOINT_TOPRIGHT, 0.007f, 0);
         _textFrame.SetPoint(FRAMEPOINT_BOTTOMLEFT, icon, FRAMEPOINT_BOTTOMRIGHT, 0.007f, 0);
         _textFrame.SetPoint(FRAMEPOINT_RIGHT, this, FRAMEPOINT_RIGHT, -0.007f, 0);
         AddFrame(_textFrame);
      }
   }
}