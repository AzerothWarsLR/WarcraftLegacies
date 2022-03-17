//
//        _   ___ ___  ___    _______________________________________________
//       /_\ |_ _|   \/ __|   ||     A D V A N C E D   I N D E X I N G     ||
//      / _ \ | || |) \__ \   ||                  A N D                    ||
//     /_/ \_\___|___/|___/   ||         D A T A   S T O R A G E           ||
//            By Jesus4Lyf    ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//                                                                    v 110
//      What is AIDS?
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          AIDS assigns unique integers between 1 and 8191 to units which enter
//          the map. These can be used for[]s and data attaching.
//

//          when units enter the map, and filtering which units should be indexed

//
//      How to implement?
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          Simply create a new trigger object called AIDS, go to )Edit -> Convert
//          to Custom Text), and replace everything that)s there with this script.
//
//          Save the map, close it, reopen it, and then delete the "!" from the
//          FAR left side of the next lines (so "external" will line up with this line):
//          external ObjectMerger w3a Adef AIDS anam "State Detection" ansf "(AIDS)" aart "" arac 0
//
//          At the top of the script, there is a )UnitIndexingFilter) constant
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
//              - Always use this if )UnitIndexingFilter) simply returns true.
//
//          function GetUnitIndex takes unit u returns integer
//              - This will return the index of a unit if it has one, or assign
//                an index if the unit doesn)t have one (and return the new index).
//              - Use this if )UnitIndexingFilter) doesn)t return true.
//
//          function GetIndexUnit takes integer index returns unit
//              - This returns the unit which has been assigned the )index).
//
//      AIDS Structs:
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯



//            are automatically created when an appropriate unit enters the map.
//          - You cannot give members default values in their declaration.
//            (eg: private integer i=5 is not allowed)
//          - You cannot use[] members.

//            functions and enforce the above so there will be no mistakes.

//              - AIDS_onCreate takes nothing returns nothing

//                  - In here you can assign members their default values, which
//                    you would usually assign in their declarations.
//                    (eg: set this.i=5)
//              - AIDS_onDestroy takes nothing returns nothing

//                  - This is your substitute to the normal onDestroy method.
//              - AIDS_filter takes unit u returns boolean
//                  - This is similar to the constant filter in the main system.
//                  - Each unit that enters the map will be tested by each AIDS


//                    have its AIDS_onCreate method called, and later have its
//                    AIDS_onDestroy method called when the index is recycled.
//                  - Not declaring this will use the default AIDS filter instead.
//              - AIDS_onInit takes nothing returns nothing
//                  - This is because I stole your onInit function with my textmacro.



//            a unit inlines to a single native call, and you can typecast between


//          - You can call .AIDS_addLock() and AIDS_removeLock() to increase or

//            not 0, it will not be destroyed until it is reduced to 0 Locks just



//
//      PUI and AutoIndex:
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          - AIDS includes the PUI textmacros and the AutoIndex module, because
//            these systems are not compatible with AIDS but have valid and distinct
//            uses.

//            because they are not created for all units, just those targetted by
//            the spell (or whatever else is necessary).
//          - The AutoData module is good for very simple[] syntax for data
//            attachment (although I don)t recommend that people actually use it,
//            it)s here mostly for compatability). Note that unlike the PUI textmacros,
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
//            )Alternative Index Detection System), but obviously I came up with
//            something better. In fact, I)d say it looks like the acronym was
//            an accident. Kinda neat, don)t you think? :P
//
//      Final Notes:
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          - With most systems, I wouldn)t usually add substitutes for alternative
//            systems. However, UnitData systems are an exception, because they
//            are incompatible with eachother. Since using this system forbids
//            people from using the real PUI or AutoIndex, and a lot of resources
//            use either of these, it made sense not to break them all.
//
//          - If this documentation confused you as to how to use the system, just
//            leave everything as default and use GetUnitId everywhere.
//
//          - To use this like PUI (if you don)t like spamming indices) simply
//            make the AIDS filter return false, and use GetUnitIndex.
//
public class AIDS{
    //==============================================================================
    // Configurables
    //
    
        private const boolean USE_PERIODIC_RECYCLER = false;
        private const float PERIOD = 003125 ;// Recycles 32 units/second max.
                                               // Lower to be able to recycle faster.
                                               // Only used if USE_PERIODIC_RECYCLER
                                               // is set to true.

        private const int LEAVE_DETECTION_ABILITY = FourCC(A0WI);
    

    private static boolean UnitIndexingFilter(unit u ){
        return true;
    }

    //==============================================================================
    // System code
    //
    
