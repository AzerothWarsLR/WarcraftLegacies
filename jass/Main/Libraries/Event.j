//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//  ~~    Event     ~~    By Jesus4Lyf    ~~    Version 1.04    ~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//
//  What is Event?
//         - Event simulates Warcraft III events. They can be created,
//           registered for, fired and also destroyed.
//         - Event, therefore, can also be used like a trigger "group".
//         - This was created when there was an influx of event style systems 
//           emerging that could really benefit from a standardised custom
//           events snippet. Many users were trying to achieve the same thing
//           and making the same kind of errors. This snippet aims to solve that.
//
//  Functions:
//         - Event.create()       --> Creates a new Event.
//         - .destroy()           --> Destroys an Event.
//         - .fire()              --> Fires all triggers which have been
//                                    registered on this Event.
//         - .register(trigger)   --> Registers another trigger on this Event.
//         - .unregister(trigger) --> Unregisters a trigger from this Event.
//
//  Details:
//         - Event is extremely efficient and lightweight.
//         - It is safe to use with dynamic triggers.
//         - Internally, it is just a linked list. Very simple.
//
//  How to import:
//         - Create a trigger named Event.
//         - Convert it to custom text and replace the whole trigger text with this.
//
//  Thanks:
//         - Builder Bob for the trigger destroy detection method.
//         - Azlier for inspiring this by ripping off my dodgier code.
//
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
library Event
    ///////////////
    // EventRegs //
    ////////////////////////////////////////////////////////////////////////////
    // For reading this far, you can learn one thing more.
    // Unlike normal Warcraft III events, you can attach to Event registries.
    // 
    // Event Registries are registrations of one trigger on one event.
    // These cannot be created or destroyed, just attached to.
    //
    // It is VERY efficient for loading and saving data.
    // 
    //  Functions:
    //         - set eventReg.data = someStruct --> Store data.
    //         - eventReg.data                  --> Retreive data.
    //         - Event.getTriggeringEventReg()  --> Get the triggering EventReg.
    //         - eventReg.destroy()             --> Undo this registration.
    // 
    private keyword destroyNode
    struct EventReg extends array
        integer data
        method clear takes nothing returns nothing
            set this.data=0
        endmethod
        method destroy takes nothing returns nothing
            call Event(this).destroyNode()
        endmethod
    endstruct
    
    private module Stack
        static thistype top=0
        static method increment takes nothing returns nothing
            set thistype.top=thistype(thistype.top+1)
        endmethod
        static method decrement takes nothing returns nothing
            set thistype.top=thistype(thistype.top-1)
        endmethod
    endmodule
    
    private struct EventStack extends array
        implement Stack
        Event current
    endstruct
    
    struct Event
        private trigger trig
        private thistype next
        private thistype prev
        
        static method getTriggeringEventReg takes nothing returns EventReg
            return EventStack.top.current
        endmethod
        
        static method create takes nothing returns Event
            local Event this=Event.allocate()
            set this.next=this
            set this.prev=this
            return this
        endmethod
        
        private static trigger currentTrigger
        method fire takes nothing returns nothing
            local thistype curr=this.next
            call EventStack.increment()
            loop
                exitwhen curr==this
                set thistype.currentTrigger=curr.trig
                if IsTriggerEnabled(thistype.currentTrigger) then
                    set EventStack.top.current=curr
                    if TriggerEvaluate(thistype.currentTrigger) then
                        call TriggerExecute(thistype.currentTrigger)
                    endif
                else
                    call EnableTrigger(thistype.currentTrigger) // Was trigger destroyed?
                    if IsTriggerEnabled(thistype.currentTrigger) then
                        call DisableTrigger(thistype.currentTrigger)
                    else // If trigger destroyed...
                        set curr.next.prev=curr.prev
                        set curr.prev.next=curr.next
                        call curr.deallocate()
                    endif
                endif
                set curr=curr.next
            endloop
            call EventStack.decrement()
        endmethod
        method register takes trigger t returns EventReg
            local Event new=Event.allocate()
            set new.prev=this.prev
            set this.prev.next=new
            set this.prev=new
            set new.next=this
            
            set new.trig=t
            
            call EventReg(new).clear()
            return new
        endmethod
        method destroyNode takes nothing returns nothing // called on EventReg
            set this.prev.next=this.next
            set this.next.prev=this.prev
            call this.deallocate()
        endmethod
        method unregister takes trigger t returns nothing
            local thistype curr=this.next
            loop
                exitwhen curr==this
                if curr.trig==t then
                    set curr.next.prev=curr.prev
                    set curr.prev.next=curr.next
                    call curr.deallocate()
                    return
                endif
                set curr=curr.next
            endloop
        endmethod
        
        method destroy takes nothing returns nothing
            local thistype curr=this.next
            loop
                call curr.deallocate()
                exitwhen curr==this
                set curr=curr.next
            endloop
        endmethod
        method chainDestroy takes nothing returns nothing
            call this.destroy() // backwards compatability.
        endmethod
    endstruct
    
    /////////////////////////////////////////////////////
    // Demonstration Functions & Alternative Interface //
    ////////////////////////////////////////////////////////////////////////////
    // What this would look like in normal WC3 style JASS (should all inline).
    // 
    function CreateEvent takes nothing returns Event
        return Event.create()
    endfunction
    function DestroyEvent takes Event whichEvent returns nothing
        call whichEvent.chainDestroy()
    endfunction
    function FireEvent takes Event whichEvent returns nothing
        call whichEvent.fire()
    endfunction
    function TriggerRegisterEvent takes trigger whichTrigger, Event whichEvent returns EventReg
        return whichEvent.register(whichTrigger)
    endfunction
    
    // And for EventRegs...
    function SetEventRegData takes EventReg whichEventReg, integer data returns nothing
        set whichEventReg.data=data
    endfunction
    function GetEventRegData takes EventReg whichEventReg returns integer
        return whichEventReg.data
    endfunction
    function GetTriggeringEventReg takes nothing returns integer
        return Event.getTriggeringEventReg()
    endfunction
endlibrary