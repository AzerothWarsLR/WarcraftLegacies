//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~ Timer32 ~~ By Jesus4Lyf ~~ Version 106 ~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//
//  What is Timer32?

//         - Instances can be added to the loop, which will call .periodic every
//           PERIOD until .stopPeriodic() is called.
//
//    =Pros=
//         - Efficient.
//         - Simple.
//
//    =Cons=
//         - Only allows one period.
//         - The called method must be named ".periodic".
//
//    Methods:


//
//         - private method periodic takes nothing returns nothing
//

//           It will be executed by the module every PERIOD until .stopPeriodic() is called.

//
//    Modules:
//         - T32x
//           Has no safety on .stopPeriodic or .startPeriodic (except debug messages
//           to warn).
//
//         - T32xs
//           Has safety on .stopPeriodic and .startPeriodic so if they are called
//           multiple times, or while otherwise are already stopped/started respectively,
//           no error will occur, the call will be ignored.
//
//         - T32
//           The original, old version of the T32 module. This remains for backwards
//           compatability, and is deprecated. The periodic method must return a boolean,
//           false to continue running or true to stop.
//
//  Details:
//         - Uses one timer.
//
//         - Do not, within a .periodic method, follow a .stopPeriodic call with a
//           .startPeriodic call.
//
//  How to import:
//         - Create a trigger named T32
//         - Convert it to custom text and replace the whole trigger text with this.
//
//  Thanks:
//         - Infinitegde for finding a bug in the debug message that actually altered
//           system operation (when in debug mode).
//
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
namespace AzerothWarsCSharp.Source.Main.Libraries
{
    public class T32{
    
        public const float PERIOD= 003125;
        public const int FPS=R2I(100/PERIOD);
        public int Tick=0 ;// very useful.

//==============================================================================
        private trigger Trig=CreateTrigger();
    

        //==============================================================================
        // The standard T32 module, T32x.
        //
        module T32x
        private thistype next;
        private thistype prev;

        private static boolean PeriodicLoop( ){
            thistype this=thistype(0).next;
            while(true){
                if ( this==0){ break; }
                this.periodic();
                this=this.next
            }
            return false;
        }

        void startPeriodic( ){
            debug if (this.prev!=0 || thistype(0).next==this){
                debug   BJDebugMsg("T32 ERROR: Struct #"+I2S(this)+" had startPeriodic called while already running!");
                debug }
            thistype(0).next.prev=this
            this.next=thistype(0).next
            thistype(0).next=this
            this.prev=thistype(0)
        }

        void stopPeriodic( ){
            debug if (this.prev==0 && thistype(0).next!=this){
                debug   BJDebugMsg("T32 ERROR: Struct #"+I2S(this)+" had stopPeriodic called while !running!");
                debug }
            // This is some real magic.
            this.prev.next=this.next
            this.next.prev=this.prev
            // This will even work for the starting element.
            debug this.prev=0
        }

        private static void onInit( ){
            TriggerAddCondition(Trig,( thistype.PeriodicLoop));
        }
        endmodule

            //==============================================================================
            // The standard T32 module with added safety checks on .startPeriodic() and
            // .stopPeriodic(), T32xs.
            //
            module T32xs
        private thistype next;
        private thistype prev;
        private boolean runningPeriodic;

        private static boolean PeriodicLoop( ){
            thistype this=thistype(0).next;
            while(true){
                if ( this==0){ break; }
                this.periodic();
                this=this.next
            }
            return false;
        }

        void startPeriodic( ){
            if (!this.runningPeriodic){
                thistype(0).next.prev=this
                this.next=thistype(0).next
                thistype(0).next=this
                this.prev=thistype(0)

                this.runningPeriodic=true
            }
        }

        void stopPeriodic( ){
            if (this.runningPeriodic){
                // This is some real magic.
                this.prev.next=this.next
                this.next.prev=this.prev
                // This will even work for the starting element.

                this.runningPeriodic=false
            }
        }

        private static void onInit( ){
            TriggerAddCondition(Trig,( thistype.PeriodicLoop));
        }
        endmodule

            //==============================================================================
            // The original T32 module, for backwards compatability only.
            //
            module T32 // deprecated.
        private thistype next;
        private thistype prev;

        private static boolean PeriodicLoop( ){
            thistype this=thistype(0).next;
            while(true){
                if ( this==0){ break; }
                if (this.periodic()){
                    // This is some real magic.
                    this.prev.next=this.next
                    this.next.prev=this.prev
                    // This will even work for the starting element.
                    debug this.prev=0
                }
                this=this.next
            }
            return false;
        }

        void startPeriodic( ){
            debug if (this.prev!=0 || thistype(0).next==this){
                debug   BJDebugMsg("T32 ERROR: Struct #"+I2S(this)+" had startPeriodic called while already running!");
                debug }
            thistype(0).next.prev=this
            this.next=thistype(0).next
            thistype(0).next=this
            this.prev=thistype(0)
        }

        private static void onInit( ){
            TriggerAddCondition(Trig,( thistype.PeriodicLoop));
        }
        endmodule

        //==============================================================================
        // System Core.
        //
        private static void OnExpire( ){
            Tick=Tick+1
            TriggerEvaluate(Trig);
        }

        private static void OnInit( ){
            TimerStart(CreateTimer(),PERIOD,true,function OnExpire);
        }
    }
}
