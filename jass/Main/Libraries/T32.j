//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~ Timer32 ~~ By Jesus4Lyf ~~ Version 1.06 ~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//
//  What is Timer32?
//         - Timer32 implements a fully optimised timer loop for a struct.
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
//         - struct.startPeriodic()
//         - struct.stopPeriodic()
//
//         - private method periodic takes nothing returns nothing
//
//           This must be defined in structs that implement Periodic Module.
//           It will be executed by the module every PERIOD until .stopPeriodic() is called.
//           Put "implement T32x" BELOW this method.
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
//         - Create a trigger named T32.
//         - Convert it to custom text and replace the whole trigger text with this.
//
//  Thanks:
//         - Infinitegde for finding a bug in the debug message that actually altered
//           system operation (when in debug mode).
//
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
library T32 initializer OnInit
    globals
        public constant real PERIOD= 0.03125
        public constant integer FPS=R2I(1.00/PERIOD)
        public integer Tick=0 // very useful.
        
//==============================================================================
        private trigger Trig=CreateTrigger()
    endglobals
    
    //==============================================================================
    // The standard T32 module, T32x.
    //
    module T32x
        private thistype next
        private thistype prev
        
        private static method PeriodicLoop takes nothing returns boolean
            local thistype this=thistype(0).next
            loop
                exitwhen this==0
                call this.periodic()
                set this=this.next
            endloop
            return false
        endmethod

        method startPeriodic takes nothing returns nothing
            debug if this.prev!=0 or thistype(0).next==this then
            debug   call BJDebugMsg("T32 ERROR: Struct #"+I2S(this)+" had startPeriodic called while already running!")
            debug endif
            set thistype(0).next.prev=this
            set this.next=thistype(0).next
            set thistype(0).next=this
            set this.prev=thistype(0)
        endmethod
        
        method stopPeriodic takes nothing returns nothing
            debug if this.prev==0 and thistype(0).next!=this then
            debug   call BJDebugMsg("T32 ERROR: Struct #"+I2S(this)+" had stopPeriodic called while not running!")
            debug endif
            // This is some real magic.
            set this.prev.next=this.next
            set this.next.prev=this.prev
            // This will even work for the starting element.
            debug set this.prev=0
        endmethod
        
        private static method onInit takes nothing returns nothing
            call TriggerAddCondition(Trig,Condition(function thistype.PeriodicLoop))
        endmethod
    endmodule
    
    //==============================================================================
    // The standard T32 module with added safety checks on .startPeriodic() and
    // .stopPeriodic(), T32xs.
    //
    module T32xs
        private thistype next
        private thistype prev
        private boolean runningPeriodic
        
        private static method PeriodicLoop takes nothing returns boolean
            local thistype this=thistype(0).next
            loop
                exitwhen this==0
                call this.periodic()
                set this=this.next
            endloop
            return false
        endmethod

        method startPeriodic takes nothing returns nothing
            if not this.runningPeriodic then
                set thistype(0).next.prev=this
                set this.next=thistype(0).next
                set thistype(0).next=this
                set this.prev=thistype(0)
                
                set this.runningPeriodic=true
            endif
        endmethod
        
        method stopPeriodic takes nothing returns nothing
            if this.runningPeriodic then
                // This is some real magic.
                set this.prev.next=this.next
                set this.next.prev=this.prev
                // This will even work for the starting element.
                
                set this.runningPeriodic=false
            endif
        endmethod
        
        private static method onInit takes nothing returns nothing
            call TriggerAddCondition(Trig,Condition(function thistype.PeriodicLoop))
        endmethod
    endmodule
    
    //==============================================================================
    // The original T32 module, for backwards compatability only.
    //
    module T32 // deprecated.
        private thistype next
        private thistype prev
        
        private static method PeriodicLoop takes nothing returns boolean
            local thistype this=thistype(0).next
            loop
                exitwhen this==0
                if this.periodic() then
                    // This is some real magic.
                    set this.prev.next=this.next
                    set this.next.prev=this.prev
                    // This will even work for the starting element.
                    debug set this.prev=0
                endif
                set this=this.next
            endloop
            return false
        endmethod

        method startPeriodic takes nothing returns nothing
            debug if this.prev!=0 or thistype(0).next==this then
            debug   call BJDebugMsg("T32 ERROR: Struct #"+I2S(this)+" had startPeriodic called while already running!")
            debug endif
            set thistype(0).next.prev=this
            set this.next=thistype(0).next
            set thistype(0).next=this
            set this.prev=thistype(0)
        endmethod
        
        private static method onInit takes nothing returns nothing
            call TriggerAddCondition(Trig,Condition(function thistype.PeriodicLoop))
        endmethod
    endmodule
    
    //==============================================================================
    // System Core.
    //
    private function OnExpire takes nothing returns nothing
        set Tick=Tick+1
        call TriggerEvaluate(Trig)
    endfunction
    
    private function OnInit takes nothing returns nothing
        call TimerStart(CreateTimer(),PERIOD,true,function OnExpire)
    endfunction
endlibrary