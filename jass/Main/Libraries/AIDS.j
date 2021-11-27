//  
//        _   ___ ___  ___    _______________________________________________
//       /_\ |_ _|   \/ __|   ||     A D V A N C E D   I N D E X I N G     ||
//      / _ \ | || |) \__ \   ||                  A N D                    ||
//     /_/ \_\___|___/|___/   ||         D A T A   S T O R A G E           ||
//            By Jesus4Lyf    ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//                                                                    v 1.1.0
//      What is AIDS?
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          AIDS assigns unique integers between 1 and 8191 to units which enter
//          the map. These can be used for arrays and data attaching.
//          
//          AIDS also allows you to define structs which are created automatically
//          when units enter the map, and filtering which units should be indexed
//          as well as for which units these structs should be created.
//          
//      How to implement?
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          Simply create a new trigger object called AIDS, go to 'Edit -> Convert
//          to Custom Text', and replace everything that's there with this script.
//
//          Save the map, close it, reopen it, and then delete the "!" from the
//          FAR left side of the next lines (so "external" will line up with this line):
//          external ObjectMerger w3a Adef AIDS anam "State Detection" ansf "(AIDS)" aart "" arac 0
//
//          At the top of the script, there is a 'UnitIndexingFilter' constant
//          function. If the function returns true for the unit, then that unit
//          will be automatically indexed. Setting this to true will automatically
//          index all units. Setting it to false will disable automatic indexing.
//
//      Functions:
//     ¯¯¯¯¯¯¯¯¯¯¯¯
//          function GetUnitId takes unit u returns integer
//              - This returns the index of an indexed unit. This will return 0
//                if the unit has not been indexed.
//              - This function inlines. It does not check if the unit needs an
//                index. This function is for the speed freaks.
//              - Always use this if 'UnitIndexingFilter' simply returns true.
//
//          function GetUnitIndex takes unit u returns integer
//              - This will return the index of a unit if it has one, or assign
//                an index if the unit doesn't have one (and return the new index).
//              - Use this if 'UnitIndexingFilter' doesn't return true.
//
//          function GetIndexUnit takes integer index returns unit
//              - This returns the unit which has been assigned the 'index'.
//
//      AIDS Structs:
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          - Insert: //! runtextmacro AIDS() at the top of a struct to make it
//            an AIDS struct.
//          - AIDS structs cannot be created or destroyed manually. Instead, they
//            are automatically created when an appropriate unit enters the map.
//          - You cannot give members default values in their declaration.
//            (eg: private integer i=5 is not allowed)
//          - You cannot use array members.
//          - AIDS structs must "extend array". This will remove some unused
//            functions and enforce the above so there will be no mistakes.
//          - There are four optional methods you can use in AIDS structs:
//              - AIDS_onCreate takes nothing returns nothing
//                  - This is called when the struct is 'created' for the unit.
//                  - In here you can assign members their default values, which
//                    you would usually assign in their declarations.
//                    (eg: set this.i=5)
//              - AIDS_onDestroy takes nothing returns nothing
//                  - This is called when the struct is 'destroyed' for the unit.
//                  - This is your substitute to the normal onDestroy method.
//              - AIDS_filter takes unit u returns boolean
//                  - This is similar to the constant filter in the main system.
//                  - Each unit that enters the map will be tested by each AIDS
//                    struct filter. If it returns true for that unit, that unit
//                    will be indexed if it was not already, the AIDS struct will
//                    have its AIDS_onCreate method called, and later have its
//                    AIDS_onDestroy method called when the index is recycled.
//                  - Not declaring this will use the default AIDS filter instead.
//              - AIDS_onInit takes nothing returns nothing
//                  - This is because I stole your onInit function with my textmacro.
//          - You can use '.unit' from any AIDS struct to get the unit for which
//            the struct is for.
//          - The structs id will be the units index, so getting the struct for
//            a unit inlines to a single native call, and you can typecast between
//            different AIDS structs. This is the premise of AIDS.
//          - Never create or destroy AIDS structs directly.
//          - You can call .AIDS_addLock() and AIDS_removeLock() to increase or
//            decrease the lock level on the struct. If a struct's lock level is
//            not 0, it will not be destroyed until it is reduced to 0. Locks just
//            put off AIDS struct destruction in case you wish to attach to a timer
//            or something which must expire before the struct data disappears.
//            Hence, not freeing all locks will leak the struct (and index).
//
//      PUI and AutoIndex:
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          - AIDS includes the PUI textmacros and the AutoIndex module, because
//            these systems are not compatible with AIDS but have valid and distinct
//            uses.
//          - The PUI textmacros are better to use for spells than AIDS structs,
//            because they are not created for all units, just those targetted by
//            the spell (or whatever else is necessary).
//          - The AutoData module is good for very simple array syntax for data
//            attachment (although I don't recommend that people actually use it,
//            it's here mostly for compatability). Note that unlike the PUI textmacros,
//            units must pass the AIDS filter in order for this module to work with
//            them. This is exactly as the same as in AutoIndex itself (AutoIndex
//            has a filter too).
//          
//      Thanks:
//     ¯¯¯¯¯¯¯¯¯
//          - Romek, for writing 90% of this user documentation, challenging my
//            interface, doing some testing, suggesting improvements and inspiring
//            me to re-do my code to include GetUnitIndex as non-inlining.
//          - grim001, for writing the AutoData module, and AutoIndex. I used the
//            on-enter-map method that he used. Full credits for the AutoData module.
//          - Cohadar, for writing his PUI textmacros. Full credits to him for these,
//            except for my slight optimisations for this system.
//            Also, I have used an optimised version of his PeriodicRecycler from
//            PUI in this system to avoid needing a RemoveUnitEx function.
//          - Vexorian, for helping Cohadar on the PUI textmacro.
//          - Larcenist, for suggesting the AIDS acronym. Originally he suggested
//            'Alternative Index Detection System', but obviously I came up with
//            something better. In fact, I'd say it looks like the acronym was
//            an accident. Kinda neat, don't you think? :P
//
//      Final Notes:
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          - With most systems, I wouldn't usually add substitutes for alternative
//            systems. However, UnitData systems are an exception, because they
//            are incompatible with eachother. Since using this system forbids
//            people from using the real PUI or AutoIndex, and a lot of resources
//            use either of these, it made sense not to break them all.
//
//          - If this documentation confused you as to how to use the system, just
//            leave everything as default and use GetUnitId everywhere.
//
//          - To use this like PUI (if you don't like spamming indices) simply
//            make the AIDS filter return false, and use GetUnitIndex.
//
library AIDS initializer InitAIDS
    //==============================================================================
    // Configurables
    //
    globals
        private constant boolean USE_PERIODIC_RECYCLER = false
        private constant real PERIOD = 0.03125 // Recycles 32 units/second max.
                                               // Lower to be able to recycle faster.
                                               // Only used if USE_PERIODIC_RECYCLER
                                               // is set to true.
        
        private constant integer LEAVE_DETECTION_ABILITY = 'A0WI'
    endglobals
    
    private function UnitIndexingFilter takes unit u returns boolean
        return true
    endfunction
    
    //==============================================================================
    // System code
    //
    globals
        // The unit stored at an index.
        private unit array IndexUnit
        private integer array LockLevel
    endglobals
    
    //==============================================================================
    globals
        // Recycle stack
        private integer array RecycledIndex
        private integer MaxRecycledIndex = 0
        
        // Previous highest index
        private integer MaxIndex = 0
    endglobals
    
    //==============================================================================
    globals
        private integer array DecayingIndex
        private integer MaxDecayingIndex=0
        private integer DecayChecker=0
    endglobals
    
    globals
        private timer UndefendTimer=CreateTimer()
        private integer array UndefendIndex
        private integer UndefendStackIndex=0
    endglobals
    globals
        private integer array UndefendExpiringIndex
        private integer UndefendExpiringIndexLevel=0
    endglobals
    
    //==============================================================================
    globals
        // The Add/Remove stack (or assign/recycle stack).
        // 
        // Indexing can become recusive since units can be created on index
        // assignment or deallocation.
        // To support this, a stack is used to store the event response results.
        private integer ARStackLevel=0
        private integer array ARStackIndex
        private unit    array ARStackUnit
        
        // A later discovery revealed that the Add/Remove stack did not need to be
        // used for deallocation. The alternative used works fine...
    endglobals
    
    public constant function GetEnteringIndexUnit takes nothing returns unit
        return ARStackUnit[ARStackLevel]
    endfunction
    
    public function GetIndexOfEnteringUnit takes nothing returns integer
        // Called in AIDS structs when units do not pass the initial AIDS filter.
        
        if ARStackIndex[ARStackLevel]==0 then
            // Get new index, from recycler first, else new.
            // Store the current index on the (new) top level of the AR stack.
            if MaxRecycledIndex==0 then // Get new.
                set MaxIndex=MaxIndex+1
                set ARStackIndex[ARStackLevel]=MaxIndex
            else // Get from recycle stack.
                set ARStackIndex[ARStackLevel]=RecycledIndex[MaxRecycledIndex]
                set MaxRecycledIndex=MaxRecycledIndex-1
            endif
            
            // Store index on unit.
            call SetUnitUserData(ARStackUnit[ARStackLevel],ARStackIndex[ARStackLevel])
            set IndexUnit[ARStackIndex[ARStackLevel]]=ARStackUnit[ARStackLevel]
            
            // Add index to recycle list.
            set MaxDecayingIndex=MaxDecayingIndex+1
            set DecayingIndex[MaxDecayingIndex]=ARStackIndex[ARStackLevel]
        endif
        
        return ARStackIndex[ARStackLevel]
    endfunction
    
    public constant function GetIndexOfEnteringUnitAllocated takes nothing returns integer
        // Called in AIDS structs when units have passed the initial AIDS filter.
        return ARStackIndex[ARStackLevel]
    endfunction
    public constant function GetDecayingIndex takes nothing returns integer
        static if USE_PERIODIC_RECYCLER then
            return DecayingIndex[DecayChecker]
        else
            return UndefendExpiringIndex[UndefendExpiringIndexLevel]
        endif
    endfunction
    
    //==============================================================================
    globals
        // For structs and such which need to do things on unit index assignment.
        private trigger OnEnter=CreateTrigger()
        // The same, but for when units pass the initial filter anyway.
        private trigger OnEnterAllocated=CreateTrigger()
        // For structs and such which need to do things on unit index deallocation.
        private trigger OnDeallocate=CreateTrigger()
    endglobals
    
    public function RegisterOnEnter takes boolexpr b returns triggercondition
        return TriggerAddCondition(OnEnter,b)
    endfunction
    public function RegisterOnEnterAllocated takes boolexpr b returns triggercondition
        return TriggerAddCondition(OnEnterAllocated,b)
    endfunction
    public function RegisterOnDeallocate takes boolexpr b returns triggercondition
        return TriggerAddCondition(OnDeallocate,b)
    endfunction
    
    //==============================================================================
    function GetIndexUnit takes integer index returns unit
        debug if index==0 then
        debug   call BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the unit of index 0.")
        debug elseif IndexUnit[index]==null then
        debug   call BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the unit of unassigned index.")
        debug endif
        
        return IndexUnit[index]
    endfunction
    
    function GetUnitId takes unit u returns integer
        debug if u==null then
        debug   call BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the id (inlines) of null unit.")
        debug elseif GetUnitUserData(u)==0 then
        debug   call BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to use GetUnitId (inlines) when you should be using GetUnitIndex (unit didn't pass filter).")
        debug endif
        
        return GetUnitUserData(u)
    endfunction
    
    globals//locals
        private integer getindex
    endglobals
    function GetUnitIndex takes unit u returns integer // Cannot be recursive.
        debug if u==null then
        debug   call BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the index of null unit.")
        debug endif
        
        set getindex=GetUnitUserData(u)
        
        if getindex==0 then
            // Get new index, from recycler first, else new.
            // Store the current index in getindex.
            if MaxRecycledIndex==0 then // Get new.
                set MaxIndex=MaxIndex+1
                set getindex=MaxIndex
            else // Get from recycle stack.
                set getindex=RecycledIndex[MaxRecycledIndex]
                set MaxRecycledIndex=MaxRecycledIndex-1
            endif
            
            // Store index on unit.
            call SetUnitUserData(u,getindex)
            set IndexUnit[getindex]=u
            
            static if USE_PERIODIC_RECYCLER then
                
                // Add index to recycle list.
                set MaxDecayingIndex=MaxDecayingIndex+1
                set DecayingIndex[MaxDecayingIndex]=getindex
                
            else
            
                // Add leave detection ability.
                call UnitAddAbility(ARStackUnit[ARStackLevel],LEAVE_DETECTION_ABILITY)
                call UnitMakeAbilityPermanent(ARStackUnit[ARStackLevel],true,LEAVE_DETECTION_ABILITY)
                
            endif
            
            // Do not fire things here. No AIDS structs will be made at this point.
        endif
        
        return getindex
    endfunction
    
    //==============================================================================
    public function AddLock takes integer index returns nothing
        set LockLevel[index]=LockLevel[index]+1
    endfunction
    public function RemoveLock takes integer index returns nothing
        set LockLevel[index]=LockLevel[index]-1
        
        static if not USE_PERIODIC_RECYCLER then
            if GetUnitUserData(IndexUnit[index])==0 and LockLevel[index]==0 then
                
                // Increment stack for recursion.
                set UndefendExpiringIndexLevel=UndefendExpiringIndexLevel+1
                set UndefendExpiringIndex[UndefendExpiringIndexLevel]=index
                
                // Fire things.
                call TriggerEvaluate(OnDeallocate)
                
                // Decrement stack for recursion.
                set UndefendExpiringIndexLevel=UndefendExpiringIndexLevel-1
                
                // Add the index to the recycler stack.
                set MaxRecycledIndex=MaxRecycledIndex+1
                set RecycledIndex[MaxRecycledIndex]=index
                
                // Null the unit.
                set IndexUnit[index]=null
                
            endif
        endif
    endfunction
    
    //==============================================================================
    static if USE_PERIODIC_RECYCLER then
        
        private function PeriodicRecycler takes nothing returns nothing
            if MaxDecayingIndex>0 then
                set DecayChecker=DecayChecker+1
                if DecayChecker>MaxDecayingIndex then
                    set DecayChecker=1
                endif
                if GetUnitUserData(IndexUnit[DecayingIndex[DecayChecker]])==0 then
                if LockLevel[DecayingIndex[DecayChecker]]==0 then
                    
                    // Fire things.
                    call TriggerEvaluate(OnDeallocate)
                    
                    // Add the index to the recycler stack.
                    set MaxRecycledIndex=MaxRecycledIndex+1
                    set RecycledIndex[MaxRecycledIndex]=DecayingIndex[DecayChecker]
                    
                    // Null the unit.
                    set IndexUnit[DecayingIndex[DecayChecker]]=null
                    
                    // Remove index from decay list.
                    set DecayingIndex[DecayChecker]=DecayingIndex[MaxDecayingIndex]
                    set MaxDecayingIndex=MaxDecayingIndex-1
                    
                endif
                endif
            endif
        endfunction
        
    else
        
        private function UndefendFilter takes nothing returns boolean
            return IsUnitType(GetFilterUnit(),UNIT_TYPE_DEAD)
        endfunction
        
        private function OnUndefendTimer takes nothing returns nothing
            loop
                exitwhen UndefendStackIndex==0
                
                set UndefendStackIndex=UndefendStackIndex-1
                set UndefendExpiringIndex[0]=UndefendIndex[UndefendStackIndex]
                
                if IndexUnit[UndefendExpiringIndex[0]]!=null then
                if GetUnitUserData(IndexUnit[UndefendExpiringIndex[0]])==0 then
                if LockLevel[UndefendExpiringIndex[0]]==0 then
                    
                    // Fire things.
                    call TriggerEvaluate(OnDeallocate)
                    
                    // Add the index to the recycler stack.
                    set MaxRecycledIndex=MaxRecycledIndex+1
                    set RecycledIndex[MaxRecycledIndex]=UndefendExpiringIndex[0]
                    
                    // Null the unit.
                    set IndexUnit[UndefendExpiringIndex[0]]=null
                    
                endif
                endif
                endif
                
            endloop
        endfunction
        
        globals//locals
            private integer UndefendFilterIndex
        endglobals
        private function OnUndefend takes nothing returns boolean
            if GetIssuedOrderId()==852056 then // If undefend then...
                set UndefendFilterIndex=GetUnitUserData(GetOrderedUnit())
                
                if UndefendIndex[UndefendStackIndex-1]!=UndefendFilterIndex then // Efficiency perk.
                    set UndefendIndex[UndefendStackIndex]=UndefendFilterIndex
                    set UndefendStackIndex=UndefendStackIndex+1
                    
                    call TimerStart(UndefendTimer,0,false,function OnUndefendTimer)
                endif
            endif
            
            return false
        endfunction
        
    endif
    
    //==============================================================================
    public function IndexEnum takes nothing returns boolean // Can be recursive...
        // Start by adding another level on the AR stack (for recursion's sake).
        set ARStackLevel=ARStackLevel+1
        
        // Store the current unit on the (new) top level of the AR stack.
        set ARStackUnit[ARStackLevel]=GetFilterUnit()
        
        if GetUnitUserData(ARStackUnit[ARStackLevel])==0 then // Has not been indexed.
            
            if UnitIndexingFilter(ARStackUnit[ARStackLevel]) then
                
                // Get new index, from recycler first, else new.
                // Store the current index on the (new) top level of the AR stack.
                if MaxRecycledIndex==0 then // Get new.
                    set MaxIndex=MaxIndex+1
                    set ARStackIndex[ARStackLevel]=MaxIndex
                else // Get from recycle stack.
                    set ARStackIndex[ARStackLevel]=RecycledIndex[MaxRecycledIndex]
                    set MaxRecycledIndex=MaxRecycledIndex-1
                endif
                
                // Store index on unit.
                call SetUnitUserData(ARStackUnit[ARStackLevel],ARStackIndex[ARStackLevel])
                set IndexUnit[ARStackIndex[ARStackLevel]]=ARStackUnit[ARStackLevel]
                
                static if USE_PERIODIC_RECYCLER then
                    
                    // Add index to recycle list.
                    set MaxDecayingIndex=MaxDecayingIndex+1
                    set DecayingIndex[MaxDecayingIndex]=ARStackIndex[ARStackLevel]
                    
                else
                    
                    // Add leave detection ability.
                    call UnitAddAbility(ARStackUnit[ARStackLevel],LEAVE_DETECTION_ABILITY)
                    call UnitMakeAbilityPermanent(ARStackUnit[ARStackLevel],true,LEAVE_DETECTION_ABILITY)
                    
                endif
                
                // Fire things.
                call TriggerEvaluate(OnEnter)
                
            else
                
                // The unit did not pass the filters, so does not need to be auto indexed.
                // However, for certain AIDS structs, it may still require indexing.
                // These structs may index the unit on their creation.
                // We flag that an index must be assigned by setting the current index to 0.
                set ARStackIndex[ARStackLevel]=0
                
                // Fire things.
                call TriggerEvaluate(OnEnter)
                
            endif
            
        endif
        
        // Decrement the stack.
        set ARStackLevel=ARStackLevel-1
        
        return false
    endfunction
    
    //==============================================================================
    private function InitAIDS takes nothing returns nothing
        local region r=CreateRegion()
        
        local group g=CreateGroup()
        local integer n=27
        
        static if USE_PERIODIC_RECYCLER then
            
            call TimerStart(UndefendTimer,PERIOD,true,function PeriodicRecycler)
            
        else
            
            local trigger t=CreateTrigger()
            
            loop
                call TriggerRegisterPlayerUnitEvent(t,Player(n),EVENT_PLAYER_UNIT_ISSUED_ORDER,Filter(function UndefendFilter))
                call SetPlayerAbilityAvailable(Player(n),LEAVE_DETECTION_ABILITY,false)
                // Capture "undefend" orders.
                exitwhen n==0
                set n=n-1
            endloop
            set n=27
            
            call TriggerAddCondition(t,Filter(function OnUndefend))
            set t=null
            
        endif
        
        // This must be done first, due to recursion. :)
        call RegionAddRect(r,GetWorldBounds())
        call TriggerRegisterEnterRegion(CreateTrigger(),r,Filter(function IndexEnum))
        set r=null
        
        loop
            call GroupEnumUnitsOfPlayer(g,Player(n),Filter(function IndexEnum))
            //Enum every non-filtered unit on the map during initialization and assign it a unique
            //index. By using GroupEnumUnitsOfPlayer, even units with Locust can be detected.
            exitwhen n==0
            set n=n-1
        endloop
        call DestroyGroup(g)
        set g=null
    endfunction
    
    //==============================================================================
    public struct DEFAULT extends array
        method AIDS_onCreate takes nothing returns nothing
        endmethod
        method AIDS_onDestroy takes nothing returns nothing
        endmethod
        
        static method AIDS_filter takes unit u returns boolean
            return UnitIndexingFilter(u)
        endmethod
        
        static method AIDS_onInit takes nothing returns nothing
        endmethod
    endstruct
    
    //===========================================================================
    //  Never create or destroy AIDS structs directly.
    //  Also, do not initialise members except by using the AIDS_onCreate method.
    //===========================================================================
    //! textmacro AIDS
        // This magic line makes default methods get called which do nothing
        // if the methods are otherwise undefined.
        private static delegate AIDS_DEFAULT AIDS_DELEGATE=0
        
        //-----------------------------------------------------------------------
        // Gotta know whether or not to destroy on deallocation...
        private boolean AIDS_instanciated
        
        //-----------------------------------------------------------------------
        static method operator[] takes unit whichUnit returns thistype
            return GetUnitId(whichUnit)
        endmethod
        
        method operator unit takes nothing returns unit
            // Allows structVar.unit to return the unit.
            return GetIndexUnit(this)
        endmethod
        
        //-----------------------------------------------------------------------
        method AIDS_addLock takes nothing returns nothing
            call AIDS_AddLock(this)
        endmethod
        method AIDS_removeLock takes nothing returns nothing
            call AIDS_RemoveLock(this)
        endmethod
        
        //-----------------------------------------------------------------------
        private static method AIDS_onEnter takes nothing returns boolean
            // At this point, the unit might not have been assigned an index.
            if thistype.AIDS_filter(AIDS_GetEnteringIndexUnit()) then
                // Flag it for destruction on deallocation.
                set thistype(AIDS_GetIndexOfEnteringUnit()).AIDS_instanciated=true
                // Can use inlining "Assigned" function now, as it must be assigned.
                call thistype(AIDS_GetIndexOfEnteringUnitAllocated()).AIDS_onCreate()
            endif
            
            return false
        endmethod
        
        private static method AIDS_onEnterAllocated takes nothing returns boolean
            // At this point, the unit must have been assigned an index.
            if thistype.AIDS_filter(AIDS_GetEnteringIndexUnit()) then
                // Flag it for destruction on deallocation. Slightly faster!
                set thistype(AIDS_GetIndexOfEnteringUnitAllocated()).AIDS_instanciated=true
                // Can use inlining "Assigned" function now, as it must be assigned.
                call thistype(AIDS_GetIndexOfEnteringUnitAllocated()).AIDS_onCreate()
            endif
            
            return false
        endmethod
        
        private static method AIDS_onDeallocate takes nothing returns boolean
            if thistype(AIDS_GetDecayingIndex()).AIDS_instanciated then
                call thistype(AIDS_GetDecayingIndex()).AIDS_onDestroy()
                // Unflag destruction on deallocation.
                set thistype(AIDS_GetDecayingIndex()).AIDS_instanciated=false
            endif
            
            return false
        endmethod
        
        //-----------------------------------------------------------------------
        private static method onInit takes nothing returns nothing
            call AIDS_RegisterOnEnter(Filter(function thistype.AIDS_onEnter))
            call AIDS_RegisterOnEnterAllocated(Filter(function thistype.AIDS_onEnterAllocated))
            call AIDS_RegisterOnDeallocate(Filter(function thistype.AIDS_onDeallocate))
            
            // Because I robbed you of your struct's onInit method.
            call thistype.AIDS_onInit()
        endmethod
    //! endtextmacro
endlibrary

library PUI uses AIDS
    //===========================================================================
    //  Allowed PUI_PROPERTY TYPES are: unit, integer, real, boolean, string
    //  Do NOT put handles that need to be destroyed here (timer, trigger, ...)
    //  Instead put them in a struct and use PUI textmacro
    //===========================================================================
    //! textmacro PUI_PROPERTY takes VISIBILITY, TYPE, NAME, DEFAULT
    $VISIBILITY$ struct $NAME$
        private static unit   array pui_unit
        private static $TYPE$ array pui_data
        
        //-----------------------------------------------------------------------
        //  Returns default value when first time used
        //-----------------------------------------------------------------------
        static method operator[] takes unit whichUnit returns $TYPE$
            local integer pui = GetUnitId(whichUnit) // Changed from GetUnitIndex.
            if .pui_unit[pui] != whichUnit then
                set .pui_unit[pui] = whichUnit
                set .pui_data[pui] = $DEFAULT$
            endif
            return .pui_data[pui]
        endmethod
        
        //-----------------------------------------------------------------------
        static method operator[]= takes unit whichUnit, $TYPE$ whichData returns nothing
            local integer pui = GetUnitIndex(whichUnit)
            set .pui_unit[pui] = whichUnit
            set .pui_data[pui] = whichData
        endmethod
    endstruct
    //! endtextmacro

    //===========================================================================
    //  Never destroy PUI structs directly.
    //  Use .release() instead, will call .destroy()
    //===========================================================================
    //! textmacro PUI
        private static unit    array pui_unit
        private static integer array pui_data
        private static integer array pui_id
        
        //-----------------------------------------------------------------------
        //  Returns zero if no struct is attached to unit
        //-----------------------------------------------------------------------
        static method operator[] takes unit whichUnit returns integer
            local integer pui = GetUnitId(whichUnit) // Changed from GetUnitIndex.
            // Switched the next two lines for optimisation.
            if .pui_unit[pui] != whichUnit then
                if .pui_data[pui] != 0 then
                    // recycled index detected
                    call .destroy(.pui_data[pui])
                    set .pui_unit[pui] = null
                    set .pui_data[pui] = 0            
                endif
            endif
            return .pui_data[pui]
        endmethod
        
        //-----------------------------------------------------------------------
        //  This will overwrite already attached struct if any
        //-----------------------------------------------------------------------
        static method operator[]= takes unit whichUnit, integer whichData returns nothing
            local integer pui = GetUnitIndex(whichUnit)
            if .pui_data[pui] != 0 then
                call .destroy(.pui_data[pui])
            endif
            set .pui_unit[pui] = whichUnit
            set .pui_data[pui] = whichData
            set .pui_id[whichData] = pui
        endmethod

        //-----------------------------------------------------------------------
        //  If you do not call release struct will be destroyed when unit handle gets recycled
        //-----------------------------------------------------------------------
        method release takes nothing returns nothing
            local integer pui= .pui_id[integer(this)]
            call .destroy()
            set .pui_unit[pui] = null
            set .pui_data[pui] = 0
        endmethod
    //! endtextmacro
endlibrary

library AutoIndex uses AIDS
    module AutoData
        private static thistype array data
        
        // Fixed up the below to use thsitype instead of integer.
        static method operator []= takes unit u, thistype i returns nothing
            set .data[GetUnitId(u)] = i //Just attaching a struct to the unit
        endmethod                       //using the module's thistype array.
        
        static method operator [] takes unit u returns thistype
            return .data[GetUnitId(u)] //Just returning the attached struct.
        endmethod
    endmodule
endlibrary