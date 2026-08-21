using System.Collections.Generic;

namespace MacroTools.Localization.Translations;

internal sealed class SpanishTranslation : ITranslation
{
  /// <inheritdoc/>
  public string Language => "es";

  /// <inheritdoc/>
  public IReadOnlyList<string> SystemLocales { get; } = new[] { "esES" };

  /// <inheritdoc/>
  public IReadOnlyDictionary<string, string> Entries { get; } = new Dictionary<string, string>
  {
    ["MAJOR EVENT"] = "EVENTO IMPORTANTE",
    ["QUEST FAILED"] = "MISIÓN FALLIDA",
    ["QUEST COMPLETED"] = "MISIÓN COMPLETADA",
    ["QUEST DISCOVERED"] = "MISIÓN DESCUBIERTA",
    ["Completed"] = "Completado",
    ["Failed"] = "Fallido",
    ["TEAM VICTORY IMMINENT"] = "VICTORIA DE EQUIPO INMINENTE",
    ["{team} has captured {captured} out of {total} Control Points required to win the game!"] =
      "¡{team} ha capturado {captured} de {total} Puntos de Control necesarios para ganar la partida!",
    ["TEAM VICTORY!"] = "¡VICTORIA DE EQUIPO!",
    ["The {team} has won the game! You may choose to continue playing."] =
      "¡{team} ha ganado la partida! Puedes elegir seguir jugando.",
    ["turn"] = "turno",
    ["turns"] = "turnos",
    ["You have met the threshold for being eliminated from the game. Unless you raise your Control Point count above {cpThreshold}, raise food used above {foodThreshold} or your team retakes/gains an essential Legend, you will be defeated in {turns} {turnWord}."] =
      "Alcanzaste el umbral para ser eliminado de la partida. A menos que subas tu cantidad de Puntos de Control por encima de {cpThreshold}, subas tu comida usada por encima de {foodThreshold}, o tu equipo recupere/consiga una Leyenda esencial, serás derrotado en {turns} {turnWord}.",
    ["You have joined {team}."] = "Te uniste a {team}.",
    ["{faction} has joined the {team}."] = "{faction} se unió a {team}.",
    ["You have not been invited to join {team}."] = "No fuiste invitado a unirte a {team}.",
    ["There is no Team with the name {name}."] = "No hay ningún Equipo con el nombre {name}.",
    ["There is no Faction with the name {name}."] = "No hay ninguna Facción con el nombre {name}.",
    ["You can't invite yourself to your own team."] = "No puedes invitarte a ti mismo a tu propio equipo.",
    ["There is no player with the Faction {faction}."] = "No hay ningún jugador con la Facción {faction}.",
    ["{player} has left the game and counts as a forfeit vote. ({votes}/{required})."] =
      "{player} abandonó la partida y su voto cuenta como un abandono. ({votes}/{required}).",
    ["{player} voted to forfeit. ({votes}/{required})."] =
      "{player} votó para abandonar. ({votes}/{required}).",
    ["You can't forfeit before turn {turn}."] = "No puedes abandonar antes del turno {turn}.",
    ["Forfeit vote registered."] = "Voto de abandono registrado.",
    ["You are not in a team."] = "No estás en ningún equipo.",
    ["You have already forfeited."] = "Ya votaste para abandonar.",
    ["Forfeit vote passed."] = "La votación de abandono fue aprobada.",
    ["{team} has forfeited the game.|cFFFF0000The game will end in 10 seconds.|r"] =
      "{team} abandonó la partida.|cFFFF0000La partida terminará en 10 segundos.|r",
    ["You must supply at least {min} parameters. If you're trying to use a parameter with multiple words, try enclosing it in quotes."] =
    "Tienes que ingresar al menos {min} parámetros. Si estás tratando de usar un parámetro con varias palabras, prueba encerrarlo entre comillas.",
    ["CHEAT"] = "CHEAT",
    ["Commands"] = "Comandos",
    ["{faction} is no longer invited to join the {team}."] = "{faction} ya no está invitado a unirse a {team}.",
    ["You are no longer invited to join the {team}."] = "Ya no estás invitado a unirte a {team}.",
    ["{faction} has been invited to join the {team}."] = "{faction} fue invitado a unirse a {team}.",
    ["You have been invited to join the {team}. Type -join {team} to accept."] =
      "Fuiste invitado a unirte a {team}. Escribe -join {team} para aceptar.",
    ["Vote Game Mode"] = "Votar Modo de Juego",
    ["The {mode} game mode has been chosen."] = "Se eligió el modo de juego {mode}.",
    ["{faction} has left the game."] = "{faction} abandonó la partida.",
    ["{playerName} has left the game."] = "{playerName} abandonó la partida.",
    ["HINT"] = "CONSEJO",
    ["HERO REWARD EARNED"] = "RECOMPENSA DE HÉROE OBTENIDA",
    ["Strength"] = "Fuerza",
    ["Agility"] = "Agilidad",
    ["Intelligence"] = "Inteligencia",
    ["Experience"] = "Experiencia",
    ["UNIT LIMIT CHANGED"] = "LÍMITE DE UNIDADES CAMBIADO",
    ["You can now train up to {limit} units of type {unit}."] = "Ahora puedes entrenar hasta {limit} unidades de tipo {unit}.",
    ["RESEARCH ACQUIRED"] = "INVESTIGACIÓN OBTENIDA",
    ["NEW UNIT ACQUIRED"] = "NUEVA UNIDAD OBTENIDA",
    ["REFUND"] = "REEMBOLSO",
    ["You cannot research {research}. All resources spent on it have been refunded."] = "No puedes investigar {research}. Todos los recursos gastados en ella fueron reembolsados.",
    ["NEW POWER ACQUIRED"] = "NUEVO PODER OBTENIDO",
    ["LEGENDARY FOE SUMMONED"] = "ENEMIGO LEGENDARIO INVOCADO",
    ["CAPITAL DESTROYED"] = "CAPITAL DESTRUIDA",
    ["LEGENDARY FOE SLAIN"] = "ENEMIGO LEGENDARIO ABATIDO",
    ["HERO SLAIN"] = "HÉROE ABATIDO",
    ["Join our Discord:"] = "Sumate a nuestro Discord:",
    ["If you are a new player, look at the Quest (F9) tab to see your objectives."] = "Si eres nuevo, mira la pestaña de Misiones (F9) para ver tus objetivos.",
    ["Quests are unique objectives that grant rewards when completed. View the Quest Menu (F9) to see the quests available to your faction."] =
      "Las misiones son objetivos únicos que otorgan recompensas al completarse. Mira el Menú de Misiones (F9) para ver las misiones disponibles para tu facción.",
    ["Artifacts are unique items that can grant major advantages. You can find out where Artifacts are using the Artifact Menu at the top-left of your screen."] =
      "Los artefactos son objetos únicos que pueden dar grandes ventajas. Puedes averiguar dónde están usando el Menú de Artefactos arriba a la izquierda de tu pantalla.",
    ["Some heroes can't be revived, and some can only be revived if you control certain capitals when they die."] =
      "Algunos héroes no se pueden revivir, y otros solo se pueden revivir si controlas ciertas capitales cuando mueren.",
    ["If you have low FPS, try turning off your health bars."] =
      "Si tienes pocos FPS, prueba desactivar las barras de vida.",
    ["We have a thriving Discord community at {url}"] =
      "Tenemos una comunidad activa en Discord en {url}",
    ["When a player leaves, their units are refunded, then their gold and hero experience are spread among their remaining allies."] =
      "Cuando un jugador abandona, sus unidades se reembolsan, y su oro y experiencia de héroe se reparten entre sus aliados restantes.",
    ["There are water passageways at the edge of the map you can use to instantly move to the other side of the map."] =
      "Hay pasajes de agua en el borde del mapa que puedes usar para moverte instantáneamente al otro lado del mapa.",
    ["Every faction can build an item shop that contains useful purchasable items."] =
      "Cada facción puede construir una tienda de objetos con artículos útiles para comprar.",
    ["When you unlock a hero through a Quest, you usually still need to summon that hero from an Altar."] =
      "Cuando desbloqueas un héroe mediante una misión, normalmente igual necesitas invocarlo desde un Altar.",
    ["The fastest way to travel between continents is by using items of type {item}."] =
      "La forma más rápida de viajar entre continentes es usando objetos de tipo {item}.",
    ["Control Points have towers which get stronger every turn, or when you research Fortify."] =
      "Los Puntos de Control tienen torres que se fortalecen cada turno, o cuando investigas Fortificar.",
    ["Each turn, every Capital and every gate gains bonus maximum hit points. Capitals gain {capitalPercent}% and gates gain {gatePercent}%."] =
      "Cada turno, cada Capital y cada portón gana puntos de vida máxima adicionales. Las Capitales ganan {capitalPercent}% y los portones ganan {gatePercent}%.",
    ["There are 4 units of type {unit} scattered throughout the seas, which each give a large amount of income when controlled."] =
      "Hay 4 unidades de tipo {unit} repartidas por los mares, cada una da una gran cantidad de ingresos al controlarla.",
    ["Summoned units grant no experience when slain."] =
      "Las unidades invocadas no otorgan experiencia al morir.",
    ["All players get bonus income for the first 10 turns. Use it to train a strong army, complete your starting quests, and secure Control Points."] =
      "Todos los jugadores reciben ingresos adicionales durante los primeros 10 turnos. Úsalos para entrenar un ejército fuerte, completar tus misiones iniciales, y asegurar Puntos de Control.",
    ["You can change alliances by using the commands -invite, -uninvite, -join, and -unally."] =
      "Puedes cambiar de alianzas usando los comandos -invite, -uninvite, -join, y -unally.",
    ["Win the game by capturing {cps} Control Points."] = "Gana la partida capturando {cps} Puntos de Control.",
    ["You can leave your current alliances by typing -unally, but you won't be able to join a new one."] =
      "Puedes abandonar tus alianzas actuales escribiendo -unally, pero no vas a poder unirte a una nueva.",
    ["Closed Alliance"] = "Alianza Cerrada",
    ["Open Alliance"] = "Alianza Abierta",
    ["Great War (8v8)"] = "Gran Guerra (8v8)",
    ["You are playing as the honorable {clan}.\n\nYou begin in Ashenvale, make your way south to establish your bases, the Echo Isles and Thunder Bluff.\n\nYour allies will be coming south to help you defend against the Old Gods, do not engage them alone."] =
    "Juegas como el honorable {clan}.\n\nComienzas en Vallefresno, dirígete al sur para establecer tus bases, las Islas del Eco y Cima del Trueno.\n\nTus aliados vendrán del sur para ayudarte a defenderte contra los Antiguos Dioses, no los enfrentes solo.",
    ["Grunt"] = "Grunt",
    ["I have wandered alone for many years, little Misha. Yet sometimes, even I grow weary of this endless solitude."] =
      "He vagado solo durante muchos años, pequeña Misha. Sin embargo, a veces hasta yo me canso de esta soledad interminable.",
    ["I have watched the other races. I have seen their squabbling, their ruthlessness. Their wars do nothing but scar the land and drive the wild things to extinction."] =
      "He observado a las otras razas. He visto sus disputas, su crueldad. Sus guerras no hacen más que cicatrizar la tierra y llevar a las criaturas salvajes a la extinción.",
    ["No, they cannot be trusted. Only beasts are above deceit."] =
      "No, no se puede confiar en ellos. Solo las bestias están por encima del engaño.",
    ["Who are you, warrior?"] = "¿Quién eres, guerrero?",
    ["I am Rexxar, last son of the Mok'Nathal."] = "Soy Rexxar, último hijo de los Mok'Nathal.",
    ["Warchief, our ship sustained heavy damage when we passed through the raging maelstrom. It's unsalvageable."] =
      "Jefe de guerra, nuestro barco sufrió graves daños al pasar por el furioso torbellino. No tiene salvación.",
    ["I knew it. Can we confirm our location? Is this Kalimdor?"] =
      "Lo sabía. ¿Podemos confirmar nuestra ubicación? ¿Esto es Kalimdor?",
    ["We traveled due west, as you instructed. This should be it."] =
      "Viajamos directo al oeste, tal como ordenaste. Esto debería ser.",
    ["I am Cairne, chief of the Bloodhoof tauren. You greenskins fight with both savagery and valor. I am intrigued."] =
      "Soy Cairne, jefe de los tauren Pezuña de Sangre. Ustedes, pieles verdes, pelean con salvajismo y valor. Estoy intrigado.",
    ["I am Thrall, and these are my brethren, the orcs. We've come seeking the destiny promised to us."] =
      "Soy Thrall, y estos son mis hermanos, los orcos. Vinimos en busca del destino que se nos prometió.",
    ["Frostwolf Clan"] = "Clan del Lobo Gélido",
    ["Basic"] = "Básico",
    ["Advanced"] = "Avanzado",
    ["Pick your Faction"] = "Elige tu Facción",
    ["Cairne's spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor."] =
      "El espíritu de Cairne ha partido de este mundo. Los Tauren ya han comenzado a venerar a su ancestro caído.",
    ["The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home."] =
      "Las mesetas de Cima del Trueno han sido despojadas de los Tauren. Los Pezuña de Sangre se han quedado sin hogar.",
    ["Maelstrom Spirit"] = "Espíritu del Vórtice",
    ["Your Orc units have a {chance}% chance on attack to call down a lightning bolt dealing {damage} magic damage. Thrall instead has a 100% chance."] =
      "Tus unidades Orcas tienen un {chance}% de probabilidad al atacar de invocar un rayo que inflige {damage} de daño mágico. Thrall en cambio tiene un 100% de probabilidad.",

    // Quest system labels (MacroTools.Quests)
    ["On completion:"] = "Al completarse:",
    ["On failure:"] = "Al fallar:",
    ["Knowledge:"] = "Conocimiento:",
    ["\n|c00FF7F00WARNING|r - Quest {quest} will expire in {turns} turns."] =
      "\n|c00FF7F00ADVERTENCIA|r - La misión {quest} expirará en {turns} turnos.",

    ["Southern Barrens"] = "Southern Barrens",
    ["Northern Barrens"] = "Northern Barrens",

    // Frostwolf - QuestCrossroadsFrostwolf
    ["The Crossroads"] = "La Encrucijada",
    ["The Horde still needs to establish a strong strategic foothold into Kalimdor. Expand into the Barrens and claim the Crossroads."] =
      "La Horda todavía necesita establecer una posición estratégica fuerte en Kalimdor. Expándete hacia Los Baldíos y reclama la Encrucijada.",
    ["Control of the Crossroads"] = "Control de la Encrucijada",

    // Frostwolf - QuestDarkspear
    ["The Darkspear Trolls"] = "Los Trolls Lanza Negra",
    ["Mere months ago, Thrall's forces saved the Darkspear tribe from the brink of extinction at the hands of constant murloc raids. They have recently made a new home on the Echo Isles, and could prove formidable allies in the invasion of Kalimdor."] =
      "Hace apenas unos meses, las fuerzas de Thrall salvaron a la tribu Lanza Negra del borde de la extinción a manos de constantes ataques de murlocs. Recientemente se han asentado en las Islas del Eco, y podrían ser aliados formidables en la invasión de Kalimdor.",
    ["Vol'jin, foremost Shadow Hunter of the Darkspear Tribe, welcomes Thrall to his village with open arms. The trolls of the Echo Isles unanimously agree to join the new Horde."] =
      "Vol'jin, el principal Cazador de Sombras de la tribu Lanza Negra, recibe a Thrall en su aldea con los brazos abiertos. Los trolls de las Islas del Eco acuerdan unánimemente unirse a la nueva Horda.",
    ["You gain control of Echo Isles, and learn to train Vol'jin from the Altar of Storms"] =
      "Obtienes el control de las Islas del Eco, y aprendes a entrenar a Vol'jin desde el Altar de las Tormentas",
    ["Echo Isles"] = "Echo Isles",

    // Frostwolf - QuestDrektharsSpellbook
    ["Drekthar's Spellbook"] = "El Grimorio de Drek'thar",
    ["The elemental planes are out of control. Bring Thrall to the Vortex Pinnacle to bring back the balance."] =
      "Los planos elementales están fuera de control. Lleva a Thrall a la Cumbre del Vórtice para restaurar el equilibrio.",
    ["The Vortex Pinnacle has been captured by the Horde. Drek'thar has gifted Warchief Thrall his magical spellbook for this achievement."] =
      "La Cumbre del Vórtice ha sido capturada por la Horda. Drek'thar le ha obsequiado al Jefe de Guerra Thrall su grimorio mágico por este logro.",
    ["Drek'thar's Spellbook"] = "El Grimorio de Drek'thar",
    ["Vortex Pinnacle"] = "Vortex Pinnacle",

    // Frostwolf - QuestFreeNerzhul
    ["Jailor of the Damned"] = "Carcelero de los Condenados",
    ["Before he became the Lich King, Ner'zhul was the chieftain and elder shaman of the Shadowmoon Clan. Perhaps something of his former self still survives within the Frozen Throne."] =
      "Antes de convertirse en el Rey Exánime, Ner'zhul era el jefe y chamán mayor del Clan Luna Oscura. Quizás algo de su antiguo ser todavía sobreviva dentro del Trono de Hielo.",
    ["The Frozen Throne has been ruptured beyond repair, but Ner'zhul's mangled soul remains imprisoned within. Perhaps the old Shaman will never know peace."] =
      "El Trono de Hielo ha sido destruido más allá de toda reparación, pero el alma destrozada de Ner'zhul permanece aprisionada en su interior. Quizás el viejo Chamán nunca conozca la paz.",
    ["It seems Ner'zhul is finally free from his tortured existence as the bearer of the Helm of Domination."] =
      "Parece que Ner'zhul finalmente es libre de su atormentada existencia como portador del Yelmo de la Dominación.",
    ["Thrall gains 10 Strength, 10 Dexterity, and 10 Intelligence"] =
      "Thrall gana 10 de Fuerza, 10 de Destreza, y 10 de Inteligencia",
    ["Icecrown"] = "Corona de Hielo",

    // Frostwolf - QuestHighmountain
    ["A Feast for Our Kin"] = "Un Festín para Nuestro Pueblo",
    ["Scouts report sighting of the Highmountain totem, thought lost long ago when the Broken Isles were shattered. As a gesture of renewed welcome, Cairne might offer them an invitation to a feast in Thunderbluff."] =
      "Los exploradores reportan haber avistado el tótem de Monte Alto, que se creía perdido desde que las Islas Quebradas fueron destruidas. Como gesto de renovada bienvenida, Cairne podría ofrecerles una invitación a un festín en Cima del Trueno.",
    ["Cairne is welcomed in Highmountain like a lost-long friend. Eager to explore the world and fight alongside their long-lost brethren, the Highmountain send their best hunters to support the Horde, and offer their home as a traveler's respite."] =
      "Cairne es recibido en Monte Alto como un viejo amigo perdido. Ansiosos por explorar el mundo y luchar junto a sus hermanos perdidos hace tiempo, los de Monte Alto envían a sus mejores cazadores para apoyar a la Horda, y ofrecen su hogar como refugio para viajeros.",
    ["Highmountain, north of Stormheim"] = "Monte Alto, al norte de Tormenheim",

    // Frostwolf - QuestMammoth
    ["Lone Wanderer"] = "Errante Solitario",
    ["Rexxar's wanderlust has brought him into contact with all kinds of beasts. Yet there is one major landmass he has never ventured to: the cold expanse of Northrend. Surely the wild things roam free even there."] =
      "El ansia viajera de Rexxar lo ha puesto en contacto con todo tipo de bestias. Sin embargo, hay una gran masa de tierra a la que nunca se ha aventurado: la fría extensión de Rasganorte. Seguramente las criaturas salvajes también deambulen libres allí.",
    ["Rexxar ventures north into lands once thought incompatible with life, and discovers the paradise of furred megafauna that is the Borean Tundra. He tames the woolly mammoths there, and teaches the Frostwolf to ride them into battle."] =
      "Rexxar se aventura hacia el norte, a tierras que alguna vez se creyeron incompatibles con la vida, y descubre el paraíso de megafauna peluda que es la Tundra Boreal. Allí doma a los mamuts lanudos, y enseña a los Lobo Gélido a montarlos en batalla.",
    ["Borean Tundra"] = "Borean Tundra",

    // Frostwolf - QuestOrgrimmarFrostwolf
    ["Build Orgrimmar"] = "Construir Orgrimmar",
    ["To Tame a Land"] = "Domar una Tierra",
    ["This new continent is ripe for the taking. If the Horde is to survive, a new city needs to be built."] =
      "Este nuevo continente está listo para ser tomado. Si la Horda ha de sobrevivir, debe construirse una nueva ciudad.",
    ["The city of Orgrimmar was finally constructed by the Frostwolf engineers, it is now a home for the new Horde and a symbol of power and innovation. Rexxar has now joined the Horde!"] =
      "La ciudad de Orgrimmar fue finalmente construida por los ingenieros Lobo Gélido, ahora es un hogar para la nueva Horda y un símbolo de poder e innovación. ¡Rexxar se ha unido a la Horda!",
    ["Control of all units in Orgrimmar and enable to train Rexxar at the Altar."] =
      "Control de todas las unidades en Orgrimmar y habilita entrenar a Rexxar en el Altar.",

    // Frostwolf - QuestRagetotem
    ["Ragetotem Tribe"] = "Tribu Tótem de Ira",
    ["The Ragetotem Tribe are renowned for their martial prowess. An older, mightier Cairne might convince them to join the Bloodhoof."] =
      "La tribu Tótem de Ira es reconocida por su destreza marcial. Un Cairne más viejo y poderoso podría convencerlos de unirse a los Pezuña de Sangre.",
    ["Tales of Cairne's strength and wisdom reverberate throughout Kalimdor. As strength is drawn to strength, the Ragetotem are drawn to the Bloodhoof."] =
      "Las historias sobre la fuerza y sabiduría de Cairne reverberan por todo Kalimdor. Así como la fuerza atrae a la fuerza, los Tótem de Ira se sienten atraídos hacia los Pezuña de Sangre.",

    // Frostwolf - QuestThunderBluff
    ["The Long March"] = "La Larga Marcha",
    ["The Tauren have been wandering for too long. The fertile plains of Mulgore would offer respite from this endless journey."] =
      "Los Tauren han vagado durante demasiado tiempo. Las fértiles llanuras de Mulgore ofrecerían un respiro de este viaje interminable.",
    ["The long march of the Tauren clans has ended, and they have joined forces with the Horde."] =
      "La larga marcha de los clanes Tauren ha terminado, y han unido fuerzas con la Horda.",
    ["Control of Thunder Bluff and enable Cairne to be trained at the Altar of Storms"] =
      "Control de Cima del Trueno y habilita entrenar a Cairne en el Altar de las Tormentas",
    ["Thunder Bluff"] = "Thunder Bluff",

    // Frostwolf - QuestWorldShaman
    ["The World-Shaman"] = "El Chamán del Mundo",
    ["The elements of Azeroth are in terrible disarray, and the situation only grows worse as rising conflicts threaten to tear our world apart. Thrall, as one of the most formidable Shamans of his time, must take up the mantle of the World-Shaman if he is to save his people - and the world."] =
      "Los elementos de Azeroth están en terrible desorden, y la situación solo empeora mientras crecientes conflictos amenazan con desgarrar nuestro mundo. Thrall, como uno de los Chamanes más formidables de su tiempo, debe asumir el manto del Chamán del Mundo si ha de salvar a su pueblo, y al mundo.",
    ["Thrall has stabilized the power of the Maelstrom and stored it within the Doomhammer. He is no longer merely the Warchief of the Horde; he is the World-Shaman of all Azeroth."] =
      "Thrall ha estabilizado el poder del Maelström y lo ha almacenado dentro del Martillo del Ocaso. Ya no es simplemente el Jefe de Guerra de la Horda; es el Chamán del Mundo de todo Azeroth.",
    ["Thrall gains 2000 experience and 15 to all attributes, and you gain the Power Maelstrom Spirit"] =
      "Thrall gana 2000 de experiencia y 15 a todos sus atributos, y obtienes el Poder Espíritu del Vórtice",
    ["the Maelstrom"] = "el Maelström",
    ["on the Broken Isles and near the Maelstrom"] = "en las Islas Quebradas y cerca del Maelström",
    ["World-Shaman"] = "Chamán del Mundo",

    // Frostwolf - AncestralLegion power (Spells/AncestralLegion.cs)
    ["Ancestor"] = "Ancestro",
    ["Remembered Tauren:"] = "Tauren Recordados:",

    // Dalaran faction
    ["Council of Dalaran"] = "Consejo de Dalaran",
    ["You are playing the wise {faction}.\n\nYou begin in the Hillsbrad Foothills, separated from the main forces of Dalaran. To unlock Dalaran, you must capture Shadowfang Keep, which has been encircled by monsters.\n\nOnce your territory is secured, you will need to prepare for the Plague of Undeath and the invasion of the Burning Legion. Lordaeron will surely need your help.\n\nYour mages are the finest in Azeroth. Be sure to utilize them alongside your heroes to turn the tide of battle."] =
      "Juegas como el sabio {faction}.\n\nComienzas en las Estribaciones de Hillsbrad, separado de las fuerzas principales de Dalaran. Para desbloquear Dalaran, debes capturar el Castillo de Colmillo Oscuro, que ha sido rodeado por monstruos.\n\nUna vez que tu territorio esté asegurado, deberás prepararte para la Plaga de la No-Muerte y la invasión de la Legión Ardiente. Lordaeron seguramente necesitará tu ayuda.\n\nTus magos son los mejores de Azeroth. Asegúrate de utilizarlos junto a tus héroes para cambiar el rumbo de la batalla.",

    // Dalaran - dialogues
    ["Now, at long last, I have returned to set things right. I... am Medivh, the Last Guardian. I tell you now, the only chance for this world is for you to unite in arms against the enemies of all who live!"] =
      "Ahora, por fin, he regresado para enmendar las cosas. Yo... soy Medivh, el Último Guardián. Les digo ahora, la única oportunidad para este mundo es que se unan en armas contra los enemigos de todo lo que vive!",
    ["Hearthglen, finally! I could use some rest!"] = "¡Hearthglen, por fin! ¡Podría usar algo de descanso!",
    ["It pains me to even look at you, Arthas."] = "Me duele hasta mirarte, Arthas.",
    ["I'll be happy to end your torment, old man. I told you that your magics could not stop me."] =
      "Será un placer poner fin a tu tormento, viejo. Te dije que tu magia no podría detenerme.",

    // Dalaran - DeathMessages
    ["The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle."] =
      "La Ciudadela Violeta, el bastión definitivo del conocimiento arcano en los Reinos del Este, se desmorona como un castillo de arena.",
    ["Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind."] =
      "El Archimago Antonidas ha sido abatido, su vasto conocimiento perdido para siempre con su muerte. Los magos de Dalaran han perdido su mente más brillante.",

    // Dalaran - QuestShadowfang
    ["Shadows of Silverpine Forest"] = "Sombras del Bosque de Silverpine",
    ["Shadowfang and Ambermill are under seige by hostile creatures we must clear them out so that they can help us secure our lands"] =
      "Colmillo Oscuro y Ambermill están asediados por criaturas hostiles, debemos eliminarlas para que puedan ayudarnos a asegurar nuestras tierras",
    ["Control of all Buildings and units in Shadowfang"] = "Control de todos los Edificios y unidades en Colmillo Oscuro",

    // Dalaran - QuestSouthshore
    ["Murloc Troubles"] = "Problemas de Murlocs",
    ["A small murloc skirmish is attacking Southshore, push them back"] =
      "Una pequeña escaramuza de murlocs está atacando Costa Sur, recházalos",
    ["Control of all units in Southshore"] = "Control de todas las unidades en Costa Sur",

    // Dalaran - QuestDalaran
    ["Outskirts"] = "Las Afueras",
    ["The territories of Dalaran are fragmented, secure the lands and protect Dalaran citizens."] =
      "Los territorios de Dalaran están fragmentados, asegura las tierras y protege a los ciudadanos de Dalaran.",
    ["Control of all units in Dalaran, enables Antonidas to be trained at the Altar and you can now build Refuges"] =
      "Control de todas las unidades en Dalaran, habilita entrenar a Antonidas en el Altar y ahora puedes construir Refugios",

    // Dalaran - QuestGilneas
    ["The Greymane Wall"] = "El Muro de Greymane",
    ["The Gilneans, fearful of a potential invasion from the frozen north, sealed themselves behind the Greymane Wall. If we are to survive the coming storm, we must force our neighbor back out into the open."] =
      "Los Gilneanos, temerosos de una posible invasión desde el norte helado, se sellaron detrás del Muro de Greymane. Si hemos de sobrevivir a la tormenta que se avecina, debemos obligar a nuestro vecino a salir de nuevo a terreno abierto.",
    [" Gilneas notcing our regained might in Southern-Lordaeron has decided to submit to our might to defend Lordaeron from the iminent Scourge invasion."] =
      "Gilneas, al notar nuestro poder recuperado en el sur de Lordaeron, ha decidido someterse a nuestro poder para defender Lordaeron de la inminente invasión de la Plaga.",
    ["Gain control of Gilneas"] = "Obtienes control de Gilneas",

    // Dalaran - QuestJainaSoulGem
    ["The Soul Gem"] = "La Gema del Alma",
    ["Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered."] =
      "Scholomance alberga una amplia variedad de artefactos profanos. Lleva a Jaina allí para ver qué se puede descubrir.",
    ["Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance."] =
      "Jaina Proudmoore ha descubierto la Gema del Alma dentro de las bóvedas en ruinas de Scholomance.",

    // Dalaran - QuestBlueDragons
    ["The Blue Dragonflight"] = "La Progenie Azul",
    ["The Blue Dragons of Northrend are the wardens of magic on Azeroth. They might be convinced to willingly join the mages of Dalaran."] =
      "Los Dragones Azules de Rasganorte son los guardianes de la magia en Azeroth. Podrían ser convencidos de unirse voluntariamente a los magos de Dalaran.",
    ["The Nexus has been captured. The Blue Dragonflight fights for Dalaran."] =
      "El Nexo ha sido capturado. La Progenie Azul lucha por Dalaran.",
    ["Learn to train Blue Dragons"] = "Aprende a entrenar Dragones Azules",
    ["You can now train Blue Dragons from Military Quarters and the Nexus."] =
      "Ahora puedes entrenar Dragones Azules desde el Cuartel Militar y el Nexo.",

    // Dalaran - QuestKarazhan
    ["Secrets of Karazhan"] = "Secretos de Karazhan",
    ["The spire of Medivh stands mysteriously idle. Dalaran could make use of its grand magicks."] =
      "La torre de Medivh permanece misteriosamente inactiva. Dalaran podría hacer uso de su gran magia.",
    ["Karazhan has been captured. Dalaran's archivists scour its halls for arcane resources."] =
      "Karazhan ha sido capturada. Los archiveros de Dalaran registran sus salones en busca de recursos arcanos.",
    ["Learn to research three powerful upgrades at Karazhan."] = "Aprende a investigar tres poderosas mejoras en Karazhan.",

    // Dalaran - QuestTheramore
    ["The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to abandon Dalaran and establish a refuge there."] =
      "Las tierras lejanas de Kalimdor permanecen intactas por la civilización humana. Si la Tercera Guerra avanza mal, podría ser necesario abandonar Dalaran y establecer un refugio allí.",
    ["Jaina Proudmoore abandons the once mighty city of Dalaran and leads her people across the sea, arriving in the untamed lands of Kalimdor."] =
      "Jaina Proudmoore abandona la otrora poderosa ciudad de Dalaran y guía a su pueblo a través del mar, llegando a las tierras salvajes de Kalimdor.",
    ["Gain control of all units at Theramore and teleport all of your units within Dalaran to Theramore. Dalaran becomes hostile"] =
      "Obtienes control de todas las unidades en Theramore y teletransportas todas tus unidades dentro de Dalaran hacia Theramore. Dalaran se vuelve hostil",
    ["Dalaran has fallen. Those who managed to survive its destruction travel west, to the distant lands of Kalimdor. They hope that this new world will treat them more kindly than the one they left behind."] =
      "Dalaran ha caído. Aquellos que lograron sobrevivir a su destrucción viajan hacia el oeste, a las tierras lejanas de Kalimdor. Esperan que este nuevo mundo los trate con más benevolencia que el que dejaron atrás.",
    ["Gain control of all units at Theramore"] = "Obtienes control de todas las unidades en Theramore",

    // Dalaran - QuestCrystalGolem
    ["Crystalsong Forest"] = "Crystalsong Forest",
    ["The living crystal of the Crystalsong Forest suffers from its proximity to the Legion. Freed from that corruption, it could be used to empower Dalaran's constructs."] =
      "El cristal viviente del Bosque Cantoscristal sufre por su cercanía a la Legión. Liberado de esa corrupción, podría usarse para potenciar los constructos de Dalaran.",
    ["Dalaran's Earth Golems have been infused with living crystal."] = "Los Gólems de Tierra de Dalaran han sido imbuidos con cristal viviente.",
    ["Transform your Earth Golems into Crystal Golems"] = "Transforma tus Gólems de Tierra en Gólems de Cristal",

    // Dalaran - QuestFallenGuardian
    ["The Fallen Guardian"] = "El Guardián Caído",
    ["Medivh's body was corrupted by Sargeras at conception. Now that he is dead, the secrets of the Tomb of Sargeras and Karazhan combined might allow the mages of Dalaran to cleanse his spirit."] =
      "El cuerpo de Medivh fue corrompido por Sargeras desde su concepción. Ahora que está muerto, los secretos combinados de la Tumba de Sargeras y Karazhan podrían permitir a los magos de Dalaran purificar su espíritu.",
    ["Medivh's spirit has been cleansed of Sargeras' influence, allowing him to return to Azeroth for a time."] =
      "El espíritu de Medivh ha sido purificado de la influencia de Sargeras, permitiéndole regresar a Azeroth por un tiempo.",
    ["You can summon Medivh from the Altar of Knowledge"] = "Puedes invocar a Medivh desde el Altar del Conocimiento",

    // Dalaran - QuestAegwynn
    ["Return from Exile"] = "Regreso del Exilio",
    ["A new generation of Mages are in dire need of council. The exiled Aegwynn, used to be a Guardian of Tirisfal. Grabbing her attention will require powerful wizards."] =
      "Una nueva generación de Magos necesita desesperadamente consejo. La exiliada Aegwynn, alguna vez fue Guardiana de Tirisfal. Captar su atención requerirá magos poderosos.",
    ["Aegwynn will also be trainable at the altar."] = "Aegwynn también será entrenable en el altar.",

    // Dalaran - QuestNewGuardian
    ["Guardian of Tirisfal"] = "Guardián de Tirisfal",
    ["Medivh's death left Azeroth without a Guardian. The spell book he left behind could be used to empower a new one."] =
      "La muerte de Medivh dejó a Azeroth sin un Guardián. El libro de hechizos que dejó atrás podría usarse para empoderar a uno nuevo.",
    ["Dalaran has empowered Jaina to be the new Guardian of Tirisfal, endowing her with a portion of the Council of Tirisfal's power."] =
      "Dalaran ha empoderado a Jaina para ser la nueva Guardiana de Tirisfal, otorgándole una porción del poder del Consejo de Tirisfal.",
    ["Grant Jaina Chaos Damage, 20 additional Intelligence, Teleport, and Mana Shield."] =
      "Otorga a Jaina Daño Caos, 20 de Inteligencia adicional, Teletransporte, y Escudo de Maná.",

    // Draenei faction
    ["You are playing as the exiled {faction}.\n\nYou begin on Azuremyst Island, amid the wreckage of your flight from the Burning Legion.\n\nFurther inland your Night-elf allies will need your help against the Old Gods. Quickly build your base and gain entry to the Exodar.\n\nPower up your buildings with your Arcane Wells to unlock powerful global abilities."] =
      "Juegas como los {faction} exiliados.\n\nComienzas en la Isla Azuremyst, entre los restos de tu huida de la Legión Ardiente.\n\nMás hacia el interior, tus aliados Elfos Nocturnos necesitarán tu ayuda contra los Antiguos Dioses. Construye tu base rápidamente y consigue entrada al Exodar.\n\nPotencia tus edificios con tus Pozos Arcanos para desbloquear poderosas habilidades globales.",

    // Draenei - QuestRepairExodarHull
    ["A New Home"] = "Un Nuevo Hogar",
    ["After the disastrous voyage through the Twisting Nether, the Exodar crash-landed on Azuremyst Isle. We need to secure the surrounding islands for resources."] =
      "Tras el desastroso viaje a través del Vacío Abisal, el Exodar se estrelló en la Isla Azuremyst. Necesitamos asegurar las islas circundantes para obtener recursos.",
    ["We have rebuilt the Exodar. Its systems thrum to life, pulsating with crystalline energy."] =
      "Hemos reconstruido el Exodar. Sus sistemas cobran vida vibrante, pulsando con energía cristalina.",
    ["The Exodar is destroyed. It can never be repaired again."] = "El Exodar ha sido destruido. Nunca podrá repararse de nuevo.",
    ["on Azuremyst Isle"] = "en la Isla Azuremyst",
    ["Gain control of all units in the Exodar and learn to train Nobundo from the {altar}"] =
      "Obtienes control de todas las unidades en el Exodar, y aprendes a entrenar a Nobundo desde el {altar}",

    // Draenei - QuestRebuildCivilisation
    ["The Way Forward"] = "El Camino a Seguir",
    ["The Draenei will need to rebuild their civilisation in Azeroth. Darkshore seems like a perfect place for the birth of the second Draenei settlement."] =
      "Los Draenei necesitarán reconstruir su civilización en Azeroth. Costa Oscura parece un lugar perfecto para el nacimiento del segundo asentamiento Draenei.",
    ["Gain an Outpost in Darkshore and Maraad is now trainable at the altar."] =
      "Obtienes un Puesto Avanzado en Costa Oscura y Maraad ahora es entrenable en el altar.",
    ["in Darkshore"] = "en Costa Oscura",

    // Draenei - QuestShipArgus
    ["Reconquering Tempest Keep"] = "Reconquistando la Fortaleza Tempestuosa",
    ["Tempest Keep still has the power to open a portal Argus, but Velen needs to channel it"] =
      "La Fortaleza Tempestuosa todavía tiene el poder de abrir un portal a Argus, pero Velen necesita canalizarlo",
    ["Open a Portal between Tempest Keep and Argus"] = "Abre un Portal entre la Fortaleza Tempestuosa y Argus",
    ["Tempest Keep"] = "la Fortaleza Tempestuosa",

    // Draenei - QuestRepairGenerator
    ["Core of the Ship"] = "Núcleo de la Nave",
    ["The broken core of the Exodar should be rebuilt, bringing us one step closer to making it usable again."] =
      "El núcleo destrozado del Exodar debe ser reconstruido, acercándonos un paso más a hacerlo utilizable de nuevo.",
    ["The Exodar's core has been rebuilt - the Crystal Protectors around it now shield it from any harm."] =
      "El núcleo del Exodar ha sido reconstruido - los Protectores de Cristal a su alrededor ahora lo protegen de cualquier daño.",
    ["The Exodar Generator becomes invulnerable until all Crystal Protectors around it have been destroyed"] =
      "El Generador del Exodar se vuelve invulnerable hasta que todos los Protectores de Cristal a su alrededor sean destruidos",

    // Draenei - QuestTriumvirate
    ["Crown of the Triumvirate"] = "Corona del Triunvirato",
    ["Eons ago, the council that led the Eredar was the Triumvirate. If Velen could reconquer Argus, he could reform the Crown of the Triumvirate"] =
      "Hace eones, el consejo que lideraba a los Eredar era el Triunvirato. Si Velen pudiera reconquistar Argus, podría reformar la Corona del Triunvirato",
    ["Velen has liberated Argus and re-assembled the Crown of Triumvirate"] = "Velen ha liberado Argus y ha reensamblado la Corona del Triunvirato",
    ["You gain the powerful item, the Crown of the Triumvirate"] = "Obtienes el poderoso objeto, la Corona del Triunvirato",

    // Draenei - QuestDimensionalShip
    ["The Dimensional Ship"] = "La Nave Dimensional",
    ["The core of the Exodar is rebuilt, but it requires a great source of power to function again. Finding that source of power would make the Exodar a powerful asset for the Draenei."] =
      "El núcleo del Exodar está reconstruido, pero requiere una gran fuente de poder para funcionar de nuevo. Encontrar esa fuente de poder haría del Exodar un activo poderoso para los Draenei.",
    ["With the acquisition of a replacement power source, the Exodar's gemcrafters set to work reigniting the ship's dimensional portals. The Dimensional Generator can now now be used to travel the planes once more."] =
      "Con la adquisición de una fuente de poder de reemplazo, los talladores de gemas del Exodar se ponen a trabajar para reencender los portales dimensionales de la nave. El Generador Dimensional ahora puede usarse para viajar entre los planos una vez más.",
    ["The Dimensional Generator gains the ability to channel portals to Argus and Outland. The Lightforged units and A'dal will become available"] =
      "El Generador Dimensional obtiene la habilidad de canalizar portales hacia Argus y Terrallende. Las unidades Forjadas de Luz y A'dal estarán disponibles",

    // Druids faction
    ["Druids of the Cenarion Circle"] = "Druidas del Círculo Cenarion",
    ["You are playing as the ancient {faction}.\n\nYou begin isolated in the deepest parts of Mount Hyjal near the World Tree.\n\nThe Old Gods are gathering to burn Ashenvale forest and the World Tree. Cenarius has emerged from his seclusion to stop them. Use him to awaken Malfurion from his slumber as soon as possible.\n\nGather your forces and strike before the Old Gods can organize their efforts."] =
      "Juegas como los ancestrales {faction}.\n\nComienzas aislado en las partes más profundas del Monte Hyjal, cerca del Árbol del Mundo.\n\nLos Antiguos Dioses se están reuniendo para quemar el bosque de Vallefresno y el Árbol del Mundo. Cenarius ha emergido de su reclusión para detenerlos. Úsalo para despertar a Malfurion de su letargo lo antes posible.\n\nReúne tus fuerzas y ataca antes de que los Antiguos Dioses puedan organizar sus esfuerzos.",

    // Druids - dialogues (DruidsFaction.RegisterDialogue / RegisterSentinelsDialogue)
    ["Satyr"] = "Sátiro",
    ["Come no further, weakling!  Lord Tichondrius commanded us to kill anyone attempting to enter this place, and we shall."] =
      "¡No sigas avanzando, débil! El Señor Tichondrius nos ordenó matar a cualquiera que intente entrar en este lugar, y lo haremos.",
    ["Patches wretches! It pains me that you once called yourselves Night Elves."] =
      "¡Miserables desgraciados! Me apena que alguna vez se hicieran llamar Elfos Nocturnos.",
    ["Satyr camp"] = "campamento de sátiros",
    ["The horn has sounded, and I have come as promised! I smell the stench of decay and corruption in our land. That angers me greatly."] =
      "¡El cuerno ha sonado, y he venido tal como prometí! Huelo el hedor de la decadencia y la corrupción en nuestra tierra. Eso me enfurece enormemente.",
    ["It has been a thousand years since I last looked up you, Tyrande. I thought of you every moment I roamed through the Emerald Dream."] =
      "Ha pasado mil años desde la última vez que te vi, Tyrande. Pensé en ti cada momento que vagué por el Sueño Esmeralda.",
    ["My heart rejoices to see you again, Furion. But I would not have awakened you unless the need was urgent."] =
      "Mi corazón se alegra de verte de nuevo, Furion. Pero no te habría despertado si la necesidad no fuera urgente.",
    ["In the Dream, I felt our land being corrupted, just as if it were my own body. You were right to awaken me."] =
      "En el Sueño, sentí que nuestra tierra se corrompía, como si fuera mi propio cuerpo. Hiciste bien en despertarme.",
    ["Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?"] =
      "¿Quién se atreve a profanar esta tierra ancestral? ¿Quién se atreve a desafiar la ira de Cenarius y los Elfos Nocturnos?",

    // Druids - DeathMessages (DruidsLegends.cs, Mechanics/CenariusGhost.cs)
    ["The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor."] =
      "El Señor del Bosque, Cenarius, ha caído. Los druidas de los Kaldorei han perdido a su más grande mentor.",
    ["Cenarius, Demigod of the Night Elves, has fallen. His spirit lives on, a mere echo of his former self."] =
      "Cenarius, Semidiós de los Elfos Nocturnos, ha caído. Su espíritu perdura, un mero eco de lo que fue.",

    // Druids - QuestMalfurionAwakens
    ["Awakening of Stormrage"] = "El Despertar de Rabia de Tormenta",
    ["Ever since the War of the Ancients ten thousand years ago, Malfurion Stormrage and his druids have slumbered within the Barrow Den. Now, their help is required once again."] =
      "Desde la Guerra de los Ancestros hace diez mil años, Malfurion Rabia de Tormenta y sus druidas han dormido dentro del Túmulo. Ahora, se requiere su ayuda una vez más.",
    ["Malfurion has emerged from his deep slumber in the Barrow Den. Darnassus and the Moonglade ancients have been awakened."] =
      "Malfurion ha emergido de su profundo letargo en el Túmulo. Darnassus y los ancestros del Claro de Luna han despertado.",
    ["Gain Nordrassil, the Darnassus base, the Moonglade base, the hero Malfurion, and the artifact G'hanir"] =
      "Obtienes Nordrassil, la base de Darnassus, la base del Claro de Luna, el héroe Malfurion, y el artefacto G'hanir",
    ["The Barrow Den"] = "el Túmulo",

    // Druids - QuestShrineBase
    ["Hyjal's Rest"] = "El Descanso de Hyjal",
    ["Mount Hyjal has been invaded by the corruption already affecting Felwood. Clear them out to awaken the Ancients"] =
      "El Monte Hyjal ha sido invadido por la corrupción que ya afecta a Felwood. Elimínalos para despertar a los Ancestros",
    ["Control of all units in the Shrine of Malorne base"] = "Control de todas las unidades en la base del Santuario de Malorne",
    ["in Hyjal"] = "en Hyjal",

    // Druids - QuestRiseBase
    ["The Druid's Rise"] = "El Ascenso del Druida",
    ["Theres a dormant ancient's grove at the base of Hyjal, take control of the area to nurture it back and awaken it!"] =
      "¡Hay una arboleda ancestral dormida en la base de Hyjal, toma control del área para nutrirla y despertarla!",
    ["Control of all units in the Ascendant's Rise base"] = "Control de todas las unidades en la base de Ascenso del Ascendente",

    // Druids - QuestAshenvale
    ["The Spirits of Ashenvale"] = "Los Espíritus de Vallefresno",
    ["The forest needs healing. Regain control of it to awaken it."] = "El bosque necesita sanar. Recupera el control de él para despertarlo.",
    ["Ashenvale has awakened!"] = "¡Vallefresno ha despertado!",
    ["Control of all units in Ashenvale"] = "Control de todas las unidades en Vallefresno",

    // Druids - QuestDruidsKillCthun
    ["The War of the Shifting Sands"] = "La Guerra de las Arenas Cambiantes",
    ["The ravaging hordes of the Qiraji have been consumming Kalimdor. We must put an end to their rampage."] =
      "Las hordas devastadoras de los Qiraji han estado consumiendo Kalimdor. Debemos poner fin a su desenfreno.",
    ["The Qiraji presence on Kalimdor has been eliminated. The sacred lands are safe from them."] =
      "La presencia Qiraji en Kalimdor ha sido eliminada. Las tierras sagradas están a salvo de ellos.",
    ["You can now train Siege Ancients at the Ancient of War."] = "Ahora puedes entrenar Ancestros de Asedio en el Ancestro de Guerra.",

    // Druids - QuestAndrassil
    ["Crown of the Snow"] = "Corona de la Nieve",
    ["Long ago, Fandral Staghelm cut a sapling from Nordrassil and used it to grow Andrassil in Northrend. Without the blessing of the Aspects, it fell to the Old Gods' corruption. If Northrend were to be reclaimed, Andrassil's growth could begin anew."] =
      "Hace mucho tiempo, Fandral Staghelm cortó un retoño de Nordrassil y lo usó para hacer crecer Andrassil en Rasganorte. Sin la bendición de los Aspectos, cayó ante la corrupción de los Antiguos Dioses. Si Rasganorte fuera reconquistado, el crecimiento de Andrassil podría comenzar de nuevo.",
    ["With Grizzly Hills now being tended by the Trees of Life, the time is ripe to regrow Andrassil in the hope that it can help reclaim this barren land."] =
      "Con las Colinas Pardas ahora cuidadas por los Árboles de la Vida, es momento propicio para hacer crecer Andrassil de nuevo, con la esperanza de que ayude a reclamar esta tierra baldía.",

    // Druids - QuestShaladrassil
    ["Crown of Shadow"] = "Corona de la Sombra",
    ["The World Tree Shaladrassil was planted in the land once known as Val'sharah, the cradle of Druidic culture. Val'sharah was shattered by the Great Sundering along with the rest of the Broken Isles. The tree still remains, but without a Druidic presence it will wither in time."] =
      "El Árbol del Mundo Shaladrassil fue plantado en la tierra alguna vez conocida como Val'sharah, la cuna de la cultura Druida. Val'sharah fue destrozada por la Gran Fragmentación junto con el resto de las Islas Quebradas. El árbol todavía permanece, pero sin presencia Druida se marchitará con el tiempo.",
    ["With Shaladrassil back under Druidic control, its roots begin to swell and its branches bloom flowers anew, as if welcoming the Night elves home."] =
      "Con Shaladrassil de vuelta bajo control Druida, sus raíces comienzan a hincharse y sus ramas florecen de nuevo, como si dieran la bienvenida a los Elfos Nocturnos a casa.",
    ["You gain the Shaladrassil's Blessing Power"] = "Obtienes el Poder Bendición de Shaladrassil",

    // Druids - QuestTortolla
    ["The Turtle Demigod"] = "El Semidiós Tortuga",
    ["Tortolla was badly wounded during the War of the Ancients, and has been resting ever since."] =
      "Tortolla resultó gravemente herido durante la Guerra de los Ancestros, y ha estado descansando desde entonces.",
    ["Tortolla has finally awoken from his ancient slumber."] = "Tortolla finalmente ha despertado de su antiguo letargo.",
    ["You can summon Tortolla from the Altar of Elders"] = "Puedes invocar a Tortolla desde el Altar de los Ancianos",

    // FelHorde faction
    ["Fel Horde"] = "la Horda Fel",
    ["You are playing as the bloodthirsty {faction}.\n\nYou begin in Nagrand, cut off from your forces in Hellfire Citadel. You must raise an army and quickly conquer Outland.\n\nOnce Outland is under your control, gather your hordes and prepare to invade Azeroth through the Dark Portal.\n\nThe Alliance is gathering outside the Dark Portal to stop you, so prepare for a very hard breakout."] =
      "Juegas como la sanguinaria {faction}.\n\nComienzas en Nagrand, aislado de tus fuerzas en la Ciudadela del Fuego Infernal. Debes levantar un ejército y conquistar Terrallende rápidamente.\n\nUna vez que Terrallende esté bajo tu control, reúne tus hordas y prepárate para invadir Azeroth a través del Portal Oscuro.\n\nLa Alianza se está reuniendo fuera del Portal Oscuro para detenerte, así que prepárate para una fuga muy difícil.",

    // FelHorde - DeathMessages (FelHordeLegends.cs)
    ["Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."] =
      "El alma demoníaca eterna de Magtheridon ha sido consumida, y su vida se ha extinguido permanentemente. El Señor de Terrallende ha caído.",
    ["Blackrock Spire has been razed."] = "La Cima de Roca Negra ha sido arrasada.",
    ["Kilsorrow Fortress has been razed."] = "La Fortaleza Kilsorrow ha sido arrasada.",

    // FelHorde - QuestHellfireCitadel
    ["The Citadel"] = "La Ciudadela",
    ["The clans holding Hellfire Citadel do not respect Kargath's authority yet, Magtheridon is being kept alive by Illidan, if we break him, he could serve us well."] =
      "Los clanes que retienen la Ciudadela del Fuego Infernal aún no respetan la autoridad de Kargath, Magtheridon está siendo mantenido con vida por Illidan, si lo quebramos, podría servirnos bien.",
    ["Control of all units in Hellfire Citadel and enable Magtheridon to be trained at the altar"] =
      "Control de todas las unidades en la Ciudadela del Fuego Infernal y habilita entrenar a Magtheridon en el altar",

    // FelHorde - QuestRuinsofShadowmoon (file QuestRebuildBlackTemple.cs)
    ["Ash and Smoke"] = "Cenizas y Humo",
    ["In the ashes of the battle of Black Temple, the Fel Horde will rebuild their bases of operation to support their new overlord"] =
      "En las cenizas de la batalla del Templo Negro, la Horda Fel reconstruirá sus bases de operaciones para apoyar a su nuevo señor",
    ["Gain control of the base in Shadowmoon Valley"] = "Obtienes control de la base en el Valle de Sombraluna",
    ["Shadowmoon Valley"] = "el Valle de Sombraluna",

    // FelHorde - QuestBlackrock
    ["Blackrock Unification"] = "Unificación de Roca Negra",
    ["Make contact with the Blackrock clan and convince them to join Magtheridon"] =
      "Contacta al clan Roca Negra y convéncelos de unirse a Magtheridon",
    ["Control of all units in Blackrock Citadel, a small outpost near the Dark Portal and enable Dal'rend Blackhand to be trained at the altar"] =
      "Control de todas las unidades en la Ciudadela de Roca Negra, un pequeño puesto avanzado cerca del Portal Oscuro y habilita entrenar a Dal'rend Blackhand en el altar",

    // FelHorde - QuestFelHordeKillIronforge
    ["Felsteel Refining"] = "Refinación de Acero Fel",
    ["The smiths of Ironforge have long been put to use crafting goods and war machinery. In the hands of the Fel Horde, they could be used to smelt and refine the ultimate metal: Felsteel."] =
      "Los herreros de Forjaz han sido utilizados durante mucho tiempo para fabricar bienes y maquinaria de guerra. En manos de la Horda Fel, podrían usarse para fundir y refinar el metal definitivo: el Acero Fel.",
    ["The Great Forge has been annihilated. The Fel Horde's peons immediately salvage its intact refineries and put them to purpose in the creation of Felsteel."] =
      "La Gran Forja ha sido aniquilada. Los peones de la Horda Fel salvan de inmediato sus refinerías intactas y las ponen a su servicio en la creación de Acero Fel.",

    // FelHorde - QuestFelHordeKillStormwind
    ["Those Who Came Before"] = "Aquellos Que Vinieron Antes",
    ["During the Second War, the souls of slain Shadow Council members were infused into the corpses of Stormwind knights to create the Death Knights. If Stormwind were to fall again, the unholy order could return."] =
      "Durante la Segunda Guerra, las almas de los miembros caídos del Consejo de las Sombras fueron infundidas en los cadáveres de los caballeros de Ventormenta para crear a los Caballeros de la Muerte. Si Ventormenta cayera de nuevo, la orden impía podría regresar.",
    ["Stormwind's annihilation has left behind the corpses of thousands of elite knights. As occurred during the Second War, these corpses have been filled with the souls of slain Shadow Council members, recreating the indominatable order of Death Knights."] =
      "La aniquilación de Ventormenta ha dejado atrás los cadáveres de miles de caballeros de élite. Tal como ocurrió durante la Segunda Guerra, estos cadáveres han sido llenados con las almas de los miembros caídos del Consejo de las Sombras, recreando la indomable orden de los Caballeros de la Muerte.",

    // FelHorde - QuestGuldansLegacy
    ["Gul'dans Legacy"] = "El Legado de Gul'dan",
    ["The Orc Warlock Gul'dan is ultimately responsible for the formation of the Fel Horde. Though long dead, his teachings could still be extracted from his body."] =
      "El Brujo Orco Gul'dan es en última instancia responsable de la formación de la Horda Fel. Aunque lleva mucho tiempo muerto, sus enseñanzas todavía podrían extraerse de su cuerpo.",
    ["Gul'dan's remains have been located within the Tomb of Sargeras. His eldritch knowledge may now be put to purpose."] =
      "Los restos de Gul'dan han sido localizados dentro de la Tumba de Sargeras. Su conocimiento arcano ahora puede ponerse en práctica.",
    ["Gul'dan's corpse in the Tomb of Sargeras"] = "el cadáver de Gul'dan en la Tumba de Sargeras",

    // FelHorde - QuestDarkPortal
    ["The Dark Portal"] = "El Portal Oscuro",
    ["Following the Second War, the archmage Khadgar and his fellow magi sealed the Dark Portal so that it would never again be used to threaten Azeroth. Little did they know that their magicks were only temporary, and that the portal would open again in time."] =
      "Tras la Segunda Guerra, el archimago Khadgar y sus compañeros magos sellaron el Portal Oscuro para que nunca más pudiera usarse para amenazar Azeroth. Poco sabían que su magia era solo temporal, y que el portal se abriría de nuevo con el tiempo.",
    ["The Dark Portal, previously thought to have been sealed forever, has been opened once more. The people of Stormwind are about to relive their worst nightmares, as the demonic Fel Horde spills forth from Outland to resume their slaughterous rampage."] =
      "El Portal Oscuro, que se creía sellado para siempre, ha sido abierto una vez más. La gente de Ventormenta está a punto de revivir sus peores pesadillas, mientras la demoníaca Horda Fel se derrama desde Terrallende para reanudar su sanguinaria carnicería.",
    ["The Dark Portal can be used to teleport units between the Eastern Kingdoms and Outland"] =
      "El Portal Oscuro puede usarse para teletransportar unidades entre los Reinos del Este y Terrallende",

    // Objective description templates (shared across all quests, tokens substituted after lookup)
    ["Cast {spell}"] = "Lanza {spell}",
    ["Anyone casts {spell}"] = "Cualquiera lanza {spell}",
    ["{hero} is at {rect}"] = "{hero} está en {rect}",
    ["{hero} is level {level}"] = "{hero} está en el nivel {level}",
    ["Have {hero} channel at {rect} for {duration} seconds"] = "Haz que {hero} canalice en {rect} durante {duration} segundos",
    ["You control {target} and all nearby creeps are dead ({current}/{max})"] =
      "Controlas {target} y todos los creeps cercanos están muertos ({current}/{max})",
    ["You control {target}"] = "Controlas {target}",
    ["You control all CPs {rect} ({current}/{max})"] = "Controlas todos los PC {rect} ({current}/{max})",
    ["Turn {turn} hasn't started"] = "El turno {turn} no ha comenzado",
    ["Turn {turn} has started"] = "El turno {turn} ha comenzado",
    ["{target} is destroyed"] = "{target} está destruido",
    ["The Frozen Throne is {state}"] = "El Trono de Hielo está {state}",
    ["Alive"] = "Intacto",
    ["Ruptured"] = "Destruido",
    ["Empty"] = "Vacío",
    ["{a} or {b}"] = "{a} o {b}",
    ["Research {research} from {structure}"] = "Investiga {research} desde {structure}",
    ["Research {research} from the {structure}"] = "Investiga {research} desde el {structure}",
    ["You have a hero at {rect}"] = "Tienes un héroe en {rect}",
    ["You have a unit at {rect}"] = "Tienes una unidad en {rect}",
    ["{hero} has spent {points} Skill Points"] = "{hero} ha gastado {points} Puntos de Habilidad",
    ["Destroy any player-owned enemy capital"] = "Destruye cualquier capital enemiga controlada por un jugador",
    ["{target} is Control Level {level} or higher ({current}/{level})"] =
      "{target} tiene Nivel de Control {level} o superior ({current}/{level})",
    ["{target} is Control Level {level} or higher"] = "{target} tiene Nivel de Control {level} o superior",
    ["Permanently kill {target}"] = "Mata permanentemente a {target}",
    ["{target} is permanently dead"] = "{target} está permanentemente muerto",
    ["Kill {target}"] = "Mata a {target}",
    ["{target} is dead"] = "{target} está muerto",
    ["Kill {required} non-summoned enemy units ({current}/{required})"] =
      "Mata a {required} unidades enemigas no invocadas ({current}/{required})",
    ["Build {count} different buildings {area} ({current}/{count})"] =
      "Construye {count} edificios diferentes {area} ({current}/{count})",
    ["Upgrade your {from} to a {to}"] = "Mejora tu {from} a un {to}",
    ["Complete the quest {quest}"] = "Completa la misión {quest}",
    ["{target} has been destroyed"] = "{target} ha sido destruido",
    ["{legend} has {item}"] = "{legend} tiene {item}",
    ["{target} is intact"] = "{target} está intacto",
    ["{target} is alive"] = "{target} está vivo",
    ["Place a valid power source in the {target}"] = "Coloca una fuente de poder válida en el {target}",
    ["All creeps {area} are dead ({current}/{max})"] = "Todos los creeps {area} están muertos ({current}/{max})",
    ["Repair {target} to {hp} hit points"] = "Repara a {target} hasta {hp} puntos de vida",
    ["Bring {target} to {hp} hit points"] = "Lleva a {target} hasta {hp} puntos de vida",
    ["Acquire {item}"] = "Consigue {item}",
    ["Bring {item} to {rect}"] = "Lleva {item} a {rect}",
    ["{attacker} has dealt damage within 500 units of {target}"] = "{attacker} ha infligido daño a menos de 500 unidades de {target}",
    ["{hero}'s Blessing"] = "Bendición de {hero}",
    ["When a unit you control would take lethal damage, it has a {chance}% chance to instead be restored to {amount}% of its maximum hit points. Only active while your team controls a World Tree."] =
      "Cuando una unidad que controlas recibiría daño letal, tiene un {chance}% de probabilidad de restaurarse al {amount}% de sus puntos de vida máximos en su lugar. Solo está activo mientras tu equipo controle un Árbol del Mundo.",
    ["Immortality"] = "Inmortalidad",

    // Gilneas faction
    ["Kingdom of Gilneas"] = "el Reino de Gilneas",
    ["You are playing as the accursed {faction}.\n\nYou start beyond the Greymane Wall at Pyrewood Village;\n\nYou must raise an army and fight back against the feral wolves of Silverpine and the bandit lords of Durnholde that have taken over Southern-Lordaeron.\n\nOnce you have reclaimed Southern-Lordaeron, open Greymane's Gate and march North to assist Lordaeron and Dalaran with the plague, if it's not too late."] =
      "Juegas como el maldito {faction}.\n\nComienzas más allá del Muro de Greymane, en la Aldea de Pyrewood;\n\nDebes levantar un ejército y contraatacar a los lobos feroces de Silverpine y a los señores bandidos de Durnholde que se han apoderado del sur de Lordaeron.\n\nUna vez que hayas recuperado el sur de Lordaeron, abre la Puerta de Greymane y marcha al norte para ayudar a Lordaeron y Dalaran con la plaga, si no es demasiado tarde.",

    // Gilneas - QuestShadowfangKeep
    ["Shadowfang Keep"] = "Shadowfang Keep",
    ["Shadowfang and Ambermill are under seige by hostile creatures we must clear them out so that they can help us secure our lost lands."] =
      "Colmillo Oscuro y Ambermill están asediados por criaturas hostiles, debemos eliminarlas para que puedan ayudarnos a asegurar nuestras tierras perdidas.",
    ["Control of all buildings and units in Shadowfang."] = "Control de todos los edificios y unidades en Colmillo Oscuro.",

    // Gilneas - QuestSouthshoregil
    ["SouthShore"] = "Costa Sur",
    ["Southshore a great port city in Southern Lordaeron is under seige by murlocks if we clear them out they will rally to our cause."] =
      "Costa Sur, una gran ciudad portuaria en el sur de Lordaeron, está asediada por murlocs; si los eliminamos, se unirán a nuestra causa.",
    ["Control of all buildings in Southshore Village"] = "Control de todos los edificios en la Aldea de Costa Sur",

    // Illidari - QuestBrokenIsles
    ["The Broken Isles"] = "Las Islas Quebradas",
    ["the Broken Isles"] = "las Islas Quebradas",
    ["With Outland now under Illidan's command, the Demon Hunter has returned to the Broken Isles in search of a legendary demonic artifact: the Eye of the Dark Titan, Sargeras."] =
      "Con Terrallende ahora bajo el mando de Illidan, el Cazador de Demonios ha regresado a las Islas Quebradas en busca de un artefacto demoníaco legendario: el Ojo del Titán Oscuro, Sargeras.",
    ["The Broken Isles have been scoured, and it is now clear that the way to the Tomb of Sargeras is closed. Illidan must return to Outland, biding his time before he is strong enough to unlock the Tomb's secrets."] =
      "Las Islas Quebradas han sido rastreadas, y ahora está claro que el camino a la Tumba de Sargeras está cerrado. Illidan debe regresar a Terrallende, esperando su momento hasta ser lo bastante fuerte para desvelar los secretos de la Tumba.",
    ["Open a one-way portal to Black Temple"] = "Abre un portal de un solo sentido hacia el Templo Negro",
    ["the Tomb of Sargeras entrance"] = "la entrada de la Tumba de Sargeras",

    // Illidari - QuestBlackTemple
    ["Return to Outland"] = "Regreso a Terrallende",
    ["Illidan's servants in Outland have been left to their own devices for too long; he must return swiftly if he is to prepare them for the coming war."] =
      "Los sirvientes de Illidan en Terrallende han quedado a su suerte durante demasiado tiempo; debe regresar con rapidez si quiere prepararlos para la guerra que se avecina.",
    ["Illidan returns triumphant to Black Temple, the seat of his power. The orcs and demons of Outland hail his coming."] =
      "Illidan regresa triunfante al Templo Negro, la sede de su poder. Los orcos y demonios de Terrallende aclaman su llegada.",
    ["Gain control of the Black Temple, learn to train Lady Vashj from the Altar of the Betrayer, abandon your base in the Broken Isles"] =
      "Obtén control del Templo Negro, aprende a entrenar a Lady Vashj desde el Altar del Traidor, y abandona tu base en las Islas Quebradas",
    ["Black Temple"] = "Black Temple",

    // Illidari - QuestAzsharasVein
    ["Azshara's Vein"] = "La Vena de Azshara",
    ["Beneath Eldarath and the coast of Azshara lies a convergence of ancient ley lines, once mapped and manipulated by the Highborne. Lady Vashj believes the remnants of their arcane workings can still be studied to uncover knowledge thought to be long-lost."] =
      "Bajo Eldarath y la costa de Azshara yace una convergencia de antiguas líneas ley, antaño cartografiadas y manipuladas por los Altos Nacidos. Lady Vashj cree que los restos de su labor arcana aún pueden estudiarse para desvelar conocimientos que se creían perdidos hace mucho.",
    ["By examining the ley line nexus and the remnants of Highborne arcane structures, the Illidari recover forgotten principles of the arcane, expanding their understanding of Azeroth’s ancient magic."] =
      "Al examinar el nexo de líneas ley y los restos de estructuras arcanas de los Altos Nacidos, los Illidari recuperan principios olvidados de lo arcano, ampliando su comprensión de la antigua magia de Azeroth.",
    ["Azshara Coast"] = "Azshara Coast",

    // Illidari - QuestZangarmarsh
    ["Coilfang Reservoir"] = "Reserva Colmillo Torcido",
    ["Lady Vashj and her Naga were instrumental in securing Outland, and for their deeds received the swamp of Zangarmarsh. It has become overrun in recent times, and must be reclaimed if the Naga are to aid in the fight against the Alliance."] =
      "Lady Vashj y sus Naga fueron fundamentales para asegurar Terrallende, y por sus hazañas recibieron el pantano de Zangarmarsh. Últimamente ha sido invadido, y debe ser reconquistado si los Naga han de ayudar en la lucha contra la Alianza.",
    ["With the swamps of Zangarmarsh secured, Lady Vashj and her Naga begin the work of rebuilding their clutcheries."] =
      "Con los pantanos de Zangarmarsh asegurados, Lady Vashj y sus Naga comienzan la labor de reconstruir sus criaderos.",
    ["Gain control of the Zangarmarsh outpost, learn to build {clutchery}s, and learn to train Warlord Naj'entus from the {altar}"] =
      "Obtienes control del puesto avanzado de Zangarmarsh, aprendes a construir {clutchery}, y aprendes a entrenar a Warlord Naj'entus desde el {altar}",

    // Illidari - QuestStranglethornOutpost
    ["The Cape of Stranglethorn"] = "The Cape of Stranglethorn",
    ["Some time ago, a group of Naga were sent to scout out the Cape of Stranglethorn. They should be brought back into the fold to aid in the war with Stormwind."] =
      "Hace tiempo, un grupo de Naga fue enviado a explorar el Cabo de Tuercespina. Deben ser traídos de vuelta al redil para ayudar en la guerra contra Ventormenta.",
    ["The Naga explorers in the Cape of Stranglethorn are rejoined with the Illidari forces from Outland, and are eager to battle the Alliance."] =
      "Los exploradores Naga en el Cabo de Tuercespina se reúnen con las fuerzas Illidari de Terrallende, y están ansiosos por luchar contra la Alianza.",
    ["Gain control of Naga units and buildings in the Cape of Stranglethorn"] =
      "Obtén control de las unidades y edificios Naga en el Cabo de Tuercespina",
    ["the Cape of Stranglethorn"] = "the Cape of Stranglethorn",

    // Illidari - QuestLostOnes
    ["The Draenei"] = "Los Draenei",
    ["The native Draenei of Outland, led by Elder Sage Akama, aided Illidan in his assault on the Black Temple, but abandoned him when he let Magtheridon live. With invaders on Outland's doorstep, the Draenei must be forced back into the fold."] =
      "Los Draenei nativos de Terrallende, liderados por el Sabio Anciano Akama, ayudaron a Illidan en su asalto al Templo Negro, pero lo abandonaron cuando dejó vivir a Magtheridon. Con invasores a las puertas de Terrallende, los Draenei deben ser obligados a volver al redil.",
    ["Elder Sage Akama and his Draenei tribesmen have been brought to heel, now forced to fight alongside Illidan - and the Pit Lord that once threatened their extinction."] =
      "El Sabio Anciano Akama y sus tribus Draenei han sido sometidos, ahora obligados a luchar junto a Illidan, y junto al Señor del Pozo que una vez amenazó con su extinción.",
    ["Gain control of the Draenei camp in Outland, learn to build {draeneiHut}s, and learn to train Akama from the {altar}"] =
      "Obtienes control del campamento Draenei en Terrallende, aprendes a construir {draeneiHut}, y aprendes a entrenar a Akama desde el {altar}",

    // Illidari - QuestBurningCrusade
    ["The Burning Crusade"] = "La Cruzada Ardiente",
    ["With the Dark Portal now open, the forces of the Alliance pose a grave threat to Outland. Their cities must be destroyed if the Illidari are to thrive."] =
      "Con el Portal Oscuro ahora abierto, las fuerzas de la Alianza suponen una grave amenaza para Terrallende. Sus ciudades deben ser destruidas si los Illidari han de prosperar.",
    ["Stormwind and Ironforge lie shattered, their armies broken before they could reach the heart of Outland. With the Alliance in ruin, the Illidari have secured their future."] =
      "Ventormenta y Forjaz yacen destrozadas, sus ejércitos rotos antes de poder alcanzar el corazón de Terrallende. Con la Alianza en ruinas, los Illidari han asegurado su futuro.",

    // Illidari - QuestTheWaywardWell
    ["The Wayward Well"] = "El Pozo Descarriado",
    ["Illidan stole three vials from the Well of Eternity. He used one to create a new Well beneath Nordrassil, and kept the other two hidden - but one went missing."] =
      "Illidan robó tres viales del Pozo de la Eternidad. Usó uno para crear un nuevo Pozo bajo Nordrassil, y mantuvo los otros dos ocultos, pero uno desapareció.",
    ["The missing vial of Eternity, it seems, was used to create yet another Well of arcane energy that has since become the center of High Elven civilization."] =
      "El vial perdido de la Eternidad, según parece, fue usado para crear otro Pozo de energía arcana más, que desde entonces se ha convertido en el centro de la civilización de los Altos Elfos.",
    ["the Sunwell"] = "el Pozo del Sol",

    // Illidari - QuestKillMaiev
    ["Vengeance Denied"] = "Venganza Negada",
    ["The Warden Maiev presided over Illidan's imprisonment in the barrow prisons for ten thousand years. His escape has spurred on a relentless quest for vengeance, and nothing short of death will stop her."] =
      "La Alcaide Maiev presidió el encarcelamiento de Illidan en las prisiones del túmulo durante diez mil años. Su fuga ha desatado una implacable búsqueda de venganza, y nada menos que la muerte la detendrá.",
    ["The Warden Shadowsong has been gravely wounded, stopping her pursuit of Illidan - for now."] =
      "La Alcaide Sombracanto ha sido gravemente herida, deteniendo su persecución de Illidan... por ahora.",

    // Illidari - QuestVestigesOfPower
    ["Vestiges of Power"] = "Vestigios de Poder",
    ["Illidan maintains an unquenchable thirst for power. The Skull of Gul'dan, the Warglaives of Azzinoth - these artifacts are not enough. He demands more."] =
      "Illidan mantiene una sed insaciable de poder. La Calavera de Gul'dan, las Cuchillas de Guerra de Azzinoth: estos artefactos no son suficientes. Exige más.",
    ["Illidan pores over the prophet's tome, unveiling arcane secrets that enhance his already prodigious mastery over magic."] =
      "Illidan estudia detenidamente el tomo del profeta, desvelando secretos arcanos que potencian su ya prodigioso dominio de la magia.",
    ["The Soulflayer's blade, though shattered and spread to the corners of Azeroth, still hold immense power. Even Illidan cannot decipher the sword's origin - but he can relish its power."] =
      "La espada del Desollador de Almas, aunque destrozada y esparcida por los rincones de Azeroth, aún conserva un poder inmenso. Ni siquiera Illidan puede descifrar el origen de la espada, pero puede disfrutar de su poder.",

    // Illidari - QuestEyeofSargeras
    ["The Eye of Sargeras"] = "El Ojo de Sargeras",
    ["Illidan has long thirsted for power, and no artifact can match the destructive energies of the Dark Titan's eye. Though far too powerful to be consumed in its entirety, merely possessing the artifact will unleash Illidan's true demonic potential."] =
      "Illidan ha ansiado el poder durante mucho tiempo, y ningún artefacto puede igualar las energías destructivas del ojo del Titán Oscuro. Aunque demasiado poderoso para ser consumido en su totalidad, la mera posesión del artefacto liberará el verdadero potencial demoníaco de Illidan.",
    ["With the Eye of Sargeras in hand, Illidan has become more demon than Night Elf. He now wields a tool capable of sundering the world."] =
      "Con el Ojo de Sargeras en su poder, Illidan se ha vuelto más demonio que Elfo de la Noche. Ahora empuña una herramienta capaz de desgarrar el mundo.",
    ["Illidan's Metamorphosis becomes permanent"] = "La Metamorfosis de Illidan se vuelve permanente",

    // Illidari - QuestKiljaedensCommand
    ["Kil'jaeden's Command"] = "La Orden de Kil'jaeden",
    ["Before retreating to Outland, Illidan was visited by the demon lord Kil'jaeden, who demanded that he destroy the Legion's foes. The Deceiver has now come to claim his due, and this time he will not be denied."] =
      "Antes de retirarse a Terrallende, Illidan recibió la visita del señor demonio Kil'jaeden, quien exigió que destruyera a los enemigos de la Legión. El Engañador ha venido ahora a reclamar lo que se le debe, y esta vez no será rechazado.",
    ["You gain the Kil'jaeden's Cunning Power, which causes your units' magic and spell damage to execute enemies"] =
      "Obtienes el Poder Astucia de Kil'jaeden, que hace que el daño mágico y de hechizos de tus unidades ejecute a los enemigos",
    ["Illidan loses 5 Strength, Agility, and Intelligence"] = "Illidan pierde 5 puntos de Fuerza, Agilidad e Inteligencia",
    ["With the Frozen Throne now ruptured beyond repair, Kil'jaeden's concerns over the upstart Lich King have been put to rest. The Deceiver upholds his end of the bargain, and bestows unto the Illidari his gift."] =
      "Con el Trono Helado ahora fracturado sin posibilidad de reparación, las preocupaciones de Kil'jaeden sobre el advenedizo Rey Exánime han quedado disipadas. El Engañador cumple su parte del trato, y otorga su regalo a los Illidari.",
    ["The Old God C'thun has excised from the world, ridding the Legion - and Azeroth - of an ancient threat. The Deceiver upholds his end of the bargain, and bestows unto the Illidari his gift."] =
      "El Antiguo Dios C'thun ha sido extirpado del mundo, librando a la Legión, y a Azeroth, de una amenaza ancestral. El Engañador cumple su parte del trato, y otorga su regalo a los Illidari.",
    ["In an act of fratricide, Illidan has defeated the Legion's ancient enemies and seized Nordrassil for Kil'jaeden. The Deceiver upholds his end of the bargain, and bestows unto the Illidari his gift."] =
      "En un acto de fratricidio, Illidan ha derrotado a los antiguos enemigos de la Legión y se ha apoderado de Nordrassil para Kil'jaeden. El Engañador cumple su parte del trato, y otorga su regalo a los Illidari.",
    ["Illidan has failed to, or refused to, obey Kil'jaeden's command. For his disobedience, the Deceiver rips a portion of Illidan's power from his body, and turns his back to scheme elsewhere."] =
      "Illidan ha fallado en obedecer, o se ha negado a obedecer, la orden de Kil'jaeden. Por su desobediencia, el Engañador arranca una porción del poder de Illidan de su cuerpo, y le da la espalda para conspirar en otro lugar.",

    // Illidari - KiljaedensCunning Power
    ["Kil'jaeden's Cunning"] = "Astucia de Kil'jaeden",
    ["Your units' Magic attacks and spell damage execute enemy units with less than {percentage}% hit points."] =
      "El daño mágico y de hechizos de tus unidades ejecuta a las unidades enemigas con menos del {percentage}% de puntos de vida.",

    // Illidari - Dialogue
    ["At last! The Tomb of Sargeras is found!"] = "¡Por fin! ¡La Tumba de Sargeras ha sido encontrada!",
    ["Hear me now, you trembling mortals! I am your lord and master! Illidan reigns supreme!"] =
      "¡Escuchadme ahora, mortales temblorosos! ¡Soy vuestro señor y amo! ¡Illidan reina supremo!",
    ["Good, let's get to it then."] = "Bien, pongámonos manos a la obra entonces.",
    ["The naga are yours to command, Lord Illidan. Where you go, we follow."] =
      "Los naga son tuyos para comandar, Lord Illidan. Donde vayas, te seguiremos.",
    ["Now I am complete!"] = "¡Ahora estoy completo!",
    ["You've come far enough, little warden. Your vaunted night elf justice has no jurisdiction here."] =
      "Has llegado lo bastante lejos, pequeña alcaide. Tu tan alabada justicia de los elfos de la noche no tiene jurisdicción aquí.",
    ["What would you know of us or our justice, naga witch?"] = "¿Qué sabrías tú de nosotros o de nuestra justicia, bruja naga?",
    ["So, Warden Shadowsong, you've made it at last. I knew you would."] =
      "Así que, Alcaide Sombracanto, al fin lo has logrado. Sabía que lo harías.",
    ["You have much to pay for, Illidan. I'm taking you back to your cell."] =
      "Tienes mucho que pagar, Illidan. Te llevo de vuelta a tu celda.",
    ["Tyrande! What are you doing here? This battle does not concern you."] =
      "¡Tyrande! ¿Qué haces aquí? Esta batalla no te concierne.",
    ["I was wrong to set you free, Illidan. I can see that now. You've become a monster."] =
      "Me equivoqué al liberarte, Illidan. Ahora puedo verlo. Te has convertido en un monstruo.",
    ["Brother? What are you doing here?"] = "¿Hermano? ¿Qué haces aquí?",
    ["I've come to stop you, Illidan. Instead of banishing you, I should have returned you to your cage when I had the chance! I was weak then--but no longer."] =
      "He venido a detenerte, Illidan. En lugar de desterrarte, debí devolverte a tu jaula cuando tuve la oportunidad. Entonces era débil... pero ya no.",
    ["You're out of your league, old king. You should have stayed hidden underground."] =
      "Estás fuera de tu liga, viejo rey. Deberías haberte quedado escondido bajo tierra.",
    ["Hello, Arthas."] = "Hola, Arthas.",
    ["You look different, Illidan. I guess the Skull of Gul'dan didn't agree with you."] =
      "Te ves diferente, Illidan. Supongo que la Calavera de Gul'dan no te sentó bien.",
    ["What are these vile serpents?"] = "¿Qué son estas viles serpientes?",
    ["I don't know, but these creatures feel familiar somehow."] = "No lo sé, pero estas criaturas se sienten familiares de algún modo.",
    ["Wretched Night Elves. We are the Naga! We are the future!"] = "Malditos Elfos de la Noche. ¡Somos los Naga! ¡Somos el futuro!",

    // Ironforge faction
    ["Kingdom of Ironforge"] = "el Reino de Forjaz",
    ["You are playing as the long-enduring {faction}.\n\nYou begin in the Wetlands, separated from the rest of your forces. Conquer Loch Modan and Dun Morogh to regain access to your territories.\n\nStormwind is preparing for an invasion through the Dark Portal in the South. Muster your forces and aid them, or risk losing your strongest ally."] =
      "Juegas como el perdurable {faction}.\n\nComienzas en las Tierras Pantanosas, separado del resto de tus fuerzas. Conquista Loch Modan y Dun Morogh para recuperar el acceso a tus territorios.\n\nVentormenta se está preparando para una invasión a través del Portal Oscuro en el sur. Reúne tus fuerzas y ayúdales, o arriésgate a perder a tu aliado más fuerte.",

    // Ironforge - Legends
    ["King Magni Bronzebeard has died."] = "El Rey Magni Barbabronce ha muerto.",
    ["The Great Forge has been extinguished."] = "La Gran Forja se ha extinguido.",

    // Ironforge - QuestThelsamar
    ["Murloc Menace"] = "Amenaza Murloc",
    ["A vile group of Murloc is terrorizing Thelsamar. Destroy them!"] = "Un vil grupo de murlocs está aterrorizando Thelsamar. ¡Destrúyelos!",
    ["Control of all units in Thelsamar"] = "Control de todas las unidades en Thelsamar",
    ["north of Thelsamar"] = "al norte de Thelsamar",

    // Ironforge - QuestDunMorogh
    ["Mountain Village"] = "Aldea de la Montaña",
    ["A small troll skirmish is attacking Dun Morogh. Push them back!"] = "Una pequeña escaramuza de trolls está atacando Dun Morogh. ¡Recházalos!",
    ["Control of all units in Dun Morogh"] = "Control de todas las unidades en Dun Morogh",

    // Ironforge - QuestDominion
    ["Dwarven Dominion"] = "Dominio Enano",
    ["The Dwarven Dominion must be established before Ironforge can join the war."] = "El Dominio Enano debe establecerse antes de que Forjaz pueda unirse a la guerra.",
    ["Control of all units in Ironforge"] = "Control de todas las unidades en Forjaz",

    // Ironforge - QuestGnomeregan
    ["The City of Invention"] = "La Ciudad de la Invención",
    ["The people of Gnomeregan have long been unable to assist the Alliance in its wars due an infestation of troggs and Ice Trolls. Resolve their conflicts for them to gain their services."] =
      "El pueblo de Gnomeregan ha sido incapaz durante mucho tiempo de ayudar a la Alianza en sus guerras debido a una infestación de troggs y Trolls de Hielo. Resuelve sus conflictos para obtener sus servicios.",
    ["Control of all units in Gnomeregan"] = "Control de todas las unidades en Gnomeregan",
    ["near Gnomeregan"] = "cerca de Gnomeregan",

    // Ironforge - QuestBlackTemple
    ["The Black Temple in Shadowmoon Valley is the capital for the forces of Outland. We must destroy it to stop the external threat once and for all."] =
      "El Templo Negro en el Valle de Sombraluna es la capital de las fuerzas de Terrallende. Debemos destruirlo para detener la amenaza externa de una vez por todas.",
    ["With the Black Temple destroyed and our enemies defeated, we have secured a significant victory for Ironforge and our allies."] =
      "Con el Templo Negro destruido y nuestros enemigos derrotados, hemos asegurado una victoria significativa para Forjaz y nuestros aliados.",

    // Ironforge - QuestDarkIron
    ["Dark Iron Alliance"] = "Alianza del Hierro Negro",
    ["Despite our strained past relations with the Dark Iron dwarves, we could reforge an alliance with them if we clear out the fel orcs from Blackrock Spire."] =
      "A pesar de nuestras tensas relaciones pasadas con los enanos del Hierro Negro, podríamos reforjar una alianza con ellos si limpiamos de orcos fel la Cima de Roca Negra.",
    ["You gain control of a small base in Shadowforge City and can train the hero Dagran Thaurassian from the Altar of Fortitude"] =
      "Obtienes control de una pequeña base en la Ciudad Forjasombría y puedes entrenar al héroe Dagran Thaurassian desde el Altar de la Fortaleza",
    ["The fel orcs have been vanquished from Blackrock Spire and {hero} has convinced Dagran and his Dark Iron dwarves to join our cause."] =
      "Los orcos fel han sido expulsados de la Cima de Roca Negra y {hero} ha convencido a Dagran y a sus enanos del Hierro Negro de unirse a nuestra causa.",
    ["Shadowforge City"] = "la Ciudad Forjasombría",

    // Ironforge - QuestWildhammer
    ["Wildhammer Alliance"] = "Alianza Martillo Salvaje",
    ["The Wildhammer dwarves roam freely over the peaks of the Hinterlands. An audience with them might earn their cooperation."] =
      "Los enanos Martillo Salvaje deambulan libremente por los picos de las Tierras del Interior. Una audiencia con ellos podría ganarnos su cooperación.",
    ["{hero} has spoken with Falstad Wildhammer and secured an alliance with the Wildhammer Clan."] =
      "{hero} ha hablado con Falstad Martillo Salvaje y ha asegurado una alianza con el Clan Martillo Salvaje.",
    ["Aerie Peak"] = "Cima del Nido",

    // Ironforge - QuestExplorersLeagueFoundation
    ["Explorer's League Foundation"] = "Fundación de la Liga de Exploradores",
    ["The Explorer's League has been established in Ironforge, and they have set out on their first expedition."] =
      "La Liga de Exploradores ha sido establecida en Forjaz, y han emprendido su primera expedición.",
    ["{hero} has overseen the expedition at {region} and the archaeologists have taken the relics back to Ironforge to study."] =
      "{hero} ha supervisado la expedición en {region} y los arqueólogos han llevado las reliquias de vuelta a Forjaz para estudiarlas.",
    ["Sunken Temple"] = "Sunken Temple",
    ["Zul'Gurub"] = "Zul'Gurub",

    // Ironforge - QuestExplorersLeagueKalimdorExpedition
    ["Explorer's League Kalimdor Expedition"] = "Expedición de la Liga de Exploradores a Kalimdor",
    ["The Explorer's League have identified areas of interest in the foreign lands of Kalimdor. We should set forth on another expedition to uncover their secrets."] =
      "La Liga de Exploradores ha identificado áreas de interés en las tierras extranjeras de Kalimdor. Deberíamos emprender otra expedición para desvelar sus secretos.",
    ["{hero} has overseen the expeditions at {regionNorth} and {regionSouth}. The archaeologists have taken the valuable relics back to Ironforge to study and sell."] =
      "{hero} ha supervisado las expediciones en {regionNorth} y {regionSouth}. Los arqueólogos han llevado las valiosas reliquias de vuelta a Forjaz para estudiarlas y venderlas.",
    ["{heroNorth} has overseen the expedition at {regionNorth}, while {heroSouth} has overseen the expedition at {regionSouth}. The archaeologists have taken the valuable relics back to Ironforge to study and sell."] =
      "{heroNorth} ha supervisado la expedición en {regionNorth}, mientras que {heroSouth} ha supervisado la expedición en {regionSouth}. Los arqueólogos han llevado las valiosas reliquias de vuelta a Forjaz para estudiarlas y venderlas.",
    ["Gain 500 gold."] = "Obtén 500 de oro.",
    ["Eldarath"] = "Eldarath",
    ["Stonetalon Peak"] = "Stonetalon Peak",
    ["Dire Maul"] = "Dire Maul",
    ["Zul'Farrak"] = "Zul'Farrak",

    // Ironforge - QuestExpedition
    ["Secrets of Uldum"] = "Secretos de Uldum",
    ["Uldum was once a vast jungle, until the Forge of Origination stationed there wiped the slate clean. Now, buried under the sands lies a veritable trove of ancient relics."] =
      "Uldum fue alguna vez una vasta jungla, hasta que la Forja de la Creación estacionada allí lo arrasó todo. Ahora, enterrado bajo las arenas, yace un auténtico tesoro de reliquias ancestrales.",

    // Ironforge - shared Objective fallback
    ["an unknown hero"] = "un héroe desconocido",

    // Kultiras faction
    ["Kingdom of Kul Tiras"] = "el Reino de Kul Tiras",
    ["You are playing as the maritime {faction}.\n\nYou begin on Balor Island, separated from your main forces in Kul Tiras. Unite your forces by eliminating your enemies in Tiragarde, Drustvar, and Stormsong Valley.\n\nStormwind is preparing for an invasion through the Dark Portal in the South. Muster the Admiralty and assist them, or risk losing your strongest ally."] =
      "Juegas como el marítimo {faction}.\n\nComienzas en la Isla Balor, separado de tus fuerzas principales en Kul Tiras. Une tus fuerzas eliminando a tus enemigos en Tiragarde, Drustvar y el Valle de Stormsong.\n\nVentormenta se está preparando para una invasión a través del Portal Oscuro en el sur. Reúne al Almirantazgo y ayúdales, o arriésgate a perder a tu aliado más fuerte.",

    // Kultiras - Legends
    ["Boralus Keep has fallen"] = "El Fuerte de Boralus ha caído",

    // Kultiras - Dialogue
    ["I must admit, you orcs are more tenacious than I remembered. I thought you savages would have turned on each other by now."] =
      "Debo admitir que vosotros los orcos sois más tenaces de lo que recordaba. Pensé que vosotros, salvajes, ya os habríais vuelto los unos contra los otros.",
    ["This is not the Horde you remember, old man. We have no interest in conquest or murder. We have paid for our sins of our forebears in blood."] =
      "Esta no es la Horda que recuerdas, anciano. No tenemos interés en la conquista ni en el asesinato. Hemos pagado con sangre los pecados de nuestros ancestros.",
    ["Can your blood atone for genocide, orc? Your Horde killed countless innocents with its rampage across Stormwind and Lordaeron. Do you really think you can just sweep all that away and cast aside your guilt so easily? No, your kind will never change, and I will never stop fighting you."] =
      "¿Puede tu sangre expiar un genocidio, orco? Tu Horda mató a incontables inocentes en su arrasadora campaña por Ventormenta y Lordaeron. ¿De verdad crees que puedes barrer todo eso y dejar de lado tu culpa tan fácilmente? No, los de tu especie nunca cambiarán, y yo nunca dejaré de luchar contra vosotros.",

    // Kultiras - QuestBoralus
    ["The Admiralty of Kul Tiras"] = "El Almirantazgo de Kul Tiras",
    ["Kul Tiras has degenerated severely in contemporary times. Bandits and vile monsters threaten the islands and the noble houses have split apart. We must quell these threats and reunite the kingdom's various regions under Daelin Proudmoore's command."] =
      "Kul Tiras se ha degradado severamente en los tiempos actuales. Bandidos y viles monstruos amenazan las islas y las casas nobles se han dividido. Debemos sofocar estas amenazas y reunir las diversas regiones del reino bajo el mando de Daelin Proudmoore.",
    ["Gain control of all units in Kul'tiras, gain control of Katherine Proudmoore, and acquire the {power} Power"] =
      "Obtén control de todas las unidades en Kul'tiras, obtén control de Katherine Proudmoore, y adquiere el Poder {power}",
    ["City of Admirals"] = "Ciudad de Almirantes",

    // Shared Power - CityOfHeroes
    ["{units} you train have a {chance} to become demiheroes, increasing their hit points, mana, and damage by {stat}, changing their attack and armor types to Hero, and granting them the ability to use items."] =
      "Las {units} que entrenas tienen un {chance} de probabilidad de convertirse en semihéroes, aumentando sus puntos de vida, maná y daño en un {stat}, cambiando sus tipos de ataque y armadura a Héroe, y otorgándoles la capacidad de usar objetos.",
    ["Ships"] = "naves",

    // Kultiras - QuestHighBank
    ["Eliminate Piracy"] = "Elimina la Piratería",
    ["Kul Tiras' historical isolationism has allowed piracy to fester throughout the seas. It's high time that we do something about it; we can start with the Goblin freebooters living it up in Booty Bay."] =
      "El histórico aislacionismo de Kul Tiras ha permitido que la piratería se propague por los mares. Ya es hora de que hagamos algo al respecto; podemos empezar con los corsarios Goblin que viven a sus anchas en la Bahía del Botín.",
    ["With the south coast of the Eastern Kingdoms now secure, High Bank has been established as a base of operations on an island near the Twilight Highlands."] =
      "Con la costa sur de los Reinos del Este ahora asegurada, el Banco Alto ha sido establecido como base de operaciones en una isla cerca de las Tierras Altas del Crepúsculo.",
    ["Gain control of High Bank, earn 225 gold, and {hero} gains 2000 experience"] =
      "Obtén control del Banco Alto, gana 225 de oro, y {hero} gana 2000 puntos de experiencia",

    // Kultiras - QuestOldHatreds
    ["Old Hatreds"] = "Viejos Odios",
    ["Daelin Proudmoore led his people against the savage Orcs during the Second War. Now his old enemies ride forth once more, and he won't be satisfied until he brings the battle to their doorstep."] =
      "Daelin Proudmoore lideró a su pueblo contra los salvajes Orcos durante la Segunda Guerra. Ahora sus viejos enemigos cabalgan de nuevo, y no estará satisfecho hasta llevar la batalla hasta su puerta.",
    ["Daelin stands before the Hellfire Citadel, towering over the landscape like a twisted monument to the Orc's brutality. He vows that, this time, he won't merely drive the Orcs back - he'll lead his men to conquer these brutal lands and slaughter them all."] =
      "Daelin se yergue ante la Ciudadela del Fuego Infernal, dominando el paisaje como un monumento retorcido a la brutalidad Orca. Jura que, esta vez, no se limitará a hacer retroceder a los Orcos: liderará a sus hombres para conquistar estas tierras brutales y masacrarlos a todos.",
    ["Daelin Proudmoore gains 4000 experience"] = "Daelin Proudmoore gana 4000 puntos de experiencia",
    ["Hellfire, the belly of the beast"] = "Infierno, el vientre de la bestia",

    // Kultiras - QuestStranglethornExpedition (file: QuestUnlockShip.cs)
    ["Stranglethorn Expedition"] = "Expedición a Vragosuelo",
    ["The Stranglethorn vale is still infested with trolls and pirates. If peace is to be brought back to the South Alliance, it needs to be purged"] =
      "El valle de Vragosuelo sigue infestado de trolls y piratas. Si la paz ha de regresar a la Alianza del Sur, debe ser purgado",
    ["Optionally move all of your non-worker units to Stranglethorn Vale"] =
      "Opcionalmente, mueve todas tus unidades que no sean trabajadores a Vragosuelo",

    // Kultiras - UnlockShipDialogPresenter
    ["Sail to Westfall (Recommended)"] = "Navegar a Poniente (Recomendado)",
    ["Do Nothing"] = "No Hacer Nada",
    ["Choose What To Do With Your Troops"] = "Elige Qué Hacer con tus Tropas",

    // Kultiras - QuestWestfallOutpost
    ["Continental Outpost"] = "Puesto Avanzado Continental",
    ["Stormwind faces the threat of annihilation at the hands of forces from beyond the Dark Portal, and they have called in our assistance. If we are to aid them, we must first establish a foothold on Stranglethorn's coast."] =
      "Ventormenta enfrenta la amenaza de aniquilación a manos de fuerzas de más allá del Portal Oscuro, y han solicitado nuestra ayuda. Si hemos de ayudarles, primero debemos establecer un punto de apoyo en la costa de Vragosuelo.",
    ["The Kul Tiran outpost in Westfall has been completed. In the mean time, the Ember Order has cleansed House Waycrest of their Drust influence. Meredith Waycrest has been released from her pact, and may now join the war effort."] =
      "El puesto avanzado de Kul Tiras en Poniente ha sido completado. Mientras tanto, la Orden de las Ascuas ha purgado a la Casa Waycrest de su influencia Drust. Meredith Waycrest ha sido liberada de su pacto, y ahora puede unirse al esfuerzo bélico.",
    ["in Stranglethorn or Westfall"] = "en Vragosuelo o Poniente",
    ["Learn to build {chapterHouse}s, and learn to train Meredith Waycrest from the {altar}"] =
      "Aprendes a construir {chapterHouse}, y aprendes a entrenar a Meredith Waycrest desde el {altar}",

    // Kultiras - QuestBeyondPortal
    ["Beyond the Dark Portal"] = "Más Allá del Portal Oscuro",
    ["The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs and their bases."] =
      "La amenaza Orca de Draenor todavía se cierne sobre todos. Elimina cada rastro de los Orcos y sus bases.",
    ["You will be able to train Fusillier from the Chapter House and to launch the Kalimdor Expedition"] =
      "Podrás entrenar al Fusilero desde la Casa del Capítulo y lanzar la Expedición a Kalimdor",

    // Legion faction
    ["Burning Legion"] = "la Legión Ardiente",
    ["You are playing as the mighty {faction}.\n\nYou begin isolated on Argus. Once the planet is under your control, you will unlock two teleporters to Northrend and Alterac.\n\nOn Azeroth, the Scourge will need your assistance to destroy the Kingdoms of Lordaeron, Dalaran, and Quel'Thalas.\n\nYour primary objective is to summon the great host of the Burning Legion. Invade the city of Dalaran, where the Book of Medivh is kept, and use it to open the Demon-gate to Argus."] =
      "Juegas como la poderosa {faction}.\n\nComienzas aislado en Argus. Una vez que el planeta esté bajo tu control, desbloquearás dos teletransportadores hacia Rasganorte y Alterac.\n\nEn Azeroth, la Plaga necesitará tu ayuda para destruir los Reinos de Lordaeron, Dalaran y Quel'Thalas.\n\nTu objetivo principal es invocar a la gran hueste de la Legión Ardiente. Invade la ciudad de Dalaran, donde se guarda el Libro de Medivh, y úsalo para abrir la Puerta Demoníaca hacia Argus.",

    // Legion - Legends
    ["Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion."] =
      "Archimonde el Profanador ha sido desterrado de Azeroth, marcando el fin de su segunda invasión fallida.",
    ["The great Stronghold of the Legian has fallen"] = "La gran Fortaleza de la Legión ha caído",

    // Legion - Rematerialization Power
    ["Rematerialization"] = "Rematerialización",
    ["Your non-Resistant units have a {chance}% chance to rematerialize in {location} upon death."] =
      "Tus unidades no Resistentes tienen un {chance}% de probabilidad de rematerializarse en {location} al morir.",

    // Legion - SummonLegionSpell
    ["Legion Summon"] = "Invocación de la Legión",
    ["The Burning Legion is being summoned!"] = "¡La Legión Ardiente está siendo invocada!",

    // Legion - Dialogue
    ["Tremble, mortals, and despair! Doom has come to this world!"] = "¡Temblad, mortales, y desesperad! ¡La perdición ha llegado a este mundo!",
    ["You are very brave to stand against me, little human. If only your countrymen had been as bold, I would have had more fun scouring your wretched nations from the world!"] =
      "Eres muy valiente al enfrentarte a mí, pequeña humana. Si tus compatriotas hubieran sido igual de audaces, ¡me habría divertido más borrando tus miserables naciones del mundo!",
    ["Is talking all you demons do?"] = "¿Es hablar todo lo que hacéis los demonios?",
    ["What? Who are... you?"] = "¿Qué? ¿Quién... eres tú?",
    ["Let's see how confident you are against one of your own kind, dreadlord!"] = "¡Veamos qué tan confiado estás contra uno de los tuyos, señor del terror!",
    ["I'm through toying with you, night elf! Begone from my sight!"] = "¡He terminado de jugar contigo, elfo de la noche! ¡Fuera de mi vista!",
    ["You orcs are weak, and hardly worth the effort. I wonder why Mannoroth even bothered with you."] =
      "Vosotros los orcos sois débiles, y apenas merecéis el esfuerzo. Me pregunto por qué Mannoroth se molestó siquiera con vosotros.",
    ["Our spirit is stronger than you know, demon! If we are to fall, then so be it! At least now... we are free!"] =
      "¡Nuestro espíritu es más fuerte de lo que crees, demonio! ¡Si hemos de caer, que así sea! Al menos ahora... ¡somos libres!",
    ["You called my name, puny lich, and I have come. You are Kel'Thuzad, are you not?"] =
      "Llamaste mi nombre, insignificante liche, y he venido. Tú eres Kel'Thuzad, ¿no es así?",
    ["Yes, great one. I am the summoner."] = "Sí, grande entre los grandes. Yo soy el invocador.",
    ["At last, the way to the World Tree is clear! Witness the end, you mortals! The final hour has come."] =
      "¡Por fin, el camino hacia el Árbol del Mundo está despejado! ¡Sed testigos del fin, mortales! La hora final ha llegado.",

    // Legion - QuestArgusControl
    ["Argus"] = "Argus",
    ["The planet of Argus is not yet fully under the control of the Legion."] = "El planeta Argus todavía no está completamente bajo el control de la Legión.",
    ["Enables training of Tichondrius and Anetheron from the Altar of Destruction and to cast the Portal spells from the Legion Teleporter"] =
      "Habilita entrenar a Tichondrius y Anetheron desde el Altar de la Destrucción, y lanzar los hechizos de Portal desde el Teletransportador de la Legión",
    ["With Argus finally under the Legion's control, the invasion of Azeroth can begin in earnest."] =
      "Con Argus finalmente bajo el control de la Legión, la invasión de Azeroth puede comenzar en serio.",

    // Legion - QuestConsumeTree
    ["Twilight of the Gods"] = "El Crepúsculo de los Dioses",
    ["Long ago, the Night Elves' hubris led them to forge a second Well of Eternity following the destruction of the first. Nordrassil was planted atop it as a means of protection, but this measly act of defiance shall not prevent Lord Archimonde from seizing the Well's energies for himself."] =
      "Hace mucho tiempo, la soberbia de los Elfos de la Noche los llevó a forjar un segundo Pozo de la Eternidad tras la destrucción del primero. Nordrassil fue plantado sobre él como medio de protección, pero este mísero acto de desafío no evitará que Lord Archimonde se apodere de las energías del Pozo para sí mismo.",
    ["The Third War is over. Archimonde has successfully consumed the energies of the Well of Eternity resting beneath Nordrassil. The last line of defense against the Burning Legion has fallen, and with it dies the hopes and dreams of Azeroth."] =
      "La Tercera Guerra ha terminado. Archimonde ha consumido con éxito las energías del Pozo de la Eternidad que yace bajo Nordrassil. La última línea de defensa contra la Legión Ardiente ha caído, y con ella mueren las esperanzas y los sueños de Azeroth.",
    ["Archimonde gains {stat} Strength, Agility, and Intelligence, and the Druids are defeated"] =
      "Archimonde gana {stat} de Fuerza, Agilidad e Inteligencia, y los Druidas son derrotados",
    ["Devourer of Worlds"] = "Devorador de Mundos",
    ["The World Tree"] = "el Árbol del Mundo",

    // Legion - QuestControlMonastery
    ["Corrupting the Monastery"] = "Corrompiendo el Monasterio",
    ["The mind of humans are feeble and easily corruptable, the Scarlet Monastery will be a perfect ground for a secret demon portal"] =
      "La mente de los humanos es débil y fácil de corromper; el Monasterio Escarlata será un terreno perfecto para un portal demoníaco secreto",
    ["The Monastery has been corrupted and plundered. A secret demon gate has now been formed inside."] =
      "El Monasterio ha sido corrompido y saqueado. Una puerta demoníaca secreta se ha formado ahora en su interior.",
    ["Learn to train troops from the Monastery."] = "Aprende a entrenar tropas desde el Monasterio.",

    // Legion - QuestControlShadowfang
    ["The Dark Manor"] = "La Mansión Oscura",
    ["The Legion will need a hidden stronghold to house a demon gate, the Shadowfang Keep is perfectly out of the way for the role."] =
      "La Legión necesitará una fortaleza oculta para albergar una puerta demoníaca; el Castillo de Colmillo Oscuro está perfectamente apartado para ese papel.",
    ["Shadowfang Keep is now under the Legion control. A secret demon gate has now been formed inside."] =
      "El Castillo de Colmillo Oscuro está ahora bajo el control de la Legión. Una puerta demoníaca secreta se ha formado ahora en su interior.",
    ["Learn to train troops from Shadowfang Keep."] = "Aprende a entrenar tropas desde el Castillo de Colmillo Oscuro.",

    // Legion - QuestControlSpire
    ["Windrunner Spire"] = "Windrunner Spire",
    ["The seat of the Windrunners, pillaging it would yield a great bounty and be the perfect grounds for a demon gate."] =
      "La sede de los Windrunner; saquearla produciría un gran botín y sería el terreno perfecto para una puerta demoníaca.",
    ["The Spire has been pillaged. A secret demon gate has now been formed inside."] =
      "La Aguja ha sido saqueada. Una puerta demoníaca secreta se ha formado ahora en su interior.",
    ["Learn to train troops from the Spire Keep and gain 500 gold"] = "Aprende a entrenar tropas desde el Fuerte de la Aguja y gana 500 de oro",

    // Legion - QuestCunningPlan
    ["A Cunning Plan"] = "Un Plan Astuto",
    ["The Dreadlords have played a subtle hand in preparing Lordaeron for the coming of the Scourge. Once the Plague is unleashed, the Dreadlords will activate their own assets."] =
      "Los Señores del Terror han jugado un papel sutil en preparar a Lordaeron para la llegada de la Plaga. Una vez que la Plaga sea desatada, los Señores del Terror activarán sus propios recursos.",
    ["With the Plague now spreading amongst Lordaeron's populace, the Dreadlords set the second half of their plan in motion: a direct demonic incursion into the Eastern Kingdoms."] =
      "Con la Plaga ahora propagándose entre la población de Lordaeron, los Señores del Terror ponen en marcha la segunda mitad de su plan: una incursión demoníaca directa en los Reinos del Este.",
    ["Gain control of a small base in Alterac, learn to generate a portal to Alterac using the Argus Teleporter, and gain a {dreadShrine} in each of the following Scourge bases: Deathknell, Stratholme Coast, and Scholomance. Mal'ganis improves his Vampiric Siphon ability."] =
      "Obtienes control de una pequeña base en Alterac, aprendes a generar un portal hacia Alterac usando el Argus Teleporter, y obtienes un {dreadShrine} en cada una de las siguientes bases de la Plaga: El Doblar de la Muerte, la Costa de Stratholme, y Scholomance. Mal'ganis mejora su habilidad Sifón Vampírico.",

    // Legion - QuestLegionCaptureSunwell
    ["Fall of Silvermoon"] = "La Caída de Lunargenta",
    ["The Sunwell is the source of the High Elves' immortality and magical prowess, created from a stolen vial from the Well of Eternity. The immense power within its waters would be an immense boon to the Legion."] =
      "El Pozo del Sol es la fuente de la inmortalidad y destreza mágica de los Altos Elfos, creado a partir de un vial robado del Pozo de la Eternidad. El inmenso poder dentro de sus aguas sería una gran bendición para la Legión.",
    ["The Dreadlords drink freely of the Sunwell. The energies that once coursed through the waters of the well now course through the veins of the Nazrethim, infusing them with power enough to tear holes in dimensions."] =
      "Los Señores del Terror beben libremente del Pozo del Sol. Las energías que una vez recorrieron las aguas del pozo ahora recorren las venas de los Nazrethim, infundiéndoles poder suficiente para desgarrar agujeros entre dimensiones.",
    ["Improves Dreadlords and Nathrezim by increasing their attack damage by 20, movement speed by 20, hit points by 200, improves the Vampiric Siphon ability and grants them the ability to cast Astral Walk"] =
      "Mejora a los Señores del Terror y Nathrezim aumentando su daño de ataque en 20, su velocidad de movimiento en 20, sus puntos de vida en 200, mejora la habilidad Sifón Vampírico y les otorga la capacidad de lanzar Paso Astral",

    // Legion - QuestLegionKillLordaeron
    ["Token Resistance"] = "Resistencia Simbólica",
    ["The Kingdom of Lordaeron must be eliminated to pave the way for the Legion's arrival."] =
      "El Reino de Lordaeron debe ser eliminado para allanar el camino para la llegada de la Legión.",
    ["The Kingdom of Lordaeron has fallen, eliminating Azeroth's vanguard against the Legion."] =
      "El Reino de Lordaeron ha caído, eliminando la vanguardia de Azeroth contra la Legión.",
    ["Tichondrius gains 15 Strength, Agility and Intelligence and improves his Vampiric Siphon ability"] =
      "Tichondrius gana 15 de Fuerza, Agilidad e Inteligencia, y mejora su habilidad Sifón Vampírico",

    // Legion - QuestSummonLegion
    ["Under the Burning Sky"] = "Bajo el Cielo Ardiente",
    ["The greater forces of the Burning Legion lie in wait in the vast expanse of the Twisting Nether. Use the Book of Medivh to tear open a hole in space-time, and visit the full might of the Legion upon Azeroth."] =
      "Las fuerzas mayores de la Legión Ardiente esperan en la vasta extensión del Vacío Abisal. Usa el Libro de Medivh para desgarrar un agujero en el espacio-tiempo, y descarga todo el poderío de la Legión sobre Azeroth.",
    ["A great portal to the depths of the Twisting Nether has been opened by {hero}. The Burning Legion steps forth, heralding the beginning of the end."] =
      "Un gran portal hacia las profundidades del Vacío Abisal ha sido abierto por {hero}. La Legión Ardiente avanza, anunciando el principio del fin.",
    ["The hero Archimonde, control of all units in the Twisting Nether. Anetheron improves his Vampiric Siphon ability"] =
      "El héroe Archimonde, control de todas las unidades en el Vacío Abisal. Anetheron mejora su habilidad Sifón Vampírico",

    // Lordaeron faction
    ["Kingdom of Lordaeron"] = "el Reino de Lordaeron",
    ["You are playing as the great {faction}.\n\nYou begin in Andorhal, isolated from your forces in the rest of the Kingdom, and the Plague of Undeath is imminent.\n\nSecure your major settlements by clearing out clusters of enemies and fortify your Kingdom as much as possible.\n\nIf you survive the Plague, sail to the frozen wasteland of Northrend and take the fight to the Lich King."] =
      "Juegas como el gran {faction}.\n\nComienzas en Andorhal, aislado de tus fuerzas en el resto del Reino, y la Plaga de la No-Muerte es inminente.\n\nAsegura tus asentamientos principales eliminando grupos de enemigos y fortifica tu Reino tanto como sea posible.\n\nSi sobrevives a la Plaga, navega hacia la yerma extensión helada de Rasganorte y lleva la lucha hasta el Rey Exánime.",

    // Lordaeron - Legends
    ["The majestic city of Stratholme has been destroyed."] = "La majestuosa ciudad de Stratholme ha sido destruida.",
    ["Tyr's Hand, the bastion of human power in Lordaeron, has fallen."] = "La Mano de Tyr, el bastión del poder humano en Lordaeron, ha caído.",
    ["Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, and humanity itself, has lost one of its finest exemplars in this dark hour."] =
      "Uther el Portador de la Luz hace su última resistencia, pereciendo en defensa de la luz. Lordaeron, y la humanidad misma, ha perdido a uno de sus mejores ejemplos en esta hora oscura.",

    // Lordaeron - ControlLevelPerTurnBonus Power
    ["Your Control Points gain an additional level each turn."] = "Tus Puntos de Control ganan un nivel adicional cada turno.",
    ["Your Control Points gain {bonus} additional levels each turn."] = "Tus Puntos de Control ganan {bonus} niveles adicionales cada turno.",

    // Lordaeron - Dialogue
    ["Welcome, Prince Arthas. The men and I are honored by your presence."] = "Bienvenido, Príncipe Arthas. Los hombres y yo nos sentimos honrados por tu presencia.",
    ["Can the formalities, Uther. I'm not king yet. It's good to see you."] = "Deja las formalidades, Uther. Todavía no soy rey. Me alegra verte.",
    ["You too, lad. I'm pleased that King Terenas sent you to help me."] = "Igualmente, muchacho. Me complace que el Rey Terenas te enviara para ayudarme.",
    ["Father still hopes your patience and experience might rub off on me."] = "Padre todavía espera que tu paciencia y experiencia se me contagien.",
    ["It is a father's right to dream, isn't it?"] = "Es el derecho de un padre soñar, ¿no es así?",
    ["Paladin fool! The warlocks of the Blackrock clan have spoken! Soon, demons will rain from the sky, and this wretched world will burn!"] =
      "¡Necio paladín! ¡Los brujos del clan Roca Negra han hablado! ¡Pronto, demonios lloverán del cielo, y este mundo miserable arderá!",
    ["Yes, I've heard this rhetoric before. You orcs will never learn!"] = "Sí, ya he escuchado esta retórica antes. ¡Vosotros los orcos nunca aprenderéis!",
    ["This is a Light-forsaken land, isn't it? You can barely even see the sun! This howling wind cuts to the bone and you're not even shaking. Mi'lord, are you alright?"] =
      "Esta es una tierra abandonada por la Luz, ¿no es así? ¡Apenas se puede ver el sol! Este viento aullante cala hasta los huesos y ni siquiera estás temblando. Mi señor, ¿estás bien?",
    ["Captain, are all my forces accounted for?"] = "Capitán, ¿están todas mis fuerzas contabilizadas?",
    ["Nearly. There are only a few ships that--"] = "Casi. Solo quedan algunas naves que--",
    ["Very well. Our first priority is to set up a base camp with proper defenses. There's no telling what's waiting for us out there in the shadows."] =
      "Muy bien. Nuestra primera prioridad es establecer un campamento base con defensas adecuadas. No hay manera de saber qué nos espera ahí fuera entre las sombras.",
    ["This must be the shrine that the old man spoke of. Any man who drinks from these Light-blessed waters will be healed."] =
      "Este debe ser el santuario del que hablaba el anciano. Cualquier hombre que beba de estas aguas benditas por la Luz será sanado.",
    ["So, you've taken up Frostmourne at the expense of your comrades' lives, just as the Dark Lord said you would. You're stronger than I thought."] =
      "Así que has tomado a Añoranza Helada a costa de las vidas de tus camaradas, tal como el Señor Oscuro dijo que harías. Eres más fuerte de lo que pensaba.",
    ["You waste your breath, Mal'Ganis. I heed only the voice of Frostmourne now."] = "Desperdicias tu aliento, Mal'Ganis. Ahora solo obedezco la voz de Añoranza Helada.",
    ["You hear the voice of the Dark Lord. He whispers to you through the blade you wield. What does he say, young human? What does the Dark Lord of the Dead tell you now?"] =
      "Oyes la voz del Señor Oscuro. Te susurra a través de la hoja que empuñas. ¿Qué dice, joven humano? ¿Qué te dice ahora el Señor Oscuro de los Muertos?",
    ["He tells me that the time for my vengeance has come."] = "Me dice que ha llegado la hora de mi venganza.",
    ["That has to be where Mal'Ganis is hiding! I want that base leveled!"] = "¡Ahí debe ser donde se esconde Mal'Ganis! ¡Quiero esa base arrasada!",
    ["The Dark Lord said you would come. This is where your journey ends, boy. Trapped and freezing at the roof of the world, with only death to sing the tale of your doom."] =
      "El Señor Oscuro dijo que vendrías. Aquí es donde termina tu viaje, muchacho. Atrapado y congelándote en el techo del mundo, con solo la muerte para cantar la historia de tu perdición.",
    ["Your father ruled this land for seventy years, and you've ground it to dust in a matter of days."] =
      "Tu padre gobernó esta tierra durante setenta años, y tú la has reducido a polvo en cuestión de días.",
    ["Vile betrayer! You are not fit enough to even carry your father's name! Why Uther ever vouched for you is beyond me. You've stripped him of his honor by casting yours to the winds! You deserve a gruesome death, boy!"] =
      "¡Vil traidor! ¡Ni siquiera eres digno de llevar el nombre de tu padre! Por qué Uther alguna vez respondió por ti está más allá de mi comprensión. ¡Lo has despojado de su honor al arrojar el tuyo a los vientos! ¡Mereces una muerte espantosa, muchacho!",
    ["Looks like you haven't lost your touch. It's good to see you again, Jaina."] = "Parece que no has perdido tu destreza. Me alegra verte de nuevo, Jaina.",
    ["You too, Arthas. It's been awhile since a prince escorted me anywhere."] = "Igualmente, Arthas. Ha pasado un tiempo desde que un príncipe me escoltó a alguna parte.",
    ["Yes, it has. Well, I guess we should get underway."] = "Sí, así es. Bueno, supongo que deberíamos ponernos en marcha.",
    ["Oh no..."] = "Oh, no...",
    ["The plague was never meant to simply kill my people. It was meant to turn them... into the undead! Defend yourselves!"] =
      "La plaga nunca estuvo destinada simplemente a matar a mi gente. ¡Estaba destinada a convertirlos... en no-muertos! ¡Defendeos!",
    ["Alterac"] = "Alterac",
    ["central Northrend"] = "el centro de Rasganorte",
    ["Fountain of Health in Alterac"] = "la Fuente de Salud en Alterac",

    // Lordaeron - QuestHearthglen
    ["Hearthglen"] = "Hearthglen",
    ["The village of Hearthglen is under siege from the restless dead. The people there must be saved."] =
      "La aldea de Vega del Amparo está sitiada por los muertos inquietos. Su gente debe ser salvada.",
    ["The walking corpses assailing Hearthglen have been put back to rest, and Hearthglen lives to see another day."] =
      "Los cadáveres andantes que asediaban Vega del Amparo han vuelto a descansar, y Vega del Amparo vive para ver otro día.",
    ["Control of all units in Hearthglen"] = "Control de todas las unidades en Vega del Amparo",
    ["in Hearthglen"] = "en Vega del Amparo",

    // Lordaeron - QuestStrahnbrad
    ["The Defense of Strahnbrad"] = "La Defensa de Strahnbrad",
    ["The Strahnbrad is under attack by some brigands, clear them out"] = "Strahnbrad está bajo el ataque de unos bandidos, elimínalos",
    ["Control of all buildings in Strahnbrad"] = "Control de todos los edificios en Strahnbrad",

    // Lordaeron - QuestStratholme
    ["Blackrock and Roll"] = "Roca Negra y Rock and Roll",
    ["The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron"] =
      "El clan Roca Negra se ha apoderado de Alterac; deben ser eliminados por la seguridad de Lordaeron",
    ["Control of all units in Stratholme and you can now build Town Halls"] = "Control de todas las unidades en Stratholme y ahora puedes construir Ayuntamientos",

    // Lordaeron - QuestCapitalCity
    ["Hearthlands"] = "Tierras del Hogar",
    ["The territories of Lordaeron are fragmented. Regain control of the old Alliance's hold to secure the kingdom."] =
      "Los territorios de Lordaeron están fragmentados. Recupera el control del antiguo bastión de la Alianza para asegurar el reino.",
    ["Gain control of all units in the Capital City, gain Uther, and acquire the {power} Power"] =
      "Obtén control de todas las unidades en la Ciudad Capital, obtén a Uther, y adquiere el Poder {power}",
    ["Dominion"] = "Dominio",

    // Lordaeron - QuestTyrHand
    ["The Fortified City"] = "La Ciudad Fortificada",
    ["The city of Tyr's Hand is considered impregnable, but they will be reluctant to join the war."] =
      "La ciudad de la Mano de Tyr se considera inexpugnable, pero se mostrarán reacios a unirse a la guerra.",
    ["The city-fortress of Tyr's Hand has decided to join us! Renowed for their siege engineers, we can now build siege workshops."] =
      "¡La ciudad-fortaleza de la Mano de Tyr ha decidido unirse a nosotros! Reconocidos por sus ingenieros de asedio, ahora podemos construir talleres de asedio.",

    // Lordaeron - QuestMograine
    ["The Exile"] = "El Exiliado",
    ["Mograine has been gone for a long time, if Lordaeron would be in great peril, he would surely come back to defend it!"] =
      "Mograine ha estado ausente durante mucho tiempo; si Lordaeron estuviera en gran peligro, ¡seguramente regresaría para defenderlo!",
    ["With the threat of the Scourge and the Plague, Mograine has returned to help Lordaeorn in their dire times."] =
      "Con la amenaza de la Plaga y el flagelo, Mograine ha regresado para ayudar a Lordaeron en sus tiempos aciagos.",

    // Lordaeron - QuestScarletCrusade
    ["The Scarlet Crusade"] = "La Cruzada Escarlata",
    ["Lordaeron is destined to fall to the Scourge. Should such an event come to pass, the Silver Hand will be transformed beyond recognition, abandoning ideals of justice in favour of those of vengeance."] =
      "Lordaeron está destinado a caer ante la Plaga. Si tal evento llegara a suceder, la Mano de Plata se transformará más allá del reconocimiento, abandonando los ideales de justicia en favor de los de venganza.",
    ["Lordaeron has been destroyed by the vile Scourge, leaving those left alive with naught but vengeance in their hearts. From the ashes rises the Scarlet Crusade, the untempered bright that will bring to the undying dead the wrath of the living."] =
      "Lordaeron ha sido destruido por la vil Plaga, dejando a los que quedan con vida con nada más que venganza en sus corazones. De las cenizas surge la Cruzada Escarlata, el fuego sin templar que traerá a los muertos eternos la ira de los vivos.",
    ["Your existing forces are removed, then you restart the game as the Scarlet Crusade in Tyr's Hand"] =
      "Tus fuerzas existentes son eliminadas, y luego reinicias la partida como la Cruzada Escarlata en la Mano de Tyr",

    // Lordaeron - QuestShoresOfNorthrend
    ["Shores of Northrend"] = "Costas de Rasganorte",
    ["Mal'ganis' citadel lies somewhere within the arctic wastes of the north. In order to assault the Dreadlord, Arthas must first establish a base camp at the shores of Northrend."] =
      "La ciudadela de Mal'ganis se encuentra en algún lugar dentro de las yermas árticas del norte. Para asaltar al Señor del Terror, Arthas debe primero establecer un campamento base en las costas de Rasganorte.",
    ["Crown Prince Arthas, and what remains of his forces, have landed on the shores of Northrend and established a base camp."] =
      "El Príncipe Heredero Arthas, y lo que queda de sus fuerzas, han desembarcado en las costas de Rasganorte y establecido un campamento base.",
    ["A new base near Dragonblight in Northrend, and Arthas revives there"] = "Una nueva base cerca del Cementerio de Dragones en Rasganorte, y Arthas revive allí",

    // Lordaeron - QuestThunderEagle
    ["To the Skies!"] = "¡Hacia los Cielos!",
    ["The Thunder Eagles of the Storm Peaks live in fear of the Legion. Wipe out the Legion Nexus to bring these great birds out into the open."] =
      "Las Águilas del Trueno de los Picos Tempestuosos viven con miedo de la Legión. Elimina el Nexo de la Legión para hacer salir a estas grandes aves a campo abierto.",
    ["You can now train Thunder Eagles at the High Tower."] = "Ahora puedes entrenar Águilas del Trueno en la Torre Alta.",

    // Lordaeron - QuestChampionoftheLight
    ["Champion of the Light"] = "Campeón de la Luz",
    ["Uther Lightbringer is a paragon of Light and a champion of Lordaeron. His example inspires many man to rise up."] =
      "Uther Portador de la Luz es un dechado de la Luz y un campeón de Lordaeron. Su ejemplo inspira a muchos hombres a levantarse.",
    ["Uther has achieved the status of living legend, inspiring the men and women of Lordaeron to strive for greatness."] =
      "Uther ha alcanzado el estatus de leyenda viviente, inspirando a los hombres y mujeres de Lordaeron a luchar por la grandeza.",
    ["Your casters and Paladins gain 200 hit points and 5 damage, and Paladins gain the Reincarnation ability"] =
      "Tus lanzadores de hechizos y Paladines ganan 200 puntos de vida y 5 de daño, y los Paladines ganan la habilidad Reencarnación",

    // Lordaeron - QuestKingArthas
    ["Line of Succession"] = "Línea de Sucesión",
    ["Arthas Menethil is the sole heir to the Lordaeron crown. His father, ever obstinate in his old age, denies the existential threat of the Scourge and forbids Arthas from bringing the fight to Northrend. The crown prince will simply have to take matters into his own hands."] =
      "Arthas Menethil es el único heredero de la corona de Lordaeron. Su padre, siempre obstinado en su vejez, niega la amenaza existencial de la Plaga y prohíbe a Arthas llevar la lucha a Rasganorte. El príncipe heredero simplemente tendrá que tomar el asunto en sus propias manos.",
    ["Fate decreed that Arthas would witness the fall of Stratholme and become corrupted by vengeance. Instead, he defended his homeland from the ravenous Scourge and took the battle to Northrend. Back at home, Terenas Menethil is forced to admit: his son is ready to be King."] =
      "El destino decretó que Arthas sería testigo de la caída de Stratholme y se corrompería por la venganza. En cambio, defendió su tierra natal de la voraz Plaga y llevó la batalla a Rasganorte. De vuelta en casa, Terenas Menethil se ve obligado a admitir: su hijo está listo para ser Rey.",
    ["King Emeritus Terenas Menethil"] = "Rey Emérito Terenas Menethil",

    // Lordaeron - QuestKingdomOfManLordaeron
    ["Kingdom of Man"] = "El Reino de los Hombres",
    ["Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again."] =
      "Antes de la Primera Guerra, toda la humanidad estaba unida bajo el estandarte del Imperio Arathoriano. Reclama su grandeza uniendo a la humanidad una vez más.",
    ["The people of the Eastern Kingdoms have been united under the banner of Lordaeron. Long live High King Arthas Menethil!"] =
      "El pueblo de los Reinos del Este ha sido unido bajo el estandarte de Lordaeron. ¡Larga vida al Alto Rey Arthas Menethil!",
    ["You gain a research improving all of your units, the Crowns of Lordaeron and Stormwind are merged, and Arthas gains 10000 experience"] =
      "Obtienes una investigación que mejora a todas tus unidades, las Coronas de Lordaeron y Ventormenta se fusionan, y Arthas gana 10000 de experiencia",

    // Gilneas - QuestGilneasCity
    ["Gilneas City"] = "Ciudad de Gilneas",
    ["The Great Kingdom of Gilneas has been reduced to its land behind the Greymane Wall, We must reclaim our lost land to regain our strength."] =
      "El Gran Reino de Gilneas ha quedado reducido a sus tierras tras el Muro de Greymane. Debemos recuperar nuestras tierras perdidas para recobrar nuestras fuerzas.",
    ["Liberation of Gilneas"] = "Liberación de Gilneas",
    ["Gain control of the Greymane Wall and Gilneas City. Enable to train Genn Greymane and the Worgen units."] =
      "Obtén control del Muro de Greymane y la Ciudad de Gilneas. Habilita entrenar a Genn Greymane y a las unidades Worgen.",

    // Gilneas - QuestDalarangilneas
    ["Dalaran"] = "Dalaran",
    ["To force the mages of Dalaran to submit to our might we must Secure the outlying regions of the Arathi Highlands, The Hinterlands and the Troll city of Jintha'alor"] =
      "Para forzar a los magos de Dalaran a someterse a nuestro poder, debemos asegurar las regiones periféricas de las Tierras Altas de Arathi, las Tierras del Interior y la ciudad Trol de Jintha'alor",
    ["The mages of Dalaran has decided to submit to our might after noticing our resurgent control of Southern-Lordaeron to help defeat the Scourge."] =
      "Los magos de Dalaran han decidido someterse a nuestro poder al notar nuestro resurgente control del sur de Lordaeron para ayudar a derrotar a la Plaga.",
    ["Control of all buildings in Dalaran."] = "Control de todos los edificios en Dalaran.",

    // Gilneas - QuestCrowley
    ["The Rebel"] = "El Rebelde",
    ["Darius Crowley has been imprisoned since the Northgate rebellion. If Gilneas were to fall into grave peril, an early release might be necessary."] =
      "Darius Crowley ha estado encarcelado desde la rebelión de Northgate. Si Gilneas cayera en grave peligro, podría ser necesaria una liberación anticipada.",
    ["Facing the looming threat of the Scourge and its horrific Plague, Genn Greymane has decided to pardon Darius Crowley for the Northgate rebellion so that he can assist in Gilneas' defense."] =
      "Ante la inminente amenaza de la Plaga y su horrible flagelo, Genn Greymane ha decidido perdonar a Darius Crowley por la rebelión de Northgate para que pueda ayudar en la defensa de Gilneas.",

    // Gilneas - QuestGoldrinn
    ["Shrine of the Wolf God"] = "Santuario del Dios Lobo",
    ["The Worgen curse originated from Goldrinn, the embodiment of ferocity, savagery, and unyielding will. Traveling to Mount Hyjal we might contact the wolf god to help us against our curse."] =
      "La maldición Worgen se originó de Goldrinn, la encarnación de la ferocidad, el salvajismo y la voluntad inquebrantable. Viajando al Monte Hyjal, quizás podamos contactar al dios lobo para que nos ayude contra nuestra maldición.",
    ["Tess Greymane calls to Goldrinn's spirit. Revolted at the horrors that his fang had wrought on the Gilnean people but impressed with their ferocity, he returns to the mortal world, ready to rend and tear for his new people."] =
      "Tess Greymane invoca al espíritu de Goldrinn. Repugnado por los horrores que su colmillo había causado al pueblo Gilneano, pero impresionado por su ferocidad, regresa al mundo mortal, listo para desgarrar y destrozar por su nuevo pueblo.",

    // Quelthalas faction
    ["Kingdom of Quel'Thalas"] = "Reino de Quel'Thalas",
    ["You are playing as the proud {faction}.\n\nYou begin in Tranquillien, separated from Silvermoon. The Trolls of Zul'Aman have laid siege to the city and are preparing attacks on your base.\n\nTrain soldiers to repel the attacks, then gather enough strength to besiege Zul'Aman and take the head of Zul'jin.\n\nThe Plague of Undeath is imminent, and Lordaeron will soon need your help against the Scourge. Be ready to join them once you have secured Silvermoon and dealt with the Amani invasion."] =
      "Juegas como el orgulloso {faction}.\n\nComienzas en Tranquillien, separado de Lunargenta. Los Trolls de Zul'Aman han sitiado la ciudad y se preparan para atacar tu base.\n\nEntrena soldados para repeler los ataques, luego reúne suficiente fuerza para sitiar Zul'Aman y tomar la cabeza de Zul'jin.\n\nLa Plaga de la No-Muerte es inminente, y Lordaeron pronto necesitará tu ayuda contra la Plaga. Prepárate para unirte a ellos una vez que hayas asegurado Lunargenta y lidiado con la invasión Amani.",

    // Quelthalas - dialogue (RegisterScourgeDialogue)
    ["Are you still upset that I stole Jaina from you, Kael?"] =
      "¿Todavía estás molesto porque te robé a Jaina, Kael?",
    ["You've taken everything I ever cared for, Arthas. Vengeance is all I have left."] =
      "Te has llevado todo lo que alguna vez me importó, Arthas. La venganza es todo lo que me queda.",

    // Quelthalas - FontOfPower power
    ["Font of Power"] = "Fuente de Poder",
    ["All units deal {damage}% extra damage and regain {mana}% of the mana cost of abilities. Only active while your team controls the Sunwell, the Well of Eternity, Black Temple, or Nordrassil."] =
      "Todas las unidades infligen {damage}% de daño adicional y recuperan {mana}% del costo de maná de las habilidades. Solo está activo mientras tu equipo controle el Pozo del Sol, el Pozo de la Eternidad, el Templo Negro, o Nordrassil.",

    // Quelthalas - CorruptedSunwell power
    ["Corrupted Sunwell"] = "Pozo del Sol Corrupto",
    ["Your units are damaged for {damage}% of the mana they spend on spells. Units that die from this effect are reanimated as hostile Wretched."] =
      "Tus unidades sufren daño equivalente al {damage}% del maná que gastan en hechizos. Las unidades que mueren por este efecto reviven como Consumidos hostiles.",

    // Quelthalas - QuelthalasLegends
    ["The grand city of the high elves, Silvermoon, has been crushed by her enemies."] =
      "La gran ciudad de los altos elfos, Lunargenta, ha sido aplastada por sus enemigos.",
    ["The Sunwell, once a source of great magical energy, is no more. Its corruption has ended, and the land is free from its dark influence."] =
      "El Pozo del Sol, alguna vez fuente de gran energía mágica, ya no existe. Su corrupción ha terminado, y la tierra está libre de su oscura influencia.",

    // Quelthalas - QuestDestroyCorruptedSunwell
    ["Forever Dusk"] = "El Ocaso Eterno",
    ["The necrotic taint at the heart of the Sunwell now permeates not only our people, but all we have built. The sacrifice we must make is grave but inevitable: the Sunwell must be destroyed by Thalassian hands."] =
      "La corrupción necrótica en el corazón del Pozo del Sol ahora impregna no solo a nuestro pueblo, sino todo lo que hemos construido. El sacrificio que debemos hacer es grave pero inevitable: el Pozo del Sol debe ser destruido por manos Thalassianas.",
    ["Lose the Corrupted Sunwell power"] = "Pierdes el poder Pozo del Sol Corrupto",
    ["The blighted tumour of the Sunwell has been excised from the Thalassian homeland. Its people have already turned their magical thirst elsewhere, drawing upon the magicks of {font}."] =
      "El tumor maldito del Pozo del Sol ha sido extirpado de la patria Thalassiana. Su pueblo ya ha volcado su sed mágica hacia otro lugar, bebiendo de las artes arcanas de {font}.",
    ["With the Sunwell destroyed, the people of Quel'thalas are freed from its necrotic influence. Yet still they yearn for its magical energies - this addiction must be sated another way."] =
      "Con el Pozo del Sol destruido, el pueblo de Quel'thalas se libera de su influencia necrótica. Sin embargo, aún anhelan sus energías mágicas: esta adicción debe saciarse de otra manera.",

    // Quelthalas - QuestForgottenKnowledge
    ["Forgotten Knowledge"] = "Conocimiento Olvidado",
    ["The Sunfury have a long, proud history, tracing all the way back to their status as the Highborne. We have forgotten more knowledge than other races have ever known. Perhaps some of it lies within the ruins of the old Highborne kingdom, Suramar."] =
      "Los Sunfury tienen una larga y orgullosa historia, que se remonta hasta su condición de Altos Nacidos. Hemos olvidado más conocimiento del que otras razas jamás llegaron a conocer. Quizás parte de él yazca entre las ruinas del antiguo reino de los Altos Nacidos, Suramar.",

    // Quelthalas - QuestQueensArchive
    ["The Queen's Archive"] = "El Archivo de la Reina",
    ["Queen Azshara studied many forms of arcane knowledge, some darker than others. With access to her library and enough time, the highborn scholares could uncover her secrets"] =
      "La Reina Azshara estudió muchas formas de conocimiento arcano, algunas más oscuras que otras. Con acceso a su biblioteca y suficiente tiempo, los eruditos Altos Nacidos podrían descubrir sus secretos",
    ["You can now train Warlocks at the Consortium"] = "Ahora puedes entrenar Brujos en el Consorcio",

    // Quelthalas - QuestQueldanil
    ["Quel'danil Lodge"] = "Refugio Quel'danil",
    ["Quel'danil Lodge is a High Elven outpost situated in the Hinterlands. It's been some time since the rangers there have been in contact with Quel'thalas."] =
      "El Refugio Quel'danil es un puesto avanzado de los Altos Elfos situado en las Tierras del Interior. Ha pasado tiempo desde que los guardabosques de allí estuvieron en contacto con Quel'thalas.",
    ["The rangers of Quel'danil have been reunited with the forces of Quel'thalas."] =
      "Los guardabosques de Quel'danil se han reunido con las fuerzas de Quel'thalas.",
    ["Gain control of Quel'danil Lodge and its rangers"] = "Obtienes control del Refugio Quel'danil y sus guardabosques",

    // Quelthalas - QuestSilvermoon
    ["The Siege of Silvermoon"] = "El Asedio de Lunargenta",
    ["The Amani Trolls have been harassing Silvermoon since its founding, but their defensive position within their jungle has made the prospect of an all-out assault too costly. Today, however, the Amani begins their largest siege yet. They leave us no choice; we must scour Zul'aman if the High Elves are to prosper."] =
      "Los Trolls Amani han estado hostigando Lunargenta desde su fundación, pero su posición defensiva dentro de su selva ha hecho que un asalto total resulte demasiado costoso. Hoy, sin embargo, los Amani inician su mayor asedio hasta la fecha. No nos dejan otra opción; debemos arrasar Zul'aman si los Altos Elfos han de prosperar.",
    ["The Amani trolls have been eliminated, settling a racial feud that had persisted for millenia."] =
      "Los trolls Amani han sido eliminados, poniendo fin a una disputa racial que había persistido durante milenios.",
    ["Control of all units in Silvermoon, unlock the Summon Mystic Defenders ability from Elven Runestones and enable Anasterian to be trained at the Altar"] =
      "Control de todas las unidades en Lunargenta, desbloquea la habilidad Invocar Defensores Místicos en las Runas Élficas y habilita entrenar a Anasterian en el Altar",

    // Quelthalas - QuestTheBloodElves
    ["The Blood Elves"] = "Los Elfos de Sangre",
    ["The Elves of Quel'thalas have a deep reliance on the Sunwell's magic. But perhaps in these dark times, they might turn to darker magicks to sate themselves."] =
      "Los Elfos de Quel'thalas dependen profundamente de la magia del Pozo del Sol. Pero quizás, en estos tiempos oscuros, recurran a artes más oscuras para saciarse.",
    ["The Legion Nexus has been obliterated. A group of ambitious mages seize the opportunity to study the demons' magic, becoming the first Blood Mages."] =
      "El Nexo de la Legión ha sido aniquilado. Un grupo de magos ambiciosos aprovecha la oportunidad para estudiar la magia de los demonios, convirtiéndose en los primeros Magos de Sangre.",

    // Quelthalas - QuestUnlockSpire
    ["The Windrunner tower is a strong asset to Quel'thalas."] =
      "La torre de los Windrunner es un gran activo para Quel'thalas.",
    ["Control of the Windrunner Spire"] = "Control de la Aguja de Windrunner",

    // ScarletCrusade - ScarletLegends
    ["The Crimson Cathedral has been destroyed"] = "La Catedral Carmesí ha sido destruida",

    // ScarletCrusade - QuestCrimsonCathedral
    ["The Crimson Cathedral"] = "La Catedral Carmesí",
    ["The Crusade's architects have drawn up plans for an ornate cathedral, to be erected in the frozen wastes of Northrend. It shall be a beacon in the dark."] =
      "Los arquitectos de la Cruzada han elaborado planos para una catedral ornamentada, que se erigirá en los yermos helados de Rasganorte. Será un faro en la oscuridad.",
    ["The Crimson Cathedral has been established in Northrend. Seeing first-hand that the Light can reach even the darkest places of the world, what few shreds of doubt lingering in Brigitte Abbendis' soul evaporate."] =
      "La Catedral Carmesí ha sido establecida en Rasganorte. Al ver de primera mano que la Luz puede alcanzar incluso los lugares más oscuros del mundo, los pocos jirones de duda que quedaban en el alma de Brigitte Abbendis se desvanecen.",
    ["Brigitte Abbendis gains the Divine Intervention ability, and you gain control of the Crimson Cathedral in Sholazar Bassin"] =
      "Brigitte Abbendis obtiene la habilidad Divine Intervention, y obtienes control de la Catedral Carmesí en la Cuenca de Sholazar",

    // ScarletCrusade - QuestOnslaught
    ["Onslaught"] = "Arremetida",
    ["Death awaits the living at the roof of the world. It is there that the Crusade must undertake its ultimate vengeance."] =
      "La muerte aguarda a los vivos en el techo del mundo. Es allí donde la Cruzada debe emprender su venganza definitiva.",
    ["The Crusade finally manages to establish a foothold in Northrend. Already the land's dark influence pierces the mind of even its most stalwart Archons."] =
      "La Cruzada finalmente logra establecer una posición en Rasganorte. Ya la oscura influencia de la tierra penetra la mente incluso de sus Arcontes más firmes.",

    // ScarletCrusade - QuestRebuildAndorhal
    ["Once the breadbasket of Lordaeron, Andorhal is now nothing but ashes. Were it to be rebuilt, its proximity to Aerie Peak would allow the Scarlet Crusade to breed powerful Eagles and Gryphons."] =
      "Antaño el granero de Lordaeron, Andorhal ahora no es más que cenizas. Si fuera reconstruido, su proximidad a la Cima del Nido permitiría a la Cruzada Escarlata criar poderosos Águilas y Grifos.",
    ["Survivors from Lordaeron's fall are once more pouring into Andorhal. Eagles and Gryphons from Aerie Peak soar down to the renewed agricultural center to enjoy its renewed production."] =
      "Los sobrevivientes de la caída de Lordaeron vuelven a llegar en masa a Andorhal. Águilas y Grifos de la Cima del Nido descienden hacia el renovado centro agrícola para disfrutar de su producción renovada.",

    // ScarletCrusade - QuestRebuildBrill
    ["The desolated village of Brill was once the hometown of Renault Mograine. Though insignificant in the grand scheme of things, the Crusade cares for its members."] =
      "La desolada aldea de Brill fue alguna vez el pueblo natal de Renault Mograine. Aunque insignificante en el gran esquema de las cosas, la Cruzada se preocupa por sus miembros.",
    ["Nobody had noticed, but until now Renault has been somewhat reserved in his actions. With his hometown now reclaimed, he shines with a new vigour."] =
      "Nadie lo había notado, pero hasta ahora Renault se había mostrado algo reservado en sus acciones. Con su pueblo natal ahora recuperado, brilla con un nuevo vigor.",
    ["Renault gains 6000 experience"] = "Renault gana 6000 de experiencia",

    // ScarletCrusade - QuestRebuildHearthglen
    ["Though the town of Hearthglen fell to the Scourge just as easily as any other, the Silver Hand Monastery there makes it a key strategic objective for the Scarlet Crusade."] =
      "Aunque la ciudad de Hearthglen cayó ante la Plaga con la misma facilidad que cualquier otra, el Monasterio de la Mano de Plata allí la convierte en un objetivo estratégico clave para la Cruzada Escarlata.",
    ["With the Monastery under Scarlet control, Sally Whitemane can be brought into the fold of the Crusade's leadership in earnest."] =
      "Con el Monasterio bajo control Escarlata, Sally Whitemane puede ser incorporada de lleno al liderazgo de la Cruzada.",

    // ScarletCrusade - QuestRebuildStratholme
    ["Before the Plague wiped out Stratholme, Saiden had established himself there as Lord Commander of the Silver Hand. This once-glorious city must be reclaimed."] =
      "Antes de que la Plaga arrasara Stratholme, Saiden se había establecido allí como Lord Comandante de la Mano de Plata. Esta otrora gloriosa ciudad debe ser recuperada.",
    ["The city of Stratholme once more stands as a bastion of human civilization. Though still a mere shadow of its former glory, it will reclaim its majesty in time."] =
      "La ciudad de Stratholme vuelve a erguirse como un bastión de la civilización humana. Aunque todavía es una mera sombra de su antigua gloria, recuperará su majestuosidad con el tiempo.",
    ["Saiden Dathrohan gains 6000 experience"] = "Saiden Dathrohan gana 6000 de experiencia",

    // ScarletCrusade - QuestReconquerCapital
    ["Lordaeron City"] = "Lordaeron City",
    ["Lordaeron City was once the heart of the Alliance and the center of the humanity before its fall. It must be reclaimed at all costs."] =
      "La Ciudad de Lordaeron fue alguna vez el corazón de la Alianza y el centro de la humanidad antes de su caída. Debe ser recuperada a toda costa.",
    ["The Scarlet Crusade has successfully rebuilt Lordaeron City, cementing their position as the rightful successors of Lordaeron's legacy."] =
      "La Cruzada Escarlata ha reconstruido con éxito la Ciudad de Lordaeron, consolidando su posición como los legítimos sucesores del legado de Lordaeron.",
    ["All of your heroes gain 2000 experience"] = "Todos tus héroes ganan 2000 de experiencia",
    ["in Capital City"] = "en la Ciudad Capital",

    // ScarletCrusade - QuestReconquerLordaeron
    ["A Once Great People"] = "Un Pueblo Antaño Grande",
    ["The onslaught of the Scourge devastated Lordaeron beyond recognition, slaughtering its people and levelling its cities. Only the Scarlet Crusade stands strong, a faint light of hope in the darkness. If the cities and village of Lordaeron could be reclaimed and rebuilt, humanity could begin again."] =
      "La embestida de la Plaga devastó Lordaeron más allá del reconocimiento, masacrando a su gente y arrasando sus ciudades. Solo la Cruzada Escarlata se mantiene firme, una tenue luz de esperanza en la oscuridad. Si las ciudades y aldeas de Lordaeron pudieran ser recuperadas y reconstruidas, la humanidad podría comenzar de nuevo.",
    ["Against all odds, the Scarlet Crusade has reclaimed and rebuilt the lands of Lordaeron, filling its cities and fields with the beginnings of a new generation. Having proven itself capable of far more than simple vengeance, the Crusade receives the Light's ultimate blessing."] =
      "Contra todo pronóstico, la Cruzada Escarlata ha recuperado y reconstruido las tierras de Lordaeron, llenando sus ciudades y campos con los inicios de una nueva generación. Habiendo demostrado ser capaz de mucho más que simple venganza, la Cruzada recibe la bendición definitiva de la Luz.",
    ["Learn to build the Divine Bastion"] = "Aprende a construir el Bastión Divino",

    // Scourge faction
    ["Undead Scourge"] = "Plaga de los No-Muertos",
    ["You are playing as the horrific {faction}.\n\nYou begin in Northrend, a vast and isolated land—perfect for raising an army of undying warriors to annihilate the living.\n\nThe local Nerubians have declared war on you. Destroy their decrepit holdings and slay their Queen to secure the continent.\n\nCoordinate with the Burning Legion and unleash the Plague of Undeath to sweep Lordaeron away.\n\nWhen the Plague strikes Lordaeron, you will have a choice of where to instantly transport all your military units."] =
      "Juegas como la horrible {faction}.\n\nComienzas en Rasganorte, una tierra vasta y aislada, perfecta para levantar un ejército de guerreros no-muertos que aniquile a los vivos.\n\nLos Nerubianos locales te han declarado la guerra. Destruye sus decrépitos dominios y da muerte a su Reina para asegurar el continente.\n\nCoordínate con la Legión Ardiente y desata la Plaga de la No-Muerte para arrasar Lordaeron.\n\nCuando la Plaga golpee Lordaeron, podrás elegir a dónde transportar instantáneamente todas tus unidades militares.",
    ["All-Seeing"] = "Omnisciente",
    ["Grants permanent vision over Northrend."] = "Otorga visión permanente sobre Rasganorte.",

    // Scourge - RegisterDialogue (Kel'thuzad summons the Legion)
    ["Come forth, Lord Archimonde! Enter this world, and let us bask in your power!"] =
      "¡Ven, Señor Archimonde! ¡Entra en este mundo, y dejemos que nos bañemos en tu poder!",

    // Scourge - RegisterDalaranDialogue
    ["Wizards of the Kirin Tor! I am Arthas, first of the Lich King's death knights! I demand that you open your gates and surrender to the might of the Scourge!"] =
      "¡Magos de Kirin Tor! ¡Soy Arthas, el primero de los caballeros de la muerte del Rey Exánime! ¡Exijo que abran sus puertas y se rindan ante el poder de la Plaga!",
    ["Greetings, Prince Arthas. How fares your noble father?"] =
      "Saludos, Príncipe Arthas. ¿Cómo se encuentra tu noble padre?",
    ["Lord Antonidas. There's no need to be snide."] = "Lord Antonidas. No hace falta ser sarcástico.",
    ["We've prepared for your coming, Arthas. My brethren and I have erected auras that will destroy any undead that pass through them."] =
      "Nos hemos preparado para tu llegada, Arthas. Mis hermanos y yo hemos erigido auras que destruirán a cualquier no-muerto que pase a través de ellas.",
    ["Your petty magics will not stop me, Antonidas."] = "Tu mísera magia no me detendrá, Antonidas.",
    ["Pull your troops back, or we will be forced to unleash our full powers against you! Make your choice, death knight."] =
      "Retira a tus tropas, o nos veremos obligados a desatar todo nuestro poder contra ti. Elige, caballero de la muerte.",

    // Scourge - RegisterLordaeronDialogue
    ["Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins."] =
      "Necio ingenuo. Mi muerte hará poca diferencia a largo plazo. Por ahora, el flagelo de esta tierra... comienza.",

    // Scourge - RegisterQuelthalasDialogue
    ["Ah, wondrous, eternal Quel'Thalas. I haven't been here since I was a boy."] =
      "Ah, maravilloso y eterno Quel'Thalas. No he estado aquí desde que era un niño.",
    ["Be wary. The elves likely wait in ambush."] = "Ten cuidado. Los elfos probablemente esperan en emboscada.",
    ["The frail elves do not concern me, necromancer. Our forces are strengthened with every foe we slay."] =
      "Los frágiles elfos no me preocupan, nigromante. Nuestras fuerzas se fortalecen con cada enemigo que abatimos.",
    ["Don't be too overconfident, death knight. The elves must not be taken lightly."] =
      "No seas demasiado confiado, caballero de la muerte. No hay que subestimar a los elfos.",
    ["You are not welcome here. I am Sylvanas Windrunner, Ranger-General of Silvermoon. I advise you to turn back now."] =
      "No eres bienvenido aquí. Soy Sylvanas Windrunner, General de Guardabosques de Lunargenta. Te aconsejo que regreses ahora.",
    ["It is you who should turn back, Sylvanas. Death itself has come for your land."] =
      "Eres tú quien debería regresar, Sylvanas. La muerte misma ha venido por tu tierra.",
    ["Now, arise, Kel'Thuzad, and serve the Lich King once again!"] =
      "¡Ahora, levántate, Kel'Thuzad, y sirve al Rey Exánime una vez más!",
    ["I am reborn, as promised! The Lich King has granted me eternal life!"] =
      "¡He renacido, tal como se prometió! ¡El Rey Exánime me ha concedido la vida eterna!",
    ["Told you my death would mean little."] = "Te dije que mi muerte significaría poco.",
    ["What the... Am I hearing ghosts now?"] = "Qué... ¿Ahora escucho fantasmas?",
    ["It is I, Kel'Thuzad. I was right about you, Prince Arthas."] =
      "Soy yo, Kel'Thuzad. Tenía razón sobre ti, Príncipe Arthas.",

    // Scourge - RegisterLegionDialogue
    ["I was wondering when you'd show up."] = "Me preguntaba cuándo aparecerías.",
    ["I am here to ensure that you do your job, little human. Not do it for you."] =
      "Estoy aquí para asegurarme de que hagas tu trabajo, pequeño humano. No para hacerlo por ti.",

    // Scourge - Domination power
    ["Domination"] = "Dominación",
    ["You can train and control Ghouls, Abominations, Frost Wyrms, and Crypt Fiends."] =
      "Puedes entrenar y controlar Necrófagos, Abominaciones, Wyrms de Escarcha y Engendros de Cripta.",

    // Scourge - QuestCultoftheDamned (Cult Spies power)
    ["The Cult of the Damned"] = "El Culto de los Condenados",
    ["To prepare the destruction of the Lordaeron kingdom, a secret cult will be formed."] =
      "Para preparar la destrucción del reino de Lordaeron, se formará un culto secreto.",
    ["With the Cult of the Damned established, the Scourge can plan their invasion of Lordaeron. The powerful Baron Rivendare has also joined the Cult to serve the Lich King."] =
      "Con el Culto de los Condenados establecido, la Plaga puede planear su invasión de Lordaeron. El poderoso Barón Rivendare también se ha unido al Culto para servir al Rey Exánime.",
    ["Cult Spies"] = "Espías del Culto",
    ["Grants vision of all of Lordaeron's units."] = "Otorga visión de todas las unidades de Lordaeron.",

    // Scourge - QuestDestroyStratholme
    ["The Culling"] = "La Purga",
    ["When the city of Stratholme falls, Prince Arthas' despair will make him more susceptible to the power of the Lich King."] =
      "Cuando la ciudad de Stratholme caiga, la desesperación del Príncipe Arthas lo hará más susceptible al poder del Rey Exánime.",
    ["Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion."] =
      "Tras fallar en proteger a su pueblo, Arthas empuña la maldita hoja rúnica Añoranza Helada como instrumento de su venganza. La malevolencia de la hoja lo domina por completo. Arthas es ahora un leal Caballero de la Muerte de la Plaga, y pronto se convertirá en su mayor campeón.",

    // Scourge - QuestDrakUnlock
    ["Drak'tharon Keep"] = "Fuerte Drak'tharon",
    ["Drak'tharon Keep will be the perfect place for an outpost by the sea."] =
      "El Fuerte Drak'tharon será el lugar perfecto para un puesto avanzado junto al mar.",

    // Scourge - QuestEnKilahUnlock
    ["Temple City of En'kilah"] = "Ciudad Templo de En'kilah",
    ["The temple city of En'kilah will be the perfect place for an outpost near the Borean Tundra."] =
      "La ciudad templo de En'kilah será el lugar perfecto para un puesto avanzado cerca de la Tundra Boreal.",
    ["The temple city of En'kilah is now under the control of the Scourge."] =
      "La ciudad templo de En'kilah está ahora bajo el control de la Plaga.",
    ["Control of all buildings in En'Kilah"] = "Control de todos los edificios en En'Kilah",

    // Scourge - QuestKelthuzadDies (file QuestKelthuzadDeath.cs)
    ["Life Beyond Death"] = "Vida Más Allá de la Muerte",
    ["The Lich King has foretold that the human necromancer Kel'thuzad will be slain by the enemies of the Scourge. Fortunately for him, he will live on in an ethereal form."] =
      "El Rey Exánime ha profetizado que el nigromante humano Kel'thuzad será abatido por los enemigos de la Plaga. Afortunadamente para él, seguirá viviendo en una forma etérea.",
    ["As foretold by the Lich King, Kel'thuzad has been slain. Unseen to his assailants, his spirit is carried away by the howling winds of Northrend and reconstituted at the base of Icecrown Citadel."] =
      "Tal como profetizó el Rey Exánime, Kel'thuzad ha sido abatido. Sin que sus agresores lo perciban, su espíritu es arrastrado por los aullantes vientos de Rasganorte y reconstituido en la base de la Ciudadela de Corona de Hielo.",
    ["In a rare twist of fate, the Lich King's prophecy did not come to pass: Kel'thuzad survived long enough to reach the Sunwell under his own power."] =
      "En un raro giro del destino, la profecía del Rey Exánime no se cumplió: Kel'thuzad sobrevivió lo suficiente para alcanzar el Pozo del Sol por sus propios medios.",
    ["If Kel'thuzad dies, he revives in spectral form at Icecrown Citadel. Otherwise, he gains 4000 experience"] =
      "Si Kel'thuzad muere, revive en forma espectral en la Ciudadela de Corona de Hielo. De lo contrario, gana 4000 de experiencia",

    // Scourge - QuestKelthuzadLich
    ["Into the Realm Eternal"] = "Al Reino Eterno",
    ["Kel'thuzad is the leader of the Cult of the Damned and an extraordinarily powerful necromancer. If he were to be brought to the Sunwell and submerged in its waters, he would be reanimated as an immortal Lich."] =
      "Kel'thuzad es el líder del Culto de los Condenados y un nigromante extraordinariamente poderoso. Si fuera llevado al Pozo del Sol y sumergido en sus aguas, sería reanimado como un Lich inmortal.",
    ["The Necromancer Kel'thuzad has been immersed in the Sunwell and reborn as a Lich. The well, formerly a beacon of eternal light and power, has been twisted into a font of dark magic, spreading malevolence across the land."] =
      "El Nigromante Kel'thuzad ha sido sumergido en el Pozo del Sol y ha renacido como un Lich. El pozo, antes un faro de luz y poder eternos, se ha retorcido en una fuente de magia oscura, esparciendo malevolencia por la tierra.",
    ["Permanently corrupt the Sunwell and turn Kel'thuzad into a Lich, causing his Dark Ritual ability to also summon a Revenant"] =
      "Corrompe permanentemente el Pozo del Sol y convierte a Kel'thuzad en un Lich, haciendo que su habilidad Ritual Oscuro también invoque a un Revenant",
    ["The Sunwell"] = "The Sunwell",

    // Scourge - QuestLichKingArthas
    ["The Ascension"] = "La Ascensión",
    ["From within the depths of the Frozen Throne, the Lich King Ner'zhul cries out for his champion. Release the Helm of Domination from its confines and merge its power with that of the Scourge's greatest Death Knight."] =
      "Desde las profundidades del Trono de Hielo, el Rey Exánime Ner'zhul clama por su campeón. Libera el Yelmo de la Dominación de su confinamiento y fusiona su poder con el del mayor Caballero de la Muerte de la Plaga.",
    ["Arthas has ascended the Frozen Throne itself and shattered Ner'zhul's frozen prison. Ner'zhul and Arthas are now joined, body and soul, into one being: the god-like Lich King."] =
      "Arthas ha ascendido al mismísimo Trono de Hielo y ha destrozado la prisión helada de Ner'zhul. Ner'zhul y Arthas ahora están unidos, cuerpo y alma, en un solo ser: el Rey Exánime, semejante a un dios.",
    ["Arthas becomes the Lich King, the Frozen Throne loses its abilities, and you regain the Domination power if you don't have it"] =
      "Arthas se convierte en el Rey Exánime, el Trono de Hielo pierde sus habilidades, y recuperas el poder Dominación si no lo tienes",
    ["The day he was born, the very forests of Lordaeron whispered the name Arthas - but no King rules forever."] =
      "El día en que nació, los mismos bosques de Lordaeron susurraron el nombre de Arthas, pero ningún Rey gobierna para siempre.",

    // Scourge - QuestPlague
    ["Plague of Undeath"] = "Plaga de la No-Muerte",
    ["The Cult of the Damned is prepared to unleash a devastating zombifying plague across the lands of Lordaeron."] =
      "El Culto de los Condenados está preparado para desatar una devastadora plaga zombificante por las tierras de Lordaeron.",
    ["The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies"] =
      "¡La plaga ha sido desatada! Los ciudadanos de Lordaeron se transforman rápidamente en zombis sin mente",
    ["Several small armies under your control spawn throughout Lordaeron, you gain control of three bases around Lordaeron, Lordaeron's Control Points reset to level 0, and you will be given a choice to instantly move your military units from Northrend to one of three locations in Lordaeron"] =
      "Varios pequeños ejércitos bajo tu control aparecen por todo Lordaeron, obtienes control de tres bases alrededor de Lordaeron, los Puntos de Control de Lordaeron se reinician a nivel 0, y se te dará la opción de mover instantáneamente tus unidades militares desde Rasganorte a una de tres ubicaciones en Lordaeron",
    ["Pick invasion location"] = "Elige la ubicación de la invasión",
    ["No invasion"] = "Sin invasión",
    ["Deathknell"] = "El Doblar de la Muerte",

    // Scourge - QuestSapphiron
    ["Kill Sapphiron the Blue Dragon to have Kel'Thuzad reanimate her as a Frost Wyrm. Sapphiron can be found in Northrend."] =
      "Mata a Sapphiron la Dragona Azul para que Kel'Thuzad la reanime como un Wyrm de Escarcha. Sapphiron puede encontrarse en Rasganorte.",
    ["Sapphiron has been slain, and has been reanimated as a mighty Frost Wyrm under the command of the Scourge."] =
      "Sapphiron ha sido abatida, y ha sido reanimada como un poderoso Wyrm de Escarcha bajo el mando de la Plaga.",

    // Scourge - QuestSlumberingKing
    ["The Slumbering King"] = "El Rey Durmiente",
    ["Ner'zhul commands the undead hordes from his throne atop Icecrown, waiting patiently for the inevitable day that interlopers will come to invade his frozen lands."] =
      "Ner'zhul comanda las huestes no-muertas desde su trono en lo alto de Corona de Hielo, esperando pacientemente el día inevitable en que los intrusos vengan a invadir sus tierras heladas.",
    ["A {unit} under the control of {faction} has encroached on the shores of Northrend. Soon they will feel the biting chill of death."] =
      "Una {unit} bajo el control de {faction} se ha adentrado en las costas de Rasganorte. Pronto sentirán el gélido frío de la muerte.",
    ["unit"] = "unidad",
    ["an unknown faction"] = "una facción desconocida",
    ["Learn to cast Frost Nova and Animate Dead from the Frozen Throne"] =
      "Aprende a lanzar Nova de Escarcha y Animar Muertos desde el Trono de Hielo",

    // Scourge - QuestSpiderWar
    ["War of the Spider"] = "La Guerra de la Araña",
    ["The proud Nerubians have declared war on the newly formed Lich King, destroy them to secure the continent of Northrend."] =
      "Los orgullosos Nerubianos le han declarado la guerra al recién formado Rey Exánime, destrúyelos para asegurar el continente de Rasganorte.",
    ["Northrend and the Icecrown Citadel is now under full control of the Lich King and the Scourge."] =
      "Rasganorte y la Ciudadela de Corona de Hielo están ahora bajo pleno control del Rey Exánime y la Plaga.",
    ["Gain control of a base in Icecrown"] = "Obtienes control de una base en Corona de Hielo",

    // Scourge - Mechanics/TheFrozenThrone
    ["Frozen Throne (Empty)"] = "Frozen Throne (Empty)",
    ["Frozen Throne (Ruptured)"] = "Frozen Throne (Ruptured)",
    ["Icecrown Citadel"] = "Icecrown Citadel",
    ["Northrend quakes as Icecrown Citadel topples to the glacier below, bringing a final end to Ner'zhul's fortress and prison of ice."] =
      "Rasganorte tiembla mientras la Ciudadela de Corona de Hielo se derrumba sobre el glaciar de abajo, poniendo fin definitivo a la fortaleza y prisión de hielo de Ner'zhul.",
    ["CAPITAL DAMAGED"] = "CAPITAL DAÑADA",
    ["The Frozen Throne, once thought to be an indomitable bastion of death, has been ruptured. Ner'zhul's consciousness recedes within, retreating desperately to protect what remains of Icecrown Citadel."] =
      "El Trono de Hielo, que se creía un bastión indomable de la muerte, ha sido fracturado. La conciencia de Ner'zhul se repliega en su interior, retrocediendo desesperadamente para proteger lo que queda de la Ciudadela de Corona de Hielo.",

    // Shared Objectives (ObjectiveFactionQuestNotComplete, ObjectiveQuestNotComplete)
    ["{faction} has not completed the quest {quest}"] = "{faction} no ha completado la misión {quest}",
    ["Do not complete the quest {quest}"] = "No completes la misión {quest}",

    // Sentinels faction
    ["Sentinels"] = "Centinelas",
    ["You are playing as the ever-watchful {faction}.\n\nThe Druids are slowly waking from their slumber, and it falls to you to drive back the Old Gods' invaders from Kalimdor until then.\n\nYour first mission is to race down the coast to Feathermoon Stronghold, a powerful Sentinel bastion on the southern half of the continent.\n\nOnce you have secured your holdings, gather your army and destroy the Old Gods. Be cautious—they will outnumber you if given time to establish a foothold in Azeroth."] =
      "Juegas como las siempre vigilantes {faction}.\n\nLos Druidas están despertando lentamente de su letargo, y te corresponde a ti repeler a los invasores de los Antiguos Dioses de Kalimdor hasta entonces.\n\nTu primera misión es correr por la costa hasta el Bastión de Feathermoon, un poderoso baluarte Centinela en la mitad sur del continente.\n\nUna vez que hayas asegurado tus dominios, reúne tu ejército y destruye a los Antiguos Dioses. Ten cuidado: te superarán en número si les das tiempo para establecer una posición en Azeroth.",

    // Sentinels - RegisterDialogue
    ["I suspected as much. These islands must have been formed only recently."] =
      "Lo sospechaba. Estas islas deben haberse formado hace poco.",
    ["What makes you say that?"] = "¿Qué te hace decir eso?",
    ["The ruins all around us, Naisha... I recognize them."] =
      "Las ruinas a nuestro alrededor, Naisha... las reconozco.",
    ["This was once the great city of Suramar, built before our civilization was blasted beneath the sea ten thousand years ago."] =
      "Esto fue alguna vez la gran ciudad de Suramar, construida antes de que nuestra civilización fuera hundida bajo el mar hace diez mil años.",
    ["Look, mistress--more of Gul'dan's glyphs."] = "Mira, ama... más glifos de Gul'dan.",
    ["Priestess Tyrande. I'm surprised you came in person. Are you here to absolve your guilty conscience?"] =
      "Sacerdotisa Tyrande. Me sorprende que hayas venido en persona. ¿Estás aquí para absolver tu conciencia culpable?",
    ["the Tomb of Sargeras"] = "la Tumba de Sargeras",

    // Sentinels - RegisterDruidsDialogue
    ["Elune be praised! I knew you would come, Shan'do Stormrage."] =
      "¡Alabada sea Elune! Sabía que vendrías, Shan'do Stormrage.",

    // Sentinels - RegisterLegionDialogue
    ["Archimonde... After ten thousand years, how is it possible?"] =
      "Archimonde... Después de diez mil años, ¿cómo es posible?",
    ["The Legion has returned to consume this world, woman. And this time, your troublesome race will not stop us."] =
      "La Legión ha regresado para consumir este mundo, mujer. Y esta vez, tu problemática raza no nos detendrá.",

    // Sentinels - Unspoiled Wilderness power
    ["Unspoiled Wilderness"] = "Naturaleza Virgen",
    ["Your Control Points increase your units' movement speed by 15% in a large radius."] =
      "Tus Puntos de Control aumentan la velocidad de movimiento de tus unidades en un 15% dentro de un gran radio.",

    // Sentinels - QuestAstranaar (file QuestAstraanar.cs)
    ["Daughters of the Moon"] = "Hijas de la Luna",
    ["Auberdin needs to be mobilized for war. Darkshore has already been attacked by wild creatures gone mad."] =
      "Auberdine necesita movilizarse para la guerra. Costa Oscura ya ha sido atacada por criaturas salvajes enloquecidas.",
    ["Control of all units in Astranaar Outpost and Auberdine and learn to train Tyrande and Naisha from the {altar}"] =
      "Control de todas las unidades en el Puesto Avanzado de Astranaar y Auberdine, y aprendes a entrenar a Tyrande y Naisha desde el {altar}",

    // Sentinels - QuestFeathermoon
    ["Shores of Feathermoon"] = "Costas de Feathermoon",
    ["Without aid from the primary Sentinel force, Feathermoon Stronghold will undoubtedly fall to the assault of the Old Gods. We will need to restore it."] =
      "Sin la ayuda de la fuerza Centinela principal, el Bastión de Feathermoon caerá sin duda ante el asalto de los Antiguos Dioses. Necesitaremos restaurarlo.",
    ["The Sentinels have rebuilt Feathermoon Stronghold to its former glory. Maiev Shadowsong now joins their efforts."] =
      "Las Centinelas han reconstruido el Bastión de Feathermoon a su antigua gloria. Maiev Shadowsong ahora se une a sus esfuerzos.",
    ["in Feathermoon"] = "en Feathermoon",
    ["Learn to train Maiev Shadowsong from the {altar} and gain control of the survivors hiding in Feathermoon."] =
      "Aprendes a entrenar a Maiev Shadowsong desde el {altar}, y obtienes control de los sobrevivientes escondidos en Feathermoon.",

    // Sentinels - QuestMaievOutland
    ["Driven by Vengeance"] = "Impulsada por la Venganza",
    ["Maiev drive for vengeance leads her to chase Illidan all the way to other worlds."] =
      "El impulso de venganza de Maiev la lleva a perseguir a Illidan hasta otros mundos.",
    ["Control of Maiev's Outland outpost and moves Maiev to Outland"] =
      "Control del puesto avanzado de Maiev en Terrallende y traslada a Maiev a Terrallende",
    ["Maiev's Outland outpost have been constructed."] =
      "El puesto avanzado de Maiev en Terrallende ha sido construido.",

    // Sentinels - QuestScepterOfTheQueenSentinels
    ["Return to the Fold"] = "Regreso al Redil",
    ["Remnants of the ancient Highborne survive within the ruins of the Athenaeum. If Stonemaul falls, it would be safe for them to come out."] =
      "Vestigios de los antiguos Altos Nacidos sobreviven entre las ruinas del Athenaeum. Si Quebrantarrocas cae, sería seguro para ellos salir.",
    ["The Shen'dralar, the Highborne survivors of the Sundering, swear allegiance to their fellow Night Elves. As a sign of their loyalty, they offer up an artifact they have guarded for thousands of years: the Scepter of the Queen."] =
      "Los Shen'dralar, los sobrevivientes Altos Nacidos del Hundimiento, juran lealtad a sus congéneres Elfos Nocturnos. Como muestra de su lealtad, ofrecen un artefacto que han custodiado durante miles de años: el Cetro de la Reina.",
    ["outside the Athenaeum"] = "fuera del Athenaeum",
    ["the Athenaeum"] = "el Athenaeum",
    ["Gain the Scepter of the Queen, the Athenaeum, 4 {highborne}, and the ability to train {highborne} from the {temple}"] =
      "Obtienes el Cetro de la Reina, el Athenaeum, 4 {highborne}, y la habilidad de entrenar {highborne} desde el {temple}",

    // Sentinels - QuestVaultoftheWardens
    ["Vault of the Wardens"] = "Vault of the Wardens",
    ["In millenia past, the most vile entities of Azeroth were imprisoned in a facility near Zin-Ashari, but it was abandoned when the Broken Isles were shattered. In troubling times such as these, the Wardens could make great use of such a facility."] =
      "Hace milenios, las entidades más viles de Azeroth fueron encarceladas en unas instalaciones cerca de Zin-Ashari, pero fueron abandonadas cuando las Islas Quebradas se hicieron pedazos. En tiempos tan turbulentos como estos, los Guardianes podrían sacar gran provecho de esas instalaciones.",
    ["The ancient Vault of the Wardens has been secured. Maiev and her Wardens take up residence within its ancient halls."] =
      "La antigua Bóveda de los Guardianes ha sido asegurada. Maiev y sus Guardianes se establecen en sus antiguos salones.",
    ["4 free {warden}s appear at the Broken Isles, and you learn to train {warden}s from the {vault} and from {bastion}s"] =
      "Aparecen 4 {warden} gratis en las Islas Quebradas, y aprendes a entrenar {warden} desde el {vault} y desde {bastion}",
    ["You can now train Wardens from the {vault} and from {bastion}s."] =
      "Ahora puedes entrenar Wardens desde el {vault} y desde {bastion}.",

    // Shared/Quests/QuestBookOfMedivh
    ["Book of Medivh"] = "Libro de Medivh",
    ["The last remaining spellbook written by Medivh, the Last Guardian, is held securely within {location}. The spells within its pages could bring us great power."] =
      "El último grimorio restante escrito por Medivh, el Último Guardián, se resguarda con seguridad dentro de {location}. Los hechizos en sus páginas podrían darnos un gran poder.",
    ["the Book of Medivh's pedestal at {location}"] = "el pedestal del Libro de Medivh en {location}",
    ["No other player has acquired {item}"] = "Ningún otro jugador ha obtenido {item}",
    ["The Book of Medivh, which can be used to summon the full might of the Burning Legion"] =
      "El Libro de Medivh, que puede usarse para invocar todo el poderío de la Legión Ardiente",
    ["The Book of Medivh"] = "El Libro de Medivh",
    ["Gilneas"] = "Gilneas",

    // Shared/Quests/QuestExtractSunwellVial
    ["Eternity, Distilled"] = "Eternidad, Destilada",
    ["The High Elves of Quel'thalas have in their possession a well of immense arcane energy. A mere vial of it would be of extraordinary value, if only we could get our hands on one."] =
      "Los Altos Elfos de Quel'thalas poseen un pozo de inmensa energía arcana. Un simple vial de ella sería de un valor extraordinario, si tan solo pudiéramos conseguir uno.",
    ["A Vial of the Sunwell appears on the ground, and the Sunwell permanently loses 500 maximum mana"] =
      "Aparece un Vial del Pozo del Sol en el suelo, y el Pozo del Sol pierde permanentemente 500 de maná máximo",
    ["We have extracted a single vial of the Sunwell's energies. Though the well remains functional, its vibrancy has been visibly diminished by our theft."] =
      "Hemos extraído un único vial de las energías del Pozo del Sol. Aunque el pozo sigue siendo funcional, su vitalidad se ha visto visiblemente disminuida por nuestro robo.",

    // Stormwind faction
    ["Kingdom of Stormwind"] = "Reino de Ventormenta",
    ["You are playing as the steadfast {faction}.\n\nYou begin in Westfall, separated from the rest of the kingdom. Reunite your lands by liberating Darkshire, Lakeshire, and finally Stormwind City.\n\nOnce you have unified Stormwind's forces, race east to the Nethergarde Stronghold and prepare for the invasion of the Fel Horde.\n\nMake sure to communicate with your Dwarven and Kul Tiran allies, as they will be key to defeating the evil that lurks beyond the Dark Portal."] =
      "Juegas como el firme {faction}.\n\nComienzas en Poniente, separado del resto del reino. Reúne tus tierras liberando Villa Oscura, Villa del Lago, y finalmente la Ciudad de Ventormenta.\n\nUna vez que hayas unificado las fuerzas de Ventormenta, corre hacia el este hasta el Bastión de Nethergarde y prepárate para la invasión de la Horda Fel.\n\nAsegúrate de comunicarte con tus aliados Enanos y de Kul Tiras, ya que serán clave para derrotar al mal que acecha más allá del Portal Oscuro.",

    // Stormwind - StormwindLegends
    ["The King of Stormwind dies a warrior’s death, defending hearth and family. The Wrynn Dynasty crumbles with his passing."] =
      "El Rey de Ventormenta muere una muerte de guerrero, defendiendo hogar y familia. La Dinastía Wrynn se desmorona con su partida.",
    ["Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!"] =
      "¡La Fortaleza de Ventormenta, la capital de la nación de Ventormenta, ha sido destruida!",

    // Stormwind - CityOfHeroes power (QuestStormwindCity)
    ["City of Heroes"] = "Ciudad de Héroes",
    ["Units"] = "Unidades",

    // Stormwind - QuestStormwindCity
    ["Clear the Outskirts"] = "Limpia las Afueras",
    ["The outskirts of Stormwind are infested by rebels and foul creatures. Defeat them to regain control of your lands."] =
      "Las afueras de Ventormenta están infestadas de rebeldes y criaturas repugnantes. Derrótalos para recuperar el control de tus tierras.",
    ["Gain control of all units in Stormwind, learn to train Varian from the {altar}, learn to cast {summonGarrison} from {keep}s and {castle}s, and acquire the {power} Power"] =
      "Obtienes control de todas las unidades en Ventormenta, aprendes a entrenar a Varian desde el {altar}, aprendes a lanzar {summonGarrison} desde los {keep} y los {castle}, y adquieres el Poder {power}",

    // Stormwind - QuestClosePortal
    ["Seal the Dark Portal"] = "Sella el Portal Oscuro",
    ["The Dark Portal has been a menace to the Kingdom of Stormwind for decades, it is time to end the menace once and for all."] =
      "El Portal Oscuro ha sido una amenaza para el Reino de Ventormenta durante décadas, es hora de acabar con la amenaza de una vez por todas.",
    ["Khadgar has sealed the Dark Portal forever, finally correcting the mistake made by his former master decades ago."] =
      "Khadgar ha sellado el Portal Oscuro para siempre, corrigiendo finalmente el error cometido por su antiguo maestro hace décadas.",
    ["The Dark Portal closes permanently and Khadgar gains 10000 experience"] =
      "El Portal Oscuro se cierra permanentemente y Khadgar gana 10000 de experiencia",
    ["the Dark Portal"] = "el Portal Oscuro",

    // Stormwind - QuestConstructionSites
    ["Inevitable Progress"] = "Progreso Inevitable",
    ["Stormwind has not yet fully recovered from the ravaging it experienced during the Second War. Await reconstruction."] =
      "Ventormenta aún no se ha recuperado por completo de la devastación que sufrió durante la Segunda Guerra. Espera la reconstrucción.",
    ["Stormwind's Construction Sites are now ready to be upgraded."] =
      "Los Sitios de Construcción de Ventormenta ya están listos para mejorarse.",
    ["Your Construction Sites can be upgraded"] = "Tus Sitios de Construcción pueden mejorarse",

    // Stormwind - QuestDarkshire
    ["Gnoll Troubles"] = "Problemas de Gnolls",
    ["The town of Darkshire is under attack by Gnoll's, clear them out!"] =
      "La ciudad de Villa Oscura está siendo atacada por Gnolls, ¡elimínalos!",
    ["Control of all units in Darkshire"] = "Control de todas las unidades en Villa Oscura",
    ["Duskwood"] = "Duskwood",

    // Stormwind - QuestGoldshire
    ["The Scourge of Elwynn"] = "El Flagelo de Elwynn",
    ["Hogger and his pack have taken over Goldshire, clear them out!"] =
      "Hogger y su manada se han apoderado de Villadorada, ¡elimínalos!",
    ["The Gnolls have been defeated, Goldshire is safe."] = "Los Gnolls han sido derrotados, Villadorada está a salvo.",
    ["Control of all units in Goldshire"] = "Control de todas las unidades en Villadorada",
    ["Elwynn Forest"] = "Elwynn Forest",

    // Stormwind - QuestHonorHold
    ["Honor Hold"] = "Bastión del Honor",
    ["Despite Outland's incredibly harsh climate, some Alliance forces have managed to make a home there - a town called Honor Hold"] =
      "A pesar del clima increíblemente duro de Terrallende, algunas fuerzas de la Alianza han logrado hacer un hogar allí: una ciudad llamada Bastión del Honor",
    ["Honor Hold is now free from the constant looming threat of Hellfire Citadel, and have finally been reconnected with their Alliance from Azeroth."] =
      "Bastión del Honor ahora está libre de la constante amenaza latente de la Ciudadela del Fuego Infernal, y finalmente se ha reconectado con su Alianza de Azeroth.",
    ["Hellfire Citadel"] = "Hellfire Citadel",
    ["Control of all units at Honor Hold and {siegeTower} gain the {ability} ability."] =
      "Control de todas las unidades en Bastión del Honor y las {siegeTower} obtienen la habilidad {ability}.",

    // Stormwind - QuestKhadgar
    ["Keeper of the Eternal Watch"] = "Guardián de la Vigilia Eterna",
    ["At the end of the Second War, Khadgar remained in Draenor to seal the Dark Portal, effectively ending the conflict. He has been stranded deep in Outland ever since."] =
      "Al final de la Segunda Guerra, Khadgar permaneció en Draenor para sellar el Portal Oscuro, terminando efectivamente el conflicto. Desde entonces ha quedado varado en las profundidades de Terrallende.",
    ["Khadgar has been freed from his confines under the Black Temple, and he is now free to serve the Kingdom of Stormwind."] =
      "Khadgar ha sido liberado de su confinamiento bajo el Templo Negro, y ahora es libre de servir al Reino de Ventormenta.",
    ["You can summon Khadgar from the Altar of Kings"] = "Puedes invocar a Khadgar desde el Altar de los Reyes",

    // Stormwind - QuestKingdomOfManStormwind
    ["The people of the Eastern Kingdoms have been united under the banner of Lordaeron. Long live High King Varian Wrynn!"] =
      "El pueblo de los Reinos del Este ha sido unido bajo el estandarte de Lordaeron. ¡Larga vida al Alto Rey Varian Wrynn!",
    ["You gain a research improving all of your units, the Crowns of Lordaeron and Stormwind are merged, and Varian gains 10 Strength and 10 Agility"] =
      "Obtienes una investigación que mejora a todas tus unidades, las Coronas de Lordaeron y Ventormenta se fusionan, y Varian gana 10 de Fuerza y 10 de Agilidad",
    ["Crown of Lordaeron"] = "Crown of Lordaeron",
    ["Crown of Stormwind"] = "Crown of Stormwind",
    ["Stormwind City"] = "Stormwind City",

    // Stormwind - QuestLakeshire
    ["Marauding Ogres"] = "Ogros Merodeadores",
    ["The town of Lakeshire is invaded by Ogres, wipe them out!"] =
      "La ciudad de Villa del Lago está siendo invadida por Ogros, ¡acábalos!",
    ["Control of all units in Lakeshire"] = "Control de todas las unidades en Villa del Lago",
    ["Redridge Mountains"] = "Redridge Mountains",

    // Stormwind - QuestNethergarde
    ["Nethergarde Relief"] = "Socorro a Nethergarde",
    ["Nethergarde Keep fort is holding down the Dark Portal, they will need to be reinforced soon!"] =
      "El fuerte de Nethergarde mantiene contenido al Portal Oscuro, ¡pronto necesitarán refuerzos!",
    ["Varian has come to relieve the Nethergarde garrison."] = "Varian ha venido a relevar a la guarnición de Nethergarde.",
    ["You gain control of Nethergarde"] = "Obtienes control de Nethergarde",

    // Stormwind - QuestStromgarde
    ["Although Stromgarde's strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind."] =
      "Aunque la fuerza de Stromgarde ha mermado desde los días del Imperio Arathoriano, sigue siendo un bastión importante de la humanidad. Podrían ser convencidos de movilizar sus fuerzas para Ventormenta.",
    ["Galen Trollbane has pledged his forces to Stormwind's cause."] =
      "Galen Trollbane ha comprometido sus fuerzas a la causa de Ventormenta.",
    ["Control of all units at Stromgarde, the artifact Trol'kalar, and you can summon the hero Galen Trollbane from the Altar of Kings"] =
      "Control de todas las unidades en Stromgarde, el artefacto Trol'kalar, y puedes invocar al héroe Galen Trollbane desde el Altar de los Reyes",

    ["Taming the Maelstrom"] = "Domando el Maelström",

    // Sunfury faction
    ["Sunfury"] = "Furia del Sol",
    ["You are playing as the power-hungry {faction}.\n\nYou begin in Netherstorm. Your first mission is to build three biodomes in the green areas protected by a bubble.\n\nUnite with your fel ally to push through the Dark Portal and destroy Stormwind.\n\nYour ultimate goal is to summon Kil'jaeden and annihilate your enemies."] =
      "Juegas como los sedientos de poder {faction}.\n\nComienzas en Netherstorm. Tu primera misión es construir tres biodomos en las zonas verdes protegidas por una burbuja.\n\nÚnete a tu aliado fel para abrirte paso a través del Portal Oscuro y destruir Ventormenta.\n\nTu objetivo final es invocar a Kil'jaeden y aniquilar a tus enemigos.",

    // Sunfury - SunfuryLegends
    ["The destruction of the original Well of Eternity tore apart the Azerothean supercontinent. The rupturing of its second successor reaches no such heights, but its absence is felt by Elves and arcanists the world over."] =
      "La destrucción del Pozo de la Eternidad original desgarró el supercontinente Azerothiano. La ruptura de su segundo sucesor no alcanza tales alturas, pero su ausencia se siente entre Elfos y arcanistas de todo el mundo.",
    ["Kil'jaeden the Deceiver has been annihilated, but it is too late for the Sunfury, who will continue to live and die with demonic taint coursing through their veins."] =
      "Kil'jaeden el Engañador ha sido aniquilado, pero ya es tarde para la Furia del Sol, que seguirá viviendo y muriendo con la corrupción demoníaca corriendo por sus venas.",

    // Sunfury - QuestArea52
    ["The goblins of Area 52 have lived in Netherstorm long before our arrival. In other circumstances, they may have been potential allies - but desperate times call for desperate conquests."] =
      "Los goblins del Área 52 han vivido en Netherstorm mucho antes de nuestra llegada. En otras circunstancias, podrían haber sido aliados potenciales, pero tiempos desesperados requieren conquistas desesperadas.",
    ["The goblins of Area 52 once aspired to travel amongst the stars. Now they aspire to nothing, buried one layer of dirt beneath our new settlement."] =
      "Los goblins del Área 52 alguna vez aspiraron a viajar entre las estrellas. Ahora no aspiran a nada, enterrados bajo una capa de tierra debajo de nuestro nuevo asentamiento.",
    ["Gain 250 gold and a base in Area 52"] = "Obtienes 250 de oro y una base en el Área 52",

    // Sunfury - QuestSolarian
    ["The High Astromancer"] = "La Gran Astrómanta",
    ["High Astromancer Solarion has long had a fascination with the void, much to the chagrin of her colleagues. With the right research materials in hand, she could become a force to be reckoned with."] =
      "La Gran Astrómanta Solarion ha sentido durante mucho tiempo una fascinación por el vacío, para disgusto de sus colegas. Con los materiales de investigación adecuados en mano, podría convertirse en una fuerza a tener en cuenta.",
    ["Extensive study of Murmur's essence has granted Solarion the power to channel void energies."] =
      "El extenso estudio de la esencia de Murmur ha otorgado a Solarion el poder de canalizar energías del vacío.",
    ["Learn to train High Astromancer Solarion from the {altar}"] =
      "Aprendes a entrenar a la Gran Astrómanta Solarion desde el {altar}",

    // Sunfury - QuestSummonKil
    ["The Deceiver"] = "El Engañador",
    ["Our hidden master, Kil'jaeden, calls to us from the depths of the Twisting Nether. The bounty of fel energy residing within Karazhan could be used to bring him forth - but not while the Kingdom of Stormwind is still strong enough to interfere."] =
      "Nuestro amo oculto, Kil'jaeden, nos llama desde las profundidades del Vacío Abisal. La abundante energía fel que reside dentro de Karazhan podría usarse para traerlo, pero no mientras el Reino de Ventormenta sea todavía lo bastante fuerte para interferir.",
    ["Kael'thas' profane ritual has paved the way for Kil'jaeden, supreme commander of the Burning Legion, to bridge the gap from the Twisting Nether to our world. Our people embrace fel magic wholeheartedly, training in preparation for their coming lord."] =
      "El ritual profano de Kael'thas ha abierto el camino para que Kil'jaeden, comandante supremo de la Legión Ardiente, tienda un puente desde el Vacío Abisal hasta nuestro mundo. Nuestro pueblo abraza la magia fel de todo corazón, entrenando en preparación para la llegada de su señor.",
    ["Summoning Kil'jaeden"] = "Invocando a Kil'jaeden",
    ["Learn to train Kil'jaeden from the {altar}, and {warlock}s from the {lyceum}"] =
      "Aprendes a entrenar a Kil'jaeden desde el {altar}, y {warlock} desde el {lyceum}",

    // Sunfury - QuestTempestKeep
    ["Eco-domes"] = "Biodomos",
    ["The Sunfury must learn to adapt to their new home within the inhospitable Netherstorm. There are several eco-domes dotted throughout the region, remnants of Netherstorm's prior existence as the verdant Farahlon. They would make excellent locations for growth facilities."] =
      "La Furia del Sol debe aprender a adaptarse a su nuevo hogar dentro del inhóspito Netherstorm. Hay varios biodomos repartidos por la región, remanentes de la existencia anterior de Netherstorm como el verdeante Farahlon. Serían excelentes ubicaciones para instalaciones de cultivo.",
    ["With food production now secured, we can settle Tempest Keep and start growing Ancients of the Arcane."] =
      "Con la producción de alimentos ahora asegurada, podemos asentarnos en la Fortaleza Tempestuosa y comenzar a cultivar Ancestrales de lo Arcano.",
    ["Gain control of Tempest Keep, and learn to build {ancientPool}s and {artificerCourt}s"] =
      "Obtienes control de la Fortaleza Tempestuosa, y aprendes a construir {ancientPool} y {artificerCourt}",
    ["in one of the 3 Eco-dome in Netherstorm"] = "en uno de los 3 Biodomos de Netherstorm",

    // Sunfury - QuestUpperNetherstorm
    ["Upper Netherstorm"] = "Netherstorm Superior",
    ["Upper Netherstorm is continously wracked by devastating magical storms. Lands such as these represent opportunity for our people, as starved for mana as they are."] =
      "Netherstorm Superior es azotado continuamente por devastadoras tormentas mágicas. Tierras como estas representan una oportunidad para nuestro pueblo, hambriento de maná como está.",
    ["Our people spread throughout the lands of Upper Netherstorm, erecting their homes amidst its arcane crystals and basking in its magical storms."] =
      "Nuestro pueblo se extiende por las tierras de Netherstorm Superior, erigiendo sus hogares entre sus cristales arcanos y disfrutando de sus tormentas mágicas.",
    ["Gain 200 gold and a base in Upper Netherstorm"] = "Obtienes 200 de oro y una base en Netherstorm Superior",
    ["in upper Netherstorm"] = "en el Netherstorm superior",

    // Sunfury - QuestWellOfEternity
    ["The Well of Eternity"] = "The Well of Eternity",
    ["The Maelstrom still hides the shattered Well of Eternity. With his immense power, Kil'jaeden can summon a new well that will bring forth the destruction of the world."] =
      "El Maelström todavía oculta el destrozado Pozo de la Eternidad. Con su inmenso poder, Kil'jaeden puede invocar un nuevo pozo que traerá la destrucción del mundo.",
    ["Kil'jaeden has reformed the ancient Well of Eternity. From its wellsprings, unlimited arcane energies spring forth. For the first time in their miserable existences, the Sunfury are truly sated."] =
      "Kil'jaeden ha reformado el antiguo Pozo de la Eternidad. De sus manantiales brotan energías arcanas ilimitadas. Por primera vez en sus miserables existencias, la Furia del Sol está verdaderamente saciada.",
    ["Gain control of the Well of Eternity, which will grant every Sunfury unit unlimited mana"] =
      "Obtienes control del Pozo de la Eternidad, que otorgará a cada unidad de la Furia del Sol maná ilimitado",
    ["The Maelstrom"] = "El Maelström",

    // Warsong faction
    ["Warsong Clan"] = "Clan Grito de Guerra",
    ["You are playing as the fierce and relentless {faction}.\n\nBegin swiftly by rescuing your Chieftain, Grom Hellscream, who is trapped in battle and consumed by demonic fury. His survival is paramount.\n\nWith Grom secured, expand your dominance by subduing or pillaging nearby races to bolster your clan's strength.\n\nWork closely with your new elven allies—only together can you overcome the looming threat of the Old Gods."] =
      "Juegas como el feroz e implacable {faction}.\n\nComienza rápidamente rescatando a tu Cacique, Grom Hellscream, quien está atrapado en batalla y consumido por la furia demoníaca. Su supervivencia es primordial.\n\nCon Grom a salvo, expande tu dominio sometiendo o saqueando a las razas cercanas para fortalecer a tu clan.\n\nTrabaja de cerca con tus nuevos aliados elfos: solo juntos pueden superar la inminente amenaza de los Antiguos Dioses.",

    // Warsong - RegisterDialogue
    ["Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!"] =
      "¡Sí! ¡Siento el poder una vez más! ¡Vengan, mis guerreros; beban de las aguas oscuras, y renacerán!",
    ["Thrall... I see clearly now.  I'm... sorry.  I am so sorry.."] =
      "Thrall... ahora veo claramente. Yo... lo siento. Lo siento mucho...",

    // Warsong - WarsongLegends
    ["Mannoroth the Corrupter has fallen."] = "Mannoroth el Corruptor ha caído.",
    ["The fortress of the Stonemaul Clan has fallen."] = "La fortaleza del Clan Quebrantarrocas ha caído.",
    ["Orgrimmar has been demolished and with it die the hopes and dreams of a wartorn race seeking refuge in a new world."] =
      "Orgrimmar ha sido demolida, y con ella mueren las esperanzas y sueños de una raza devastada por la guerra que busca refugio en un nuevo mundo.",

    // Warsong - Mechanics/WarsongPillageDialogPresenter
    ["Choose their fate"] = "Elige su destino",

    // Warsong - QuestBloodpact
    ["The Bloodpact"] = "El Pacto de Sangre",
    ["The Warsong is still vulnerable to the tentation of Mannoroth's Blood. If they drink it from the Fountain, they would have a surge of power. Although, Thrall would certainly hurry to save his friend Grom from the corruption."] =
      "El Warsong todavía es vulnerable a la tentación de la Sangre de Mannoroth. Si beben de ella en la Fuente, tendrían un torrente de poder. Sin embargo, Thrall seguramente se apresuraría a salvar a su amigo Grom de la corrupción.",
    ["The Warsong has drunk the blood of Mannoroth. It will take Thrall 4 minutes to save Grom and purify the Warsong Clan orcs."] =
      "El Warsong ha bebido la sangre de Mannoroth. A Thrall le tomará 4 minutos salvar a Grom y purificar a los orcos del Clan Grito de Guerra.",
    ["You will gain Mannoroth as a temporary unit, all your orcs except your Kor'kron Elites will gain 200 hit points and chaos damage. After 4 min, your units will revert to normal and Mannoroth will become hostile."] =
      "Obtienes a Mannoroth como unidad temporal, todos tus orcos excepto tus Élites Kor'kron ganan 200 puntos de vida y daño de caos. Después de 4 min, tus unidades volverán a la normalidad y Mannoroth se volverá hostil.",

    // Warsong - QuestFountainOfBlood
    ["The Blood of Mannoroth"] = "La Sangre de Mannoroth",
    ["Long ago, the orcs drank the blood of Mannoroth and were infused with demonic fury. A mere taste of his blood would reignite those powers."] =
      "Hace mucho tiempo, los orcos bebieron la sangre de Mannoroth y se infundieron de furia demoníaca. Un simple sorbo de su sangre reavivaría esos poderes.",
    ["The Fountain of Blood is under Warsong control. As the orcs drink from it, they feel a a familiar fury awake within them."] =
      "La Fuente de Sangre está bajo control Warsong. Al beber de ella, los orcos sienten despertar una furia familiar dentro de sí.",
    ["Allows Orcish units to increase their attack rate and movement speed temporarily. Blood Brothers is now available to Grunts"] =
      "Permite a las unidades Orcas aumentar temporalmente su velocidad de ataque y de movimiento. Hermanos de Sangre ahora está disponible para los Grunts",
    ["The Fountain of Blood"] = "The Fountain of Blood",

    // Warsong - QuestOrgrimmar (Title/Flavour reused verbatim from Frostwolf's QuestOrgrimmarFrostwolf)
    ["The city of Orgrimmar was finally constructed by the Warsong engineers, it is now a home for the new Horde and a symbol of power and innovation. The Warchief has rewarded us generously for our work!"] =
      "La ciudad de Orgrimmar fue finalmente construida por los ingenieros Warsong, ahora es un hogar para la nueva Horda y un símbolo de poder e innovación. ¡El Jefe de Guerra nos ha recompensado generosamente por nuestro trabajo!",
    ["Control of all units in Orgrimmar and can now train Varok and Azerite Siege Engines"] =
      "Control de todas las unidades en Orgrimmar y ahora puedes entrenar a Varok y Motores de Asedio de Azerita",

    // Warsong - QuestRokhan
    ["The Darkspear Champion"] = "El Campeón Lanza Negra",
    ["Rumours tell of a Darkspear Champion in the area. Perhaps it could be convinced to join the Horde."] =
      "Rumores hablan de un Campeón Lanza Negra en la zona. Quizás podría ser convencido de unirse a la Horda.",
    ["The hero Rohkan is now trainable at the Altar"] = "El héroe Rohkan ahora es entrenable en el Altar",

    // Warsong - QuestSubdueOgres
    ["Brute Allegiance"] = "Lealtad Brutal",
    ["Their brute strength is untamed, their loyalty unproven. Subdue the ogres and further strengthen the Horde."] =
      "Su fuerza bruta es indómita, su lealtad no probada. Somete a los ogros y fortalece aún más a la Horda.",
    ["The fate of the ogres has been decided, and the Horde's power grows."] =
      "El destino de los ogros ha sido decidido, y el poder de la Horda crece.",
    ["Subdue the Ogres"] = "Someter a los Ogros",
    ["Pillage Stonemaul"] = "Saquear Quebrantarrocas",
    ["Gain control of Stonemaul, {removeUnit}s' are upgraded to {addUnit}s' and unlock the ability to train {ogreMagi}s. Alternatively, earn {gold} gold and up to {experience} experience points, shared among all your heroes—the fewer heroes you control, the less experience each receives. Additionally, enhance both {blademaster}s' and {korkronElite}s' attack damage by 10, movement speed by 20 and hit points by 250."] =
      "Obtienes control de Quebrantarrocas: los {removeUnit} se mejoran a {addUnit}, y desbloqueas la habilidad de entrenar {ogreMagi}. Alternativamente, gana {gold} de oro y hasta {experience} puntos de experiencia, repartidos entre todos tus héroes —mientras menos héroes controles, menos experiencia recibe cada uno—. Además, mejora el daño de ataque de los {blademaster} y {korkronElite} en 10, la velocidad de movimiento en 20, y los puntos de vida en 250.",

    // Warsong - QuestSubdueTauren
    ["Unyielding Bonds"] = "Lazos Inquebrantables",
    ["The Tauren of Thunder Bluff are noble warriors, but their allegiances are uncertain. Bring them into the fold or pillage their lands."] =
      "Los Tauren de Cima del Trueno son guerreros nobles, pero sus lealtades son inciertas. Tráelos al redil o saquea sus tierras.",
    ["Subdue the Tauren"] = "Someter a los Tauren",
    ["Pillage Thunder Bluff"] = "Saquear Cima del Trueno",
    ["Control of Thunder Bluff and the ability to train {kodo}s' from {beastiary} or gain the artifact {totem}, {gold} gold and {experience} experience points, shared across all your heroes—the fewer heroes you control, the less experience each receives."] =
      "Control de Cima del Trueno y la habilidad de entrenar {kodo} desde {beastiary}, o consigue el artefacto {totem}, {gold} de oro y {experience} puntos de experiencia, repartidos entre todos tus héroes —mientras menos héroes controles, menos experiencia recibe cada uno—.",

    // Warsong - QuestSubdueTrolls
    ["To Break or Bind"] = "Quebrar o Atar",
    ["The Darkspear Trolls, fierce and cunning warriors, dwell in Echo Isles. It is time we forced their hand."] =
      "Los Trolls Lanza Negra, guerreros feroces y astutos, habitan en las Islas del Eco. Es hora de forzar su mano.",
    ["The Darkspear Trolls have been brought to heel."] = "Los Trolls Lanza Negra han sido sometidos.",
    ["Subdue the Trolls"] = "Someter a los Trolls",
    ["Pillage Echo Isles"] = "Saquear las Islas del Eco",
    ["Gain control of Echo Isles, {removeUnit}s are upgraded to {addUnit}s and learn to train {shadowpriest}s. Alternatively, earn {gold} gold and up to {experience} experience points, shared among all your heroes—the fewer heroes you control, the less experience each receives. Additionally, enhance both {blademaster}s' and {korkronElite}s' maximum mana by 250 and mana regeneration by 50%."] =
      "Obtienes control de las Islas del Eco: los {removeUnit} se mejoran a {addUnit}, y aprendes a entrenar {shadowpriest}. Alternativamente, ganas {gold} de oro y hasta {experience} puntos de experiencia, repartidos entre todos tus héroes —mientras menos héroes controles, menos experiencia recibe cada uno—. Además, mejora el maná máximo de los {blademaster} y {korkronElite} en 250 y la regeneración de maná en 50%.",

    // Warsong - QuestWarsongHold
    ["Warsong Hold"] = "Fortaleza Grito de Guerra",
    ["Northrend Expedition"] = "Northrend Expedition",
    ["The far-off land of Northrend is the new home of the traitor shaman Ner'zhul. The Warsong must land its forces on its shores in order to end the existential threat he now represents."] =
      "La lejana tierra de Rasganorte es el nuevo hogar del chamán traidor Ner'zhul. El Warsong debe desembarcar sus fuerzas en sus costas para poner fin a la amenaza existencial que ahora representa.",
    ["The Warsong Clan has set sail for the icy shores of Northrend and set up a formidable encampment at Borean Tundra."] =
      "El Clan Grito de Guerra ha zarpado hacia las heladas costas de Rasganorte y ha establecido un campamento formidable en la Tundra Boreal.",
    ["A new base at Borean Tundra in Northrend"] = "Una nueva base en la Tundra Boreal en Rasganorte",

    // QuestTombOfSargeras
    ["Tomb of Sargeras"] = "Tomb of Sargeras",
    ["When the Guardian Aegwynn defeated the fallen Titan Sargeras, she sealed his corpse within the temple that would come to be known as the Tomb of Sargeras. It lies still there, tempting those with the ambition to seize the power that remains within."] =
      "Cuando la Guardiana Aegwynn derrotó al Titán caído Sargeras, selló su cadáver dentro del templo que llegaría a conocerse como la Tumba de Sargeras. Aún yace allí, tentando a quienes tengan la ambición de apoderarse del poder que permanece en su interior.",
    ["the Tomb of Sargeras' entrance"] = "la entrada de la Tumba de Sargeras",
    ["The Tomb of Sargeras opens"] = "Se abre la Tumba de Sargeras",
    ["The Tomb of Sargeras has been opened by {unit}."] = "{unit} ha abierto la Tumba de Sargeras.",

    // QuestRagnaros
    ["Lord of the Firelands"] = "Señor de las Tierras de Fuego",
    ["Ragnaros hides within the Elemental Plane known as the Firelands. Outside Shadowforge City, the Dark Iron dwarves have been trying to summon him forth into Azeroth. Their efforts until now have proved ineffective, but we could succeed where they have not."] =
      "Ragnaros se oculta en el Plano Elemental conocido como las Tierras de Fuego. Fuera de la Ciudad Forjasombría, los enanos Hierro Negro han intentado invocarlo hacia Azeroth. Sus esfuerzos hasta ahora han resultado ineficaces, pero nosotros podríamos triunfar donde ellos han fallado.",
    ["the Portal to the Firelands"] = "el Portal a las Tierras de Fuego",
    ["Ragnaros is summoned near the Blackrock Depths, and can be slain to acquire Sulfuras"] =
      "Ragnaros es invocado cerca de las Profundidades de Roca Negra, y puede ser abatido para obtener Sulfuras",
    ["{unit} has seized control of the portal to the Firelands, and can now summon Ragnaros."] =
      "{unit} ha tomado el control del portal a las Tierras de Fuego, y ahora puede invocar a Ragnaros.",
    ["Ragnaros, the Elemental Lord of Fire, has been forcibly called forth into Azeroth. The air smolders with his arrival, and Blackrock Mountain erupts in raging infernos that can be seen for miles."] =
      "Ragnaros, el Señor Elemental del Fuego, ha sido invocado a la fuerza hacia Azeroth. El aire arde con su llegada, y la Montaña de Roca Negra estalla en infiernos furiosos que pueden verse a kilómetros de distancia.",

    // QuestYoggSaron
    ["The Beast With a Thousand Maws"] = "La Bestia de las Mil Fauces",
    ["Yogg-Saron rests dormant in Ulduar but his corruption seeps out from his prison. Once we are strong enough, we should open his prison and confront the Old God."] =
      "Yogg-Saron descansa dormido en Ulduar, pero su corrupción se filtra desde su prisión. Una vez que seamos lo bastante fuertes, deberíamos abrir su prisión y enfrentar al Antiguo Dios.",
    ["the Prison of Yogg-Saron"] = "la Prisión de Yogg-Saron",
    ["Gain the ability to release Yogg-Saron from his near Storm peaks; he can be slain to acquire Val'anyr, Hammer of Ancient Kings"] =
      "Obtén la capacidad de liberar a Yogg-Saron cerca de los Picos Tempestuosos; puede ser abatido para obtener Val'anyr, Martillo de los Reyes Antiguos",
    ["{unit} has seized control of the prison of Yogg-Saron, and can now free him."] =
      "{unit} ha tomado el control de la prisión de Yogg-Saron, y ahora puede liberarlo.",
    ["LOOK UPON YOGG-SARON, GOD OF DEATH, AND KNOW THAT YOUR END COMES SOON!"] =
      "¡CONTEMPLA A YOGG-SARON, DIOS DE LA MUERTE, Y SABE QUE TU FIN SE ACERCA!",

    // QuestDragonsOfNightmare
    ["Taerar and Ysondre"] = "Taerar y Ysondre",
    ["Once protectors of the Emerald Dream, the now corrupted dragons came to Azeroth to spread the corruption. Stop them before the corruption begins to spread."] =
      "Antes protectores del Sueño Esmeralda, los ahora corruptos dragones llegaron a Azeroth para propagar la corrupción. Detenlos antes de que la corrupción comience a extenderse.",
    ["NIGHTMARE DRAGONS SPAWNED"] = "DRAGONES DE LA PESADILLA APARECIDOS",
    ["{dragon1} and {dragon2} have appeared in {loc1} and {loc2}."] = "{dragon1} y {dragon2} han aparecido en {loc1} y {loc2}.",
    ["A portal between {loc1} and {loc2} opens"] = "Se abre un portal entre {loc1} y {loc2}",
    ["The Dragons of Nightmare {dragon1} and {dragon2} have been defeated."] =
      "Los Dragones de la Pesadilla {dragon1} y {dragon2} han sido derrotados.",

    // QuestZinrokhAssembly
    ["Destroyer of Worlds"] = "Destructor de Mundos",
    ["When Hakkar the Soulflayer was defeated long ago, Zin'rokh was shattered and spread throughout the Troll tribes. The legendary blade could be reforged if its pieces could be unified once more."] =
      "Cuando Hakkar el Devorador de Almas fue derrotado hace mucho tiempo, Zin'rokh se hizo pedazos y se esparció entre las tribus Trolls. La legendaria espada podría ser reforjada si sus fragmentos pudieran unificarse una vez más.",
    ["Reforge Zin'rokh, Destroyer of Worlds from its Shards"] = "Reforja Zin'rokh, Destructor de Mundos, a partir de sus Fragmentos",
    ["{unit} has assembled Zin'rokh, Destroyer of Worlds!"] = "{unit} ha ensamblado Zin'rokh, Destructor de Mundos!",
    ["{faction} has assembled Zin'rokh, Destroyer of Worlds. The only way we will acquire it now is if we take it from them."] =
      "{faction} ha ensamblado Zin'rokh, Destructor de Mundos. La única manera de conseguirlo ahora es si se lo quitamos.",

    // QuestSharedVision
    ["Battle for Azeroth"] = "Batalla por Azeroth",
    ["Beyond our local conflicts lies a larger war for the fate of Azeroth itself. It will reach us eventually, whether we wish it or not."] =
      "Más allá de nuestros conflictos locales yace una guerra mayor por el destino de Azeroth mismo. Tarde o temprano nos alcanzará, lo queramos o no.",
    ["Every player shares vision with their extended allies"] = "Todos los jugadores comparten visión con sus aliados extendidos",
    ["A global conflict for control of Azeroth is brewing. The great powers set their sights on distant shores as allies, new and old alike, seek to bolster their own."] =
      "Se está gestando un conflicto global por el control de Azeroth. Las grandes potencias ponen su mirada en costas distantes mientras aliados, nuevos y antiguos por igual, buscan fortalecer los suyos.",

    // ObjectiveKillUnit
    ["Destroy {target}"] = "Destruye a {target}",

    // Frostwolf
    ["Gain control of all units in Highmountain, and learn to train {unit}s from the {building}"] =
      "Obtienes control de todas las unidades en Monte Alto, y aprendes a entrenar la unidad {unit} desde {building}",
    ["Learn to train {unit}s from the {building}"] = "Aprendes a entrenar la unidad {unit} desde {building}",

    // Quel'thalas
    ["Eversong Woods"] = "Eversong Woods",
    ["Drak'Tharon Keep"] = "Drak'Tharon Keep",
    ["Altar of Prowess"] = "Altar of Prowess",
    ["Learn to train {unit}s from the {building}, and you can summon Magister Rommath & Lor'themar Theron from the {altar}"] =
      "Aprendes a entrenar la unidad {unit} desde {building}, y puedes invocar a Magíster Rommath y Lor'themar Theron desde el {altar}",

    // Scourge
    ["Icecrown Glacier"] = "Icecrown Glacier",
    ["Stratholme Castle"] = "Stratholme Castle",
    ["Frozen Throne"] = "Frozen Throne",
    ["{caster} has cast {spell} on {target}"] = "{caster} ha lanzado {spell} sobre {target}",
    ["Gain control of all buildings in Drak'tharon Keep and learn to train {hero} from the {altar}"] =
      "Obtienes control de todos los edificios en el Fuerte Drak'tharon y aprendes a entrenar a {hero} desde el {altar}",
    ["Learn to train {unit}s from the {building}. If your team killed Sapphiron, gain him in an undead form; otherwise, learn to train him from the {altar}"] =
      "Aprendes a entrenar la unidad {unit} desde {building}. Si tu equipo mató a Sapphiron, lo obtienes en su forma no-muerta; de lo contrario, aprendes a entrenarlo desde el {altar}",
    ["Gain vision over Lordaeron until you unleash the Plague, the Plague of Undeath research becomes available in the {building}, and {hero} becomes trainable at the {altar}"] =
      "Obtienes visión sobre Lordaeron hasta que desates la Plaga, la investigación Plaga de la No-Muerte estará disponible en el {building}, y {hero} se vuelve entrenable en el {altar}",
    ["Arthas abandons Lordaeron to join the Scourge; learn to train {hero} from the {altar}"] =
      "Arthas abandona Lordaeron para unirse a la Plaga; aprendes a entrenar a {hero} desde el {altar}",
    ["Enemy {descriptor} unit has entered {rect}"] = "Una unidad {descriptor} enemiga ha entrado a {rect}",
    ["non-boat"] = "no naval",
    ["Northrend"] = "Rasganorte",

    // Ironforge
    ["Gryphon Superior Breed"] = "Gryphon Superior Breed",
    ["Gain control of {place}, learn to train Falstad Wildhammer from the {altar}, and gain the ability to research {upgrade} at the {building}"] =
      "Obtienes control de {place}, aprendes a entrenar a Falstad Wildhammer desde el {altar}, y obtienes la habilidad de investigar {upgrade} en el {building}",

    // Fel Horde
    ["Blood Runes"] = "Blood Runes",
    ["Learn to train {count} {unit}s from the {building} and acquire Felsteel Plating"] =
      "Aprendes a entrenar {count} {unit} desde el {building} y adquieres las Placas de Acero Fel",
    ["Teron Gorefiend can be trained at the altar and learn to train {count} {unit}s from the {building}"] =
      "Teron Gorefiend puede ser entrenado en el altar, y aprendes a entrenar {count} {unit} desde el {building}",
    ["Learn to research {upgrade} from the {building}"] = "Aprendes a investigar {upgrade} desde el {building}",
    ["West-Zangarmarsh"] = "West-Zangarmarsh",
    ["Terokkar Forest"] = "Terokkar Forest",
    ["Stormwind Keep"] = "Stormwind Keep",
    ["The Great Forge"] = "The Great Forge",
    ["Silverpine Forest"] = "Silverpine Forest",
    ["Southshore"] = "Southshore",
    ["Hinterlands"] = "Hinterlands",
    ["Arathi Highlands"] = "Arathi Highlands",
    ["The Violet Citadel"] = "The Violet Citadel",

    // Gilneas
    ["Mount Hyjal"] = "Monte Hyjal",
    ["Learn to train Darius Crowley from the {altar}"] = "Aprendes a entrenar a Darius Crowley desde el {altar}",
    ["Learn to train {hero} from the {altar}, and learn to train {unit} from the {building}. If you're allied to the Druids, {hero}'s starting experience is halved"] =
      "Aprendes a entrenar a {hero} desde el {altar}, y aprendes a entrenar {unit} desde {building}. Si estás aliado con los Druidas, la experiencia inicial de {hero} se reduce a la mitad",

    // Lordaeron
    ["Alterac Mountains"] = "Alterac Mountains",
    ["Storm Peaks"] = "Storm Peaks",
    ["Learn to train {unit}s"] = "Aprendes a entrenar la unidad {unit}",
    ["Gain control of all units in Tyr's Hand, learn to train Garithos from the {altar}, and learn to build {building}s"] =
      "Obtienes control de todas las unidades en Tyr's Hand, aprendes a entrenar a Garithos desde el {altar}, y aprendes a construir {building}",
    ["Learn to train Alexandros Mograine from the {altar}"] = "Aprendes a entrenar a Alexandros Mograine desde el {altar}",
    ["Arthas becomes the King of Lordaeron, gains the {crown}, and he can no longer permanently die. Learn to build {tower}s. Your {knight}s become {gallantKnight}s and your {huntsman}s become {arbalest}s"] =
      "Arthas se convierte en el Rey de Lordaeron, obtiene la {crown}, y ya no puede morir permanentemente. Aprendes a construir {tower}. Tus {knight} se convierten en {gallantKnight} y tus {huntsman} se convierten en {arbalest}",

    // Scarlet Crusade
    ["Scarlet Monastery"] = "Scarlet Monastery",
    ["Sholazar Basin"] = "Sholazar Basin",
    ["in Brill"] = "en Brill",
    ["in Andorhal"] = "en Andorhal",
    ["in Dragonblight"] = "en el Cementerio de Dragones",
    ["Build {count} {building}s {area} ({current}/{count})"] = "Construye {count} {building} {area} ({current}/{count})",
    ["Build {building} {area}"] = "Construye {building} {area}",
    ["Learn to train Sally Whitemane from the {altar}"] = "Aprendes a entrenar a Sally Whitemane desde el {altar}",
    ["Your {unit1}s and {unit2} gain 400 hit points"] = "Tus {unit1} y {unit2} obtienen 400 puntos de vida",
    ["Your {unit} gain the Unholy Archon ability."] = "Tus {unit} obtienen la habilidad Unholy Archon.",

    // Druids
    ["Shrine to Malorne"] = "Shrine to Malorne",
    ["Felwood"] = "Felwood",
    ["Northern Ashenvale"] = "Northern Ashenvale",
    ["Southern Ashenvale"] = "Southern Ashenvale",
    ["Grizzly Hills"] = "Grizzly Hills",
    ["in Grizzly Hills"] = "en Colinas Pardas",
    ["Gain a new capital at Grizzly Hills that can research a powerful upgrade for your {unit}, and learn to train the hero Ursoc from the {altar}. If you're allied to the Scourge, {hero}'s starting experience is halved"] =
      "Obtienes una nueva capital en Colinas Pardas que puede investigar una mejora poderosa para tu {unit}, y aprendes a entrenar al héroe Ursoc desde el {altar}. Si estás aliado con la Plaga, la experiencia inicial de {hero} se reduce a la mitad",

  };
}
