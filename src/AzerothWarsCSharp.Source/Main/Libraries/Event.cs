//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//  ~~    Event     ~~    By Jesus4Lyf    ~~    Version 104    ~~
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
namespace AzerothWarsCSharp.Source.Main.Libraries
{
    public class Event{
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
        private keyword destroyNode;

        int data
        void clear( ){
            this.data=0
        }
        void destroy( ){
            Event(this).destroyNode();
        }


        private module Stack;
        static thistype top=0
        static void increment( ){
            thistype.top=thistype(thistype.top+1)
        }
        static void decrement( ){
            thistype.top=thistype(thistype.top-1)
        }
        endmodule



            Event current



        private trigger trig;
        private thistype next;
        private thistype prev;

        static EventReg getTriggeringEventReg( ){
            return EventStack.top.current;
        }

        Event ( ){

            this.next=this
            this.prev=this
                ;;
        }

        private static trigger currentTrigger;
        void fire( ){
            thistype curr=this.next;
            EventStack.increment();
            while(true){
                if ( curr==this){ break; }
                thistype.currentTrigger=curr.trig
                if (IsTriggerEnabled(thistype.currentTrigger)){
                    EventStack.top.current=curr
                    if (TriggerEvaluate(thistype.currentTrigger)){
                        TriggerExecute(thistype.currentTrigger);
                    }
                }else {
                    EnableTrigger(thistype.currentTrigger) ;// Was trigger destroyed?
                    if (IsTriggerEnabled(thistype.currentTrigger)){
                        DisableTrigger(thistype.currentTrigger);
                    }else { // If trigger destroyed...
                        curr.next.prev=curr.prev
                        curr.prev.next=curr.next
                        curr.deallocate();
                    }
                }
                curr=curr.next
            }
            EventStack.decrement();
        }
        EventReg register(trigger t ){

            new.prev=this.prev
            this.prev.next=new
            this.prev=new
            new.next=this

            new.trig=t

            EventReg(new).clear();
            return new;
        }
        destroyNode( ){// called on EventReg
            this.prev.next=this.next
            this.next.prev=this.prev
            this.deallocate();
        }
        void unregister(trigger t ){
            thistype curr=this.next;
            while(true){
                if ( curr==this){ break; }
                if (curr.trig==t){
                    curr.next.prev=curr.prev
                    curr.prev.next=curr.next
                    curr.deallocate();
                    return;
                }
                curr=curr.next
            }
        }

        void destroy( ){
            thistype curr=this.next;
            while(true){
                curr.deallocate();
                if ( curr==this){ break; }
                curr=curr.next
            }
        }
        void chainDestroy( ){
            this.destroy() ;// backwards compatability.
        }


        /////////////////////////////////////////////////////
        // Demonstration Functions & Alternative Interface //
        ////////////////////////////////////////////////////////////////////////////
        // What this would look like in normal WC3 style JASS (should all inline).
        //
        static Event CreateEvent( ){
            return Event.create();
        }
        static void DestroyEvent(Event whichEvent ){
            whichEvent.chainDestroy();
        }
        static void FireEvent(Event whichEvent ){
            whichEvent.fire();
        }
        static EventReg TriggerRegisterEvent(trigger whichTrigger, Event whichEvent ){
            return whichEvent.register(whichTrigger);
        }

        // And for EventRegs...
        static void SetEventRegData(EventReg whichEventReg, int data ){
            whichEventReg.data=data
        }
        static integer GetEventRegData(EventReg whichEventReg ){
            return whichEventReg.data;
        }
        static integer GetTriggeringEventReg( ){
            return Event.getTriggeringEventReg();
        }
    }
}
