library StructurePackingConfig initializer OnInit requires StructurePacking

  private function OnInit takes nothing returns nothing
    call PackableStructure.create('ogre', "buildings\\Orc\\GreatHall\\GreatHall.mdx", 'A00O')
    call PackableStructure.create('ostr', "buildings\\Orc\\GreatHall\\GreatHall.mdx", 'A0EU')
    call PackableStructure.create('ofrt', "buildings\\Orc\\GreatHall\\GreatHall.mdx", 'A0ET')
    call PackableStructure.create('ofor', "buildings\\Orc\\WarMill\\WarMill.mdx", 'A0D9')
    call PackableStructure.create('oalt', "buildings\\Orc\\AltarofStorms\\AltarofStorms.mdx", 'A0E4')
    call PackableStructure.create('obar', "buildings\\Orc\\OrcBarracks\\OrcBarracks.mdx", 'A02U')
    call PackableStructure.create('otto', "buildings\\Orc\\TaurenTotem\\TaurenTotem.mdx", 'A09Z')
    call PackableStructure.create('osld', "buildings\\Orc\\SpiritLodge\\SpiritLodge.mdx", 'A09H')
    call PackableStructure.create('otrb', "buildings\\Orc\\TrollBurrow\\TrollBurrow.mdx", 'A0EV')
    call PackableStructure.create('oshy', "buildings\\other\\GoblinShipyard\\GoblinShipyard.mdx", 'A0EX')
    call PackableStructure.create('o01M', "war3mapImported\\Building_GoblinOutpost.mdl", 'A07D')
  endfunction

endlibrary