using System.Collections.Generic;

namespace WarcraftLegacies.Source.Setup;

public static class UniqueEliteNames
{
  public static Dictionary<int, List<string>> GetNames()
  {
    return new Dictionary<int, List<string>>
    {
      [UNIT_H00F_PALADIN_LORDAERON] =
        new()
        {
          "Agamand the True",
          "Arius the Seeker",
          "Aurrius the Pure",
          "Ballador the Bright",
          "Buzan the Fearless",
          "Dagren the Orcslayer",
          "Duke Lionheart",
          "Gavinrad the Dire",
          "Geros Ironblade",
          "Granis Darkhammer",
          "Halahk the Lifebringer",
          "Jorn the Redeemer",
          "Karnwield the Seeker",
          "Lord Nicholas Buzan",
          "Sage Truthbearer",
          "Sir Gregory Edmunson",
          "Sten Azureshield",
          "Magroth the Defender",
          "Malak the Avenger",
          "Manadar the Healer",
          "Morlune the Mighty",
          "Zann the Defender"
        },
      [UNIT_N00A_FARSTRIDER_QUELTHALAS_ELITE] =
        new()
        {
          "Amora Eagleye",
          "Anthis Sunbow",
          "Anya Eversong",
          "Clea Deathstrider",
          "Cyndia Hawkspear",
          "Mira Shadewither",
          "Nara Pathstrider",
          "Siren Ghostsong",
          "Somand Wayfinder",
          "Lyrelia Starwhisper",
          "Thalindra Moonshade",
          "Faelith Sunrunner",
          "Elaria Nightbreeze",
          "Vaelith Dawntracker"
        },
      [UNIT_N007_KIRIN_TOR_DALARAN_ELITE] =
        new()
        {
          "Aran Spellweaver",
          "Nikil Dawnseeker",
          "Doril Magefont",
          "Manath Magesinger",
          "Nilas Arcanister",
          "Peril Spellbinder",
          "Shal Lightbinder",
          "Tenn Flamecaster",
          "Lyrian Starwhisper",
          "Vaelis Moonweaver",
          "Serethis Brightspark",
          "Elowen Frostflare",
          "Leios Sunward"
        },
      [UNIT_O01V_GREYGUARD_GILNEAS] =
        new()
        {
          "Fenric the Howler",
          "Ravok Nightfang",
          "Tharok Silverclaw",
          "Lycanis Shadowpelt",
          "Garruk Moonbane",
          "Drenar Wolfheart",
          "Fenris Darkmane",
          "Varok Grimfang",
          "Korvath Steelpaw",
          "Mordran Bloodhowl"
        },
      [UNIT_H00H_DEATH_KNIGHT_SCOURGE_ELITE] =
        new()
        {
          "Baron Bloodbane",
          "Baron Felblade",
          "Baron Frostfel",
          "Baron Morte",
          "Baron Perenolde",
          "Duke Dreadmoore",
          "Duke Ragereaver",
          "Duke Wintermaul",
          "Lord Darkhallow",
          "Lord Darkscythe",
          "Lord Dethstorm",
          "Lord Lightstalker",
          "Lord Maldazzar",
          "Lord Nightsorrow",
          "Lord Soulrender"
        },
      [UNIT_U007_DREADLORD_LEGION_ELITE] =
        new()
      {
        "Algammon",
        "Banehallow",
        "Bleakill",
        "Dethecus",
        "Fearoth",
        "Lorthiras",
        "Maldibion",
        "Mullioch",
        "Necros",
        "Nerothos",
        "Terrordar",
        "Ven'Gyr",
        "Zenedar",
        "Zilfallon"
      },
      [UNIT_O01L_EXECUTIONER_FEL_ELITE] =
        new()
        {
          "Gorrak Bloodcleaver",
          "Thragor Doomblade",
          "Kargath Ironfist",
          "Morguk Skullsplitter",
          "Drogath the Cruel",
          "Rendok the Vicious",
          "Vargoth Deathfang",
          "Zorak the Slayer",
          "Grimnar Warblade",
          "Balthok Bonecrusher",
          "Korvak the Butcher",
          "Thulgar Bladebreaker",
          "Drakthar Gorehand",
          "Horgath Bloodmaw",
          "Vorrak the Ravager"
        },
      [UNIT_NNRG_ROYAL_GUARD_ILLIDARI] =
        new()
        {
          "Zytheris the Vigilant",
          "Malirion Tideblade",
          "Serathis Deepwarden",
          "Vaelith Shadowfin",
          "Thalindra Waveguard",
          "Nerithis Stormscale",
          "Calythar Nighttrident",
          "Orithal Sunblade",
          "Velarith Moonwarden",
          "Sorynthis Deepseer",
          "Dralithar Seabreaker",
          "Eryndor Tidewarden",
          "Thyssara Coralguard",
          "Xalorath Seaheart",
          "Valyssia Stormsentinel"
        },
      [UNIT_H0AC_SEA_WITCH_ILLIDARI_ELITE] =
        new()
        {
          "Anna Kondra",
          "Asprah Serpus",
          "Charib'dishal",
          "Lady Snakemane",
          "Lady Venomtongue",
          "Ursula Snakemane",
          "Morrath Deepcoil",
          "Selara Tidebinder",
          "Velyra Blackfin",
          "Thalassa Darkwave"
        },
      [UNIT_N0E7_BLOODWARDER_SUNFURY] =
        new()
        {
          "Aldos Firestar",
          "Eldin Sunstrider",
          "Geldor Earthfire",
          "Gilaras Drakeson",
          "Hale Magefire",
          "Halendor Burnkin",
          "Kath'ranis Remar",
          "Kelen the Destroyer",
          "Lorn Bloodseeker",
          "Marakanis Starfury",
          "Tanin Hawkwing",
          "Tenris Mirkblood",
          "Tenris Mirkblood",
          "Tyoril Sunchaser",
          "Vandrel Flamewarden",
          "Zarion Emberheart",
          "Caledor Sunfury",
          "Thalir Firebane",
          "Orendis Starflare"
        },
      [UNIT_ZBLI_LICH_SCOURGE_ELITE] =
        new()
        {
          "Alandil Lieng",
          "Araj the Summoner",
          "Cho'Nammoth",
          "Coldreaver",
          "Din Frostfire",
          "Kali'naj Dethknell",
          "Kryptikk Soulslayer",
          "Miasmus",
          "Naze the Eternal",
          "Ordin Frostbane",
          "Rak Coldskull",
          "Ras Frostwhisper"
        },
      [UNIT_O00A_FAR_SEER_FROSTWOLF_ELITE] =
        new()
        {
          "Bale Bleakstare",
          "Doomroar",
          "Fenris'ar Gul",
          "Foerend",
          "Gar'dal Grimsight",
          "Gorr Grimwolf",
          "Kag'ar Winterfang",
          "Kazil Darkeye",
          "Kazragore",
          "Magis Coldeye",
          "Negel Fireye",
          "Warmaul"
        },
      [UNIT_N03F_KOR_KRON_ELITE_WARSONG_ELITE] =
        new()
        {
          "Arashicage",
          "Bloodgrin",
          "Bonethirst",
          "Genjuros",
          "Maim",
          "Mazuru",
          "Mizgill",
          "Moogul the Sly",
          "Nera'thor",
          "Rend",
          "Sagra'nel",
          "Samuro",
          "Tojara"
        },
      [UNIT_E00N_KEEPER_OF_THE_GROVE_DRUIDS_ELITE] =
        new()
      {
        "Anubris",
        "Bandalar",
        "Centrius",
        "Ceredwyn",
        "Dagda",
        "Gholbine",
        "Larodar",
        "Malorne",
        "Nandieb",
        "Nuada",
        "Oghma"
      },
      [UNIT_H04L_PRIESTESS_OF_THE_MOON_SENTINELS_ELITE] =
        new()
        {
          "Adora Nightshade",
          "Anara Chillwind",
          "Ariel Darkmoon",
          "Delas Moonfang",
          "Diana Windwood",
          "Felore Moonray",
          "Kathris Starsong",
          "Kera Stardragon",
          "Mave Whisperwind",
          "Mira Whitemane",
          "Mora Moonsinger",
          "Theta Saberfang",
          "Tygra Snowscar"
        },
      [UNIT_H09R_VINDICATOR_DRAENEI] =
        new()
        {
          "Aeloras Lightwarden",
          "Ardalis Starshield",
          "Calyndra Dawnbringer",
          "Draethor Soulguard",
          "Elunara Brightblade",
          "Kaelvinar Sunward",
          "Lorandis Faithhammer",
          "Myrieth Dawnshield",
          "Thalorin Lightstrike",
          "Vaeloria Starbreaker",
          "Zerathis the Righteous",
          "Oranil Sunshield",
          "Seloras Lightwarden"
        },
      [UNIT_N08S_ELEMENTAL_LORD_SKYWALL] =
        new()
        {
          "Pyros Stormheart",
          "Terrak Emberforge",
          "Zephros Windcaller",
          "Infernalash",
          "Stonefury",
          "Galecrash",
          "Blazemantle",
          "Thundrax",
          "Moltenveil",
          "Stormbark",
          "Cinderpeak",
          "Rockmaw",
          "Tempesthorn"
        },
      [UNIT_O000_ROYALTY_CTHUN_ELITES] =
        new()
        {
          "Zarqith the Carapaced",
          "Thalrix the Impaler",
          "Qirnoth the Hiveguard",
          "Veknar the Spined",
          "Xylaris the Chitinous",
          "Rexqir the Hardened",
          "Balthor the Mandibled",
          "Syrith the Venomous",
          "Kranix the Armored",
          "Vornax the Burrower",
          "Thryxis the Shellbreaker",
          "Zyphor the Pincered"
        },
      [UNIT_N0B4_REAPER_NZOTH] =
        new()
        {
          "Skarath the Venomous",
          "Zyrix the Spinner",
          "Thalnoth the Fang",
          "Vorrik the Shadowleg",
          "Xylaris the Webweaver",
          "Rethis the Nightstalker",
          "Krythos the Silkbound",
          "Drazul the Huntmaster",
          "Nytrix the Shadowfang",
          "Velkrath the Creeper",
          "Pharax the Lurker",
          "Sythrak the Poisoned"
        },
      [UNIT_H01L_THANE_IRONFORGE_ELITE] =
        new()
        {
          "Aggronor the Mighty",
          "Bandis Forgefire",
          "Beazel Bludstone",
          "Bor Stonebreaker",
          "Buri Frostbeard",
          "Gar Doomforge",
          "Grim Thunderbrew",
          "Huginn Ironcliff",
          "Kelv Sternhammer",
          "Modi Stonesmith",
          "Munin Ironcliff",
          "Thordin Rockbeard",
          "Thorgas Broadaxe",
          "Thurin Stormbreaker"
        },
      [UNIT_N07G_MUSKETEER_KULTIRAS] =
        new()
        {
          "Barnaby Flintlock",
          "Gideon Seawatch",
          "Roland Saltwind",
          "Silas Broadbeam",
          "Jeremiah Wavecaller",
          "Percival Longshot",
          "Elias Gunport",
          "Thaddeus Blackpowder",
          "Nathaniel Tidebreaker",
          "Quinton Seafoe",
          "Edmund Sharpshot",
          "Victor Helmstrike",
          "Harrison Truewind",
          "Malcolm Ironbarrel",
          "Tobias Stormlock"
        },
      [UNIT_H05F_STORMWIND_CHAMPION_STORMWIND_ELITE] =
        new()
        {
          "Sir Alaric Dawnshield",
          "Sir Roland Brightblade",
          "Sir Gareth Lionheart",
          "Sir Cedric Stormspear",
          "Sir Darius Ironmane",
          "Sir Tristan Lightguard",
          "Sir Edmund Goldcrest",
          "Sir Leoric Sunwarden",
          "Sir Hadrian Steelhoof",
          "Sir Percival Silverlance",
          "Sir Lionel Trueblade",
          "Sir Thaddeus Ironcrest",
          "Sir Galen Highstride",
          "Sir Marcus Shieldheart",
          "Sir Victor Lightmane"
        },
      [UNIT_N086_FEL_DEATH_KNIGHT_FEL_ELITE_TIER] =
        new()
      {
        "Krag Deathshroud",
        "Morthus Blackfell",
        "Dreadbane",
        "Malrath Bloodgrave",
        "Zarvok Soulrender",
        "Threnos Darkember",
        "Ravengrim the Unbound",
        "Vornath Doomblade",
        "Ulthar Shadowcleave",
        "Dethros Nightreaver",
        "Ghulmar Gravevein",
        "Orryx Felbreaker",
        "Sulfiren Bonewrought",
        "Velkris Doomcaller",
        "Kaelvros Nightbane"
      },

      [UNIT_H06B_TEMPLAR_LORDAERON] =
        new()
        {
          "Alaric the Zealous",
          "Sir Mathias Dawnhammer",
          "Thane Valemort Creed",
          "Edric Lightbane",
          "Brother Halbrecht Pyre",
          "Justicar Thalos Redmark",
          "Sir Corvin Ashguard",
          "Magnus Brightwrath",
          "High Templar Aurelian",
          "Garrick Flameward",
          "Lucien Dawnreaver",
          "Sir Roland Scarletbane",
          "Inquisitor Varrus Holycinder",
          "Benedict Ironfaith",
          "Albrecht Sunfall"
        }
    };
  }
}
