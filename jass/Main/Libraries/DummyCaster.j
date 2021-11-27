//
//      ___  _   _  __  __  __  __ __  __
//     |   \| | | |/  |/  |/  |/  |\ \/ /
//     | |) | |_| | / | / | / | / | \  /
//     |___/\____/_/|__/|_|/|__/|_|_|_|__
//         /  _/ /_\ / __\_   _|  __|  _ \
//        |  |_ / _ \\__ \ | | |  __|  _ /
//         \___\_/ \_\___/ |_| |____|_|\_\         By Jesus4Lyf
//
//      What is DummyCaster?
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          DummyCaster is designed to be the perfect dummy caster for dummy abilities.
//          There has been a lot of thought put into this unit type, and dummy casting
//          has evolved over the years of WC3 mapping. These days, best practise is that
//          damage is triggered, and the effects of an ability such as slow or stun
//          are applied through a global dummy caster (which is owned by Neutral Hostile).
//
//          A lot of thought has been put into this unit. It has no mana, because if
//          it had mana then it could potentially run out and suddenly fail without
//          an apparent reason. It has no movement speed or casting time, allowing it
//          to instantly cast. Hence, this library only exposes one thing. A "DUMMY"
//          unit constant (global variable).
//
//          You may provide this unit with a model by having a model imported into the
//          path "Dummy.mdx". The purpose of this is allowing the same unit type
//          to be created dynamically for special effect attachment.
//
//          The rawcode of the "Dummy Caster" type is 'dumy'.
//
//          Upon issueing the order to cast a spell using the DUMMY global, as long as
//          the spell is instant, the casting will occur before the next line of
//          JASS code is executed, meaning you can cast in a loop or a ForGroup, etc
//          without bugging or dynamically creating (or recycling) dummies.
//
//          The initialiser is in a struct because struct onInit methods are called
//          before library "initializers". This allows abilities to be added on the
//          constant DUMMY unit on map initialisation.
//
//          Spells that this dummy casts should have no mana cost, no cooldown, no
//          cast time and infinite range. They also must be able to be cast from a
//          Neutral Hostile unit to your target, meaning they must be castable on
//          enemies (if you must, you can change the owner of the dummy for the cast,
//          and then change it back if you need to have it target allied units and such).
//
//          Be sure to add your spell to the dummy before trying to cast it! :)
//          Beware of permenantly adding spells with conflicting order ids/strings.
//
//      How to implement?
//     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
//          Create a new trigger object called DummyCaster, go to 'Edit -> Convert to
//          Custom Text', and replace everything that's there with this script.
//
//          Save the map, close it, reopen it, and then delete the "!" from the
//          FAR left side of the next line (so "external" will line up with this line):
//          external ObjectMerger w3u ushd dumy unam "Dummy Caster" uabi Aloc ucbs 0 ucpt 0 umvs 0 ushu "" umvh 0 umdl "Dummy.mdl" umpi 100000 umpm 100000 umpr 1000 ufoo 0
//
//      Thanks:
//     ¯¯¯¯¯¯¯¯¯
//          - Viikuna for demonstrating how to make dummy casters cast instantaneously.
//
library DummyCaster
    // If you're looking for where the 'dumy' type is declared, it is declared
    // in the object merger line at the end of "How to implement?" in the above
    // documentation.
    globals
        // If this is changed, the object merger line must also be changed
        // before the second implementation step is followed.
        constant integer DUMMY_TYPE='u00X'
        
        // This shouldn't be changed, but in some maps perhaps it is necessary.
        constant player DUMMY_OWNER=Player(PLAYER_NEUTRAL_AGGRESSIVE)
        
        // Just because these belong here:
        private constant real CREATED_AT_X=0.0
        private constant real CREATED_AT_Y=0.0

//=====================================================================================
        unit DUMMY=null
    endglobals
    
    private struct Initializer extends array // "extends array" removes
                                             // create/destoy methods.
        // The initialisation is done this way because struct initialisers are
        // called before library initialisers, making this important for adding
        // abilities on map initialisation.
        private static method onInit takes nothing returns nothing
            set DUMMY=CreateUnit(DUMMY_OWNER,DUMMY_TYPE,CREATED_AT_X,CREATED_AT_Y,0)
        endmethod
    endstruct
endlibrary
