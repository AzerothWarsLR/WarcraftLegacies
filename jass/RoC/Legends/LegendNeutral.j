library LegendNeutral initializer OnInit requires Legend

  globals
    Legend LEGEND_RAGNAROS
    Legend LEGEND_SEAWITCH

    Legend LEGEND_AUCHINDOUN
    Legend LEGEND_DRAKTHARONKEEP
    Legend LEGEND_OSHUGUN
    Legend LEGEND_JINTHAALOR
    Legend LEGEND_SHRINEOFULATEK
    Legend LEGEND_SERADANE
    Legend LEGEND_ZULGURUB
    Legend LEGEND_DAZARALOR
    Legend LEGEND_GUNDRAK
    Legend LEGEND_DUSKWOODGRAVEYARD
    Legend LEGEND_GRIMBATOL
    Legend LEGEND_ETHELRETHOR
    Legend LEGEND_NEXUS
    Legend LEGEND_KARAZHAN
    Legend LEGEND_ZULFARRAK
    Legend LEGEND_FOUNTAINOFHEALTH
    Legend LEGEND_FOUNTAINOFHEALTH_WETLANDS
    Legend LEGEND_FOUNTAINOFHEALTH_FERALAS
    Legend LEGEND_FOUNTAINOFHEALTH_TOMB
    Legend LEGEND_FOUNTAINOFHEALTH_DALARAN
    Legend LEGEND_FOUNTAINOFBLOOD
    Legend LEGEND_CENTAURKHAN
    Legend LEGEND_IMMOLTHAR
    Legend LEGEND_ARUGAL
    Legend LEGEND_VAELASTRASZ
    Legend LEGEND_OCCULUS
    Legend LEGEND_SARAGOSA
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_RAGNAROS = Legend.create()
    set LEGEND_RAGNAROS.Unit = gg_unit_N00D_1457
    set LEGEND_RAGNAROS.DeathMessage = "Ragnaros, the King of Fire and Lord of the Firelands, has been extinguished."

    set LEGEND_SEAWITCH = Legend.create()
    set LEGEND_SEAWITCH.Unit = gg_unit_O02L_0340

    set LEGEND_AUCHINDOUN = Legend.create()
    set LEGEND_AUCHINDOUN.Capturable = true
    set LEGEND_AUCHINDOUN.Unit = gg_unit_h026_1207

    set LEGEND_DRAKTHARONKEEP = Legend.create()
    set LEGEND_DRAKTHARONKEEP.Capturable = true
    set LEGEND_DRAKTHARONKEEP.Unit = gg_unit_o016_0771

    set LEGEND_OSHUGUN = Legend.create()
    set LEGEND_OSHUGUN.Capturable = true
    set LEGEND_OSHUGUN.Unit = gg_unit_h02Z_0726

    set LEGEND_JINTHAALOR = Legend.create()
    set LEGEND_JINTHAALOR.Capturable = true
    set LEGEND_JINTHAALOR.Unit = gg_unit_o02G_0310

    set LEGEND_SHRINEOFULATEK = Legend.create()
    set LEGEND_SHRINEOFULATEK.Capturable = true
    set LEGEND_SHRINEOFULATEK.Unit = gg_unit_o00Q_0989

    set LEGEND_SERADANE = Legend.create()
    set LEGEND_SERADANE.Capturable = true
    set LEGEND_SERADANE.Unit = gg_unit_e014_3083

    set LEGEND_ZULGURUB = Legend.create()
    set LEGEND_ZULGURUB.Capturable = true
    set LEGEND_ZULGURUB.Unit = gg_unit_o018_0017

    set LEGEND_DAZARALOR = Legend.create()
    set LEGEND_DAZARALOR.Capturable = true
    set LEGEND_DAZARALOR.Unit = gg_unit_o00V_2194

    set LEGEND_GUNDRAK = Legend.create()
    set LEGEND_GUNDRAK.Capturable = true
    set LEGEND_GUNDRAK.Unit = gg_unit_o00N_0704

    set LEGEND_DUSKWOODGRAVEYARD = Legend.create()
    set LEGEND_DUSKWOODGRAVEYARD.Capturable = true
    set LEGEND_DUSKWOODGRAVEYARD.Unit = gg_unit_h01F_1161

    set LEGEND_GRIMBATOL = Legend.create()
    set LEGEND_GRIMBATOL.Capturable = true
    set LEGEND_GRIMBATOL.Unit = gg_unit_h01Z_0618

    set LEGEND_ETHELRETHOR = Legend.create()
    set LEGEND_ETHELRETHOR.Capturable = true
    set LEGEND_ETHELRETHOR.Unit = gg_unit_h05I_0313

    set LEGEND_NEXUS = Legend.create()
    set LEGEND_NEXUS.Unit = gg_unit_h04P_1732
    set LEGEND_NEXUS.Capturable = true

    set LEGEND_KARAZHAN = Legend.create()
    set LEGEND_KARAZHAN.Unit = gg_unit_h00G_0084
    set LEGEND_KARAZHAN.Capturable = true

    set LEGEND_ZULFARRAK = Legend.create()
    set LEGEND_ZULFARRAK.Capturable = true
    set LEGEND_ZULFARRAK.Unit = gg_unit_o00K_0150

    set LEGEND_FOUNTAINOFHEALTH = Legend.create()
    set LEGEND_FOUNTAINOFHEALTH.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH.Unit = gg_unit_nfoh_0212

    set LEGEND_FOUNTAINOFHEALTH_WETLANDS = Legend.create()
    set LEGEND_FOUNTAINOFHEALTH_WETLANDS.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_WETLANDS.Unit = gg_unit_nfoh_2299

    set LEGEND_FOUNTAINOFHEALTH_FERALAS = Legend.create()
    set LEGEND_FOUNTAINOFHEALTH_FERALAS.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_FERALAS.Unit = gg_unit_nfoh_0315

    set LEGEND_FOUNTAINOFHEALTH_TOMB = Legend.create()
    set LEGEND_FOUNTAINOFHEALTH_TOMB.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_TOMB.Unit = gg_unit_nfoh_1904

    set LEGEND_FOUNTAINOFHEALTH_DALARAN = Legend.create()
    set LEGEND_FOUNTAINOFHEALTH_DALARAN.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_DALARAN.Unit = gg_unit_nfoh_1190

    set LEGEND_FOUNTAINOFBLOOD = Legend.create()
    set LEGEND_FOUNTAINOFBLOOD.Capturable = true
    set LEGEND_FOUNTAINOFBLOOD.Unit = gg_unit_nbfl_0094

    set LEGEND_CENTAURKHAN = Legend.create()
    set LEGEND_CENTAURKHAN.Unit = gg_unit_ncnk_0573

    set LEGEND_IMMOLTHAR = Legend.create()
    set LEGEND_IMMOLTHAR.Unit = gg_unit_n04R_1914

    set LEGEND_VAELASTRASZ = Legend.create()
    set LEGEND_VAELASTRASZ.Unit = gg_unit_nrwm_1981

    set LEGEND_OCCULUS = Legend.create()
    set LEGEND_OCCULUS.Unit = gg_unit_O025_3426
    set LEGEND_OCCULUS.PermaDies = true

    set LEGEND_SARAGOSA = Legend.create()
    set LEGEND_SARAGOSA.Unit = gg_unit_nadr_0658

    set LEGEND_ARUGAL = Legend.create()
    set LEGEND_ARUGAL.Unit = gg_unit_Hgam_1450
  endfunction

endlibrary