library PersonSetup requires Persons, Team, ScourgeSetup, LegionSetup, FelHordeSetup, LordaeronSetup, IronforgeSetup, DalaranSetup, QuelthalasSetup, FrostwolfSetup, WarsongSetup, SentinelsSetup, StormwindSetup, DruidsSetup, NagaSetup, CthunSetup

  public function OnInit takes nothing returns nothing
    local Person p

    set p = Person.create(Player(0))
    set p.Faction = FACTION_FROSTWOLF          

    set p = Person.create(Player(1))
    set p.Faction = FACTION_LORDAERON

    set p = Person.create(Player(2))
    set p.Faction = FACTION_QUELTHALAS

    set p = Person.create(Player(3))
    set p.Faction = FACTION_SCOURGE

    set p = Person.create(Player(4)) 
    set p.Faction = FACTION_IRONFORGE

    set p = Person.create(Player(5))
    set p.Faction = FACTION_WARSONG

    set p = Person.create(Player(6))
    set p.Faction = FACTION_FEL_HORDE

    set p = Person.create(Player(7))
    set p.Faction = FACTION_DALARAN

    set p = Person.create(Player(8))
    set p.Faction = FACTION_GOBLIN

    set p = Person.create(Player(9))
    set p.Faction = FACTION_FORSAKEN

    set p = Person.create(Player(10))
    set p.Faction = FACTION_STORMWIND

    set p = Person.create(Player(11))
    set p.Faction = FACTION_DRUIDS

    set p = Person.create(Player(12))
    set p.Faction = FACTION_SCARLET

    set p = Person.create(Player(14))
    set p.Faction = FACTION_BLACKEMPIRE

    set p = Person.create(Player(15))
    set p.Faction = FACTION_NAGA

    set p = Person.create(Player(16))
    set p.Faction = FACTION_CTHUN

    set p = Person.create(Player(17))
    set p.Faction = FACTION_TROLL

    set p = Person.create(Player(18))
    set p.Faction = FACTION_SENTINELS

    set p = Person.create(Player(19))
    set p.Faction = FACTION_TWILIGHT

    set p = Person.create(Player(20))
    set p.Faction = FACTION_GILNEAS

    set p = Person.create(Player(22))
    set p.Faction = FACTION_KULTIRAS

    set p = Person.create(Player(23))
    set p.Faction = FACTION_LEGION

    call Person.create(Player(13))

  endfunction

endlibrary