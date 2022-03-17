
public class Table{
//***************************************************************
//* Table object 31
//* ------------
//*
//*   set t=Table.create() - instanceates a new table object
//*   call t.destroy()     - destroys it
//*   t[1234567]           - Get value for key 1234567
//*                          (zero if not assigned previously)
//*   set t[12341]=32      - Assigning it.
//*   call t.flush(12341)  - Flushes the stored value, so it
//*                          doesn)t use any more memory
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

//* placed in a library that requires Table or outside a library.
//*
//*  You can also do 2D[] syntax if you want to touch
//* mission keys directly, however, since this is shared space
//* you may want to prefix your mission keys accordingly:
//*
//*  set Table["thisstring"][ 7 ] = 2
//*  set Table["thisstring"][ 5 ] = Table["thisstring"][7]
//*
//***************************************************************

//=============================================================
    
        private const int MAX_INSTANCES=8100 ;//400000
        //Feel free to change max instances if necessary, it will only affect allocation
        //speed which shouldn)t matter that much.

    //=========================================================
        private hashtable ht = InitHashtable();
    



        void retakes  ){
            FlushChildHashtable(ht, integer(this) );
        }

        private void onDestroy( ){
            this.reset();
        }



    //Hey: Don)t instanciate other people)s textmacros that you are not supposed to, thanks.
    //! textmacro Table__make takes name, type, key


        integer operator []($type$ key ){
            return LoadInteger(ht, integer(this), $key$);
        }

        void operator []=($type$ key, int value ){
            SaveInteger(ht,  integer(this)  ,$key$, value);
        }

        void flush($type$ key ){
            RemoveSavedInteger(ht, integer(this), $key$);
        }

        boolean exists($type$ key ){
            return HaveSavedInteger( ht,  integer(this)  ,$key$);
        }

        static void flush2D(string firstkey ){
            $name$(- StringHash(firstkey)).reset();
        }

        static $name$ operator [](string firstkey ){
            return $name$(- StringHash(firstkey) );
        }


    //! endtextmacro

    //! runtextmacro Table__make("Table","integer","key" )
    //! runtextmacro Table__make("StringTable","string", "StringHash(key)" )
    //! runtextmacro Table__make("HandleTable","handle","GetHandleId(key)" )

}
