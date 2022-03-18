library LegendNeutral initializer OnInit requires Legend

  globals
    public static Legend LEGEND_RAGNAROS
    public static Legend LEGEND_SEAWITCH

    public static Legend LEGEND_AUCHINDOUN
    public static Legend LEGEND_DRAKTHARONKEEP
    public static Legend LEGEND_OSHUGUN
    public static Legend LEGEND_JINTHAALOR
    public static Legend LEGEND_SHRINEOFULATEK
    public static Legend LEGEND_SERADANE
    public static Legend LEGEND_ZULGURUB
    public static Legend LEGEND_DAZARALOR
    public static Legend LEGEND_GUNDRAK
    public static Legend LEGEND_DUSKWOODGRAVEYARD
    public static Legend LEGEND_GRIMBATOL
    public static Legend LEGEND_ETHELRETHOR
    public static Legend LEGEND_NEXUS
    public static Legend LEGEND_KARAZHAN
    public static Legend LEGEND_ZULFARRAK
    public static Legend LEGEND_FOUNTAINOFHEALTH
    public static Legend LEGEND_FOUNTAINOFHEALTH_WETLANDS
    public static Legend LEGEND_FOUNTAINOFHEALTH_FERALAS
    public static Legend LEGEND_FOUNTAINOFHEALTH_TOMB
    public static Legend LEGEND_FOUNTAINOFHEALTH_DALARAN
    public static Legend LEGEND_FOUNTAINOFBLOOD
    public static Legend LEGEND_CENTAURKHAN
    public static Legend LEGEND_IMMOLTHAR
    public static Legend LEGEND_ARUGAL
    public static Legend LEGEND_VAELASTRASZ
    public static Legend LEGEND_OCCULUS
    public static Legend LEGEND_SARAGOSA
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_RAGNAROS = new Legend()
    set LEGEND_RAGNAROS.Unit = gg_unit_N00D_1457
    set LEGEND_RAGNAROS.DeathMessage = "Ragnaros, the King of Fire and Lord of the Firelands, has been extinguished."

    set LEGEND_SEAWITCH = new Legend()
    set LEGEND_SEAWITCH.Unit = gg_unit_O02L_0340

    set LEGEND_AUCHINDOUN = new Legend()
    set LEGEND_AUCHINDOUN.Capturable = true
    set LEGEND_AUCHINDOUN.Unit = gg_unit_h026_1207

    set LEGEND_DRAKTHARONKEEP = new Legend()
    set LEGEND_DRAKTHARONKEEP.Capturable = true
    set LEGEND_DRAKTHARONKEEP.Unit = gg_unit_o016_0771

    set LEGEND_OSHUGUN = new Legend()
    set LEGEND_OSHUGUN.Capturable = true
    set LEGEND_OSHUGUN.Unit = gg_unit_h02Z_0726

    set LEGEND_JINTHAALOR = new Legend()
    set LEGEND_JINTHAALOR.Capturable = true
    set LEGEND_JINTHAALOR.Unit = gg_unit_o02G_0310

    set LEGEND_SHRINEOFULATEK = new Legend()
    set LEGEND_SHRINEOFULATEK.Capturable = true
    set LEGEND_SHRINEOFULATEK.Unit = gg_unit_o00Q_0989

    set LEGEND_SERADANE = new Legend()
    set LEGEND_SERADANE.Capturable = true
    set LEGEND_SERADANE.Unit = gg_unit_e014_3083

    set LEGEND_ZULGURUB = new Legend()
    set LEGEND_ZULGURUB.Capturable = true
    set LEGEND_ZULGURUB.Unit = gg_unit_o018_0017

    set LEGEND_DAZARALOR = new Legend()
    set LEGEND_DAZARALOR.Capturable = true
    set LEGEND_DAZARALOR.Unit = gg_unit_o00V_2194

    set LEGEND_GUNDRAK = new Legend()
    set LEGEND_GUNDRAK.Capturable = true
    set LEGEND_GUNDRAK.Unit = gg_unit_o00N_0704

    set LEGEND_DUSKWOODGRAVEYARD = new Legend()
    set LEGEND_DUSKWOODGRAVEYARD.Capturable = true
    set LEGEND_DUSKWOODGRAVEYARD.Unit = gg_unit_h01F_1161

    set LEGEND_GRIMBATOL = new Legend()
    set LEGEND_GRIMBATOL.Capturable = true
    set LEGEND_GRIMBATOL.Unit = gg_unit_h01Z_0618

    set LEGEND_ETHELRETHOR = new Legend()
    set LEGEND_ETHELRETHOR.Capturable = true
    set LEGEND_ETHELRETHOR.Unit = gg_unit_h05I_0313

    set LEGEND_NEXUS = new Legend()
    set LEGEND_NEXUS.Unit = gg_unit_h04P_1732
    set LEGEND_NEXUS.Capturable = true

    set LEGEND_KARAZHAN = new Legend()
    set LEGEND_KARAZHAN.Unit = gg_unit_h00G_0084
    set LEGEND_KARAZHAN.Capturable = true

    set LEGEND_ZULFARRAK = new Legend()
    set LEGEND_ZULFARRAK.Capturable = true
    set LEGEND_ZULFARRAK.Unit = gg_unit_o00K_0150

    set LEGEND_FOUNTAINOFHEALTH = new Legend()
    set LEGEND_FOUNTAINOFHEALTH.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH.Unit = gg_unit_nfoh_0212

    set LEGEND_FOUNTAINOFHEALTH_WETLANDS = new Legend()
    set LEGEND_FOUNTAINOFHEALTH_WETLANDS.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_WETLANDS.Unit = gg_unit_nfoh_2299

    set LEGEND_FOUNTAINOFHEALTH_FERALAS = new Legend()
    set LEGEND_FOUNTAINOFHEALTH_FERALAS.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_FERALAS.Unit = gg_unit_nfoh_0315

    set LEGEND_FOUNTAINOFHEALTH_TOMB = new Legend()
    set LEGEND_FOUNTAINOFHEALTH_TOMB.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_TOMB.Unit = gg_unit_nfoh_1904

    set LEGEND_FOUNTAINOFHEALTH_DALARAN = new Legend()
    set LEGEND_FOUNTAINOFHEALTH_DALARAN.Capturable = true
    set LEGEND_FOUNTAINOFHEALTH_DALARAN.Unit = gg_unit_nfoh_1190

    set LEGEND_FOUNTAINOFBLOOD = new Legend()
    set LEGEND_FOUNTAINOFBLOOD.Capturable = true
    set LEGEND_FOUNTAINOFBLOOD.Unit = gg_unit_nbfl_0094

    set LEGEND_CENTAURKHAN = new Legend()
    set LEGEND_CENTAURKHAN.Unit = gg_unit_ncnk_0573

    set LEGEND_IMMOLTHAR = new Legend()
    set LEGEND_IMMOLTHAR.Unit = gg_unit_n04R_1914

    set LEGEND_VAELASTRASZ = new Legend()
    set LEGEND_VAELASTRASZ.Unit = gg_unit_nrwm_1981

    set LEGEND_OCCULUS = new Legend()
    set LEGEND_OCCULUS.Unit = gg_unit_O025_3426
    set LEGEND_OCCULUS.PermaDies = true

    set LEGEND_SARAGOSA = new Legend()
    set LEGEND_SARAGOSA.Unit = gg_unit_nadr_0658

    set LEGEND_ARUGAL = new Legend()
    set LEGEND_ARUGAL.Unit = gg_unit_Hgam_1450
  endfunction

endlibrary