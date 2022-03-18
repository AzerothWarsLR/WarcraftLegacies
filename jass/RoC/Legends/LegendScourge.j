library LegendScourge initializer OnInit requires Legend

  globals
    public static Legend LEGEND_KELTHUZAD
    public static Legend LEGEND_ANUBARAK
    public static Legend LEGEND_RIVENDARE
    public static Legend LEGEND_LICHKING
    public static Legend LEGEND_UTGARDE

    constant integer UNITTYPE_KELTHUZAD_NECROMANCER = 'U001'
    constant integer UNITTYPE_KELTHUZAD_GHOST = 'U00M'
    constant integer UNITTYPE_KELTHUZAD_LICH = 'Uktl'
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_KELTHUZAD = new Legend()
    set LEGEND_KELTHUZAD.UnitType = 'U001'
    set LEGEND_KELTHUZAD.PermaDies = true
    set LEGEND_KELTHUZAD.DeathMessage = "Kel'thuzad has been slain. He lives on in spectral form, and may yet return if he is brought to the Sunwell."
    set LEGEND_KELTHUZAD.DeathSfx = "Abilities\\Spells\\Undead\\DeathCoil\\DeathCoilSpecialArt.mdl"
    set LEGEND_KELTHUZAD.Essential = true
    set LEGEND_KELTHUZAD.StartingXp = 1000
    set LEGEND_KELTHUZAD.Name = "Kel'thuzad"

    set LEGEND_ANUBARAK = new Legend()
    set LEGEND_ANUBARAK.UnitType = 'Uanb'

    set LEGEND_RIVENDARE = new Legend()
    set LEGEND_RIVENDARE.UnitType = 'U00A'
    set LEGEND_RIVENDARE.StartingXp = 1000

    set LEGEND_UTGARDE = new Legend()
    set LEGEND_UTGARDE.Unit = gg_unit_h00O_2516
    set LEGEND_UTGARDE.Capturable = true

    set LEGEND_LICHKING = new Legend()
    set LEGEND_LICHKING.Unit = gg_unit_u000_0649
    set LEGEND_LICHKING.Hivemind = true
    set LEGEND_LICHKING.DeathMessage = "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue."
endfunction

endlibrary