        // The unit stored at an index.
        private unit[] IndexUnit;
        private int[] LockLevel;
    

    //==============================================================================
    
        // Recycle stack
        private int[] RecycledIndex;
        private int MaxRecycledIndex = 0;

        // Previous highest index
        private int MaxIndex = 0;
    

    //==============================================================================
    
        private int[] DecayingIndex;
        private int MaxDecayingIndex=0;
        private int DecayChecker=0;
    

    
        private timer UndefendTimer=CreateTimer();
        private int[] UndefendIndex;
        private int UndefendStackIndex=0;
    
    
        private int[] UndefendExpiringIndex;
        private int UndefendExpiringIndexLevel=0;
    

    //==============================================================================
    
        // The Add/Remove stack (or assign/recycle stack).
        //
        // Indexing can become recusive since units can be created on index
        // assignment or deallocation.
        // To support this, a stack is used to store the event response results.
        private int ARStackLevel=0;
        private int[] ARStackIndex;
        private unit   [] ARStackUnit;

        // A later discovery revealed that the Add/Remove stack did not need to be
        // used for deallocation. The alternative used works fine...
    

    public const static unit GetEnteringIndexUnit( ){
        return ARStackUnit[ARStackLevel];
    }

    public static integer GetIndexOfEnteringUnit( ){


        if (ARStackIndex[ARStackLevel]==0){
            // Get new index, from recycler first, else new.
            // Store the current index on the (new) top level of the AR stack.
            if (MaxRecycledIndex==0){ // Get new.
                MaxIndex=MaxIndex+1
                ARStackIndex[ARStackLevel]=MaxIndex
            }else { // Get from recycle stack.
                ARStackIndex[ARStackLevel]=RecycledIndex[MaxRecycledIndex]
                MaxRecycledIndex=MaxRecycledIndex-1
            }

            // Store index on unit.
            SetUnitUserData(ARStackUnit[ARStackLevel],ARStackIndex[ARStackLevel]);
            IndexUnit[ARStackIndex[ARStackLevel]]=ARStackUnit[ARStackLevel]

            // Add index to recycle list.
            MaxDecayingIndex=MaxDecayingIndex+1
            DecayingIndex[MaxDecayingIndex]=ARStackIndex[ARStackLevel]
        }

        return ARStackIndex[ARStackLevel];
    }

    public const static integer GetIndexOfEnteringUnitAllocated( ){

        return ARStackIndex[ARStackLevel];
    }
    public const static integer GetDecayingIndex( ){
        static if (USE_PERIODIC_RECYCLER){
            return DecayingIndex[DecayChecker];
        }else {
            return UndefendExpiringIndex[UndefendExpiringIndexLevel];
        }
    }

    //==============================================================================
    

        private trigger OnEnter=CreateTrigger();
        // The same, but for when units pass the initial filter anyway.
        private trigger OnEnterAllocated=CreateTrigger();

        private trigger OnDeallocate=CreateTrigger();
    

    public static triggercondition RegisterOnEnter(boolexpr b ){
        return TriggerAddCondition(OnEnter,b);
    }
    public static triggercondition RegisterOnEnterAllocated(boolexpr b ){
        return TriggerAddCondition(OnEnterAllocated,b);
    }
    public static triggercondition RegisterOnDeallocate(boolexpr b ){
        return TriggerAddCondition(OnDeallocate,b);
    }

    //==============================================================================
    static unit GetIndexUnit(int index ){
        debug if (index==0){
        debug   BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the unit of index 0");
        debug }else if (IndexUnit[index]==null){
        debug   BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the unit of unassigned index.");
        debug }

        return IndexUnit[index];
    }

