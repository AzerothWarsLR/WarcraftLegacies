
library Table
//***************************************************************
//* Table object 3.1
//* ------------
//*
//*   set t=Table.create() - instanceates a new table object
//*   call t.destroy()     - destroys it
//*   t[1234567]           - Get value for key 1234567
//*                          (zero if not assigned previously)
//*   set t[12341]=32      - Assigning it.
//*   call t.flush(12341)  - Flushes the stored value, so it
//*                          doesn't use any more memory
//*   t.exists(32)         - Was key 32 assigned? Notice
//*                          that flush() unassigns values.
//*   call t.reset()       - Flushes the whole contents of the
//*                          Table.
//*
//*   call t.destroy()     - Does reset() and also recycles the id.
//*
//*   If you use HandleTable instead of Table, it is the same
//* but it uses handles as keys, the same with StringTable.
//*
//*  You can use Table on structs' onInit  if the struct is
//* placed in a library that requires Table or outside a library.
//*
//*  You can also do 2D array syntax if you want to touch
//* mission keys directly, however, since this is shared space
//* you may want to prefix your mission keys accordingly:
//*
//*  set Table["thisstring"][ 7 ] = 2
//*  set Table["thisstring"][ 5 ] = Table["thisstring"][7]
//*
//***************************************************************

//=============================================================
    globals
        private constant integer MAX_INSTANCES=8100 //400000
        //Feel free to change max instances if necessary, it will only affect allocation
        //speed which shouldn't matter that much.

    //=========================================================
        private hashtable ht = InitHashtable()
    endglobals

    private struct GTable[MAX_INSTANCES]

        method reset takes nothing returns nothing
            call FlushChildHashtable(ht, integer(this) )
        endmethod

        private method onDestroy takes nothing returns nothing
            call this.reset()
        endmethod

    endstruct

    //Hey: Don't instanciate other people's textmacros that you are not supposed to, thanks.
    //! textmacro Table__make takes name, type, key
    struct $name$ extends GTable

        method operator [] takes $type$ key returns integer
            return LoadInteger(ht, integer(this), $key$)
        endmethod

        method operator []= takes $type$ key, integer value returns nothing
            call SaveInteger(ht,  integer(this)  ,$key$, value)
        endmethod

        method flush takes $type$ key returns nothing
            call RemoveSavedInteger(ht, integer(this), $key$)
        endmethod

        method exists takes $type$ key returns boolean
            return HaveSavedInteger( ht,  integer(this)  ,$key$)
        endmethod

        static method flush2D takes string firstkey returns nothing
            call $name$(- StringHash(firstkey)).reset()
        endmethod

        static method operator [] takes string firstkey returns $name$
            return $name$(- StringHash(firstkey) )
        endmethod

    endstruct
    //! endtextmacro

    //! runtextmacro Table__make("Table","integer","key" )
    //! runtextmacro Table__make("StringTable","string", "StringHash(key)" )
    //! runtextmacro Table__make("HandleTable","handle","GetHandleId(key)" )

endlibrary