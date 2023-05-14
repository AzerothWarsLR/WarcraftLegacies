using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Frames
{
   public delegate void OnClickAction(player triggerPlayer);

   /// <summary>
   /// A user interface element which can be clicked to produce an effect.
   /// </summary>
   public sealed class Button : Frame
   {
      private trigger? _onClickTrigger;

      public Button(string name, framehandle parent, int priority) : base(name, parent,
         priority)
      {
      }

      public Button(string name, Frame parent, int priority) : base(name, parent, priority)
      {
      }

      public Button(string name, Frame parent) : base(name, parent)
      {
      }

      public Button(string typeName, string name, Frame parent, string inherits = null) : base(typeName, name, parent,
         inherits)
      {
      }

      /// <summary>
      /// Determines what happens when the button is clicked.
      /// </summary>
      public OnClickAction OnClick
      {
         set
         {
           if (_onClickTrigger != null)
           {
             _onClickTrigger.Destroy();
             _onClickTrigger = null;
           }
           _onClickTrigger = CreateTrigger()
             .RegisterFrameEvent(Handle, FRAMEEVENT_CONTROL_CLICK)
             .AddAction(() => value(GetTriggerPlayer()));
         }
      }

      public string Text
      {
         get => BlzFrameGetText(Handle);
         set => BlzFrameSetText(Handle, value);
      }

      /// <inheritdoc />
      public override void Dispose()
      {
        _onClickTrigger?.Destroy();
        base.Dispose();
      }
   }
}