    static integer GetUnitId(unit u ){
        debug if (u==null){
        debug   BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the id (inlines) of null unit.");
        debug }else if (GetUnitUserData(u)==0){
        debug   BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to use GetUnitId (inlines) when you should be using GetUnitIndex (unit didnFourCC(t pass filter).");
        debug }

        return GetUnitUserData(u);
    }

    //locals
        private int getindex;
    
    static  GetUnitIndex(unit u ){// Cannot be recursive.
        debug if (u==null){
        debug   BJDebugMsg("|cFFFF0000Error using AIDS:|r Trying to get the index of null unit.");
        debug }

        getindex=GetUnitUserData(u)

        if (getindex==0){
            // Get new index, from recycler first, else new.
            // Store the current index in getindex.
            if (MaxRecycledIndex==0){ // Get new.
                MaxIndex=MaxIndex+1
                getindex=MaxIndex
            }else { // Get from recycle stack.
                getindex=RecycledIndex[MaxRecycledIndex]
                MaxRecycledIndex=MaxRecycledIndex-1
            }

            // Store index on unit.
            SetUnitUserData(u,getindex);
            IndexUnit[getindex]=u

            static if (USE_PERIODIC_RECYCLER){

                // Add index to recycle list.
                MaxDecayingIndex=MaxDecayingIndex+1
                DecayingIndex[MaxDecayingIndex]=getindex

            }else {

                // Add leave detection ability.
                UnitAddAbility(ARStackUnit[ARStackLevel],LEAVE_DETECTION_ABILITY);
                UnitMakeAbilityPermanent(ARStackUnit[ARStackLevel],true,LEAVE_DETECTION_ABILITY);

            }


        }

        return getindex;
    }

    //==============================================================================
    public static void AddLock(int index ){
        LockLevel[index]=LockLevel[index]+1
    }
    public static void RemoveLock(int index ){
        LockLevel[index]=LockLevel[index]-1

        static if (!USE_PERIODIC_RECYCLER){
            if (GetUnitUserData(IndexUnit[index])==0 && LockLevel[index]==0){

                // Increment stack for recursion.
                UndefendExpiringIndexLevel=UndefendExpiringIndexLevel+1
                UndefendExpiringIndex[UndefendExpiringIndexLevel]=index

                // Fire things.
                TriggerEvaluate(OnDeallocate);

                // Decrement stack for recursion.
                UndefendExpiringIndexLevel=UndefendExpiringIndexLevel-1

                // Add the index to the recycler stack.
                MaxRecycledIndex=MaxRecycledIndex+1
                RecycledIndex[MaxRecycledIndex]=index

                // Null the unit.
                IndexUnit[index]=null

            }
        }
    }

    //==============================================================================
    static if (USE_PERIODIC_RECYCLER){

        private static void PeriodicRecycler( ){
            if (MaxDecayingIndex>0){
                DecayChecker=DecayChecker+1
                if (DecayChecker>MaxDecayingIndex){
                    DecayChecker=1
                }
                if (GetUnitUserData(IndexUnit[DecayingIndex[DecayChecker]])==0){
                if (LockLevel[DecayingIndex[DecayChecker]]==0){

                    // Fire things.
                    TriggerEvaluate(OnDeallocate);

                    // Add the index to the recycler stack.
                    MaxRecycledIndex=MaxRecycledIndex+1
                    RecycledIndex[MaxRecycledIndex]=DecayingIndex[DecayChecker]

                    // Null the unit.
                    IndexUnit[DecayingIndex[DecayChecker]]=null

                    // Remove index from decay list.
                    DecayingIndex[DecayChecker]=DecayingIndex[MaxDecayingIndex]
                    MaxDecayingIndex=MaxDecayingIndex-1

                }
                }
            }
        }

    }else {

        private static boolean UndefendFilter( ){
            return IsUnitType(GetFilterUnit(),UNIT_TYPE_DEAD);
        }

        private static void OnUndefendTimer( ){
            while(true){
                if ( UndefendStackIndex==0){ break; }

                UndefendStackIndex=UndefendStackIndex-1
                UndefendExpiringIndex[0]=UndefendIndex[UndefendStackIndex]

                if (IndexUnit[UndefendExpiringIndex[0]]!=null){
                if (GetUnitUserData(IndexUnit[UndefendExpiringIndex[0]])==0){
                if (LockLevel[UndefendExpiringIndex[0]]==0){

                    // Fire things.
                    TriggerEvaluate(OnDeallocate);

                    // Add the index to the recycler stack.
                    MaxRecycledIndex=MaxRecycledIndex+1
                    RecycledIndex[MaxRecycledIndex]=UndefendExpiringIndex[0]

                    // Null the unit.
                    IndexUnit[UndefendExpiringIndex[0]]=null

                }
                }
                }

            }
        }

        //locals
            private int UndefendFilterIndex;
        
        private static boolean OnUndefend( ){
            if (GetIssuedOrderId()==852056){ // If undefend then...
                UndefendFilterIndex=GetUnitUserData(GetOrderedUnit())

                if (UndefendIndex[UndefendStackIndex-1]!=UndefendFilterIndex){ // Efficiency perk.
                    UndefendIndex[UndefendStackIndex]=UndefendFilterIndex
                    UndefendStackIndex=UndefendStackIndex+1

                    TimerStart(UndefendTimer,0,false,function OnUndefendTimer);
                }
            }

            return false;
        }

    }

    //==============================================================================
    public static  IndexEnum( ){// Can be recursive...
        // Start by adding another level on the AR stack (for recursion)s sake).
        ARStackLevel=ARStackLevel+1

        // Store the current unit on the (new) top level of the AR stack.
        ARStackUnit[ARStackLevel]=GetFilterUnit()

        if (GetUnitUserData(ARStackUnit[ARStackLevel])==0){ // Has not been indexed.

            if (UnitIndexingFilter(ARStackUnit[ARStackLevel])){

                // Get new index, from recycler first, else new.
                // Store the current index on the (new) top level of the AR stack.
                if (MaxRecycledIndex==0){ // Get new.
                    MaxIndex=MaxIndex+1
                    ARStackIndex[ARStackLevel]=MaxIndex
                }else { // Get from recycle stack.
                    ARStackIndex[ARStackLevel]=RecycledIndex[MaxRecycledIndex]
                    MaxRecycledIndex=MaxRecycledIndex-1
                }

                // Store index on unit.
                SetUnitUserData(ARStackUnit[ARStackLevel],ARStackIndex[ARStackLevel]);
                IndexUnit[ARStackIndex[ARStackLevel]]=ARStackUnit[ARStackLevel]

                static if (USE_PERIODIC_RECYCLER){

                    // Add index to recycle list.
                    MaxDecayingIndex=MaxDecayingIndex+1
                    DecayingIndex[MaxDecayingIndex]=ARStackIndex[ARStackLevel]

                }else {

                    // Add leave detection ability.
                    UnitAddAbility(ARStackUnit[ARStackLevel],LEAVE_DETECTION_ABILITY);
                    UnitMakeAbilityPermanent(ARStackUnit[ARStackLevel],true,LEAVE_DETECTION_ABILITY);

                }

                // Fire things.
                TriggerEvaluate(OnEnter);

            }else {

                // The unit did not pass the filters, so does not need to be auto indexed.


                // We flag that an index must be assigned by setting the current index to 0
                ARStackIndex[ARStackLevel]=0

                // Fire things.
                TriggerEvaluate(OnEnter);

            }

        }

        // Decrement the stack.
        ARStackLevel=ARStackLevel-1

        return false;
    }

    //==============================================================================
    private static void InitAIDS( ){
        region r=CreateRegion();

        group g=CreateGroup();
        int n=27;

        static if (USE_PERIODIC_RECYCLER){

            TimerStart(UndefendTimer,PERIOD,true,function PeriodicRecycler);

        }else {

            trigger t=CreateTrigger();

            while(true){
                TriggerRegisterPlayerUnitEvent(t,Player(n),EVENT_PLAYER_UNIT_ISSUED_ORDER,Filter(function UndefendFilter));
                SetPlayerAbilityAvailable(Player(n),LEAVE_DETECTION_ABILITY,false);
                // Capture "undefend" orders.
                if ( n==0){ break; }
                n=n-1
            }
            n=27

            TriggerAddCondition(t,Filter(function OnUndefend));
            t=null

        }

        // This must be done first, due to recursion. :)
        RegionAddRect(r,GetWorldBounds());
        TriggerRegisterEnterRegion(CreateTrigger(),r,Filter(function IndexEnum));
        r=null

        while(true){
            GroupEnumUnitsOfPlayer(g,Player(n),Filter(function IndexEnum));
            //Enum every non-filtered unit on the map during initialization and assign it a unique
            //index. By using GroupEnumUnitsOfPlayer, even units with Locust can be detected.
            if ( n==0){ break; }
            n=n-1
        }
        DestroyGroup(g);
        g=null
    }

    //==============================================================================

        void AIDS_onCreate( ){
        }
        void AIDS_onDestroy( ){
        }

        static boolean AIDS_filter(unit u ){
            return UnitIndexingFilter(u);
        }

        static void AIDS_onInit( ){
        }


    //===========================================================================

    //  Also, do not initialise members except by using the AIDS_onCreate method.
    //===========================================================================
    //! textmacro AIDS
        // This magic line makes default methods get called which do nothing
        // if the methods are otherwise undefined.
        private static delegate AIDS_DEFAULT AIDS_DELEGATE=0;

        //-----------------------------------------------------------------------
        // Gotta know whether or not to destroy on deallocation...
        private boolean AIDS_instanciated;

        //-----------------------------------------------------------------------
        static thistype operator[](unit whichUnit ){
            return GetUnitId(whichUnit);
        }

        unit operator unit( ){

            return GetIndexUnit(this);
        }

        //-----------------------------------------------------------------------
        void AIDS_addLock( ){
            AIDS_AddLock(this);
        }
        void AIDS_removeLock( ){
            AIDS_RemoveLock(this);
        }

        //-----------------------------------------------------------------------
        private static boolean AIDS_onEnter( ){
            // At this point, the unit might not have been assigned an index.
            if (thistype.AIDS_filter(AIDS_GetEnteringIndexUnit())){

                thistype(AIDS_GetIndexOfEnteringUnit()).AIDS_instanciated=true
                // Can use inlining "Assigned" function now, as it must be assigned.
                thistype(AIDS_GetIndexOfEnteringUnitAllocated()).AIDS_onCreate();
            }

            return false;
        }

        private static boolean AIDS_onEnterAllocated( ){
            // At this point, the unit must have been assigned an index.
            if (thistype.AIDS_filter(AIDS_GetEnteringIndexUnit())){

                thistype(AIDS_GetIndexOfEnteringUnitAllocated()).AIDS_instanciated=true
                // Can use inlining "Assigned" function now, as it must be assigned.
                thistype(AIDS_GetIndexOfEnteringUnitAllocated()).AIDS_onCreate();
            }

            return false;
        }

        private static boolean AIDS_onDeallocate( ){
            if (thistype(AIDS_GetDecayingIndex()).AIDS_instanciated){
                thistype(AIDS_GetDecayingIndex()).AIDS_onDestroy();

                thistype(AIDS_GetDecayingIndex()).AIDS_instanciated=false
            }

            return false;
        }

        //-----------------------------------------------------------------------
        private static void onInit( ){
            AIDS_RegisterOnEnter(Filter(function thistype.AIDS_onEnter));
            AIDS_RegisterOnEnterAllocated(Filter(function thistype.AIDS_onEnterAllocated));
            AIDS_RegisterOnDeallocate(Filter(function thistype.AIDS_onDeallocate));


            thistype.AIDS_onInit();
        }
    //! endtextmacro
}

public class PUI{
    //===========================================================================
    //  Allowed PUI_PROPERTY TYPES are: unit, integer, real, boolean, string
    //  Do NOT put handles that need to be destroyed here (timer, trigger, ...)

    //===========================================================================
    //! textmacro PUI_PROPERTY takes VISIBILITY, TYPE, NAME, DEFAULT

        private static unit  [] pui_unit;
        private static $TYPE$[] pui_data;

        //-----------------------------------------------------------------------
        //  Returns default value when first time used
        //-----------------------------------------------------------------------
        static $TYPE$ operator[](unit whichUnit ){
            int pui = GetUnitId(whichUnit) ;// Changed from GetUnitIndex.
            if (.pui_unit[pui] != whichUnit){
                .pui_unit[pui] = whichUnit;
                .pui_data[pui] = $DEFAULT$;
            }
            return .pui_data[pui];
        }

        //-----------------------------------------------------------------------
        static void operator[]=(unit whichUnit, $TYPE$ whichData ){
            int pui = GetUnitIndex(whichUnit);
            .pui_unit[pui] = whichUnit;
            .pui_data[pui] = whichData;
        }

    //! endtextmacro

    //===========================================================================

    //  Use .release() instead, will call .destroy()
    //===========================================================================
    //! textmacro PUI
        private static unit   [] pui_unit;
        private static int[] pui_data;
        private static int[] pui_id;

        //-----------------------------------------------------------------------

        //-----------------------------------------------------------------------
        static integer operator[](unit whichUnit ){
            int pui = GetUnitId(whichUnit) ;// Changed from GetUnitIndex.
            // Switched the next two lines for optimisation.
            if (.pui_unit[pui] != whichUnit){
                if (.pui_data[pui] != 0){
                    // recycled index detected
                    .destroy(.pui_data[pui]);
                    .pui_unit[pui] = null;
                    .pui_data[pui] = 0;
                }
            }
            return .pui_data[pui];
        }

        //-----------------------------------------------------------------------

        //-----------------------------------------------------------------------
        static void operator[]=(unit whichUnit, int whichData ){
            int pui = GetUnitIndex(whichUnit);
            if (.pui_data[pui] != 0){
                .destroy(.pui_data[pui]);
            }
            .pui_unit[pui] = whichUnit;
            .pui_data[pui] = whichData;
            .pui_id[whichData] = pui;
        }

        //-----------------------------------------------------------------------

        //-----------------------------------------------------------------------
        void release( ){
            int pui= .pui_id[integer(this)];
            .destroy();
            .pui_unit[pui] = null;
            .pui_data[pui] = 0;
        }
    //! endtextmacro
}

public class AutoIndex{
    module AutoData
        private static thistype[] data;

        // Fixed up the below to use thsitype instead of integer.
        static void operator []=(unit u, thistype i ){

        }                       //using the module)s thistype[].

        static thistype operator [](unit u ){

        }
    endmodule
}
